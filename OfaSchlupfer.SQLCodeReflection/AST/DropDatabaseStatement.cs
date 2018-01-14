namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropDatabaseStatement : TSqlStatement {

        public List<Identifier> Databases { get; } = new List<Identifier>();

        public bool IsIfExists { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = this.Databases.Count; i < count; i++) {
                this.Databases[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
