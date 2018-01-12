namespace OfaSchlupfer.ScriptDom {
    internal class IndexOptionHelper : OptionsHelper<IndexOptionKind> {
        internal static readonly IndexOptionHelper Instance = new IndexOptionHelper();

        private IndexOptionHelper() {
            base.AddOptionMapping(IndexOptionKind.PadIndex, "PAD_INDEX", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.FillFactor, TSqlTokenType.FillFactor, SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.SortInTempDB, "SORT_IN_TEMPDB", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.IgnoreDupKey, "IGNORE_DUP_KEY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.StatisticsNoRecompute, "STATISTICS_NORECOMPUTE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.DropExisting, "DROP_EXISTING", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.Online, "ONLINE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.AllowPageLocks, "ALLOW_PAGE_LOCKS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.AllowRowLocks, "ALLOW_ROW_LOCKS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.MaxDop, "MAXDOP", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.LobCompaction, "LOB_COMPACTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.FileStreamOn, "FILESTREAM_ON", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(IndexOptionKind.DataCompression, "DATA_COMPRESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(IndexOptionKind.BucketCount, "BUCKET_COUNT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(IndexOptionKind.StatisticsIncremental, "STATISTICS_INCREMENTAL", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(IndexOptionKind.Order, "ORDER", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.CompressAllRowGroups, "COMPRESS_ALL_ROW_GROUPS", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.CompressionDelay, "COMPRESSION_DELAY", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.Resumable, "RESUMABLE", SqlVersionFlags.TSql140);
            base.AddOptionMapping(IndexOptionKind.MaxDuration, "MAX_DURATION", SqlVersionFlags.TSql140);
            base.AddOptionMapping(IndexOptionKind.WaitAtLowPriority, "WAIT_AT_LOW_PRIORITY", SqlVersionFlags.TSql140);
        }
    }
}
