using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerConfigurationHadrClusterOption : TSqlFragment {
        private AlterServerConfigurationHadrClusterOptionKind _optionKind;

        private OptionValue _optionValue;

        private bool _isLocal;

        public AlterServerConfigurationHadrClusterOptionKind OptionKind {
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

        public bool IsLocal {
            get {
                return this._isLocal;
            }
            set {
                this._isLocal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
