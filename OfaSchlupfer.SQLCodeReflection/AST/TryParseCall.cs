namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TryParseCall : PrimaryExpression {
        private ScalarExpression _stringValue;

        private DataTypeReference _dataType;

        private ScalarExpression _culture;

        public ScalarExpression StringValue {
            get {
                return this._stringValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._stringValue = value;
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

        public ScalarExpression Culture {
            get {
                return this._culture;
            }

            set {
                this.UpdateTokenInfo(value);
                this._culture = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.StringValue != null) {
                this.StringValue.Accept(visitor);
            }
            if (this.DataType != null) {
                this.DataType.Accept(visitor);
            }
            if (this.Culture != null) {
                this.Culture.Accept(visitor);
            }
        }
    }
}
