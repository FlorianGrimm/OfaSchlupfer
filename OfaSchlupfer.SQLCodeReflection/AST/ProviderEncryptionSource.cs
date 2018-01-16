namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ProviderEncryptionSource : EncryptionSource {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<KeyOption> KeyOptions { get; } = new List<KeyOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.KeyOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
