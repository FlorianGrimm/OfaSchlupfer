using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CompressionPartitionRange : TSqlFragment {
        private ScalarExpression _from;

        private ScalarExpression _to;

        public ScalarExpression From {
            get {
                return this._from;
            }

            set {
                this.UpdateTokenInfo(value);
                this._from = value;
            }
        }

        public ScalarExpression To {
            get {
                return this._to;
            }

            set {
                this.UpdateTokenInfo(value);
                this._to = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.From?.Accept(visitor);
            this.To?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
