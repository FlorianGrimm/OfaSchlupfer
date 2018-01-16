namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public class StatementList : TSqlFragment {
        public List<TSqlStatement> Statements { get; } = new List<TSqlStatement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Statements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
