namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ViewStatementBody : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        private SelectStatement _selectStatement;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public List<ViewOption> ViewOptions { get; } = new List<ViewOption>();

        public SelectStatement SelectStatement {
            get {
                return this._selectStatement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._selectStatement = value;
            }
        }

        public bool WithCheckOption { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.ViewOptions.Accept(visitor);
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
