using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TransactionStatement : TSqlStatement {
        private IdentifierOrValueExpression _name;

        public IdentifierOrValueExpression Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
