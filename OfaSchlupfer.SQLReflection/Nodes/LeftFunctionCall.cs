namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class LeftFunctionCall : PrimaryExpression {
        public LeftFunctionCall() : base() { }
        public LeftFunctionCall(ScriptDom.LeftFunctionCall src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
        }
        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
