// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Formats.Heif.Av1.Transform;

internal static class Av1ScanOrderConstants
{
    public const int QuantizationMatrixLevelBitCount = 4;
    public const int QuantizationMatrixLevelCount = 1 << QuantizationMatrixLevelBitCount;

    private static readonly Av1ScanOrder[][] ScanOrders =
    [

        // Transform size 4x4
        [
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(DefaultScan4x4, DefaultIScan4x4, DefaultScan4x4Neighbors),
            new(MatrixRowScan4x4, MatrixRowIScan4x4, MatrixRowScan4x4Neighbors),
            new(MatrixColumnScan4x4, MatrixColumnIScan4x4, MatrixColumnScan4x4Neighbors),
            new(MatrixRowScan4x4, MatrixRowIScan4x4, MatrixRowScan4x4Neighbors),
            new(MatrixColumnScan4x4, MatrixColumnIScan4x4, MatrixColumnScan4x4Neighbors),
            new(MatrixRowScan4x4, MatrixRowIScan4x4, MatrixRowScan4x4Neighbors),
            new(MatrixColumnScan4x4, MatrixColumnIScan4x4, MatrixColumnScan4x4Neighbors),
        ],

        // Transform size 8x8
        [
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(DefaultScan8x8, DefaultIScan8x8, DefaultScan8x8Neighbors),
            new(MatrixRowScan8x8, MatrixRowIScan8x8, MatrixRowScan8x8Neighbors),
            new(MatrixColumnScan8x8, MatrixColumnIScan8x8, MatrixColumnScan8x8Neighbors),
            new(MatrixRowScan8x8, MatrixRowIScan8x8, MatrixRowScan8x8Neighbors),
            new(MatrixColumnScan8x8, MatrixColumnIScan8x8, MatrixColumnScan8x8Neighbors),
            new(MatrixRowScan8x8, MatrixRowIScan8x8, MatrixRowScan8x8Neighbors),
            new(MatrixColumnScan8x8, MatrixColumnIScan8x8, MatrixColumnScan8x8Neighbors),
        ],

        // Transform size 16x16
        [
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(DefaultScan16x16, DefaultIScan16x16, DefaultScan16x16Neighbors),
            new(MatrixRowScan16x16, MatrixRowIScan16x16, MatrixRowScan16x16Neighbors),
            new(MatrixColumnScan16x16, MatrixColumnIScan16x16, MatrixColumnScan16x16Neighbors),
            new(MatrixRowScan16x16, MatrixRowIScan16x16, MatrixRowScan16x16Neighbors),
            new(MatrixColumnScan16x16, MatrixColumnIScan16x16, MatrixColumnScan16x16Neighbors),
            new(MatrixRowScan16x16, MatrixRowIScan16x16, MatrixRowScan16x16Neighbors),
            new(MatrixColumnScan16x16, MatrixColumnIScan16x16, MatrixColumnScan16x16Neighbors),
        ],

        // Transform size 32x32
        [
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
        ],
        [

            // Transform size 64X64
            // Half of the coefficients of tx64 at higher frequencies are set to
            // zeros. So tx32's scan order is used.
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
        ],
        [

            // Transform size 4X8
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(DefaultScan4x8, DefaultIScan4x8, DefaultScan4x8Neighbors),
            new(MatrixRowScan4x8, MatrixRowIScan4x8, MatrixRowScan4x8Neighbors),
            new(MatrixColumnScan4x8, MatrixColumnIScan4x8, MatrixColumnScan4x8Neighbors),
            new(MatrixRowScan4x8, MatrixRowIScan4x8, MatrixRowScan4x8Neighbors),
            new(MatrixColumnScan4x8, MatrixColumnIScan4x8, MatrixColumnScan4x8Neighbors),
            new(MatrixRowScan4x8, MatrixRowIScan4x8, MatrixRowScan4x8Neighbors),
            new(MatrixColumnScan4x8, MatrixColumnIScan4x8, MatrixColumnScan4x8Neighbors),
        ],
        [

            // Transform size 8X4
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(DefaultScan8x4, DefaultIScan8x4, DefaultScan8x4Neighbors),
            new(MatrixRowScan8x4, MatrixRowIScan8x4, MatrixRowScan8x4Neighbors),
            new(MatrixColumnScan8x4, MatrixColumnIScan8x4, MatrixColumnScan8x4Neighbors),
            new(MatrixRowScan8x4, MatrixRowIScan8x4, MatrixRowScan8x4Neighbors),
            new(MatrixColumnScan8x4, MatrixColumnIScan8x4, MatrixColumnScan8x4Neighbors),
            new(MatrixRowScan8x4, MatrixRowIScan8x4, MatrixRowScan8x4Neighbors),
            new(MatrixColumnScan8x4, MatrixColumnIScan8x4, MatrixColumnScan8x4Neighbors),
        ],
        [

            // Transform size 8X16
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(DefaultScan8x16, DefaultIScan8x16, DefaultScan8x16Neighbors),
            new(MatrixRowScan8x16, MatrixRowIScan8x16, MatrixRowScan8x16Neighbors),
            new(MatrixColumnScan8x16, MatrixColumnIScan8x16, MatrixColumnScan8x16Neighbors),
            new(MatrixRowScan8x16, MatrixRowIScan8x16, MatrixRowScan8x16Neighbors),
            new(MatrixColumnScan8x16, MatrixColumnIScan8x16, MatrixColumnScan8x16Neighbors),
            new(MatrixRowScan8x16, MatrixRowIScan8x16, MatrixRowScan8x16Neighbors),
            new(MatrixColumnScan8x16, MatrixColumnIScan8x16, MatrixColumnScan8x16Neighbors),
        ],
        [

            // Transform size 16X8
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(DefaultScan16x8, DefaultIScan16x8, DefaultScan16x8Neighbors),
            new(MatrixRowScan16x8, MatrixRowIScan16x8, MatrixRowScan16x8Neighbors),
            new(MatrixColumnScan16x8, MatrixColumnIScan16x8, MatrixColumnScan16x8Neighbors),
            new(MatrixRowScan16x8, MatrixRowIScan16x8, MatrixRowScan16x8Neighbors),
            new(MatrixColumnScan16x8, MatrixColumnIScan16x8, MatrixColumnScan16x8Neighbors),
            new(MatrixRowScan16x8, MatrixRowIScan16x8, MatrixRowScan16x8Neighbors),
            new(MatrixColumnScan16x8, MatrixColumnIScan16x8, MatrixColumnScan16x8Neighbors),
        ],
        [

            // Transform size 16X32
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
        ],
        [

            // Transform size 32X16
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
        ],
        [

            // Transform size 32X64
            // Half of the coefficients of tx64 at higher frequencies are set to
            // zeros. So tx32's scan order is used.
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
        ],
        [

            // Transform size 64X32
            // Half of the coefficients of tx64 at higher frequencies are set to
            // zeros. So tx32's scan order is used.
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(DefaultScan32x32, DefaultIScan32x32, DefaultScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
            new(MatrixRowScan32x32, MatrixRowIScan32x32, MatrixRowScan32x32Neighbors),
            new(MatrixColumnScan32x32, MatrixColumnIScan32x32, MatrixColumnScan32x32Neighbors),
        ],
        [

            // Transform size 4X16
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(DefaultScan4x16, DefaultIScan4x16, DefaultScan4x16Neighbors),
            new(MatrixRowScan4x16, MatrixRowIScan4x16, MatrixRowScan4x16Neighbors),
            new(MatrixColumnScan4x16, MatrixColumnIScan4x16, MatrixColumnScan4x16Neighbors),
            new(MatrixRowScan4x16, MatrixRowIScan4x16, MatrixRowScan4x16Neighbors),
            new(MatrixColumnScan4x16, MatrixColumnIScan4x16, MatrixColumnScan4x16Neighbors),
            new(MatrixRowScan4x16, MatrixRowIScan4x16, MatrixRowScan4x16Neighbors),
            new(MatrixColumnScan4x16, MatrixColumnIScan4x16, MatrixColumnScan4x16Neighbors),
        ],
        [

            // Transform size 16X4
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(DefaultScan16x4, DefaultIScan16x4, DefaultScan16x4Neighbors),
            new(MatrixRowScan16x4, MatrixRowIScan16x4, MatrixRowScan16x4Neighbors),
            new(MatrixColumnScan16x4, MatrixColumnIScan16x4, MatrixColumnScan16x4Neighbors),
            new(MatrixRowScan16x4, MatrixRowIScan16x4, MatrixRowScan16x4Neighbors),
            new(MatrixColumnScan16x4, MatrixColumnIScan16x4, MatrixColumnScan16x4Neighbors),
            new(MatrixRowScan16x4, MatrixRowIScan16x4, MatrixRowScan16x4Neighbors),
            new(MatrixColumnScan16x4, MatrixColumnIScan16x4, MatrixColumnScan16x4Neighbors),
        ],
        [

            // Transform size 8X32
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(DefaultScan8x32, DefaultIScan8x32, DefaultScan8x32Neighbors),
            new(MatrixRowScan8x32, MatrixRowIScan8x32, MatrixRowScan8x32Neighbors),
            new(MatrixColumnScan8x32, MatrixColumnIScan8x32, MatrixColumnScan8x32Neighbors),
            new(MatrixRowScan8x32, MatrixRowIScan8x32, MatrixRowScan8x32Neighbors),
            new(MatrixColumnScan8x32, MatrixColumnIScan8x32, MatrixColumnScan8x32Neighbors),
            new(MatrixRowScan8x32, MatrixRowIScan8x32, MatrixRowScan8x32Neighbors),
            new(MatrixColumnScan8x32, MatrixColumnIScan8x32, MatrixColumnScan8x32Neighbors),
        ],
        [

            // Transform size 32X8
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(DefaultScan32x8, DefaultIScan32x8, DefaultScan32x8Neighbors),
            new(MatrixRowScan32x8, MatrixRowIScan32x8, MatrixRowScan32x8Neighbors),
            new(MatrixColumnScan32x8, MatrixColumnIScan32x8, MatrixColumnScan32x8Neighbors),
            new(MatrixRowScan32x8, MatrixRowIScan32x8, MatrixRowScan32x8Neighbors),
            new(MatrixColumnScan32x8, MatrixColumnIScan32x8, MatrixColumnScan32x8Neighbors),
            new(MatrixRowScan32x8, MatrixRowIScan32x8, MatrixRowScan32x8Neighbors),
            new(MatrixColumnScan32x8, MatrixColumnIScan32x8, MatrixColumnScan32x8Neighbors),
        ],
        [

            // Transform size 16X64
            // Half of the coefficients of tx64 at higher frequencies are set to
            // zeros. So tx32's scan order is used.
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(DefaultScan16x32, DefaultIScan16x32, DefaultScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
            new(MatrixRowScan16x32, MatrixRowIScan16x32, MatrixRowScan16x32Neighbors),
            new(MatrixColumnScan16x32, MatrixColumnIScan16x32, MatrixColumnScan16x32Neighbors),
        ],
        [

            // Transform size 64X16
            // Half of the coefficients of tx64 at higher frequencies are set to
            // zeros. So tx32's scan order is used.
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(DefaultScan32x16, DefaultIScan32x16, DefaultScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
            new(MatrixRowScan32x16, MatrixRowIScan32x16, MatrixRowScan32x16Neighbors),
            new(MatrixColumnScan32x16, MatrixColumnIScan32x16, MatrixColumnScan32x16Neighbors),
        ]
    ];

    private static readonly short[] DefaultScan4x4 = [0, 1, 4, 8, 5, 2, 3, 6, 9, 12, 13, 10, 7, 11, 14, 15];
    private static readonly short[] DefaultScan8x8 = [
        0,  1,  8,  16, 9,  2,  3,  10, 17, 24, 32, 25, 18, 11, 4,  5,  12, 19, 26, 33, 40, 48,
        41, 34, 27, 20, 13, 6,  7,  14, 21, 28, 35, 42, 49, 56, 57, 50, 43, 36, 29, 22, 15, 23,
        30, 37, 44, 51, 58, 59, 52, 45, 38, 31, 39, 46, 53, 60, 61, 54, 47, 55, 62, 63];

    private static readonly short[] DefaultScan16x16 = [
        0,   1,   16,  32,  17,  2,   3,   18,  33,  48,  64,  49,  34,  19,  4,   5,   20,  35,  50,  65,  80,  96,
        81,  66,  51,  36,  21,  6,   7,   22,  37,  52,  67,  82,  97,  112, 128, 113, 98,  83,  68,  53,  38,  23,
        8,   9,   24,  39,  54,  69,  84,  99,  114, 129, 144, 160, 145, 130, 115, 100, 85,  70,  55,  40,  25,  10,
        11,  26,  41,  56,  71,  86,  101, 116, 131, 146, 161, 176, 192, 177, 162, 147, 132, 117, 102, 87,  72,  57,
        42,  27,  12,  13,  28,  43,  58,  73,  88,  103, 118, 133, 148, 163, 178, 193, 208, 224, 209, 194, 179, 164,
        149, 134, 119, 104, 89,  74,  59,  44,  29,  14,  15,  30,  45,  60,  75,  90,  105, 120, 135, 150, 165, 180,
        195, 210, 225, 240, 241, 226, 211, 196, 181, 166, 151, 136, 121, 106, 91,  76,  61,  46,  31,  47,  62,  77,
        92,  107, 122, 137, 152, 167, 182, 197, 212, 227, 242, 243, 228, 213, 198, 183, 168, 153, 138, 123, 108, 93,
        78,  63,  79,  94,  109, 124, 139, 154, 169, 184, 199, 214, 229, 244, 245, 230, 215, 200, 185, 170, 155, 140,
        125, 110, 95,  111, 126, 141, 156, 171, 186, 201, 216, 231, 246, 247, 232, 217, 202, 187, 172, 157, 142, 127,
        143, 158, 173, 188, 203, 218, 233, 248, 249, 234, 219, 204, 189, 174, 159, 175, 190, 205, 220, 235, 250, 251,
        236, 221, 206, 191, 207, 222, 237, 252, 253, 238, 223, 239, 254, 255];

    private static readonly short[] DefaultScan32x32 = [
        0,    1,    32,  64,  33,  2,   3,   34,  65,   96,   128,  97,  66,   35,   4,    5,    36,   67,  98,  129, 160,
        192,  161,  130, 99,  68,  37,  6,   7,   38,   69,   100,  131, 162,  193,  224,  256,  225,  194, 163, 132, 101,
        70,   39,   8,   9,   40,  71,  102, 133, 164,  195,  226,  257, 288,  320,  289,  258,  227,  196, 165, 134, 103,
        72,   41,   10,  11,  42,  73,  104, 135, 166,  197,  228,  259, 290,  321,  352,  384,  353,  322, 291, 260, 229,
        198,  167,  136, 105, 74,  43,  12,  13,  44,   75,   106,  137, 168,  199,  230,  261,  292,  323, 354, 385, 416,
        448,  417,  386, 355, 324, 293, 262, 231, 200,  169,  138,  107, 76,   45,   14,   15,   46,   77,  108, 139, 170,
        201,  232,  263, 294, 325, 356, 387, 418, 449,  480,  512,  481, 450,  419,  388,  357,  326,  295, 264, 233, 202,
        171,  140,  109, 78,  47,  16,  17,  48,  79,   110,  141,  172, 203,  234,  265,  296,  327,  358, 389, 420, 451,
        482,  513,  544, 576, 545, 514, 483, 452, 421,  390,  359,  328, 297,  266,  235,  204,  173,  142, 111, 80,  49,
        18,   19,   50,  81,  112, 143, 174, 205, 236,  267,  298,  329, 360,  391,  422,  453,  484,  515, 546, 577, 608,
        640,  609,  578, 547, 516, 485, 454, 423, 392,  361,  330,  299, 268,  237,  206,  175,  144,  113, 82,  51,  20,
        21,   52,   83,  114, 145, 176, 207, 238, 269,  300,  331,  362, 393,  424,  455,  486,  517,  548, 579, 610, 641,
        672,  704,  673, 642, 611, 580, 549, 518, 487,  456,  425,  394, 363,  332,  301,  270,  239,  208, 177, 146, 115,
        84,   53,   22,  23,  54,  85,  116, 147, 178,  209,  240,  271, 302,  333,  364,  395,  426,  457, 488, 519, 550,
        581,  612,  643, 674, 705, 736, 768, 737, 706,  675,  644,  613, 582,  551,  520,  489,  458,  427, 396, 365, 334,
        303,  272,  241, 210, 179, 148, 117, 86,  55,   24,   25,   56,  87,   118,  149,  180,  211,  242, 273, 304, 335,
        366,  397,  428, 459, 490, 521, 552, 583, 614,  645,  676,  707, 738,  769,  800,  832,  801,  770, 739, 708, 677,
        646,  615,  584, 553, 522, 491, 460, 429, 398,  367,  336,  305, 274,  243,  212,  181,  150,  119, 88,  57,  26,
        27,   58,   89,  120, 151, 182, 213, 244, 275,  306,  337,  368, 399,  430,  461,  492,  523,  554, 585, 616, 647,
        678,  709,  740, 771, 802, 833, 864, 896, 865,  834,  803,  772, 741,  710,  679,  648,  617,  586, 555, 524, 493,
        462,  431,  400, 369, 338, 307, 276, 245, 214,  183,  152,  121, 90,   59,   28,   29,   60,   91,  122, 153, 184,
        215,  246,  277, 308, 339, 370, 401, 432, 463,  494,  525,  556, 587,  618,  649,  680,  711,  742, 773, 804, 835,
        866,  897,  928, 960, 929, 898, 867, 836, 805,  774,  743,  712, 681,  650,  619,  588,  557,  526, 495, 464, 433,
        402,  371,  340, 309, 278, 247, 216, 185, 154,  123,  92,   61,  30,   31,   62,   93,   124,  155, 186, 217, 248,
        279,  310,  341, 372, 403, 434, 465, 496, 527,  558,  589,  620, 651,  682,  713,  744,  775,  806, 837, 868, 899,
        930,  961,  992, 993, 962, 931, 900, 869, 838,  807,  776,  745, 714,  683,  652,  621,  590,  559, 528, 497, 466,
        435,  404,  373, 342, 311, 280, 249, 218, 187,  156,  125,  94,  63,   95,   126,  157,  188,  219, 250, 281, 312,
        343,  374,  405, 436, 467, 498, 529, 560, 591,  622,  653,  684, 715,  746,  777,  808,  839,  870, 901, 932, 963,
        994,  995,  964, 933, 902, 871, 840, 809, 778,  747,  716,  685, 654,  623,  592,  561,  530,  499, 468, 437, 406,
        375,  344,  313, 282, 251, 220, 189, 158, 127,  159,  190,  221, 252,  283,  314,  345,  376,  407, 438, 469, 500,
        531,  562,  593, 624, 655, 686, 717, 748, 779,  810,  841,  872, 903,  934,  965,  996,  997,  966, 935, 904, 873,
        842,  811,  780, 749, 718, 687, 656, 625, 594,  563,  532,  501, 470,  439,  408,  377,  346,  315, 284, 253, 222,
        191,  223,  254, 285, 316, 347, 378, 409, 440,  471,  502,  533, 564,  595,  626,  657,  688,  719, 750, 781, 812,
        843,  874,  905, 936, 967, 998, 999, 968, 937,  906,  875,  844, 813,  782,  751,  720,  689,  658, 627, 596, 565,
        534,  503,  472, 441, 410, 379, 348, 317, 286,  255,  287,  318, 349,  380,  411,  442,  473,  504, 535, 566, 597,
        628,  659,  690, 721, 752, 783, 814, 845, 876,  907,  938,  969, 1000, 1001, 970,  939,  908,  877, 846, 815, 784,
        753,  722,  691, 660, 629, 598, 567, 536, 505,  474,  443,  412, 381,  350,  319,  351,  382,  413, 444, 475, 506,
        537,  568,  599, 630, 661, 692, 723, 754, 785,  816,  847,  878, 909,  940,  971,  1002, 1003, 972, 941, 910, 879,
        848,  817,  786, 755, 724, 693, 662, 631, 600,  569,  538,  507, 476,  445,  414,  383,  415,  446, 477, 508, 539,
        570,  601,  632, 663, 694, 725, 756, 787, 818,  849,  880,  911, 942,  973,  1004, 1005, 974,  943, 912, 881, 850,
        819,  788,  757, 726, 695, 664, 633, 602, 571,  540,  509,  478, 447,  479,  510,  541,  572,  603, 634, 665, 696,
        727,  758,  789, 820, 851, 882, 913, 944, 975,  1006, 1007, 976, 945,  914,  883,  852,  821,  790, 759, 728, 697,
        666,  635,  604, 573, 542, 511, 543, 574, 605,  636,  667,  698, 729,  760,  791,  822,  853,  884, 915, 946, 977,
        1008, 1009, 978, 947, 916, 885, 854, 823, 792,  761,  730,  699, 668,  637,  606,  575,  607,  638, 669, 700, 731,
        762,  793,  824, 855, 886, 917, 948, 979, 1010, 1011, 980,  949, 918,  887,  856,  825,  794,  763, 732, 701, 670,
        639,  671,  702, 733, 764, 795, 826, 857, 888,  919,  950,  981, 1012, 1013, 982,  951,  920,  889, 858, 827, 796,
        765,  734,  703, 735, 766, 797, 828, 859, 890,  921,  952,  983, 1014, 1015, 984,  953,  922,  891, 860, 829, 798,
        767,  799,  830, 861, 892, 923, 954, 985, 1016, 1017, 986,  955, 924,  893,  862,  831,  863,  894, 925, 956, 987,
        1018, 1019, 988, 957, 926, 895, 927, 958, 989,  1020, 1021, 990, 959,  991,  1022, 1023];

    private static readonly short[] DefaultScan4x8 = [
        0,  1,  4,  2,  5,  8,  3,  6,  9,  12, 7,  10, 13, 16, 11, 14,
        17, 20, 15, 18, 21, 24, 19, 22, 25, 28, 23, 26, 29, 27, 30, 31,];

    private static readonly short[] DefaultScan8x4 = [
        0,  8, 1,  16, 9,  2, 24, 17, 10, 3, 25, 18, 11, 4,  26, 19,
        12, 5, 27, 20, 13, 6, 28, 21, 14, 7, 29, 22, 15, 30, 23, 31,];

    private static readonly short[] DefaultScan8x16 = [
        0,   1,   8,   2,   9,   16,  3,   10,  17,  24,  4,   11,  18,  25,  32,  5,   12,  19,  26,  33, 40, 6,
        13,  20,  27,  34,  41,  48,  7,   14,  21,  28,  35,  42,  49,  56,  15,  22,  29,  36,  43,  50, 57, 64,
        23,  30,  37,  44,  51,  58,  65,  72,  31,  38,  45,  52,  59,  66,  73,  80,  39,  46,  53,  60, 67, 74,
        81,  88,  47,  54,  61,  68,  75,  82,  89,  96,  55,  62,  69,  76,  83,  90,  97,  104, 63,  70, 77, 84,
        91,  98,  105, 112, 71,  78,  85,  92,  99,  106, 113, 120, 79,  86,  93,  100, 107, 114, 121, 87, 94, 101,
        108, 115, 122, 95,  102, 109, 116, 123, 103, 110, 117, 124, 111, 118, 125, 119, 126, 127,];

    private static readonly short[] DefaultScan16x8 = [
        0,   16, 1,   32,  17,  2,   48,  33, 18,  3,   64,  49,  34,  19,  4,   80,  65,  50,  35,  20,  5,   96,
        81,  66, 51,  36,  21,  6,   112, 97, 82,  67,  52,  37,  22,  7,   113, 98,  83,  68,  53,  38,  23,  8,
        114, 99, 84,  69,  54,  39,  24,  9,  115, 100, 85,  70,  55,  40,  25,  10,  116, 101, 86,  71,  56,  41,
        26,  11, 117, 102, 87,  72,  57,  42, 27,  12,  118, 103, 88,  73,  58,  43,  28,  13,  119, 104, 89,  74,
        59,  44, 29,  14,  120, 105, 90,  75, 60,  45,  30,  15,  121, 106, 91,  76,  61,  46,  31,  122, 107, 92,
        77,  62, 47,  123, 108, 93,  78,  63, 124, 109, 94,  79,  125, 110, 95,  126, 111, 127,];

    private static readonly short[] DefaultScan16x32 = [
        0,   1,   16,  2,   17,  32,  3,   18,  33,  48,  4,   19,  34,  49,  64,  5,   20,  35,  50,  65,  80,  6,   21,
        36,  51,  66,  81,  96,  7,   22,  37,  52,  67,  82,  97,  112, 8,   23,  38,  53,  68,  83,  98,  113, 128, 9,
        24,  39,  54,  69,  84,  99,  114, 129, 144, 10,  25,  40,  55,  70,  85,  100, 115, 130, 145, 160, 11,  26,  41,
        56,  71,  86,  101, 116, 131, 146, 161, 176, 12,  27,  42,  57,  72,  87,  102, 117, 132, 147, 162, 177, 192, 13,
        28,  43,  58,  73,  88,  103, 118, 133, 148, 163, 178, 193, 208, 14,  29,  44,  59,  74,  89,  104, 119, 134, 149,
        164, 179, 194, 209, 224, 15,  30,  45,  60,  75,  90,  105, 120, 135, 150, 165, 180, 195, 210, 225, 240, 31,  46,
        61,  76,  91,  106, 121, 136, 151, 166, 181, 196, 211, 226, 241, 256, 47,  62,  77,  92,  107, 122, 137, 152, 167,
        182, 197, 212, 227, 242, 257, 272, 63,  78,  93,  108, 123, 138, 153, 168, 183, 198, 213, 228, 243, 258, 273, 288,
        79,  94,  109, 124, 139, 154, 169, 184, 199, 214, 229, 244, 259, 274, 289, 304, 95,  110, 125, 140, 155, 170, 185,
        200, 215, 230, 245, 260, 275, 290, 305, 320, 111, 126, 141, 156, 171, 186, 201, 216, 231, 246, 261, 276, 291, 306,
        321, 336, 127, 142, 157, 172, 187, 202, 217, 232, 247, 262, 277, 292, 307, 322, 337, 352, 143, 158, 173, 188, 203,
        218, 233, 248, 263, 278, 293, 308, 323, 338, 353, 368, 159, 174, 189, 204, 219, 234, 249, 264, 279, 294, 309, 324,
        339, 354, 369, 384, 175, 190, 205, 220, 235, 250, 265, 280, 295, 310, 325, 340, 355, 370, 385, 400, 191, 206, 221,
        236, 251, 266, 281, 296, 311, 326, 341, 356, 371, 386, 401, 416, 207, 222, 237, 252, 267, 282, 297, 312, 327, 342,
        357, 372, 387, 402, 417, 432, 223, 238, 253, 268, 283, 298, 313, 328, 343, 358, 373, 388, 403, 418, 433, 448, 239,
        254, 269, 284, 299, 314, 329, 344, 359, 374, 389, 404, 419, 434, 449, 464, 255, 270, 285, 300, 315, 330, 345, 360,
        375, 390, 405, 420, 435, 450, 465, 480, 271, 286, 301, 316, 331, 346, 361, 376, 391, 406, 421, 436, 451, 466, 481,
        496, 287, 302, 317, 332, 347, 362, 377, 392, 407, 422, 437, 452, 467, 482, 497, 303, 318, 333, 348, 363, 378, 393,
        408, 423, 438, 453, 468, 483, 498, 319, 334, 349, 364, 379, 394, 409, 424, 439, 454, 469, 484, 499, 335, 350, 365,
        380, 395, 410, 425, 440, 455, 470, 485, 500, 351, 366, 381, 396, 411, 426, 441, 456, 471, 486, 501, 367, 382, 397,
        412, 427, 442, 457, 472, 487, 502, 383, 398, 413, 428, 443, 458, 473, 488, 503, 399, 414, 429, 444, 459, 474, 489,
        504, 415, 430, 445, 460, 475, 490, 505, 431, 446, 461, 476, 491, 506, 447, 462, 477, 492, 507, 463, 478, 493, 508,
        479, 494, 509, 495, 510, 511,];

    private static readonly short[] DefaultScan32x16 = [
        0,   32,  1,   64,  33,  2,   96,  65,  34,  3,   128, 97,  66,  35,  4,   160, 129, 98,  67,  36,  5,   192, 161,
        130, 99,  68,  37,  6,   224, 193, 162, 131, 100, 69,  38,  7,   256, 225, 194, 163, 132, 101, 70,  39,  8,   288,
        257, 226, 195, 164, 133, 102, 71,  40,  9,   320, 289, 258, 227, 196, 165, 134, 103, 72,  41,  10,  352, 321, 290,
        259, 228, 197, 166, 135, 104, 73,  42,  11,  384, 353, 322, 291, 260, 229, 198, 167, 136, 105, 74,  43,  12,  416,
        385, 354, 323, 292, 261, 230, 199, 168, 137, 106, 75,  44,  13,  448, 417, 386, 355, 324, 293, 262, 231, 200, 169,
        138, 107, 76,  45,  14,  480, 449, 418, 387, 356, 325, 294, 263, 232, 201, 170, 139, 108, 77,  46,  15,  481, 450,
        419, 388, 357, 326, 295, 264, 233, 202, 171, 140, 109, 78,  47,  16,  482, 451, 420, 389, 358, 327, 296, 265, 234,
        203, 172, 141, 110, 79,  48,  17,  483, 452, 421, 390, 359, 328, 297, 266, 235, 204, 173, 142, 111, 80,  49,  18,
        484, 453, 422, 391, 360, 329, 298, 267, 236, 205, 174, 143, 112, 81,  50,  19,  485, 454, 423, 392, 361, 330, 299,
        268, 237, 206, 175, 144, 113, 82,  51,  20,  486, 455, 424, 393, 362, 331, 300, 269, 238, 207, 176, 145, 114, 83,
        52,  21,  487, 456, 425, 394, 363, 332, 301, 270, 239, 208, 177, 146, 115, 84,  53,  22,  488, 457, 426, 395, 364,
        333, 302, 271, 240, 209, 178, 147, 116, 85,  54,  23,  489, 458, 427, 396, 365, 334, 303, 272, 241, 210, 179, 148,
        117, 86,  55,  24,  490, 459, 428, 397, 366, 335, 304, 273, 242, 211, 180, 149, 118, 87,  56,  25,  491, 460, 429,
        398, 367, 336, 305, 274, 243, 212, 181, 150, 119, 88,  57,  26,  492, 461, 430, 399, 368, 337, 306, 275, 244, 213,
        182, 151, 120, 89,  58,  27,  493, 462, 431, 400, 369, 338, 307, 276, 245, 214, 183, 152, 121, 90,  59,  28,  494,
        463, 432, 401, 370, 339, 308, 277, 246, 215, 184, 153, 122, 91,  60,  29,  495, 464, 433, 402, 371, 340, 309, 278,
        247, 216, 185, 154, 123, 92,  61,  30,  496, 465, 434, 403, 372, 341, 310, 279, 248, 217, 186, 155, 124, 93,  62,
        31,  497, 466, 435, 404, 373, 342, 311, 280, 249, 218, 187, 156, 125, 94,  63,  498, 467, 436, 405, 374, 343, 312,
        281, 250, 219, 188, 157, 126, 95,  499, 468, 437, 406, 375, 344, 313, 282, 251, 220, 189, 158, 127, 500, 469, 438,
        407, 376, 345, 314, 283, 252, 221, 190, 159, 501, 470, 439, 408, 377, 346, 315, 284, 253, 222, 191, 502, 471, 440,
        409, 378, 347, 316, 285, 254, 223, 503, 472, 441, 410, 379, 348, 317, 286, 255, 504, 473, 442, 411, 380, 349, 318,
        287, 505, 474, 443, 412, 381, 350, 319, 506, 475, 444, 413, 382, 351, 507, 476, 445, 414, 383, 508, 477, 446, 415,
        509, 478, 447, 510, 479, 511,];

    private static readonly short[] DefaultScan4x16 = [
        0,  1,  4,  2,  5,  8,  3,  6,  9,  12, 7,  10, 13, 16, 11, 14, 17, 20, 15, 18, 21, 24,
        19, 22, 25, 28, 23, 26, 29, 32, 27, 30, 33, 36, 31, 34, 37, 40, 35, 38, 41, 44, 39, 42,
        45, 48, 43, 46, 49, 52, 47, 50, 53, 56, 51, 54, 57, 60, 55, 58, 61, 59, 62, 63,];

    private static readonly short[] DefaultScan16x4 = [
         0,  16, 1,  32, 17, 2,  48, 33, 18, 3,  49, 34, 19, 4,  50, 35, 20, 5,  51, 36, 21, 6,
        52, 37, 22, 7,  53, 38, 23, 8,  54, 39, 24, 9,  55, 40, 25, 10, 56, 41, 26, 11, 57, 42,
        27, 12, 58, 43, 28, 13, 59, 44, 29, 14, 60, 45, 30, 15, 61, 46, 31, 62, 47, 63,];

    private static readonly short[] DefaultScan8x32 = [
        0,   1,   8,   2,   9,   16,  3,   10,  17,  24,  4,   11,  18,  25,  32,  5,   12,  19,  26,  33,  40,  6,
        13,  20,  27,  34,  41,  48,  7,   14,  21,  28,  35,  42,  49,  56,  15,  22,  29,  36,  43,  50,  57,  64,
        23,  30,  37,  44,  51,  58,  65,  72,  31,  38,  45,  52,  59,  66,  73,  80,  39,  46,  53,  60,  67,  74,
        81,  88,  47,  54,  61,  68,  75,  82,  89,  96,  55,  62,  69,  76,  83,  90,  97,  104, 63,  70,  77,  84,
        91,  98,  105, 112, 71,  78,  85,  92,  99,  106, 113, 120, 79,  86,  93,  100, 107, 114, 121, 128, 87,  94,
        101, 108, 115, 122, 129, 136, 95,  102, 109, 116, 123, 130, 137, 144, 103, 110, 117, 124, 131, 138, 145, 152,
        111, 118, 125, 132, 139, 146, 153, 160, 119, 126, 133, 140, 147, 154, 161, 168, 127, 134, 141, 148, 155, 162,
        169, 176, 135, 142, 149, 156, 163, 170, 177, 184, 143, 150, 157, 164, 171, 178, 185, 192, 151, 158, 165, 172,
        179, 186, 193, 200, 159, 166, 173, 180, 187, 194, 201, 208, 167, 174, 181, 188, 195, 202, 209, 216, 175, 182,
        189, 196, 203, 210, 217, 224, 183, 190, 197, 204, 211, 218, 225, 232, 191, 198, 205, 212, 219, 226, 233, 240,
        199, 206, 213, 220, 227, 234, 241, 248, 207, 214, 221, 228, 235, 242, 249, 215, 222, 229, 236, 243, 250, 223,
        230, 237, 244, 251, 231, 238, 245, 252, 239, 246, 253, 247, 254, 255,];

    private static readonly short[] DefaultScan32x8 = [
        0,   32,  1,   64,  33,  2,   96,  65,  34,  3,   128, 97,  66,  35,  4,   160, 129, 98,  67,  36,  5,   192,
        161, 130, 99,  68,  37,  6,   224, 193, 162, 131, 100, 69,  38,  7,   225, 194, 163, 132, 101, 70,  39,  8,
        226, 195, 164, 133, 102, 71,  40,  9,   227, 196, 165, 134, 103, 72,  41,  10,  228, 197, 166, 135, 104, 73,
        42,  11,  229, 198, 167, 136, 105, 74,  43,  12,  230, 199, 168, 137, 106, 75,  44,  13,  231, 200, 169, 138,
        107, 76,  45,  14,  232, 201, 170, 139, 108, 77,  46,  15,  233, 202, 171, 140, 109, 78,  47,  16,  234, 203,
        172, 141, 110, 79,  48,  17,  235, 204, 173, 142, 111, 80,  49,  18,  236, 205, 174, 143, 112, 81,  50,  19,
        237, 206, 175, 144, 113, 82,  51,  20,  238, 207, 176, 145, 114, 83,  52,  21,  239, 208, 177, 146, 115, 84,
        53,  22,  240, 209, 178, 147, 116, 85,  54,  23,  241, 210, 179, 148, 117, 86,  55,  24,  242, 211, 180, 149,
        118, 87,  56,  25,  243, 212, 181, 150, 119, 88,  57,  26,  244, 213, 182, 151, 120, 89,  58,  27,  245, 214,
        183, 152, 121, 90,  59,  28,  246, 215, 184, 153, 122, 91,  60,  29,  247, 216, 185, 154, 123, 92,  61,  30,
        248, 217, 186, 155, 124, 93,  62,  31,  249, 218, 187, 156, 125, 94,  63,  250, 219, 188, 157, 126, 95,  251,
        220, 189, 158, 127, 252, 221, 190, 159, 253, 222, 191, 254, 223, 255,];

    private static readonly short[] MatrixColumnScan4x4 = [0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15];
    private static readonly short[] MatrixColumnScan8x8 = [
        0,  8,  16, 24, 32, 40, 48, 56, 1,  9,  17, 25, 33, 41, 49, 57, 2,  10, 18, 26, 34, 42,
        50, 58, 3,  11, 19, 27, 35, 43, 51, 59, 4,  12, 20, 28, 36, 44, 52, 60, 5,  13, 21, 29,
        37, 45, 53, 61, 6,  14, 22, 30, 38, 46, 54, 62, 7,  15, 23, 31, 39, 47, 55, 63];

    private static readonly short[] MatrixColumnScan16x16 = [
         0,   16,  32,  48,  64,  80,  96,  112, 128, 144, 160, 176, 192, 208, 224, 240, 1,   17,  33,  49,  65,  81,
        97,  113, 129, 145, 161, 177, 193, 209, 225, 241, 2,   18,  34,  50,  66,  82,  98,  114, 130, 146, 162, 178,
        194, 210, 226, 242, 3,   19,  35,  51,  67,  83,  99,  115, 131, 147, 163, 179, 195, 211, 227, 243, 4,   20,
        36,  52,  68,  84,  100, 116, 132, 148, 164, 180, 196, 212, 228, 244, 5,   21,  37,  53,  69,  85,  101, 117,
        133, 149, 165, 181, 197, 213, 229, 245, 6,   22,  38,  54,  70,  86,  102, 118, 134, 150, 166, 182, 198, 214,
        230, 246, 7,   23,  39,  55,  71,  87,  103, 119, 135, 151, 167, 183, 199, 215, 231, 247, 8,   24,  40,  56,
        72,  88,  104, 120, 136, 152, 168, 184, 200, 216, 232, 248, 9,   25,  41,  57,  73,  89,  105, 121, 137, 153,
        169, 185, 201, 217, 233, 249, 10,  26,  42,  58,  74,  90,  106, 122, 138, 154, 170, 186, 202, 218, 234, 250,
        11,  27,  43,  59,  75,  91,  107, 123, 139, 155, 171, 187, 203, 219, 235, 251, 12,  28,  44,  60,  76,  92,
        108, 124, 140, 156, 172, 188, 204, 220, 236, 252, 13,  29,  45,  61,  77,  93,  109, 125, 141, 157, 173, 189,
        205, 221, 237, 253, 14,  30,  46,  62,  78,  94,  110, 126, 142, 158, 174, 190, 206, 222, 238, 254, 15,  31,
        47,  63,  79,  95,  111, 127, 143, 159, 175, 191, 207, 223, 239, 255,];

    private static readonly short[] MatrixColumnScan32x32 = [
        0,   32,  64,  96,   128, 160, 192, 224,  256, 288, 320, 352,  384, 416, 448, 480,  512, 544, 576, 608,
        640, 672, 704, 736,  768, 800, 832, 864,  896, 928, 960, 992,  1,   33,  65,  97,   129, 161, 193, 225,
        257, 289, 321, 353,  385, 417, 449, 481,  513, 545, 577, 609,  641, 673, 705, 737,  769, 801, 833, 865,
        897, 929, 961, 993,  2,   34,  66,  98,   130, 162, 194, 226,  258, 290, 322, 354,  386, 418, 450, 482,
        514, 546, 578, 610,  642, 674, 706, 738,  770, 802, 834, 866,  898, 930, 962, 994,  3,   35,  67,  99,
        131, 163, 195, 227,  259, 291, 323, 355,  387, 419, 451, 483,  515, 547, 579, 611,  643, 675, 707, 739,
        771, 803, 835, 867,  899, 931, 963, 995,  4,   36,  68,  100,  132, 164, 196, 228,  260, 292, 324, 356,
        388, 420, 452, 484,  516, 548, 580, 612,  644, 676, 708, 740,  772, 804, 836, 868,  900, 932, 964, 996,
        5,   37,  69,  101,  133, 165, 197, 229,  261, 293, 325, 357,  389, 421, 453, 485,  517, 549, 581, 613,
        645, 677, 709, 741,  773, 805, 837, 869,  901, 933, 965, 997,  6,   38,  70,  102,  134, 166, 198, 230,
        262, 294, 326, 358,  390, 422, 454, 486,  518, 550, 582, 614,  646, 678, 710, 742,  774, 806, 838, 870,
        902, 934, 966, 998,  7,   39,  71,  103,  135, 167, 199, 231,  263, 295, 327, 359,  391, 423, 455, 487,
        519, 551, 583, 615,  647, 679, 711, 743,  775, 807, 839, 871,  903, 935, 967, 999,  8,   40,  72,  104,
        136, 168, 200, 232,  264, 296, 328, 360,  392, 424, 456, 488,  520, 552, 584, 616,  648, 680, 712, 744,
        776, 808, 840, 872,  904, 936, 968, 1000, 9,   41,  73,  105,  137, 169, 201, 233,  265, 297, 329, 361,
        393, 425, 457, 489,  521, 553, 585, 617,  649, 681, 713, 745,  777, 809, 841, 873,  905, 937, 969, 1001,
        10,  42,  74,  106,  138, 170, 202, 234,  266, 298, 330, 362,  394, 426, 458, 490,  522, 554, 586, 618,
        650, 682, 714, 746,  778, 810, 842, 874,  906, 938, 970, 1002, 11,  43,  75,  107,  139, 171, 203, 235,
        267, 299, 331, 363,  395, 427, 459, 491,  523, 555, 587, 619,  651, 683, 715, 747,  779, 811, 843, 875,
        907, 939, 971, 1003, 12,  44,  76,  108,  140, 172, 204, 236,  268, 300, 332, 364,  396, 428, 460, 492,
        524, 556, 588, 620,  652, 684, 716, 748,  780, 812, 844, 876,  908, 940, 972, 1004, 13,  45,  77,  109,
        141, 173, 205, 237,  269, 301, 333, 365,  397, 429, 461, 493,  525, 557, 589, 621,  653, 685, 717, 749,
        781, 813, 845, 877,  909, 941, 973, 1005, 14,  46,  78,  110,  142, 174, 206, 238,  270, 302, 334, 366,
        398, 430, 462, 494,  526, 558, 590, 622,  654, 686, 718, 750,  782, 814, 846, 878,  910, 942, 974, 1006,
        15,  47,  79,  111,  143, 175, 207, 239,  271, 303, 335, 367,  399, 431, 463, 495,  527, 559, 591, 623,
        655, 687, 719, 751,  783, 815, 847, 879,  911, 943, 975, 1007, 16,  48,  80,  112,  144, 176, 208, 240,
        272, 304, 336, 368,  400, 432, 464, 496,  528, 560, 592, 624,  656, 688, 720, 752,  784, 816, 848, 880,
        912, 944, 976, 1008, 17,  49,  81,  113,  145, 177, 209, 241,  273, 305, 337, 369,  401, 433, 465, 497,
        529, 561, 593, 625,  657, 689, 721, 753,  785, 817, 849, 881,  913, 945, 977, 1009, 18,  50,  82,  114,
        146, 178, 210, 242,  274, 306, 338, 370,  402, 434, 466, 498,  530, 562, 594, 626,  658, 690, 722, 754,
        786, 818, 850, 882,  914, 946, 978, 1010, 19,  51,  83,  115,  147, 179, 211, 243,  275, 307, 339, 371,
        403, 435, 467, 499,  531, 563, 595, 627,  659, 691, 723, 755,  787, 819, 851, 883,  915, 947, 979, 1011,
        20,  52,  84,  116,  148, 180, 212, 244,  276, 308, 340, 372,  404, 436, 468, 500,  532, 564, 596, 628,
        660, 692, 724, 756,  788, 820, 852, 884,  916, 948, 980, 1012, 21,  53,  85,  117,  149, 181, 213, 245,
        277, 309, 341, 373,  405, 437, 469, 501,  533, 565, 597, 629,  661, 693, 725, 757,  789, 821, 853, 885,
        917, 949, 981, 1013, 22,  54,  86,  118,  150, 182, 214, 246,  278, 310, 342, 374,  406, 438, 470, 502,
        534, 566, 598, 630,  662, 694, 726, 758,  790, 822, 854, 886,  918, 950, 982, 1014, 23,  55,  87,  119,
        151, 183, 215, 247,  279, 311, 343, 375,  407, 439, 471, 503,  535, 567, 599, 631,  663, 695, 727, 759,
        791, 823, 855, 887,  919, 951, 983, 1015, 24,  56,  88,  120,  152, 184, 216, 248,  280, 312, 344, 376,
        408, 440, 472, 504,  536, 568, 600, 632,  664, 696, 728, 760,  792, 824, 856, 888,  920, 952, 984, 1016,
        25,  57,  89,  121,  153, 185, 217, 249,  281, 313, 345, 377,  409, 441, 473, 505,  537, 569, 601, 633,
        665, 697, 729, 761,  793, 825, 857, 889,  921, 953, 985, 1017, 26,  58,  90,  122,  154, 186, 218, 250,
        282, 314, 346, 378,  410, 442, 474, 506,  538, 570, 602, 634,  666, 698, 730, 762,  794, 826, 858, 890,
        922, 954, 986, 1018, 27,  59,  91,  123,  155, 187, 219, 251,  283, 315, 347, 379,  411, 443, 475, 507,
        539, 571, 603, 635,  667, 699, 731, 763,  795, 827, 859, 891,  923, 955, 987, 1019, 28,  60,  92,  124,
        156, 188, 220, 252,  284, 316, 348, 380,  412, 444, 476, 508,  540, 572, 604, 636,  668, 700, 732, 764,
        796, 828, 860, 892,  924, 956, 988, 1020, 29,  61,  93,  125,  157, 189, 221, 253,  285, 317, 349, 381,
        413, 445, 477, 509,  541, 573, 605, 637,  669, 701, 733, 765,  797, 829, 861, 893,  925, 957, 989, 1021,
        30,  62,  94,  126,  158, 190, 222, 254,  286, 318, 350, 382,  414, 446, 478, 510,  542, 574, 606, 638,
        670, 702, 734, 766,  798, 830, 862, 894,  926, 958, 990, 1022, 31,  63,  95,  127,  159, 191, 223, 255,
        287, 319, 351, 383,  415, 447, 479, 511,  543, 575, 607, 639,  671, 703, 735, 767,  799, 831, 863, 895,
        927, 959, 991, 1023,];

    private static readonly short[] MatrixColumnScan4x8 = [
         0, 4, 8,  12, 16, 20, 24, 28, 1, 5, 9,  13, 17, 21, 25, 29,
        2, 6, 10, 14, 18, 22, 26, 30, 3, 7, 11, 15, 19, 23, 27, 31,];

    private static readonly short[] MatrixColumnScan8x4 = [
        0, 8,  16, 24, 1, 9,  17, 25, 2, 10, 18, 26, 3, 11, 19, 27,
        4, 12, 20, 28, 5, 13, 21, 29, 6, 14, 22, 30, 7, 15, 23, 31,];

    private static readonly short[] MatrixColumnScan8x16 = [
        0,   8,   16,  24,  32,  40,  48,  56,  64,  72,  80,  88,  96,  104, 112, 120, 1,   9,   17,  25,  33,  41,
        49,  57,  65,  73,  81,  89,  97,  105, 113, 121, 2,   10,  18,  26,  34,  42,  50,  58,  66,  74,  82,  90,
        98,  106, 114, 122, 3,   11,  19,  27,  35,  43,  51,  59,  67,  75,  83,  91,  99,  107, 115, 123, 4,   12,
        20,  28,  36,  44,  52,  60,  68,  76,  84,  92,  100, 108, 116, 124, 5,   13,  21,  29,  37,  45,  53,  61,
        69,  77,  85,  93,  101, 109, 117, 125, 6,   14,  22,  30,  38,  46,  54,  62,  70,  78,  86,  94,  102, 110,
        118, 126, 7,   15,  23,  31,  39,  47,  55,  63,  71,  79,  87,  95,  103, 111, 119, 127,];

    private static readonly short[] MatrixColumnScan16x8 = [
         0,   16,  32,  48,  64,  80,  96,  112, 1,   17,  33,  49,  65,  81,  97,  113, 2,   18,  34,  50,  66,  82,
        98,  114, 3,   19,  35,  51,  67,  83,  99,  115, 4,   20,  36,  52,  68,  84,  100, 116, 5,   21,  37,  53,
        69,  85,  101, 117, 6,   22,  38,  54,  70,  86,  102, 118, 7,   23,  39,  55,  71,  87,  103, 119, 8,   24,
        40,  56,  72,  88,  104, 120, 9,   25,  41,  57,  73,  89,  105, 121, 10,  26,  42,  58,  74,  90,  106, 122,
        11,  27,  43,  59,  75,  91,  107, 123, 12,  28,  44,  60,  76,  92,  108, 124, 13,  29,  45,  61,  77,  93,
        109, 125, 14,  30,  46,  62,  78,  94,  110, 126, 15,  31,  47,  63,  79,  95,  111, 127,];

    private static readonly short[] MatrixColumnScan16x32 = [
        0,   16,  32,  48,  64,  80,  96,  112, 128, 144, 160, 176, 192, 208, 224, 240, 256, 272, 288, 304, 320, 336, 352,
        368, 384, 400, 416, 432, 448, 464, 480, 496, 1,   17,  33,  49,  65,  81,  97,  113, 129, 145, 161, 177, 193, 209,
        225, 241, 257, 273, 289, 305, 321, 337, 353, 369, 385, 401, 417, 433, 449, 465, 481, 497, 2,   18,  34,  50,  66,
        82,  98,  114, 130, 146, 162, 178, 194, 210, 226, 242, 258, 274, 290, 306, 322, 338, 354, 370, 386, 402, 418, 434,
        450, 466, 482, 498, 3,   19,  35,  51,  67,  83,  99,  115, 131, 147, 163, 179, 195, 211, 227, 243, 259, 275, 291,
        307, 323, 339, 355, 371, 387, 403, 419, 435, 451, 467, 483, 499, 4,   20,  36,  52,  68,  84,  100, 116, 132, 148,
        164, 180, 196, 212, 228, 244, 260, 276, 292, 308, 324, 340, 356, 372, 388, 404, 420, 436, 452, 468, 484, 500, 5,
        21,  37,  53,  69,  85,  101, 117, 133, 149, 165, 181, 197, 213, 229, 245, 261, 277, 293, 309, 325, 341, 357, 373,
        389, 405, 421, 437, 453, 469, 485, 501, 6,   22,  38,  54,  70,  86,  102, 118, 134, 150, 166, 182, 198, 214, 230,
        246, 262, 278, 294, 310, 326, 342, 358, 374, 390, 406, 422, 438, 454, 470, 486, 502, 7,   23,  39,  55,  71,  87,
        103, 119, 135, 151, 167, 183, 199, 215, 231, 247, 263, 279, 295, 311, 327, 343, 359, 375, 391, 407, 423, 439, 455,
        471, 487, 503, 8,   24,  40,  56,  72,  88,  104, 120, 136, 152, 168, 184, 200, 216, 232, 248, 264, 280, 296, 312,
        328, 344, 360, 376, 392, 408, 424, 440, 456, 472, 488, 504, 9,   25,  41,  57,  73,  89,  105, 121, 137, 153, 169,
        185, 201, 217, 233, 249, 265, 281, 297, 313, 329, 345, 361, 377, 393, 409, 425, 441, 457, 473, 489, 505, 10,  26,
        42,  58,  74,  90,  106, 122, 138, 154, 170, 186, 202, 218, 234, 250, 266, 282, 298, 314, 330, 346, 362, 378, 394,
        410, 426, 442, 458, 474, 490, 506, 11,  27,  43,  59,  75,  91,  107, 123, 139, 155, 171, 187, 203, 219, 235, 251,
        267, 283, 299, 315, 331, 347, 363, 379, 395, 411, 427, 443, 459, 475, 491, 507, 12,  28,  44,  60,  76,  92,  108,
        124, 140, 156, 172, 188, 204, 220, 236, 252, 268, 284, 300, 316, 332, 348, 364, 380, 396, 412, 428, 444, 460, 476,
        492, 508, 13,  29,  45,  61,  77,  93,  109, 125, 141, 157, 173, 189, 205, 221, 237, 253, 269, 285, 301, 317, 333,
        349, 365, 381, 397, 413, 429, 445, 461, 477, 493, 509, 14,  30,  46,  62,  78,  94,  110, 126, 142, 158, 174, 190,
        206, 222, 238, 254, 270, 286, 302, 318, 334, 350, 366, 382, 398, 414, 430, 446, 462, 478, 494, 510, 15,  31,  47,
        63,  79,  95,  111, 127, 143, 159,];

    private static readonly short[] MatrixColumnScan32x16 = [
        0,   32,  64,  96,  128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, 480, 1,   33,  65,  97,  129, 161, 193,
        225, 257, 289, 321, 353, 385, 417, 449, 481, 2,   34,  66,  98,  130, 162, 194, 226, 258, 290, 322, 354, 386, 418,
        450, 482, 3,   35,  67,  99,  131, 163, 195, 227, 259, 291, 323, 355, 387, 419, 451, 483, 4,   36,  68,  100, 132,
        164, 196, 228, 260, 292, 324, 356, 388, 420, 452, 484, 5,   37,  69,  101, 133, 165, 197, 229, 261, 293, 325, 357,
        389, 421, 453, 485, 6,   38,  70,  102, 134, 166, 198, 230, 262, 294, 326, 358, 390, 422, 454, 486, 7,   39,  71,
        103, 135, 167, 199, 231, 263, 295, 327, 359, 391, 423, 455, 487, 8,   40,  72,  104, 136, 168, 200, 232, 264, 296,
        328, 360, 392, 424, 456, 488, 9,   41,  73,  105, 137, 169, 201, 233, 265, 297, 329, 361, 393, 425, 457, 489, 10,
        42,  74,  106, 138, 170, 202, 234, 266, 298, 330, 362, 394, 426, 458, 490, 11,  43,  75,  107, 139, 171, 203, 235,
        267, 299, 331, 363, 395, 427, 459, 491, 12,  44,  76,  108, 140, 172, 204, 236, 268, 300, 332, 364, 396, 428, 460,
        492, 13,  45,  77,  109, 141, 173, 205, 237, 269, 301, 333, 365, 397, 429, 461, 493, 14,  46,  78,  110, 142, 174,
        206, 238, 270, 302, 334, 366, 398, 430, 462, 494, 15,  47,  79,  111, 143, 175, 207, 239, 271, 303, 335, 367, 399,
        431, 463, 495, 16,  48,  80,  112, 144, 176, 208, 240, 272, 304, 336, 368, 400, 432, 464, 496, 17,  49,  81,  113,
        145, 177, 209, 241, 273, 305, 337, 369, 401, 433, 465, 497, 18,  50,  82,  114, 146, 178, 210, 242, 274, 306, 338,
        370, 402, 434, 466, 498, 19,  51,  83,  115, 147, 179, 211, 243, 275, 307, 339, 371, 403, 435, 467, 499, 20,  52,
        84,  116, 148, 180, 212, 244, 276, 308, 340, 372, 404, 436, 468, 500, 21,  53,  85,  117, 149, 181, 213, 245, 277,
        309, 341, 373, 405, 437, 469, 501, 22,  54,  86,  118, 150, 182, 214, 246, 278, 310, 342, 374, 406, 438, 470, 502,
        23,  55,  87,  119, 151, 183, 215, 247, 279, 311, 343, 375, 407, 439, 471, 503, 24,  56,  88,  120, 152, 184, 216,
        248, 280, 312, 344, 376, 408, 440, 472, 504, 25,  57,  89,  121, 153, 185, 217, 249, 281, 313, 345, 377, 409, 441,
        473, 505, 26,  58,  90,  122, 154, 186, 218, 250, 282, 314, 346, 378, 410, 442, 474, 506, 27,  59,  91,  123, 155,
        187, 219, 251, 283, 315, 347, 379, 411, 443, 475, 507, 28,  60,  92,  124, 156, 188, 220, 252, 284, 316, 348, 380,
        412, 444, 476, 508, 29,  61,  93,  125, 157, 189, 221, 253, 285, 317, 349, 381, 413, 445, 477, 509, 30,  62,  94,
        126, 158, 190, 222, 254, 286, 318, 350, 382, 414, 446, 478, 510, 31,  63,  95,  127, 159, 191, 223, 255, 287, 319,
        351, 383, 415, 447, 479, 511,];

    private static readonly short[] MatrixColumnScan4x16 = [
        0,  4,  8,  12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 1,  5,  9,  13, 17, 21,
        25, 29, 33, 37, 41, 45, 49, 53, 57, 61, 2,  6,  10, 14, 18, 22, 26, 30, 34, 38, 42, 46,
        50, 54, 58, 62, 3,  7,  11, 15, 19, 23, 27, 31, 35, 39, 43, 47, 51, 55, 59, 63,];

    private static readonly short[] MatrixColumnScan16x4 = [
        0,  16, 32, 48, 1,  17, 33, 49, 2,  18, 34, 50, 3,  19, 35, 51, 4,  20, 36, 52, 5,  21,
        37, 53, 6,  22, 38, 54, 7,  23, 39, 55, 8,  24, 40, 56, 9,  25, 41, 57, 10, 26, 42, 58,
        11, 27, 43, 59, 12, 28, 44, 60, 13, 29, 45, 61, 14, 30, 46, 62, 15, 31, 47, 63,];

    private static readonly short[] MatrixColumnScan8x32 = [
        0,   8,   16,  24,  32,  40,  48,  56,  64,  72,  80,  88,  96,  104, 112, 120, 128, 136, 144, 152, 160, 168,
        176, 184, 192, 200, 208, 216, 224, 232, 240, 248, 1,   9,   17,  25,  33,  41,  49,  57,  65,  73,  81,  89,
        97,  105, 113, 121, 129, 137, 145, 153, 161, 169, 177, 185, 193, 201, 209, 217, 225, 233, 241, 249, 2,   10,
        18,  26,  34,  42,  50,  58,  66,  74,  82,  90,  98,  106, 114, 122, 130, 138, 146, 154, 162, 170, 178, 186,
        194, 202, 210, 218, 226, 234, 242, 250, 3,   11,  19,  27,  35,  43,  51,  59,  67,  75,  83,  91,  99,  107,
        115, 123, 131, 139, 147, 155, 163, 171, 179, 187, 195, 203, 211, 219, 227, 235, 243, 251, 4,   12,  20,  28,
        36,  44,  52,  60,  68,  76,  84,  92,  100, 108, 116, 124, 132, 140, 148, 156, 164, 172, 180, 188, 196, 204,
        212, 220, 228, 236, 244, 252, 5,   13,  21,  29,  37,  45,  53,  61,  69,  77,  85,  93,  101, 109, 117, 125,
        133, 141, 149, 157, 165, 173, 181, 189, 197, 205, 213, 221, 229, 237, 245, 253, 6,   14,  22,  30,  38,  46,
        54,  62,  70,  78,  86,  94,  102, 110, 118, 126, 134, 142, 150, 158, 166, 174, 182, 190, 198, 206, 214, 222,
        230, 238, 246, 254, 7,   15,  23,  31,  39,  47,  55,  63,  71,  79,  87,  95,  103, 111, 119, 127, 135, 143,
        151, 159, 167, 175, 183, 191, 199, 207, 215, 223, 231, 239, 247, 255,];

    private static readonly short[] MatrixColumnScan32x8 = [
        0,  32, 64, 96,  128, 160, 192, 224, 1,  33, 65, 97,  129, 161, 193, 225, 2,  34, 66, 98,  130, 162, 194, 226,
        3,  35, 67, 99,  131, 163, 195, 227, 4,  36, 68, 100, 132, 164, 196, 228, 5,  37, 69, 101, 133, 165, 197, 229,
        6,  38, 70, 102, 134, 166, 198, 230, 7,  39, 71, 103, 135, 167, 199, 231, 8,  40, 72, 104, 136, 168, 200, 232,
        9,  41, 73, 105, 137, 169, 201, 233, 10, 42, 74, 106, 138, 170, 202, 234, 11, 43, 75, 107, 139, 171, 203, 235,
        12, 44, 76, 108, 140, 172, 204, 236, 13, 45, 77, 109, 141, 173, 205, 237, 14, 46, 78, 110, 142, 174, 206, 238,
        15, 47, 79, 111, 143, 175, 207, 239, 16, 48, 80, 112, 144, 176, 208, 240, 17, 49, 81, 113, 145, 177, 209, 241,
        18, 50, 82, 114, 146, 178, 210, 242, 19, 51, 83, 115, 147, 179, 211, 243, 20, 52, 84, 116, 148, 180, 212, 244,
        21, 53, 85, 117, 149, 181, 213, 245, 22, 54, 86, 118, 150, 182, 214, 246, 23, 55, 87, 119, 151, 183, 215, 247,
        24, 56, 88, 120, 152, 184, 216, 248, 25, 57, 89, 121, 153, 185, 217, 249, 26, 58, 90, 122, 154, 186, 218, 250,
        27, 59, 91, 123, 155, 187, 219, 251, 28, 60, 92, 124, 156, 188, 220, 252, 29, 61, 93, 125, 157, 189, 221, 253,
        30, 62, 94, 126, 158, 190, 222, 254, 31, 63, 95, 127, 159, 191, 223, 255,];

    private static readonly short[] MatrixRowScan4x4 = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
    private static readonly short[] MatrixRowScan8x8 = [
        0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
        22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43,
        44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63];

    private static readonly short[] MatrixRowScan16x16 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,
        22,  23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,
        44,  45,  46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,
        66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,
        88,  89,  90,  91,  92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
        110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131,
        132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153,
        154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175,
        176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197,
        198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
        220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241,
        242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255,];

    private static readonly short[] MatrixRowScan32x32 = [
        0,    1,    2,    3,    4,    5,    6,    7,    8,    9,    10,   11,   12,   13,   14,   15,   16,   17,   18,
        19,   20,   21,   22,   23,   24,   25,   26,   27,   28,   29,   30,   31,   32,   33,   34,   35,   36,   37,
        38,   39,   40,   41,   42,   43,   44,   45,   46,   47,   48,   49,   50,   51,   52,   53,   54,   55,   56,
        57,   58,   59,   60,   61,   62,   63,   64,   65,   66,   67,   68,   69,   70,   71,   72,   73,   74,   75,
        76,   77,   78,   79,   80,   81,   82,   83,   84,   85,   86,   87,   88,   89,   90,   91,   92,   93,   94,
        95,   96,   97,   98,   99,   100,  101,  102,  103,  104,  105,  106,  107,  108,  109,  110,  111,  112,  113,
        114,  115,  116,  117,  118,  119,  120,  121,  122,  123,  124,  125,  126,  127,  128,  129,  130,  131,  132,
        133,  134,  135,  136,  137,  138,  139,  140,  141,  142,  143,  144,  145,  146,  147,  148,  149,  150,  151,
        152,  153,  154,  155,  156,  157,  158,  159,  160,  161,  162,  163,  164,  165,  166,  167,  168,  169,  170,
        171,  172,  173,  174,  175,  176,  177,  178,  179,  180,  181,  182,  183,  184,  185,  186,  187,  188,  189,
        190,  191,  192,  193,  194,  195,  196,  197,  198,  199,  200,  201,  202,  203,  204,  205,  206,  207,  208,
        209,  210,  211,  212,  213,  214,  215,  216,  217,  218,  219,  220,  221,  222,  223,  224,  225,  226,  227,
        228,  229,  230,  231,  232,  233,  234,  235,  236,  237,  238,  239,  240,  241,  242,  243,  244,  245,  246,
        247,  248,  249,  250,  251,  252,  253,  254,  255,  256,  257,  258,  259,  260,  261,  262,  263,  264,  265,
        266,  267,  268,  269,  270,  271,  272,  273,  274,  275,  276,  277,  278,  279,  280,  281,  282,  283,  284,
        285,  286,  287,  288,  289,  290,  291,  292,  293,  294,  295,  296,  297,  298,  299,  300,  301,  302,  303,
        304,  305,  306,  307,  308,  309,  310,  311,  312,  313,  314,  315,  316,  317,  318,  319,  320,  321,  322,
        323,  324,  325,  326,  327,  328,  329,  330,  331,  332,  333,  334,  335,  336,  337,  338,  339,  340,  341,
        342,  343,  344,  345,  346,  347,  348,  349,  350,  351,  352,  353,  354,  355,  356,  357,  358,  359,  360,
        361,  362,  363,  364,  365,  366,  367,  368,  369,  370,  371,  372,  373,  374,  375,  376,  377,  378,  379,
        380,  381,  382,  383,  384,  385,  386,  387,  388,  389,  390,  391,  392,  393,  394,  395,  396,  397,  398,
        399,  400,  401,  402,  403,  404,  405,  406,  407,  408,  409,  410,  411,  412,  413,  414,  415,  416,  417,
        418,  419,  420,  421,  422,  423,  424,  425,  426,  427,  428,  429,  430,  431,  432,  433,  434,  435,  436,
        437,  438,  439,  440,  441,  442,  443,  444,  445,  446,  447,  448,  449,  450,  451,  452,  453,  454,  455,
        456,  457,  458,  459,  460,  461,  462,  463,  464,  465,  466,  467,  468,  469,  470,  471,  472,  473,  474,
        475,  476,  477,  478,  479,  480,  481,  482,  483,  484,  485,  486,  487,  488,  489,  490,  491,  492,  493,
        494,  495,  496,  497,  498,  499,  500,  501,  502,  503,  504,  505,  506,  507,  508,  509,  510,  511,  512,
        513,  514,  515,  516,  517,  518,  519,  520,  521,  522,  523,  524,  525,  526,  527,  528,  529,  530,  531,
        532,  533,  534,  535,  536,  537,  538,  539,  540,  541,  542,  543,  544,  545,  546,  547,  548,  549,  550,
        551,  552,  553,  554,  555,  556,  557,  558,  559,  560,  561,  562,  563,  564,  565,  566,  567,  568,  569,
        570,  571,  572,  573,  574,  575,  576,  577,  578,  579,  580,  581,  582,  583,  584,  585,  586,  587,  588,
        589,  590,  591,  592,  593,  594,  595,  596,  597,  598,  599,  600,  601,  602,  603,  604,  605,  606,  607,
        608,  609,  610,  611,  612,  613,  614,  615,  616,  617,  618,  619,  620,  621,  622,  623,  624,  625,  626,
        627,  628,  629,  630,  631,  632,  633,  634,  635,  636,  637,  638,  639,  640,  641,  642,  643,  644,  645,
        646,  647,  648,  649,  650,  651,  652,  653,  654,  655,  656,  657,  658,  659,  660,  661,  662,  663,  664,
        665,  666,  667,  668,  669,  670,  671,  672,  673,  674,  675,  676,  677,  678,  679,  680,  681,  682,  683,
        684,  685,  686,  687,  688,  689,  690,  691,  692,  693,  694,  695,  696,  697,  698,  699,  700,  701,  702,
        703,  704,  705,  706,  707,  708,  709,  710,  711,  712,  713,  714,  715,  716,  717,  718,  719,  720,  721,
        722,  723,  724,  725,  726,  727,  728,  729,  730,  731,  732,  733,  734,  735,  736,  737,  738,  739,  740,
        741,  742,  743,  744,  745,  746,  747,  748,  749,  750,  751,  752,  753,  754,  755,  756,  757,  758,  759,
        760,  761,  762,  763,  764,  765,  766,  767,  768,  769,  770,  771,  772,  773,  774,  775,  776,  777,  778,
        779,  780,  781,  782,  783,  784,  785,  786,  787,  788,  789,  790,  791,  792,  793,  794,  795,  796,  797,
        798,  799,  800,  801,  802,  803,  804,  805,  806,  807,  808,  809,  810,  811,  812,  813,  814,  815,  816,
        817,  818,  819,  820,  821,  822,  823,  824,  825,  826,  827,  828,  829,  830,  831,  832,  833,  834,  835,
        836,  837,  838,  839,  840,  841,  842,  843,  844,  845,  846,  847,  848,  849,  850,  851,  852,  853,  854,
        855,  856,  857,  858,  859,  860,  861,  862,  863,  864,  865,  866,  867,  868,  869,  870,  871,  872,  873,
        874,  875,  876,  877,  878,  879,  880,  881,  882,  883,  884,  885,  886,  887,  888,  889,  890,  891,  892,
        893,  894,  895,  896,  897,  898,  899,  900,  901,  902,  903,  904,  905,  906,  907,  908,  909,  910,  911,
        912,  913,  914,  915,  916,  917,  918,  919,  920,  921,  922,  923,  924,  925,  926,  927,  928,  929,  930,
        931,  932,  933,  934,  935,  936,  937,  938,  939,  940,  941,  942,  943,  944,  945,  946,  947,  948,  949,
        950,  951,  952,  953,  954,  955,  956,  957,  958,  959,  960,  961,  962,  963,  964,  965,  966,  967,  968,
        969,  970,  971,  972,  973,  974,  975,  976,  977,  978,  979,  980,  981,  982,  983,  984,  985,  986,  987,
        988,  989,  990,  991,  992,  993,  994,  995,  996,  997,  998,  999,  1000, 1001, 1002, 1003, 1004, 1005, 1006,
        1007, 1008, 1009, 1010, 1011, 1012, 1013, 1014, 1015, 1016, 1017, 1018, 1019, 1020, 1021, 1022, 1023,];

    private static readonly short[] MatrixRowScan4x8 = [
        0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15,
        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,];

    private static readonly short[] MatrixRowScan8x4 = [
        0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15,
        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,];

    private static readonly short[] MatrixRowScan8x16 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,
        22,  23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,
        44,  45,  46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,
        66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,
        88,  89,  90,  91,  92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
        110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,];

    private static readonly short[] MatrixRowScan16x8 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,
        22,  23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,
        44,  45,  46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,
        66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,
        88,  89,  90,  91,  92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
        110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,];

