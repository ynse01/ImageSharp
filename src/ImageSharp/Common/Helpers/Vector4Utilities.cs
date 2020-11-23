// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if SUPPORTS_RUNTIME_INTRINSICS
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

namespace SixLabors.ImageSharp
{
    /// <summary>
    /// Utility methods for the <see cref="Vector4"/> struct.
    /// </summary>
    internal static class Vector4Utilities
    {
        private const int BlendAlphaControl = 0b_10_00_10_00;
        private const int ShuffleAlphaControl = 0b_11_11_11_11;

        /// <summary>
        /// Pre-multiplies the "x", "y", "z" components of a vector by its "w" component leaving the "w" component intact.
        /// </summary>
        /// <param name="source">The <see cref="Vector4"/> to premultiply</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void Premultiply(ref Vector4 source)
        {
            float w = source.W;
            source *= w;
            source.W = w;
        }

        /// <summary>
        /// Reverses the result of premultiplying a vector via <see cref="Premultiply(ref Vector4)"/>.
        /// </summary>
        /// <param name="source">The <see cref="Vector4"/> to premultiply</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void UnPremultiply(ref Vector4 source)
        {
            float w = source.W;
            source /= w;
            source.W = w;
        }

        /// <summary>
        /// Bulk variant of <see cref="Premultiply(ref Vector4)"/>
        /// </summary>
        /// <param name="vectors">The span of vectors</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void Premultiply(Span<Vector4> vectors)
        {
#if SUPPORTS_RUNTIME_INTRINSICS
            if (Avx2.IsSupported && vectors.Length >= 2)
            {
                ref Vector256<float> vectorsBase =
                    ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference(vectors));

                // Divide by 2 as 4 elements per Vector4 and 8 per Vector256<float>
                ref Vector256<float> vectorsLast = ref Unsafe.Add(ref vectorsBase, (IntPtr)((uint)vectors.Length / 2u));

                while (Unsafe.IsAddressLessThan(ref vectorsBase, ref vectorsLast))
                {
                    Vector256<float> source = vectorsBase;
                    Vector256<float> multiply = Avx.Shuffle(source, source, ShuffleAlphaControl);
                    vectorsBase = Avx.Blend(Avx.Multiply(source, multiply), source, BlendAlphaControl);
                    vectorsBase = ref Unsafe.Add(ref vectorsBase, 1);
                }

                if (Numerics.Modulo2(vectors.Length) != 0)
                {
                    // Vector4 fits neatly in pairs. Any overlap has to be equal to 1.
                    Premultiply(ref MemoryMarshal.GetReference(vectors.Slice(vectors.Length - 1)));
                }
            }
            else
#endif
            {
                ref Vector4 baseRef = ref MemoryMarshal.GetReference(vectors);

                for (int i = 0; i < vectors.Length; i++)
                {
                    ref Vector4 v = ref Unsafe.Add(ref baseRef, i);
                    Premultiply(ref v);
                }
            }
        }

        /// <summary>
        /// Bulk variant of <see cref="UnPremultiply(ref Vector4)"/>
        /// </summary>
        /// <param name="vectors">The span of vectors</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void UnPremultiply(Span<Vector4> vectors)
        {
#if SUPPORTS_RUNTIME_INTRINSICS
            if (Avx2.IsSupported && vectors.Length >= 2)
            {
                ref Vector256<float> vectorsBase =
                    ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference(vectors));

                // Divide by 2 as 4 elements per Vector4 and 8 per Vector256<float>
                ref Vector256<float> vectorsLast = ref Unsafe.Add(ref vectorsBase, (IntPtr)((uint)vectors.Length / 2u));

                while (Unsafe.IsAddressLessThan(ref vectorsBase, ref vectorsLast))
                {
                    Vector256<float> source = vectorsBase;
                    Vector256<float> multiply = Avx.Shuffle(source, source, ShuffleAlphaControl);
                    vectorsBase = Avx.Blend(Avx.Divide(source, multiply), source, BlendAlphaControl);
                    vectorsBase = ref Unsafe.Add(ref vectorsBase, 1);
                }

                if (Numerics.Modulo2(vectors.Length) != 0)
                {
                    // Vector4 fits neatly in pairs. Any overlap has to be equal to 1.
                    UnPremultiply(ref MemoryMarshal.GetReference(vectors.Slice(vectors.Length - 1)));
                }
            }
            else
#endif
            {
                ref Vector4 baseRef = ref MemoryMarshal.GetReference(vectors);

                for (int i = 0; i < vectors.Length; i++)
                {
                    ref Vector4 v = ref Unsafe.Add(ref baseRef, i);
                    UnPremultiply(ref v);
                }
            }
        }

        /// <summary>
        /// Transforms a vector by the given matrix.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="matrix">The transformation matrix.</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void Transform(ref Vector4 vector, ref ColorMatrix matrix)
        {
            float x = vector.X;
            float y = vector.Y;
            float z = vector.Z;
            float w = vector.W;

            vector.X = (x * matrix.M11) + (y * matrix.M21) + (z * matrix.M31) + (w * matrix.M41) + matrix.M51;
            vector.Y = (x * matrix.M12) + (y * matrix.M22) + (z * matrix.M32) + (w * matrix.M42) + matrix.M52;
            vector.Z = (x * matrix.M13) + (y * matrix.M23) + (z * matrix.M33) + (w * matrix.M43) + matrix.M53;
            vector.W = (x * matrix.M14) + (y * matrix.M24) + (z * matrix.M34) + (w * matrix.M44) + matrix.M54;
        }

        /// <summary>
        /// Bulk variant of <see cref="Transform(ref Vector4, ref ColorMatrix)"/>.
        /// </summary>
        /// <param name="vectors">The span of vectors</param>
        /// <param name="matrix">The transformation matrix.</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static void Transform(Span<Vector4> vectors, ref ColorMatrix matrix)
        {
            ref Vector4 baseRef = ref MemoryMarshal.GetReference(vectors);

            for (int i = 0; i < vectors.Length; i++)
            {
                ref Vector4 v = ref Unsafe.Add(ref baseRef, i);
                Transform(ref v, ref matrix);
            }
        }
    }
}
