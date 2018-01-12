using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterFederationStatement : TSqlStatement {
        private Identifier _name;

        private AlterFederationKind _kind;

        private Identifier _distributionName;

        private ScalarExpression _boundary;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public AlterFederationKind Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }

        public Identifier DistributionName {
            get {
                return this._distributionName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._distributionName = value;
            }
        }

        public ScalarExpression Boundary {
            get {
                return this._boundary;
            }

            set {
                this.UpdateTokenInfo(value);
                this._boundary = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.DistributionName?.Accept(visitor);
            this.Boundary?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
