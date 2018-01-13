namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MoveConversationStatement : TSqlStatement {
        private ScalarExpression _conversation;

        private ScalarExpression _group;

        public ScalarExpression Conversation {
            get {
                return this._conversation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._conversation = value;
            }
        }

        public ScalarExpression Group {
            get {
                return this._group;
            }

            set {
                this.UpdateTokenInfo(value);
                this._group = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Conversation?.Accept(visitor);
            this.Group?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
