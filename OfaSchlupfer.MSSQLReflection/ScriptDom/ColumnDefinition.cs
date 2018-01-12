namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ColumnDefinition : ColumnDefinitionBase, IDataMaskingSetter {
        private ScalarExpression _computedColumnExpression;

        private bool _isPersisted;

        private DefaultConstraintDefinition _defaultConstraint;

        private IdentityOptions _identityOptions;

        private bool _isRowGuidCol;

        private List<ConstraintDefinition> _constraints = new List<ConstraintDefinition>();

        private ColumnStorageOptions _storageOptions;

        private IndexDefinition _index;

        private GeneratedAlwaysType? _generatedAlways;

        private bool _isHidden;

        private ColumnEncryptionDefinition _encryption;

        private bool _isMasked;

        private StringLiteral _maskingFunction;

        public ScalarExpression ComputedColumnExpression {
            get {
                return this._computedColumnExpression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._computedColumnExpression = value;
            }
        }

        public bool IsPersisted {
            get {
                return this._isPersisted;
            }
            set {
                this._isPersisted = value;
            }
        }

        public DefaultConstraintDefinition DefaultConstraint {
            get {
                return this._defaultConstraint;
            }
            set {
                base.UpdateTokenInfo(value);
                this._defaultConstraint = value;
            }
        }

        public IdentityOptions IdentityOptions {
            get {
                return this._identityOptions;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identityOptions = value;
            }
        }

        public bool IsRowGuidCol {
            get {
                return this._isRowGuidCol;
            }
            set {
                this._isRowGuidCol = value;
            }
        }

        public List<ConstraintDefinition> Constraints {
            get {
                return this._constraints;
            }
        }

        public ColumnStorageOptions StorageOptions {
            get {
                return this._storageOptions;
            }
            set {
                base.UpdateTokenInfo(value);
                this._storageOptions = value;
            }
        }

        public IndexDefinition Index {
            get {
                return this._index;
            }
            set {
                base.UpdateTokenInfo(value);
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

        public bool IsHidden {
            get {
                return this._isHidden;
            }
            set {
                this._isHidden = value;
            }
        }

        public ColumnEncryptionDefinition Encryption {
            get {
                return this._encryption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._encryption = value;
            }
        }

        public bool IsMasked {
            get {
                return this._isMasked;
            }
            set {
                this._isMasked = value;
            }
        }

        public StringLiteral MaskingFunction {
            get {
                return this._maskingFunction;
            }
            set {
                base.UpdateTokenInfo(value);
                this._maskingFunction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ComputedColumnExpression?.Accept(visitor);
            this.DefaultConstraint?.Accept(visitor);
            this.IdentityOptions?.Accept(visitor);
            for (int i = 0, count = this.Constraints.Count; i < count; i++) {
                this.Constraints[i].Accept(visitor);
            }
            this.StorageOptions?.Accept(visitor);
            this.Index?.Accept(visitor);
            this.Encryption?.Accept(visitor);
            this.MaskingFunction?.Accept(visitor);
        }
    }
}
