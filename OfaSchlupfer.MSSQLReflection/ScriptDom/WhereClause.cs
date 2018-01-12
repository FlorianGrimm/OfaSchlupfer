using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WhereClause : TSqlFragment {
        private BooleanExpression _searchCondition;

        private CursorId _cursor;

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public CursorId Cursor {
            get {
                return this._cursor;
            }
            set {
                base.UpdateTokenInfo(value);
                this._cursor = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SearchCondition?.Accept(visitor);
            this.Cursor?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
