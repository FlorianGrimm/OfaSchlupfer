using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SessionOption : TSqlFragment {
        private SessionOptionKind _optionKind;

        public SessionOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
