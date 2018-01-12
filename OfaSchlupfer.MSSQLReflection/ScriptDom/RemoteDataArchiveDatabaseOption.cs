using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveDatabaseOption : DatabaseOption {
        private OptionState _optionState;

        private List<RemoteDataArchiveDatabaseSetting> _settings = new List<RemoteDataArchiveDatabaseSetting>();

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public List<RemoteDataArchiveDatabaseSetting> Settings {
            get {
                return this._settings;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Settings.Count; i < count; i++) {
                this.Settings[i].Accept(visitor);
            }
        }
    }
}
