namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CoalesceExpression : PrimaryExpression {
        public CoalesceExpression() : base() { }
        public CoalesceExpression(ScriptDom.CoalesceExpression src) : base(src) {
            Copier.CopyList(this.Expressions, src.Expressions);
        }
        public List<ScalarExpression> Expressions { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expressions.Accept(visitor);
        }
    }
}
