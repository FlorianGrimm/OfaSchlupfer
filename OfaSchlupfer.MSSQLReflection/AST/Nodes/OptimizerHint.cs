#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class OptimizerHint : SqlNode {
        public OptimizerHint() : base() { }
        public OptimizerHint(ScriptDom.OptimizerHint src) : base(src) {
            this.HintKind = src.HintKind;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.OptimizerHintKind HintKind;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
