using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EventNotificationObjectScope : TSqlFragment {
        private EventNotificationTarget _target;

        private SchemaObjectName _queueName;

        public EventNotificationTarget Target {
            get {
                return this._target;
            }

            set {
                this._target = value;
            }
        }

        public SchemaObjectName QueueName {
            get {
                return this._queueName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queueName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.QueueName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
