#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TopRowFilter : SqlNode {
        public TopRowFilter() : base() { }
        public TopRowFilter(ScriptDom.TopRowFilter src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.Percent = src.Percent;
            this.WithTies = src.WithTies;
        }
        public ScalarExpression Expression;
        public bool Percent;
        public bool WithTies;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
