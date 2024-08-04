// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Buffers;
using System.Reflection.PortableExecutable;
using SixLabors.ImageSharp.Formats.Heif.Av1.Transform;

namespace SixLabors.ImageSharp.Formats.Heif.Av1.OpenBitstreamUnit;

internal class ObuWriter
{
    private int[] previousQIndex = [];
    private int[] previousDeltaLoopFilter = [];

    /// <summary>
    /// Encode a single frame into OBU's.
    /// </summary>
    public void WriteAll(Stream stream, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, IAv1TileWriter tileWriter)
    {
        MemoryStream bufferStream = new(2000);
        Av1BitStreamWriter writer = new(bufferStream);
        WriteObuHeaderAndSize(stream, ObuType.TemporalDelimiter, [], 0);

        if (sequenceHeader != null)
        {
            WriteSequenceHeader(ref writer, sequenceHeader);
            int bytesWritten = (writer.BitPosition + 7) >> 3;
            writer.Flush();
            WriteObuHeaderAndSize(stream, ObuType.SequenceHeader, bufferStream.GetBuffer(), bytesWritten);
        }

        if (frameInfo != null && sequenceHeader != null)
        {
            bufferStream.Position = 0;
            this.WriteFrameHeader(ref writer, sequenceHeader, frameInfo, true);
            if (frameInfo.TilesInfo != null)
            {
                WriteTileGroup(ref writer, frameInfo.TilesInfo, tileWriter);
            }

            int bytesWritten = (writer.BitPosition + 7) >> 3;
            writer.Flush();
            WriteObuHeaderAndSize(stream, ObuType.Frame, bufferStream.GetBuffer(), bytesWritten);
        }
    }

    private static void WriteObuHeader(ref Av1BitStreamWriter writer, ObuType type)
    {
        writer.WriteBoolean(false); // Forbidden bit
        writer.WriteLiteral((uint)type, 4);
        writer.WriteBoolean(false); // Extension
        writer.WriteBoolean(true); // HasSize
        writer.WriteBoolean(false); // Reserved
    }

    /// <summary>
    /// Read OBU header and size.
    /// </summary>
    private static void WriteObuHeaderAndSize(Stream stream, ObuType type, Span<byte> payload, int length)
    {
        Av1BitStreamWriter writer = new(stream);
        WriteObuHeader(ref writer, type);
        writer.WriteLittleEndianBytes128((uint)length);
        stream.Write(payload, 0, length);
    }

    /// <summary>
    /// Write trsainling bits to end on a byte boundary, these trailing bits start with a 1 and end with 0s.
    /// </summary>
    /// <remarks>Write an additional byte, if already byte aligned before.</remarks>
    private static void WriteTrailingBits(ref Av1BitStreamWriter writer)
    {
        int bitsBeforeAlignment = 8 - (writer.BitPosition & 0x7);
        if (bitsBeforeAlignment != 8)
        {
            writer.WriteLiteral(1U << (bitsBeforeAlignment - 1), bitsBeforeAlignment);
        }
    }

    private static void AlignToByteBoundary(ref Av1BitStreamWriter writer)
    {
        while ((writer.BitPosition & 0x7) > 0)
        {
            writer.WriteBoolean(false);
        }
    }

    private static bool IsValidObuType(ObuType type) => type switch
    {
        ObuType.SequenceHeader or ObuType.TemporalDelimiter or ObuType.FrameHeader or
        ObuType.TileGroup or ObuType.Metadata or ObuType.Frame or ObuType.RedundantFrameHeader or
        ObuType.TileList or ObuType.Padding => true,
        _ => false,
    };

    private static void WriteSequenceHeader(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader)
    {
        writer.WriteLiteral((uint)sequenceHeader.SequenceProfile, 3);
        writer.WriteBoolean(true); // IsStillPicture
        writer.WriteBoolean(true); // IsReducedStillPicture
        writer.WriteLiteral((uint)sequenceHeader.OperatingPoint[0].SequenceLevelIndex, Av1Constants.LevelBits);

        // Frame width and Height
        writer.WriteLiteral((uint)sequenceHeader.FrameWidthBits - 1, 4);
        writer.WriteLiteral((uint)sequenceHeader.FrameHeightBits - 1, 4);
        writer.WriteLiteral((uint)sequenceHeader.MaxFrameWidth - 1, sequenceHeader.FrameWidthBits);
        writer.WriteLiteral((uint)sequenceHeader.MaxFrameHeight - 1, sequenceHeader.FrameHeightBits);

        // Video related flags removed
        writer.WriteBoolean(sequenceHeader.Use128x128Superblock);
        writer.WriteBoolean(sequenceHeader.EnableFilterIntra);
        writer.WriteBoolean(sequenceHeader.EnableIntraEdgeFilter);

        // Video related flags removed
        writer.WriteBoolean(sequenceHeader.EnableSuperResolution);
        writer.WriteBoolean(sequenceHeader.EnableCdef);
        writer.WriteBoolean(sequenceHeader.EnableRestoration);
        WriteColorConfig(ref writer, sequenceHeader);
        writer.WriteBoolean(sequenceHeader.AreFilmGrainingParametersPresent);
        WriteTrailingBits(ref writer);
    }

