// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Provides enumeration of available Pcx colors.
/// </summary>
public enum PcxColorType : byte
{
    /// <summary>
    /// Single component, black and white only.
    /// </summary>
    BlackAndWhite,

    /// <summary>
    /// Single component, grayscale.
    /// </summary>
    Grayscale,

    /// <summary>
    /// Red, Green and Blue color components.
    /// </summary>
    Rgb,

    /// <summary>
    /// Red, Green, Blue and Alpha color components.
    /// </summary>
    Rgba,

    /// <summary>
    /// Palette colors, not supported yet.
    /// </summary>
    Palette,
}
