// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.Formats.Tiff.Constants;

namespace SixLabors.ImageSharp.Formats.Dng;

/// <summary>
/// Encapsulates the means to encode and decode Dng images.
/// </summary>
public sealed class DngFormat : IImageFormat<DngMetadata, TiffFrameMetadata>
{
    private DngFormat()
    {
    }

    /// <summary>
    /// Gets the shared instance.
    /// </summary>
    public static DngFormat Instance { get; } = new DngFormat();

    /// <inheritdoc/>
    public string Name => "DNG";

    /// <inheritdoc/>
    public string DefaultMimeType => "image/x-adobe-dng";

    /// <inheritdoc/>
    public IEnumerable<string> MimeTypes => new [] { DefaultMimeType };

    /// <inheritdoc/>
    public IEnumerable<string> FileExtensions => new [] { "dng" };

    /// <inheritdoc/>
    public DngMetadata CreateDefaultFormatMetadata() => new DngMetadata();

    /// <inheritdoc/>
    public TiffFrameMetadata CreateDefaultFormatFrameMetadata() => new TiffFrameMetadata();
}
