namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionAlgorithmParameter : ColumnEncryptionDefinitionParameter {
        private StringLiteral _encryptionAlgorithm;

        public StringLiteral EncryptionAlgorithm {
            get {
                return this._encryptionAlgorithm;
            }

            set {
                this._encryptionAlgorithm = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
