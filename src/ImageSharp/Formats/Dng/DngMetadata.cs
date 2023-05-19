// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Tiff;

namespace SixLabors.ImageSharp.Formats.Dng;

/// <summary>
/// Provides DNG specific metadata information for the image.
/// </summary>
public class DngMetadata : TiffMetadata
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DngMetadata"/> class.
    /// </summary>
    public DngMetadata()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DngMetadata"/> class.
    /// </summary>
    /// <param name="other">The metadata to create an instance from.</param>
    private DngMetadata(DngMetadata other)
    {
        this.ByteOrder = other.ByteOrder;
        this.FormatType = other.FormatType;
    }

    /// <inheritdoc/>
    public new IDeepCloneable DeepClone() => new DngMetadata(this);
}
