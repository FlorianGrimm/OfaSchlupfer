#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class RaiseErrorStatement : SqlStatement {
        public RaiseErrorStatement() : base() { }
        public RaiseErrorStatement(ScriptDom.RaiseErrorStatement src) : base(src) {
            this.FirstParameter = Copier.Copy<ScalarExpression>(src.FirstParameter);
            this.SecondParameter = Copier.Copy<ScalarExpression>(src.SecondParameter);
            this.ThirdParameter = Copier.Copy<ScalarExpression>(src.ThirdParameter);
            Copier.CopyList(this.OptionalParameters, src.OptionalParameters);
            this.RaiseErrorOptions = src.RaiseErrorOptions;
        }
        public ScalarExpression FirstParameter;
        public ScalarExpression SecondParameter;
        public ScalarExpression ThirdParameter;
        public List<ScalarExpression> OptionalParameters { get; } = new List<ScalarExpression>();
        public Microsoft.SqlServer.TransactSql.ScriptDom.RaiseErrorOptions RaiseErrorOptions;
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
