namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class EventDeclaration : TSqlFragment {
        private EventSessionObjectName _objectName;

        private BooleanExpression _eventDeclarationPredicateParameter;

        public EventSessionObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<EventDeclarationSetParameter> EventDeclarationSetParameters { get; } = new List<EventDeclarationSetParameter>();

        public List<EventSessionObjectName> EventDeclarationActionParameters { get; } = new List<EventSessionObjectName>();

        public BooleanExpression EventDeclarationPredicateParameter {
            get {
                return this._eventDeclarationPredicateParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._eventDeclarationPredicateParameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ObjectName?.Accept(visitor);
            this.EventDeclarationSetParameters.Accept(visitor);
            this.EventDeclarationActionParameters.Accept(visitor);
            this.EventDeclarationPredicateParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
