namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableAddTableElementStatement : AlterTableStatement {
        private ConstraintEnforcement _existingRowsCheckEnforcement;

        private TableDefinition _definition;

        public ConstraintEnforcement ExistingRowsCheckEnforcement {
            get {
                return this._existingRowsCheckEnforcement;
            }

            set {
                this._existingRowsCheckEnforcement = value;
            }
        }

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
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.Definition?.Accept(visitor);
        }
    }
}
