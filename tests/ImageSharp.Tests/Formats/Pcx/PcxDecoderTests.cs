// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Pcx;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Tests.TestUtilities.ImageComparison;
using static SixLabors.ImageSharp.Tests.TestImages.Pcx;

// ReSharper disable InconsistentNaming
namespace SixLabors.ImageSharp.Tests.Formats.Pcx;

[Trait("Format", "Pcx")]
[ValidateDisposedMemoryAllocations]
public class PcxDecoderTests
{
    [Theory]
    [InlineData(BlackAndWhite, PcxColorType.BlackAndWhite)]
    [InlineData(Palette16Colors, PcxColorType.Palette)]
    [InlineData(Palette16ColorsAlpha, PcxColorType.Palette)]
    [InlineData(RgbLandscape, PcxColorType.Rgb)]
    [InlineData(YellowCat, PcxColorType.Palette)]
    public void ImageLoadCanDecode(string imagePath, PcxColorType expectedColorType)
    {
        // Arrange
        var testFile = TestFile.Create(imagePath);
        using var stream = new MemoryStream(testFile.Bytes, false);

        // Act
        using var image = Image.Load(stream);

        // Assert
        Assert.NotNull(image);
        PcxMetadata metadata = image.Metadata.GetPcxMetadata();
        Assert.NotNull(metadata);
        Assert.Equal(expectedColorType, metadata.ColorType);
    }

    [Theory]
    [InlineData(BlackAndWhite)]
    [InlineData(Palette16Colors)]
    [InlineData(Palette16ColorsAlpha)]
    [InlineData(RgbLandscape)]
    [InlineData(YellowCat)]
    public void ImageLoadL8CanDecode(string imagePath)
    {
        // Arrange
        var testFile = TestFile.Create(imagePath);
        using var stream = new MemoryStream(testFile.Bytes, false);

        // Act
        using var image = Image.Load<L8>(stream);

        // Assert
        Assert.NotNull(image);
    }

    [Theory]
    [InlineData(RgbLandscape)]
    [InlineData(Palette16Colors)]
    [InlineData(Palette16ColorsAlpha)]
    public void ImageLoadRgb24CanDecode(string imagePath)
    {
        // Arrange
        var testFile = TestFile.Create(imagePath);
        using var stream = new MemoryStream(testFile.Bytes, false);

        // Act
        using var image = Image.Load<Rgb24>(stream);

        // Assert
        Assert.NotNull(image);
    }

    [Theory]
    [WithFile(BlackAndWhite, PixelTypes.L8)]
    [WithFile(Palette16Colors, PixelTypes.Rgb24)]
    [WithFile(Palette16ColorsAlpha, PixelTypes.Rgba32)]
    [WithFile(RgbLandscape, PixelTypes.Rgb24)]
    public void DecodeReferenceImage<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        using Image<TPixel> image = provider.GetImage();
        image.DebugSave(provider, extension: "pcx");

        image.CompareToReferenceOutput(provider);
    }

    [Theory]
    [WithFile(RgbLandscape, PixelTypes.Rgb24)]
    public void PcxDecoder_Decode_Resize<TPixel>(TestImageProvider<TPixel> provider)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        DecoderOptions options = new()
        {
            TargetSize = new() { Width = 150, Height = 150 }
        };

        using Image<TPixel> image = provider.GetImage(PcxDecoder.Instance, options);

        FormattableString details = $"{options.TargetSize.Value.Width}_{options.TargetSize.Value.Height}";

        image.DebugSave(provider, testOutputDetails: details, appendPixelTypeToFileName: false);
        image.CompareToReferenceOutput(
            ImageComparer.Exact,
            provider,
            testOutputDetails: details,
            appendPixelTypeToFileName: false);
    }
}
