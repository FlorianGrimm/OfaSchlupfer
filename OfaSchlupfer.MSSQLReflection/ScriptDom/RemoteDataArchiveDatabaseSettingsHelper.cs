using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RemoteDataArchiveDatabaseSettingsHelper : OptionsHelper<RemoteDataArchiveDatabaseSettingKind> {
        internal static readonly RemoteDataArchiveDatabaseSettingsHelper Instance = new RemoteDataArchiveDatabaseSettingsHelper();

        private RemoteDataArchiveDatabaseSettingsHelper() {
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.Server, "SERVER");
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.Credential, "CREDENTIAL");
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.FederatedServiceAccount, "FEDERATED_SERVICE_ACCOUNT");
        }
    }
}
