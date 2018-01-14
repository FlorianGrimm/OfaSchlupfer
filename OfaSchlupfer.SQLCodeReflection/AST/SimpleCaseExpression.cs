using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SimpleCaseExpression : CaseExpression {
        private ScalarExpression _inputExpression;

        private List<SimpleWhenClause> _whenClauses = new List<SimpleWhenClause>();

        public ScalarExpression InputExpression {
            get {
                return this._inputExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._inputExpression = value;
            }
        }

        public List<SimpleWhenClause> WhenClauses {
            get {
                return this._whenClauses;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.InputExpression?.Accept(visitor);
            for (int i = 0, count = this.WhenClauses.Count; i < count; i++) {
                this.WhenClauses[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
