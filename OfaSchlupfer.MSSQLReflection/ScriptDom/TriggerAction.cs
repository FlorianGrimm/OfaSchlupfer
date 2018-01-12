using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TriggerAction : TSqlFragment {
        private TriggerActionType _triggerActionType;

        private EventTypeGroupContainer _eventTypeGroup;

        public TriggerActionType TriggerActionType {
            get {
                return this._triggerActionType;
            }

            set {
                this._triggerActionType = value;
            }
        }

        public EventTypeGroupContainer EventTypeGroup {
            get {
                return this._eventTypeGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._eventTypeGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.EventTypeGroup?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
