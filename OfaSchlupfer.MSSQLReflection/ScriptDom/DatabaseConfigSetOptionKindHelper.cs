namespace OfaSchlupfer.ScriptDom
{
	internal class DatabaseConfigSetOptionKindHelper : OptionsHelper<DatabaseConfigSetOptionKind>
	{
		internal static readonly DatabaseConfigSetOptionKindHelper Instance = new DatabaseConfigSetOptionKindHelper();

		private DatabaseConfigSetOptionKindHelper()
		{
			base.AddOptionMapping(DatabaseConfigSetOptionKind.MaxDop, "MAXDOP", SqlVersionFlags.TSql130AndAbove);
			base.AddOptionMapping(DatabaseConfigSetOptionKind.LegacyCardinalityEstimate, "LEGACY_CARDINALITY_ESTIMATION", SqlVersionFlags.TSql130AndAbove);
			base.AddOptionMapping(DatabaseConfigSetOptionKind.ParameterSniffing, "PARAMETER_SNIFFING", SqlVersionFlags.TSql130AndAbove);
			base.AddOptionMapping(DatabaseConfigSetOptionKind.QueryOptimizerHotFixes, "QUERY_OPTIMIZER_HOTFIXES", SqlVersionFlags.TSql130AndAbove);
		}
	}
}
