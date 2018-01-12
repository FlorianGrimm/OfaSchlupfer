using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TablePartitionOption : TableOption {
        private Identifier _partitionColumn;

        private TablePartitionOptionSpecifications _partitionOptionSpecs;

        public Identifier PartitionColumn {
            get {
                return this._partitionColumn;
            }
            set {
                this._partitionColumn = value;
            }
        }

        public TablePartitionOptionSpecifications PartitionOptionSpecs {
            get {
                return this._partitionOptionSpecs;
            }
            set {
                base.UpdateTokenInfo(value);
                this._partitionOptionSpecs = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PartitionOptionSpecs?.Accept(visitor);
        }
    }
}
