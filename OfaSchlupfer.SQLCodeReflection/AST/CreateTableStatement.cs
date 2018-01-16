namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateTableStatement : TSqlStatement, IFileStreamSpecifier {
        private SchemaObjectName _schemaObjectName;

        private TableDefinition _definition;

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private FederationScheme _federationScheme;

        private IdentifierOrValueExpression _textImageOn;

        private IdentifierOrValueExpression _fileStreamOn;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public bool AsEdge { get; set; }

        public bool AsFileTable { get; set; }

        public bool AsNode { get; set; }

        public TableDefinition Definition {
            get {
                return this._definition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._definition = value;
            }
        }

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme {
            get {
                return this._onFileGroupOrPartitionScheme;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onFileGroupOrPartitionScheme = value;
            }
        }

        public FederationScheme FederationScheme {
            get {
                return this._federationScheme;
            }

            set {
                this.UpdateTokenInfo(value);
                this._federationScheme = value;
            }
        }

        public IdentifierOrValueExpression TextImageOn {
            get {
                return this._textImageOn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._textImageOn = value;
            }
        }

        public List<TableOption> Options { get; } = new List<TableOption>();

        public IdentifierOrValueExpression FileStreamOn {
            get {
                return this._fileStreamOn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileStreamOn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.Definition?.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FederationScheme?.Accept(visitor);
            this.TextImageOn?.Accept(visitor);
            this.Options.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
