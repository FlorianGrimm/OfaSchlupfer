namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TSqlBatch : TSqlFragment {
        private List<TSqlStatement> _statements = new List<TSqlStatement>();

        public List<TSqlStatement> Statements => this._statements;

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            var statements = this.Statements;
            for (int i = 0, count = statements.Count; i < count; i++) {
                statements[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
