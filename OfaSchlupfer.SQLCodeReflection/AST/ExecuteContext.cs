namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecuteContext : TSqlFragment {
        private ScalarExpression _principal;

        private ExecuteAsOption _kind;

        public ScalarExpression Principal {
            get {
                return this._principal;
            }

            set {
                this.UpdateTokenInfo(value);
                this._principal = value;
            }
        }

        public ExecuteAsOption Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Principal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
