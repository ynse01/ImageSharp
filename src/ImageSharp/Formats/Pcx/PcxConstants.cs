// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Contains PCX constant values defined in the specification.
/// </summary>
internal static class PcxConstants
{
    /// <summary>
    /// The list of mimetypes that equate to a pcx.
    /// </summary>
    public static readonly IEnumerable<string> MimeTypes = new[] { "image/vnd.zbrush.pcx", "image/x-pcx" };

    /// <summary>
    /// The list of file extensions that equate to a pcx.
    /// </summary>
    public static readonly IEnumerable<string> FileExtensions = new[] { "pcx" };
}
