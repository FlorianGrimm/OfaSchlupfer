using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GetConversationGroupStatement : WaitForSupportedStatement {
        private VariableReference _groupId;

        private SchemaObjectName _queue;

        public VariableReference GroupId {
            get {
                return this._groupId;
            }

            set {
                this.UpdateTokenInfo(value);
                this._groupId = value;
            }
        }

        public SchemaObjectName Queue {
            get {
                return this._queue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.GroupId?.Accept(visitor);
            this.Queue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
