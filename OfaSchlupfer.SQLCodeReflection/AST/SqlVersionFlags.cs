using System;

namespace OfaSchlupfer.AST {
    [Flags]
    internal enum SqlVersionFlags {
        None = 0,
        TSql80 = 1,
        TSql90 = 2,
        TSql100 = 4,
        TSql110 = 8,
        TSql120 = 0x10,
        TSql130 = 0x20,
        TSql140 = 0x40,
        TSqlAll = 0x7F,
        TSql90AndAbove = 0x7E,
        TSql100AndAbove = 0x7C,
        TSql110AndAbove = 0x78,
        TSql120AndAbove = 0x70,
        TSql130AndAbove = 0x60,
        TSql140AndAbove = 0x40,
        TSqlUnder110 = 7,
        TSqlUnder120 = 0xF,
        TSqlUnder130 = 0x1F,
        TSqlUnder140 = 0x3F
    }
}
