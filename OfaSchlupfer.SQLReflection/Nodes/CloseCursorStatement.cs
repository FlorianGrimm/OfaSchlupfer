namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CloseCursorStatement : CursorStatement {
        public CloseCursorStatement() : base() { }
        public CloseCursorStatement(ScriptDom.CloseCursorStatement src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
