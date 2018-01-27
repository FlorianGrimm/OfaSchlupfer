#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ProcedureReference : SqlNode {
        public ProcedureReference() : base() { }
        public ProcedureReference(ScriptDom.ProcedureReference src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
            this.Number = Copier.Copy<Literal>(src.Number);
        }
        public SchemaObjectName Name;
        public Literal Number;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Number?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
