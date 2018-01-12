namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class DeclareVariableElement : TSqlFragment {
        private Identifier _variableName;

        private DataTypeReference _dataType;

        private NullableConstraintDefinition _nullable;

        private ScalarExpression _value;

        public Identifier VariableName {
            get {
                return this._variableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variableName = value;
            }
        }

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public NullableConstraintDefinition Nullable {
            get {
                return this._nullable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._nullable = value;
            }
        }

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {

            this.VariableName?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Nullable?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
