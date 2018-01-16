namespace OfaSchlupfer.AST {
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
                this.UpdateTokenInfo(value);
                this._topRowFilter = value;
            }
        }

        public List<SelectElement> SelectElements { get; } = new List<SelectElement>();

        public FromClause FromClause {
            get {
                return this._fromClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fromClause = value;
            }
        }

        public WhereClause WhereClause {
            get {
                return this._whereClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._whereClause = value;
            }
        }

        public GroupByClause GroupByClause {
            get {
                return this._groupByClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._groupByClause = value;
            }
        }

        public HavingClause HavingClause {
            get {
                return this._havingClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._havingClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TopRowFilter?.Accept(visitor);
            this.SelectElements.Accept(visitor);
            this.FromClause?.Accept(visitor);
            this.WhereClause?.Accept(visitor);
            this.GroupByClause?.Accept(visitor);
            this.HavingClause?.Accept(visitor);
        }
    }
}
