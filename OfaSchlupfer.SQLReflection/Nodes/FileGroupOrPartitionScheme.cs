namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FileGroupOrPartitionScheme : SqlNode {
        public IdentifierOrValueExpression Name { get; set; }

        public List<Identifier> PartitionSchemeColumns { get; } = new List<Identifier>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.PartitionSchemeColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
