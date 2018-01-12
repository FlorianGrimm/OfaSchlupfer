namespace OfaSchlupfer.ScriptDom
{
	internal class DataCompressionLevelHelper : OptionsHelper<DataCompressionLevel>
	{
		public static readonly DataCompressionLevelHelper Instance = new DataCompressionLevelHelper();

		private DataCompressionLevelHelper()
		{
			base.AddOptionMapping(DataCompressionLevel.None, "NONE");
			base.AddOptionMapping(DataCompressionLevel.Page, "PAGE");
			base.AddOptionMapping(DataCompressionLevel.Row, "ROW");
			base.AddOptionMapping(DataCompressionLevel.ColumnStore, "COLUMNSTORE");
			base.AddOptionMapping(DataCompressionLevel.ColumnStoreArchive, "COLUMNSTORE_ARCHIVE");
		}
	}
}
