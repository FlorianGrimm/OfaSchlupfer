namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateMergeAction : MergeAction {
        private List<SetClause> _setClauses = new List<SetClause>();

        public List<SetClause> SetClauses {
            get {
                return this._setClauses;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.SetClauses.Count; i < count; i++) {
                this.SetClauses[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
