#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ColumnDefinition : ColumnDefinitionBase, IDataMaskingSetter {
        private ScalarExpression _computedColumnExpression;

        private DefaultConstraintDefinition _defaultConstraint;

        private IdentityOptions _identityOptions;

        private ColumnStorageOptions _storageOptions;

        private IndexDefinition _index;

        private GeneratedAlwaysType? _generatedAlways;

        private ColumnEncryptionDefinition _encryption;

        private StringLiteral _maskingFunction;

        public ScalarExpression ComputedColumnExpression {
            get {
                return this._computedColumnExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._computedColumnExpression = value;
            }
        }

        public bool IsPersisted { get; set; }

        public DefaultConstraintDefinition DefaultConstraint {
            get {
                return this._defaultConstraint;
            }

            set {
                this.UpdateTokenInfo(value);
                this._defaultConstraint = value;
            }
        }

        public IdentityOptions IdentityOptions {
            get {
                return this._identityOptions;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identityOptions = value;
            }
        }

        public bool IsRowGuidCol { get; set; }

        public List<ConstraintDefinition> Constraints { get; } = new List<ConstraintDefinition>();

        public ColumnStorageOptions StorageOptions {
            get {
                return this._storageOptions;
            }

            set {
                this.UpdateTokenInfo(value);
                this._storageOptions = value;
            }
        }

        public IndexDefinition Index {
            get {
                return this._index;
            }

            set {
                this.UpdateTokenInfo(value);
                this._index = value;
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
            base.AcceptChildren(visitor);
            this.ComputedColumnExpression?.Accept(visitor);
            this.DefaultConstraint?.Accept(visitor);
            this.IdentityOptions?.Accept(visitor);
            this.Constraints.Accept(visitor);
            this.StorageOptions?.Accept(visitor);
            this.Index?.Accept(visitor);
            this.Encryption?.Accept(visitor);
            this.MaskingFunction?.Accept(visitor);
        }
    }
}
