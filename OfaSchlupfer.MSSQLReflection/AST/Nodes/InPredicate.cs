#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class InPredicate : BooleanExpression {
        public InPredicate() : base() { }
        public InPredicate(ScriptDom.InPredicate src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
            this.NotDefined = src.NotDefined;
            Copier.CopyList(this.Values, src.Values);
        }
        public ScalarExpression Expression;
        public ScalarSubquery Subquery;
        public bool NotDefined;
        public List<ScalarExpression> Values { get; } = new List<ScalarExpression>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            this.Values.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
