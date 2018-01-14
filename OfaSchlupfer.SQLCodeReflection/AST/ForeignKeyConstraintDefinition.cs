using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ForeignKeyConstraintDefinition : ConstraintDefinition {
        private List<Identifier> _columns = new List<Identifier>();

        private SchemaObjectName _referenceTableName;

        private List<Identifier> _referencedTableColumns = new List<Identifier>();

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public SchemaObjectName ReferenceTableName {
            get {
                return this._referenceTableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._referenceTableName = value;
            }
        }

        public List<Identifier> ReferencedTableColumns {
            get {
                return this._referencedTableColumns;
            }
        }

        public DeleteUpdateAction DeleteAction { get; set; }

        public DeleteUpdateAction UpdateAction { get; set; }

        public bool NotForReplication { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.ReferenceTableName?.Accept(visitor);
            int j = 0;
            for (int count2 = this.ReferencedTableColumns.Count; j < count2; j++) {
                this.ReferencedTableColumns[j].Accept(visitor);
            }
        }
    }
}
