using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CoalesceExpression : PrimaryExpression {
        private List<ScalarExpression> _expressions = new List<ScalarExpression>();

        public List<ScalarExpression> Expressions {
            get {
                return this._expressions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Expressions.Count; i < count; i++) {
                this.Expressions[i].Accept(visitor);
            }
        }
    }
}
