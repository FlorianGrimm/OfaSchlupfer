namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UseHintList : OptimizerHint {

        public List<StringLiteral> Hints { get; } = new List<StringLiteral>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Hints.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
