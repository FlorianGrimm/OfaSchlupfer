namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropIndexStatement : TSqlStatement {
        public List<DropIndexClauseBase> DropIndexClauses { get; } = new List<DropIndexClauseBase>();

        public bool IsIfExists { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = this.DropIndexClauses.Count; i < count; i++) {
                this.DropIndexClauses[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
