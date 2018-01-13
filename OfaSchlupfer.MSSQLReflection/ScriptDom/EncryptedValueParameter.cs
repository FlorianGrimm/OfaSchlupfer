namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EncryptedValueParameter : ColumnEncryptionKeyValueParameter {
        private BinaryLiteral _value;

        public BinaryLiteral Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }
}
