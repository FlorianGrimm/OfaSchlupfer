namespace OfaSchlupfer.ScriptDom {
    internal class BackupOptionsNoValueHelper : OptionsHelper<BackupOptionKind> {
        internal static readonly BackupOptionsNoValueHelper Instance = new BackupOptionsNoValueHelper();

        private BackupOptionsNoValueHelper() {
            base.AddOptionMapping(BackupOptionKind.NoRecovery, "NORECOVERY");
            base.AddOptionMapping(BackupOptionKind.TruncateOnly, "TRUNCATE_ONLY");
            base.AddOptionMapping(BackupOptionKind.NoLog, "NO_LOG");
            base.AddOptionMapping(BackupOptionKind.NoTruncate, "NO_TRUNCATE");
            base.AddOptionMapping(BackupOptionKind.Unload, "UNLOAD");
            base.AddOptionMapping(BackupOptionKind.NoUnload, "NOUNLOAD");
            base.AddOptionMapping(BackupOptionKind.Rewind, "REWIND");
            base.AddOptionMapping(BackupOptionKind.NoRewind, "NOREWIND");
            base.AddOptionMapping(BackupOptionKind.Format, "FORMAT");
            base.AddOptionMapping(BackupOptionKind.NoFormat, "NOFORMAT");
            base.AddOptionMapping(BackupOptionKind.Init, "INIT");
            base.AddOptionMapping(BackupOptionKind.NoInit, "NOINIT");
            base.AddOptionMapping(BackupOptionKind.Skip, "SKIP");
            base.AddOptionMapping(BackupOptionKind.NoSkip, "NOSKIP");
            base.AddOptionMapping(BackupOptionKind.Restart, "RESTART");
            base.AddOptionMapping(BackupOptionKind.Stats, "STATS");
            base.AddOptionMapping(BackupOptionKind.Differential, "DIFFERENTIAL");
            base.AddOptionMapping(BackupOptionKind.Snapshot, "SNAPSHOT");
            base.AddOptionMapping(BackupOptionKind.Checksum, "CHECKSUM");
            base.AddOptionMapping(BackupOptionKind.NoChecksum, "NO_CHECKSUM");
            base.AddOptionMapping(BackupOptionKind.ContinueAfterError, "CONTINUE_AFTER_ERROR");
            base.AddOptionMapping(BackupOptionKind.StopOnError, "STOP_ON_ERROR");
            base.AddOptionMapping(BackupOptionKind.CopyOnly, "COPY_ONLY");
            base.AddOptionMapping(BackupOptionKind.Compression, "COMPRESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(BackupOptionKind.NoCompression, "NO_COMPRESSION", SqlVersionFlags.TSql100AndAbove);
        }
    }
}
