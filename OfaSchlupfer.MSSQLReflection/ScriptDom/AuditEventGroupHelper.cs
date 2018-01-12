namespace OfaSchlupfer.ScriptDom {
    internal class AuditEventGroupHelper : OptionsHelper<EventNotificationEventGroup> {
        internal static readonly AuditEventGroupHelper Instance = new AuditEventGroupHelper();

        private AuditEventGroupHelper() {
            base.AddOptionMapping(EventNotificationEventGroup.TrcClr, "TRC_CLR", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcDatabase, "TRC_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcDeprecation, "TRC_DEPRECATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcErrorsAndWarnings, "TRC_ERRORS_AND_WARNINGS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcFullText, "TRC_FULL_TEXT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcLocks, "TRC_LOCKS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcObjects, "TRC_OBJECTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcOledb, "TRC_OLEDB", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcPerformance, "TRC_PERFORMANCE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcQueryNotifications, "TRC_QUERY_NOTIFICATIONS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcSecurityAudit, "TRC_SECURITY_AUDIT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcServer, "TRC_SERVER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcStoredProcedures, "TRC_STORED_PROCEDURES", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcTSql, "TRC_TSQL", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcUserConfigurable, "TRC_USER_CONFIGURABLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.TrcAllEvents, "TRC_ALL_EVENTS", SqlVersionFlags.TSql90AndAbove);
        }
    }
}
