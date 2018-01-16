namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropEventNotificationStatement : TSqlStatement {

        private EventNotificationObjectScope _scope;

        public List<Identifier> Notifications { get; } = new List<Identifier>();

        public EventNotificationObjectScope Scope {
            get {
                return this._scope;
            }
            set {
                this.UpdateTokenInfo(value);
                this._scope = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Notifications.Accept(visitor);
            this.Scope?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
