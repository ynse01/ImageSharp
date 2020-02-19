// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace SixLabors.ImageSharp.Processing.Processors.Dithering
{
    /// <summary>
    /// An error diffusion dithering implementation.
    /// <see href="http://www.efg2.com/Lab/Library/ImageProcessing/DHALF.TXT"/>
    /// </summary>
    public readonly partial struct ErrorDither : IDither, IEquatable<ErrorDither>
    {
        private readonly int offset;
        private readonly DenseMatrix<float> matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDither"/> struct.
        /// </summary>
        /// <param name="matrix">The diffusion matrix.</param>
        /// <param name="offset">The starting offset within the matrix.</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public ErrorDither(in DenseMatrix<float> matrix, int offset)
        {
            this.matrix = matrix;
            this.offset = offset;
        }

        /// <inheritdoc/>
        [MethodImpl(InliningOptions.ShortMethod)]
        public void ApplyQuantizationDither<TFrameQuantizer, TPixel>(
            ref TFrameQuantizer quantizer,
            ReadOnlyMemory<TPixel> palette,
            ImageFrame<TPixel> source,
            Memory<byte> output,
            Rectangle bounds)
            where TFrameQuantizer : struct, IFrameQuantizer<TPixel>
            where TPixel : struct, IPixel<TPixel>
        {
            Span<byte> outputSpan = output.Span;
            ReadOnlySpan<TPixel> paletteSpan = palette.Span;
            int width = bounds.Width;
            int offsetY = bounds.Top;
            int offsetX = bounds.Left;
            float scale = quantizer.Options.DitherScale;

            for (int y = bounds.Top; y < bounds.Bottom; y++)
            {
                Span<TPixel> row = source.GetPixelRowSpan(y);
                int rowStart = (y - offsetY) * width;

                for (int x = bounds.Left; x < bounds.Right; x++)
                {
                    TPixel sourcePixel = row[x];
                    outputSpan[rowStart + x - offsetX] = quantizer.GetQuantizedColor(sourcePixel, paletteSpan, out TPixel transformed);
                    this.Dither(source, bounds, sourcePixel, transformed, x, y, scale);
                }
            }
        }

        /// <inheritdoc/>
        [MethodImpl(InliningOptions.ShortMethod)]
        public void ApplyPaletteDither<TPixel>(
            Configuration configuration,
            ReadOnlyMemory<TPixel> palette,
            ImageFrame<TPixel> source,
            Rectangle bounds,
            float scale)
            where TPixel : struct, IPixel<TPixel>
        {
            var pixelMap = new EuclideanPixelMap<TPixel>(palette);

            for (int y = bounds.Top; y < bounds.Bottom; y++)
            {
                Span<TPixel> row = source.GetPixelRowSpan(y);
                for (int x = bounds.Left; x < bounds.Right; x++)
                {
                    TPixel sourcePixel = row[x];
                    pixelMap.GetClosestColor(sourcePixel, out TPixel transformed);
                    this.Dither(source, bounds, sourcePixel, transformed, x, y, scale);
                    row[x] = transformed;
                }
            }
        }

        // Internal for AOT
        [MethodImpl(InliningOptions.ShortMethod)]
        internal TPixel Dither<TPixel>(
            ImageFrame<TPixel> image,
            Rectangle bounds,
            TPixel source,
            TPixel transformed,
            int x,
            int y,
            float scale)
            where TPixel : struct, IPixel<TPixel>
        {
            // Equal? Break out as there's no error to pass.
            if (source.Equals(transformed))
            {
                return transformed;
            }

            // Calculate the error
            Vector4 error = (source.ToVector4() - transformed.ToVector4()) * scale;

            int offset = this.offset;
            DenseMatrix<float> matrix = this.matrix;

            // Loop through and distribute the error amongst neighboring pixels.
            for (int row = 0, targetY = y; row < matrix.Rows; row++, targetY++)
            {
                if (targetY >= bounds.Bottom)
                {
                    continue;
                }

                Span<TPixel> rowSpan = image.GetPixelRowSpan(targetY);

                for (int col = 0; col < matrix.Columns; col++)
                {
                    int targetX = x + (col - offset);
                    if (targetX < bounds.Left || targetX >= bounds.Right)
                    {
                        continue;
                    }

                    float coefficient = matrix[row, col];
                    if (coefficient == 0)
                    {
                        continue;
                    }

                    ref TPixel pixel = ref rowSpan[targetX];
                    var result = pixel.ToVector4();

                    result += error * coefficient;
                    pixel.FromVector4(result);
                }
            }

            return transformed;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
            => obj is ErrorDither dither && this.Equals(dither);

        /// <inheritdoc/>
        public bool Equals(ErrorDither other)
            => this.offset == other.offset && this.matrix.Equals(other.matrix);

        /// <inheritdoc/>
        public override int GetHashCode()
            => HashCode.Combine(this.offset, this.matrix);
    }
}
