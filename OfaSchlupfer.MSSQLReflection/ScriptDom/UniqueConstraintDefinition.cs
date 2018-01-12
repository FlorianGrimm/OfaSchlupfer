using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UniqueConstraintDefinition : ConstraintDefinition, IFileStreamSpecifier {
        private bool? _clustered;

        private bool _isPrimaryKey;

        private List<ColumnWithSortOrder> _columns = new List<ColumnWithSortOrder>();

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        private IndexType _indexType;

        private IdentifierOrValueExpression _fileStreamOn;

        public bool? Clustered {
            get {
                return this._clustered;
            }

            set {
                this._clustered = value;
            }
        }

        public bool IsPrimaryKey {
            get {
                return this._isPrimaryKey;
            }

            set {
                this._isPrimaryKey = value;
            }
        }

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

        public IndexType IndexType {
            get {
                return this._indexType;
            }

            set {
                this._indexType = value;
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
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
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
