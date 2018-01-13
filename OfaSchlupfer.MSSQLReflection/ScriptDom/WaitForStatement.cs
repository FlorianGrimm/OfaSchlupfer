namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WaitForStatement : TSqlStatement {
        private WaitForOption _waitForOption;

        private ValueExpression _parameter;

        private ScalarExpression _timeout;

        private WaitForSupportedStatement _statement;

        public WaitForOption WaitForOption {
            get {
                return this._waitForOption;
            }

            set {
                this._waitForOption = value;
            }
        }

        public ValueExpression Parameter {
            get {
                return this._parameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameter = value;
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

        public WaitForSupportedStatement Statement {
            get {
                return this._statement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statement = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            this.Timeout?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
