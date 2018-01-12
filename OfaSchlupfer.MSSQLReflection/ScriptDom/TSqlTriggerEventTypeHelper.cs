namespace OfaSchlupfer.ScriptDom
{
	public static class TSqlTriggerEventTypeHelper
	{
		private static readonly TriggerEventTypeHelper HelperInstance = TriggerEventTypeHelper.Instance;

		public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventType returnValue)
		{
			return ((OptionsHelper<EventNotificationEventType>)TSqlTriggerEventTypeHelper.HelperInstance).TryParseOption(input, TSqlTriggerEventTypeHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
		}
	}
}
