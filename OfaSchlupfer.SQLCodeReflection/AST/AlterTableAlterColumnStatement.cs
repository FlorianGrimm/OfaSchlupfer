namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableAlterColumnStatement : AlterTableStatement, ICollationSetter, IDataMaskingSetter {
        private Identifier _columnIdentifier;

        private DataTypeReference _dataType;

        private AlterTableAlterColumnOption _alterTableAlterColumnOption;

        private ColumnStorageOptions _storageOptions;

        private List<IndexOption> _options = new List<IndexOption>();

        private GeneratedAlwaysType? _generatedAlways;

        private ColumnEncryptionDefinition _encryption;

        private Identifier _collation;

        private StringLiteral _maskingFunction;

        public Identifier ColumnIdentifier {
            get {
                return this._columnIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._columnIdentifier = value;
            }
        }

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public AlterTableAlterColumnOption AlterTableAlterColumnOption {
            get {
                return this._alterTableAlterColumnOption;
            }

            set {
                this._alterTableAlterColumnOption = value;
            }
        }

        public ColumnStorageOptions StorageOptions {
            get {
                return this._storageOptions;
            }

            set {
                this.UpdateTokenInfo(value);
                this._storageOptions = value;
            }
        }

        public List<IndexOption> Options {
            get {
                return this._options;
            }
        }

        public GeneratedAlwaysType? GeneratedAlways {
            get {
                return this._generatedAlways;
            }

            set {
                this._generatedAlways = value;
            }
        }

        public bool IsHidden { get; set; }

        public ColumnEncryptionDefinition Encryption {
            get {
                return this._encryption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._encryption = value;
            }
        }

        public Identifier Collation {
            get {
                return this._collation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public bool IsMasked { get; set; }

        public StringLiteral MaskingFunction {
            get {
                return this._maskingFunction;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maskingFunction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.ColumnIdentifier?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.StorageOptions?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            this.Encryption?.Accept(visitor);
            this.Collation?.Accept(visitor);
            this.MaskingFunction?.Accept(visitor);
        }
    }
}
