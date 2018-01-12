namespace OfaSchlupfer.ScriptDom {
    internal class BackupOptionsWithValueHelper : OptionsHelper<BackupOptionKind> {
        internal static readonly BackupOptionsWithValueHelper Instance = new BackupOptionsWithValueHelper();

        private BackupOptionsWithValueHelper() {
            base.AddOptionMapping(BackupOptionKind.Stats, "STATS");
            base.AddOptionMapping(BackupOptionKind.Standby, "STANDBY");
            base.AddOptionMapping(BackupOptionKind.ExpireDate, "EXPIREDATE");
            base.AddOptionMapping(BackupOptionKind.RetainDays, "RETAINDAYS");
            base.AddOptionMapping(BackupOptionKind.Name, "NAME");
            base.AddOptionMapping(BackupOptionKind.Description, "DESCRIPTION");
            base.AddOptionMapping(BackupOptionKind.Password, "PASSWORD", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(BackupOptionKind.MediaName, "MEDIANAME");
            base.AddOptionMapping(BackupOptionKind.MediaDescription, "MEDIADESCRIPTION");
            base.AddOptionMapping(BackupOptionKind.MediaPassword, "MEDIAPASSWORD", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(BackupOptionKind.BlockSize, "BLOCKSIZE");
            base.AddOptionMapping(BackupOptionKind.BufferCount, "BUFFERCOUNT");
            base.AddOptionMapping(BackupOptionKind.MaxTransferSize, "MAXTRANSFERSIZE");
            base.AddOptionMapping(BackupOptionKind.EnhancedIntegrity, "ENHANCEDINTEGRITY");
        }
    }
}
