using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CloseSymmetricKeyStatement : TSqlStatement {
        private Identifier _name;

        private bool _all;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
