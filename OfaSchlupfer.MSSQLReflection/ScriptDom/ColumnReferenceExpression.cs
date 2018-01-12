using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnReferenceExpression : PrimaryExpression {
        private ColumnType _columnType;

        private MultiPartIdentifier _multiPartIdentifier;

        public ColumnType ColumnType {
            get {
                return this._columnType;
            }

            set {
                this._columnType = value;
            }
        }

        public MultiPartIdentifier MultiPartIdentifier {
            get {
                return this._multiPartIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._multiPartIdentifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MultiPartIdentifier?.Accept(visitor);
        }
    }
}
