using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OpenRowsetTableReference : TableReferenceWithAlias {
        private StringLiteral _providerName;

        private StringLiteral _dataSource;

        private StringLiteral _userId;

        private StringLiteral _password;

        private StringLiteral _providerString;

        private StringLiteral _query;

        private SchemaObjectName _object;

        public StringLiteral ProviderName {
            get {
                return this._providerName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._providerName = value;
            }
        }

        public StringLiteral DataSource {
            get {
                return this._dataSource;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataSource = value;
            }
        }

        public StringLiteral UserId {
            get {
                return this._userId;
            }
            set {
                base.UpdateTokenInfo(value);
                this._userId = value;
            }
        }

        public StringLiteral Password {
            get {
                return this._password;
            }
            set {
                base.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public StringLiteral ProviderString {
            get {
                return this._providerString;
            }
            set {
                base.UpdateTokenInfo(value);
                this._providerString = value;
            }
        }

        public StringLiteral Query {
            get {
                return this._query;
            }
            set {
                base.UpdateTokenInfo(value);
                this._query = value;
            }
        }

        public SchemaObjectName Object {
            get {
                return this._object;
            }
            set {
                base.UpdateTokenInfo(value);
                this._object = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProviderName?.Accept(visitor);
            this.DataSource?.Accept(visitor);
            this.UserId?.Accept(visitor);
            this.Password?.Accept(visitor);
            this.ProviderString?.Accept(visitor);
            this.Query?.Accept(visitor);
            this.Object?.Accept(visitor);
        }
    }
}
