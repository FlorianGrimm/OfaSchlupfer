namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ProcedureReference : TSqlFragment {
        private SchemaObjectName _name;

        private Literal _number;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Literal Number {
            get {
                return this._number;
            }

            set {
                this.UpdateTokenInfo(value);
                this._number = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Number?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
