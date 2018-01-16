namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AddAlterFullTextIndexAction : AlterFullTextIndexAction {
        public List<FullTextIndexColumn> Columns { get; } = new List<FullTextIndexColumn>();

        public bool WithNoPopulation { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
