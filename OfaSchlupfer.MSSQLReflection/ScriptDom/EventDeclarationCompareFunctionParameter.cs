using System;

namespace OfaSchlupfer.ScriptDom {
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
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SourceDeclaration SourceDeclaration {
            get {
                return this._sourceDeclaration;
            }
            set {
                base.UpdateTokenInfo(value);
                this._sourceDeclaration = value;
            }
        }

        public ScalarExpression EventValue {
            get {
                return this._eventValue;
            }
            set {
                base.UpdateTokenInfo(value);
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
