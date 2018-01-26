namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class WriteTextStatement : TextModificationStatement {
        public WriteTextStatement() : base() { }
        public WriteTextStatement(ScriptDom.WriteTextStatement src) : base(src) {
            this.SourceParameter = Copier.Copy<ValueExpression>(src.SourceParameter);
        }
        public ValueExpression SourceParameter { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SourceParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
