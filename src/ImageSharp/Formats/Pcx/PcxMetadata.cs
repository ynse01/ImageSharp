// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Provides PCX specific metadata information for the image.
/// </summary>
public class PcxMetadata : IDeepCloneable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PcxMetadata"/> class.
    /// </summary>
    public PcxMetadata()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PcxMetadata"/> class.
    /// </summary>
    /// <param name="other">The metadata to create an instance from.</param>
    private PcxMetadata(PcxMetadata other)
    {
        this.ColorType = other.ColorType;
        this.BitsPerPixel = other.BitsPerPixel;
        this.ComponentCount = other.ComponentCount;
    }

    /// <summary>
    /// Gets or sets the encoding of the pixels.
    /// </summary>
    public PcxColorType ColorType { get; set; } = PcxColorType.Rgb;

    /// <summary>
    /// Gets or sets the number of bits per pixel component.
    /// </summary>
    public int BitsPerPixel { get; set; } = 8;

    /// <summary>
    /// Gets or sets the data number of color components.
    /// </summary>
    public int ComponentCount { get; set; }

    /// <inheritdoc/>
    public IDeepCloneable DeepClone() => new PcxMetadata(this);
}
