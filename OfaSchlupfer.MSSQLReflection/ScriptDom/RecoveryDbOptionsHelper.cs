using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RecoveryDbOptionsHelper : OptionsHelper<RecoveryDatabaseOptionKind> {
        internal static readonly RecoveryDbOptionsHelper Instance = new RecoveryDbOptionsHelper();

        private RecoveryDbOptionsHelper() {
            base.AddOptionMapping(RecoveryDatabaseOptionKind.Full, "FULL");
            base.AddOptionMapping(RecoveryDatabaseOptionKind.BulkLogged, "BULK_LOGGED");
            base.AddOptionMapping(RecoveryDatabaseOptionKind.Simple, "SIMPLE");
        }
    }
}
