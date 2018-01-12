namespace OfaSchlupfer.ScriptDom {
    internal class BulkInsertIntOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertIntOptionsHelper Instance = new BulkInsertIntOptionsHelper();

        private BulkInsertIntOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.MaxErrors, "MAXERRORS");
            base.AddOptionMapping(BulkInsertOptionKind.FirstRow, "FIRSTROW");
            base.AddOptionMapping(BulkInsertOptionKind.LastRow, "LASTROW");
            base.AddOptionMapping(BulkInsertOptionKind.BatchSize, "BATCHSIZE");
            base.AddOptionMapping(BulkInsertOptionKind.CodePage, "CODEPAGE");
            base.AddOptionMapping(BulkInsertOptionKind.RowsPerBatch, "ROWS_PER_BATCH");
            base.AddOptionMapping(BulkInsertOptionKind.KilobytesPerBatch, "KILOBYTES_PER_BATCH");
        }
    }
}
