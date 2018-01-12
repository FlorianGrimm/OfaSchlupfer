namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupEncryptionOption : BackupOption {
        public EncryptionAlgorithm Algorithm { get; set; }

        public CryptoMechanism Encryptor { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
