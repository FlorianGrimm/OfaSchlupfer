namespace OfaSchlupfer.ScriptDom
{
	internal class DiskStatementOptionsHelper : OptionsHelper<DiskStatementOptionKind>
	{
		internal static readonly DiskStatementOptionsHelper Instance = new DiskStatementOptionsHelper();

		private DiskStatementOptionsHelper()
		{
			base.AddOptionMapping(DiskStatementOptionKind.Name, "NAME");
			base.AddOptionMapping(DiskStatementOptionKind.PhysName, "PHYSNAME");
			base.AddOptionMapping(DiskStatementOptionKind.VDevNo, "VDEVNO");
			base.AddOptionMapping(DiskStatementOptionKind.Size, "SIZE");
			base.AddOptionMapping(DiskStatementOptionKind.VStart, "VSTART");
		}
	}
}
