// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Tiff;

namespace SixLabors.ImageSharp.Formats.Dng;

/// <summary>
/// Encoder for writing the data image to a stream in DNG format.
/// </summary>
public class DngEncoder : ImageEncoder
{
    private TiffEncoder tiffEncoderOptions = new TiffEncoder();

    /// <inheritdoc/>
    protected override void Encode<TPixel>(Image<TPixel> image, Stream stream, CancellationToken cancellationToken)
    {
        TiffEncoderCore encode = new(tiffEncoderOptions, image.GetMemoryAllocator());
        encode.Encode(image, stream, cancellationToken);
    }
}
