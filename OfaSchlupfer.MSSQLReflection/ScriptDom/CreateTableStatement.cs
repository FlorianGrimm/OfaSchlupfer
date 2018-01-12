namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateTableStatement : TSqlStatement, IFileStreamSpecifier {
        private SchemaObjectName _schemaObjectName;

        private bool _asEdge;

        private bool _asFileTable;

        private bool _asNode;

        private TableDefinition _definition;

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private FederationScheme _federationScheme;

        private IdentifierOrValueExpression _textImageOn;

        private List<TableOption> _options = new List<TableOption>();

        private IdentifierOrValueExpression _fileStreamOn;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public bool AsEdge {
            get {
                return this._asEdge;
            }
            set {
                this._asEdge = value;
            }
        }

        public bool AsFileTable {
            get {
                return this._asFileTable;
            }
            set {
                this._asFileTable = value;
            }
        }

        public bool AsNode {
            get {
                return this._asNode;
            }
            set {
                this._asNode = value;
            }
        }

        public TableDefinition Definition {
            get {
                return this._definition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._definition = value;
            }
        }

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme {
            get {
                return this._onFileGroupOrPartitionScheme;
            }
            set {
                base.UpdateTokenInfo(value);
                this._onFileGroupOrPartitionScheme = value;
            }
        }

        public FederationScheme FederationScheme {
            get {
                return this._federationScheme;
            }
            set {
                base.UpdateTokenInfo(value);
                this._federationScheme = value;
            }
        }

        public IdentifierOrValueExpression TextImageOn {
            get {
                return this._textImageOn;
            }
            set {
                base.UpdateTokenInfo(value);
                this._textImageOn = value;
            }
        }

        public List<TableOption> Options {
            get {
                return this._options;
            }
        }

        public IdentifierOrValueExpression FileStreamOn {
            get {
                return this._fileStreamOn;
            }
            set {
                base.UpdateTokenInfo(value);
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
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            this.FileStreamOn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
