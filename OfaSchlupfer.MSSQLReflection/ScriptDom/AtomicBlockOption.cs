using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AtomicBlockOption : TSqlFragment {
        private AtomicBlockOptionKind _optionKind;

        public AtomicBlockOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
