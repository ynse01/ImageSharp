// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Pcx;

/// <summary>
/// Registers the image encoders, decoders and mime type detectors for the PCX format.
/// </summary>
public sealed class PcxConfigurationModule : IImageFormatConfigurationModule
{
    /// <inheritdoc/>
    public void Configure(Configuration configuration)
    {
        configuration.ImageFormatsManager.SetEncoder(PcxFormat.Instance, new PcxEncoder());
        configuration.ImageFormatsManager.SetDecoder(PcxFormat.Instance, PcxDecoder.Instance);
        configuration.ImageFormatsManager.AddImageFormatDetector(new PcxImageFormatDetector());
    }
}
