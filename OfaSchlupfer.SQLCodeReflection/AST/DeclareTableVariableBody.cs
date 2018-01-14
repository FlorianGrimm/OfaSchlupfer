namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DeclareTableVariableBody : TSqlFragment {
        private Identifier _variableName;

        private TableDefinition _definition;

        public Identifier VariableName {
            get {
                return this._variableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variableName = value;
            }
        }

        public bool AsDefined { get; set; }

        public TableDefinition Definition {
            get {
                return this._definition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._definition = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.VariableName != null) {
                this.VariableName.Accept(visitor);
            }
            if (this.Definition != null) {
                this.Definition.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
