using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateTypeUddtStatement : CreateTypeStatement {
        private DataTypeReference _dataType;

        private NullableConstraintDefinition _nullableConstraint;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public NullableConstraintDefinition NullableConstraint {
            get {
                return this._nullableConstraint;
            }
            set {
                base.UpdateTokenInfo(value);
                this._nullableConstraint = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            this.DataType?.Accept(visitor);
            this.NullableConstraint?.Accept(visitor);
        }
    }
}
