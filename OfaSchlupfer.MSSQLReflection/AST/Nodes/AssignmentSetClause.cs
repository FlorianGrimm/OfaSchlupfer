#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class AssignmentSetClause : SetClause {
        public AssignmentSetClause() : base() { }
        public AssignmentSetClause(ScriptDom.AssignmentSetClause src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
            this.NewValue = Copier.Copy<ScalarExpression>(src.NewValue);
            this.AssignmentKind = src.AssignmentKind;
        }
        public VariableReference Variable;
        public ColumnReferenceExpression Column;
        public ScalarExpression NewValue;
        public ScriptDom.AssignmentKind AssignmentKind;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Column?.Accept(visitor);
            this.NewValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
