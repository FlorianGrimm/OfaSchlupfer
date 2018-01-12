namespace OfaSchlupfer.ScriptDom
{
	internal class CursorOptionsHelper : OptionsHelper<CursorOptionKind>
	{
		internal static readonly CursorOptionsHelper Instance = new CursorOptionsHelper();

		private CursorOptionsHelper()
		{
			base.AddOptionMapping(CursorOptionKind.Local, "LOCAL");
			base.AddOptionMapping(CursorOptionKind.Global, "GLOBAL");
			base.AddOptionMapping(CursorOptionKind.Scroll, "SCROLL");
			base.AddOptionMapping(CursorOptionKind.ForwardOnly, "FORWARD_ONLY");
			base.AddOptionMapping(CursorOptionKind.Insensitive, "INSENSITIVE");
			base.AddOptionMapping(CursorOptionKind.Keyset, "KEYSET");
			base.AddOptionMapping(CursorOptionKind.Dynamic, "DYNAMIC");
			base.AddOptionMapping(CursorOptionKind.FastForward, "FAST_FORWARD");
			base.AddOptionMapping(CursorOptionKind.ScrollLocks, "SCROLL_LOCKS");
			base.AddOptionMapping(CursorOptionKind.Optimistic, "OPTIMISTIC");
			base.AddOptionMapping(CursorOptionKind.ReadOnly, "READ_ONLY");
			base.AddOptionMapping(CursorOptionKind.Static, "STATIC");
			base.AddOptionMapping(CursorOptionKind.TypeWarning, "TYPE_WARNING");
		}
	}
}
