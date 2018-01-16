namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class Permission : TSqlFragment {
        public List<Identifier> Identifiers { get; } = new List<Identifier>();

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifiers.Accept(visitor);
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
