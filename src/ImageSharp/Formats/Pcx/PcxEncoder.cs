// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Advanced;

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Image encoder for writing an image to a stream as PCX image.
/// </summary>
public sealed class PcxEncoder : ImageEncoder
{
    /// <summary>
    /// Gets the palette mode.
    /// </summary>
    public PcxColorType? ColorMode { get; init; }

    /// <summary>
    /// Gets the number of bitx per pixel channel.
    /// </summary>
    public int? PixelDepth { get; init; }

    /// <summary>
    /// Gets the number of color channels.
    /// </summary>
    public int? NumberOfChannels { get; init; }

    /// <inheritdoc/>
    protected override void Encode<TPixel>(Image<TPixel> image, Stream stream, CancellationToken cancellationToken)
    {
        PcxEncoderCore encoder = new(image.GetConfiguration(), this);
        encoder.Encode(image, stream, cancellationToken);
    }
}
