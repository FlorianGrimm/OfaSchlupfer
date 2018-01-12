using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RestoreOptionWithValueHelper : OptionsHelper<RestoreOptionKind> {
        internal static readonly RestoreOptionWithValueHelper Instance = new RestoreOptionWithValueHelper();

        private RestoreOptionWithValueHelper() {
            base.AddOptionMapping(RestoreOptionKind.File, TSqlTokenType.File);
            base.AddOptionMapping(RestoreOptionKind.Stats, "STATS");
            base.AddOptionMapping(RestoreOptionKind.StopAt, "STOPAT");
            base.AddOptionMapping(RestoreOptionKind.MediaName, "MEDIANAME");
            base.AddOptionMapping(RestoreOptionKind.MediaPassword, "MEDIAPASSWORD");
            base.AddOptionMapping(RestoreOptionKind.Password, "PASSWORD");
            base.AddOptionMapping(RestoreOptionKind.BlockSize, "BLOCKSIZE");
            base.AddOptionMapping(RestoreOptionKind.BufferCount, "BUFFERCOUNT");
            base.AddOptionMapping(RestoreOptionKind.MaxTransferSize, "MAXTRANSFERSIZE");
            base.AddOptionMapping(RestoreOptionKind.Standby, "STANDBY");
            base.AddOptionMapping(RestoreOptionKind.EnhancedIntegrity, "ENHANCEDINTEGRITY");
            base.AddOptionMapping(RestoreOptionKind.SnapshotRestorePhase, "SNAPSHOTRESTOREPHASE");
        }
    }
}
