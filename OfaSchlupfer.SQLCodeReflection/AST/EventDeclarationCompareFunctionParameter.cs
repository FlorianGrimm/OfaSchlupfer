namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class EventDeclarationCompareFunctionParameter : BooleanExpression {
        private EventSessionObjectName _name;

        private SourceDeclaration _sourceDeclaration;

        private ScalarExpression _eventValue;

        public EventSessionObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SourceDeclaration SourceDeclaration {
            get {
                return this._sourceDeclaration;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourceDeclaration = value;
            }
        }

        public ScalarExpression EventValue {
            get {
                return this._eventValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._eventValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.SourceDeclaration?.Accept(visitor);
            this.EventValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
