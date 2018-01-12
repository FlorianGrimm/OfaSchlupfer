using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableDefinition : TSqlFragment {
        private List<ColumnDefinition> _columnDefinitions = new List<ColumnDefinition>();

        private List<ConstraintDefinition> _tableConstraints = new List<ConstraintDefinition>();

        private List<IndexDefinition> _indexes = new List<IndexDefinition>();

        private SystemTimePeriodDefinition _systemTimePeriod;

        public List<ColumnDefinition> ColumnDefinitions {
            get {
                return this._columnDefinitions;
            }
        }

        public List<ConstraintDefinition> TableConstraints {
            get {
                return this._tableConstraints;
            }
        }

        public List<IndexDefinition> Indexes {
            get {
                return this._indexes;
            }
        }

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
            for (int i=0, count = this.ColumnDefinitions.Count; i < count; i++) {
                this.ColumnDefinitions[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.TableConstraints.Count; j < count2; j++) {
                this.TableConstraints[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = this.Indexes.Count; k < count3; k++) {
                this.Indexes[k].Accept(visitor);
            }
            this.SystemTimePeriod?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
