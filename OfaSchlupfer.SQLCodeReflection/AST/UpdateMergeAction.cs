namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateMergeAction : MergeAction {
        public List<SetClause> SetClauses { get; } = new List<SetClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SetClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
