namespace OfaSchlupfer.ScriptDom {
    public static class TSqlAuditEventTypeHelper {
        private static readonly AuditEventTypeHelper HelperInstance = AuditEventTypeHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventType returnValue) {
            return ((OptionsHelper<EventNotificationEventType>)TSqlAuditEventTypeHelper.HelperInstance).TryParseOption(input, TSqlAuditEventTypeHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }
}
