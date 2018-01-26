namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class RaiseErrorStatement : SqlStatement {
        public RaiseErrorStatement() : base() { }
        public RaiseErrorStatement(ScriptDom.RaiseErrorStatement src) : base(src) {
            this.FirstParameter = Copier.Copy<ScalarExpression>(src.FirstParameter);
            this.SecondParameter = Copier.Copy<ScalarExpression>(src.SecondParameter);
            this.ThirdParameter = Copier.Copy<ScalarExpression>(src.ThirdParameter);
            Copier.CopyList(this.OptionalParameters, src.OptionalParameters);
            this.RaiseErrorOptions = src.RaiseErrorOptions;
        }
        public ScalarExpression FirstParameter { get; set; }

        public ScalarExpression SecondParameter { get; set; }

        public ScalarExpression ThirdParameter { get; set; }

        public List<ScalarExpression> OptionalParameters { get; } = new List<ScalarExpression>();

        public Microsoft.SqlServer.TransactSql.ScriptDom.RaiseErrorOptions RaiseErrorOptions { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstParameter?.Accept(visitor);
            this.SecondParameter?.Accept(visitor);
            this.ThirdParameter?.Accept(visitor);
            this.OptionalParameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
