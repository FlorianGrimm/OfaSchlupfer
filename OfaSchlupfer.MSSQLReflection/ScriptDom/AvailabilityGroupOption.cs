using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AvailabilityGroupOption : TSqlFragment {
        private AvailabilityGroupOptionKind _optionKind;

        public AvailabilityGroupOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
