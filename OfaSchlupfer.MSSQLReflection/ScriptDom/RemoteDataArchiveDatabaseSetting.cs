using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class RemoteDataArchiveDatabaseSetting : TSqlFragment {
        private RemoteDataArchiveDatabaseSettingKind _settingKind;

        public RemoteDataArchiveDatabaseSettingKind SettingKind {
            get {
                return this._settingKind;
            }
            set {
                this._settingKind = value;
            }
        }
    }
}
