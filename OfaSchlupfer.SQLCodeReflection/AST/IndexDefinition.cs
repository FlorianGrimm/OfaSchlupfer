namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class IndexDefinition : TSqlStatement, IFileStreamSpecifier {
        private Identifier _name;

        private IndexType _indexType;

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private BooleanExpression _filterPredicate;

        private IdentifierOrValueExpression _fileStreamOn;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool Unique { get; set; }

        public IndexType IndexType {
            get {
                return this._indexType;
            }

            set {
                this._indexType = value;
            }
        }

        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();

        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme {
            get {
                return this._onFileGroupOrPartitionScheme;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onFileGroupOrPartitionScheme = value;
            }
        }

        public BooleanExpression FilterPredicate {
            get {
                return this._filterPredicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._filterPredicate = value;
            }
        }

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
            this.Name?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
            this.Columns.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FilterPredicate?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
