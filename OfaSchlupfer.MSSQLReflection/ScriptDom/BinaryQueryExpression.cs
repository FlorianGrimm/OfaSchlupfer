namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BinaryQueryExpression : QueryExpression {
        private QueryExpression _firstQueryExpression;

        private QueryExpression _secondQueryExpression;

        public BinaryQueryExpressionType BinaryQueryExpressionType { get; set; }

        public bool All { get; set; }

        public QueryExpression FirstQueryExpression {
            get {
                return this._firstQueryExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._firstQueryExpression = value;
            }
        }

        public QueryExpression SecondQueryExpression {
            get {
                return this._secondQueryExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._secondQueryExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FirstQueryExpression?.Accept(visitor);
            this.SecondQueryExpression?.Accept(visitor);
        }
    }
}
