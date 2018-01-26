namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class IdentityFunctionCall : ScalarExpression {

        public IdentityFunctionCall() : base() { }
        public IdentityFunctionCall(ScriptDom.IdentityFunctionCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Seed = Copier.Copy<ScalarExpression>(src.Seed);
            this.Increment = Copier.Copy<ScalarExpression>(src.Increment);
        }

        public DataTypeReference DataType { get; set; }

        public ScalarExpression Seed { get; set; }

        public ScalarExpression Increment { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            this.Seed?.Accept(visitor);
            this.Increment?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
