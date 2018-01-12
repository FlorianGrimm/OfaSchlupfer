using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OutputClause : TSqlFragment {
        private List<SelectElement> _selectColumns = new List<SelectElement>();

        public List<SelectElement> SelectColumns {
            get {
                return this._selectColumns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.SelectColumns.Count; i < count; i++) {
                this.SelectColumns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
