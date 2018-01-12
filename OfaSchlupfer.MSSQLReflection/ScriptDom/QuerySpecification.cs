namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class QuerySpecification : QueryExpression {

        private TopRowFilter _topRowFilter;

        private FromClause _fromClause;

        private WhereClause _whereClause;

        private GroupByClause _groupByClause;

        private HavingClause _havingClause;

        public UniqueRowFilter UniqueRowFilter { get; set; }

        public TopRowFilter TopRowFilter {
            get {
                return this._topRowFilter;
            }
            set {
                base.UpdateTokenInfo(value);
                this._topRowFilter = value;
            }
        }

        public List<SelectElement> SelectElements { get; } = new List<SelectElement>();

        public FromClause FromClause {
            get {
                return this._fromClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fromClause = value;
            }
        }

        public WhereClause WhereClause {
            get {
                return this._whereClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._whereClause = value;
            }
        }

        public GroupByClause GroupByClause {
            get {
                return this._groupByClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._groupByClause = value;
            }
        }

        public HavingClause HavingClause {
            get {
                return this._havingClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._havingClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TopRowFilter?.Accept(visitor);
            var selectElements = this.SelectElements;
            for (int i = 0, count = selectElements.Count; i < count; i++) {
                selectElements[i].Accept(visitor);
            }
            this.FromClause?.Accept(visitor);
            this.WhereClause?.Accept(visitor);
            this.GroupByClause?.Accept(visitor);
            this.HavingClause?.Accept(visitor);
        }
    }
}
