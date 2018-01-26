#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