    private static void WriteColorConfig(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader)
    {
        ObuColorConfig colorConfig = sequenceHeader.ColorConfig;
        WriteBitDepth(ref writer, colorConfig, sequenceHeader);
        if (sequenceHeader.SequenceProfile != ObuSequenceProfile.High)
        {
            writer.WriteBoolean(colorConfig.IsMonochrome);
        }

        writer.WriteBoolean(colorConfig.IsColorDescriptionPresent);
        if (colorConfig.IsColorDescriptionPresent)
        {
            writer.WriteLiteral((uint)colorConfig.ColorPrimaries, 8);
            writer.WriteLiteral((uint)colorConfig.TransferCharacteristics, 8);
            writer.WriteLiteral((uint)colorConfig.MatrixCoefficients, 8);
        }

        if (colorConfig.IsMonochrome)
        {
            writer.WriteBoolean(colorConfig.ColorRange);
            return;
        }
        else if (
            colorConfig.ColorPrimaries == ObuColorPrimaries.Bt709 &&
            colorConfig.TransferCharacteristics == ObuTransferCharacteristics.Srgb &&
            colorConfig.MatrixCoefficients == ObuMatrixCoefficients.Identity)
        {
            colorConfig.ColorRange = true;
            colorConfig.SubSamplingX = false;
            colorConfig.SubSamplingY = false;
        }
        else
        {
            writer.WriteBoolean(colorConfig.ColorRange);
            if (sequenceHeader.SequenceProfile == ObuSequenceProfile.Professional && colorConfig.BitDepth == 12)
            {
                writer.WriteBoolean(colorConfig.SubSamplingX);
                if (colorConfig.SubSamplingX)
                {
                    writer.WriteBoolean(colorConfig.SubSamplingY);
                }
            }

            if (colorConfig.SubSamplingX && colorConfig.SubSamplingY)
            {
                writer.WriteLiteral((uint)colorConfig.ChromaSamplePosition, 2);
            }
        }

        writer.WriteBoolean(colorConfig.HasSeparateUvDelta);
    }

    private static void WriteBitDepth(ref Av1BitStreamWriter writer, ObuColorConfig colorConfig, ObuSequenceHeader sequenceHeader)
    {
        bool hasHighBitDepth = colorConfig.BitDepth > 8;
        writer.WriteBoolean(hasHighBitDepth);
        if (sequenceHeader.SequenceProfile == ObuSequenceProfile.Professional && hasHighBitDepth)
        {
            writer.WriteBoolean(colorConfig.BitDepth == 12);
        }
    }

