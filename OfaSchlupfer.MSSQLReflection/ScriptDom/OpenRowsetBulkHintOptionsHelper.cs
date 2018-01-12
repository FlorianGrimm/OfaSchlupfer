namespace OfaSchlupfer.ScriptDom {
    internal class OpenRowsetBulkHintOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly OpenRowsetBulkHintOptionsHelper Instance = new OpenRowsetBulkHintOptionsHelper();

        private OpenRowsetBulkHintOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.SingleBlob, "SINGLE_BLOB");
            base.AddOptionMapping(BulkInsertOptionKind.SingleClob, "SINGLE_CLOB");
            base.AddOptionMapping(BulkInsertOptionKind.SingleNClob, "SINGLE_NCLOB");
        }
    }
}
