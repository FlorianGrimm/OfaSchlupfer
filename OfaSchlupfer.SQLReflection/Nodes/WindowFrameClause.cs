namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WindowFrameClause : SqlNode {
        public WindowFrameClause() : base() { }
        public WindowFrameClause(ScriptDom.WindowFrameClause src) : base(src) {
            this.Top = Copier.Copy<WindowDelimiter>(src.Top);
            this.Bottom = Copier.Copy<WindowDelimiter>(src.Bottom);
            this.WindowFrameType = src.WindowFrameType;
        }

        public WindowDelimiter Top { get; set; }

        public WindowDelimiter Bottom { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.WindowFrameType WindowFrameType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Top?.Accept(visitor);
            this.Bottom?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
