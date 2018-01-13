using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GroupByClause : TSqlFragment {
        private GroupByOption _groupByOption;

        private bool _all;

        private List<GroupingSpecification> _groupingSpecifications = new List<GroupingSpecification>();

        public GroupByOption GroupByOption {
            get {
                return this._groupByOption;
            }

            set {
                this._groupByOption = value;
            }
        }

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public List<GroupingSpecification> GroupingSpecifications {
            get {
                return this._groupingSpecifications;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.GroupingSpecifications.Count; i < count; i++) {
                this.GroupingSpecifications[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
