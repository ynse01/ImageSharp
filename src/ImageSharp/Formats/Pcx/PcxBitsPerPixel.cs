// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Enumerates the available bits per pixel the PCX encoder supports.
/// </summary>
public enum PcxBitsPerPixel : byte
{
    /// <summary>
    /// 1 bit per pixel channel.
    /// </summary>
    Bits1 = 1,

    /// <summary>
    /// 2 bits per pixel channel.
    /// </summary>
    Bits2 = 2,

    /// <summary>
    /// 4 bits per pixel channel.
    /// </summary>
    Bits4 = 4,

    /// <summary>
    /// 8 bits per pixel channel.
    /// </summary>
    Bits8 = 8
}
