namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TryParseCall : PrimaryExpression {
        public TryParseCall() : base() { }
        public TryParseCall(ScriptDom.TryParseCall src) : base(src) {
            this.StringValue = Copier.Copy<ScalarExpression>(src.StringValue);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Culture = Copier.Copy<ScalarExpression>(src.Culture);
        }

        public ScalarExpression StringValue { get; set; }

        public DataTypeReference DataType { get; set; }

        public ScalarExpression Culture { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StringValue?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Culture?.Accept(visitor);
        }
    }
}
