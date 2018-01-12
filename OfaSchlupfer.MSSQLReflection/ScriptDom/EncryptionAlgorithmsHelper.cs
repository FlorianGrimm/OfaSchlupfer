namespace OfaSchlupfer.ScriptDom {
    internal class EncryptionAlgorithmsHelper : OptionsHelper<EncryptionAlgorithm> {
        internal static readonly EncryptionAlgorithmsHelper Instance = new EncryptionAlgorithmsHelper();

        private EncryptionAlgorithmsHelper() {
            base.AddOptionMapping(EncryptionAlgorithm.RC2, "RC2");
            base.AddOptionMapping(EncryptionAlgorithm.RC4, "RC4");
            base.AddOptionMapping(EncryptionAlgorithm.RC4_128, "RC4_128");
            base.AddOptionMapping(EncryptionAlgorithm.Des, "DES");
            base.AddOptionMapping(EncryptionAlgorithm.TripleDes, "TRIPLE_DES");
            base.AddOptionMapping(EncryptionAlgorithm.DesX, "DESX");
            base.AddOptionMapping(EncryptionAlgorithm.Aes128, "AES_128");
            base.AddOptionMapping(EncryptionAlgorithm.Aes192, "AES_192");
            base.AddOptionMapping(EncryptionAlgorithm.Aes256, "AES_256");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa512, "RSA_512");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa1024, "RSA_1024");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa2048, "RSA_2048");
            base.AddOptionMapping(EncryptionAlgorithm.TripleDes3Key, "TRIPLE_DES_3KEY");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa3072, "RSA_3072");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa4096, "RSA_4096");
        }
    }
}
