using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PartitionParameterType : TSqlFragment, ICollationSetter {
        private DataTypeReference _dataType;

        private Identifier _collation;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public Identifier Collation {
            get {
                return this._collation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
