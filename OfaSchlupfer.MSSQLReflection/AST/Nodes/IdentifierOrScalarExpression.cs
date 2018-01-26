#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class IdentifierOrScalarExpression : SqlNode {
        public IdentifierOrScalarExpression() : base() { }
        public IdentifierOrScalarExpression(ScriptDom.IdentifierOrScalarExpression src) : base(src) {
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
            this.ScalarExpression = Copier.Copy<ScalarExpression>(src.ScalarExpression);
        }

        public Identifier Identifier { get; set; }

        public ScalarExpression ScalarExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            this.ScalarExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
