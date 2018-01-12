using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class QueryStoreSizeCleanupPolicyHelper : OptionsHelper<QueryStoreSizeCleanupPolicyOptionKind> {
        internal static readonly QueryStoreSizeCleanupPolicyHelper Instance = new QueryStoreSizeCleanupPolicyHelper();

        private QueryStoreSizeCleanupPolicyHelper() {
            base.AddOptionMapping(QueryStoreSizeCleanupPolicyOptionKind.AUTO, "AUTO");
            base.AddOptionMapping(QueryStoreSizeCleanupPolicyOptionKind.OFF, "OFF");
        }
    }
}
