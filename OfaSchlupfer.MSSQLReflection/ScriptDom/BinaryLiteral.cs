using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BinaryLiteral : Literal {
        private bool _isLargeObject;

        public override LiteralType LiteralType {
            get {
                return LiteralType.Binary;
            }
        }

        public bool IsLargeObject {
            get {
                return this._isLargeObject;
            }

            set {
                this._isLargeObject = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
