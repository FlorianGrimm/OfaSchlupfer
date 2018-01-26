namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class Permission : SqlNode {
        public List<Identifier> Identifiers { get; } = new List<Identifier>();

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifiers.Accept(visitor);
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
