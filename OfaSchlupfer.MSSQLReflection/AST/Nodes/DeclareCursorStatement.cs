#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class DeclareCursorStatement : SqlStatement {
        public DeclareCursorStatement() : base() { }
        public DeclareCursorStatement(ScriptDom.DeclareCursorStatement src) : base(src) {
            this.Name = Copier.Copy<Identifier>(src.Name);
            this.CursorDefinition = Copier.Copy<CursorDefinition>(src.CursorDefinition);
        }
        public Identifier Name;
        public CursorDefinition CursorDefinition;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
