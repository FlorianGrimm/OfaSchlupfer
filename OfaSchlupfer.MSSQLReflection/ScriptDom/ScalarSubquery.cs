using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ScalarSubquery : PrimaryExpression {
        private QueryExpression _queryExpression;

        public QueryExpression QueryExpression {
            get {
                return this._queryExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queryExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }
}
