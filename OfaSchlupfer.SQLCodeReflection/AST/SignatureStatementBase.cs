namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class SignatureStatementBase : TSqlStatement {
        private SchemaObjectName _element;

        public bool IsCounter { get; set; }

        public SignableElementKind ElementKind { get; set; }

        public SchemaObjectName Element {
            get {
                return this._element;
            }

            set {
                this.UpdateTokenInfo(value);
                this._element = value;
            }
        }

        public List<CryptoMechanism> Cryptos { get; } = new List<CryptoMechanism>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Element?.Accept(visitor);
            this.Cryptos.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
