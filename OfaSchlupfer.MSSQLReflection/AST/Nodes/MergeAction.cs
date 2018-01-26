#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class MergeAction : SqlNode {
        public MergeAction() : base() { }
        public MergeAction(ScriptDom.MergeAction src) : base(src) { }
    }

    [System.Serializable]
    public sealed class DeleteMergeAction : MergeAction {
        public DeleteMergeAction() : base() { }
        public DeleteMergeAction(ScriptDom.DeleteMergeAction src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
