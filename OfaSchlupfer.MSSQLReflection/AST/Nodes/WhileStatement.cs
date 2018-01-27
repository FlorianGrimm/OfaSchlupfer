#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WhileStatement : SqlStatement {
        public WhileStatement() : base() { }
        public WhileStatement(ScriptDom.WhileStatement src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.Statement = Copier.Copy<SqlStatement>(src.Statement);
        }
        public BooleanExpression Predicate;
        public SqlStatement Statement;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