    private static void WriteSuperResolutionParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo)
    {
        bool useSuperResolution = false;
        if (sequenceHeader.EnableSuperResolution)
        {
            writer.WriteBoolean(useSuperResolution);
        }

        if (useSuperResolution)
        {
            writer.WriteLiteral((uint)frameInfo.FrameSize.SuperResolutionDenominator - Av1Constants.SuperResolutionScaleDenominatorMinimum, Av1Constants.SuperResolutionScaleBits);
        }
    }

    private static void WriteRenderSize(ref Av1BitStreamWriter writer, ObuFrameHeader frameInfo)
    {
        bool renderSizeAndFrameSizeDifferent = false;
        writer.WriteBoolean(false);
        if (renderSizeAndFrameSizeDifferent)
        {
            writer.WriteLiteral((uint)frameInfo.FrameSize.RenderWidth - 1, 16);
            writer.WriteLiteral((uint)frameInfo.FrameSize.RenderHeight - 1, 16);
        }
    }

    private static void WriteFrameSizeWithReferences(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, bool frameSizeOverrideFlag)
    {
        bool foundReference = false;
        for (int i = 0; i < Av1Constants.ReferencesPerFrame; i++)
        {
            writer.WriteBoolean(foundReference);
            if (foundReference)
            {
                // Take values over from reference frame
                break;
            }
        }

        if (!foundReference)
        {
            WriteFrameSize(ref writer, sequenceHeader, frameInfo, frameSizeOverrideFlag);
            WriteRenderSize(ref writer, frameInfo);
        }
        else
        {
            WriteSuperResolutionParameters(ref writer, sequenceHeader, frameInfo);
        }
    }

    private static void WriteFrameSize(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, bool frameSizeOverrideFlag)
    {
        if (frameSizeOverrideFlag)
        {
            writer.WriteLiteral((uint)frameInfo.FrameSize.FrameWidth - 1, sequenceHeader.FrameWidthBits + 1);
            writer.WriteLiteral((uint)frameInfo.FrameSize.FrameHeight - 1, sequenceHeader.FrameHeightBits + 1);
        }

        WriteSuperResolutionParameters(ref writer, sequenceHeader, frameInfo);
    }

    private static void WriteTileInfo(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo)
    {
        ObuTileGroupHeader tileInfo = frameInfo.TilesInfo;
        int superblockColumnCount;
        int superblockRowCount;
        int superblockSizeLog2 = sequenceHeader.SuperblockSizeLog2;
        int superblockShift = superblockSizeLog2 - Av1Constants.ModeInfoSizeLog2;
        superblockColumnCount = (frameInfo.ModeInfoColumnCount + sequenceHeader.SuperblockModeInfoSize - 1) >> superblockShift;
        superblockRowCount = (frameInfo.ModeInfoRowCount + sequenceHeader.SuperblockModeInfoSize - 1) >> superblockShift;
        int superBlockSize = superblockShift + 2;
        int maxTileAreaOfSuperBlock = Av1Constants.MaxTileArea >> (2 * superBlockSize);

        tileInfo.MaxTileWidthSuperblock = Av1Constants.MaxTileWidth >> superBlockSize;
        tileInfo.MaxTileHeightSuperblock = (Av1Constants.MaxTileArea / Av1Constants.MaxTileWidth) >> superBlockSize;
        tileInfo.MinLog2TileColumnCount = ObuReader.TileLog2(tileInfo.MaxTileWidthSuperblock, superblockColumnCount);
        tileInfo.MaxLog2TileColumnCount = ObuReader.TileLog2(1, Math.Min(superblockColumnCount, Av1Constants.MaxTileColumnCount));
        tileInfo.MaxLog2TileRowCount = ObuReader.TileLog2(1, Math.Min(superblockRowCount, Av1Constants.MaxTileRowCount));
        tileInfo.MinLog2TileCount = Math.Max(tileInfo.MinLog2TileColumnCount, ObuReader.TileLog2(maxTileAreaOfSuperBlock, superblockColumnCount * superblockRowCount));

        int log2TileColumnCount = Av1Math.Log2(tileInfo.TileColumnCount);
        int log2TileRowCount = Av1Math.Log2(tileInfo.TileRowCount);

        writer.WriteBoolean(tileInfo.HasUniformTileSpacing);
        if (tileInfo.HasUniformTileSpacing)
        {
            // Uniform spaced tiles with power-of-two number of rows and columns
            // tile columns
            int ones = log2TileColumnCount - tileInfo.MinLog2TileColumnCount;
            while (ones-- > 0)
            {
                writer.WriteBoolean(true);
            }

            if (log2TileColumnCount < tileInfo.MaxLog2TileColumnCount)
            {
                writer.WriteBoolean(false);
            }

            // rows
            tileInfo.MinLog2TileRowCount = Math.Min(tileInfo.MinLog2TileCount - log2TileColumnCount, 0);
            ones = log2TileRowCount - tileInfo.MinLog2TileRowCount;
            while (ones-- > 0)
            {
                writer.WriteBoolean(true);
            }

            if (log2TileRowCount < tileInfo.MaxLog2TileRowCount)
            {
                writer.WriteBoolean(false);
            }
        }
        else
        {
            int startSuperBlock = 0;
            int i = 0;
            for (; startSuperBlock < superblockColumnCount; i++)
            {
                uint widthInSuperBlocks = (uint)((tileInfo.TileColumnStartModeInfo[i] >> superblockShift) - startSuperBlock);
                uint maxWidth = (uint)Math.Min(superblockColumnCount - startSuperBlock, tileInfo.MaxTileWidthSuperblock);
                writer.WriteNonSymmetric(widthInSuperBlocks - 1, maxWidth);
                startSuperBlock += (int)widthInSuperBlocks;
            }

            if (startSuperBlock != superblockColumnCount)
            {
                throw new ImageFormatException("Super block tiles width does not add up to total width.");
            }

            startSuperBlock = 0;
            for (i = 0; startSuperBlock < superblockRowCount; i++)
            {
                uint heightInSuperBlocks = (uint)((tileInfo.TileRowStartModeInfo[i] >> superblockShift) - startSuperBlock);
                uint maxHeight = (uint)Math.Min(superblockRowCount - startSuperBlock, tileInfo.MaxTileHeightSuperblock);
                writer.WriteNonSymmetric(heightInSuperBlocks - 1, maxHeight);
                startSuperBlock += (int)heightInSuperBlocks;
            }

            if (startSuperBlock != superblockRowCount)
            {
                throw new ImageFormatException("Super block tiles height does not add up to total height.");
            }
        }

        if (tileInfo.TileColumnCountLog2 > 0 || tileInfo.TileRowCountLog2 > 0)
        {
            writer.WriteLiteral(tileInfo.ContextUpdateTileId, tileInfo.TileRowCountLog2 + tileInfo.TileColumnCountLog2);
            writer.WriteLiteral((uint)tileInfo.TileSizeBytes - 1, 2);
        }

        frameInfo.TilesInfo = tileInfo;
    }

    private void WriteUncompressedFrameHeader(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameHeader)
    {
        // TODO: Make tile count configurable.
        int tileCount = 1;
        int planesCount = sequenceHeader.ColorConfig.PlaneCount;
        writer.WriteBoolean(frameHeader.DisableCdfUpdate);
        if (sequenceHeader.ForceScreenContentTools == 2)
        {
            writer.WriteBoolean(frameHeader.AllowScreenContentTools);
        }
        else
        {
            // Guard.IsTrue(frameInfo.AllowScreenContentTools == sequenceHeader.ForceScreenContentTools);
        }

        if (frameHeader.AllowScreenContentTools)
        {
            if (sequenceHeader.ForceIntegerMotionVector == 2)
            {
                writer.WriteBoolean(frameHeader.ForceIntegerMotionVector);
            }
            else
            {
                // Guard.IsTrue(frameInfo.ForceIntegerMotionVector == sequenceHeader.ForceIntegerMotionVector, nameof(frameInfo.ForceIntegerMotionVector), "Frame and sequence must be in sync");
            }
        }

        if (frameHeader.FrameType == ObuFrameType.KeyFrame)
        {
            if (!frameHeader.ShowFrame)
            {
                throw new NotImplementedException("No support for hidden frames.");
            }
        }
        else if (frameHeader.FrameType == ObuFrameType.IntraOnlyFrame)
        {
            throw new NotImplementedException("No IntraOnly frames supported.");
        }

        if (frameHeader.FrameType == ObuFrameType.KeyFrame)
        {
            WriteFrameSize(ref writer, sequenceHeader, frameHeader, false);
            WriteRenderSize(ref writer, frameHeader);
            if (frameHeader.AllowScreenContentTools)
            {
                writer.WriteBoolean(frameHeader.AllowIntraBlockCopy);
            }
        }
        else if (frameHeader.FrameType == ObuFrameType.IntraOnlyFrame)
        {
            WriteFrameSize(ref writer, sequenceHeader, frameHeader, false);
            WriteRenderSize(ref writer, frameHeader);
            if (frameHeader.AllowScreenContentTools)
            {
                writer.WriteBoolean(frameHeader.AllowIntraBlockCopy);
            }
        }
        else
        {
            throw new NotImplementedException("Inter frames not applicable for AVIF.");
        }

        WriteTileInfo(ref writer, sequenceHeader, frameHeader);
        WriteQuantizationParameters(ref writer, frameHeader.QuantizationParameters, sequenceHeader.ColorConfig, planesCount);
        WriteSegmentationParameters(ref writer, sequenceHeader, frameHeader, planesCount);

        if (frameHeader.QuantizationParameters.BaseQIndex > 0)
        {
            writer.WriteBoolean(frameHeader.DeltaQParameters.IsPresent);
            if (frameHeader.DeltaQParameters.IsPresent)
            {
                writer.WriteLiteral((uint)frameHeader.DeltaQParameters.Resolution - 1, 2);
                for (int tileIndex = 0; tileIndex < tileCount; tileIndex++)
                {
                    this.previousQIndex[tileIndex] = frameHeader.QuantizationParameters.BaseQIndex;
                }

                if (frameHeader.AllowIntraBlockCopy)
                {
                    Guard.IsFalse(
                        frameHeader.DeltaLoopFilterParameters.IsPresent,
                        nameof(frameHeader.DeltaLoopFilterParameters.IsPresent),
                        "Allow INTRA block copy required Loop Filter.");
                }
                else
                {
                    writer.WriteBoolean(frameHeader.DeltaLoopFilterParameters.IsPresent);
                }

                if (frameHeader.DeltaLoopFilterParameters.IsPresent)
                {
                    writer.WriteLiteral((uint)(1 + Av1Math.MostSignificantBit((uint)frameHeader.DeltaLoopFilterParameters.Resolution) - 1), 2);
                    writer.WriteBoolean(frameHeader.DeltaLoopFilterParameters.IsMulti);
                    int frameLoopFilterCount = sequenceHeader.ColorConfig.IsMonochrome ? Av1Constants.FrameLoopFilterCount - 2 : Av1Constants.FrameLoopFilterCount;
                    for (int loopFilterId = 0; loopFilterId < frameLoopFilterCount; loopFilterId++)
                    {
                        this.previousDeltaLoopFilter[loopFilterId] = 0;
                    }
                }
            }
        }

        if (frameHeader.AllLossless)
        {
            throw new NotImplementedException("No entire lossless supported.");
        }
        else
        {
            if (!frameHeader.CodedLossless)
            {
                WriteLoopFilterParameters(ref writer, sequenceHeader, frameHeader, planesCount);
                if (sequenceHeader.CdefLevel > 0)
                {
                    WriteCdefParameters(ref writer, sequenceHeader, frameHeader, planesCount);
                }
            }

            if (sequenceHeader.EnableRestoration)
            {
                WriteLoopRestorationParameters(ref writer, sequenceHeader, frameHeader, planesCount);
            }
        }

        // No Frame Reference mode selection for AVIF
        WriteTransformMode(ref writer, frameHeader);

        // No compound INTER-INTER for AVIF.
        if (frameHeader.SkipModeParameters.SkipModeAllowed)
        {
            writer.WriteBoolean(frameHeader.SkipModeParameters.SkipModeFlag);
        }

        // No warp motion for AVIF.
        writer.WriteBoolean(frameHeader.UseReducedTransformSet);

        // No global motion for AVIF.
        WriteFilmGrainFilterParameters(ref writer, sequenceHeader, frameHeader);
    }

    private static bool IsSegmentationFeatureActive(ObuSegmentationParameters segmentationParameters, int segmentId, ObuSegmentationLevelFeature feature)
        => segmentationParameters.Enabled && segmentationParameters.FeatureEnabled[segmentId, (int)feature];

    private int WriteFrameHeader(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, bool writeTrailingBits)
    {
        int startBitPosition = writer.BitPosition;
        this.WriteUncompressedFrameHeader(ref writer, sequenceHeader, frameInfo);
        if (writeTrailingBits)
        {
            WriteTrailingBits(ref writer);
        }

        int endPosition = writer.BitPosition;
        int headerBytes = (endPosition - startBitPosition) / 8;
        return headerBytes;
    }

    private static int WriteTileGroup(ref Av1BitStreamWriter writer, ObuTileGroupHeader tileInfo, IAv1TileWriter tileWriter)
    {
        int tileCount = tileInfo.TileColumnCount * tileInfo.TileRowCount;
        int startBitPosition = writer.BitPosition;
        bool tileStartAndEndPresentFlag = tileCount != 0;
        writer.WriteBoolean(tileStartAndEndPresentFlag);

        uint tileGroupStart = 0U;
        uint tileGroupEnd = (uint)tileCount - 1U;
        if (tileCount != 1)
        {
            int tileBits = Av1Math.Log2(tileInfo.TileColumnCount) + Av1Math.Log2(tileInfo.TileRowCount);
            writer.WriteLiteral(tileGroupStart, tileBits);
            writer.WriteLiteral(tileGroupEnd, tileBits);
        }

        AlignToByteBoundary(ref writer);

        WriteTileData(ref writer, tileInfo, tileWriter);

        int endBitPosition = writer.BitPosition;
        int headerBytes = (endBitPosition - startBitPosition) / 8;
        return headerBytes;
    }

    private static void WriteTileData(ref Av1BitStreamWriter writer, ObuTileGroupHeader tileInfo, IAv1TileWriter tileWriter)
    {
        int tileCount = tileInfo.TileColumnCount * tileInfo.TileRowCount;
        for (int tileNum = 0; tileNum < tileCount; tileNum++)
        {
            Span<byte> tileData = tileWriter.WriteTile(tileNum);
            if (tileNum != tileCount - 1 && tileCount > 1)
            {
                writer.WriteLittleEndian((uint)tileData.Length - 1U, tileInfo.TileSizeBytes);
            }

            writer.WriteBlob(tileData);
        }
    }

    private static int WriteDeltaQ(ref Av1BitStreamWriter writer, int deltaQ)
    {
        bool isCoded = deltaQ != 0;
        writer.WriteBoolean(isCoded);
        if (isCoded)
        {
            writer.WriteSignedFromUnsigned(deltaQ, 7);
        }

        return deltaQ;
    }

    private static void WriteFrameDeltaQParameters(ref Av1BitStreamWriter writer, ObuFrameHeader frameInfo)
    {
        if (frameInfo.QuantizationParameters.BaseQIndex > 0)
        {
            writer.WriteBoolean(frameInfo.DeltaQParameters.IsPresent);
        }

        if (frameInfo.DeltaQParameters.IsPresent)
        {
            writer.WriteLiteral((uint)frameInfo.DeltaQParameters.Resolution, 2);
        }
    }

    private static void WriteFrameDeltaLoopFilterParameters(ref Av1BitStreamWriter writer, ObuFrameHeader frameInfo)
    {
        if (frameInfo.DeltaQParameters.IsPresent)
        {
            if (!frameInfo.AllowIntraBlockCopy)
            {
                writer.WriteBoolean(frameInfo.DeltaLoopFilterParameters.IsPresent);
            }

            if (frameInfo.DeltaLoopFilterParameters.IsPresent)
            {
                writer.WriteLiteral((uint)frameInfo.DeltaLoopFilterParameters.Resolution, 2);
                writer.WriteBoolean(frameInfo.DeltaLoopFilterParameters.IsMulti);
            }
        }
    }

    /// <summary>
    /// See section 5.9.12.
    /// </summary>
    private static void WriteQuantizationParameters(ref Av1BitStreamWriter writer, ObuQuantizationParameters quantParams, ObuColorConfig colorInfo, int planesCount)
    {
        writer.WriteLiteral((uint)quantParams.BaseQIndex, 8);
        WriteDeltaQ(ref writer, quantParams.DeltaQDc[(int)Av1Plane.Y]);
        if (planesCount > 1)
        {
            if (colorInfo.HasSeparateUvDelta)
            {
                writer.WriteBoolean(quantParams.HasSeparateUvDelta);
            }

            WriteDeltaQ(ref writer, quantParams.DeltaQDc[(int)Av1Plane.U]);
            WriteDeltaQ(ref writer, quantParams.DeltaQAc[(int)Av1Plane.U]);
            if (quantParams.HasSeparateUvDelta)
            {
                WriteDeltaQ(ref writer, quantParams.DeltaQDc[(int)Av1Plane.V]);
                WriteDeltaQ(ref writer, quantParams.DeltaQAc[(int)Av1Plane.V]);
            }
        }

        writer.WriteBoolean(quantParams.IsUsingQMatrix);
        if (quantParams.IsUsingQMatrix)
        {
            writer.WriteLiteral((uint)quantParams.QMatrix[(int)Av1Plane.Y], 4);
            writer.WriteLiteral((uint)quantParams.QMatrix[(int)Av1Plane.U], 4);
            if (colorInfo.HasSeparateUvDelta)
            {
                writer.WriteLiteral((uint)quantParams.QMatrix[(int)Av1Plane.V], 4);
            }
        }
    }

    private static void WriteSegmentationParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, int planesCount)
    {
        Guard.IsFalse(frameInfo.SegmentationParameters.Enabled, nameof(frameInfo.SegmentationParameters.Enabled), "Segmentatino not supported yet.");
        writer.WriteBoolean(false);
    }

    private static void WriteLoopFilterParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, int planesCount)
    {
        if (frameInfo.CodedLossless || frameInfo.AllowIntraBlockCopy)
        {
            return;
        }

        writer.WriteLiteral((uint)frameInfo.LoopFilterParameters.FilterLevel[0], 6);
        writer.WriteLiteral((uint)frameInfo.LoopFilterParameters.FilterLevel[1], 6);
        if (sequenceHeader.ColorConfig.PlaneCount > 1)
        {
            if (frameInfo.LoopFilterParameters.FilterLevel[0] > 0 || frameInfo.LoopFilterParameters.FilterLevel[1] > 0)
            {
                writer.WriteLiteral((uint)frameInfo.LoopFilterParameters.FilterLevelU, 6);
                writer.WriteLiteral((uint)frameInfo.LoopFilterParameters.FilterLevelV, 6);
            }
        }

        writer.WriteLiteral((uint)frameInfo.LoopFilterParameters.SharpnessLevel, 3);
        writer.WriteBoolean(frameInfo.LoopFilterParameters.ReferenceDeltaModeEnabled);
        if (frameInfo.LoopFilterParameters.ReferenceDeltaModeEnabled)
        {
            writer.WriteBoolean(frameInfo.LoopFilterParameters.ReferenceDeltaModeUpdate);
            if (frameInfo.LoopFilterParameters.ReferenceDeltaModeUpdate)
            {
                throw new NotImplementedException("Reference update of loop filter not supported yet.");
            }
        }
    }

    /// <summary>
    /// 5.9.21. TX mode syntax.
    /// </summary>
    private static void WriteTransformMode(ref Av1BitStreamWriter writer, ObuFrameHeader frameInfo)
    {
        if (!frameInfo.CodedLossless)
        {
            writer.WriteBoolean(frameInfo.TransformMode == Av1TransformMode.Select);
        }
    }

    private static void WriteLoopRestorationParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, int planesCount)
    {
        if (frameInfo.CodedLossless || frameInfo.AllowIntraBlockCopy || !sequenceHeader.EnableRestoration)
        {
            return;
        }

        for (int i = 0; i < planesCount; i++)
        {
            writer.WriteLiteral((uint)frameInfo.LoopRestorationParameters.Items[i].Type, 2);
        }

        if (frameInfo.LoopRestorationParameters.UsesLoopRestoration)
        {
            uint unitShift = (uint)frameInfo.LoopRestorationParameters.UnitShift;
            if (sequenceHeader.Use128x128Superblock)
            {
                writer.WriteLiteral(unitShift - 1, 1);
            }
            else
            {
                writer.WriteLiteral(unitShift & 0x01, 1);
                if (unitShift > 0)
                {
                    writer.WriteLiteral(unitShift - 1, 1);
                }
            }

            if (sequenceHeader.ColorConfig.SubSamplingX && sequenceHeader.ColorConfig.SubSamplingY && frameInfo.LoopRestorationParameters.UsesChromaLoopRestoration)
            {
                writer.WriteLiteral((uint)frameInfo.LoopRestorationParameters.UVShift, 1);
            }
        }
    }

    private static void WriteCdefParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, int planesCount)
    {
        _ = writer;
        _ = sequenceHeader;
        _ = frameInfo;
        _ = planesCount;

        if (!frameInfo.CodedLossless && !frameInfo.AllowIntraBlockCopy && sequenceHeader.EnableCdef)
        {
            throw new NotImplementedException("Didn't implment writing CDF yet.");
        }
    }

    private static void WriteGlobalMotionParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameInfo, bool isIntraFrame)
    {
        _ = writer;
        _ = sequenceHeader;
        _ = frameInfo;

        // Nothing to be written for INTRA frames.
        Guard.IsTrue(isIntraFrame, nameof(isIntraFrame), "Still picture contains only INTRA frames.");
    }

    private static void WriteFrameReferenceMode(ref Av1BitStreamWriter writer, bool isIntraFrame)
    {
        _ = writer;

        // Nothing to be written for INTRA frames.
        Guard.IsTrue(isIntraFrame, nameof(isIntraFrame), "Still picture contains only INTRA frames.");
    }

    private static void WriteSkipModeParameters(ref Av1BitStreamWriter writer, bool isIntraFrame)
    {
        _ = writer;

        // Nothing to be written for INTRA frames.
        Guard.IsTrue(isIntraFrame, nameof(isIntraFrame), "Still picture contains only INTRA frames.");
    }

    private static void WriteFilmGrainFilterParameters(ref Av1BitStreamWriter writer, ObuSequenceHeader sequenceHeader, ObuFrameHeader frameHeader)
    {
        ObuFilmGrainParameters grainParams = frameHeader.FilmGrainParameters;
        if (!sequenceHeader.AreFilmGrainingParametersPresent && (!frameHeader.ShowFrame && !frameHeader.ShowableFrame))
        {
            return;
        }

        writer.WriteBoolean(grainParams.ApplyGrain);
        if (!grainParams.ApplyGrain)
        {
            return;
        }

        writer.WriteLiteral(grainParams.GrainSeed, 16);
        writer.WriteLiteral(grainParams.NumYPoints, 4);
        Guard.NotNull(grainParams.PointYValue);
        Guard.NotNull(grainParams.PointYScaling);
        for (int i = 0; i < grainParams.NumYPoints; i++)
        {
            writer.WriteLiteral(grainParams.PointYValue[i], 8);
            writer.WriteLiteral(grainParams.PointYScaling[i], 8);
        }

        if (!sequenceHeader.ColorConfig.IsMonochrome)
        {
            writer.WriteBoolean(grainParams.ChromaScalingFromLuma);
        }

        if (!sequenceHeader.ColorConfig.IsMonochrome &&
            !grainParams.ChromaScalingFromLuma &&
            (!sequenceHeader.ColorConfig.SubSamplingX || !sequenceHeader.ColorConfig.SubSamplingY || grainParams.NumYPoints != 0))
        {
            writer.WriteLiteral(grainParams.NumCbPoints, 4);
            Guard.NotNull(grainParams.PointCbValue);
            Guard.NotNull(grainParams.PointCbScaling);
            for (int i = 0; i < grainParams.NumCbPoints; i++)
            {
                writer.WriteLiteral(grainParams.PointCbValue[i], 8);
                writer.WriteLiteral(grainParams.PointCbScaling[i], 8);
            }

            writer.WriteLiteral(grainParams.NumCrPoints, 4);
            Guard.NotNull(grainParams.PointCrValue);
            Guard.NotNull(grainParams.PointCrScaling);
            for (int i = 0; i < grainParams.NumCbPoints; i++)
            {
                writer.WriteLiteral(grainParams.PointCrValue[i], 8);
                writer.WriteLiteral(grainParams.PointCrScaling[i], 8);
            }
        }

        writer.WriteLiteral(grainParams.GrainScalingMinus8, 2);
        writer.WriteLiteral(grainParams.ArCoeffLag, 2);
        uint numPosLuma = 2 * grainParams.ArCoeffLag * (grainParams.ArCoeffLag + 1);

        uint numPosChroma = 0;
        if (grainParams.NumYPoints != 0)
        {
            numPosChroma = numPosLuma + 1;
            Guard.NotNull(grainParams.ArCoeffsYPlus128);
            for (int i = 0; i < numPosLuma; i++)
            {
                writer.WriteLiteral(grainParams.ArCoeffsYPlus128[i], 8);
            }
        }

        if (grainParams.ChromaScalingFromLuma || grainParams.NumCbPoints != 0)
        {
            Guard.NotNull(grainParams.ArCoeffsCbPlus128);
            for (int i = 0; i < numPosChroma; i++)
            {
                writer.WriteLiteral(grainParams.ArCoeffsCbPlus128[i], 8);
            }
        }

        if (grainParams.ChromaScalingFromLuma || grainParams.NumCrPoints != 0)
        {
            Guard.NotNull(grainParams.ArCoeffsCrPlus128);
            for (int i = 0; i < numPosChroma; i++)
            {
                writer.WriteLiteral(grainParams.ArCoeffsCrPlus128[i], 8);
            }
        }

        writer.WriteLiteral(grainParams.ArCoeffShiftMinus6, 2);
        writer.WriteLiteral(grainParams.GrainScaleShift, 2);
        if (grainParams.NumCbPoints != 0)
        {
            writer.WriteLiteral(grainParams.CbMult, 8);
            writer.WriteLiteral(grainParams.CbLumaMult, 8);
            writer.WriteLiteral(grainParams.CbOffset, 9);
        }

        if (grainParams.NumCrPoints != 0)
        {
            writer.WriteLiteral(grainParams.CrMult, 8);
            writer.WriteLiteral(grainParams.CrLumaMult, 8);
            writer.WriteLiteral(grainParams.CrOffset, 9);
        }

        writer.WriteBoolean(grainParams.OverlapFlag);
        writer.WriteBoolean(grainParams.ClipToRestrictedRange);
    }
}
