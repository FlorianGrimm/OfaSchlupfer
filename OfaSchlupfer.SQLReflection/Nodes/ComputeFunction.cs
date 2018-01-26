namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ComputeFunction : SqlNode {
        public ComputeFunction() : base() { }
        public ComputeFunction(ScriptDom.ComputeFunction src) : base(src) {
            this.ComputeFunctionType = src.ComputeFunctionType;
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ComputeFunctionType ComputeFunctionType { get; set; }

        public ScalarExpression Expression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
