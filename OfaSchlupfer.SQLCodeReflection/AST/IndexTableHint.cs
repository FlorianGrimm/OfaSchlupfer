namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class IndexTableHint : TableHint {

        public List<IdentifierOrValueExpression> IndexValues { get; } = new List<IdentifierOrValueExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.IndexValues.Accept(visitor);
        }
    }
}
