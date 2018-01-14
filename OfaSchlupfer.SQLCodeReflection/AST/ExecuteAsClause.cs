namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecuteAsClause : TSqlFragment {
        private ExecuteAsOption _executeAsOption;

        private Literal _literal;

        public ExecuteAsOption ExecuteAsOption {
            get {
                return this._executeAsOption;
            }

            set {
                this._executeAsOption = value;
            }
        }

        public Literal Literal {
            get {
                return this._literal;
            }

            set {
                this.UpdateTokenInfo(value);
                this._literal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Literal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
