// Copyright (c) Six Labors and contributors.
// Licensed under the GNU Affero General Public License, Version 3.

using System;
using System.Buffers;
using System.Drawing;
using System.Drawing.Imaging;

using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Tests.TestUtilities.ReferenceCodecs
{
    /// <summary>
    /// Provides methods to convert to/from System.Drawing bitmaps.
    /// </summary>
    public static class SystemDrawingBridge
    {
        /// <summary>
        /// Returns an image from the given System.Drawing bitmap.
        /// </summary>
        /// <typeparam name="TPixel">The pixel format.</typeparam>
        /// <param name="bmp">The input bitmap.</param>
        /// <exception cref="ArgumentException">Thrown if the image pixel format is not of type <see cref="PixelFormat.Format32bppArgb"/></exception>
        internal static unsafe Image<TPixel> From32bppArgbSystemDrawingBitmap<TPixel>(Bitmap bmp)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            var image = new Image<TPixel>(bmp.Width, bmp.Height);
            CopyDataFrom32BppDrawingBitmap(bmp, image);

            return image;
        }

        /// <summary>
        /// Returns an image from the given System.Drawing bitmap.
        /// </summary>
        /// <typeparam name="TPixel">The pixel format.</typeparam>
        /// <param name="bmp">The input bitmap.</param>
        /// <exception cref="ArgumentException">Thrown if the image pixel format is not of type <see cref="PixelFormat.Format24bppRgb"/></exception>
        internal static unsafe Image<TPixel> From24bppRgbSystemDrawingBitmap<TPixel>(Bitmap bmp)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            if (bmp.PixelFormat != PixelFormat.Format24bppRgb)
            {
                throw new ArgumentException(
                    $"{nameof(From24bppRgbSystemDrawingBitmap)}: pixel format should be {PixelFormat.Format24bppRgb}!",
                    nameof(bmp));
            }

            int w = bmp.Width;
            int h = bmp.Height;

            var fullRect = new System.Drawing.Rectangle(0, 0, w, h);

            BitmapData data = bmp.LockBits(fullRect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            var image = new Image<TPixel>(w, h);
            try
            {
                byte* sourcePtrBase = (byte*)data.Scan0;

                long sourceRowByteCount = data.Stride;
                long destRowByteCount = w * sizeof(Bgr24);

                Configuration configuration = image.GetConfiguration();

                using (IMemoryOwner<Bgr24> workBuffer = Configuration.Default.MemoryAllocator.Allocate<Bgr24>(w))
                {
                    fixed (Bgr24* destPtr = &workBuffer.GetReference())
                    {
                        for (int y = 0; y < h; y++)
                        {
                            Span<TPixel> row = image.Frames.RootFrame.GetPixelRowSpan(y);

                            byte* sourcePtr = sourcePtrBase + (data.Stride * y);

                            Buffer.MemoryCopy(sourcePtr, destPtr, destRowByteCount, sourceRowByteCount);
                            PixelOperations<TPixel>.Instance.FromBgr24(configuration, workBuffer.GetSpan().Slice(0, w), row);
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(data);
            }

            return image;
        }

        /// <summary>
        /// Adds a new frame to the image and copies the data from the given System.Drawing bitmap to it.
        /// </summary>
        /// <typeparam name="TPixel">The pixel format.</typeparam>
        /// <param name="bmp">The bitmap to copy data from.</param>
        /// <param name="image">The destination image.</param>
        /// <param name="delay">The frame delay in number of hundredths (1/100) of a second.</param>
        public static void AddFrameWithDelay<TPixel>(Bitmap bmp, Image<TPixel> image, int delay)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            image.Frames.CreateFrame();
            var frameIdx = image.Frames.Count - 1;
            image.Frames[frameIdx].Metadata.GetGifMetadata().FrameDelay = delay;
            CopyDataFrom32BppDrawingBitmap(bmp, image, frameIdx);
        }

        /// <summary>
        /// Copies data from a System.Drawing Bitmap to a ImageSharp image.
        /// </summary>
        /// <typeparam name="TPixel">The pixel format.</typeparam>
        /// <param name="bmp">The bitmap to copy from.</param>
        /// <param name="image">The destination image.</param>
        /// <param name="frameIndex">The frame index. Defaults to zero</param>
        private static unsafe void CopyDataFrom32BppDrawingBitmap<TPixel>(Bitmap bmp, Image<TPixel> image, int frameIndex = 0)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ArgumentException(
                    $"{nameof(From32bppArgbSystemDrawingBitmap)} : pixel format should be {PixelFormat.Format32bppArgb}!",
                    nameof(bmp));
            }

            int w = bmp.Width;
            int h = bmp.Height;

            var fullRect = new System.Drawing.Rectangle(0, 0, w, h);

            BitmapData data = bmp.LockBits(fullRect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            try
            {
                byte* sourcePtrBase = (byte*)data.Scan0;

                long sourceRowByteCount = data.Stride;
                long destRowByteCount = w * sizeof(Bgra32);

                Configuration configuration = image.GetConfiguration();

                using (IMemoryOwner<Bgra32> workBuffer = Configuration.Default.MemoryAllocator.Allocate<Bgra32>(w))
                {
                    fixed (Bgra32* destPtr = &workBuffer.GetReference())
                    {
                        for (int y = 0; y < h; y++)
                        {
                            Span<TPixel> row = image.Frames[frameIndex].GetPixelRowSpan(y);

                            byte* sourcePtr = sourcePtrBase + (data.Stride * y);

                            Buffer.MemoryCopy(sourcePtr, destPtr, destRowByteCount, sourceRowByteCount);
                            PixelOperations<TPixel>.Instance.FromBgra32(
                                configuration,
                                workBuffer.GetSpan().Slice(0, w),
                                row);
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(data);
            }
        }

        /// <summary>
        /// Converts a ImageSharp image to a System.Drawing Bitmap.
        /// </summary>
        /// <typeparam name="TPixel">The pixel format.</typeparam>
        /// <param name="image">The image to convert.</param>
        /// <returns>A System.Drawing Bitmap.</returns>
        internal static unsafe Bitmap To32bppArgbSystemDrawingBitmap<TPixel>(Image<TPixel> image)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            Configuration configuration = image.GetConfiguration();
            int w = image.Width;
            int h = image.Height;

            var resultBitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            var fullRect = new System.Drawing.Rectangle(0, 0, w, h);
            BitmapData data = resultBitmap.LockBits(fullRect, ImageLockMode.ReadWrite, resultBitmap.PixelFormat);
            try
            {
                byte* destPtrBase = (byte*)data.Scan0;

                long destRowByteCount = data.Stride;
                long sourceRowByteCount = w * sizeof(Bgra32);

                using (IMemoryOwner<Bgra32> workBuffer = image.GetConfiguration().MemoryAllocator.Allocate<Bgra32>(w))
                {
                    fixed (Bgra32* sourcePtr = &workBuffer.GetReference())
                    {
                        for (int y = 0; y < h; y++)
                        {
                            Span<TPixel> row = image.Frames.RootFrame.GetPixelRowSpan(y);
                            PixelOperations<TPixel>.Instance.ToBgra32(configuration, row, workBuffer.GetSpan());
                            byte* destPtr = destPtrBase + (data.Stride * y);

                            Buffer.MemoryCopy(sourcePtr, destPtr, destRowByteCount, sourceRowByteCount);
                        }
                    }
                }
            }
            finally
            {
                resultBitmap.UnlockBits(data);
            }

            return resultBitmap;
        }
    }
}
