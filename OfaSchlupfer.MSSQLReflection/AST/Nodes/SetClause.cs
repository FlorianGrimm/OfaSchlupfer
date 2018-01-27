#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class SetClause : SqlNode {
        public SetClause() : base() { }
        public SetClause(ScriptDom.SetClause src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class FunctionCallSetClause : SetClause {
        public FunctionCallSetClause() : base() { }
        public FunctionCallSetClause(ScriptDom.FunctionCallSetClause src) : base(src) {
            this.MutatorFunction = Copier.Copy<FunctionCall>(src.MutatorFunction);
        }
        public FunctionCall MutatorFunction;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.MutatorFunction?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
