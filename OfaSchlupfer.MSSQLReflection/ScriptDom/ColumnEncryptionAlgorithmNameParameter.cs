namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionAlgorithmNameParameter : ColumnEncryptionKeyValueParameter {
        private StringLiteral _algorithm;

        public StringLiteral Algorithm {
            get {
                return this._algorithm;
            }

            set {
                this.UpdateTokenInfo(value);
                this._algorithm = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Algorithm?.Accept(visitor);
        }
    }
}
