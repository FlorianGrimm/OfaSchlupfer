#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class SelectElement : SqlNode {
        public SelectElement() : base() { }
        public SelectElement(ScriptDom.SelectElement src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectStarExpression : SelectElement {
        public SelectStarExpression() : base() { }
        public SelectStarExpression(ScriptDom.SelectStarExpression src) : base(src) {
            this.Qualifier = Copier.Copy<MultiPartIdentifier>(src.Qualifier);
        }
        public MultiPartIdentifier Qualifier;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Qualifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
