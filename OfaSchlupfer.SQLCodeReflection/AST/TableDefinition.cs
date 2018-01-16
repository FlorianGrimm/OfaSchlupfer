namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableDefinition : TSqlFragment {
        private SystemTimePeriodDefinition _systemTimePeriod;

        public List<ColumnDefinition> ColumnDefinitions { get; } = new List<ColumnDefinition>();

        public List<ConstraintDefinition> TableConstraints { get; } = new List<ConstraintDefinition>();

        public List<IndexDefinition> Indexes { get; } = new List<IndexDefinition>();

        public SystemTimePeriodDefinition SystemTimePeriod {
            get {
                return this._systemTimePeriod;
            }

            set {
                this.UpdateTokenInfo(value);
                this._systemTimePeriod = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnDefinitions.Accept(visitor);
            this.TableConstraints.Accept(visitor);
            this.Indexes.Accept(visitor);
            this.SystemTimePeriod?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
