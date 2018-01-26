namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ParameterlessCall : PrimaryExpression {
        public ParameterlessCall() : base() { }
        public ParameterlessCall(ScriptDom.ParameterlessCall src) : base(src) {
            this.ParameterlessCallType = src.ParameterlessCallType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ParameterlessCallType ParameterlessCallType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
