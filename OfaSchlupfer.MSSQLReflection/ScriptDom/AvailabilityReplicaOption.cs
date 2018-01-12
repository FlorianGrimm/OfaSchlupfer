using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AvailabilityReplicaOption : TSqlFragment {
        private AvailabilityReplicaOptionKind _optionKind;

        public AvailabilityReplicaOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
