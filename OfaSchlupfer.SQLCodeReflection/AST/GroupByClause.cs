namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class GroupByClause : TSqlFragment {
        private GroupByOption _groupByOption;

        public GroupByOption GroupByOption {
            get {
                return this._groupByOption;
            }

            set {
                this._groupByOption = value;
            }
        }

        public bool All { get; set; }

        public List<GroupingSpecification> GroupingSpecifications { get; } = new List<GroupingSpecification>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.GroupingSpecifications.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
