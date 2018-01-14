using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class IndexDefinition : TSqlStatement, IFileStreamSpecifier {
        private Identifier _name;

        private IndexType _indexType;

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

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

        public List<IndexOption> IndexOptions {
            get {
                return this._indexOptions;
            }
        }

        public List<ColumnWithSortOrder> Columns {
            get {
                return this._columns;
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
            for (int i = 0, count = this.IndexOptions.Count; i < count; i++) {
                this.IndexOptions[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Columns.Count; j < count2; j++) {
                this.Columns[j].Accept(visitor);
            }
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FilterPredicate?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
