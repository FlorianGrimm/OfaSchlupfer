namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ForeignKeyConstraintDefinition : ConstraintDefinition {
        private SchemaObjectName _referenceTableName;

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public SchemaObjectName ReferenceTableName {
            get {
                return this._referenceTableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._referenceTableName = value;
            }
        }

        public List<Identifier> ReferencedTableColumns { get; } = new List<Identifier>();

        public DeleteUpdateAction DeleteAction { get; set; }

        public DeleteUpdateAction UpdateAction { get; set; }

        public bool NotForReplication { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
            this.ReferenceTableName?.Accept(visitor);
            this.ReferencedTableColumns.Accept(visitor);
        }
    }
}
