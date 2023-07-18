// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Diagnostics.CodeAnalysis;

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Detects PCX file headers.
/// </summary>
public sealed class PcxImageFormatDetector : IImageFormatDetector
{
    private const byte Identifier = 0x0a;

    /// <inheritdoc/>
    public int HeaderSize => 1;

    /// <inheritdoc/>
    public bool TryDetectFormat(ReadOnlySpan<byte> header, [NotNullWhen(true)] out IImageFormat? format)
    {
        format = IsSupportedFileFormat(header) ? PcxFormat.Instance : null;
        return format != null;
    }

    private static bool IsSupportedFileFormat(ReadOnlySpan<byte> header)
    {
        if ((uint)header.Length >= 1)
        {
            // Signature should be 0x0a as the first byte.
            return header[0] == Identifier;
        }

        return false;
    }
}
