#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class DefaultConstraintDefinition : ConstraintDefinition {
        public DefaultConstraintDefinition() : base() { }
        public DefaultConstraintDefinition(ScriptDom.DefaultConstraintDefinition src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.WithValues = src.WithValues;
            this.Column = Copier.Copy<Identifier>(src.Column);
        }

        public ScalarExpression Expression { get; set; }

        public bool WithValues { get; set; }

        public Identifier Column { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
            this.Column?.Accept(visitor);
        }
    }
}
