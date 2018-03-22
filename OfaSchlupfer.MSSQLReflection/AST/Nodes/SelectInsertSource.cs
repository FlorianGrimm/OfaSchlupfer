#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectInsertSource : InsertSource {
        public SelectInsertSource() : base() { }
        public SelectInsertSource(ScriptDom.SelectInsertSource src) : base(src) {
            this.Select = Copier.Copy<QueryExpression>(src.Select);
        }
        public QueryExpression Select;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
