#pragma warning disable SA1600 // Elements must be documented

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
