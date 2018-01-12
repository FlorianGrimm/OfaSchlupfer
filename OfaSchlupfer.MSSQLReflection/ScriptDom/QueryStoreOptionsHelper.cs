using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class QueryStoreOptionsHelper : OptionsHelper<QueryStoreOptionKind> {
        internal static readonly QueryStoreOptionsHelper Instance = new QueryStoreOptionsHelper();

        private QueryStoreOptionsHelper() {
            base.AddOptionMapping(QueryStoreOptionKind.Desired_State, "DESIRED_STATE");
            base.AddOptionMapping(QueryStoreOptionKind.Query_Capture_Mode, "QUERY_CAPTURE_MODE");
            base.AddOptionMapping(QueryStoreOptionKind.Size_Based_Cleanup_Mode, "SIZE_BASED_CLEANUP_MODE");
            base.AddOptionMapping(QueryStoreOptionKind.Flush_Interval_Seconds, "DATA_FLUSH_INTERVAL_SECONDS");
            base.AddOptionMapping(QueryStoreOptionKind.Interval_Length_Minutes, "INTERVAL_LENGTH_MINUTES");
            base.AddOptionMapping(QueryStoreOptionKind.Current_Storage_Size_MB, "MAX_STORAGE_SIZE_MB");
            base.AddOptionMapping(QueryStoreOptionKind.Max_Plans_Per_Query, "MAX_PLANS_PER_QUERY");
            base.AddOptionMapping(QueryStoreOptionKind.Stale_Query_Threshold_Days, "CLEANUP_POLICY");
        }
    }
}
