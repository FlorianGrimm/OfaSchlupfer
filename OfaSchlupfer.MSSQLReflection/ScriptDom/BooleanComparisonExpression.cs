namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BooleanComparisonExpression : BooleanExpression {
        private BooleanComparisonType _comparisonType;

        private ScalarExpression _firstExpression;

        private ScalarExpression _secondExpression;

        public BooleanComparisonType ComparisonType {
            get {
                return this._comparisonType;
            }

            set {
                this._comparisonType = value;
            }
        }

        public ScalarExpression FirstExpression {
            get {
                return this._firstExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._firstExpression = value;
            }
        }

        public ScalarExpression SecondExpression {
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
