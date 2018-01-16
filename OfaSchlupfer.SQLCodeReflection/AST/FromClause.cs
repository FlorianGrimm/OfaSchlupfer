namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FromClause : TSqlFragment {
        public List<TableReference> TableReferences { get; } = new List<TableReference>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TableReferences.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
