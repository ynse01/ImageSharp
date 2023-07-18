// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Enumerates the available components that PCX supports.
/// </summary>
public enum PcxComponentType : byte
{
    /// <summary>
    /// 1 component. Grey intensity value.
    /// </summary>
    Greyscale = 1,

    /// <summary>
    /// 3 color components. Red, Green and Blue respectively.
    /// </summary>
    Rgb = 3,

    /// <summary>
    /// 4 color components. Red, Green, Blue and Alpha respectively.
    /// </summary>
    Rgba = 4
}
