namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropAlterFullTextIndexAction : AlterFullTextIndexAction {

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public bool WithNoPopulation { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}