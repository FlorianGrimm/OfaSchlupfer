using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RowValue : TSqlFragment {
        private List<ScalarExpression> _columnValues = new List<ScalarExpression>();

        public List<ScalarExpression> ColumnValues {
            get {
                return this._columnValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.ColumnValues.Count; i < count; i++) {
                this.ColumnValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
