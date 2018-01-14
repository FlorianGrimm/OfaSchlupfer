namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UseHintList : OptimizerHint {

        public List<StringLiteral> Hints { get; } = new List<StringLiteral>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Hints.Count; i < count; i++) {
                this.Hints[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
