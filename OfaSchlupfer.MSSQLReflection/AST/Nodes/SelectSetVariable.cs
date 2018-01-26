#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectSetVariable : SelectElement {
        public SelectSetVariable() : base() { }
        public SelectSetVariable(ScriptDom.SelectSetVariable src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.AssignmentKind = src.AssignmentKind;
        }
        public VariableReference Variable { get; set; }

        public ScalarExpression Expression { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.AssignmentKind AssignmentKind { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
