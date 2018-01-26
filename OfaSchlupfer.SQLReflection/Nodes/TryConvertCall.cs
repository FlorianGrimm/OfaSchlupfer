namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TryConvertCall : PrimaryExpression {
        public TryConvertCall() : base() { }
        public TryConvertCall(ScriptDom.TryConvertCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
            this.Style = Copier.Copy<ScalarExpression>(src.Style);
        }

        public DataTypeReference DataType { get; set; }

        public ScalarExpression Parameter { get; set; }

        public ScalarExpression Style { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
            this.Style?.Accept(visitor);
        }
    }
}
