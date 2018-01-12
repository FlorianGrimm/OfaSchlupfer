using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum EventSessionEventRetentionModeType {
        Unknown,
        AllowSingleEventLoss,
        AllowMultipleEventLoss,
        NoEventLoss
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum EventSessionMemoryPartitionModeType {
        Unknown,
        None,
        PerNode,
        PerCpu
    }
}
using System;

namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    [System.Serializable]
    public enum EventSessionScope {
        Server,
        Database
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom
{
	public enum ExecuteAsOption
	{
		Caller,
		Self,
		Owner,
		String,
		Login,
		User
	}
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom
{
	public enum ExecuteOptionKind
	{
		Recompile,
		ResultSets
	}
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalDataSourceOptionKind {
        ResourceManagerLocation,
        Credential,
        DatabaseName,
        ShardMapName
    }
}
namespace OfaSchlupfer.MSSQLReflection.SqlCode.ScriptDom {
    public enum ExternalDataSourceType {
        HADOOP,
        RDBMS,
        SHARD_MAP_MANAGER,
        BLOB_STORAGE
    }
}
