namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateMergeAction : MergeAction {
        public UpdateMergeAction() : base() { }
        public UpdateMergeAction(ScriptDom.UpdateMergeAction src) : base(src) {
            Copier.CopyList(this.SetClauses, src.SetClauses);
        }
        public List<SetClause> SetClauses { get; } = new List<SetClause>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SetClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
