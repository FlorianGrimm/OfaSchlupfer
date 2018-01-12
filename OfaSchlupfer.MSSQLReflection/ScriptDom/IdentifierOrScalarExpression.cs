using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentifierOrScalarExpression : TSqlFragment {
        private Identifier _identifier;

        private ScalarExpression _scalarExpression;

        public Identifier Identifier {
            get {
                return this._identifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public ScalarExpression ScalarExpression {
            get {
                return this._scalarExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._scalarExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            this.ScalarExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
