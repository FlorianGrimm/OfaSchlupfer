namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalFileFormatOptionKind {
        SerDeMethod,
        FormatOptions,
        FieldTerminator,
        StringDelimiter,
        DateFormat,
        UseTypeDefault,
        DataCompression
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalFileFormatType {
        DelimitedText,
        RcFile,
        Orc,
        Parquet
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalFileFormatUseDefaultType {
        False,
        True
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum ExternalResourcePoolAffinityType {
        None,
        Cpu,
        NumaNode
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum ExternalResourcePoolParameterType {
        Unknown,
        MaxCpuPercent,
        MaxMemoryPercent,
        MaxProcesses,
        Affinity
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalTableOptionKind {
        Distribution,
        FileFormat,
        Location,
        RejectSampleValue,
        RejectType,
        RejectValue,
        SchemaName,
        ObjectName
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalTableRejectType {
        Value,
        Percentage
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FailoverActionOptionKind {
        Target
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FailoverModeOptionKind {
        Automatic,
        Manual
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FetchOrientation {
        None,
        First,
        Next,
        Prior,
        Last,
        Relative,
        Absolute
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FileDeclarationOptionKind {
        Name,
        NewName,
        Offline,
        FileName,
        Size,
        MaxSize,
        FileGrowth
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FipsComplianceLevel {
        Off,
        Entry,
        Intermediate,
        Full
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom
{
	public enum FullTextCatalogOptionKind
	{
		AccentSensitivity
	}
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FullTextFunctionType {
        None,
        Contains,
        FreeText
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FullTextIndexOptionKind {
        ChangeTracking,
        StopList,
        SearchPropertyList
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum FunctionOptionKind {
        Encryption,
        SchemaBinding,
        ReturnsNullOnNullInput,
        CalledOnNullInput,
        ExecuteAs,
        NativeCompilation
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum GeneralSetCommandType {
        None,
        Language,
        DateFormat,
        DateFirst,
        DeadlockPriority,
        LockTimeout,
        QueryGovernorCostLimit,
        ContextInfo
    }
}
