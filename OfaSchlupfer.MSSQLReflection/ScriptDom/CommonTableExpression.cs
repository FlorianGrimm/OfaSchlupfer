using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CommonTableExpression : TSqlFragment {
        private Identifier _expressionName;

        private List<Identifier> _columns = new List<Identifier>();

        private QueryExpression _queryExpression;

        public Identifier ExpressionName {
            get {
                return this._expressionName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expressionName = value;
            }
        }

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public QueryExpression QueryExpression {
            get {
                return this._queryExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._queryExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ExpressionName?.Accept(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.QueryExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
