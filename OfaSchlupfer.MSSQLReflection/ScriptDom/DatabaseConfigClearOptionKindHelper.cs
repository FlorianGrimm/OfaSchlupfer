namespace OfaSchlupfer.ScriptDom
{
	internal class DatabaseConfigClearOptionKindHelper : OptionsHelper<DatabaseConfigClearOptionKind>
	{
		internal static readonly DatabaseConfigClearOptionKindHelper Instance = new DatabaseConfigClearOptionKindHelper();

		private DatabaseConfigClearOptionKindHelper()
		{
			base.AddOptionMapping(DatabaseConfigClearOptionKind.ProcedureCache, "PROCEDURE_CACHE", SqlVersionFlags.TSql130AndAbove);
		}
	}
}
