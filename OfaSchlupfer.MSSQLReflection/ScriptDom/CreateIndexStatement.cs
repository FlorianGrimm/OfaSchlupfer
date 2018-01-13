#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateIndexStatement : IndexStatement, IFileStreamSpecifier {
        private bool _translated80SyntaxTo90;

        private bool _unique;

        private bool? _clustered;

        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

        private List<ColumnReferenceExpression> _includeColumns = new List<ColumnReferenceExpression>();

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private BooleanExpression _filterPredicate;

        private IdentifierOrValueExpression _fileStreamOn;

        public bool Translated80SyntaxTo90 {
            get {
                return this._translated80SyntaxTo90;
            }

            set {
                this._translated80SyntaxTo90 = value;
            }
        }

        public bool Unique {
            get {
                return this._unique;
            }

            set {
                this._unique = value;
            }
        }

        public bool? Clustered {
            get {
                return this._clustered;
            }

            set {
                this._clustered = value;
            }
        }

        public List<ColumnWithSortOrder> Columns {
            get {
                return this._columns;
            }
        }

        public List<ColumnReferenceExpression> IncludeColumns {
            get {
                return this._includeColumns;
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
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            if (base.OnName != null) {
                base.OnName.Accept(visitor);
            }
            int i = 0;
            for (int count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.IncludeColumns.Count; j < count2; j++) {
                this.IncludeColumns[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = base.IndexOptions.Count; k < count3; k++) {
                base.IndexOptions[k].Accept(visitor);
            }
            if (this.OnFileGroupOrPartitionScheme != null) {
                this.OnFileGroupOrPartitionScheme.Accept(visitor);
            }
            if (this.FilterPredicate != null) {
                this.FilterPredicate.Accept(visitor);
            }
            if (this.FileStreamOn != null) {
                this.FileStreamOn.Accept(visitor);
            }
        }
    }
}
