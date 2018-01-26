namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ExecuteAsStatement : SqlStatement {
        public ExecuteAsStatement() : base() { }
        public ExecuteAsStatement(ScriptDom.ExecuteAsStatement src) : base(src) {
            this.WithNoRevert = src.WithNoRevert;
            this.Cookie = Copier.Copy<VariableReference>(src.Cookie);
            this.ExecuteContext = Copier.Copy<ExecuteContext>(src.ExecuteContext);
        }

        public bool WithNoRevert { get; set; }

        public VariableReference Cookie { get; set; }

        public ExecuteContext ExecuteContext { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Cookie?.Accept(visitor);
            this.ExecuteContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
