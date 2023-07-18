// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Registers the image encoders, decoders and mime type detectors for the PCX format.
/// </summary>
public sealed class PcxFormat : IImageFormat<PcxMetadata>
{
    private PcxFormat()
    {
    }

    /// <summary>
    /// Gets the shared instance.
    /// </summary>
    public static PcxFormat Instance { get; } = new();

    /// <inheritdoc/>
    public string Name => "PCX";

    /// <inheritdoc/>
    public string DefaultMimeType => PcxConstants.MimeTypes.First();

    /// <inheritdoc/>
    public IEnumerable<string> MimeTypes => PcxConstants.MimeTypes;

    /// <inheritdoc/>
    public IEnumerable<string> FileExtensions => PcxConstants.FileExtensions;

    /// <inheritdoc/>
    public PcxMetadata CreateDefaultFormatMetadata() => new();
}
