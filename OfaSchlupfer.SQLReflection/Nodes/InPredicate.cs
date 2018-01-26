namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class InPredicate : BooleanExpression {
        public InPredicate() : base() { }
        public InPredicate(ScriptDom.InPredicate src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.Subquery = Copier.Copy<ScalarSubquery>(src.Subquery);
            this.NotDefined = src.NotDefined;
            Copier.CopyList(this.Values, src.Values);

        }


        public ScalarExpression Expression { get; set; }

        public ScalarSubquery Subquery { get; set; }

        public bool NotDefined { get; set; }

        public List<ScalarExpression> Values { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            this.Values.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
