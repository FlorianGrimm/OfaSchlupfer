using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AuditTargetOption : TSqlFragment {
        private AuditTargetOptionKind _optionKind;

        public AuditTargetOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
