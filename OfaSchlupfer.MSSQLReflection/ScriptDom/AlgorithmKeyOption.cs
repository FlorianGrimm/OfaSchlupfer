namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlgorithmKeyOption : KeyOption {
        public EncryptionAlgorithm Algorithm { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
