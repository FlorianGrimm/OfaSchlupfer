using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class QueryStoreDesiredStateHelper : OptionsHelper<QueryStoreDesiredStateOptionKind> {
        internal static readonly QueryStoreDesiredStateHelper Instance = new QueryStoreDesiredStateHelper();

        private QueryStoreDesiredStateHelper() {
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.Off, "OFF");
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.ReadWrite, "READ_WRITE");
        }
    }
}
