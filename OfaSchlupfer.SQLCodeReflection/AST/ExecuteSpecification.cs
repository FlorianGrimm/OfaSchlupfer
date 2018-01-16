namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecuteSpecification : TSqlFragment {
        private VariableReference _variable;

        private Identifier _linkedServer;

        private ExecuteContext _executeContext;

        private ExecutableEntity _executableEntity;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public Identifier LinkedServer {
            get {
                return this._linkedServer;
            }

            set {
                this.UpdateTokenInfo(value);
                this._linkedServer = value;
            }
        }

        public ExecuteContext ExecuteContext {
            get {
                return this._executeContext;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeContext = value;
            }
        }

        public ExecutableEntity ExecutableEntity {
            get {
                return this._executableEntity;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executableEntity = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.LinkedServer?.Accept(visitor);
            this.ExecuteContext?.Accept(visitor);
            this.ExecutableEntity?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
