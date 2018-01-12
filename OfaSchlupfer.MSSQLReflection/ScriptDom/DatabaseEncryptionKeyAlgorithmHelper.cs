namespace OfaSchlupfer.ScriptDom
{
	internal class DatabaseEncryptionKeyAlgorithmHelper : OptionsHelper<DatabaseEncryptionKeyAlgorithm>
	{
		internal static readonly DatabaseEncryptionKeyAlgorithmHelper Instance = new DatabaseEncryptionKeyAlgorithmHelper();

		private DatabaseEncryptionKeyAlgorithmHelper()
		{
			base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes128, "AES_128");
			base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes192, "AES_192");
			base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes256, "AES_256");
			base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.TripleDes3Key, "TRIPLE_DES_3KEY");
		}
	}
}
