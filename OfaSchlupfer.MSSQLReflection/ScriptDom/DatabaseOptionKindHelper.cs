namespace OfaSchlupfer.ScriptDom
{
	internal class DatabaseOptionKindHelper : OptionsHelper<DatabaseOptionKind>
	{
		internal static readonly DatabaseOptionKindHelper Instance = new DatabaseOptionKindHelper();

		private DatabaseOptionKindHelper()
		{
			base.AddOptionMapping(DatabaseOptionKind.CompatibilityLevel, "COMPATIBILITY_LEVEL", SqlVersionFlags.TSql90AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.DefaultFullTextLanguage, "DEFAULT_FULLTEXT_LANGUAGE", SqlVersionFlags.TSql110AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE", SqlVersionFlags.TSql110AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.TwoDigitYearCutoff, "TWO_DIGIT_YEAR_CUTOFF", SqlVersionFlags.TSql110AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.Edition, "EDITION", SqlVersionFlags.TSql110AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.ServiceObjective, "SERVICE_OBJECTIVE", SqlVersionFlags.TSql120AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.QueryStore, "QUERY_STORE", SqlVersionFlags.TSql130AndAbove);
			base.AddOptionMapping(DatabaseOptionKind.CatalogCollation, "CATALOG_COLLATION", SqlVersionFlags.TSql140);
			base.AddOptionMapping(DatabaseOptionKind.AutomaticTuning, "AUTOMATIC_TUNING", SqlVersionFlags.TSql140);
		}
	}
}
