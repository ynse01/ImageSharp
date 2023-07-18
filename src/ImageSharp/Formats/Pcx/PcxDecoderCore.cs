// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Buffers;
using System.Buffers.Binary;
using SixLabors.ImageSharp.IO;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Performs the PCX decoding operation.
/// </summary>
internal sealed class PcxDecoderCore : IImageDecoderInternals
{
    /// <summary>
    /// The general configuration.
    /// </summary>
    private readonly Configuration configuration;

    /// <summary>
    /// The colortype to use
    /// </summary>
    private PcxColorType colorMode;

    /// <summary>
    /// The size of the pixel array
    /// </summary>
    private Size pixelSize;

    /// <summary>
    /// The version of the Pcx file.
    /// </summary>
    private int version;

    /// <summary>
    /// The number of color components per pixel.
    /// </summary>
    private int numberOfComponents;

    /// <summary>
    /// The number of bits per pixel channel.
    /// </summary>
    private int bitsPerPixel;

    /// <summary>
    /// The number of bytes in a single channel in a single row.
    /// </summary>
    private int stride;

    /// <summary>
    /// The <see cref="ImageMetadata"/> decoded by this decoder instance.
    /// </summary>
    private ImageMetadata? metadata;

    /// <summary>
    /// Initializes a new instance of the <see cref="PcxDecoderCore" /> class.
    /// </summary>
    /// <param name="options">The decoder options.</param>
    public PcxDecoderCore(DecoderOptions options)
    {
        this.Options = options;
        this.configuration = options.Configuration;
    }

    /// <inheritdoc/>
    public DecoderOptions Options { get; }

    /// <inheritdoc/>
    public Size Dimensions => this.pixelSize;

    /// <inheritdoc/>
    public Image<TPixel> Decode<TPixel>(BufferedReadStream stream, CancellationToken cancellationToken)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        this.ProcessHeader(stream);

        Image<TPixel> image = new(this.configuration, this.pixelSize.Width, this.pixelSize.Height, this.metadata);

        Buffer2D<TPixel> pixels = image.GetRootFramePixelBuffer();

        this.ProcessPixels(stream, pixels);
        return image;
    }

    /// <inheritdoc/>
    public ImageInfo Identify(BufferedReadStream stream, CancellationToken cancellationToken)
    {
        this.ProcessHeader(stream);

        return new ImageInfo(new PixelTypeInfo(this.bitsPerPixel), this.pixelSize, this.metadata);
    }

    /// <summary>
    /// Processes the pcx header.
    /// </summary>
    /// <param name="stream">The input stream.</param>
    private void ProcessHeader(BufferedReadStream stream)
    {
        Span<byte> buffer = stackalloc byte[128];
        _ = stream.Read(buffer, 0, buffer.Length);

        if (buffer[0] != 0x0a)
        {
            throw new InvalidImageContentException("Identifier for PCX image not found.");
        }

        this.version = buffer[1];
        if (buffer[2] != (byte)PcxCompression.RunLength)
        {
            throw new InvalidImageContentException("PCX images must be RLE encoded.");
        }

        this.bitsPerPixel = buffer[3];
        int minX = BinaryPrimitives.ReadUInt16LittleEndian(buffer[4..]);
        int minY = BinaryPrimitives.ReadUInt16LittleEndian(buffer[6..]);
        int maxX = BinaryPrimitives.ReadUInt16LittleEndian(buffer[8..]);
        int maxY = BinaryPrimitives.ReadUInt16LittleEndian(buffer[10..]);
        this.pixelSize = new Size(maxX - minX + 1, maxY - minY + 1);
        this.numberOfComponents = buffer[65];
        this.stride = BinaryPrimitives.ReadInt16LittleEndian(buffer[66..]);
        this.colorMode = this.DetermineColorMode();

        this.metadata = new ImageMetadata
        {
            ResolutionUnits = PixelResolutionUnit.PixelsPerInch,
            HorizontalResolution = BinaryPrimitives.ReadUInt16LittleEndian(buffer[12..]),
            VerticalResolution = BinaryPrimitives.ReadUInt16LittleEndian(buffer[14..])
        };

        PcxMetadata meta = this.metadata.GetPcxMetadata();
        meta.ColorMode = this.colorMode;
        meta.NumberOfComponents = this.numberOfComponents;
        meta.BitsPerPixel = this.bitsPerPixel;
    }

    private void ProcessPixels<TPixel>(BufferedReadStream stream, Buffer2D<TPixel> pixels)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        int rowWidthInBytes = this.stride * this.numberOfComponents;
        Span<byte> buffer = stackalloc byte[rowWidthInBytes];
        using IMemoryOwner<Rgba32> rowOwner = this.configuration.MemoryAllocator.Allocate<Rgba32>(this.pixelSize.Width);
        Span<Rgba32> rgbaRow = rowOwner.GetSpan();

        for (int y = 0; y < this.pixelSize.Height; y++)
        {
            ReadRowRleEncoded(stream, buffer);
            this.RowToPixelInterleavedRgb(buffer, rgbaRow);
            Memory<TPixel> rowData = pixels.GetSafeRowMemory(y);
            PixelOperations<TPixel>.Instance.FromRgba32(this.configuration, rgbaRow, rowData.Span);
        }
    }

    private PcxColorType DetermineColorMode()
    {
        PcxColorType mode = PcxColorType.Palette;
        if (this.bitsPerPixel == 8)
        {
            if (this.numberOfComponents == 3)
            {
                mode = PcxColorType.Rgb;
            }
            else if (this.numberOfComponents == 4)
            {
                mode = PcxColorType.Rgba;
            }
            else if (this.numberOfComponents == 1)
            {
                mode = PcxColorType.Grayscale;
            }
        }

        if (this.bitsPerPixel == 1 && this.numberOfComponents == 1)
        {
            mode = PcxColorType.BlackAndWhite;
        }

        return mode;
    }

    private static void ReadRowRleEncoded(BufferedReadStream stream, Span<byte> row)
    {
        for (int x = 0; x < row.Length;)
        {
            int b = stream.ReadByte();
            if ((b & 0xc0) == 0xc0)
            {
                int c = b & 0x3f;
                byte p = (byte)stream.ReadByte();
                for (int i = 0; i < c; i++)
                {
                    row[x] = p;
                    x++;
                }
            }
            else
            {
                row[x] = (byte)b;
                x++;
            }
        }
    }

    private void RowToPixelInterleavedRgb(Span<byte> buffer, Span<Rgba32> span)
    {
        int stride2 = this.stride * 2;
        switch (this.colorMode)
        {
            case PcxColorType.Grayscale:
                for (int x = 0; x < span.Length; x++)
                {
                    byte r = buffer[x];
                    Rgba32 pixel = new(r, r, r, 255);
                    span[x] = pixel;
                }

                break;
            case PcxColorType.Rgb:
                for (int x = 0; x < span.Length; x++)
                {
                    byte r = buffer[x];
                    byte g = buffer[x + this.stride];
                    byte b = buffer[x + stride2];
                    Rgba32 pixel = new(r, g, b, 255);
                    span[x] = pixel;
                }

                break;
            case PcxColorType.Rgba:
                int stride3 = this.stride * 3;
                for (int x = 0; x < span.Length; x++)
                {
                    byte r = buffer[x];
                    byte g = buffer[x + this.stride];
                    byte b = buffer[x + stride2];
                    byte a = buffer[x + stride3];
                    Rgba32 pixel = new(r, g, b, a);
                    span[x] = pixel;
                }

                break;
        }
    }
}
