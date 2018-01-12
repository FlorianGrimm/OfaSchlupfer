namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum GeneratedAlwaysType {
        RowStart,
        RowEnd,
        UserIdStart,
        UserIdEnd,
        UserNameStart,
        UserNameEnd
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum GridParameterType {
        None,
        Level1,
        Level2,
        Level3,
        Level4
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum GroupByOption {
        None,
        Cube,
        Rollup
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum HadrDatabaseOptionKind {
        Suspend,
        Resume,
        Off,
        AvailabilityGroup
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum ImportanceParameterType {
        Unknown,
        Low,
        Medium,
        High
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum IndexOptionKind {
        PadIndex,
        FillFactor,
        SortInTempDB,
        IgnoreDupKey,
        StatisticsNoRecompute,
        DropExisting,
        Online,
        AllowRowLocks,
        AllowPageLocks,
        MaxDop,
        LobCompaction,
        FileStreamOn,
        DataCompression,
        MoveTo,
        BucketCount,
        StatisticsIncremental,
        Order,
        CompressAllRowGroups,
        CompressionDelay,
        Resumable,
        MaxDuration,
        WaitAtLowPriority
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum IndexTypeKind {
        Clustered,
        NonClustered,
        NonClusteredHash,
        ClusteredColumnStore,
        NonClusteredColumnStore
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum InsertOption {
        None,
        Into,
        Over
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum IsolationLevel {
        None,
        ReadCommitted,
        ReadUncommitted,
        RepeatableRead,
        Serializable,
        Snapshot
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum JoinHint {
        None,
        Loop,
        Hash,
        Merge,
        Remote
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    [Flags]
    public enum JsonForClauseOptions {
        None = 0,
        Auto = 1,
        Path = 2,
        Root = 4,
        IncludeNullValues = 8,
        WithoutArrayWrapper = 0x10
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum KeyOptionKind {
        KeySource,
        Algorithm,
        IdentityValue,
        ProviderKeyName,
        CreationDisposition
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum KeywordCasing {
        Lowercase,
        Uppercase,
        PascalCase
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum LiteralType {
        Integer,
        Real,
        Money,
        Binary,
        String,
        Null,
        Default,
        Max,
        Odbc,
        Identifier,
        Numeric
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum LockEscalationMethod {
        Table,
        Auto,
        Disable
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum LowPriorityLockWaitOptionKind {
        MaxDuration,
        AbortAfterWait
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum MemoryUnit {
        Unspecified,
        Percent,
        Bytes,
        KB,
        MB,
        GB,
        TB,
        PB,
        EB
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum MergeCondition {
        NotSpecified,
        Matched,
        NotMatched,
        NotMatchedByTarget,
        NotMatchedBySource
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum MessageSender {
        None,
        Initiator,
        Target,
        Any
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum MessageValidationMethod {
        NotSpecified,
        None,
        Empty,
        WellFormedXml,
        ValidXml
    }
}
