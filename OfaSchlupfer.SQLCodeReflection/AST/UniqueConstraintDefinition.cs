namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UniqueConstraintDefinition : ConstraintDefinition, IFileStreamSpecifier {
        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private IdentifierOrValueExpression _fileStreamOn;

        public bool? Clustered { get; set; }

        public bool IsPrimaryKey { get; set; }

        public List<ColumnWithSortOrder> Columns {
            get {
                return this._columns;
            }
        }

        public List<IndexOption> IndexOptions {
            get {
                return this._indexOptions;
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

        public IndexType IndexType { get; set; }

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
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.IndexOptions.Count; j < count2; j++) {
                this.IndexOptions[j].Accept(visitor);
            }
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }
}
