namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropIndexStatement : SqlStatement {
        public List<DropIndexClauseBase> DropIndexClauses { get; } = new List<DropIndexClauseBase>();

        public bool IsIfExists { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DropIndexClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
