namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ScalarFunctionReturnType : FunctionReturnType {
        private DataTypeReference _dataType;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
