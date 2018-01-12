using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SetOnOffStatement : TSqlStatement {
        private bool _isOn;

        public bool IsOn {
            get {
                return this._isOn;
            }

            set {
                this._isOn = value;
            }
        }
    }
}
