namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class MergeAction : SqlNode {
        public MergeAction() : base() { }
        public MergeAction(ScriptDom.MergeAction src) : base(src) {
        }
    }
}
namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class DeleteMergeAction : MergeAction {
        public DeleteMergeAction() : base() { }
        public DeleteMergeAction(ScriptDom.DeleteMergeAction src) : base(src) {
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
