namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class EventSessionStatement : TSqlStatement {
        private Identifier _name;

        private EventSessionScope _sessionScope;

        private List<EventDeclaration> _eventDeclarations = new List<EventDeclaration>();

        private List<TargetDeclaration> _targetDeclarations = new List<TargetDeclaration>();

        private List<SessionOption> _sessionOptions = new List<SessionOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public EventSessionScope SessionScope {
            get {
                return this._sessionScope;
            }

            set {
                this._sessionScope = value;
            }
        }

        public List<EventDeclaration> EventDeclarations {
            get {
                return this._eventDeclarations;
            }
        }

        public List<TargetDeclaration> TargetDeclarations {
            get {
                return this._targetDeclarations;
            }
        }

        public List<SessionOption> SessionOptions {
            get {
                return this._sessionOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.EventDeclarations.Count; i < count; i++) {
                this.EventDeclarations[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.TargetDeclarations.Count; j < count2; j++) {
                this.TargetDeclarations[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = this.SessionOptions.Count; k < count3; k++) {
                this.SessionOptions[k].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
