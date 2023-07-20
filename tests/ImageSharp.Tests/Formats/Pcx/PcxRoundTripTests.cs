// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Tests.TestUtilities.ImageComparison;
using static SixLabors.ImageSharp.Tests.TestImages.Pcx;

// ReSharper disable InconsistentNaming
namespace SixLabors.ImageSharp.Tests.Formats.Pcx;

[Trait("Format", "Pcx")]
public class PcxRoundTripTests
{
    [Theory]
    [InlineData(BlackAndWhite)]
    public void PcxGrayscaleImageCanRoundTrip(string imagePath)
    {
        // Arrange
        var testFile = TestFile.Create(imagePath);
        using var stream = new MemoryStream(testFile.Bytes, false);

        // Act
        using var originalImage = Image.Load(stream);
        using Image<Rgb24> colorImage = originalImage.CloneAs<Rgb24>();
        using Image<Rgb24> encodedImage = RoundTrip(colorImage);

        // Assert
        Assert.NotNull(encodedImage);
        ImageComparer.Exact.VerifySimilarity(colorImage, encodedImage);
    }

    [Theory]
    [InlineData(Palette16Colors)]
    [InlineData(Palette16ColorsAlpha)]
    [InlineData(RgbLandscape)]
    public void PcxColorImageCanRoundTrip(string imagePath)
    {
        // Arrange
        var testFile = TestFile.Create(imagePath);
        using var stream = new MemoryStream(testFile.Bytes, false);

        // Act
        using var originalImage = Image.Load<Rgb24>(stream);
        using Image<Rgb24> encodedImage = RoundTrip(originalImage);

        // Assert
        Assert.NotNull(encodedImage);
        ImageComparer.Exact.VerifySimilarity(originalImage, encodedImage);
    }

    private static Image<TPixel> RoundTrip<TPixel>(Image<TPixel> originalImage)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        using var decodedStream = new MemoryStream();
        originalImage.SaveAsPbm(decodedStream);
        decodedStream.Seek(0, SeekOrigin.Begin);
        var encodedImage = Image.Load<TPixel>(decodedStream);
        return encodedImage;
    }
}
