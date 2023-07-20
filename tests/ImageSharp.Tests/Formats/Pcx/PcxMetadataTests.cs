// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Pcx;
using static SixLabors.ImageSharp.Tests.TestImages.Pcx;

// ReSharper disable InconsistentNaming
namespace SixLabors.ImageSharp.Tests.Formats.Pcx;

[Trait("Format", "Pcx")]
public class PcxMetadataTests
{
    [Fact]
    public void CloneIsDeep()
    {
        PcxMetadata meta = new()
        { ColorType = PcxColorType.Grayscale };
        PcxMetadata clone = (PcxMetadata)meta.DeepClone();

        clone.ColorType = PcxColorType.Rgb;

        Assert.False(meta.ColorType.Equals(clone.ColorType));
    }

    [Theory]
    [InlineData(BlackAndWhite, PcxColorType.BlackAndWhite)]
    [InlineData(Palette16Colors, PcxColorType.Palette)]
    [InlineData(Palette16ColorsAlpha, PcxColorType.Palette)]
    [InlineData(RgbLandscape, PcxColorType.Rgb)]
    public void Identify_DetectsCorrectColorType(string imagePath, PcxColorType expectedColorType)
    {
        TestFile testFile = TestFile.Create(imagePath);
        using MemoryStream stream = new(testFile.Bytes, false);
        ImageInfo imageInfo = Image.Identify(stream);
        Assert.NotNull(imageInfo);
        PcxMetadata bitmapMetadata = imageInfo.Metadata.GetPcxMetadata();
        Assert.NotNull(bitmapMetadata);
        Assert.Equal(expectedColorType, bitmapMetadata.ColorType);
    }

    [Theory]
    [InlineData(BlackAndWhite, 1)]
    [InlineData(Palette16Colors, 4)]
    [InlineData(Palette16ColorsAlpha, 4)]
    [InlineData(RgbLandscape, 8)]
    public void Identify_DetectsCorrectBitsPerPixel(string imagePath, int expectedBitsPerPixel)
    {
        TestFile testFile = TestFile.Create(imagePath);
        using MemoryStream stream = new(testFile.Bytes, false);
        ImageInfo imageInfo = Image.Identify(stream);
        Assert.NotNull(imageInfo);
        PcxMetadata bitmapMetadata = imageInfo.Metadata.GetPcxMetadata();
        Assert.NotNull(bitmapMetadata);
        Assert.Equal(expectedBitsPerPixel, bitmapMetadata.BitsPerPixel);
    }

    [Theory]
    [InlineData(BlackAndWhite, 1)]
    [InlineData(Palette16Colors, 1)]
    [InlineData(Palette16ColorsAlpha, 1)]
    [InlineData(RgbLandscape, 3)]
    public void Identify_DetectsCorrectComponentCount(string imagePath, int expectedComponentCount)
    {
        TestFile testFile = TestFile.Create(imagePath);
        using MemoryStream stream = new(testFile.Bytes, false);
        ImageInfo imageInfo = Image.Identify(stream);
        Assert.NotNull(imageInfo);
        PcxMetadata bitmapMetadata = imageInfo.Metadata.GetPcxMetadata();
        Assert.NotNull(bitmapMetadata);
        Assert.Equal(expectedComponentCount, bitmapMetadata.ComponentCount);
    }
}
