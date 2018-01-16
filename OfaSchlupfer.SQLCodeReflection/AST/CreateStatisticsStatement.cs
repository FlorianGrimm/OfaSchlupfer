namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateStatisticsStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _onName;

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

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public List<StatisticsOption> StatisticsOptions { get; } = new List<StatisticsOption>();

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
            this.Columns.Accept(visitor);
            this.StatisticsOptions.Accept(visitor);
            this.FilterPredicate?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
