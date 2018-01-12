using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class PrimaryExpression : ScalarExpression, ICollationSetter {
        private Identifier _collation;

        public Identifier Collation {
            get {
                return this._collation;
            }
            set {
                base.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
