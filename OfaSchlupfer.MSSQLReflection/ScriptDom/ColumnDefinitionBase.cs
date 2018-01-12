namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class ColumnDefinitionBase : TSqlFragment, ICollationSetter {
        private Identifier _columnIdentifier;

        private DataTypeReference _dataType;

        private Identifier _collation;

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

        public Identifier Collation {
            get {
                return this._collation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnIdentifier?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
