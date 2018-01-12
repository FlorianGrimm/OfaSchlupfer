namespace OfaSchlupfer.ScriptDom {
    public static class TSqlTriggerEventGroupHelper {
        private static readonly TriggerEventGroupHelper HelperInstance = TriggerEventGroupHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventGroup returnValue) {
            return ((OptionsHelper<EventNotificationEventGroup>)TSqlTriggerEventGroupHelper.HelperInstance).TryParseOption(input, TSqlTriggerEventGroupHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }
}
