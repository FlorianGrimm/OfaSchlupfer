namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SendStatement : TSqlStatement {
        private IdentifierOrValueExpression _messageTypeName;

        private ScalarExpression _messageBody;

        public List<ScalarExpression> ConversationHandles { get; } = new List<ScalarExpression>();

        public IdentifierOrValueExpression MessageTypeName {
            get {
                return this._messageTypeName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._messageTypeName = value;
            }
        }

        public ScalarExpression MessageBody {
            get {
                return this._messageBody;
            }

            set {
                this.UpdateTokenInfo(value);
                this._messageBody = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ConversationHandles.Accept(visitor);
            this.MessageTypeName?.Accept(visitor);
            this.MessageBody?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
