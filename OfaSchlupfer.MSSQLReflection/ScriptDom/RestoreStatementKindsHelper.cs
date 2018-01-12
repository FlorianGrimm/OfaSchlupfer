using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RestoreStatementKindsHelper : OptionsHelper<RestoreStatementKind> {
        internal static readonly RestoreStatementKindsHelper Instance = new RestoreStatementKindsHelper();

        private RestoreStatementKindsHelper() {
            base.AddOptionMapping(RestoreStatementKind.FileListOnly, "FILELISTONLY");
            base.AddOptionMapping(RestoreStatementKind.VerifyOnly, "VERIFYONLY");
            base.AddOptionMapping(RestoreStatementKind.LabelOnly, "LABELONLY");
            base.AddOptionMapping(RestoreStatementKind.RewindOnly, "REWINDONLY");
            base.AddOptionMapping(RestoreStatementKind.HeaderOnly, "HEADERONLY");
        }
    }
}
