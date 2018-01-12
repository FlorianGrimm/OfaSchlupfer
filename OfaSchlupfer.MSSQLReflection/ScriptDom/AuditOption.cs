using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AuditOption : TSqlFragment {
        private AuditOptionKind _optionKind;

        public AuditOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
