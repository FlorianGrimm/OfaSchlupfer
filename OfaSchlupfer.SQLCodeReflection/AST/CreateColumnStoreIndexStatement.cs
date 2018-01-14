using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateColumnStoreIndexStatement : TSqlStatement {
        private Identifier _name;

        private bool? _clustered;

        private SchemaObjectName _onName;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        private BooleanExpression _filterPredicate;

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        private FileGroupOrPartitionScheme _onFileGroupOrPartitionScheme;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
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

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.FilterPredicate?.Accept(visitor);
            int j = 0;
            for (int count2 = this.IndexOptions.Count; j < count2; j++) {
                this.IndexOptions[j].Accept(visitor);
            }
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
