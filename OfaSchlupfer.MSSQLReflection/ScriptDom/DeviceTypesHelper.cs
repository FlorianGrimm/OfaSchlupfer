namespace OfaSchlupfer.ScriptDom
{
	internal class DeviceTypesHelper : OptionsHelper<DeviceType>
	{
		internal static readonly DeviceTypesHelper Instance = new DeviceTypesHelper();

		private DeviceTypesHelper()
		{
			base.AddOptionMapping(DeviceType.Disk, "DISK");
			base.AddOptionMapping(DeviceType.Tape, "TAPE");
			base.AddOptionMapping(DeviceType.VirtualDevice, "VIRTUAL_DEVICE");
			base.AddOptionMapping(DeviceType.DatabaseSnapshot, "DATABASE_SNAPSHOT");
		}
	}
}
