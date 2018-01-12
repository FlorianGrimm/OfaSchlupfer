using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QualifiedJoin : JoinTableReference {
        private BooleanExpression _searchCondition;

        private QualifiedJoinType _qualifiedJoinType;

        private JoinHint _joinHint;

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public QualifiedJoinType QualifiedJoinType {
            get {
                return this._qualifiedJoinType;
            }
            set {
                this._qualifiedJoinType = value;
            }
        }

        public JoinHint JoinHint {
            get {
                return this._joinHint;
            }
            set {
                this._joinHint = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.SearchCondition?.Accept(visitor);
        }
    }
}
