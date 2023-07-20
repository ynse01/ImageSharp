// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Buffers;
using System.Buffers.Binary;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Image encoder for writing an image to a stream as a PCX image.
/// </summary>
internal sealed class PcxEncoderCore : IImageEncoderInternals
{
    /// <summary>
    /// The global configuration.
    /// </summary>
    private Configuration configuration;

    /// <summary>
    /// The encoder with options.
    /// </summary>
    private readonly PcxEncoder encoder;

    /// <summary>
    /// Gets the color type used in this image.
    /// </summary>
    private PcxColorType colorType;

    /// <summary>
    /// Gets the number of bits per pixel channel.
    /// </summary>
    private int pixelDepth;

    /// <summary>
    /// Gets the number of color channels.
    /// </summary>
    private int numberOfChannels;

    /// <summary>
    /// Initializes a new instance of the <see cref="PcxEncoderCore"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="encoder">The encoder with options.</param>
    public PcxEncoderCore(Configuration configuration, PcxEncoder encoder)
    {
        this.configuration = configuration;
        this.encoder = encoder;
    }

    /// <summary>
    /// Encodes the image to the specified stream from the <see cref="ImageFrame{TPixel}"/>.
    /// </summary>
    /// <typeparam name="TPixel">The pixel format.</typeparam>
    /// <param name="image">The <see cref="ImageFrame{TPixel}"/> to encode from.</param>
    /// <param name="stream">The <see cref="Stream"/> to encode the image data to.</param>
    /// <param name="cancellationToken">The token to request cancellation.</param>
    public void Encode<TPixel>(Image<TPixel> image, Stream stream, CancellationToken cancellationToken)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        Guard.NotNull(image, nameof(image));
        Guard.NotNull(stream, nameof(stream));

        this.WriteHeader(stream, image.Size);

        this.WritePixels(stream, image.Frames.RootFrame);

        stream.Flush();
    }

    private void WriteHeader(Stream stream, Size pixelSize)
    {
        Span<byte> buffer = stackalloc byte[128];
        buffer[0] = 0x0a;
        buffer[2] = 1;

        // Set size
        BinaryPrimitives.WriteUInt16LittleEndian(buffer[8..], (ushort)(pixelSize.Width - 1));
        BinaryPrimitives.WriteUInt16LittleEndian(buffer[10..], (ushort)(pixelSize.Height - 1));
        stream.Write(buffer, 0, buffer.Length);
    }

    /// <summary>
    /// Writes the pixel data to the binary stream.
    /// </summary>
    /// <typeparam name="TPixel">The pixel format.</typeparam>
    /// <param name="stream">The <see cref="Stream"/> to write to.</param>
    /// <param name="image">
    /// The <see cref="ImageFrame{TPixel}"/> containing pixel data.
    /// </param>
    private void WritePixels<TPixel>(Stream stream, ImageFrame<TPixel> image)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        var pixelInfo = PixelTypeInfo.Create<TPixel>();
        var hasAlphaComponent = pixelInfo.AlphaRepresentation.HasValue && pixelInfo.AlphaRepresentation.Value == PixelAlphaRepresentation.Unassociated;
    }

    private void WriteRgbaPixels(Stream stream, ImageFrame<Rgba32> image)
    {
        IMemoryOwner<byte> bandOwner = this.configuration.MemoryAllocator.Allocate<byte>(image.Width * 4);
        int rIndex = 0;
        int gIndex = image.Width;
        int bIndex = gIndex * 2;
        int aIndex = gIndex * 3;
        for (int y = 0; y < image.Height; y++)
        {
            image.ProcessPixelRows(accessor =>
            {
                Span<byte> bandRow = bandOwner.GetSpan();
                Span<Rgba32> imageRow = accessor.GetRowSpan(y);
                for (int x = 0; x < image.Width; x++)
                {
                    Rgba32 currentPixel = imageRow[x];
                    bandRow[rIndex + x] = currentPixel.R;
                    bandRow[gIndex + x] = currentPixel.G;
                    bandRow[bIndex + x] = currentPixel.B;
                    bandRow[aIndex + x] = currentPixel.A;
                }
            });

            EncodeAndWriteRowToStream(stream, bandOwner.GetSpan());
        }
    }

    private void WriteRgbPixels(Stream stream, ImageFrame<Rgb24> image)
    {
        IMemoryOwner<byte> bandOwner = this.configuration.MemoryAllocator.Allocate<byte>(image.Width * 3);
        int rIndex = 0;
        int gIndex = image.Width;
        int bIndex = gIndex * 2;
        for (int y = 0; y < image.Height; y++)
        {
            image.ProcessPixelRows(accessor =>
            {
                Span<byte> bandRow = bandOwner.GetSpan();
                Span<Rgb24> imageRow = accessor.GetRowSpan(y);
                for (int x = 0; x < image.Width; x++)
                {
                    Rgb24 currentPixel = imageRow[x];
                    bandRow[rIndex + x] = currentPixel.R;
                    bandRow[gIndex + x] = currentPixel.G;
                    bandRow[bIndex + x] = currentPixel.B;
                }
            });

            EncodeAndWriteRowToStream(stream, bandOwner.GetSpan());
        }
    }

    private static void EncodeAndWriteRowToStream(Stream stream, Span<byte> row)
    {
        // TODO: implement RLE encoding
        stream.Write(row);
    }
}
