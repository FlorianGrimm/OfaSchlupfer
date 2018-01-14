namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SetRowCountStatement : TSqlStatement {
        private ValueExpression _numberRows;

        public ValueExpression NumberRows {
            get {
                return this._numberRows;
            }

            set {
                this.UpdateTokenInfo(value);
                this._numberRows = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.NumberRows?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