    private static readonly short[] MatrixRowScan16x32 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,  22,
        23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,  44,  45,
        46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,  66,  67,  68,
        69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,  88,  89,  90,  91,
        92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114,
        115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137,
        138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160,
        161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183,
        184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206,
        207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
        230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252,
        253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275,
        276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298,
        299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 315, 316, 317, 318, 319, 320, 321,
        322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 333, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344,
        345, 346, 347, 348, 349, 350, 351, 352, 353, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 366, 367,
        368, 369, 370, 371, 372, 373, 374, 375, 376, 377, 378, 379, 380, 381, 382, 383, 384, 385, 386, 387, 388, 389, 390,
        391, 392, 393, 394, 395, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413,
        414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 428, 429, 430, 431, 432, 433, 434, 435, 436,
        437, 438, 439, 440, 441, 442, 443, 444, 445, 446, 447, 448, 449, 450, 451, 452, 453, 454, 455, 456, 457, 458, 459,
        460, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471, 472, 473, 474, 475, 476, 477, 478, 479, 480, 481, 482,
        483, 484, 485, 486, 487, 488, 489, 490, 491, 492, 493, 494, 495, 496, 497, 498, 499, 500, 501, 502, 503, 504, 505,
        506, 507, 508, 509, 510, 511,];

    private static readonly short[] MatrixRowScan32x16 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,  22,
        23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,  44,  45,
        46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,  66,  67,  68,
        69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,  88,  89,  90,  91,
        92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114,
        115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137,
        138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160,
        161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183,
        184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206,
        207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
        230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252,
        253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275,
        276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298,
        299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 315, 316, 317, 318, 319, 320, 321,
        322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 333, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344,
        345, 346, 347, 348, 349, 350, 351, 352, 353, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 366, 367,
        368, 369, 370, 371, 372, 373, 374, 375, 376, 377, 378, 379, 380, 381, 382, 383, 384, 385, 386, 387, 388, 389, 390,
        391, 392, 393, 394, 395, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413,
        414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 428, 429, 430, 431, 432, 433, 434, 435, 436,
        437, 438, 439, 440, 441, 442, 443, 444, 445, 446, 447, 448, 449, 450, 451, 452, 453, 454, 455, 456, 457, 458, 459,
        460, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471, 472, 473, 474, 475, 476, 477, 478, 479, 480, 481, 482,
        483, 484, 485, 486, 487, 488, 489, 490, 491, 492, 493, 494, 495, 496, 497, 498, 499, 500, 501, 502, 503, 504, 505,
        506, 507, 508, 509, 510, 511,];

    private static readonly short[] MatrixRowScan4x16 = [
        0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
        22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43,
        44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,];

    private static readonly short[] MatrixRowScan16x4 = [
        0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
        22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43,
        44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,];

    private static readonly short[] MatrixRowScan8x32 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,
        22,  23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,
        44,  45,  46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,
        66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,
        88,  89,  90,  91,  92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
        110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131,
        132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153,
        154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175,
        176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197,
        198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
        220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241,
        242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255,];

    private static readonly short[] MatrixRowScan32x8 = [
        0,   1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  13,  14,  15,  16,  17,  18,  19,  20,  21,
        22,  23,  24,  25,  26,  27,  28,  29,  30,  31,  32,  33,  34,  35,  36,  37,  38,  39,  40,  41,  42,  43,
        44,  45,  46,  47,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,  63,  64,  65,
        66,  67,  68,  69,  70,  71,  72,  73,  74,  75,  76,  77,  78,  79,  80,  81,  82,  83,  84,  85,  86,  87,
        88,  89,  90,  91,  92,  93,  94,  95,  96,  97,  98,  99,  100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
        110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131,
        132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153,
        154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175,
        176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197,
        198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
        220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241,
        242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255,];

    // IScan is not used (yet) for AVIF coding, leave these arrays empty for now.
    private static readonly short[] DefaultIScan4x4 = [];
    private static readonly short[] DefaultIScan8x8 = [];
    private static readonly short[] DefaultIScan16x16 = [];
    private static readonly short[] DefaultIScan32x32 = [];
    private static readonly short[] DefaultIScan64x64 = [];
    private static readonly short[] DefaultIScan4x8 = [];
    private static readonly short[] DefaultIScan8x4 = [];
    private static readonly short[] DefaultIScan8x16 = [];
    private static readonly short[] DefaultIScan16x8 = [];
    private static readonly short[] DefaultIScan16x32 = [];
    private static readonly short[] DefaultIScan32x16 = [];
    private static readonly short[] DefaultIScan4x16 = [];
    private static readonly short[] DefaultIScan16x4 = [];
    private static readonly short[] DefaultIScan8x32 = [];
    private static readonly short[] DefaultIScan32x8 = [];

    private static readonly short[] MatrixColumnIScan4x4 = [];
    private static readonly short[] MatrixColumnIScan8x8 = [];
    private static readonly short[] MatrixColumnIScan16x16 = [];
    private static readonly short[] MatrixColumnIScan32x32 = [];
    private static readonly short[] MatrixColumnIScan64x64 = [];
    private static readonly short[] MatrixColumnIScan4x8 = [];
    private static readonly short[] MatrixColumnIScan8x4 = [];
    private static readonly short[] MatrixColumnIScan8x16 = [];
    private static readonly short[] MatrixColumnIScan16x8 = [];
    private static readonly short[] MatrixColumnIScan16x32 = [];
    private static readonly short[] MatrixColumnIScan32x16 = [];
    private static readonly short[] MatrixColumnIScan4x16 = [];
    private static readonly short[] MatrixColumnIScan16x4 = [];
    private static readonly short[] MatrixColumnIScan8x32 = [];
    private static readonly short[] MatrixColumnIScan32x8 = [];

    private static readonly short[] MatrixRowIScan4x4 = [];
    private static readonly short[] MatrixRowIScan8x8 = [];
    private static readonly short[] MatrixRowIScan16x16 = [];
    private static readonly short[] MatrixRowIScan32x32 = [];
    private static readonly short[] MatrixRowIScan64x64 = [];
    private static readonly short[] MatrixRowIScan4x8 = [];
    private static readonly short[] MatrixRowIScan8x4 = [];
    private static readonly short[] MatrixRowIScan8x16 = [];
    private static readonly short[] MatrixRowIScan16x8 = [];
    private static readonly short[] MatrixRowIScan16x32 = [];
    private static readonly short[] MatrixRowIScan32x16 = [];
    private static readonly short[] MatrixRowIScan4x16 = [];
    private static readonly short[] MatrixRowIScan16x4 = [];
    private static readonly short[] MatrixRowIScan8x32 = [];
    private static readonly short[] MatrixRowIScan32x8 = [];

    // Neighborss are not used (yet) for AVIF coding, leave these arrays empty for now.
    private static readonly short[] DefaultScan4x4Neighbors = [];
    private static readonly short[] DefaultScan8x8Neighbors = [];
    private static readonly short[] DefaultScan16x16Neighbors = [];
    private static readonly short[] DefaultScan32x32Neighbors = [];
    private static readonly short[] DefaultScan64x64Neighbors = [];
    private static readonly short[] DefaultScan4x8Neighbors = [];
    private static readonly short[] DefaultScan8x4Neighbors = [];
    private static readonly short[] DefaultScan8x16Neighbors = [];
    private static readonly short[] DefaultScan16x8Neighbors = [];
    private static readonly short[] DefaultScan16x32Neighbors = [];
    private static readonly short[] DefaultScan32x16Neighbors = [];
    private static readonly short[] DefaultScan4x16Neighbors = [];
    private static readonly short[] DefaultScan16x4Neighbors = [];
    private static readonly short[] DefaultScan8x32Neighbors = [];
    private static readonly short[] DefaultScan32x8Neighbors = [];

    private static readonly short[] MatrixColumnScan4x4Neighbors = [];
    private static readonly short[] MatrixColumnScan8x8Neighbors = [];
    private static readonly short[] MatrixColumnScan16x16Neighbors = [];
    private static readonly short[] MatrixColumnScan32x32Neighbors = [];
    private static readonly short[] MatrixColumnScan64x64Neighbors = [];
    private static readonly short[] MatrixColumnScan4x8Neighbors = [];
    private static readonly short[] MatrixColumnScan8x4Neighbors = [];
    private static readonly short[] MatrixColumnScan8x16Neighbors = [];
    private static readonly short[] MatrixColumnScan16x8Neighbors = [];
    private static readonly short[] MatrixColumnScan16x32Neighbors = [];
    private static readonly short[] MatrixColumnScan32x16Neighbors = [];
    private static readonly short[] MatrixColumnScan4x16Neighbors = [];
    private static readonly short[] MatrixColumnScan16x4Neighbors = [];
    private static readonly short[] MatrixColumnScan8x32Neighbors = [];
    private static readonly short[] MatrixColumnScan32x8Neighbors = [];

    private static readonly short[] MatrixRowScan4x4Neighbors = [];
    private static readonly short[] MatrixRowScan8x8Neighbors = [];
    private static readonly short[] MatrixRowScan16x16Neighbors = [];
    private static readonly short[] MatrixRowScan32x32Neighbors = [];
    private static readonly short[] MatrixRowScan64x64Neighbors = [];
    private static readonly short[] MatrixRowScan4x8Neighbors = [];
    private static readonly short[] MatrixRowScan8x4Neighbors = [];
    private static readonly short[] MatrixRowScan8x16Neighbors = [];
    private static readonly short[] MatrixRowScan16x8Neighbors = [];
    private static readonly short[] MatrixRowScan16x32Neighbors = [];
    private static readonly short[] MatrixRowScan32x16Neighbors = [];
    private static readonly short[] MatrixRowScan4x16Neighbors = [];
    private static readonly short[] MatrixRowScan16x4Neighbors = [];
    private static readonly short[] MatrixRowScan8x32Neighbors = [];
    private static readonly short[] MatrixRowScan32x8Neighbors = [];

    public static Av1ScanOrder GetScanOrder(Av1TransformSize transformSize, Av1TransformType transformType)
        => ScanOrders[(int)transformSize][(int)transformType];
}
