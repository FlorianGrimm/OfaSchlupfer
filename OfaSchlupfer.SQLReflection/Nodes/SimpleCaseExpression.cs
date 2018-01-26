namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SimpleCaseExpression : CaseExpression {
        public SimpleCaseExpression() : base() { }
        public SimpleCaseExpression(ScriptDom.SimpleCaseExpression src) : base(src) {
            this.InputExpression = Copier.Copy<ScalarExpression>(src.InputExpression);
            Copier.CopyList(this.WhenClauses, src.WhenClauses);
        }
        public ScalarExpression InputExpression { get; set; }

        public List<SimpleWhenClause> WhenClauses { get; } = new List<SimpleWhenClause>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.InputExpression?.Accept(visitor);
            this.WhenClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
