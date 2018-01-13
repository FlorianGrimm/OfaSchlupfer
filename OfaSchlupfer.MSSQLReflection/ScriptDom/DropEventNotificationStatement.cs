namespace OfaSchlupfer.ScriptDom {
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
            int i = 0;
            for (int count = this.Notifications.Count; i < count; i++) {
                this.Notifications[i].Accept(visitor);
            }
            if (this.Scope != null) {
                this.Scope.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
