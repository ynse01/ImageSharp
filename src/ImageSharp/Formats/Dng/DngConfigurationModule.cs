// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Dng;

/// <summary>
/// Registers the image encoders, decoders and mime type detectors for the DNG format.
/// </summary>
public sealed class DngConfigurationModule : IImageFormatConfigurationModule
{
    /// <inheritdoc/>
    public void Configure(Configuration configuration)
    {
        configuration.ImageFormatsManager.SetEncoder(DngFormat.Instance, new DngEncoder());
        configuration.ImageFormatsManager.SetDecoder(DngFormat.Instance, DngDecoder.Instance);
        configuration.ImageFormatsManager.AddImageFormatDetector(new DngImageFormatDetector());
    }
}
