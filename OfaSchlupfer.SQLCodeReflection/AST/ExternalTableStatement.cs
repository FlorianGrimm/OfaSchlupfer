namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExternalTableStatement : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        private Identifier _dataSource;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<ExternalTableColumnDefinition> ColumnDefinitions { get; } = new List<ExternalTableColumnDefinition>();

        public Identifier DataSource {
            get {
                return this._dataSource;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataSource = value;
            }
        }

        public List<ExternalTableOption> ExternalTableOptions { get; } = new List<ExternalTableOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.ColumnDefinitions.Accept(visitor);
            this.DataSource?.Accept(visitor);
            this.ExternalTableOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
