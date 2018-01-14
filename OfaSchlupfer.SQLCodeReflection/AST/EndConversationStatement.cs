namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class EndConversationStatement : TSqlStatement {
        private ScalarExpression _conversation;

        private ValueExpression _errorCode;

        private ValueExpression _errorDescription;

        public ScalarExpression Conversation {
            get {
                return this._conversation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._conversation = value;
            }
        }

        public bool WithCleanup { get; set; }

        public ValueExpression ErrorCode {
            get {
                return this._errorCode;
            }

            set {
                this.UpdateTokenInfo(value);
                this._errorCode = value;
            }
        }

        public ValueExpression ErrorDescription {
            get {
                return this._errorDescription;
            }

            set {
                this.UpdateTokenInfo(value);
                this._errorDescription = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Conversation?.Accept(visitor);
            this.ErrorCode?.Accept(visitor);
            this.ErrorDescription?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
