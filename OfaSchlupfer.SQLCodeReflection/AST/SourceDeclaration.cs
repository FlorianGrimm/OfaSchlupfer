namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SourceDeclaration : ScalarExpression {
        private EventSessionObjectName _value;

        public EventSessionObjectName Value {
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
