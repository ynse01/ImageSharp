// Copyright (c) Six Labors and contributors.
// Licensed under the GNU Affero General Public License, Version 3.

using System;
using System.IO;
using Microsoft.DotNet.RemoteExecutor;

using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Tests.TestUtilities;
using SixLabors.ImageSharp.Tests.TestUtilities.ImageComparison;
using SixLabors.ImageSharp.Tests.TestUtilities.ReferenceCodecs;
using Xunit;

// ReSharper disable InconsistentNaming
namespace SixLabors.ImageSharp.Tests.Formats.Gif
{
    public class GifDecoderTests
    {
        private const PixelTypes TestPixelTypes = PixelTypes.Rgba32 | PixelTypes.RgbaVector | PixelTypes.Argb32;

        private static GifDecoder GifDecoder => new GifDecoder();

        [Theory]
        [WithFile(TestImages.Gif.Cheers, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.RestoreNotDispose, PixelTypes.Rgba32)]
        public void Decode_WithDisposeMethod_NotDispose_VerifyAllFrames<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);
                image.CompareToOriginal(provider);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Kumin, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.RestoreToBackground, PixelTypes.Rgba32)]
        public void Decode_WithDisposeMethod_RestoreToBackground_VerifyAllFrames<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);
                image.CompareToOriginal(provider);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.RestoreToPrevious, PixelTypes.Rgba32)]
        public void Decode_WithDisposeMethod_Previous_VerifyAllFrames<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);
                image.CompareToOriginal(provider);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Giphy, PixelTypes.Rgba32)]
        public void Decode_WithDisposeMethod_RestoreToBackground_LocalPalette_VerifyAllFrames<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);

                // Note: Using here magick reference decoder instead of Drawing, because drawing decoder
                // seems to ignore local color palette and uses (255, 255, 255, 0) from the global palette,
                // instead of (0, 0, 0, 0) to restore the background.
                image.CompareToOriginal(provider, new MagickReferenceDecoder());
            }
        }

        [Fact]
        public unsafe void Decode_NonTerminatedFinalFrame()
        {
            var testFile = TestFile.Create(TestImages.Gif.Rings);

            int length = testFile.Bytes.Length - 2;

            fixed (byte* data = testFile.Bytes.AsSpan(0, length))
            {
                using (var stream = new UnmanagedMemoryStream(data, length))
                {
                    using (Image<Rgba32> image = GifDecoder.Decode<Rgba32>(Configuration.Default, stream))
                    {
                        Assert.Equal((200, 200), (image.Width, image.Height));
                    }
                }
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Trans, TestPixelTypes)]
        public void GifDecoder_IsNotBoundToSinglePixelType<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);

                // Note: The drawing reference decoder sets the transparent pixels to zero (0, 0, 0, 0) instead of the transparent color.
                // Magick does use the transparent color from the palette, as ImageSharp which initializes the image with the
                // transparent color if the transparent color flag is set.
                image.CompareToOriginal(provider, new MagickReferenceDecoder());
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Cheers, PixelTypes.Rgba32, 93)]
        [WithFile(TestImages.Gif.Rings, PixelTypes.Rgba32, 1)]
        [WithFile(TestImages.Gif.Issues.BadDescriptorWidth, PixelTypes.Rgba32, 36)]
        public void Decode_VerifyRootFrameAndFrameCount<TPixel>(TestImageProvider<TPixel> provider, int expectedFrameCount)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                Assert.Equal(expectedFrameCount, image.Frames.Count);
                image.DebugSave(provider);
                image.CompareFirstFrameToReferenceOutput(ImageComparer.Exact, provider);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Giphy, PixelTypes.Rgba32)]
        public void CanDecodeJustOneFrame<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(new GifDecoder { DecodingMode = FrameDecodingMode.First }))
            {
                Assert.Equal(1, image.Frames.Count);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Giphy, PixelTypes.Rgba32)]
        public void CanDecodeAllFrames<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(new GifDecoder { DecodingMode = FrameDecodingMode.All }))
            {
                Assert.Equal(5, image.Frames.Count);
            }
        }

        [Theory]
        [InlineData(TestImages.Gif.Cheers, 8)]
        [InlineData(TestImages.Gif.Giphy, 8)]
        [InlineData(TestImages.Gif.Rings, 8)]
        [InlineData(TestImages.Gif.Trans, 8)]
        public void DetectPixelSize(string imagePath, int expectedPixelSize)
        {
            var testFile = TestFile.Create(imagePath);
            using (var stream = new MemoryStream(testFile.Bytes, false))
            {
                Assert.Equal(expectedPixelSize, Image.Identify(stream)?.PixelType?.BitsPerPixel);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.ZeroSize, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.ZeroWidth, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.ZeroHeight, PixelTypes.Rgba32)]
        public void Decode_WithInvalidDimensions_DoesThrowException<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            System.Exception ex = Record.Exception(
                () =>
                {
                    using Image<TPixel> image = provider.GetImage(GifDecoder);
                });
            Assert.NotNull(ex);
            Assert.Contains("Width or height should not be 0", ex.Message);
        }

        [Theory]
        [WithFile(TestImages.Gif.MaxWidth, PixelTypes.Rgba32, 65535, 1)]
        [WithFile(TestImages.Gif.MaxHeight, PixelTypes.Rgba32, 1, 65535)]
        public void Decode_WithMaxDimensions_Works<TPixel>(TestImageProvider<TPixel> provider, int expectedWidth, int expectedHeight)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                Assert.Equal(expectedWidth, image.Width);
                Assert.Equal(expectedHeight, image.Height);
            }
        }

        [Fact]
        public void CanDecodeIntermingledImages()
        {
            using (var kumin1 = Image.Load(TestFile.Create(TestImages.Gif.Kumin).Bytes))
            using (Image.Load(TestFile.Create(TestImages.Png.Icon).Bytes))
            using (var kumin2 = Image.Load(TestFile.Create(TestImages.Gif.Kumin).Bytes))
            {
                for (int i = 0; i < kumin1.Frames.Count; i++)
                {
                    ImageFrame<Rgba32> first = kumin1.Frames[i];
                    ImageFrame<Rgba32> second = kumin2.Frames[i];

                    Assert.True(second.TryGetSinglePixelSpan(out Span<Rgba32> secondSpan));

                    first.ComparePixelBufferTo(secondSpan);
                }
            }
        }

        // https://github.com/SixLabors/ImageSharp/issues/405
        [Theory]
        [WithFile(TestImages.Gif.Issues.BadAppExtLength, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.Issues.BadAppExtLength_2, PixelTypes.Rgba32)]
        public void Issue405_BadApplicationExtensionBlockLength<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage(GifDecoder))
            {
                image.DebugSave(provider);
                image.CompareToOriginal(provider);
            }
        }

        [Theory]
        [WithFile(TestImages.Gif.Giphy, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.Kumin, PixelTypes.Rgba32)]
        public void GifDecoder_DegenerateMemoryRequest_ShouldTranslateTo_ImageFormatException<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            provider.LimitAllocatorBufferCapacity().InPixelsSqrt(10);
            InvalidImageContentException ex = Assert.Throws<InvalidImageContentException>(() => provider.GetImage(GifDecoder));
            Assert.IsType<InvalidMemoryOperationException>(ex.InnerException);
        }

        [Theory]
        [WithFile(TestImages.Gif.Giphy, PixelTypes.Rgba32)]
        [WithFile(TestImages.Gif.Kumin, PixelTypes.Rgba32)]
        public void GifDecoder_CanDecode_WithLimitedAllocatorBufferCapacity<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            static void RunTest(string providerDump, string nonContiguousBuffersStr)
            {
                TestImageProvider<TPixel> provider = BasicSerializer.Deserialize<TestImageProvider<TPixel>>(providerDump);

                provider.LimitAllocatorBufferCapacity().InPixelsSqrt(100);

                using Image<TPixel> image = provider.GetImage(GifDecoder);
                image.DebugSave(provider);
                image.CompareToOriginal(provider);
            }

            string providerDump = BasicSerializer.Serialize(provider);
            RemoteExecutor.Invoke(
                    RunTest,
                    providerDump,
                    "Disco")
                .Dispose();
        }
    }
}
