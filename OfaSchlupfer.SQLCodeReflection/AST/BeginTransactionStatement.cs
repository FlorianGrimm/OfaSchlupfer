namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BeginTransactionStatement : TransactionStatement {
        private ValueExpression _markDescription;

        public bool Distributed { get; set; }

        public bool MarkDefined { get; set; }

        public ValueExpression MarkDescription {
            get {
                return this._markDescription;
            }

            set {
                this.UpdateTokenInfo(value);
                this._markDescription = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MarkDescription?.Accept(visitor);
        }
    }
}
