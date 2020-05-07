// Copyright (c) Six Labors and contributors.
// Licensed under the GNU Affero General Public License, Version 3.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Tests.TestUtilities.ReferenceCodecs
{
    public class SystemDrawingReferenceDecoder : IImageDecoder, IImageInfoDetector
    {
        public static SystemDrawingReferenceDecoder Instance { get; } = new SystemDrawingReferenceDecoder();

        public Image<TPixel> Decode<TPixel>(Configuration configuration, Stream stream)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (var sourceBitmap = new Bitmap(stream))
            {
                if (sourceBitmap.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    if (sourceBitmap.RawFormat.Equals(ImageFormat.Gif) && ImageAnimator.CanAnimate(sourceBitmap))
                    {
                        Image<TPixel> multiFrameImage = SystemDrawingBridge.From32bppArgbSystemDrawingBitmap<TPixel>(sourceBitmap);
                        int frameCount = sourceBitmap.GetFrameCount(FrameDimension.Time);
                        byte[] frameDelay = sourceBitmap.GetPropertyItem(20736).Value;
                        int delayIndex = 0;
                        for (int i = 1; i < frameCount; i++)
                        {
                            sourceBitmap.SelectActiveFrame(FrameDimension.Time, i);
                            var delay = BitConverter.ToInt32(frameDelay, delayIndex);
                            SystemDrawingBridge.AddFrameWithDelay(sourceBitmap, multiFrameImage, delay);
                            delayIndex += 4;
                        }

                        return multiFrameImage;
                    }

                    return SystemDrawingBridge.From32bppArgbSystemDrawingBitmap<TPixel>(sourceBitmap);
                }

                using (var convertedBitmap = new Bitmap(
                    sourceBitmap.Width,
                    sourceBitmap.Height,
                    PixelFormat.Format32bppArgb))
                {
                    using (var g = Graphics.FromImage(convertedBitmap))
                    {
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        g.DrawImage(sourceBitmap, 0, 0, sourceBitmap.Width, sourceBitmap.Height);
                    }

                    return SystemDrawingBridge.From32bppArgbSystemDrawingBitmap<TPixel>(convertedBitmap);
                }
            }
        }

        public IImageInfo Identify(Configuration configuration, Stream stream)
        {
            using (var sourceBitmap = new Bitmap(stream))
            {
                var pixelType = new PixelTypeInfo(System.Drawing.Image.GetPixelFormatSize(sourceBitmap.PixelFormat));
                return new ImageInfo(pixelType, sourceBitmap.Width, sourceBitmap.Height, new ImageMetadata());
            }
        }

        public Image Decode(Configuration configuration, Stream stream) => this.Decode<Rgba32>(configuration, stream);
    }
}
