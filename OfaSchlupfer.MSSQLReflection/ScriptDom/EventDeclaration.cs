using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EventDeclaration : TSqlFragment {
        private EventSessionObjectName _objectName;

        private List<EventDeclarationSetParameter> _eventDeclarationSetParameters = new List<EventDeclarationSetParameter>();

        private List<EventSessionObjectName> _eventDeclarationActionParameters = new List<EventSessionObjectName>();

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

        public List<EventDeclarationSetParameter> EventDeclarationSetParameters {
            get {
                return this._eventDeclarationSetParameters;
            }
        }

        public List<EventSessionObjectName> EventDeclarationActionParameters {
            get {
                return this._eventDeclarationActionParameters;
            }
        }

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
            for (int i=0, count = this.EventDeclarationSetParameters.Count; i < count; i++) {
                this.EventDeclarationSetParameters[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.EventDeclarationActionParameters.Count; j < count2; j++) {
                this.EventDeclarationActionParameters[j].Accept(visitor);
            }
            this.EventDeclarationPredicateParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
