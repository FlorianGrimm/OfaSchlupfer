#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class IfStatement : SqlStatement {
        public IfStatement() : base() { }
        public IfStatement(ScriptDom.IfStatement src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.ThenStatement = Copier.Copy<SqlStatement>(src.ThenStatement);
            this.ElseStatement = Copier.Copy<SqlStatement>(src.ElseStatement);
        }
        public BooleanExpression Predicate;
        public SqlStatement ThenStatement;
        public SqlStatement ElseStatement;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.ThenStatement?.Accept(visitor);
            this.ElseStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
