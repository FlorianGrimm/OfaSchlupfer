using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveDbFederatedServiceAccountSetting : RemoteDataArchiveDatabaseSetting {
        private bool _isOn;

        public bool IsOn {
            get {
                return this._isOn;
            }

            set {
                this._isOn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
