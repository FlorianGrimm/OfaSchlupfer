namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectFunctionReturnType : FunctionReturnType {
        public SelectFunctionReturnType() : base() { }
        public SelectFunctionReturnType(ScriptDom.SelectFunctionReturnType src) : base(src) {
            this.SelectStatement = Copier.Copy<SelectStatement>(src.SelectStatement);
        }

        public SelectStatement SelectStatement { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
