namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WindowDelimiter : SqlNode {
        public WindowDelimiter() : base() { }
        public WindowDelimiter(ScriptDom.WindowDelimiter src) : base(src) {
            this.WindowDelimiterType = src.WindowDelimiterType;
            this.OffsetValue = Copier.Copy<ScalarExpression>(src.OffsetValue);
        }

        public Microsoft.SqlServer.TransactSql.ScriptDom.WindowDelimiterType WindowDelimiterType { get; set; }

        public ScalarExpression OffsetValue { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OffsetValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
