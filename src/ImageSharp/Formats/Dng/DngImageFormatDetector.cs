// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Diagnostics.CodeAnalysis;
using SixLabors.ImageSharp.Formats.Tiff;

namespace SixLabors.ImageSharp.Formats.Dng;

/// <summary>
/// Detects DNG file headers
/// </summary>
public sealed class DngImageFormatDetector : IImageFormatDetector
{
    private TiffImageFormatDetector tiffDetector = new TiffImageFormatDetector();

    /// <inheritdoc/>
    public int HeaderSize => 8;

    /// <inheritdoc/>
    public bool TryDetectFormat(ReadOnlySpan<byte> header, [NotNullWhen(true)] out IImageFormat? format)
    {
        if (tiffDetector.TryDetectFormat(header, out format)) {
            // TODO: Do DNG specific checks
            format = null;
        }
        return format != null;
    }
}
