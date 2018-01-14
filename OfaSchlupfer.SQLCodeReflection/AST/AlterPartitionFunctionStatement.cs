namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterPartitionFunctionStatement : TSqlStatement {
        private Identifier _name;

        private ScalarExpression _boundary;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool IsSplit { get; set; }

        public ScalarExpression Boundary {
            get {
                return this._boundary;
            }

            set {
                this.UpdateTokenInfo(value);
                this._boundary = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Boundary?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
