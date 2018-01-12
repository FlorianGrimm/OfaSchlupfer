using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OrderIndexOption : IndexOption {
        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }
}
