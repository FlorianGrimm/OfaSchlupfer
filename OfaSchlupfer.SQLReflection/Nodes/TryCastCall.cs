namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TryCastCall : PrimaryExpression {
        public TryCastCall() : base() { }
        public TryCastCall(ScriptDom.TryCastCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
        }

        public DataTypeReference DataType { get; set; }

        public ScalarExpression Parameter { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
        }
    }
}
