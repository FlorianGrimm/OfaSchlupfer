#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
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
