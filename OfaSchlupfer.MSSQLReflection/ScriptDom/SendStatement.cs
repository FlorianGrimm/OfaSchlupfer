using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SendStatement : TSqlStatement {
        private List<ScalarExpression> _conversationHandles = new List<ScalarExpression>();

        private IdentifierOrValueExpression _messageTypeName;

        private ScalarExpression _messageBody;

        public List<ScalarExpression> ConversationHandles {
            get {
                return this._conversationHandles;
            }
        }

        public IdentifierOrValueExpression MessageTypeName {
            get {
                return this._messageTypeName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._messageTypeName = value;
            }
        }

        public ScalarExpression MessageBody {
            get {
                return this._messageBody;
            }
            set {
                base.UpdateTokenInfo(value);
                this._messageBody = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.ConversationHandles.Count; i < count; i++) {
                this.ConversationHandles[i].Accept(visitor);
            }
            this.MessageTypeName?.Accept(visitor);
            this.MessageBody?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
