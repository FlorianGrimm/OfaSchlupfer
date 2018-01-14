namespace OfaSchlupfer.AST {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using antlr;
    using OfaSchlupfer.AST.ScriptGenerator;

    internal abstract class OptionsHelper<OptionType> where OptionType : struct, IConvertible {
        private class OptionInfo {
            private readonly OptionType _optionValue;

            private readonly TSqlTokenType _tokenId;

            private readonly string _identifier;

            private readonly SqlVersionFlags _validVersions;

            public OptionType Value {
                get {
                    return this._optionValue;
                }
            }

            public OptionInfo(OptionType optionValue, TSqlTokenType tokenId, SqlVersionFlags appliesToVersion) {
                this._optionValue = optionValue;
                this._tokenId = tokenId;
                this._identifier = null;
                this._validVersions = appliesToVersion;
            }

            public OptionInfo(OptionType optionValue, string identifier, SqlVersionFlags validVersions) {
                this._optionValue = optionValue;
                this._tokenId = TSqlTokenType.None;
                this._identifier = identifier;
                this._validVersions = validVersions;
            }

            public void GenerateSource(ScriptWriter writer) {
                if (this._identifier != null) {
                    writer.AddIdentifierWithoutCasing(this._identifier);
                } else {
                    writer.AddKeyword(this._tokenId);
                }
            }

            public bool IsValidIn(SqlVersionFlags version) {
                return (this._validVersions & version) != SqlVersionFlags.None;
            }
        }

        private Dictionary<OptionType, OptionInfo> _optionToOptionInfo = new Dictionary<OptionType, OptionInfo>();

        private Dictionary<string, OptionInfo> _stringToOptionInfo = new Dictionary<string, OptionInfo>(StringComparer.OrdinalIgnoreCase);

        protected void AddOptionMapping(OptionType option, string identifier, SqlVersionFlags validVersions) {
            OptionInfo value = new OptionInfo(option, identifier, validVersions);
            this._optionToOptionInfo.Add(option, value);
            this._stringToOptionInfo.Add(identifier, value);
        }

        protected void AddOptionMapping(OptionType option, TSqlTokenType tokenId, SqlVersionFlags validVersions) {
            OptionInfo value = new OptionInfo(option, tokenId, validVersions);
            this._optionToOptionInfo.Add(option, value);
            this._stringToOptionInfo.Add(ScriptGeneratorSupporter.GetLowerCase(tokenId), value);
        }

        protected void AddOptionMapping(OptionType option, string identifier) {
            this.AddOptionMapping(option, identifier, SqlVersionFlags.TSqlAll);
        }

        protected void AddOptionMapping(OptionType option, TSqlTokenType tokenId) {
            this.AddOptionMapping(option, tokenId, SqlVersionFlags.TSqlAll);
        }

        internal bool IsValidKeyword(IToken token) {
            return this._stringToOptionInfo.ContainsKey(token.getText());
        }

        internal SqlVersionFlags MapSqlVersionToSqlVersionFlags(SqlVersion sqlVersion) {
            switch (sqlVersion) {
                case SqlVersion.Sql80:
                    return SqlVersionFlags.TSql80;
                case SqlVersion.Sql90:
                    return SqlVersionFlags.TSql90;
                case SqlVersion.Sql100:
                    return SqlVersionFlags.TSql100;
                case SqlVersion.Sql110:
                    return SqlVersionFlags.TSql110;
                case SqlVersion.Sql120:
                    return SqlVersionFlags.TSql120;
                case SqlVersion.Sql130:
                    return SqlVersionFlags.TSql130;
                case SqlVersion.Sql140:
                    return SqlVersionFlags.TSql140;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SqlScriptGeneratorResource.UnknownEnumValue, new object[2]
                    {
                    sqlVersion,
                    "SqlVersion"
                    }), "sqlVersion");
            }
        }

        internal OptionType ParseOption(IToken token, SqlVersionFlags version) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._stringToOptionInfo.TryGetValue(token.getText(), out optionInfo) && optionInfo.IsValidIn(version)) {
                return optionInfo.Value;
            }
            throw this.GetMatchingException(token);
        }

        internal bool TryParseOption(IToken token, SqlVersionFlags version, out OptionType returnValue) {
            return this.TryParseOption(token.getText(), version, out returnValue);
        }

        internal bool TryParseOption(string tokenString, SqlVersionFlags version, out OptionType returnValue) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._stringToOptionInfo.TryGetValue(tokenString, out optionInfo) && optionInfo.IsValidIn(version)) {
                returnValue = optionInfo.Value;
                return true;
            }
            returnValue = default(OptionType);
            return false;
        }

        internal OptionType ParseOption(IToken token) {
            return this.ParseOption(token, SqlVersionFlags.TSqlAll);
        }

        internal bool TryParseOption(IToken token, out OptionType returnValue) {
            return this.TryParseOption(token, SqlVersionFlags.TSqlAll, out returnValue);
        }

        protected virtual TSqlParseErrorException GetMatchingException(IToken token) {
            return TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        internal void GenerateSourceForOption(ScriptWriter writer, OptionType option) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._optionToOptionInfo.TryGetValue(option, out optionInfo)) {
                optionInfo.GenerateSource(writer);
            }
        }

        internal bool TryGenerateSourceForOption(ScriptWriter writer, OptionType option) {
            OptionInfo optionInfo = default(OptionInfo);
            if (this._optionToOptionInfo.TryGetValue(option, out optionInfo)) {
                optionInfo.GenerateSource(writer);
                return true;
            }
            return false;
        }

        internal void GenerateCommaSeparatedFlagOptions(ScriptWriter writer, OptionType options) {
            bool flag = true;
            long num = options.ToInt64(CultureInfo.InvariantCulture.NumberFormat);
            foreach (OptionType value in Enum.GetValues(typeof(OptionType))) {
                long num2 = value.ToInt64(CultureInfo.InvariantCulture.NumberFormat);
                if (!value.Equals(default(OptionType)) && (num & num2) == num2) {
                    if (flag) {
                        flag = false;
                    } else {
                        writer.AddKeyword(TSqlTokenType.Comma);
                        writer.AddToken(ScriptGeneratorSupporter.CreateWhitespaceToken(1));
                    }
                    this.GenerateSourceForOption(writer, value);
                }
            }
        }
    }

    internal class AbortAfterWaitTypeHelper : OptionsHelper<AbortAfterWaitType> {
        public static readonly AbortAfterWaitTypeHelper Instance = new AbortAfterWaitTypeHelper();

        private AbortAfterWaitTypeHelper() {
            base.AddOptionMapping(AbortAfterWaitType.None, "NONE");
            base.AddOptionMapping(AbortAfterWaitType.Blockers, "BLOCKERS");
            base.AddOptionMapping(AbortAfterWaitType.Self, "SELF");
        }
    }

    internal class AllowConnectionsOptionsHelper : OptionsHelper<AllowConnectionsOptionKind> {
        public static readonly AllowConnectionsOptionsHelper Instance = new AllowConnectionsOptionsHelper();

        private AllowConnectionsOptionsHelper() {
            base.AddOptionMapping(AllowConnectionsOptionKind.All, "ALL");
            base.AddOptionMapping(AllowConnectionsOptionKind.No, "NO");
            base.AddOptionMapping(AllowConnectionsOptionKind.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(AllowConnectionsOptionKind.ReadWrite, "READ_WRITE");
        }
    }

    internal class AlterAvailabilityGroupActionTypeHelper : OptionsHelper<AlterAvailabilityGroupActionType> {
        public static readonly AlterAvailabilityGroupActionTypeHelper Instance = new AlterAvailabilityGroupActionTypeHelper();

        private AlterAvailabilityGroupActionTypeHelper() {
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Failover, "FAILOVER");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.ForceFailoverAllowDataLoss, "FORCE_FAILOVER_ALLOW_DATA_LOSS");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Join, TSqlTokenType.Join);
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Offline, "OFFLINE");
            base.AddOptionMapping(AlterAvailabilityGroupActionType.Online, "ONLINE");
        }
    }

    internal class AlterIndexTypeHelper : OptionsHelper<AlterIndexType> {
        internal static readonly AlterIndexTypeHelper Instance = new AlterIndexTypeHelper();

        private AlterIndexTypeHelper() {
            base.AddOptionMapping(AlterIndexType.Disable, "DISABLE");
            base.AddOptionMapping(AlterIndexType.Rebuild, "REBUILD");
            base.AddOptionMapping(AlterIndexType.Reorganize, "REORGANIZE");
            base.AddOptionMapping(AlterIndexType.Set, TSqlTokenType.Set);
            base.AddOptionMapping(AlterIndexType.Abort, "ABORT", SqlVersionFlags.TSql140);
            base.AddOptionMapping(AlterIndexType.Pause, "PAUSE", SqlVersionFlags.TSql140);
            base.AddOptionMapping(AlterIndexType.Resume, "RESUME", SqlVersionFlags.TSql140);
        }
    }

    internal class AlterServerConfigurationBufferPoolExtensionOptionHelper : OptionsHelper<AlterServerConfigurationBufferPoolExtensionOptionKind> {
        internal static readonly AlterServerConfigurationBufferPoolExtensionOptionHelper Instance = new AlterServerConfigurationBufferPoolExtensionOptionHelper();

        private AlterServerConfigurationBufferPoolExtensionOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationBufferPoolExtensionOptionKind.FileName, "FILENAME");
            base.AddOptionMapping(AlterServerConfigurationBufferPoolExtensionOptionKind.Size, "SIZE");
        }
    }

    internal class AlterServerConfigurationDiagnosticsLogOptionHelper : OptionsHelper<AlterServerConfigurationDiagnosticsLogOptionKind> {
        internal static readonly AlterServerConfigurationDiagnosticsLogOptionHelper Instance = new AlterServerConfigurationDiagnosticsLogOptionHelper();

        private AlterServerConfigurationDiagnosticsLogOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.Path, "PATH");
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.MaxSize, "MAX_SIZE");
            base.AddOptionMapping(AlterServerConfigurationDiagnosticsLogOptionKind.MaxFiles, "MAX_FILES");
        }
    }

    internal class AlterServerConfigurationFailoverClusterPropertyOptionHelper : OptionsHelper<AlterServerConfigurationFailoverClusterPropertyOptionKind> {
        internal static readonly AlterServerConfigurationFailoverClusterPropertyOptionHelper Instance = new AlterServerConfigurationFailoverClusterPropertyOptionHelper();

        private AlterServerConfigurationFailoverClusterPropertyOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.VerboseLogging, "VerboseLogging");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpFlags, "SqlDumperDumpFlags");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpPath, "SqlDumperDumpPath");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.SqlDumperDumpTimeout, "SqlDumperDumpTimeout");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.FailureConditionLevel, "FailureConditionLevel");
            base.AddOptionMapping(AlterServerConfigurationFailoverClusterPropertyOptionKind.HealthCheckTimeout, "HealthCheckTimeout");
        }
    }

    internal class AlterServerConfigurationHadrClusterOptionHelper : OptionsHelper<AlterServerConfigurationHadrClusterOptionKind> {
        internal static readonly AlterServerConfigurationHadrClusterOptionHelper Instance = new AlterServerConfigurationHadrClusterOptionHelper();

        private AlterServerConfigurationHadrClusterOptionHelper() {
            base.AddOptionMapping(AlterServerConfigurationHadrClusterOptionKind.Context, "CONTEXT");
        }
    }

    internal class ApplicationRoleOptionHelper : OptionsHelper<ApplicationRoleOptionKind> {
        internal static readonly ApplicationRoleOptionHelper Instance = new ApplicationRoleOptionHelper();

        private ApplicationRoleOptionHelper() {
            base.AddOptionMapping(ApplicationRoleOptionKind.DefaultSchema, "DEFAULT_SCHEMA");
            base.AddOptionMapping(ApplicationRoleOptionKind.Password, "PASSWORD");
            base.AddOptionMapping(ApplicationRoleOptionKind.Name, "NAME");
            base.AddOptionMapping(ApplicationRoleOptionKind.Login, "LOGIN");
        }
    }

    [System.Serializable]
    internal class AtomicBlockOptionHelper : OptionsHelper<AtomicBlockOptionKind> {
        internal static readonly AtomicBlockOptionHelper Instance = new AtomicBlockOptionHelper();

        private AtomicBlockOptionHelper() {
            base.AddOptionMapping(AtomicBlockOptionKind.DateFirst, "DATEFIRST", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.DateFormat, "DATEFORMAT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.DelayedDurability, "DELAYED_DURABILITY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.IsolationLevel, "TRANSACTION ISOLATION LEVEL", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.Language, "LANGUAGE", SqlVersionFlags.TSql120AndAbove);
        }
    }

    internal class AttachModeHelper : OptionsHelper<AttachMode> {
        internal static readonly AttachModeHelper Instance = new AttachModeHelper();

        private AttachModeHelper() {
            base.AddOptionMapping(AttachMode.Attach, "ATTACH");
            base.AddOptionMapping(AttachMode.AttachRebuildLog, "ATTACH_REBUILD_LOG");
            base.AddOptionMapping(AttachMode.AttachForceRebuildLog, "ATTACH_FORCE_REBUILD_LOG");
            base.AddOptionMapping(AttachMode.Load, "LOAD");
        }
    }

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

    internal class AuditEventTypeHelper : OptionsHelper<EventNotificationEventType> {
        internal static readonly AuditEventTypeHelper Instance = new AuditEventTypeHelper();

        private AuditEventTypeHelper() {
            base.AddOptionMapping(EventNotificationEventType.AssemblyLoad, "ASSEMBLY_LOAD", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAddDBUserEvent, "AUDIT_ADD_DB_USER_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAddLoginEvent, "AUDIT_ADDLOGIN_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAddLoginToServerRoleEvent, "AUDIT_ADD_LOGIN_TO_SERVER_ROLE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAddMemberToDBRoleEvent, "AUDIT_ADD_MEMBER_TO_DB_ROLE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAddRoleEvent, "AUDIT_ADD_ROLE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditAppRoleChangePasswordEvent, "AUDIT_APP_ROLE_CHANGE_PASSWORD_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditBackupRestoreEvent, "AUDIT_BACKUP_RESTORE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditChangeAuditEvent, "AUDIT_CHANGE_AUDIT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditChangeDatabaseOwner, "AUDIT_CHANGE_DATABASE_OWNER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseManagementEvent, "AUDIT_DATABASE_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseObjectAccessEvent, "AUDIT_DATABASE_OBJECT_ACCESS_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseObjectGdrEvent, "AUDIT_DATABASE_OBJECT_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseObjectManagementEvent, "AUDIT_DATABASE_OBJECT_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseObjectTakeOwnershipEvent, "AUDIT_DATABASE_OBJECT_TAKE_OWNERSHIP_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseOperationEvent, "AUDIT_DATABASE_OPERATION_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabasePrincipalImpersonationEvent, "AUDIT_DATABASE_PRINCIPAL_IMPERSONATION_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabasePrincipalManagementEvent, "AUDIT_DATABASE_PRINCIPAL_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDatabaseScopeGdrEvent, "AUDIT_DATABASE_SCOPE_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditDbccEvent, "AUDIT_DBCC_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLogin, "AUDIT_LOGIN", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLoginChangePasswordEvent, "AUDIT_LOGIN_CHANGE_PASSWORD_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLoginChangePropertyEvent, "AUDIT_LOGIN_CHANGE_PROPERTY_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLoginFailed, "AUDIT_LOGIN_FAILED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLoginGdrEvent, "AUDIT_LOGIN_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditLogout, "AUDIT_LOGOUT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditSchemaObjectAccessEvent, "AUDIT_SCHEMA_OBJECT_ACCESS_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditSchemaObjectGdrEvent, "AUDIT_SCHEMA_OBJECT_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditSchemaObjectManagementEvent, "AUDIT_SCHEMA_OBJECT_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditSchemaObjectTakeOwnershipEvent, "AUDIT_SCHEMA_OBJECT_TAKE_OWNERSHIP_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerAlterTraceEvent, "AUDIT_SERVER_ALTER_TRACE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerObjectGdrEvent, "AUDIT_SERVER_OBJECT_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerObjectManagementEvent, "AUDIT_SERVER_OBJECT_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerObjectTakeOwnershipEvent, "AUDIT_SERVER_OBJECT_TAKE_OWNERSHIP_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerOperationEvent, "AUDIT_SERVER_OPERATION_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerPrincipalImpersonationEvent, "AUDIT_SERVER_PRINCIPAL_IMPERSONATION_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerPrincipalManagementEvent, "AUDIT_SERVER_PRINCIPAL_MANAGEMENT_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditServerScopeGdrEvent, "AUDIT_SERVER_SCOPE_GDR_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.BlockedProcessReport, "BLOCKED_PROCESS_REPORT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.BrokerQueueDisabled, "BROKER_QUEUE_DISABLED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DataFileAutoGrow, "DATA_FILE_AUTO_GROW", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DataFileAutoShrink, "DATA_FILE_AUTO_SHRINK", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DatabaseMirroringStateChange, "DATABASE_MIRRORING_STATE_CHANGE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DeadlockGraph, "DEADLOCK_GRAPH", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DeprecationAnnouncement, "DEPRECATION_ANNOUNCEMENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DeprecationFinalSupport, "DEPRECATION_FINAL_SUPPORT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ErrorLog, "ERRORLOG", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.EventLog, "EVENTLOG", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.Exception, "EXCEPTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ExchangeSpillEvent, "EXCHANGE_SPILL_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ExecutionWarnings, "EXECUTION_WARNINGS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.FtCrawlAborted, "FT_CRAWL_ABORTED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.FtCrawlStarted, "FT_CRAWL_STARTED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.FtCrawlStopped, "FT_CRAWL_STOPPED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.HashWarning, "HASH_WARNING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.LockDeadlock, "LOCK_DEADLOCK", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.LockDeadlockChain, "LOCK_DEADLOCK_CHAIN", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.LockEscalation, "LOCK_ESCALATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.LogFileAutoGrow, "LOG_FILE_AUTO_GROW", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.LogFileAutoShrink, "LOG_FILE_AUTO_SHRINK", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.MissingColumnStatistics, "MISSING_COLUMN_STATISTICS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.MissingJoinPredicate, "MISSING_JOIN_PREDICATE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.MountTape, "MOUNT_TAPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ObjectAltered, "OBJECT_ALTERED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ObjectCreated, "OBJECT_CREATED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ObjectDeleted, "OBJECT_DELETED", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.OledbCallEvent, "OLEDB_CALL_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.OledbDataReadEvent, "OLEDB_DATAREAD_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.OledbErrors, "OLEDB_ERRORS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.OledbProviderInformation, "OLEDB_PROVIDER_INFORMATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.OledbQueryInterfaceEvent, "OLEDB_QUERYINTERFACE_EVENT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.QnDynamics, "QN__DYNAMICS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.QnParameterTable, "QN__PARAMETER_TABLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.QnSubscription, "QN__SUBSCRIPTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.QnTemplate, "QN__TEMPLATE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.QueueActivation, "QUEUE_ACTIVATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ServerMemoryChange, "SERVER_MEMORY_CHANGE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ShowPlanAllForQueryCompile, "SHOWPLAN_ALL_FOR_QUERY_COMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ShowPlanXmlForQueryCompile, "SHOWPLAN_XML_FOR_QUERY_COMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ShowPlanXml, "SHOWPLAN_XML", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.ShowPlanXmlStatisticsProfile, "SHOWPLAN_XML_STATISTICS_PROFILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SortWarnings, "SORT_WARNINGS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SpCacheInsert, "SP_CACHEINSERT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SpCacheMiss, "SP_CACHEMISS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SpCacheRemove, "SP_CACHEREMOVE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SpRecompile, "SP_RECOMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.SqlStmtRecompile, "SQL_STMTRECOMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.TraceFileClose, "TRACE_FILE_CLOSE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserErrorMessage, "USER_ERROR_MESSAGE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable0, "USERCONFIGURABLE_0", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable1, "USERCONFIGURABLE_1", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable2, "USERCONFIGURABLE_2", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable3, "USERCONFIGURABLE_3", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable4, "USERCONFIGURABLE_4", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable5, "USERCONFIGURABLE_5", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable6, "USERCONFIGURABLE_6", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable7, "USERCONFIGURABLE_7", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable8, "USERCONFIGURABLE_8", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UserConfigurable9, "USERCONFIGURABLE_9", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.XQueryStaticType, "XQUERY_STATIC_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AuditFullText, "AUDIT_FULLTEXT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.BitmapWarning, "BITMAP_WARNING", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CpuThresholdExceeded, "CPU_THRESHOLD_EXCEEDED", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DatabaseSuspectDataPage, "DATABASE_SUSPECT_DATA_PAGE", SqlVersionFlags.TSql100AndAbove);
        }
    }

    internal class AuthenticationTypesHelper : OptionsHelper<AuthenticationTypes> {
        internal static readonly AuthenticationTypesHelper Instance = new AuthenticationTypesHelper();

        private AuthenticationTypesHelper() {
            base.AddOptionMapping(AuthenticationTypes.Basic, "BASIC");
            base.AddOptionMapping(AuthenticationTypes.Digest, "DIGEST");
            base.AddOptionMapping(AuthenticationTypes.Integrated, "INTEGRATED");
            base.AddOptionMapping(AuthenticationTypes.Kerberos, "KERBEROS");
            base.AddOptionMapping(AuthenticationTypes.Ntlm, "NTLM");
        }
    }
    [System.Serializable]
    internal class AutomaticTuningCreateIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningCreateIndexOptionHelper Instance = new AutomaticTuningCreateIndexOptionHelper();

        private AutomaticTuningCreateIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }

    [System.Serializable]
    internal class AutomaticTuningDropIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningDropIndexOptionHelper Instance = new AutomaticTuningDropIndexOptionHelper();

        private AutomaticTuningDropIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }

    [System.Serializable]
    internal class AutomaticTuningForceLastGoodPlanOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningForceLastGoodPlanOptionHelper Instance = new AutomaticTuningForceLastGoodPlanOptionHelper();

        private AutomaticTuningForceLastGoodPlanOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }

    [System.Serializable]
    internal class AutomaticTuningMaintainIndexOptionHelper : OptionsHelper<AutomaticTuningOptionState> {
        internal static readonly AutomaticTuningMaintainIndexOptionHelper Instance = new AutomaticTuningMaintainIndexOptionHelper();

        private AutomaticTuningMaintainIndexOptionHelper() {
            base.AddOptionMapping(AutomaticTuningOptionState.Off, "OFF");
            base.AddOptionMapping(AutomaticTuningOptionState.On, "ON");
            base.AddOptionMapping(AutomaticTuningOptionState.Default, "DEFAULT");
        }
    }

    [System.Serializable]
    internal class AutomaticTuningOptionsHelper : OptionsHelper<AutomaticTuningOptionKind> {
        internal static readonly AutomaticTuningOptionsHelper Instance = new AutomaticTuningOptionsHelper();

        private AutomaticTuningOptionsHelper() {
            base.AddOptionMapping(AutomaticTuningOptionKind.Force_Last_Good_Plan, "FORCE_LAST_GOOD_PLAN");
            base.AddOptionMapping(AutomaticTuningOptionKind.Create_Index, "CREATE_INDEX");
            base.AddOptionMapping(AutomaticTuningOptionKind.Drop_Index, "DROP_INDEX");
            base.AddOptionMapping(AutomaticTuningOptionKind.Maintain_Index, "MAINTAIN_INDEX");
        }
    }

    internal class AvailabilityReplicaOptionsHelper : OptionsHelper<AvailabilityReplicaOptionKind> {
        public static readonly AvailabilityReplicaOptionsHelper Instance = new AvailabilityReplicaOptionsHelper();

        private AvailabilityReplicaOptionsHelper() {
            base.AddOptionMapping(AvailabilityReplicaOptionKind.ApplyDelay, "APPLY_DELAY");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.AvailabilityMode, "AVAILABILITY_MODE");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.EndpointUrl, "ENDPOINT_URL");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.SecondaryRole, "SECONDARY_ROLE");
            base.AddOptionMapping(AvailabilityReplicaOptionKind.SessionTimeout, "SESSION_TIMEOUT");
        }
    }

    internal class BackupOptionsNoValueHelper : OptionsHelper<BackupOptionKind> {
        internal static readonly BackupOptionsNoValueHelper Instance = new BackupOptionsNoValueHelper();

        private BackupOptionsNoValueHelper() {
            base.AddOptionMapping(BackupOptionKind.NoRecovery, "NORECOVERY");
            base.AddOptionMapping(BackupOptionKind.TruncateOnly, "TRUNCATE_ONLY");
            base.AddOptionMapping(BackupOptionKind.NoLog, "NO_LOG");
            base.AddOptionMapping(BackupOptionKind.NoTruncate, "NO_TRUNCATE");
            base.AddOptionMapping(BackupOptionKind.Unload, "UNLOAD");
            base.AddOptionMapping(BackupOptionKind.NoUnload, "NOUNLOAD");
            base.AddOptionMapping(BackupOptionKind.Rewind, "REWIND");
            base.AddOptionMapping(BackupOptionKind.NoRewind, "NOREWIND");
            base.AddOptionMapping(BackupOptionKind.Format, "FORMAT");
            base.AddOptionMapping(BackupOptionKind.NoFormat, "NOFORMAT");
            base.AddOptionMapping(BackupOptionKind.Init, "INIT");
            base.AddOptionMapping(BackupOptionKind.NoInit, "NOINIT");
            base.AddOptionMapping(BackupOptionKind.Skip, "SKIP");
            base.AddOptionMapping(BackupOptionKind.NoSkip, "NOSKIP");
            base.AddOptionMapping(BackupOptionKind.Restart, "RESTART");
            base.AddOptionMapping(BackupOptionKind.Stats, "STATS");
            base.AddOptionMapping(BackupOptionKind.Differential, "DIFFERENTIAL");
            base.AddOptionMapping(BackupOptionKind.Snapshot, "SNAPSHOT");
            base.AddOptionMapping(BackupOptionKind.Checksum, "CHECKSUM");
            base.AddOptionMapping(BackupOptionKind.NoChecksum, "NO_CHECKSUM");
            base.AddOptionMapping(BackupOptionKind.ContinueAfterError, "CONTINUE_AFTER_ERROR");
            base.AddOptionMapping(BackupOptionKind.StopOnError, "STOP_ON_ERROR");
            base.AddOptionMapping(BackupOptionKind.CopyOnly, "COPY_ONLY");
            base.AddOptionMapping(BackupOptionKind.Compression, "COMPRESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(BackupOptionKind.NoCompression, "NO_COMPRESSION", SqlVersionFlags.TSql100AndAbove);
        }
    }

    internal class BackupOptionsWithValueHelper : OptionsHelper<BackupOptionKind> {
        internal static readonly BackupOptionsWithValueHelper Instance = new BackupOptionsWithValueHelper();

        private BackupOptionsWithValueHelper() {
            base.AddOptionMapping(BackupOptionKind.Stats, "STATS");
            base.AddOptionMapping(BackupOptionKind.Standby, "STANDBY");
            base.AddOptionMapping(BackupOptionKind.ExpireDate, "EXPIREDATE");
            base.AddOptionMapping(BackupOptionKind.RetainDays, "RETAINDAYS");
            base.AddOptionMapping(BackupOptionKind.Name, "NAME");
            base.AddOptionMapping(BackupOptionKind.Description, "DESCRIPTION");
            base.AddOptionMapping(BackupOptionKind.Password, "PASSWORD", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(BackupOptionKind.MediaName, "MEDIANAME");
            base.AddOptionMapping(BackupOptionKind.MediaDescription, "MEDIADESCRIPTION");
            base.AddOptionMapping(BackupOptionKind.MediaPassword, "MEDIAPASSWORD", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(BackupOptionKind.BlockSize, "BLOCKSIZE");
            base.AddOptionMapping(BackupOptionKind.BufferCount, "BUFFERCOUNT");
            base.AddOptionMapping(BackupOptionKind.MaxTransferSize, "MAXTRANSFERSIZE");
            base.AddOptionMapping(BackupOptionKind.EnhancedIntegrity, "ENHANCEDINTEGRITY");
        }
    }

    internal class BoundingBoxParameterTypeHelper : OptionsHelper<BoundingBoxParameterType> {
        internal static readonly BoundingBoxParameterTypeHelper Instance = new BoundingBoxParameterTypeHelper();

        private BoundingBoxParameterTypeHelper() {
            base.AddOptionMapping(BoundingBoxParameterType.XMin, "XMIN");
            base.AddOptionMapping(BoundingBoxParameterType.YMin, "YMIN");
            base.AddOptionMapping(BoundingBoxParameterType.XMax, "XMAX");
            base.AddOptionMapping(BoundingBoxParameterType.YMax, "YMAX");
        }
    }

    [System.Serializable]
    internal class BrokerPriorityParameterHelper : OptionsHelper<BrokerPriorityParameterType> {
        internal static readonly BrokerPriorityParameterHelper Instance = new BrokerPriorityParameterHelper();

        private BrokerPriorityParameterHelper() {
            base.AddOptionMapping(BrokerPriorityParameterType.ContractName, "CONTRACT_NAME");
            base.AddOptionMapping(BrokerPriorityParameterType.LocalServiceName, "LOCAL_SERVICE_NAME");
            base.AddOptionMapping(BrokerPriorityParameterType.PriorityLevel, "PRIORITY_LEVEL");
            base.AddOptionMapping(BrokerPriorityParameterType.RemoteServiceName, "REMOTE_SERVICE_NAME");
        }
    }

    internal class BulkInsertFlagOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertFlagOptionsHelper Instance = new BulkInsertFlagOptionsHelper();

        private BulkInsertFlagOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.NoTriggers, "NO_TRIGGERS");
            base.AddOptionMapping(BulkInsertOptionKind.KeepIdentity, "KEEPIDENTITY");
            base.AddOptionMapping(BulkInsertOptionKind.KeepNulls, "KEEPNULLS");
            base.AddOptionMapping(BulkInsertOptionKind.TabLock, "TABLOCK");
            base.AddOptionMapping(BulkInsertOptionKind.CheckConstraints, "CHECK_CONSTRAINTS");
            base.AddOptionMapping(BulkInsertOptionKind.FireTriggers, "FIRE_TRIGGERS");
            base.AddOptionMapping(BulkInsertOptionKind.IncludeHidden, "INCLUDE_HIDDEN");
        }
    }

    internal class BulkInsertIntOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertIntOptionsHelper Instance = new BulkInsertIntOptionsHelper();

        private BulkInsertIntOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.MaxErrors, "MAXERRORS");
            base.AddOptionMapping(BulkInsertOptionKind.FirstRow, "FIRSTROW");
            base.AddOptionMapping(BulkInsertOptionKind.LastRow, "LASTROW");
            base.AddOptionMapping(BulkInsertOptionKind.BatchSize, "BATCHSIZE");
            base.AddOptionMapping(BulkInsertOptionKind.CodePage, "CODEPAGE");
            base.AddOptionMapping(BulkInsertOptionKind.RowsPerBatch, "ROWS_PER_BATCH");
            base.AddOptionMapping(BulkInsertOptionKind.KilobytesPerBatch, "KILOBYTES_PER_BATCH");
        }
    }

    internal class BulkInsertStringOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertStringOptionsHelper Instance = new BulkInsertStringOptionsHelper();

        private BulkInsertStringOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.FieldTerminator, "FIELDTERMINATOR");
            base.AddOptionMapping(BulkInsertOptionKind.RowTerminator, "ROWTERMINATOR");
            base.AddOptionMapping(BulkInsertOptionKind.FormatFile, "FORMATFILE");
            base.AddOptionMapping(BulkInsertOptionKind.ErrorFile, "ERRORFILE");
            base.AddOptionMapping(BulkInsertOptionKind.CodePage, "CODEPAGE");
            base.AddOptionMapping(BulkInsertOptionKind.DataFileType, "DATAFILETYPE");
            base.AddOptionMapping(BulkInsertOptionKind.DataSource, "DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.FormatDataSource, "FORMATFILE_DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.ErrorDataSource, "ERRORFILE_DATA_SOURCE");
            base.AddOptionMapping(BulkInsertOptionKind.DataFileFormat, "FORMAT", SqlVersionFlags.TSql140);
            base.AddOptionMapping(BulkInsertOptionKind.FieldQuote, "FIELDQUOTE", SqlVersionFlags.TSql140);
        }
    }

    internal class CertificateOptionKindsHelper : OptionsHelper<CertificateOptionKinds> {
        internal static readonly CertificateOptionKindsHelper Instance = new CertificateOptionKindsHelper();

        private CertificateOptionKindsHelper() {
            base.AddOptionMapping(CertificateOptionKinds.Subject, "SUBJECT");
            base.AddOptionMapping(CertificateOptionKinds.StartDate, "START_DATE");
            base.AddOptionMapping(CertificateOptionKinds.ExpiryDate, "EXPIRY_DATE");
        }
    }

    internal class CompressionDelayTimeUnitHelper : OptionsHelper<CompressionDelayTimeUnit> {
        internal static readonly CompressionDelayTimeUnitHelper Instance = new CompressionDelayTimeUnitHelper();

        private CompressionDelayTimeUnitHelper() {
            base.AddOptionMapping(CompressionDelayTimeUnit.Unitless, string.Empty);
            base.AddOptionMapping(CompressionDelayTimeUnit.Minute, "MINUTE");
            base.AddOptionMapping(CompressionDelayTimeUnit.Minutes, "MINUTES");
        }
    }
    internal class ComputeFunctionTypeHelper : OptionsHelper<ComputeFunctionType> {
        internal static readonly ComputeFunctionTypeHelper Instance = new ComputeFunctionTypeHelper();

        private ComputeFunctionTypeHelper() {
            base.AddOptionMapping(ComputeFunctionType.Count, "COUNT");
            base.AddOptionMapping(ComputeFunctionType.CountBig, "COUNT_BIG");
            base.AddOptionMapping(ComputeFunctionType.Max, "MAX");
            base.AddOptionMapping(ComputeFunctionType.Min, "MIN");
            base.AddOptionMapping(ComputeFunctionType.Sum, "SUM");
            base.AddOptionMapping(ComputeFunctionType.Avg, "AVG");
            base.AddOptionMapping(ComputeFunctionType.Var, "VAR");
            base.AddOptionMapping(ComputeFunctionType.Varp, "VARP");
            base.AddOptionMapping(ComputeFunctionType.Stdev, "STDEV");
            base.AddOptionMapping(ComputeFunctionType.Stdevp, "STDEVP");
            base.AddOptionMapping(ComputeFunctionType.ChecksumAgg, "CHECKSUM_AGG");
            base.AddOptionMapping(ComputeFunctionType.ModularSum, "MODULAR_SUM");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46024", token, TSqlParserResource.SQL46024Message, token.getText()));
        }
    }

    internal class ContainmentOptionKindHelper : OptionsHelper<ContainmentOptionKind> {
        internal static readonly ContainmentOptionKindHelper Instance = new ContainmentOptionKindHelper();

        private ContainmentOptionKindHelper() {
            base.AddOptionMapping(ContainmentOptionKind.None, "NONE");
            base.AddOptionMapping(ContainmentOptionKind.Partial, "PARTIAL");
        }
    }
    internal class CursorOptionsHelper : OptionsHelper<CursorOptionKind> {
        internal static readonly CursorOptionsHelper Instance = new CursorOptionsHelper();

        private CursorOptionsHelper() {
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

    internal class DatabaseAuditActionGroupHelper : OptionsHelper<AuditActionGroup> {
        internal static readonly DatabaseAuditActionGroupHelper Instance = new DatabaseAuditActionGroupHelper();

        private DatabaseAuditActionGroupHelper() {
            base.AddOptionMapping(AuditActionGroup.DatabasePermissionChange, "DATABASE_PERMISSION_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.SchemaObjectPermissionChange, "SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseRoleMemberChange, "DATABASE_ROLE_MEMBER_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.ApplicationRoleChangePassword, "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.SchemaObjectAccess, "SCHEMA_OBJECT_ACCESS_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.BackupRestore, "BACKUP_RESTORE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.Dbcc, "DBCC_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.AuditChange, "AUDIT_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseChange, "DATABASE_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectChange, "DATABASE_OBJECT_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabasePrincipalChange, "DATABASE_PRINCIPAL_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.SchemaObjectChange, "SCHEMA_OBJECT_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabasePrincipalImpersonation, "DATABASE_PRINCIPAL_IMPERSONATION_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectOwnershipChange, "DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseOwnershipChange, "DATABASE_OWNERSHIP_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.SchemaObjectOwnershipChange, "SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectPermissionChange, "DATABASE_OBJECT_PERMISSION_CHANGE_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseOperation, "DATABASE_OPERATION_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectAccess, "DATABASE_OBJECT_ACCESS_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(AuditActionGroup.SuccessfulDatabaseAuthenticationGroup, "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.FailedDatabaseAuthenticationGroup, "FAILED_DATABASE_AUTHENTICATION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseLogoutGroup, "DATABASE_LOGOUT_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.UserChangePasswordGroup, "USER_CHANGE_PASSWORD_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.UserDefinedAuditGroup, "USER_DEFINED_AUDIT_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionGroup, "TRANSACTION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionBegin, "TRANSACTION_BEGIN_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionCommit, "TRANSACTION_COMMIT_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionRollback, "TRANSACTION_ROLLBACK_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.StatementRollback, "STATEMENT_ROLLBACK_GROUP", SqlVersionFlags.TSql110AndAbove);
        }
    }

    internal class DatabaseConfigClearOptionKindHelper : OptionsHelper<DatabaseConfigClearOptionKind> {
        internal static readonly DatabaseConfigClearOptionKindHelper Instance = new DatabaseConfigClearOptionKindHelper();

        private DatabaseConfigClearOptionKindHelper() {
            base.AddOptionMapping(DatabaseConfigClearOptionKind.ProcedureCache, "PROCEDURE_CACHE", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class DatabaseConfigSetOptionKindHelper : OptionsHelper<DatabaseConfigSetOptionKind> {
        internal static readonly DatabaseConfigSetOptionKindHelper Instance = new DatabaseConfigSetOptionKindHelper();

        private DatabaseConfigSetOptionKindHelper() {
            base.AddOptionMapping(DatabaseConfigSetOptionKind.MaxDop, "MAXDOP", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(DatabaseConfigSetOptionKind.LegacyCardinalityEstimate, "LEGACY_CARDINALITY_ESTIMATION", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(DatabaseConfigSetOptionKind.ParameterSniffing, "PARAMETER_SNIFFING", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(DatabaseConfigSetOptionKind.QueryOptimizerHotFixes, "QUERY_OPTIMIZER_HOTFIXES", SqlVersionFlags.TSql130AndAbove);
        }
    }
    internal class DatabaseEncryptionKeyAlgorithmHelper : OptionsHelper<DatabaseEncryptionKeyAlgorithm> {
        internal static readonly DatabaseEncryptionKeyAlgorithmHelper Instance = new DatabaseEncryptionKeyAlgorithmHelper();

        private DatabaseEncryptionKeyAlgorithmHelper() {
            base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes128, "AES_128");
            base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes192, "AES_192");
            base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.Aes256, "AES_256");
            base.AddOptionMapping(DatabaseEncryptionKeyAlgorithm.TripleDes3Key, "TRIPLE_DES_3KEY");
        }
    }
    internal class DatabaseOptionKindHelper : OptionsHelper<DatabaseOptionKind> {
        internal static readonly DatabaseOptionKindHelper Instance = new DatabaseOptionKindHelper();

        private DatabaseOptionKindHelper() {
            base.AddOptionMapping(DatabaseOptionKind.CompatibilityLevel, "COMPATIBILITY_LEVEL", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.DefaultFullTextLanguage, "DEFAULT_FULLTEXT_LANGUAGE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.TwoDigitYearCutoff, "TWO_DIGIT_YEAR_CUTOFF", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.Edition, "EDITION", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.ServiceObjective, "SERVICE_OBJECTIVE", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.QueryStore, "QUERY_STORE", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.CatalogCollation, "CATALOG_COLLATION", SqlVersionFlags.TSql140);
            base.AddOptionMapping(DatabaseOptionKind.AutomaticTuning, "AUTOMATIC_TUNING", SqlVersionFlags.TSql140);
        }
    }

    internal class DataCompressionLevelHelper : OptionsHelper<DataCompressionLevel> {
        public static readonly DataCompressionLevelHelper Instance = new DataCompressionLevelHelper();

        private DataCompressionLevelHelper() {
            base.AddOptionMapping(DataCompressionLevel.None, "NONE");
            base.AddOptionMapping(DataCompressionLevel.Page, "PAGE");
            base.AddOptionMapping(DataCompressionLevel.Row, "ROW");
            base.AddOptionMapping(DataCompressionLevel.ColumnStore, "COLUMNSTORE");
            base.AddOptionMapping(DataCompressionLevel.ColumnStoreArchive, "COLUMNSTORE_ARCHIVE");
        }
    }

    internal class DbccCommandsHelper : OptionsHelper<DbccCommand> {
        internal static readonly DbccCommandsHelper Instance = new DbccCommandsHelper();

        private DbccCommandsHelper() {
            base.AddOptionMapping(DbccCommand.ActiveCursors, "ACTIVECURSORS");
            base.AddOptionMapping(DbccCommand.AddExtendedProc, "ADDEXTENDEDPROC");
            base.AddOptionMapping(DbccCommand.AddInstance, "ADDINSTANCE");
            base.AddOptionMapping(DbccCommand.AuditEvent, "AUDITEVENT");
            base.AddOptionMapping(DbccCommand.AutoPilot, "AUTOPILOT");
            base.AddOptionMapping(DbccCommand.Buffer, "BUFFER");
            base.AddOptionMapping(DbccCommand.Bytes, "BYTES");
            base.AddOptionMapping(DbccCommand.CacheProfile, "CACHEPROFILE");
            base.AddOptionMapping(DbccCommand.CacheStats, "CACHESTATS");
            base.AddOptionMapping(DbccCommand.CallFullText, "CALLFULLTEXT");
            base.AddOptionMapping(DbccCommand.CheckAlloc, "CHECKALLOC");
            base.AddOptionMapping(DbccCommand.CheckCatalog, "CHECKCATALOG");
            base.AddOptionMapping(DbccCommand.CheckConstraints, "CHECK_CONSTRAINTS");
            base.AddOptionMapping(DbccCommand.CheckDB, "CHECKDB");
            base.AddOptionMapping(DbccCommand.CheckFileGroup, "CHECKFILEGROUP");
            base.AddOptionMapping(DbccCommand.CheckIdent, "CHECKIDENT");
            base.AddOptionMapping(DbccCommand.CheckPrimaryFile, "CHECKPRIMARYFILE");
            base.AddOptionMapping(DbccCommand.CheckTable, "CHECKTABLE");
            base.AddOptionMapping(DbccCommand.CleanTable, "CLEANTABLE");
            base.AddOptionMapping(DbccCommand.ClearSpaceCaches, "CLEARSPACECACHES");
            base.AddOptionMapping(DbccCommand.CollectStats, "COLLECTSTATS");
            base.AddOptionMapping(DbccCommand.ConcurrencyViolation, "CONCURRENCYVIOLATION");
            base.AddOptionMapping(DbccCommand.CursorStats, "CURSORSTATS");
            base.AddOptionMapping(DbccCommand.DBRecover, "DBRECOVER");
            base.AddOptionMapping(DbccCommand.DBReindex, "DBREINDEX");
            base.AddOptionMapping(DbccCommand.DBReindexAll, "DBREINDEXALL");
            base.AddOptionMapping(DbccCommand.DBRepair, "DBREPAIR");
            base.AddOptionMapping(DbccCommand.DebugBreak, "DEBUGBREAK");
            base.AddOptionMapping(DbccCommand.DeleteInstance, "DELETEINSTANCE");
            base.AddOptionMapping(DbccCommand.DetachDB, "DETACHDB");
            base.AddOptionMapping(DbccCommand.DropCleanBuffers, "DROPCLEANBUFFERS");
            base.AddOptionMapping(DbccCommand.DropExtendedProc, "DROPEXTENDEDPROC");
            base.AddOptionMapping(DbccCommand.DumpConfig, "CONFIG");
            base.AddOptionMapping(DbccCommand.DumpDBInfo, "DBINFO");
            base.AddOptionMapping(DbccCommand.DumpDBTable, "DBTABLE");
            base.AddOptionMapping(DbccCommand.DumpLock, "LOCK");
            base.AddOptionMapping(DbccCommand.DumpLog, "LOG");
            base.AddOptionMapping(DbccCommand.DumpPage, "PAGE");
            base.AddOptionMapping(DbccCommand.DumpResource, "RESOURCE");
            base.AddOptionMapping(DbccCommand.DumpTrigger, "DUMPTRIGGER");
            base.AddOptionMapping(DbccCommand.ErrorLog, "ERRORLOG");
            base.AddOptionMapping(DbccCommand.ExtentInfo, "EXTENTINFO");
            base.AddOptionMapping(DbccCommand.FileHeader, "FILEHEADER");
            base.AddOptionMapping(DbccCommand.FixAllocation, "FIXALLOCATION");
            base.AddOptionMapping(DbccCommand.Flush, "FLUSH");
            base.AddOptionMapping(DbccCommand.FlushProcInDB, "FLUSHPROCINDB");
            base.AddOptionMapping(DbccCommand.ForceGhostCleanup, "FORCEGHOSTCLEANUP");
            base.AddOptionMapping(DbccCommand.FreeProcCache, "FREEPROCCACHE");
            base.AddOptionMapping(DbccCommand.FreeSessionCache, "FREESESSIONCACHE");
            base.AddOptionMapping(DbccCommand.FreeSystemCache, "FREESYSTEMCACHE");
            base.AddOptionMapping(DbccCommand.FreezeIO, "FREEZE_IO");
            base.AddOptionMapping(DbccCommand.Help, "HELP");
            base.AddOptionMapping(DbccCommand.IcecapQuery, "ICECAPQUERY");
            base.AddOptionMapping(DbccCommand.IncrementInstance, "INCREMENTINSTANCE");
            base.AddOptionMapping(DbccCommand.Ind, "IND");
            base.AddOptionMapping(DbccCommand.IndexDefrag, "INDEXDEFRAG");
            base.AddOptionMapping(DbccCommand.InputBuffer, "INPUTBUFFER");
            base.AddOptionMapping(DbccCommand.InvalidateTextptr, "INVALIDATE_TEXTPTR");
            base.AddOptionMapping(DbccCommand.InvalidateTextptrObjid, "INVALIDATE_TEXTPTR_OBJID");
            base.AddOptionMapping(DbccCommand.Latch, "LATCH");
            base.AddOptionMapping(DbccCommand.LogInfo, "LOGINFO");
            base.AddOptionMapping(DbccCommand.MapAllocUnit, "MAPALLOCUNIT");
            base.AddOptionMapping(DbccCommand.MemObjList, "MEMOBJLIST");
            base.AddOptionMapping(DbccCommand.MemoryMap, "MEMORYMAP");
            base.AddOptionMapping(DbccCommand.MemoryStatus, "MEMORYSTATUS");
            base.AddOptionMapping(DbccCommand.Metadata, "METADATA");
            base.AddOptionMapping(DbccCommand.MovePage, "MOVEPAGE");
            base.AddOptionMapping(DbccCommand.NoTextptr, "NO_TEXTPTR");
            base.AddOptionMapping(DbccCommand.OpenTran, "OPENTRAN");
            base.AddOptionMapping(DbccCommand.OptimizerWhatIf, "OPTIMIZER_WHATIF");
            base.AddOptionMapping(DbccCommand.OutputBuffer, "OUTPUTBUFFER");
            base.AddOptionMapping(DbccCommand.PerfMonStats, "PERFMON");
            base.AddOptionMapping(DbccCommand.PersistStackHash, "PERSISTSTACKHASH");
            base.AddOptionMapping(DbccCommand.PinTable, "PINTABLE");
            base.AddOptionMapping(DbccCommand.ProcCache, "PROCCACHE");
            base.AddOptionMapping(DbccCommand.PrtiPage, "PRTIPAGE");
            base.AddOptionMapping(DbccCommand.ReadPage, "READPAGE");
            base.AddOptionMapping(DbccCommand.RenameColumn, "RENAMECOLUMN");
            base.AddOptionMapping(DbccCommand.RuleOff, "RULEOFF");
            base.AddOptionMapping(DbccCommand.RuleOn, "RULEON");
            base.AddOptionMapping(DbccCommand.SeMetadata, "SEMETADATA");
            base.AddOptionMapping(DbccCommand.SetCpuWeight, "SETCPUWEIGHT");
            base.AddOptionMapping(DbccCommand.SetInstance, "SETINSTANCE");
            base.AddOptionMapping(DbccCommand.SetIOWeight, "SETIOWEIGHT");
            base.AddOptionMapping(DbccCommand.ShowStatistics, "SHOW_STATISTICS");
            base.AddOptionMapping(DbccCommand.ShowContig, "SHOWCONTIG");
            base.AddOptionMapping(DbccCommand.ShowDBAffinity, "SHOWDBAFFINITY");
            base.AddOptionMapping(DbccCommand.ShowFileStats, "SHOWFILESTATS");
            base.AddOptionMapping(DbccCommand.ShowOffRules, "SHOWOFFRULES");
            base.AddOptionMapping(DbccCommand.ShowOnRules, "SHOWONRULES");
            base.AddOptionMapping(DbccCommand.ShowTableAffinity, "SHOWTABLEAFFINITY");
            base.AddOptionMapping(DbccCommand.ShowText, "SHOWTEXT");
            base.AddOptionMapping(DbccCommand.ShowWeights, "SHOWWEIGHTS");
            base.AddOptionMapping(DbccCommand.ShrinkDatabase, "SHRINKDATABASE");
            base.AddOptionMapping(DbccCommand.ShrinkFile, "SHRINKFILE");
            base.AddOptionMapping(DbccCommand.SqlMgrStats, "SQLMGRSTATS");
            base.AddOptionMapping(DbccCommand.SqlPerf, "SQLPERF");
            base.AddOptionMapping(DbccCommand.StackDump, "STACKDUMP");
            base.AddOptionMapping(DbccCommand.Tec, "TEC");
            base.AddOptionMapping(DbccCommand.ThawIO, "THAW_IO");
            base.AddOptionMapping(DbccCommand.ThrottleIO, "THROTTLE_IO");
            base.AddOptionMapping(DbccCommand.TraceOff, "TRACEOFF");
            base.AddOptionMapping(DbccCommand.TraceOn, "TRACEON");
            base.AddOptionMapping(DbccCommand.TraceStatus, "TRACESTATUS");
            base.AddOptionMapping(DbccCommand.UnpinTable, "UNPINTABLE");
            base.AddOptionMapping(DbccCommand.UpdateUsage, "UPDATEUSAGE");
            base.AddOptionMapping(DbccCommand.UsePlan, "USEPLAN");
            base.AddOptionMapping(DbccCommand.UserOptions, "USEROPTIONS");
            base.AddOptionMapping(DbccCommand.WritePage, "WRITEPAGE");
        }
    }

    internal class DbccJoinOptionsHelper : OptionsHelper<DbccOptionKind> {
        internal static readonly DbccJoinOptionsHelper Instance = new DbccJoinOptionsHelper();

        private DbccJoinOptionsHelper() {
            base.AddOptionMapping(DbccOptionKind.StatHeader, "STAT_HEADER");
            base.AddOptionMapping(DbccOptionKind.DensityVector, "DENSITY_VECTOR");
        }
    }

    internal class DbccOptionsHelper : OptionsHelper<DbccOptionKind> {
        internal static readonly DbccOptionsHelper Instance = new DbccOptionsHelper();

        private DbccOptionsHelper() {
            base.AddOptionMapping(DbccOptionKind.AllErrorMessages, "ALL_ERRORMSGS");
            base.AddOptionMapping(DbccOptionKind.CountRows, "COUNT_ROWS");
            base.AddOptionMapping(DbccOptionKind.NoInfoMessages, "NO_INFOMSGS");
            base.AddOptionMapping(DbccOptionKind.TableResults, "TABLERESULTS");
            base.AddOptionMapping(DbccOptionKind.TabLock, "TABLOCK");
            base.AddOptionMapping(DbccOptionKind.StatHeader, "STAT_HEADER");
            base.AddOptionMapping(DbccOptionKind.DensityVector, "DENSITY_VECTOR");
            base.AddOptionMapping(DbccOptionKind.HistogramSteps, "HISTOGRAM_STEPS");
            base.AddOptionMapping(DbccOptionKind.EstimateOnly, "ESTIMATEONLY");
            base.AddOptionMapping(DbccOptionKind.Fast, "FAST");
            base.AddOptionMapping(DbccOptionKind.AllLevels, "ALL_LEVELS");
            base.AddOptionMapping(DbccOptionKind.AllIndexes, "ALL_INDEXES");
            base.AddOptionMapping(DbccOptionKind.PhysicalOnly, "PHYSICAL_ONLY");
            base.AddOptionMapping(DbccOptionKind.AllConstraints, "ALL_CONSTRAINTS");
            base.AddOptionMapping(DbccOptionKind.StatsStream, "STATS_STREAM");
            base.AddOptionMapping(DbccOptionKind.Histogram, "HISTOGRAM");
            base.AddOptionMapping(DbccOptionKind.DataPurity, "DATA_PURITY");
            base.AddOptionMapping(DbccOptionKind.MarkInUseForRemoval, "MARK_IN_USE_FOR_REMOVAL");
            base.AddOptionMapping(DbccOptionKind.ExtendedLogicalChecks, "EXTENDED_LOGICAL_CHECKS", SqlVersionFlags.TSql100AndAbove);
        }
    }

    internal class DelayedDurabilityOptionKindHelper : OptionsHelper<DelayedDurabilityOptionKind> {
        internal static readonly DelayedDurabilityOptionKindHelper Instance = new DelayedDurabilityOptionKindHelper();

        private DelayedDurabilityOptionKindHelper() {
            base.AddOptionMapping(DelayedDurabilityOptionKind.Disabled, "DISABLED");
            base.AddOptionMapping(DelayedDurabilityOptionKind.Allowed, "ALLOWED");
            base.AddOptionMapping(DelayedDurabilityOptionKind.Forced, "FORCED");
        }
    }

    internal class DeviceTypesHelper : OptionsHelper<DeviceType> {
        internal static readonly DeviceTypesHelper Instance = new DeviceTypesHelper();

        private DeviceTypesHelper() {
            base.AddOptionMapping(DeviceType.Disk, "DISK");
            base.AddOptionMapping(DeviceType.Tape, "TAPE");
            base.AddOptionMapping(DeviceType.VirtualDevice, "VIRTUAL_DEVICE");
            base.AddOptionMapping(DeviceType.DatabaseSnapshot, "DATABASE_SNAPSHOT");
        }
    }

    internal class DiskStatementOptionsHelper : OptionsHelper<DiskStatementOptionKind> {
        internal static readonly DiskStatementOptionsHelper Instance = new DiskStatementOptionsHelper();

        private DiskStatementOptionsHelper() {
            base.AddOptionMapping(DiskStatementOptionKind.Name, "NAME");
            base.AddOptionMapping(DiskStatementOptionKind.PhysName, "PHYSNAME");
            base.AddOptionMapping(DiskStatementOptionKind.VDevNo, "VDEVNO");
            base.AddOptionMapping(DiskStatementOptionKind.Size, "SIZE");
            base.AddOptionMapping(DiskStatementOptionKind.VStart, "VSTART");
        }
    }

    internal class DoubleOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly DoubleOptimizerHintHelper Instance = new DoubleOptimizerHintHelper();

        private DoubleOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.MaxGrantPercent, "MAX_GRANT_PERCENT", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(OptimizerHintKind.MinGrantPercent, "MIN_GRANT_PERCENT", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class DurabilityTableOptionHelper : OptionsHelper<DurabilityTableOptionKind> {
        internal static readonly DurabilityTableOptionHelper Instance = new DurabilityTableOptionHelper();

        private DurabilityTableOptionHelper() {
            base.AddOptionMapping(DurabilityTableOptionKind.SchemaOnly, "SCHEMA_ONLY");
            base.AddOptionMapping(DurabilityTableOptionKind.SchemaAndData, "SCHEMA_AND_DATA");
        }
    }

    internal class EnableDisableOptionTypeHelper : OptionsHelper<EnableDisableOptionType> {
        internal static readonly EnableDisableOptionTypeHelper Instance = new EnableDisableOptionTypeHelper();

        private EnableDisableOptionTypeHelper() {
            base.AddOptionMapping(EnableDisableOptionType.Enable, "ENABLE");
            base.AddOptionMapping(EnableDisableOptionType.Disable, "DISABLE");
        }
    }

    internal class EncryptionAlgorithmsHelper : OptionsHelper<EncryptionAlgorithm> {
        internal static readonly EncryptionAlgorithmsHelper Instance = new EncryptionAlgorithmsHelper();

        private EncryptionAlgorithmsHelper() {
            base.AddOptionMapping(EncryptionAlgorithm.RC2, "RC2");
            base.AddOptionMapping(EncryptionAlgorithm.RC4, "RC4");
            base.AddOptionMapping(EncryptionAlgorithm.RC4_128, "RC4_128");
            base.AddOptionMapping(EncryptionAlgorithm.Des, "DES");
            base.AddOptionMapping(EncryptionAlgorithm.TripleDes, "TRIPLE_DES");
            base.AddOptionMapping(EncryptionAlgorithm.DesX, "DESX");
            base.AddOptionMapping(EncryptionAlgorithm.Aes128, "AES_128");
            base.AddOptionMapping(EncryptionAlgorithm.Aes192, "AES_192");
            base.AddOptionMapping(EncryptionAlgorithm.Aes256, "AES_256");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa512, "RSA_512");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa1024, "RSA_1024");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa2048, "RSA_2048");
            base.AddOptionMapping(EncryptionAlgorithm.TripleDes3Key, "TRIPLE_DES_3KEY");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa3072, "RSA_3072");
            base.AddOptionMapping(EncryptionAlgorithm.Rsa4096, "RSA_4096");
        }
    }

    internal class EndpointEncryptionSupportHelper : OptionsHelper<EndpointEncryptionSupport> {
        internal static readonly EndpointEncryptionSupportHelper Instance = new EndpointEncryptionSupportHelper();

        private EndpointEncryptionSupportHelper() {
            base.AddOptionMapping(EndpointEncryptionSupport.Disabled, "DISABLED");
            base.AddOptionMapping(EndpointEncryptionSupport.Required, "REQUIRED");
            base.AddOptionMapping(EndpointEncryptionSupport.Supported, "SUPPORTED");
        }
    }

    internal class EndpointProtocolOptionsHelper : OptionsHelper<EndpointProtocolOptions> {
        internal static readonly EndpointProtocolOptionsHelper Instance = new EndpointProtocolOptionsHelper();

        private EndpointProtocolOptionsHelper() {
            base.AddOptionMapping(EndpointProtocolOptions.HttpAuthenticationRealm, "AUTH_REALM");
            base.AddOptionMapping(EndpointProtocolOptions.HttpAuthentication, "AUTHENTICATION");
            base.AddOptionMapping(EndpointProtocolOptions.HttpClearPort, "CLEAR_PORT");
            base.AddOptionMapping(EndpointProtocolOptions.HttpCompression, "COMPRESSION");
            base.AddOptionMapping(EndpointProtocolOptions.HttpDefaultLogonDomain, "DEFAULT_LOGON_DOMAIN");
            base.AddOptionMapping(EndpointProtocolOptions.HttpPath, "PATH");
            base.AddOptionMapping(EndpointProtocolOptions.HttpPorts, "PORTS");
            base.AddOptionMapping(EndpointProtocolOptions.HttpSite, "SITE");
            base.AddOptionMapping(EndpointProtocolOptions.HttpSslPort, "SSL_PORT");
            base.AddOptionMapping(EndpointProtocolOptions.TcpListenerIP, "LISTENER_IP");
            base.AddOptionMapping(EndpointProtocolOptions.TcpListenerPort, "LISTENER_PORT");
        }
    }

    internal class EndpointProtocolsHelper : OptionsHelper<EndpointProtocol> {
        internal static readonly EndpointProtocolsHelper Instance = new EndpointProtocolsHelper();

        private EndpointProtocolsHelper() {
            base.AddOptionMapping(EndpointProtocol.Tcp, "TCP");
            base.AddOptionMapping(EndpointProtocol.Http, "HTTP");
        }
    }

    internal class EndpointStateHelper : OptionsHelper<EndpointState> {
        internal static readonly EndpointStateHelper Instance = new EndpointStateHelper();

        private EndpointStateHelper() {
            base.AddOptionMapping(EndpointState.Disabled, "DISABLED");
            base.AddOptionMapping(EndpointState.Started, "STARTED");
            base.AddOptionMapping(EndpointState.Stopped, "STOPPED");
        }
    }

    internal class EndpointTypesHelper : OptionsHelper<EndpointType> {
        internal static readonly EndpointTypesHelper Instance = new EndpointTypesHelper();

        private EndpointTypesHelper() {
            base.AddOptionMapping(EndpointType.DatabaseMirroring, "DATABASE_MIRRORING");
            base.AddOptionMapping(EndpointType.Soap, "SOAP");
            base.AddOptionMapping(EndpointType.ServiceBroker, "SERVICE_BROKER");
            base.AddOptionMapping(EndpointType.TSql, "TSQL");
        }
    }

    internal class EventSessionEventRetentionModeTypeHelper : OptionsHelper<EventSessionEventRetentionModeType> {
        internal static readonly EventSessionEventRetentionModeTypeHelper Instance = new EventSessionEventRetentionModeTypeHelper();

        private EventSessionEventRetentionModeTypeHelper() {
            base.AddOptionMapping(EventSessionEventRetentionModeType.AllowMultipleEventLoss, "ALLOW_MULTIPLE_EVENT_LOSS");
            base.AddOptionMapping(EventSessionEventRetentionModeType.AllowSingleEventLoss, "ALLOW_SINGLE_EVENT_LOSS");
            base.AddOptionMapping(EventSessionEventRetentionModeType.NoEventLoss, "NO_EVENT_LOSS");
        }
    }

    internal class EventSessionMemoryPartitionModeTypeHelper : OptionsHelper<EventSessionMemoryPartitionModeType> {
        internal static readonly EventSessionMemoryPartitionModeTypeHelper Instance = new EventSessionMemoryPartitionModeTypeHelper();

        private EventSessionMemoryPartitionModeTypeHelper() {
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.None, "NONE");
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.PerCpu, "PER_CPU");
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.PerNode, "PER_NODE");
        }
    }

    internal class ExecuteAsOptionHelper : OptionsHelper<ExecuteAsOption> {
        internal static readonly ExecuteAsOptionHelper Instance = new ExecuteAsOptionHelper();

        private ExecuteAsOptionHelper() {
            base.AddOptionMapping(ExecuteAsOption.Caller, "CALLER");
            base.AddOptionMapping(ExecuteAsOption.Self, "SELF");
            base.AddOptionMapping(ExecuteAsOption.Owner, "OWNER");
        }
    }

    internal class ExternalDataSourceOptionHelper : OptionsHelper<ExternalDataSourceOptionKind> {
        internal static readonly ExternalDataSourceOptionHelper Instance = new ExternalDataSourceOptionHelper();

        private ExternalDataSourceOptionHelper() {
            base.AddOptionMapping(ExternalDataSourceOptionKind.ResourceManagerLocation, "RESOURCE_MANAGER_LOCATION");
            base.AddOptionMapping(ExternalDataSourceOptionKind.Credential, "CREDENTIAL");
            base.AddOptionMapping(ExternalDataSourceOptionKind.DatabaseName, "DATABASE_NAME");
            base.AddOptionMapping(ExternalDataSourceOptionKind.ShardMapName, "SHARD_MAP_NAME");
        }
    }

    internal class ExternalFileFormatOptionHelper : OptionsHelper<ExternalFileFormatOptionKind> {
        internal static readonly ExternalFileFormatOptionHelper Instance = new ExternalFileFormatOptionHelper();

        private ExternalFileFormatOptionHelper() {
            base.AddOptionMapping(ExternalFileFormatOptionKind.SerDeMethod, "SERDE_METHOD");
            base.AddOptionMapping(ExternalFileFormatOptionKind.FormatOptions, "FORMAT_OPTIONS");
            base.AddOptionMapping(ExternalFileFormatOptionKind.FieldTerminator, "FIELD_TERMINATOR");
            base.AddOptionMapping(ExternalFileFormatOptionKind.StringDelimiter, "STRING_DELIMITER");
            base.AddOptionMapping(ExternalFileFormatOptionKind.DateFormat, "DATE_FORMAT");
            base.AddOptionMapping(ExternalFileFormatOptionKind.UseTypeDefault, "USE_TYPE_DEFAULT");
            base.AddOptionMapping(ExternalFileFormatOptionKind.DataCompression, "DATA_COMPRESSION");
        }
    }

    [System.Serializable]
    internal class ExternalResourcePoolAffinityHelper : OptionsHelper<ExternalResourcePoolAffinityType> {
        internal static readonly ExternalResourcePoolAffinityHelper Instance = new ExternalResourcePoolAffinityHelper();

        private ExternalResourcePoolAffinityHelper() {
            base.AddOptionMapping(ExternalResourcePoolAffinityType.Cpu, "CPU", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolAffinityType.NumaNode, "NUMANODE", SqlVersionFlags.TSql130AndAbove);
        }
    }

    [System.Serializable]
    internal class ExternalResourcePoolParameterHelper : OptionsHelper<ExternalResourcePoolParameterType> {
        internal static readonly ExternalResourcePoolParameterHelper Instance = new ExternalResourcePoolParameterHelper();

        private ExternalResourcePoolParameterHelper() {
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxCpuPercent, "MAX_CPU_PERCENT", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxMemoryPercent, "MAX_MEMORY_PERCENT", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxProcesses, "MAX_PROCESSES", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.Affinity, "AFFINITY", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class ExternalTableOptionHelper : OptionsHelper<ExternalTableOptionKind> {
        internal static readonly ExternalTableOptionHelper Instance = new ExternalTableOptionHelper();

        private ExternalTableOptionHelper() {
            base.AddOptionMapping(ExternalTableOptionKind.Distribution, "DISTRIBUTION");
            base.AddOptionMapping(ExternalTableOptionKind.FileFormat, "FILE_FORMAT");
            base.AddOptionMapping(ExternalTableOptionKind.Location, "LOCATION");
            base.AddOptionMapping(ExternalTableOptionKind.RejectSampleValue, "REJECT_SAMPLE_VALUE");
            base.AddOptionMapping(ExternalTableOptionKind.RejectType, "REJECT_TYPE");
            base.AddOptionMapping(ExternalTableOptionKind.RejectValue, "REJECT_VALUE");
            base.AddOptionMapping(ExternalTableOptionKind.SchemaName, "SCHEMA_NAME");
            base.AddOptionMapping(ExternalTableOptionKind.ObjectName, "OBJECT_NAME");
        }
    }

    internal class ExternalTableRejectTypeHelper : OptionsHelper<ExternalTableRejectType> {
        internal static readonly ExternalTableRejectTypeHelper Instance = new ExternalTableRejectTypeHelper();

        private ExternalTableRejectTypeHelper() {
            base.AddOptionMapping(ExternalTableRejectType.Value, "VALUE");
            base.AddOptionMapping(ExternalTableRejectType.Percentage, "PERCENTAGE");
        }
    }

    internal class FetchOrientationHelper : OptionsHelper<FetchOrientation> {
        internal static readonly FetchOrientationHelper Instance = new FetchOrientationHelper();

        private FetchOrientationHelper() {
            base.AddOptionMapping(FetchOrientation.First, "FIRST");
            base.AddOptionMapping(FetchOrientation.Next, "NEXT");
            base.AddOptionMapping(FetchOrientation.Prior, "PRIOR");
            base.AddOptionMapping(FetchOrientation.Last, "LAST");
            base.AddOptionMapping(FetchOrientation.Relative, "RELATIVE");
            base.AddOptionMapping(FetchOrientation.Absolute, "ABSOLUTE");
        }
    }

    internal class FipsComplianceLevelHelper : OptionsHelper<FipsComplianceLevel> {
        internal static readonly FipsComplianceLevelHelper Instance = new FipsComplianceLevelHelper();

        private FipsComplianceLevelHelper() {
            base.AddOptionMapping(FipsComplianceLevel.Off, TSqlTokenType.Off);
            base.AddOptionMapping(FipsComplianceLevel.Entry, "'ENTRY'");
            base.AddOptionMapping(FipsComplianceLevel.Intermediate, "'INTERMEDIATE'");
            base.AddOptionMapping(FipsComplianceLevel.Full, "'FULL'");
        }
    }

    internal class GeneralSetCommandTypeHelper : OptionsHelper<GeneralSetCommandType> {
        internal static readonly GeneralSetCommandTypeHelper Instance = new GeneralSetCommandTypeHelper();

        private GeneralSetCommandTypeHelper() {
            base.AddOptionMapping(GeneralSetCommandType.Language, "LANGUAGE");
            base.AddOptionMapping(GeneralSetCommandType.DateFormat, "DATEFORMAT");
            base.AddOptionMapping(GeneralSetCommandType.DateFirst, "DATEFIRST");
            base.AddOptionMapping(GeneralSetCommandType.DeadlockPriority, "DEADLOCK_PRIORITY");
            base.AddOptionMapping(GeneralSetCommandType.LockTimeout, "LOCK_TIMEOUT");
            base.AddOptionMapping(GeneralSetCommandType.QueryGovernorCostLimit, "QUERY_GOVERNOR_COST_LIMIT");
            base.AddOptionMapping(GeneralSetCommandType.ContextInfo, "CONTEXT_INFO");
        }
    }

    internal class GenerateAlwaysTypeHelper : OptionsHelper<GeneratedAlwaysType> {
        internal static readonly GenerateAlwaysTypeHelper Instance = new GenerateAlwaysTypeHelper();

        private GenerateAlwaysTypeHelper() {
            base.AddOptionMapping(GeneratedAlwaysType.RowStart, "START");
            base.AddOptionMapping(GeneratedAlwaysType.RowEnd, "END");
        }
    }

    internal class GridParameterTypeHelper : OptionsHelper<GridParameterType> {
        internal static readonly GridParameterTypeHelper Instance = new GridParameterTypeHelper();

        private GridParameterTypeHelper() {
            base.AddOptionMapping(GridParameterType.Level1, "LEVEL_1");
            base.AddOptionMapping(GridParameterType.Level2, "LEVEL_2");
            base.AddOptionMapping(GridParameterType.Level3, "LEVEL_3");
            base.AddOptionMapping(GridParameterType.Level4, "LEVEL_4");
        }
    }
    internal class GroupByOptionHelper : OptionsHelper<GroupByOption> {
        internal static readonly GroupByOptionHelper Instance = new GroupByOptionHelper();

        private GroupByOptionHelper() {
            base.AddOptionMapping(GroupByOption.Cube, "CUBE");
            base.AddOptionMapping(GroupByOption.Rollup, "ROLLUP");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46023", token, TSqlParserResource.SQL46023Message, token.getText()));
        }
    }

    internal class IdentifierCreateLoginOptionsHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly IdentifierCreateLoginOptionsHelper Instance = new IdentifierCreateLoginOptionsHelper();

        private IdentifierCreateLoginOptionsHelper() {
            base.AddOptionMapping(PrincipalOptionKind.DefaultDatabase, "DEFAULT_DATABASE");
            base.AddOptionMapping(PrincipalOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE");
            base.AddOptionMapping(PrincipalOptionKind.Credential, "CREDENTIAL");
        }
    }

    [System.Serializable]
    internal class ImportanceParameterHelper : OptionsHelper<ImportanceParameterType> {
        internal static readonly ImportanceParameterHelper Instance = new ImportanceParameterHelper();

        private ImportanceParameterHelper() {
            base.AddOptionMapping(ImportanceParameterType.Low, "LOW");
            base.AddOptionMapping(ImportanceParameterType.High, "HIGH");
            base.AddOptionMapping(ImportanceParameterType.Medium, "MEDIUM");
        }
    }

    internal class IndexOptionHelper : OptionsHelper<IndexOptionKind> {
        internal static readonly IndexOptionHelper Instance = new IndexOptionHelper();

        private IndexOptionHelper() {
            base.AddOptionMapping(IndexOptionKind.PadIndex, "PAD_INDEX", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.FillFactor, TSqlTokenType.FillFactor, SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.SortInTempDB, "SORT_IN_TEMPDB", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.IgnoreDupKey, "IGNORE_DUP_KEY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.StatisticsNoRecompute, "STATISTICS_NORECOMPUTE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.DropExisting, "DROP_EXISTING", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(IndexOptionKind.Online, "ONLINE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.AllowPageLocks, "ALLOW_PAGE_LOCKS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.AllowRowLocks, "ALLOW_ROW_LOCKS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.MaxDop, "MAXDOP", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.LobCompaction, "LOB_COMPACTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(IndexOptionKind.FileStreamOn, "FILESTREAM_ON", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(IndexOptionKind.DataCompression, "DATA_COMPRESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(IndexOptionKind.BucketCount, "BUCKET_COUNT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(IndexOptionKind.StatisticsIncremental, "STATISTICS_INCREMENTAL", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(IndexOptionKind.Order, "ORDER", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.CompressAllRowGroups, "COMPRESS_ALL_ROW_GROUPS", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.CompressionDelay, "COMPRESSION_DELAY", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(IndexOptionKind.Resumable, "RESUMABLE", SqlVersionFlags.TSql140);
            base.AddOptionMapping(IndexOptionKind.MaxDuration, "MAX_DURATION", SqlVersionFlags.TSql140);
            base.AddOptionMapping(IndexOptionKind.WaitAtLowPriority, "WAIT_AT_LOW_PRIORITY", SqlVersionFlags.TSql140);
        }
    }

    internal class IntegerOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly IntegerOptimizerHintHelper Instance = new IntegerOptimizerHintHelper();

        private IntegerOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.Fast, "FAST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.MaxDop, "MAXDOP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.UsePlan, "USEPLAN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.MaxRecursion, "MAXRECURSION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(OptimizerHintKind.QueryTraceOn, "QUERYTRACEON", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(OptimizerHintKind.CardinalityTunerLimit, "CARDINALITY_TUNER_LIMIT", SqlVersionFlags.TSql100AndAbove);
        }
    }

    internal class JoinHintHelper : OptionsHelper<JoinHint> {
        internal static readonly JoinHintHelper Instance = new JoinHintHelper();

        private JoinHintHelper() {
            base.AddOptionMapping(JoinHint.Hash, "HASH", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Loop, "LOOP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Merge, "MERGE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Remote, "REMOTE", SqlVersionFlags.TSqlAll);
        }
    }

    internal class JsonForClauseModeHelper : OptionsHelper<JsonForClauseOptions> {
        internal static readonly JsonForClauseModeHelper Instance = new JsonForClauseModeHelper();

        private JsonForClauseModeHelper() {
            base.AddOptionMapping(JsonForClauseOptions.Auto, "AUTO");
            base.AddOptionMapping(JsonForClauseOptions.Path, "PATH");
        }
    }

    internal class JsonForClauseOptionsHelper : OptionsHelper<JsonForClauseOptions> {
        internal static readonly JsonForClauseOptionsHelper Instance = new JsonForClauseOptionsHelper();

        private JsonForClauseOptionsHelper() {
            base.AddOptionMapping(JsonForClauseOptions.Root, "ROOT");
            base.AddOptionMapping(JsonForClauseOptions.IncludeNullValues, "INCLUDE_NULL_VALUES");
            base.AddOptionMapping(JsonForClauseOptions.WithoutArrayWrapper, "WITHOUT_ARRAY_WRAPPER");
        }
    }

    internal class LockEscalationMethodHelper : OptionsHelper<LockEscalationMethod> {
        public static LockEscalationMethodHelper Instance = new LockEscalationMethodHelper();

        private LockEscalationMethodHelper() {
            base.AddOptionMapping(LockEscalationMethod.Auto, "AUTO");
            base.AddOptionMapping(LockEscalationMethod.Disable, "DISABLE");
            base.AddOptionMapping(LockEscalationMethod.Table, TSqlTokenType.Table);
        }
    }

    [System.Serializable]
    internal class LowPriorityLockWaitMaxDurationTimeUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly LowPriorityLockWaitMaxDurationTimeUnitHelper Instance = new LowPriorityLockWaitMaxDurationTimeUnitHelper();

        private LowPriorityLockWaitMaxDurationTimeUnitHelper() {
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
        }
    }

    internal class MemoryUnitsHelper : OptionsHelper<MemoryUnit> {
        internal static readonly MemoryUnitsHelper Instance = new MemoryUnitsHelper();

        private MemoryUnitsHelper() {
            base.AddOptionMapping(MemoryUnit.KB, "KB");
            base.AddOptionMapping(MemoryUnit.MB, "MB");
            base.AddOptionMapping(MemoryUnit.GB, "GB");
            base.AddOptionMapping(MemoryUnit.TB, "TB");
            base.AddOptionMapping(MemoryUnit.Percent, TSqlTokenType.PercentSign);
        }
    }

    internal class MessageValidationMethodsHelper : OptionsHelper<MessageValidationMethod> {
        internal static readonly MessageValidationMethodsHelper Instance = new MessageValidationMethodsHelper();

        private MessageValidationMethodsHelper() {
            base.AddOptionMapping(MessageValidationMethod.None, "NONE");
            base.AddOptionMapping(MessageValidationMethod.Empty, "EMPTY");
            base.AddOptionMapping(MessageValidationMethod.WellFormedXml, "WELL_FORMED_XML");
            base.AddOptionMapping(MessageValidationMethod.ValidXml, "VALID_XML");
        }
    }

    internal class MigrationStateHelper : OptionsHelper<MigrationState> {
        public static MigrationStateHelper Instance = new MigrationStateHelper();

        private MigrationStateHelper() {
            base.AddOptionMapping(MigrationState.Paused, "PAUSED");
            base.AddOptionMapping(MigrationState.Outbound, "OUTBOUND");
            base.AddOptionMapping(MigrationState.Inbound, "INBOUND");
        }
    }

    internal class ModifyFilegroupOptionsHelper : OptionsHelper<ModifyFileGroupOption> {
        internal static readonly ModifyFilegroupOptionsHelper Instance = new ModifyFilegroupOptionsHelper();

        private ModifyFilegroupOptionsHelper() {
            base.AddOptionMapping(ModifyFileGroupOption.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(ModifyFileGroupOption.ReadOnlyOld, "READONLY");
            base.AddOptionMapping(ModifyFileGroupOption.ReadWrite, "READ_WRITE");
            base.AddOptionMapping(ModifyFileGroupOption.ReadWriteOld, "READWRITE");
            base.AddOptionMapping(ModifyFileGroupOption.AutogrowAllFiles, "AUTOGROW_ALL_FILES", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ModifyFileGroupOption.AutogrowSingleFile, "AUTOGROW_SINGLE_FILE", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class MonoOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly MonoOptimizerHintHelper Instance = new MonoOptimizerHintHelper();

        private MonoOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.Recompile, "RECOMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(OptimizerHintKind.IgnoreNonClusteredColumnStoreIndex, "IGNORE_NONCLUSTERED_COLUMNSTORE_INDEX", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(OptimizerHintKind.NoPerformanceSpool, "NO_PERFORMANCE_SPOOL", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class OnOffSimpleDbOptionsHelper : OptionsHelper<DatabaseOptionKind> {
        internal static readonly OnOffSimpleDbOptionsHelper Instance = new OnOffSimpleDbOptionsHelper();

        private OnOffSimpleDbOptionsHelper() {
            base.AddOptionMapping(DatabaseOptionKind.CursorCloseOnCommit, "CURSOR_CLOSE_ON_COMMIT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AutoClose, "AUTO_CLOSE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AutoCreateStatistics, "AUTO_CREATE_STATISTICS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AutoShrink, "AUTO_SHRINK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AutoUpdateStatistics, "AUTO_UPDATE_STATISTICS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AnsiNullDefault, "ANSI_NULL_DEFAULT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AnsiNulls, "ANSI_NULLS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AnsiPadding, "ANSI_PADDING", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.AnsiWarnings, "ANSI_WARNINGS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.ArithAbort, "ARITHABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.ConcatNullYieldsNull, "CONCAT_NULL_YIELDS_NULL", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.NumericRoundAbort, "NUMERIC_ROUNDABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.QuotedIdentifier, "QUOTED_IDENTIFIER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.RecursiveTriggers, "RECURSIVE_TRIGGERS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.TornPageDetection, "TORN_PAGE_DETECTION", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.DBChaining, "DB_CHAINING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.Trustworthy, "TRUSTWORTHY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.AutoUpdateStatisticsAsync, "AUTO_UPDATE_STATISTICS_ASYNC", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.DateCorrelationOptimization, "DATE_CORRELATION_OPTIMIZATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.AllowSnapshotIsolation, "ALLOW_SNAPSHOT_ISOLATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.ReadCommittedSnapshot, "READ_COMMITTED_SNAPSHOT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.SupplementalLogging, "SUPPLEMENTAL_LOGGING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.Encryption, "ENCRYPTION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.HonorBrokerPriority, "HONOR_BROKER_PRIORITY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.VarDecimalStorageFormat, "VARDECIMAL_STORAGE_FORMAT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.NestedTriggers, "NESTED_TRIGGERS", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.TransformNoiseWords, "TRANSFORM_NOISE_WORDS", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.MemoryOptimizedElevateToSnapshot, "MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.MixedPageAllocation, "MIXED_PAGE_ALLOCATION", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.TemporalHistoryRetention, "TEMPORAL_HISTORY_RETENTION", SqlVersionFlags.TSql140);
        }

        internal bool RequiresEqualsSign(DatabaseOptionKind optionKind) {
            switch (optionKind) {
                case DatabaseOptionKind.NestedTriggers:
                case DatabaseOptionKind.TransformNoiseWords:
                case DatabaseOptionKind.MemoryOptimizedElevateToSnapshot:
                    return true;
                default:
                    return false;
            }
        }
    }

    internal class OpenRowsetBulkHintOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly OpenRowsetBulkHintOptionsHelper Instance = new OpenRowsetBulkHintOptionsHelper();

        private OpenRowsetBulkHintOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.SingleBlob, "SINGLE_BLOB");
            base.AddOptionMapping(BulkInsertOptionKind.SingleClob, "SINGLE_CLOB");
            base.AddOptionMapping(BulkInsertOptionKind.SingleNClob, "SINGLE_NCLOB");
        }
    }


    internal class PageVerifyDbOptionsHelper : OptionsHelper<PageVerifyDatabaseOptionKind> {
        internal static readonly PageVerifyDbOptionsHelper Instance = new PageVerifyDbOptionsHelper();

        private PageVerifyDbOptionsHelper() {
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.None, "NONE");
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.Checksum, "CHECKSUM");
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.TornPageDetection, "TORN_PAGE_DETECTION");
        }
    }

    internal class PartnerDbOptionsHelper : OptionsHelper<PartnerDatabaseOptionKind> {
        public static readonly PartnerDbOptionsHelper Instance = new PartnerDbOptionsHelper();

        private PartnerDbOptionsHelper() {
            base.AddOptionMapping(PartnerDatabaseOptionKind.Failover, "FAILOVER");
            base.AddOptionMapping(PartnerDatabaseOptionKind.ForceServiceAllowDataLoss, "FORCE_SERVICE_ALLOW_DATA_LOSS");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Off, TSqlTokenType.Off);
            base.AddOptionMapping(PartnerDatabaseOptionKind.Resume, "RESUME");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Suspend, "SUSPEND");
            base.AddOptionMapping(PartnerDatabaseOptionKind.Timeout, "TIMEOUT");
        }
    }

    [System.Serializable]
    internal class PermissionSetOptionHelper : OptionsHelper<PermissionSetOption> {
        internal static readonly PermissionSetOptionHelper Instance = new PermissionSetOptionHelper();

        private PermissionSetOptionHelper() {
            base.AddOptionMapping(PermissionSetOption.Safe, "SAFE");
            base.AddOptionMapping(PermissionSetOption.ExternalAccess, "EXTERNAL_ACCESS");
            base.AddOptionMapping(PermissionSetOption.Unsafe, "UNSAFE");
        }
    }

    internal class PlanOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly PlanOptimizerHintHelper Instance = new PlanOptimizerHintHelper();

        private PlanOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.RobustPlan, "ROBUST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.ShrinkDBPlan, "SHRINKDB", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.AlterColumnPlan, "ALTERCOLUMN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.KeepPlan, "KEEP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.KeepFixedPlan, "KEEPFIXED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.CheckConstraintsPlan, "CHECKCONSTRAINTS", SqlVersionFlags.TSql90AndAbove);
        }
    }

    [System.Serializable]
    internal class PortTypesHelper : OptionsHelper<PortTypes> {
        internal static readonly PortTypesHelper Instance = new PortTypesHelper();

        private PortTypesHelper() {
            base.AddOptionMapping(PortTypes.Clear, "CLEAR");
            base.AddOptionMapping(PortTypes.Ssl, "SSL");
        }
    }

    [System.Serializable]
    internal class PredicateSetOptionsHelper : OptionsHelper<SetOptions> {
        internal static readonly PredicateSetOptionsHelper Instance = new PredicateSetOptionsHelper();

        private PredicateSetOptionsHelper() {
            base.AddOptionMapping(SetOptions.QuotedIdentifier, "QUOTED_IDENTIFIER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ConcatNullYieldsNull, "CONCAT_NULL_YIELDS_NULL", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.CursorCloseOnCommit, "CURSOR_CLOSE_ON_COMMIT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ArithAbort, "ARITHABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ArithIgnore, "ARITHIGNORE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.FmtOnly, "FMTONLY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NoCount, "NOCOUNT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NoExec, "NOEXEC", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NumericRoundAbort, "NUMERIC_ROUNDABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ParseOnly, "PARSEONLY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiDefaults, "ANSI_DEFAULTS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNullDfltOff, "ANSI_NULL_DFLT_OFF", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNullDfltOn, "ANSI_NULL_DFLT_ON", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNulls, "ANSI_NULLS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiPadding, "ANSI_PADDING", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiWarnings, "ANSI_WARNINGS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ForcePlan, "FORCEPLAN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanAll, "SHOWPLAN_ALL", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanText, "SHOWPLAN_TEXT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanXml, "SHOWPLAN_XML", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ImplicitTransactions, "IMPLICIT_TRANSACTIONS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.RemoteProcTransactions, "REMOTE_PROC_TRANSACTIONS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.XactAbort, "XACT_ABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.DisableDefCnstChk, "DISABLE_DEF_CNST_CHK", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(SetOptions.NoBrowsetable, "NO_BROWSETABLE", SqlVersionFlags.TSqlAll);
        }
    }

    [System.Serializable]
    internal class ProcedureOptionHelper : OptionsHelper<ProcedureOptionKind> {
        internal static readonly ProcedureOptionHelper Instance = new ProcedureOptionHelper();

        private ProcedureOptionHelper() {
            base.AddOptionMapping(ProcedureOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(ProcedureOptionKind.Recompile, "RECOMPILE");
            base.AddOptionMapping(ProcedureOptionKind.NativeCompilation, "NATIVE_COMPILATION", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(ProcedureOptionKind.SchemaBinding, "SCHEMABINDING", SqlVersionFlags.TSql120AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46006", token, TSqlParserResource.SQL46006Message, token.getText()));
        }
    }

    internal class PseudoColumnHelper : OptionsHelper<ColumnType> {
        internal static readonly PseudoColumnHelper Instance = new PseudoColumnHelper();

        private PseudoColumnHelper() {
            base.AddOptionMapping(ColumnType.PseudoColumnIdentity, "$IDENTITY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(ColumnType.PseudoColumnRowGuid, "$ROWGUID", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(ColumnType.PseudoColumnAction, "$ACTION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(ColumnType.PseudoColumnCuid, "$CUID", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphNodeId, "$NODE_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphEdgeId, "$EDGE_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphFromId, "$FROM_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphToId, "$TO_ID", SqlVersionFlags.TSql140);
        }
    }

    [System.Serializable]
    internal class QueryStoreCapturePolicyHelper : OptionsHelper<QueryStoreCapturePolicyOptionKind> {
        internal static readonly QueryStoreCapturePolicyHelper Instance = new QueryStoreCapturePolicyHelper();

        private QueryStoreCapturePolicyHelper() {
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.NONE, "NONE");
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.AUTO, "AUTO");
            base.AddOptionMapping(QueryStoreCapturePolicyOptionKind.ALL, "ALL");
        }
    }

    [System.Serializable]
    internal class QueryStoreDesiredStateHelper : OptionsHelper<QueryStoreDesiredStateOptionKind> {
        internal static readonly QueryStoreDesiredStateHelper Instance = new QueryStoreDesiredStateHelper();

        private QueryStoreDesiredStateHelper() {
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.Off, "OFF");
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(QueryStoreDesiredStateOptionKind.ReadWrite, "READ_WRITE");
        }
    }

    [System.Serializable]
    internal class QueryStoreOptionsHelper : OptionsHelper<QueryStoreOptionKind> {
        internal static readonly QueryStoreOptionsHelper Instance = new QueryStoreOptionsHelper();

        private QueryStoreOptionsHelper() {
            base.AddOptionMapping(QueryStoreOptionKind.Desired_State, "DESIRED_STATE");
            base.AddOptionMapping(QueryStoreOptionKind.Query_Capture_Mode, "QUERY_CAPTURE_MODE");
            base.AddOptionMapping(QueryStoreOptionKind.Size_Based_Cleanup_Mode, "SIZE_BASED_CLEANUP_MODE");
            base.AddOptionMapping(QueryStoreOptionKind.Flush_Interval_Seconds, "DATA_FLUSH_INTERVAL_SECONDS");
            base.AddOptionMapping(QueryStoreOptionKind.Interval_Length_Minutes, "INTERVAL_LENGTH_MINUTES");
            base.AddOptionMapping(QueryStoreOptionKind.Current_Storage_Size_MB, "MAX_STORAGE_SIZE_MB");
            base.AddOptionMapping(QueryStoreOptionKind.Max_Plans_Per_Query, "MAX_PLANS_PER_QUERY");
            base.AddOptionMapping(QueryStoreOptionKind.Stale_Query_Threshold_Days, "CLEANUP_POLICY");
        }
    }

    [System.Serializable]
    internal class QueryStoreSizeCleanupPolicyHelper : OptionsHelper<QueryStoreSizeCleanupPolicyOptionKind> {
        internal static readonly QueryStoreSizeCleanupPolicyHelper Instance = new QueryStoreSizeCleanupPolicyHelper();

        private QueryStoreSizeCleanupPolicyHelper() {
            base.AddOptionMapping(QueryStoreSizeCleanupPolicyOptionKind.AUTO, "AUTO");
            base.AddOptionMapping(QueryStoreSizeCleanupPolicyOptionKind.OFF, "OFF");
        }
    }

    [System.Serializable]
    internal class RaiseErrorOptionsHelper : OptionsHelper<RaiseErrorOptions> {
        internal static readonly RaiseErrorOptionsHelper Instance = new RaiseErrorOptionsHelper();

        private RaiseErrorOptionsHelper() {
            base.AddOptionMapping(RaiseErrorOptions.Log, "LOG");
            base.AddOptionMapping(RaiseErrorOptions.NoWait, "NOWAIT");
            base.AddOptionMapping(RaiseErrorOptions.SetError, "SETERROR");
        }
    }

    internal class RdaTableOptionHelper : OptionsHelper<RdaTableOption> {
        public static RdaTableOptionHelper Instance = new RdaTableOptionHelper();

        private RdaTableOptionHelper() {
            base.AddOptionMapping(RdaTableOption.Enable, "ON");
            base.AddOptionMapping(RdaTableOption.Disable, "OFF");
            base.AddOptionMapping(RdaTableOption.OffWithoutDataRecovery, "OFF_WITHOUT_DATA_RECOVERY");
        }
    }

    [System.Serializable]
    internal class RecoveryDbOptionsHelper : OptionsHelper<RecoveryDatabaseOptionKind> {
        internal static readonly RecoveryDbOptionsHelper Instance = new RecoveryDbOptionsHelper();

        private RecoveryDbOptionsHelper() {
            base.AddOptionMapping(RecoveryDatabaseOptionKind.Full, "FULL");
            base.AddOptionMapping(RecoveryDatabaseOptionKind.BulkLogged, "BULK_LOGGED");
            base.AddOptionMapping(RecoveryDatabaseOptionKind.Simple, "SIMPLE");
        }
    }

    [System.Serializable]
    internal class RemoteDataArchiveDatabaseSettingsHelper : OptionsHelper<RemoteDataArchiveDatabaseSettingKind> {
        internal static readonly RemoteDataArchiveDatabaseSettingsHelper Instance = new RemoteDataArchiveDatabaseSettingsHelper();

        private RemoteDataArchiveDatabaseSettingsHelper() {
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.Server, "SERVER");
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.Credential, "CREDENTIAL");
            base.AddOptionMapping(RemoteDataArchiveDatabaseSettingKind.FederatedServiceAccount, "FEDERATED_SERVICE_ACCOUNT");
        }
    }

    [System.Serializable]
    internal class ResourcePoolAffinityHelper : OptionsHelper<ResourcePoolAffinityType> {
        internal static readonly ResourcePoolAffinityHelper Instance = new ResourcePoolAffinityHelper();

        private ResourcePoolAffinityHelper() {
            base.AddOptionMapping(ResourcePoolAffinityType.Scheduler, "SCHEDULER");
            base.AddOptionMapping(ResourcePoolAffinityType.NumaNode, "NUMANODE");
        }
    }

    [System.Serializable]
    internal class ResourcePoolParameterHelper : OptionsHelper<ResourcePoolParameterType> {
        internal static readonly ResourcePoolParameterHelper Instance = new ResourcePoolParameterHelper();

        private ResourcePoolParameterHelper() {
            base.AddOptionMapping(ResourcePoolParameterType.MaxCpuPercent, "MAX_CPU_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MaxMemoryPercent, "MAX_MEMORY_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MinCpuPercent, "MIN_CPU_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MinMemoryPercent, "MIN_MEMORY_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.CapCpuPercent, "CAP_CPU_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.TargetMemoryPercent, "TARGET_MEMORY_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MinIoPercent, "MIN_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MaxIoPercent, "MAX_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.CapIoPercent, "CAP_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.Affinity, "AFFINITY", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MinIopsPerVolume, "MIN_IOPS_PER_VOLUME", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MaxIopsPerVolume, "MAX_IOPS_PER_VOLUME", SqlVersionFlags.TSql120AndAbove);
        }
    }

    [System.Serializable]
    internal class RestoreOptionNoValueHelper : OptionsHelper<RestoreOptionKind> {
        internal static readonly RestoreOptionNoValueHelper Instance = new RestoreOptionNoValueHelper();

        private RestoreOptionNoValueHelper() {
            base.AddOptionMapping(RestoreOptionKind.NoLog, "NO_LOG");
            base.AddOptionMapping(RestoreOptionKind.Checksum, "CHECKSUM");
            base.AddOptionMapping(RestoreOptionKind.NoChecksum, "NO_CHECKSUM");
            base.AddOptionMapping(RestoreOptionKind.ContinueAfterError, "CONTINUE_AFTER_ERROR");
            base.AddOptionMapping(RestoreOptionKind.StopOnError, "STOP_ON_ERROR");
            base.AddOptionMapping(RestoreOptionKind.Unload, "UNLOAD");
            base.AddOptionMapping(RestoreOptionKind.NoUnload, "NOUNLOAD");
            base.AddOptionMapping(RestoreOptionKind.Rewind, "REWIND");
            base.AddOptionMapping(RestoreOptionKind.NoRewind, "NOREWIND");
            base.AddOptionMapping(RestoreOptionKind.Stats, "STATS");
            base.AddOptionMapping(RestoreOptionKind.NoRecovery, "NORECOVERY");
            base.AddOptionMapping(RestoreOptionKind.Recovery, "RECOVERY");
            base.AddOptionMapping(RestoreOptionKind.Replace, "REPLACE");
            base.AddOptionMapping(RestoreOptionKind.Restart, "RESTART");
            base.AddOptionMapping(RestoreOptionKind.Verbose, "VERBOSE");
            base.AddOptionMapping(RestoreOptionKind.LoadHistory, "LOADHISTORY");
            base.AddOptionMapping(RestoreOptionKind.DboOnly, "DBO_ONLY", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(RestoreOptionKind.RestrictedUser, "RESTRICTED_USER");
            base.AddOptionMapping(RestoreOptionKind.Partial, "PARTIAL");
            base.AddOptionMapping(RestoreOptionKind.Snapshot, "SNAPSHOT");
            base.AddOptionMapping(RestoreOptionKind.KeepReplication, "KEEP_REPLICATION");
            base.AddOptionMapping(RestoreOptionKind.KeepTemporalRetention, "KEEP_TEMPORAL_RETENTION", SqlVersionFlags.TSql140);
            base.AddOptionMapping(RestoreOptionKind.Online, "ONLINE");
            base.AddOptionMapping(RestoreOptionKind.CommitDifferentialBase, "COMMIT_DIFFERENTIAL_BASE");
            base.AddOptionMapping(RestoreOptionKind.SnapshotImport, "SNAPSHOT_IMPORT");
            base.AddOptionMapping(RestoreOptionKind.NewBroker, "NEW_BROKER");
            base.AddOptionMapping(RestoreOptionKind.EnableBroker, "ENABLE_BROKER");
            base.AddOptionMapping(RestoreOptionKind.ErrorBrokerConversations, "ERROR_BROKER_CONVERSATIONS");
        }
    }

    [System.Serializable]
    internal class RestoreOptionWithValueHelper : OptionsHelper<RestoreOptionKind> {
        internal static readonly RestoreOptionWithValueHelper Instance = new RestoreOptionWithValueHelper();

        private RestoreOptionWithValueHelper() {
            base.AddOptionMapping(RestoreOptionKind.File, TSqlTokenType.File);
            base.AddOptionMapping(RestoreOptionKind.Stats, "STATS");
            base.AddOptionMapping(RestoreOptionKind.StopAt, "STOPAT");
            base.AddOptionMapping(RestoreOptionKind.MediaName, "MEDIANAME");
            base.AddOptionMapping(RestoreOptionKind.MediaPassword, "MEDIAPASSWORD");
            base.AddOptionMapping(RestoreOptionKind.Password, "PASSWORD");
            base.AddOptionMapping(RestoreOptionKind.BlockSize, "BLOCKSIZE");
            base.AddOptionMapping(RestoreOptionKind.BufferCount, "BUFFERCOUNT");
            base.AddOptionMapping(RestoreOptionKind.MaxTransferSize, "MAXTRANSFERSIZE");
            base.AddOptionMapping(RestoreOptionKind.Standby, "STANDBY");
            base.AddOptionMapping(RestoreOptionKind.EnhancedIntegrity, "ENHANCEDINTEGRITY");
            base.AddOptionMapping(RestoreOptionKind.SnapshotRestorePhase, "SNAPSHOTRESTOREPHASE");
        }
    }

    [System.Serializable]
    internal class RestoreStatementKindsHelper : OptionsHelper<RestoreStatementKind> {
        internal static readonly RestoreStatementKindsHelper Instance = new RestoreStatementKindsHelper();

        private RestoreStatementKindsHelper() {
            base.AddOptionMapping(RestoreStatementKind.FileListOnly, "FILELISTONLY");
            base.AddOptionMapping(RestoreStatementKind.VerifyOnly, "VERIFYONLY");
            base.AddOptionMapping(RestoreStatementKind.LabelOnly, "LABELONLY");
            base.AddOptionMapping(RestoreStatementKind.RewindOnly, "REWINDONLY");
            base.AddOptionMapping(RestoreStatementKind.HeaderOnly, "HEADERONLY");
        }
    }

    [System.Serializable]
    internal class RetentionUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly RetentionUnitHelper Instance = new RetentionUnitHelper();

        private RetentionUnitHelper() {
            base.AddOptionMapping(TimeUnit.Days, "DAYS");
            base.AddOptionMapping(TimeUnit.Hours, "HOURS");
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
        }
    }

    [System.Serializable]
    internal class RouteOptionHelper : OptionsHelper<RouteOptionKind> {
        internal static readonly RouteOptionHelper Instance = new RouteOptionHelper();

        private RouteOptionHelper() {
            base.AddOptionMapping(RouteOptionKind.Address, "ADDRESS");
            base.AddOptionMapping(RouteOptionKind.BrokerInstance, "BROKER_INSTANCE");
            base.AddOptionMapping(RouteOptionKind.Lifetime, "LIFETIME");
            base.AddOptionMapping(RouteOptionKind.MirrorAddress, "MIRROR_ADDRESS");
            base.AddOptionMapping(RouteOptionKind.ServiceName, "SERVICE_NAME");
        }
    }

    [System.Serializable]
    internal class SecondaryXmlIndexTypeHelper : OptionsHelper<SecondaryXmlIndexType> {
        internal static readonly SecondaryXmlIndexTypeHelper Instance = new SecondaryXmlIndexTypeHelper();

        private SecondaryXmlIndexTypeHelper() {
            base.AddOptionMapping(SecondaryXmlIndexType.Path, "PATH");
            base.AddOptionMapping(SecondaryXmlIndexType.Property, "PROPERTY");
            base.AddOptionMapping(SecondaryXmlIndexType.Value, "VALUE");
        }
    }

    internal class SecurityLoginOptionsHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly SecurityLoginOptionsHelper Instance = new SecurityLoginOptionsHelper();

        private SecurityLoginOptionsHelper() {
            base.AddOptionMapping(PrincipalOptionKind.CheckExpiration, "CHECK_EXPIRATION");
            base.AddOptionMapping(PrincipalOptionKind.CheckPolicy, "CHECK_POLICY");
        }
    }

    [System.Serializable]
    internal class SecurityPredicateTypeHelper : OptionsHelper<SecurityPredicateType> {
        internal static readonly SecurityPredicateTypeHelper Instance = new SecurityPredicateTypeHelper();

        private SecurityPredicateTypeHelper() {
            base.AddOptionMapping(SecurityPredicateType.Filter, "FILTER", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(SecurityPredicateType.Block, "BLOCK", SqlVersionFlags.TSql130AndAbove);
        }
    }

    internal class ServerAuditActionGroupHelper : OptionsHelper<AuditActionGroup> {
        internal static readonly ServerAuditActionGroupHelper Instance = new ServerAuditActionGroupHelper();

        private ServerAuditActionGroupHelper() {
            base.AddOptionMapping(AuditActionGroup.SuccessfulLogin, "SUCCESSFUL_LOGIN_GROUP");
            base.AddOptionMapping(AuditActionGroup.Logout, "LOGOUT_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerStateChange, "SERVER_STATE_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.FailedLogin, "FAILED_LOGIN_GROUP");
            base.AddOptionMapping(AuditActionGroup.LoginChangePassword, "LOGIN_CHANGE_PASSWORD_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerRoleMemberChange, "SERVER_ROLE_MEMBER_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerPrincipalImpersonation, "SERVER_PRINCIPAL_IMPERSONATION_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerObjectOwnershipChange, "SERVER_OBJECT_OWNERSHIP_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseMirroringLogin, "DATABASE_MIRRORING_LOGIN_GROUP");
            base.AddOptionMapping(AuditActionGroup.BrokerLogin, "BROKER_LOGIN_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerPermissionChange, "SERVER_PERMISSION_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerObjectPermissionChange, "SERVER_OBJECT_PERMISSION_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerOperation, "SERVER_OPERATION_GROUP");
            base.AddOptionMapping(AuditActionGroup.TraceChange, "TRACE_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerObjectChange, "SERVER_OBJECT_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ServerPrincipalChange, "SERVER_PRINCIPAL_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.TransactionBegin, "TRANSACTION_BEGIN_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionCommit, "TRANSACTION_COMMIT_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionRollback, "TRANSACTION_ROLLBACK_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.StatementRollback, "STATEMENT_ROLLBACK_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.TransactionGroup, "TRANSACTION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabasePermissionChange, "DATABASE_PERMISSION_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.SchemaObjectPermissionChange, "SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseRoleMemberChange, "DATABASE_ROLE_MEMBER_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.ApplicationRoleChangePassword, "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP");
            base.AddOptionMapping(AuditActionGroup.SchemaObjectAccess, "SCHEMA_OBJECT_ACCESS_GROUP");
            base.AddOptionMapping(AuditActionGroup.BackupRestore, "BACKUP_RESTORE_GROUP");
            base.AddOptionMapping(AuditActionGroup.Dbcc, "DBCC_GROUP");
            base.AddOptionMapping(AuditActionGroup.AuditChange, "AUDIT_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseChange, "DATABASE_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectChange, "DATABASE_OBJECT_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabasePrincipalChange, "DATABASE_PRINCIPAL_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.SchemaObjectChange, "SCHEMA_OBJECT_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabasePrincipalImpersonation, "DATABASE_PRINCIPAL_IMPERSONATION_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectOwnershipChange, "DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseOwnershipChange, "DATABASE_OWNERSHIP_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.SchemaObjectOwnershipChange, "SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectPermissionChange, "DATABASE_OBJECT_PERMISSION_CHANGE_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseOperation, "DATABASE_OPERATION_GROUP");
            base.AddOptionMapping(AuditActionGroup.DatabaseObjectAccess, "DATABASE_OBJECT_ACCESS_GROUP");
            base.AddOptionMapping(AuditActionGroup.SuccessfulDatabaseAuthenticationGroup, "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.FailedDatabaseAuthenticationGroup, "FAILED_DATABASE_AUTHENTICATION_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.DatabaseLogoutGroup, "DATABASE_LOGOUT_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.UserChangePasswordGroup, "USER_CHANGE_PASSWORD_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(AuditActionGroup.UserDefinedAuditGroup, "USER_DEFINED_AUDIT_GROUP", SqlVersionFlags.TSql110AndAbove);
        }
    }

    internal class ServiceBrokerOptionsHelper : OptionsHelper<ServiceBrokerOption> {
        internal static readonly ServiceBrokerOptionsHelper Instance = new ServiceBrokerOptionsHelper();

        private ServiceBrokerOptionsHelper() {
            base.AddOptionMapping(ServiceBrokerOption.NewBroker, "NEW_BROKER");
            base.AddOptionMapping(ServiceBrokerOption.EnableBroker, "ENABLE_BROKER");
            base.AddOptionMapping(ServiceBrokerOption.ErrorBrokerConversations, "ERROR_BROKER_CONVERSATIONS");
        }
    }

    internal class SessionOptionUnitHelper : OptionsHelper<MemoryUnit> {
        internal static readonly SessionOptionUnitHelper Instance = new SessionOptionUnitHelper();

        private SessionOptionUnitHelper() {
            base.AddOptionMapping(MemoryUnit.KB, "KB");
            base.AddOptionMapping(MemoryUnit.MB, "MB");
        }
    }

    [System.Serializable]
    internal class SetStatisticsOptionsHelper : OptionsHelper<SetStatisticsOptions> {
        internal static readonly SetStatisticsOptionsHelper Instance = new SetStatisticsOptionsHelper();

        private SetStatisticsOptionsHelper() {
            base.AddOptionMapping(SetStatisticsOptions.IO, "IO", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetStatisticsOptions.Profile, "PROFILE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetStatisticsOptions.Time, "TIME", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetStatisticsOptions.Xml, "XML", SqlVersionFlags.TSql90AndAbove);
        }
    }

    [System.Serializable]
    internal class SimpleDbOptionsHelper : OptionsHelper<DatabaseOptionKind> {
        internal static readonly SimpleDbOptionsHelper Instance = new SimpleDbOptionsHelper();

        private SimpleDbOptionsHelper() {
            base.AddOptionMapping(DatabaseOptionKind.Online, "ONLINE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.Offline, "OFFLINE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.SingleUser, "SINGLE_USER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.RestrictedUser, "RESTRICTED_USER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.MultiUser, "MULTI_USER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.ReadOnly, "READ_ONLY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.ReadWrite, "READ_WRITE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(DatabaseOptionKind.Emergency, "EMERGENCY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.EnableBroker, "ENABLE_BROKER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.DisableBroker, "DISABLE_BROKER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.NewBroker, "NEW_BROKER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(DatabaseOptionKind.ErrorBrokerConversations, "ERROR_BROKER_CONVERSATIONS", SqlVersionFlags.TSql90AndAbove);
        }
    }

    [System.Serializable]
    internal class SoapMethodFormatsHelper : OptionsHelper<SoapMethodFormat> {
        internal static readonly SoapMethodFormatsHelper Instance = new SoapMethodFormatsHelper();

        private SoapMethodFormatsHelper() {
            base.AddOptionMapping(SoapMethodFormat.AllResults, "ALL_RESULTS");
            base.AddOptionMapping(SoapMethodFormat.RowsetsOnly, "ROWSETS_ONLY");
            base.AddOptionMapping(SoapMethodFormat.None, "NONE");
        }
    }

    internal class SpatialIndexingSchemeTypeHelper : OptionsHelper<SpatialIndexingSchemeType> {
        internal static readonly SpatialIndexingSchemeTypeHelper Instance = new SpatialIndexingSchemeTypeHelper();

        private SpatialIndexingSchemeTypeHelper() {
            base.AddOptionMapping(SpatialIndexingSchemeType.GeographyGrid, "GEOGRAPHY_GRID");
            base.AddOptionMapping(SpatialIndexingSchemeType.GeometryGrid, "GEOMETRY_GRID");
            base.AddOptionMapping(SpatialIndexingSchemeType.GeographyAutoGrid, "GEOGRAPHY_AUTO_GRID", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(SpatialIndexingSchemeType.GeometryAutoGrid, "GEOMETRY_AUTO_GRID", SqlVersionFlags.TSql110AndAbove);
        }
    }
    internal class StatisticsOptionHelper : OptionsHelper<StatisticsOptionKind> {
        internal static readonly StatisticsOptionHelper Instance = new StatisticsOptionHelper();

        private StatisticsOptionHelper() {
            base.AddOptionMapping(StatisticsOptionKind.FullScan, "FULLSCAN");
            base.AddOptionMapping(StatisticsOptionKind.NoRecompute, "NORECOMPUTE");
            base.AddOptionMapping(StatisticsOptionKind.Resample, "RESAMPLE");
            base.AddOptionMapping(StatisticsOptionKind.Columns, "COLUMNS");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46020", token, TSqlParserResource.SQL46020Message, token.getText()));
        }
    }
    internal class TableHintOptionsHelper : OptionsHelper<TableHintKind> {
        internal static readonly TableHintOptionsHelper Instance = new TableHintOptionsHelper();

        private TableHintOptionsHelper() {
            base.AddOptionMapping(TableHintKind.FastFirstRow, "FASTFIRSTROW", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(TableHintKind.HoldLock, TSqlTokenType.HoldLock, SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoLock, "NOLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.PagLock, "PAGLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadCommitted, "READCOMMITTED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadPast, "READPAST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadUncommitted, "READUNCOMMITTED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.RepeatableRead, "REPEATABLEREAD", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.Rowlock, "ROWLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.Serializable, "SERIALIZABLE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.TabLock, "TABLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.TabLockX, "TABLOCKX", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.UpdLock, "UPDLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.XLock, "XLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoExpand, "NOEXPAND", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoWait, "NOWAIT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadCommittedLock, "READCOMMITTEDLOCK", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.KeepIdentity, "KEEPIDENTITY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.KeepDefaults, "KEEPDEFAULTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.IgnoreConstraints, "IGNORE_CONSTRAINTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.IgnoreTriggers, "IGNORE_TRIGGERS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.ForceSeek, "FORCESEEK", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(TableHintKind.ForceScan, "FORCESCAN", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(TableHintKind.Snapshot, "SNAPSHOT", SqlVersionFlags.TSql120AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46022", token, TSqlParserResource.SQL46022Message, token.getText()));
        }
    }

    internal class TableOptionHelper : OptionsHelper<TableOptionKind> {
        internal static readonly TableOptionHelper Instance = new TableOptionHelper();

        private TableOptionHelper() {
            base.AddOptionMapping(TableOptionKind.Distribution, "DISTRIBUTION");
            base.AddOptionMapping(TableOptionKind.Partition, "PARTITION");
        }
    }

    [System.Serializable]
    internal class TargetRecoveryTimeUnitHelper : OptionsHelper<TimeUnit> {
        internal static readonly TargetRecoveryTimeUnitHelper Instance = new TargetRecoveryTimeUnitHelper();

        private TargetRecoveryTimeUnitHelper() {
            base.AddOptionMapping(TimeUnit.Minutes, "MINUTES");
            base.AddOptionMapping(TimeUnit.Seconds, "SECONDS");
        }
    }

    internal class TemporalRetentionPeriodUnitHelper : OptionsHelper<TemporalRetentionPeriodUnit> {
        internal static readonly TemporalRetentionPeriodUnitHelper Instance = new TemporalRetentionPeriodUnitHelper();

        private TemporalRetentionPeriodUnitHelper() {
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Day, "DAY");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Days, "DAYS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Week, "WEEK");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Weeks, "WEEKS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Month, "MONTH");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Months, "MONTHS");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Year, "YEAR");
            base.AddOptionMapping(TemporalRetentionPeriodUnit.Years, "YEARS");
        }
    }

    internal class TriggerEventGroupHelper : OptionsHelper<EventNotificationEventGroup> {
        internal static readonly TriggerEventGroupHelper Instance = new TriggerEventGroupHelper();

        private TriggerEventGroupHelper() {
            base.AddOptionMapping(EventNotificationEventGroup.DdlApplicationRoleEvents, "DDL_APPLICATION_ROLE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlAssemblyEvents, "DDL_ASSEMBLY_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlAuthorizationDatabaseEvents, "DDL_AUTHORIZATION_DATABASE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlCertificateEvents, "DDL_CERTIFICATE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlContractEvents, "DDL_CONTRACT_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseLevelEvents, "DDL_DATABASE_LEVEL_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseSecurityEvents, "DDL_DATABASE_SECURITY_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlEventNotificationEvents, "DDL_EVENT_NOTIFICATION_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlFunctionEvents, "DDL_FUNCTION_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlGdrDatabaseEvents, "DDL_GDR_DATABASE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlIndexEvents, "DDL_INDEX_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlMessageTypeEvents, "DDL_MESSAGE_TYPE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlPartitionEvents, "DDL_PARTITION_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlPartitionFunctionEvents, "DDL_PARTITION_FUNCTION_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlPartitionSchemeEvents, "DDL_PARTITION_SCHEME_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlProcedureEvents, "DDL_PROCEDURE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlQueueEvents, "DDL_QUEUE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlRemoteServiceBindingEvents, "DDL_REMOTE_SERVICE_BINDING_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlRoleEvents, "DDL_ROLE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlRouteEvents, "DDL_ROUTE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSchemaEvents, "DDL_SCHEMA_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServiceEvents, "DDL_SERVICE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSsbEvents, "DDL_SSB_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlStatisticsEvents, "DDL_STATISTICS_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSynonymEvents, "DDL_SYNONYM_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlTableEvents, "DDL_TABLE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlTableViewEvents, "DDL_TABLE_VIEW_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlTriggerEvents, "DDL_TRIGGER_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlTypeEvents, "DDL_TYPE_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlUserEvents, "DDL_USER_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlViewEvents, "DDL_VIEW_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlXmlSchemaCollectionEvents, "DDL_XML_SCHEMA_COLLECTION_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlAuthorizationServerEvents, "DDL_AUTHORIZATION_SERVER_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlEndpointEvents, "DDL_ENDPOINT_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlEvents, "DDL_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlGdrServerEvents, "DDL_GDR_SERVER_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlLoginEvents, "DDL_LOGIN_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServerLevelEvents, "DDL_SERVER_LEVEL_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServerSecurityEvents, "DDL_SERVER_SECURITY_EVENTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlAsymmetricKeyEvents, "DDL_ASYMMETRIC_KEY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlBrokerPriorityEvents, "DDL_BROKER_PRIORITY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlCryptoSignatureEvents, "DDL_CRYPTO_SIGNATURE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseAuditSpecificationEvents, "DDL_DATABASE_AUDIT_SPECIFICATION_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseEncryptionKeyEvents, "DDL_DATABASE_ENCRYPTION_KEY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDefaultEvents, "DDL_DEFAULT_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlExtendedPropertyEvents, "DDL_EXTENDED_PROPERTY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlFullTextCatalogEvents, "DDL_FULLTEXT_CATALOG_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlFullTextStopListEvents, "DDL_FULLTEXT_STOPLIST_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlMasterKeyEvents, "DDL_MASTER_KEY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlPlanGuideEvents, "DDL_PLAN_GUIDE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlRuleEvents, "DDL_RULE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSymmetricKeyEvents, "DDL_SYMMETRIC_KEY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlCredentialEvents, "DDL_CREDENTIAL_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseEvents, "DDL_DATABASE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlCryptographicProviderEvents, "DDL_CRYPTOGRAPHIC_PROVIDER_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlEventSessionEvents, "DDL_EVENT_SESSION_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlExtendedProcedureEvents, "DDL_EXTENDED_PROCEDURE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlLinkedServerEvents, "DDL_LINKED_SERVER_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlLinkedServerLoginEvents, "DDL_LINKED_SERVER_LOGIN_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlMessageEvents, "DDL_MESSAGE_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlRemoteServerEvents, "DDL_REMOTE_SERVER_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlResourceGovernorEvents, "DDL_RESOURCE_GOVERNOR_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlResourcePool, "DDL_RESOURCE_POOL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServerAuditEvents, "DDL_SERVER_AUDIT_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServerAuditSpecificationEvents, "DDL_SERVER_AUDIT_SPECIFICATION_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlServiceMasterKeyEvents, "DDL_SERVICE_MASTER_KEY_EVENTS", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlWorkloadGroup, "DDL_WORKLOAD_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSearchPropertyListEvents, "DDL_SEARCH_PROPERTY_LIST_EVENTS", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSequenceEvents, "DDL_SEQUENCE_EVENTS", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlAvailabilityGroupEvents, "DDL_AVAILABILITY_GROUP_EVENTS", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlDatabaseAuditEvents, "DDL_DATABASE_AUDIT_EVENTS", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventGroup.DdlSecurityPolicyEvents, "DDL_SECURITY_POLICY_EVENTS", SqlVersionFlags.TSql120AndAbove);
        }
    }

    internal class TriggerEventTypeHelper : OptionsHelper<EventNotificationEventType> {
        internal static readonly TriggerEventTypeHelper Instance = new TriggerEventTypeHelper();

        private TriggerEventTypeHelper() {
            base.AddOptionMapping(EventNotificationEventType.AddRoleMember, "ADD_ROLE_MEMBER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterApplicationRole, "ALTER_APPLICATION_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterAssembly, "ALTER_ASSEMBLY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterAuthorizationDatabase, "ALTER_AUTHORIZATION_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterCertificate, "ALTER_CERTIFICATE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterFunction, "ALTER_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterIndex, "ALTER_INDEX", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterMessageType, "ALTER_MESSAGE_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterPartitionFunction, "ALTER_PARTITION_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterPartitionScheme, "ALTER_PARTITION_SCHEME", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterProcedure, "ALTER_PROCEDURE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterQueue, "ALTER_QUEUE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterRemoteServiceBinding, "ALTER_REMOTE_SERVICE_BINDING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterRole, "ALTER_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterRoute, "ALTER_ROUTE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterSchema, "ALTER_SCHEMA", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterService, "ALTER_SERVICE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterTable, "ALTER_TABLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterTrigger, "ALTER_TRIGGER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterUser, "ALTER_USER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterView, "ALTER_VIEW", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterXmlSchemaCollection, "ALTER_XML_SCHEMA_COLLECTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateApplicationRole, "CREATE_APPLICATION_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateAssembly, "CREATE_ASSEMBLY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateCertificate, "CREATE_CERTIFICATE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateContract, "CREATE_CONTRACT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateEventNotification, "CREATE_EVENT_NOTIFICATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateFunction, "CREATE_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateIndex, "CREATE_INDEX", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateMessageType, "CREATE_MESSAGE_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreatePartitionFunction, "CREATE_PARTITION_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreatePartitionScheme, "CREATE_PARTITION_SCHEME", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateProcedure, "CREATE_PROCEDURE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateQueue, "CREATE_QUEUE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateRemoteServiceBinding, "CREATE_REMOTE_SERVICE_BINDING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateRole, "CREATE_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateRoute, "CREATE_ROUTE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSchema, "CREATE_SCHEMA", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateService, "CREATE_SERVICE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateStatistics, "CREATE_STATISTICS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSynonym, "CREATE_SYNONYM", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateTable, "CREATE_TABLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateTrigger, "CREATE_TRIGGER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateType, "CREATE_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateUser, "CREATE_USER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateView, "CREATE_VIEW", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateXmlIndex, "CREATE_XML_INDEX", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateXmlSchemaCollection, "CREATE_XML_SCHEMA_COLLECTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DenyDatabase, "DENY_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropApplicationRole, "DROP_APPLICATION_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropAssembly, "DROP_ASSEMBLY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropCertificate, "DROP_CERTIFICATE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropContract, "DROP_CONTRACT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropEventNotification, "DROP_EVENT_NOTIFICATION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropFunction, "DROP_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropIndex, "DROP_INDEX", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropMessageType, "DROP_MESSAGE_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropPartitionFunction, "DROP_PARTITION_FUNCTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropPartitionScheme, "DROP_PARTITION_SCHEME", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropProcedure, "DROP_PROCEDURE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropQueue, "DROP_QUEUE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRemoteServiceBinding, "DROP_REMOTE_SERVICE_BINDING", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRole, "DROP_ROLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRoleMember, "DROP_ROLE_MEMBER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRoute, "DROP_ROUTE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSchema, "DROP_SCHEMA", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropService, "DROP_SERVICE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropStatistics, "DROP_STATISTICS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSynonym, "DROP_SYNONYM", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropTable, "DROP_TABLE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropTrigger, "DROP_TRIGGER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropType, "DROP_TYPE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropUser, "DROP_USER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropView, "DROP_VIEW", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropXmlSchemaCollection, "DROP_XML_SCHEMA_COLLECTION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.GrantDatabase, "GRANT_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.RevokeDatabase, "REVOKE_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UpdateStatistics, "UPDATE_STATISTICS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AddServerRoleMember, "ADD_SERVER_ROLE_MEMBER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterAuthorizationServer, "ALTER_AUTHORIZATION_SERVER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterDatabase, "ALTER_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterEndpoint, "ALTER_ENDPOINT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterLogin, "ALTER_LOGIN", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateDatabase, "CREATE_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateEndpoint, "CREATE_ENDPOINT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateLogin, "CREATE_LOGIN", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DenyServer, "DENY_SERVER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropDatabase, "DROP_DATABASE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropEndpoint, "DROP_ENDPOINT", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropLogin, "DROP_LOGIN", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropServerRoleMember, "DROP_SERVER_ROLE_MEMBER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.GrantServer, "GRANT_SERVER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.RevokeServer, "REVOKE_SERVER", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AddSignature, "ADD_SIGNATURE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AddSignatureSchemaObject, "ADD_SIGNATURE_SCHEMA_OBJECT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterAsymmetricKey, "ALTER_ASYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterBrokerPriority, "ALTER_BROKER_PRIORITY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterDatabaseAuditSpecification, "ALTER_DATABASE_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterDatabaseEncryptionKey, "ALTER_DATABASE_ENCRYPTION_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterExtendedProperty, "ALTER_EXTENDED_PROPERTY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterFullTextCatalog, "ALTER_FULLTEXT_CATALOG", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterFullTextIndex, "ALTER_FULLTEXT_INDEX", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterFullTextStopList, "ALTER_FULLTEXT_STOPLIST", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterMasterKey, "ALTER_MASTER_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterPlanGuide, "ALTER_PLAN_GUIDE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterSymmetricKey, "ALTER_SYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.BindDefault, "BIND_DEFAULT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.BindRule, "BIND_RULE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateAsymmetricKey, "CREATE_ASYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateBrokerPriority, "CREATE_BROKER_PRIORITY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateDatabaseAuditSpecification, "CREATE_DATABASE_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateDatabaseEncryptionKey, "CREATE_DATABASE_ENCRYPTION_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateDefault, "CREATE_DEFAULT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateExtendedProperty, "CREATE_EXTENDED_PROPERTY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateFullTextCatalog, "CREATE_FULLTEXT_CATALOG", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateFullTextIndex, "CREATE_FULLTEXT_INDEX", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateFullTextStopList, "CREATE_FULLTEXT_STOPLIST", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateMasterKey, "CREATE_MASTER_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreatePlanGuide, "CREATE_PLAN_GUIDE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateRule, "CREATE_RULE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSpatialIndex, "CREATE_SPATIAL_INDEX", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSymmetricKey, "CREATE_SYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropAsymmetricKey, "DROP_ASYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropBrokerPriority, "DROP_BROKER_PRIORITY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropDatabaseAuditSpecification, "DROP_DATABASE_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropDatabaseEncryptionKey, "DROP_DATABASE_ENCRYPTION_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropDefault, "DROP_DEFAULT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropExtendedProperty, "DROP_EXTENDED_PROPERTY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropFullTextCatalog, "DROP_FULLTEXT_CATALOG", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropFullTextIndex, "DROP_FULLTEXT_INDEX", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropFullTextStopList, "DROP_FULLTEXT_STOPLIST", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropMasterKey, "DROP_MASTER_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropPlanGuide, "DROP_PLAN_GUIDE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRule, "DROP_RULE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSignature, "DROP_SIGNATURE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSignatureSchemaObject, "DROP_SIGNATURE_SCHEMA_OBJECT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSymmetricKey, "DROP_SYMMETRIC_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.Rename, "RENAME", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UnbindDefault, "UNBIND_DEFAULT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.UnbindRule, "UNBIND_RULE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterCredential, "ALTER_CREDENTIAL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterCryptographicProvider, "ALTER_CRYPTOGRAPHIC_PROVIDER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterEventSession, "ALTER_EVENT_SESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterInstance, "ALTER_INSTANCE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterLinkedServer, "ALTER_LINKED_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterMessage, "ALTER_MESSAGE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterRemoteServer, "ALTER_REMOTE_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterResourceGovernorConfig, "ALTER_RESOURCE_GOVERNOR_CONFIG", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterResourcePool, "ALTER_RESOURCE_POOL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterServerAudit, "ALTER_SERVER_AUDIT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterServerAuditSpecification, "ALTER_SERVER_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterServiceMasterKey, "ALTER_SERVICE_MASTER_KEY", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterWorkloadGroup, "ALTER_WORKLOAD_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateCredential, "CREATE_CREDENTIAL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateCryptographicProvider, "CREATE_CRYPTOGRAPHIC_PROVIDER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateEventSession, "CREATE_EVENT_SESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateExtendedProcedure, "CREATE_EXTENDED_PROCEDURE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateLinkedServer, "CREATE_LINKED_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateLinkedServerLogin, "CREATE_LINKED_SERVER_LOGIN", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateMessage, "CREATE_MESSAGE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateRemoteServer, "CREATE_REMOTE_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateResourcePool, "CREATE_RESOURCE_POOL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateServerAudit, "CREATE_SERVER_AUDIT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateServerAuditSpecification, "CREATE_SERVER_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateWorkloadGroup, "CREATE_WORKLOAD_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropCredential, "DROP_CREDENTIAL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropCryptographicProvider, "DROP_CRYPTOGRAPHIC_PROVIDER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropEventSession, "DROP_EVENT_SESSION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropExtendedProcedure, "DROP_EXTENDED_PROCEDURE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropLinkedServer, "DROP_LINKED_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropLinkedServerLogin, "DROP_LINKED_SERVER_LOGIN", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropMessage, "DROP_MESSAGE", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropRemoteServer, "DROP_REMOTE_SERVER", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropResourcePool, "DROP_RESOURCE_POOL", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropServerAudit, "DROP_SERVER_AUDIT", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropServerAuditSpecification, "DROP_SERVER_AUDIT_SPECIFICATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropWorkloadGroup, "DROP_WORKLOAD_GROUP", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterServerConfiguration, "ALTER_SERVER_CONFIGURATION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSearchPropertyList, "CREATE_SEARCH_PROPERTY_LIST", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterSearchPropertyList, "ALTER_SEARCH_PROPERTY_LIST", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSearchPropertyList, "DROP_SEARCH_PROPERTY_LIST", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateServerRole, "CREATE_SERVER_ROLE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterServerRole, "ALTER_SERVER_ROLE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropServerRole, "DROP_SERVER_ROLE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSequence, "CREATE_SEQUENCE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterSequence, "ALTER_SEQUENCE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSequence, "DROP_SEQUENCE", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateAvailabilityGroup, "CREATE_AVAILABILITY_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterAvailabilityGroup, "ALTER_AVAILABILITY_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropAvailabilityGroup, "DROP_AVAILABILITY_GROUP", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateDatabaseAudit, "CREATE_AUDIT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropDatabaseAudit, "DROP_AUDIT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterDatabaseAudit, "ALTER_AUDIT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateSecurityPolicy, "CREATE_SECURITY_POLICY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterSecurityPolicy, "ALTER_SECURITY_POLICY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropSecurityPolicy, "DROP_SECURITY_POLICY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateColumnMasterKey, "CREATE_COLUMN_MASTER_KEY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropColumnMasterKey, "DROP_COLUMN_MASTER_KEY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateColumnEncryptionKey, "CREATE_COLUMN_ENCRYPTION_KEY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterColumnEncryptionKey, "ALTER_COLUMN_ENCRYPTION_KEY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropColumnEncryptionKey, "DROP_COLUMN_ENCRYPTION_KEY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterDatabaseScopedConfiguration, "ALTER_DATABASE_SCOPED_CONFIGURATION", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(EventNotificationEventType.CreateExternalResourcePool, "CREATE_EXTERNAL_RESOURCE_POOL", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(EventNotificationEventType.AlterExternalResourcePool, "ALTER_EXTERNAL_RESOURCE_POOL", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(EventNotificationEventType.DropExternalResourcePool, "DROP_EXTERNAL_RESOURCE_POOL", SqlVersionFlags.TSql130AndAbove);
        }
    }
    [System.Serializable]
    internal class TriggerOptionHelper : OptionsHelper<TriggerOptionKind> {
        internal static readonly TriggerOptionHelper Instance = new TriggerOptionHelper();

        private TriggerOptionHelper() {
            base.AddOptionMapping(TriggerOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(TriggerOptionKind.NativeCompile, "NATIVE_COMPILATION", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(TriggerOptionKind.SchemaBinding, "SCHEMABINDING", SqlVersionFlags.TSql130AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46007", token, TSqlParserResource.SQL46007Message, token.getText()));
        }
    }

    public static class TSqlAuditEventGroupHelper {
        private static readonly AuditEventGroupHelper HelperInstance = AuditEventGroupHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventGroup returnValue) {
            return ((OptionsHelper<EventNotificationEventGroup>)TSqlAuditEventGroupHelper.HelperInstance).TryParseOption(input, TSqlAuditEventGroupHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }

    public static class TSqlAuditEventTypeHelper {
        private static readonly AuditEventTypeHelper HelperInstance = AuditEventTypeHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventType returnValue) {
            return ((OptionsHelper<EventNotificationEventType>)TSqlAuditEventTypeHelper.HelperInstance).TryParseOption(input, TSqlAuditEventTypeHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }

    public static class TSqlTriggerEventGroupHelper {
        private static readonly TriggerEventGroupHelper HelperInstance = TriggerEventGroupHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventGroup returnValue) {
            return ((OptionsHelper<EventNotificationEventGroup>)TSqlTriggerEventGroupHelper.HelperInstance).TryParseOption(input, TSqlTriggerEventGroupHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }
    public static class TSqlTriggerEventTypeHelper {
        private static readonly TriggerEventTypeHelper HelperInstance = TriggerEventTypeHelper.Instance;

        public static bool TryParseOption(string input, SqlVersion version, out EventNotificationEventType returnValue) {
            return ((OptionsHelper<EventNotificationEventType>)TSqlTriggerEventTypeHelper.HelperInstance).TryParseOption(input, TSqlTriggerEventTypeHelper.HelperInstance.MapSqlVersionToSqlVersionFlags(version), out returnValue);
        }
    }

    [System.Serializable]
    internal class UserLoginOptionHelper : OptionsHelper<UserLoginOptionType> {
        internal static readonly UserLoginOptionHelper Instance = new UserLoginOptionHelper();

        private UserLoginOptionHelper() {
            base.AddOptionMapping(UserLoginOptionType.Certificate, "CERTIFICATE");
            base.AddOptionMapping(UserLoginOptionType.Login, "LOGIN");
        }
    }

    [System.Serializable]
    internal class UserOptionHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly UserOptionHelper Instance = new UserOptionHelper();

        private UserOptionHelper() {
            base.AddOptionMapping(PrincipalOptionKind.DefaultSchema, "DEFAULT_SCHEMA");
            base.AddOptionMapping(PrincipalOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE");
            base.AddOptionMapping(PrincipalOptionKind.Name, "NAME");
            base.AddOptionMapping(PrincipalOptionKind.Login, "LOGIN");
            base.AddOptionMapping(PrincipalOptionKind.Type, "TYPE");
            base.AddOptionMapping(PrincipalOptionKind.Sid, "SID");
        }
    }
    internal class ViewOptionHelper : OptionsHelper<ViewOptionKind> {
        internal static readonly ViewOptionHelper Instance = new ViewOptionHelper();

        private ViewOptionHelper() {
            base.AddOptionMapping(ViewOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(ViewOptionKind.SchemaBinding, "SCHEMABINDING");
            base.AddOptionMapping(ViewOptionKind.ViewMetadata, "VIEW_METADATA");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46025", token, TSqlParserResource.SQL46025Message, token.getText()));
        }
    }

    [System.Serializable]
    internal class WaitForOptionHelper : OptionsHelper<WaitForOption> {
        internal static readonly WaitForOptionHelper Instance = new WaitForOptionHelper();

        private WaitForOptionHelper() {
            base.AddOptionMapping(WaitForOption.Delay, "DELAY");
            base.AddOptionMapping(WaitForOption.Time, "TIME");
        }
    }

    [System.Serializable]
    internal class WorkloadGroupResourceParameterHelper : OptionsHelper<WorkloadGroupParameterType> {
        internal static readonly WorkloadGroupResourceParameterHelper Instance = new WorkloadGroupResourceParameterHelper();

        private WorkloadGroupResourceParameterHelper() {
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMaxMemoryGrantPercent, "REQUEST_MAX_MEMORY_GRANT_PERCENT");
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMaxCpuTimeSec, "REQUEST_MAX_CPU_TIME_SEC");
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMemoryGrantTimeoutSec, "REQUEST_MEMORY_GRANT_TIMEOUT_SEC");
            base.AddOptionMapping(WorkloadGroupParameterType.MaxDop, "MAX_DOP");
            base.AddOptionMapping(WorkloadGroupParameterType.GroupMaxRequests, "GROUP_MAX_REQUESTS");
            base.AddOptionMapping(WorkloadGroupParameterType.GroupMinMemoryPercent, "GROUP_MIN_MEMORY_PERCENT", SqlVersionFlags.TSql110AndAbove);
        }
    }

    [System.Serializable]
    internal class XmlDataTypeOptionHelper : OptionsHelper<XmlDataTypeOption> {
        internal static readonly XmlDataTypeOptionHelper Instance = new XmlDataTypeOptionHelper();

        private XmlDataTypeOptionHelper() {
            base.AddOptionMapping(XmlDataTypeOption.Content, "CONTENT");
            base.AddOptionMapping(XmlDataTypeOption.Document, "DOCUMENT");
        }
    }

    internal class XmlForClauseModeHelper : OptionsHelper<XmlForClauseOptions> {
        internal static readonly XmlForClauseModeHelper Instance = new XmlForClauseModeHelper();

        private XmlForClauseModeHelper() {
            base.AddOptionMapping(XmlForClauseOptions.Auto, "AUTO");
            base.AddOptionMapping(XmlForClauseOptions.Raw, "RAW");
            base.AddOptionMapping(XmlForClauseOptions.Explicit, "EXPLICIT");
            base.AddOptionMapping(XmlForClauseOptions.Path, "PATH");
        }
    }

    internal class XmlForClauseOptionsHelper : OptionsHelper<XmlForClauseOptions> {
        internal static readonly XmlForClauseOptionsHelper Instance = new XmlForClauseOptionsHelper();

        private XmlForClauseOptionsHelper() {
            base.AddOptionMapping(XmlForClauseOptions.Elements, "ELEMENTS");
            base.AddOptionMapping(XmlForClauseOptions.Root, "ROOT");
            base.AddOptionMapping(XmlForClauseOptions.XmlSchema, "XMLSCHEMA");
            base.AddOptionMapping(XmlForClauseOptions.XmlData, "XMLDATA");
            base.AddOptionMapping(XmlForClauseOptions.Type, "TYPE");
        }
    }
}
