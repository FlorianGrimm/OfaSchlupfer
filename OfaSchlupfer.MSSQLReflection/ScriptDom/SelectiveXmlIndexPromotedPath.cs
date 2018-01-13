namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectiveXmlIndexPromotedPath : TSqlFragment {
        private Identifier _name;

        private Literal _path;

        private DataTypeReference _sQLDataType;

        private Literal _xQueryDataType;

        private IntegerLiteral _maxLength;

        private bool _isSingleton;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Literal Path {
            get {
                return this._path;
            }

            set {
                this.UpdateTokenInfo(value);
                this._path = value;
            }
        }

        public DataTypeReference SQLDataType {
            get {
                return this._sQLDataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sQLDataType = value;
            }
        }

        public Literal XQueryDataType {
            get {
                return this._xQueryDataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xQueryDataType = value;
            }
        }

        public IntegerLiteral MaxLength {
            get {
                return this._maxLength;
            }

            set {
                this.UpdateTokenInfo(value);
                this._maxLength = value;
            }
        }

        public bool IsSingleton {
            get {
                return this._isSingleton;
            }

            set {
                this._isSingleton = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Path?.Accept(visitor);
            this.SQLDataType?.Accept(visitor);
            this.XQueryDataType?.Accept(visitor);
            this.MaxLength?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
