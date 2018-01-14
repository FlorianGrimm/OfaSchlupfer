namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SetUserStatement : TSqlStatement {
        private ValueExpression _userName;

        public ValueExpression UserName {
            get {
                return this._userName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._userName = value;
            }
        }

        public bool WithNoReset { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.UserName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
