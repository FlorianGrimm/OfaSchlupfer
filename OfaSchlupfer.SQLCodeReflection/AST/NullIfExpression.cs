namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class NullIfExpression : PrimaryExpression {
        private ScalarExpression _firstExpression;

        private ScalarExpression _secondExpression;

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
            base.AcceptChildren(visitor);
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
        }
    }
}
