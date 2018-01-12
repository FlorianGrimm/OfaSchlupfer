using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OdbcLiteral : Literal {
        private OdbcLiteralType _odbcLiteralType;

        private bool _isNational;

        public override LiteralType LiteralType {
            get {
                return LiteralType.Odbc;
            }
        }

        public OdbcLiteralType OdbcLiteralType {
            get {
                return this._odbcLiteralType;
            }
            set {
                this._odbcLiteralType = value;
            }
        }

        public bool IsNational {
            get {
                return this._isNational;
            }
            set {
                this._isNational = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
