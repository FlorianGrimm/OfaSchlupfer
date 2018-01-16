namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UniqueConstraintDefinition : ConstraintDefinition, IFileStreamSpecifier {
        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private IdentifierOrValueExpression _fileStreamOn;

        public bool? Clustered { get; set; }

        public bool IsPrimaryKey { get; set; }

        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();

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
            this.Columns.Accept(visitor);
            this.IndexOptions.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }
}
