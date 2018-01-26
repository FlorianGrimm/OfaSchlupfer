namespace OfaSchlupfer.SQLReflection {
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
