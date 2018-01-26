#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class FunctionCall : PrimaryExpression {
        public FunctionCall() : base() { }
        public FunctionCall(ScriptDom.FunctionCall src) : base(src) {
            this.CallTarget = Copier.Copy<CallTarget>(src.CallTarget);
            this.FunctionName = Copier.Copy<Identifier>(src.FunctionName);
            Copier.CopyList(this.Parameters, src.Parameters);
            this.UniqueRowFilter = src.UniqueRowFilter;
            this.OverClause = Copier.Copy<OverClause>(src.OverClause);
            this.WithinGroupClause = Copier.Copy<WithinGroupClause>(src.WithinGroupClause);
        }
        public CallTarget CallTarget { get; set; }

        public Identifier FunctionName { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public Microsoft.SqlServer.TransactSql.ScriptDom.UniqueRowFilter UniqueRowFilter { get; set; }

        public OverClause OverClause { get; set; }

        public WithinGroupClause WithinGroupClause { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.FunctionName?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.OverClause?.Accept(visitor);
            this.WithinGroupClause?.Accept(visitor);
        }
    }
}
