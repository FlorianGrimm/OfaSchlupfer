#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ComputeClause : SqlNode {
        public ComputeClause() : base() { }
        public ComputeClause(ScriptDom.ComputeClause src) : base(src) {
            Copier.CopyList(this.ComputeFunctions, src.ComputeFunctions);
            Copier.CopyList(this.ByExpressions, src.ByExpressions);
        }

        public List<ComputeFunction> ComputeFunctions { get; } = new List<ComputeFunction>();

        public List<ScalarExpression> ByExpressions { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ComputeFunctions.Accept(visitor);
            this.ByExpressions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
