using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateStatisticsStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _onName;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        private List<StatisticsOption> _statisticsOptions = new List<StatisticsOption>();

        private BooleanExpression _filterPredicate;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public List<StatisticsOption> StatisticsOptions {
            get {
                return this._statisticsOptions;
            }
        }

        public BooleanExpression FilterPredicate {
            get {
                return this._filterPredicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._filterPredicate = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.StatisticsOptions.Count; j < count2; j++) {
                this.StatisticsOptions[j].Accept(visitor);
            }
            this.FilterPredicate?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
