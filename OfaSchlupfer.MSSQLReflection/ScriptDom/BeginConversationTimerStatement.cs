namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BeginConversationTimerStatement : TSqlStatement {
        private ScalarExpression _handle;

        private ScalarExpression _timeout;

        public ScalarExpression Handle {
            get {
                return this._handle;
            }

            set {
                this.UpdateTokenInfo(value);
                this._handle = value;
            }
        }

        public ScalarExpression Timeout {
            get {
                return this._timeout;
            }

            set {
                this.UpdateTokenInfo(value);
                this._timeout = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Handle?.Accept(visitor);
            this.Timeout?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
