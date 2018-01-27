#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SimpleCaseExpression : CaseExpression {
        public SimpleCaseExpression() : base() { }
        public SimpleCaseExpression(ScriptDom.SimpleCaseExpression src) : base(src) {
            this.InputExpression = Copier.Copy<ScalarExpression>(src.InputExpression);
            Copier.CopyList(this.WhenClauses, src.WhenClauses);
        }
        public ScalarExpression InputExpression;
        public List<SimpleWhenClause> WhenClauses { get; } = new List<SimpleWhenClause>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.InputExpression?.Accept(visitor);
            this.WhenClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
