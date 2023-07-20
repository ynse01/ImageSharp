// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Pcx;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Tests.TestUtilities.ImageComparison;
using static SixLabors.ImageSharp.Tests.TestImages.Pcx;

// ReSharper disable InconsistentNaming
namespace SixLabors.ImageSharp.Tests.Formats.Pcx;

[Collection("RunSerial")]
[Trait("Format", "Pbm")]
public class PcxEncoderTests
{
    public static readonly TheoryData<PcxColorType> ColorType =
        new()
        {
            PcxColorType.BlackAndWhite,
            PcxColorType.Grayscale,
            PcxColorType.Rgb
        };

    public static readonly TheoryData<string, PcxColorType> PcxColorTypeFiles =
        new()
        {
            { BlackAndWhite, PcxColorType.BlackAndWhite },
            { Palette16Colors, PcxColorType.Palette },
            { Palette16ColorsAlpha, PcxColorType.Palette },
            { RgbLandscape, PcxColorType.Rgb },
        };

    [Theory]
    [MemberData(nameof(PcxColorTypeFiles))]
    public void PcxEncoder_PreserveColorType(string imagePath, PcxColorType pcxColorType)
    {
        var options = new PcxEncoder();

        var testFile = TestFile.Create(imagePath);
        using (Image<Rgba32> input = testFile.CreateRgba32Image())
        {
            using (var memStream = new MemoryStream())
            {
                input.Save(memStream, options);
                memStream.Position = 0;
                using (var output = Image.Load<Rgba32>(memStream))
                {
                    PcxMetadata meta = output.Metadata.GetPcxMetadata();
                    Assert.Equal(pcxColorType, meta.ColorType);
                }
            }
        }
    }

    [Theory]
    [MemberData(nameof(PcxColorTypeFiles))]
    public void PcxEncoder_PreserveBitsPerPixel(string imagePath, PcxColorType pbmColorType)
    {
        var options = new PcxEncoder();

        var testFile = TestFile.Create(imagePath);
        using (Image<Rgba32> input = testFile.CreateRgba32Image())
        {
            using (var memStream = new MemoryStream())
            {
                input.Save(memStream, options);

                // EOF indicator for plain is a Space.
                memStream.Seek(-1, SeekOrigin.End);
                int lastByte = memStream.ReadByte();
                Assert.Equal(0x20, lastByte);

                memStream.Seek(0, SeekOrigin.Begin);
                using (var output = Image.Load<Rgba32>(memStream))
                {
                    PcxMetadata meta = output.Metadata.GetPcxMetadata();
                    Assert.Equal(pbmColorType, meta.ColorType);
                }
            }
        }
    }

    [Theory]
    [WithFile(BlackAndWhite, PixelTypes.Rgb24)]
    public void PcxEncoder_P4_Works<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel> => TestPcxEncoderCore(provider, PcxColorType.BlackAndWhite);

    [Theory]
    [WithFile(Palette16Colors, PixelTypes.Rgb24)]
    public void PcxEncoder_P2_Works<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel> => TestPcxEncoderCore(provider, PcxColorType.Grayscale);

    [Theory]
    [WithFile(Palette16ColorsAlpha, PixelTypes.Rgb24)]
    public void PcxEncoder_P5_Works<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel> => TestPcxEncoderCore(provider, PcxColorType.Grayscale);

    [Theory]
    [WithFile(RgbLandscape, PixelTypes.Rgb24)]
    public void PcxEncoder_P3_Works<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel> => TestPcxEncoderCore(provider, PcxColorType.Rgb);

    [Theory]
    [WithFile(RgbLandscape, PixelTypes.Rgb24)]
    public void PcxEncoder_P6_Works<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel> => TestPcxEncoderCore(provider, PcxColorType.Rgb);

    private static void TestPcxEncoderCore<TPixel>(
        TestImageProvider<TPixel> provider,
        PcxColorType colorType,
        bool useExactComparer = true,
        float compareTolerance = 0.01f)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        using (Image<TPixel> image = provider.GetImage())
        {
            var encoder = new PcxEncoder { ColorMode = colorType };

            using (var memStream = new MemoryStream())
            {
                image.Save(memStream, encoder);
                memStream.Position = 0;
                using (var encodedImage = (Image<TPixel>)Image.Load(memStream))
                {
                    ImageComparingUtils.CompareWithReferenceDecoder(provider, encodedImage, useExactComparer, compareTolerance);
                }
            }
        }
    }
}
