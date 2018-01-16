namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DbccNamedLiteral : TSqlFragment {
        private ScalarExpression _value;

        public string Name { get; set; }

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
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
