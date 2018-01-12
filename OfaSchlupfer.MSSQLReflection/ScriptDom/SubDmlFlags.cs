using System;

namespace OfaSchlupfer.ScriptDom {
    [Flags]
    internal enum SubDmlFlags {
        None = 0,
        InsideSubDml = 1,
        SelectNotForInsert = 2,
        MergeUsing = 4,
        UpdateDeleteFrom = 8
    }
}
