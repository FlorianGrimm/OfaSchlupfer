using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BeginTransactionStatement : TransactionStatement {
        private bool _distributed;

        private bool _markDefined;

        private ValueExpression _markDescription;

        public bool Distributed {
            get {
                return this._distributed;
            }
            set {
                this._distributed = value;
            }
        }

        public bool MarkDefined {
            get {
                return this._markDefined;
            }
            set {
                this._markDefined = value;
            }
        }

        public ValueExpression MarkDescription {
            get {
                return this._markDescription;
            }
            set {
                base.UpdateTokenInfo(value);
                this._markDescription = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MarkDescription?.Accept(visitor);
        }
    }
}
