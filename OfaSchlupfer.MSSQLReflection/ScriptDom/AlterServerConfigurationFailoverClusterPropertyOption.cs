using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerConfigurationFailoverClusterPropertyOption : TSqlFragment {
        private AlterServerConfigurationFailoverClusterPropertyOptionKind _optionKind;

        private OptionValue _optionValue;

        public AlterServerConfigurationFailoverClusterPropertyOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
