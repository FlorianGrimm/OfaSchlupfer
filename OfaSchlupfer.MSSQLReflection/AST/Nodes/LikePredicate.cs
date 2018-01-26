#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class LikePredicate : BooleanExpression {
        public LikePredicate() : base() { }
        public LikePredicate(ScriptDom.LikePredicate src) : base(src) {
            this.NotDefined = src.NotDefined;
            this.OdbcEscape = src.OdbcEscape;
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
            this.EscapeExpression = Copier.Copy<ScalarExpression>(src.EscapeExpression);
        }
        public ScalarExpression FirstExpression { get; set; }

        public ScalarExpression SecondExpression { get; set; }

        public bool NotDefined { get; set; }

        public bool OdbcEscape { get; set; }

        public ScalarExpression EscapeExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            this.EscapeExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
