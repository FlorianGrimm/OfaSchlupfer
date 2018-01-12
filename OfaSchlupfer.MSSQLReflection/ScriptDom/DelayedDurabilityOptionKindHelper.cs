namespace OfaSchlupfer.ScriptDom
{
	internal class DelayedDurabilityOptionKindHelper : OptionsHelper<DelayedDurabilityOptionKind>
	{
		internal static readonly DelayedDurabilityOptionKindHelper Instance = new DelayedDurabilityOptionKindHelper();

		private DelayedDurabilityOptionKindHelper()
		{
			base.AddOptionMapping(DelayedDurabilityOptionKind.Disabled, "DISABLED");
			base.AddOptionMapping(DelayedDurabilityOptionKind.Allowed, "ALLOWED");
			base.AddOptionMapping(DelayedDurabilityOptionKind.Forced, "FORCED");
		}
	}
}
