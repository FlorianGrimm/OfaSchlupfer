#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ExecuteAsClause : SqlNode {
        public ExecuteAsClause() : base() { }
        public ExecuteAsClause(ScriptDom.ExecuteAsClause src) : base(src) {
            this.ExecuteAsOption = src.ExecuteAsOption;
            this.Literal = Copier.Copy<Literal>(src.Literal);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ExecuteAsOption ExecuteAsOption { get; set; }

        public Literal Literal { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Literal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
