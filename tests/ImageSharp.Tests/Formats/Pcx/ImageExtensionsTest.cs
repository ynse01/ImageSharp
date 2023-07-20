// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Pcx;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Tests.Formats.Pcx;

[Trait("Format", "Pcx")]
public class ImageExtensionsTest
{
    [Fact]
    public void SaveAsPcx_Path()
    {
        string dir = TestEnvironment.CreateOutputDirectory(nameof(ImageExtensionsTest));
        string file = Path.Combine(dir, "SaveAsPcx_Path.pcx");

        using (Image<L8> image = new(10, 10))
        {
            image.SaveAsPcx(file);
        }

        IImageFormat format = Image.DetectFormat(file);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public async Task SaveAsPcxAsync_Path()
    {
        string dir = TestEnvironment.CreateOutputDirectory(nameof(ImageExtensionsTest));
        string file = Path.Combine(dir, "SaveAsPcxAsync_Path.pcx");

        using (Image<L8> image = new(10, 10))
        {
            await image.SaveAsPcxAsync(file);
        }

        IImageFormat format = Image.DetectFormat(file);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public void SaveAsPcx_Path_Encoder()
    {
        string dir = TestEnvironment.CreateOutputDirectory(nameof(ImageExtensions));
        string file = Path.Combine(dir, "SaveAsPcx_Path_Encoder.pcx");

        using (Image<L8> image = new(10, 10))
        {
            image.SaveAsPcx(file, new PcxEncoder());
        }

        IImageFormat format = Image.DetectFormat(file);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public async Task SaveAsPcxAsync_Path_Encoder()
    {
        string dir = TestEnvironment.CreateOutputDirectory(nameof(ImageExtensions));
        string file = Path.Combine(dir, "SaveAsPcxAsync_Path_Encoder.pcx");

        using (Image<L8> image = new(10, 10))
        {
            await image.SaveAsPcxAsync(file, new PcxEncoder());
        }

        IImageFormat format = Image.DetectFormat(file);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public void SaveAsPcx_Stream()
    {
        using MemoryStream memoryStream = new();

        using (Image<L8> image = new(10, 10))
        {
            image.SaveAsPcx(memoryStream);
        }

        memoryStream.Position = 0;

        IImageFormat format = Image.DetectFormat(memoryStream);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public async Task SaveAsPcxAsync_StreamAsync()
    {
        using MemoryStream memoryStream = new();

        using (Image<L8> image = new(10, 10))
        {
            await image.SaveAsPcxAsync(memoryStream);
        }

        memoryStream.Position = 0;

        IImageFormat format = Image.DetectFormat(memoryStream);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public void SaveAsPcx_Stream_Encoder()
    {
        using MemoryStream memoryStream = new();

        using (Image<L8> image = new(10, 10))
        {
            image.SaveAsPcx(memoryStream, new PcxEncoder());
        }

        memoryStream.Position = 0;

        IImageFormat format = Image.DetectFormat(memoryStream);
        Assert.True(format is PcxFormat);
    }

    [Fact]
    public async Task SaveAsPcxAsync_Stream_Encoder()
    {
        using MemoryStream memoryStream = new();

        using (Image<L8> image = new(10, 10))
        {
            await image.SaveAsPcxAsync(memoryStream, new PcxEncoder());
        }

        memoryStream.Position = 0;

        IImageFormat format = Image.DetectFormat(memoryStream);
        Assert.True(format is PcxFormat);
    }
}
