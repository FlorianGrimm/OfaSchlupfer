namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EventTypeContainer : EventTypeGroupContainer {
        private EventNotificationEventType _eventType;

        public EventNotificationEventType EventType {
            get {
                return this._eventType;
            }

            set {
                this._eventType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
