using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SecurityPolicyOption : TSqlFragment {
        private SecurityPolicyOptionKind _optionKind;

        private OptionState _optionState;

        public SecurityPolicyOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
