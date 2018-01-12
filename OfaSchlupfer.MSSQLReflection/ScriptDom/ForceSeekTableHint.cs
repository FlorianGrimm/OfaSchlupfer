using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ForceSeekTableHint : TableHint {
        private IdentifierOrValueExpression _indexValue;

        private List<ColumnReferenceExpression> _columnValues = new List<ColumnReferenceExpression>();

        public IdentifierOrValueExpression IndexValue {
            get {
                return this._indexValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._indexValue = value;
            }
        }

        public List<ColumnReferenceExpression> ColumnValues {
            get {
                return this._columnValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.IndexValue?.Accept(visitor);
            for (int i=0, count = this.ColumnValues.Count; i < count; i++) {
                this.ColumnValues[i].Accept(visitor);
            }
        }
    }
}
