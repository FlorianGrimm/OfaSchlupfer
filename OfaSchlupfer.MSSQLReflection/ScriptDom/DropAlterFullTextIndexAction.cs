namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropAlterFullTextIndexAction : AlterFullTextIndexAction {

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public bool WithNoPopulation { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}