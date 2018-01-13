using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InsertMergeAction : MergeAction {
        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        private ValuesInsertSource _source;

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public ValuesInsertSource Source {
            get {
                return this._source;
            }

            set {
                this.UpdateTokenInfo(value);
                this._source = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.Source?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
