namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BooleanBinaryExpression : BooleanExpression {
        private BooleanBinaryExpressionType _binaryExpressionType;

        private BooleanExpression _firstExpression;

        private BooleanExpression _secondExpression;

        public BooleanBinaryExpressionType BinaryExpressionType {
            get {
                return this._binaryExpressionType;
            }

            set {
                this._binaryExpressionType = value;
            }
        }

        public BooleanExpression FirstExpression {
            get {
                return this._firstExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._firstExpression = value;
            }
        }

        public BooleanExpression SecondExpression {
            get {
                return this._secondExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secondExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
