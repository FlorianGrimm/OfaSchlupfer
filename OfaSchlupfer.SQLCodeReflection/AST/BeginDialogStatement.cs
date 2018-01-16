namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BeginDialogStatement : TSqlStatement {
        private VariableReference _handle;

        private IdentifierOrValueExpression _initiatorServiceName;

        private ValueExpression _targetServiceName;

        private ValueExpression _instanceSpec;

        private IdentifierOrValueExpression _contractName;

        public bool IsConversation { get; set; }

        public VariableReference Handle {
            get {
                return this._handle;
            }

            set {
                this.UpdateTokenInfo(value);
                this._handle = value;
            }
        }

        public IdentifierOrValueExpression InitiatorServiceName {
            get {
                return this._initiatorServiceName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._initiatorServiceName = value;
            }
        }

        public ValueExpression TargetServiceName {
            get {
                return this._targetServiceName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._targetServiceName = value;
            }
        }

        public ValueExpression InstanceSpec {
            get {
                return this._instanceSpec;
            }

            set {
                this.UpdateTokenInfo(value);
                this._instanceSpec = value;
            }
        }

        public IdentifierOrValueExpression ContractName {
            get {
                return this._contractName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._contractName = value;
            }
        }

        public List<DialogOption> Options { get; } = new List<DialogOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Handle?.Accept(visitor);
            this.InitiatorServiceName?.Accept(visitor);
            this.TargetServiceName?.Accept(visitor);
            this.InstanceSpec?.Accept(visitor);
            this.ContractName?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
