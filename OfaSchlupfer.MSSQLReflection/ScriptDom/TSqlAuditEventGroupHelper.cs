namespace OfaSchlupfer.ScriptDom {
    public static class TSqlAuditEventGroupHelper {
        private static readonly AuditEventGroupHelper HelperInstance = AuditEventGroupHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventGroup returnValue) {
            return ((OptionsHelper<EventNotificationEventGroup>)TSqlAuditEventGroupHelper.HelperInstance).TryParseOption(input, TSqlAuditEventGroupHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }
}
