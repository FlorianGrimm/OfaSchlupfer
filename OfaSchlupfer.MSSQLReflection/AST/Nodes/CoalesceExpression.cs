#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
