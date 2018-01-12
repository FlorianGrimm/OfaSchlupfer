using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class QueryStoreCapturePolicyHelper : OptionsHelper<QueryStoreCapturePolicyOptionKind> {
        internal static readonly QueryStoreCapturePolicyHelper Instance = new QueryStoreCapturePolicyHelper();

        private QueryStoreCapturePolicyHelper() {
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.NONE, "NONE");
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.AUTO, "AUTO");
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.ALL, "ALL");
        }
    }
}
