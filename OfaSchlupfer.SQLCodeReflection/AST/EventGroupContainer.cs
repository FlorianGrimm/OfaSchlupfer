namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class EventGroupContainer : EventTypeGroupContainer {
        private EventNotificationEventGroup _eventGroup;

        public EventNotificationEventGroup EventGroup {
            get {
                return this._eventGroup;
            }

            set {
                this._eventGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
