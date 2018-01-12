namespace OfaSchlupfer.ScriptDom {
    internal class BulkInsertStringOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertStringOptionsHelper Instance = new BulkInsertStringOptionsHelper();

        private BulkInsertStringOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.FieldTerminator, "FIELDTERMINATOR");
            base.AddOptionMapping(BulkInsertOptionKind.RowTerminator, "ROWTERMINATOR");
            base.AddOptionMapping(BulkInsertOptionKind.FormatFile, "FORMATFILE");
            base.AddOptionMapping(BulkInsertOptionKind.ErrorFile, "ERRORFILE");
            base.AddOptionMapping(BulkInsertOptionKind.CodePage, "CODEPAGE");
            base.AddOptionMapping(BulkInsertOptionKind.DataFileType, "DATAFILETYPE");
            base.AddOptionMapping(BulkInsertOptionKind.DataSource, "DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.FormatDataSource, "FORMATFILE_DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.ErrorDataSource, "ERRORFILE_DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.DataFileFormat, "FORMAT", SqlVersionFlags.TSql140);
            base.AddOptionMapping(BulkInsertOptionKind.FieldQuote, "FIELDQUOTE", SqlVersionFlags.TSql140);
        }
    }
}
