#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateIndexStatement : IndexStatement, IFileStreamSpecifier {
        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private BooleanExpression _filterPredicate;

        private IdentifierOrValueExpression _fileStreamOn;

        public bool Translated80SyntaxTo90 { get; set; }

        public bool Unique { get; set; }

        public bool? Clustered { get; set; }

        public List<ColumnWithSortOrder> Columns { get; } = new List<ColumnWithSortOrder>();

        public List<ColumnReferenceExpression> IncludeColumns { get; } = new List<ColumnReferenceExpression>();

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
            base.Name?.Accept(visitor);
            base.OnName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.IncludeColumns.Accept(visitor);
            base.IndexOptions.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            this.FilterPredicate?.Accept(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }
}
