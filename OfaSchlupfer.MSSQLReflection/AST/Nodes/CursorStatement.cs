#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class CursorStatement : SqlStatement {
        public CursorStatement() : base() { }
        public CursorStatement(ScriptDom.CursorStatement src) : base(src) {
            this.Cursor = Copier.Copy<CursorId>(src.Cursor);
        }

        public CursorId Cursor { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Cursor?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
