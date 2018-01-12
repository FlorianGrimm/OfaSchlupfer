using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnWithSortOrder : TSqlFragment {
        private ColumnReferenceExpression _column;

        private SortOrder _sortOrder;

        public ColumnReferenceExpression Column {
            get {
                return this._column;
            }
            set {
                base.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public SortOrder SortOrder {
            get {
                return this._sortOrder;
            }
            set {
                this._sortOrder = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
