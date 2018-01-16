namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateEventNotificationStatement : TSqlStatement {
        private Identifier _name;

        private EventNotificationObjectScope _scope;

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

        public List<EventTypeGroupContainer> EventTypeGroups { get; } = new List<EventTypeGroupContainer>();

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
            this.Name?.Accept(visitor);
            this.Scope?.Accept(visitor);
            this.EventTypeGroups.Accept(visitor);
            this.BrokerService?.Accept(visitor);
            this.BrokerInstanceSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
