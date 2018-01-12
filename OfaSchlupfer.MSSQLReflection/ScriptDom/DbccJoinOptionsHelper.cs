namespace OfaSchlupfer.ScriptDom
{
	internal class DbccJoinOptionsHelper : OptionsHelper<DbccOptionKind>
	{
		internal static readonly DbccJoinOptionsHelper Instance = new DbccJoinOptionsHelper();

		private DbccJoinOptionsHelper()
		{
			base.AddOptionMapping(DbccOptionKind.StatHeader, "STAT_HEADER");
			base.AddOptionMapping(DbccOptionKind.DensityVector, "DENSITY_VECTOR");
		}
	}
}
