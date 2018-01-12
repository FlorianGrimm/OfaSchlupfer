using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ApplicationRoleOption : TSqlFragment {
        private ApplicationRoleOptionKind _optionKind;

        private IdentifierOrValueExpression _value;

        public ApplicationRoleOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public IdentifierOrValueExpression Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
