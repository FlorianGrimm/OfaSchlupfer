#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class DropObjectsStatement : SqlStatement {
        public List<SchemaObjectName> Objects { get; } = new List<SchemaObjectName>();

        public bool IsIfExists { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Objects.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
