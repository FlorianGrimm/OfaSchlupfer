namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OutputClause : TSqlFragment {
        public List<SelectElement> SelectColumns { get; } = new List<SelectElement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SelectColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
