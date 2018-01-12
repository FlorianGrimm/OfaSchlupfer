using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class KeyOption : TSqlFragment {
        private KeyOptionKind _optionKind;

        public KeyOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
