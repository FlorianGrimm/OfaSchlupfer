namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AddAlterFullTextIndexAction : AlterFullTextIndexAction {
        public List<FullTextIndexColumn> Columns { get; } = new List<FullTextIndexColumn>();

        public bool WithNoPopulation { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            var columns = this.Columns;
            for (int i = 0, count = columns.Count; i < count; i++) {
                columns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
