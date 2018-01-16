namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateColumnStoreIndexStatement : TSqlStatement {
        private Identifier _name;

        private bool? _clustered;

        private SchemaObjectName _onName;

        private BooleanExpression _filterPredicate;

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

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public BooleanExpression FilterPredicate {
            get {
                return this._filterPredicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._filterPredicate = value;
            }
        }

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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.FilterPredicate?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
            this.OnFileGroupOrPartitionScheme?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
