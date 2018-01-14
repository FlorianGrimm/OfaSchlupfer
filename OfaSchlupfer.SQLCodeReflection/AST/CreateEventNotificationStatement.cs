namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateEventNotificationStatement : TSqlStatement {
        private Identifier _name;

        private EventNotificationObjectScope _scope;

        private List<EventTypeGroupContainer> _eventTypeGroups = new List<EventTypeGroupContainer>();

        private Literal _brokerService;

        private Literal _brokerInstanceSpecifier;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public EventNotificationObjectScope Scope {
            get {
                return this._scope;
            }

            set {
                this.UpdateTokenInfo(value);
                this._scope = value;
            }
        }

        public bool WithFanIn { get; set; }

        public List<EventTypeGroupContainer> EventTypeGroups {
            get {
                return this._eventTypeGroups;
            }
        }

        public Literal BrokerService {
            get {
                return this._brokerService;
            }

            set {
                this.UpdateTokenInfo(value);
                this._brokerService = value;
            }
        }

        public Literal BrokerInstanceSpecifier {
            get {
                return this._brokerInstanceSpecifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._brokerInstanceSpecifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            if (this.Scope != null) {
                this.Scope.Accept(visitor);
            }
            for (int i = 0, count = this.EventTypeGroups.Count; i < count; i++) {
                this.EventTypeGroups[i].Accept(visitor);
            }
            if (this.BrokerService != null) {
                this.BrokerService.Accept(visitor);
            }
            if (this.BrokerInstanceSpecifier != null) {
                this.BrokerInstanceSpecifier.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
