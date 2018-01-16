namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateTypeTableStatement : CreateTypeStatement {
        private TableDefinition _definition;

        public TableDefinition Definition {
            get {
                return this._definition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._definition = value;
            }
        }

        public List<TableOption> Options { get; } = new List<TableOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Definition?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
