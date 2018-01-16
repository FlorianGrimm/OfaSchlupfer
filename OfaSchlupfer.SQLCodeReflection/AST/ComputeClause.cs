#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ComputeClause : TSqlFragment {
        public List<ComputeFunction> ComputeFunctions { get; } = new List<ComputeFunction>();

        public List<ScalarExpression> ByExpressions { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ComputeFunctions.Accept(visitor);
            this.ByExpressions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
