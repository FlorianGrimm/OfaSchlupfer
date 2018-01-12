namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public enum AbortAfterWaitType {
        None,
        Blockers,
        Self
    }
    [System.Serializable]
    public enum AffinityKind {
        NotSpecified,
        None,
        Integer,
        Admin
    }

    [System.Serializable]
    public enum AllowConnectionsOptionKind {
        No,
        ReadOnly,
        ReadWrite,
        All
    }

    [System.Serializable]
    public enum AlterAction {
        None,
        Add,
        Drop
    }

    [System.Serializable]
    public enum AlterAvailabilityGroupActionType {
        Failover,
        ForceFailoverAllowDataLoss,
        Online,
        Offline,
        Join
    }

    [System.Serializable]
    public enum AlterAvailabilityGroupStatementType {
        AddDatabase,
        RemoveDatabase,
        AddReplica,
        ModifyReplica,
        RemoveReplica,
        Set,
        Action
    }

    [System.Serializable]
    public enum AlterCertificateStatementKind {
        None,
        RemovePrivateKey,
        RemoveAttestedOption,
        WithPrivateKey,
        WithActiveForBeginDialog,
        AttestedBy
    }

    [System.Serializable]
    public enum AlterEventSessionStatementType {
        Unknown,
        AddEventDeclarationOptionalSessionOptions,
        DropEventSpecificationOptionalSessionOptions,
        AddTargetDeclarationOptionalSessionOptions,
        DropTargetSpecificationOptionalSessionOptions,
        RequiredSessionOptions,
        AlterStateIsStart,
        AlterStateIsStop
    }

    [System.Serializable]
    public enum AlterFederationKind {
        Unknown,
        Split,
        DropLow,
        DropHigh
    }

    [System.Serializable]
    public enum AlterFullTextCatalogAction {
        None,
        Rebuild,
        Reorganize,
        AsDefault
    }

    [System.Serializable]
    public enum AlterIndexType {
        Rebuild,
        Disable,
        Reorganize,
        Set,
        UpdateSelectiveXmlPaths,
        Abort,
        Pause,
        Resume
    }

    [System.Serializable]
    public enum AlterMasterKeyOption {
        None,
        Regenerate,
        ForceRegenerate,
        AddEncryptionByServiceMasterKey,
        AddEncryptionByPassword,
        DropEncryptionByServiceMasterKey,
        DropEncryptionByPassword
    }

    [System.Serializable]
    public enum AlterResourceGovernorCommandType {
        Unknown,
        Disable,
        Reconfigure,
        ClassifierFunction,
        ResetStatistics
    }

    [System.Serializable]
    public enum AlterServerConfigurationBufferPoolExtensionOptionKind {
        None,
        OnOff,
        FileName,
        Size
    }

    [System.Serializable]
    public enum AlterServerConfigurationDiagnosticsLogOptionKind {
        None,
        OnOff,
        Path,
        MaxSize,
        MaxFiles
    }

    [System.Serializable]
    public enum AlterServerConfigurationFailoverClusterPropertyOptionKind {
        None,
        VerboseLogging,
        SqlDumperDumpFlags,
        SqlDumperDumpPath,
        SqlDumperDumpTimeout,
        FailureConditionLevel,
        HealthCheckTimeout
    }

    [System.Serializable]
    public enum AlterServerConfigurationHadrClusterOptionKind {
        None,
        Context
    }

    [System.Serializable]
    public enum AlterServerConfigurationSoftNumaOptionKind {
        None,
        OnOff
    }


    [System.Serializable]
    public enum AlterServiceMasterKeyOption {
        None,
        Regenerate,
        ForceRegenerate,
        WithOldAccount,
        WithNewAccount
    }

    [System.Serializable]
    public enum AlterTableAlterColumnOption {
        NoOptionDefined,
        AddRowGuidCol,
        DropRowGuidCol,
        Null,
        NotNull,
        AddPersisted,
        DropPersisted,
        AddNotForReplication,
        DropNotForReplication,
        AddSparse,
        DropSparse,
        AddMaskingFunction,
        DropMaskingFunction,
        AddHidden,
        DropHidden,
        Encryption
    }

    [System.Serializable]
    public enum ApplicationRoleOptionKind {
        Name,
        DefaultSchema,
        Login,
        Password
    }

    [System.Serializable]
    public enum AssemblyOptionKind {
        PermissionSet,
        Visibility,
        UncheckedData
    }

    [System.Serializable]
    public enum AssignmentKind {
        Equals,
        AddEquals,
        SubtractEquals,
        MultiplyEquals,
        DivideEquals,
        ModEquals,
        BitwiseAndEquals,
        BitwiseOrEquals,
        BitwiseXorEquals
    }

    [System.Serializable]
    public enum AtomicBlockOptionKind {
        IsolationLevel,
        Language,
        DateFirst,
        DateFormat,
        DelayedDurability
    }

    [System.Serializable]
    public enum AttachMode {
        None,
        Attach,
        AttachRebuildLog,
        AttachForceRebuildLog,
        Load
    }

    [System.Serializable]
    public enum AuditActionGroup {
        None,
        SuccessfulLogin,
        Logout,
        ServerStateChange,
        FailedLogin,
        LoginChangePassword,
        ServerRoleMemberChange,
        ServerPrincipalImpersonation,
        ServerObjectOwnershipChange,
        DatabaseMirroringLogin,
        BrokerLogin,
        ServerPermissionChange,
        ServerObjectPermissionChange,
        ServerOperation,
        TraceChange,
        ServerObjectChange,
        ServerPrincipalChange,
        DatabasePermissionChange,
        SchemaObjectPermissionChange,
        DatabaseRoleMemberChange,
        ApplicationRoleChangePassword,
        SchemaObjectAccess,
        BackupRestore,
        Dbcc,
        AuditChange,
        DatabaseChange,
        DatabaseObjectChange,
        DatabasePrincipalChange,
        SchemaObjectChange,
        DatabasePrincipalImpersonation,
        DatabaseObjectOwnershipChange,
        DatabaseOwnershipChange,
        SchemaObjectOwnershipChange,
        DatabaseObjectPermissionChange,
        DatabaseOperation,
        DatabaseObjectAccess,
        SuccessfulDatabaseAuthenticationGroup,
        FailedDatabaseAuthenticationGroup,
        DatabaseLogoutGroup,
        UserChangePasswordGroup,
        UserDefinedAuditGroup,
        TransactionBegin,
        TransactionCommit,
        TransactionRollback,
        StatementRollback,
        TransactionGroup
    }

    [System.Serializable]
    public enum AuditFailureActionType {
        Continue,
        Shutdown,
        FailOperation
    }

    [System.Serializable]
    public enum AuditOptionKind {
        QueueDelay,
        AuditGuid,
        OnFailure,
        State
    }

    [System.Serializable]
    public enum AuditTargetKind {
        File,
        ApplicationLog,
        SecurityLog
    }

    [System.Serializable]
    public enum AuditTargetOptionKind {
        MaxRolloverFiles,
        FilePath,
        ReserveDiskSpace,
        MaxSize,
        MaxFiles
    }

    public enum AuthenticationProtocol {
        NotSpecified,
        Windows,
        WindowsNtlm,
        WindowsKerberos,
        WindowsNegotiate
    }

    [System.Flags]
    public enum AuthenticationTypes {
        None = 0,
        Basic = 1,
        Digest = 2,
        Integrated = 4,
        Ntlm = 8,
        Kerberos = 0x10
    }

    [System.Serializable]
    public enum AutomaticTuningOptionKind {
        Force_Last_Good_Plan,
        Create_Index,
        Drop_Index,
        Maintain_Index
    }

    [System.Serializable]
    public enum AutomaticTuningOptionState {
        Off,
        On,
        Default
    }

    [System.Serializable]
    public enum AutomaticTuningState {
        NotSet,
        Inherit,
        Auto,
        Custom
    }

    [System.Serializable]
    public enum AvailabilityGroupOptionKind {
        RequiredCopiesToCommit
    }

    [System.Serializable]
    public enum AvailabilityModeOptionKind {
        SynchronousCommit,
        AsynchronousCommit
    }

    [System.Serializable]
    public enum AvailabilityReplicaOptionKind {
        AvailabilityMode,
        FailoverMode,
        EndpointUrl,
        SecondaryRole,
        SessionTimeout,
        ApplyDelay,
        PrimaryRole
    }

    [System.Serializable]
    public enum BackupOptionKind {
        None,
        NoRecovery,
        TruncateOnly,
        NoLog,
        NoTruncate,
        Unload,
        NoUnload,
        Rewind,
        NoRewind,
        Format,
        NoFormat,
        Init,
        NoInit,
        Skip,
        NoSkip,
        Restart,
        Stats,
        Differential,
        Snapshot,
        Checksum,
        NoChecksum,
        ContinueAfterError,
        StopOnError,
        CopyOnly,
        Standby,
        ExpireDate,
        RetainDays,
        Name,
        Description,
        Password,
        MediaName,
        MediaDescription,
        MediaPassword,
        BlockSize,
        BufferCount,
        MaxTransferSize,
        EnhancedIntegrity,
        Compression,
        NoCompression,
        Encryption
    }

    [System.Serializable]
    public enum BackupRestoreItemKind {
        None,
        Files,
        FileGroups,
        Page,
        ReadWriteFileGroups
    }

    [System.Serializable]
    public enum BinaryExpressionType {
        Add,
        Subtract,
        Multiply,
        Divide,
        Modulo,
        BitwiseAnd,
        BitwiseOr,
        BitwiseXor
    }

    [System.Serializable]
    public enum BinaryQueryExpressionType {
        Union,
        Except,
        Intersect
    }


    [System.Serializable]
    public enum BooleanBinaryExpressionType {
        And,
        Or
    }

    [System.Serializable]
    public enum BooleanComparisonType {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        NotEqualToBrackets,
        NotEqualToExclamation,
        NotLessThan,
        NotGreaterThan,
        LeftOuterJoin,
        RightOuterJoin
    }

    [System.Serializable]
    public enum BooleanTernaryExpressionType {
        Between,
        NotBetween
    }

    [System.Serializable]
    public enum BoundingBoxParameterType {
        None,
        XMin,
        YMin,
        XMax,
        YMax
    }

    [System.Serializable]
    public enum BrokerPriorityParameterSpecialType {
        None,
        Any,
        Default
    }

    [System.Serializable]
    public enum BrokerPriorityParameterType {
        Unknown,
        ContractName,
        LocalServiceName,
        RemoteServiceName,
        PriorityLevel
    }

    [System.Serializable]
    public enum BulkInsertOptionKind {
        None,
        BatchSize,
        CheckConstraints,
        CodePage,
        DataFileType,
        FieldTerminator,
        FirstRow,
        FireTriggers,
        FormatFile,
        KeepIdentity,
        KeepNulls,
        KilobytesPerBatch,
        LastRow,
        MaxErrors,
        RowsPerBatch,
        RowTerminator,
        TabLock,
        ErrorFile,
        NoTriggers,
        SingleBlob,
        SingleClob,
        SingleNClob,
        Order,
        IncludeHidden,
        DataSource,
        FormatDataSource,
        ErrorDataSource,
        DataFileFormat,
        FieldQuote
    }


    [System.Flags]
    public enum CertificateOptionKinds {
        None = 0,
        Subject = 1,
        StartDate = 2,
        ExpiryDate = 4
    }

    [System.Serializable]
    public enum ChangeTrackingOption {
        NotSpecified,
        Auto,
        Manual,
        Off,
        OffNoPopulation
    }

    [System.Serializable]
    public enum ColumnEncryptionDefinitionParameterKind {
        ColumnEncryptionKey,
        EncryptionType,
        Algorithm
    }



    [System.Serializable]
    public enum ColumnEncryptionKeyAlterType {
        Add,
        Drop
    }


    [System.Serializable]
    public enum ColumnEncryptionKeyValueParameterKind {
        ColumnMasterKeyName,
        EncryptionAlgorithmName,
        EncryptedValue
    }


    [System.Serializable]
    public enum ColumnEncryptionType {
        Deterministic,
        Randomized
    }

    [System.Serializable]
    public enum ColumnMasterKeyParameterKind {
        KeyStoreProviderName,
        KeyPath
    }

    [System.Serializable]
    public enum ColumnType {
        Regular,
        IdentityCol,
        RowGuidCol,
        Wildcard,
        PseudoColumnIdentity,
        PseudoColumnRowGuid,
        PseudoColumnAction,
        PseudoColumnCuid,
        PseudoColumnGraphNodeId,
        PseudoColumnGraphEdgeId,
        PseudoColumnGraphFromId,
        PseudoColumnGraphToId
    }

    [System.Flags]
    public enum CommandOptions {
        None = 0,
        CreateDatabase = 1,
        CreateDefault = 2,
        CreateProcedure = 4,
        CreateFunction = 8,
        CreateRule = 0x10,
        CreateTable = 0x20,
        CreateView = 0x40,
        BackupDatabase = 0x80,
        BackupLog = 0x100
    }

    [System.Serializable]
    public enum CompressionDelayTimeUnit {
        Unitless,
        Minute,
        Minutes
    }

    [System.Serializable]
    public enum ComputeFunctionType {
        NotSpecified,
        Avg,
        Count,
        Max,
        Min,
        Stdev,
        Stdevp,
        Var,
        Varp,
        Sum,
        CountBig,
        ChecksumAgg,
        ModularSum
    }

    [System.Serializable]
    public enum ConstraintEnforcement {
        NotSpecified,
        NoCheck,
        Check
    }

    [System.Serializable]
    public enum ContainmentOptionKind {
        None,
        Partial
    }

    [System.Serializable]
    public enum CryptoMechanismType {
        Certificate,
        AsymmetricKey,
        SymmetricKey,
        Password
    }


    [System.Serializable]
    public enum CursorOptionKind {
        Local,
        Global,
        Scroll,
        ForwardOnly,
        Insensitive,
        Keyset,
        Dynamic,
        FastForward,
        ScrollLocks,
        Optimistic,
        ReadOnly,
        Static,
        TypeWarning
    }

    public enum DatabaseAuditActionKind {
        Select,
        Update,
        Insert,
        Delete,
        Execute,
        Receive,
        References
    }

    public enum DatabaseConfigClearOptionKind {
        ProcedureCache = 1
    }

    public enum DatabaseConfigSetOptionKind {
        MaxDop,
        LegacyCardinalityEstimate,
        ParameterSniffing,
        QueryOptimizerHotFixes
    }


    public enum DatabaseConfigurationOptionState {
        NotSet,
        On,
        Off,
        Primary
    }

    public enum DatabaseEncryptionKeyAlgorithm {
        None,
        Aes128,
        Aes192,
        Aes256,
        TripleDes3Key
    }

    public enum DatabaseMirroringEndpointRole {
        NotSpecified,
        Witness,
        Partner,
        All
    }

    public enum DatabaseOptionKind {
        Online,
        Offline,
        Emergency,
        SingleUser,
        RestrictedUser,
        MultiUser,
        ReadOnly,
        ReadWrite,
        EnableBroker,
        DisableBroker,
        NewBroker,
        ErrorBrokerConversations,
        DBChaining,
        Trustworthy,
        CursorCloseOnCommit,
        AutoClose,
        AutoCreateStatistics,
        AutoShrink,
        AutoUpdateStatistics,
        AutoUpdateStatisticsAsync,
        AnsiNullDefault,
        AnsiNulls,
        AnsiPadding,
        AnsiWarnings,
        ArithAbort,
        ConcatNullYieldsNull,
        NumericRoundAbort,
        QuotedIdentifier,
        RecursiveTriggers,
        TornPageDetection,
        DateCorrelationOptimization,
        AllowSnapshotIsolation,
        ReadCommittedSnapshot,
        Encryption,
        HonorBrokerPriority,
        VarDecimalStorageFormat,
        SupplementalLogging,
        CompatibilityLevel,
        CursorDefault,
        Recovery,
        PageVerify,
        Partner,
        Witness,
        Parameterization,
        ChangeTracking,
        DefaultLanguage,
        DefaultFullTextLanguage,
        NestedTriggers,
        TransformNoiseWords,
        TwoDigitYearCutoff,
        Containment,
        Hadr,
        FileStream,
        Edition,
        MaxSize,
        TargetRecoveryTime,
        MemoryOptimizedData,
        DelayedDurability,
        MemoryOptimizedElevateToSnapshot,
        ServiceObjective,
        RemoteDataArchive,
        QueryStore,
        MixedPageAllocation,
        TemporalHistoryRetention,
        CatalogCollation,
        AutomaticTuning
    }

    public enum DataCompressionLevel {
        None,
        Row,
        Page,
        ColumnStore,
        ColumnStoreArchive
    }

    public enum DbccCommand {
        None,
        ActiveCursors,
        AddExtendedProc,
        AddInstance,
        AuditEvent,
        AutoPilot,
        Buffer,
        Bytes,
        CacheProfile,
        CacheStats,
        CallFullText,
        CheckAlloc,
        CheckCatalog,
        CheckConstraints,
        CheckDB,
        CheckFileGroup,
        CheckIdent,
        CheckPrimaryFile,
        CheckTable,
        CleanTable,
        ClearSpaceCaches,
        CollectStats,
        ConcurrencyViolation,
        CursorStats,
        DBRecover,
        DBReindex,
        DBReindexAll,
        DBRepair,
        DebugBreak,
        DeleteInstance,
        DetachDB,
        DropCleanBuffers,
        DropExtendedProc,
        DumpConfig,
        DumpDBInfo,
        DumpDBTable,
        DumpLock,
        DumpLog,
        DumpPage,
        DumpResource,
        DumpTrigger,
        ErrorLog,
        ExtentInfo,
        FileHeader,
        FixAllocation,
        Flush,
        FlushProcInDB,
        ForceGhostCleanup,
        Free,
        FreeProcCache,
        FreeSessionCache,
        FreeSystemCache,
        FreezeIO,
        Help,
        IcecapQuery,
        IncrementInstance,
        Ind,
        IndexDefrag,
        InputBuffer,
        InvalidateTextptr,
        InvalidateTextptrObjid,
        Latch,
        LogInfo,
        MapAllocUnit,
        MemObjList,
        MemoryMap,
        MemoryStatus,
        Metadata,
        MovePage,
        NoTextptr,
        OpenTran,
        OptimizerWhatIf,
        OutputBuffer,
        PerfMonStats,
        PersistStackHash,
        PinTable,
        ProcCache,
        PrtiPage,
        ReadPage,
        RenameColumn,
        RuleOff,
        RuleOn,
        SeMetadata,
        SetCpuWeight,
        SetInstance,
        SetIOWeight,
        ShowStatistics,
        ShowContig,
        ShowDBAffinity,
        ShowFileStats,
        ShowOffRules,
        ShowOnRules,
        ShowTableAffinity,
        ShowText,
        ShowWeights,
        ShrinkDatabase,
        ShrinkFile,
        SqlMgrStats,
        SqlPerf,
        StackDump,
        Tec,
        ThawIO,
        ThrottleIO,
        TraceOff,
        TraceOn,
        TraceStatus,
        UnpinTable,
        UpdateUsage,
        UsePlan,
        UserOptions,
        WritePage
    }

    public enum DbccOptionKind {
        AllErrorMessages,
        CountRows,
        NoInfoMessages,
        TableResults,
        TabLock,
        StatHeader,
        DensityVector,
        HistogramSteps,
        EstimateOnly,
        Fast,
        AllLevels,
        AllIndexes,
        PhysicalOnly,
        AllConstraints,
        StatsStream,
        Histogram,
        DataPurity,
        MarkInUseForRemoval,
        ExtendedLogicalChecks
    }

    public enum DelayedDurabilityOptionKind {
        Disabled,
        Allowed,
        Forced
    }


    public enum DeleteUpdateAction {
        NotSpecified,
        Cascade,
        SetNull,
        SetDefault,
        NoAction
    }

    public enum DeviceType {
        None,
        Disk,
        Tape,
        VirtualDevice,
        DatabaseSnapshot
    }


    public enum DialogOptionKind {
        RelatedConversation,
        RelatedConversationGroup,
        Lifetime,
        Encryption
    }


    public enum DiskStatementOptionKind {
        Name,
        PhysName,
        VDevNo,
        Size,
        VStart
    }

    public enum DiskStatementType {
        Init,
        Resize
    }

    public enum DropClusteredConstraintOptionKind {
        MaxDop,
        Online,
        MoveTo,
        WaitAtLowPriority
    }


    public enum DropSchemaBehavior {
        None,
        Cascade,
        Restrict
    }

    public enum DurabilityTableOptionKind {
        SchemaOnly,
        SchemaAndData
    }

    [System.Serializable]
    public enum EnableDisableOptionType {
        None,
        Enable,
        Disable
    }

    [System.Serializable]
    public enum EncryptionAlgorithm {
        None,
        RC2,
        RC4,
        RC4_128,
        Des,
        TripleDes,
        DesX,
        Aes128,
        Aes192,
        Aes256,
        Rsa512,
        Rsa1024,
        Rsa2048,
        TripleDes3Key,
        Rsa3072,
        Rsa4096
    }

    [System.Serializable]
    public enum EncryptionAlgorithmPreference {
        NotSpecified,
        Aes,
        Rc4
    }

    [System.Serializable]
    public enum EndpointEncryptionSupport {
        NotSpecified,
        Disabled,
        Supported,
        Required
    }

    [System.Serializable]
    public enum EndpointState {
        NotSpecified,
        Disabled,
        Started,
        Stopped
    }

    [System.Serializable]
    public enum EndpointType {
        NotSpecified,
        Soap,
        TSql,
        ServiceBroker,
        DatabaseMirroring
    }

    [System.Serializable]
    public enum EndpointProtocol {
        None,
        Http,
        Tcp
    }

    [System.Serializable]
    [System.Flags]
    public enum EndpointProtocolOptions {
        None = 0,
        HttpAuthenticationRealm = 1,
        HttpAuthentication = 2,
        HttpClearPort = 4,
        HttpCompression = 8,
        HttpDefaultLogonDomain = 0x10,
        HttpPath = 0x20,
        HttpPorts = 0x40,
        HttpSite = 0x80,
        HttpSslPort = 0x100,
        HttpOptions = 0x1FF,
        TcpListenerIP = 0x200,
        TcpListenerPort = 0x400,
        TcpOptions = 0x600
    }

    [System.Serializable]
    public enum EventNotificationEventType {
        Unknown,
        CreateTable = 21,
        AlterTable,
        DropTable,
        CreateIndex,
        AlterIndex,
        DropIndex,
        CreateStatistics,
        UpdateStatistics,
        DropStatistics,
        CreateSynonym = 34,
        DropSynonym = 36,
        CreateView = 41,
        AlterView,
        DropView,
        CreateProcedure = 51,
        AlterProcedure,
        DropProcedure,
        CreateFunction = 61,
        AlterFunction,
        DropFunction,
        CreateTrigger = 71,
        AlterTrigger,
        DropTrigger,
        CreateEventNotification,
        DropEventNotification = 76,
        CreateType = 91,
        DropType = 93,
        CreateAssembly = 101,
        AlterAssembly,
        DropAssembly,
        CreateUser = 131,
        AlterUser,
        DropUser,
        CreateRole,
        AlterRole,
        DropRole,
        CreateApplicationRole,
        AlterApplicationRole,
        DropApplicationRole,
        CreateSchema = 141,
        AlterSchema,
        DropSchema,
        CreateLogin,
        AlterLogin,
        DropLogin,
        CreateMessageType = 151,
        AlterMessageType,
        DropMessageType,
        CreateContract,
        DropContract = 156,
        CreateQueue,
        AlterQueue,
        DropQueue,
        BrokerQueueDisabled,
        CreateService,
        AlterService,
        DropService,
        CreateRoute,
        AlterRoute,
        DropRoute,
        GrantServer,
        DenyServer,
        RevokeServer,
        GrantDatabase,
        DenyDatabase,
        RevokeDatabase,
        QueueActivation,
        CreateRemoteServiceBinding,
        AlterRemoteServiceBinding,
        DropRemoteServiceBinding,
        CreateXmlSchemaCollection,
        AlterXmlSchemaCollection,
        DropXmlSchemaCollection,
        CreateEndpoint = 181,
        AlterEndpoint,
        DropEndpoint,
        CreatePartitionFunction = 191,
        AlterPartitionFunction,
        DropPartitionFunction,
        CreatePartitionScheme,
        AlterPartitionScheme,
        DropPartitionScheme,
        CreateCertificate,
        AlterCertificate,
        DropCertificate,
        CreateDatabase = 201,
        AlterDatabase,
        DropDatabase,
        AlterAuthorizationServer,
        AlterAuthorizationDatabase,
        CreateXmlIndex,
        AddRoleMember,
        DropRoleMember,
        AddServerRoleMember,
        DropServerRoleMember,
        AlterExtendedProperty,
        AlterFullTextCatalog,
        AlterFullTextIndex,
        AlterInstance,
        AlterMessage,
        AlterPlanGuide,
        AlterRemoteServer,
        BindDefault,
        BindRule,
        CreateDefault,
        CreateExtendedProcedure,
        CreateExtendedProperty,
        CreateFullTextCatalog,
        CreateFullTextIndex,
        CreateLinkedServer,
        CreateLinkedServerLogin,
        CreateMessage,
        CreatePlanGuide,
        CreateRule,
        CreateRemoteServer,
        DropDefault,
        DropExtendedProcedure,
        DropExtendedProperty,
        DropFullTextCatalog,
        DropFullTextIndex,
        DropLinkedServerLogin,
        DropMessage,
        DropPlanGuide,
        DropRule,
        DropRemoteServer,
        Rename,
        UnbindDefault,
        UnbindRule,
        CreateSymmetricKey,
        AlterSymmetricKey,
        DropSymmetricKey,
        CreateAsymmetricKey,
        AlterAsymmetricKey,
        DropAsymmetricKey,
        AlterServiceMasterKey = 251,
        CreateMasterKey,
        AlterMasterKey,
        DropMasterKey,
        AddSignatureSchemaObject,
        DropSignatureSchemaObject,
        AddSignature,
        DropSignature,
        CreateCredential,
        AlterCredential,
        DropCredential,
        DropLinkedServer,
        AlterLinkedServer,
        CreateEventSession,
        AlterEventSession,
        DropEventSession,
        CreateResourcePool,
        AlterResourcePool,
        DropResourcePool,
        CreateWorkloadGroup,
        AlterWorkloadGroup,
        DropWorkloadGroup,
        AlterResourceGovernorConfig,
        CreateSpatialIndex,
        CreateCryptographicProvider,
        AlterCryptographicProvider,
        DropCryptographicProvider,
        CreateDatabaseEncryptionKey,
        AlterDatabaseEncryptionKey,
        DropDatabaseEncryptionKey,
        CreateBrokerPriority,
        AlterBrokerPriority,
        DropBrokerPriority,
        CreateServerAudit,
        AlterServerAudit,
        DropServerAudit,
        CreateServerAuditSpecification,
        AlterServerAuditSpecification,
        DropServerAuditSpecification,
        CreateDatabaseAuditSpecification,
        AlterDatabaseAuditSpecification,
        DropDatabaseAuditSpecification,
        CreateFullTextStopList,
        AlterFullTextStopList,
        DropFullTextStopList,
        AlterServerConfiguration,
        CreateSearchPropertyList,
        AlterSearchPropertyList,
        DropSearchPropertyList,
        CreateServerRole,
        AlterServerRole,
        DropServerRole,
        CreateSequence,
        AlterSequence,
        DropSequence,
        CreateAvailabilityGroup,
        AlterAvailabilityGroup,
        DropAvailabilityGroup,
        CreateDatabaseAudit,
        DropDatabaseAudit,
        AlterDatabaseAudit,
        CreateSecurityPolicy,
        AlterSecurityPolicy,
        DropSecurityPolicy,
        CreateColumnMasterKey,
        DropColumnMasterKey,
        CreateColumnEncryptionKey,
        AlterColumnEncryptionKey,
        DropColumnEncryptionKey,
        AlterDatabaseScopedConfiguration,
        CreateExternalResourcePool,
        AlterExternalResourcePool,
        DropExternalResourcePool,
        CreateExternalLibrary,
        AlterExternalLibrary,
        DropExternalLibrary,
        AuditLogin = 1014,
        AuditLogout,
        AuditLoginFailed = 1020,
        EventLog,
        ErrorLog,
        LockDeadlock = 1025,
        Exception = 1033,
        SpCacheMiss,
        SpCacheInsert,
        SpCacheRemove,
        SpRecompile,
        ObjectCreated = 1046,
        ObjectDeleted,
        HashWarning = 1055,
        LockDeadlockChain = 1059,
        LockEscalation,
        OledbErrors,
        ExecutionWarnings = 1067,
        SortWarnings = 1069,
        MissingColumnStatistics = 1079,
        MissingJoinPredicate,
        ServerMemoryChange,
        UserConfigurable0,
        UserConfigurable1,
        UserConfigurable2,
        UserConfigurable3,
        UserConfigurable4,
        UserConfigurable5,
        UserConfigurable6,
        UserConfigurable7,
        UserConfigurable8,
        UserConfigurable9,
        DataFileAutoGrow,
        LogFileAutoGrow,
        DataFileAutoShrink,
        LogFileAutoShrink,
        AuditDatabaseScopeGdrEvent = 1102,
        AuditSchemaObjectGdrEvent,
        AuditAddLoginEvent,
        AuditLoginGdrEvent,
        AuditLoginChangePropertyEvent,
        AuditLoginChangePasswordEvent,
        AuditAddLoginToServerRoleEvent,
        AuditAddDBUserEvent,
        AuditAddMemberToDBRoleEvent,
        AuditAddRoleEvent,
        AuditAppRoleChangePasswordEvent,
        AuditSchemaObjectAccessEvent = 1114,
        AuditBackupRestoreEvent,
        AuditDbccEvent,
        AuditChangeAuditEvent,
        OledbCallEvent = 1119,
        OledbQueryInterfaceEvent,
        OledbDataReadEvent,
        ShowPlanXml,
        DeprecationAnnouncement = 1125,
        DeprecationFinalSupport,
        ExchangeSpillEvent,
        AuditDatabaseManagementEvent,
        AuditDatabaseObjectManagementEvent,
        AuditDatabasePrincipalManagementEvent,
        AuditSchemaObjectManagementEvent,
        AuditServerPrincipalImpersonationEvent,
        AuditDatabasePrincipalImpersonationEvent,
        AuditServerObjectTakeOwnershipEvent,
        AuditDatabaseObjectTakeOwnershipEvent,
        BlockedProcessReport = 1137,
        ShowPlanXmlStatisticsProfile = 1146,
        DeadlockGraph = 1148,
        TraceFileClose = 1150,
        AuditChangeDatabaseOwner = 1152,
        AuditSchemaObjectTakeOwnershipEvent,
        FtCrawlStarted = 1155,
        FtCrawlStopped,
        FtCrawlAborted,
        UserErrorMessage = 1162,
        ObjectAltered = 1164,
        SqlStmtRecompile = 1166,
        DatabaseMirroringStateChange,
        ShowPlanXmlForQueryCompile,
        ShowPlanAllForQueryCompile,
        AuditServerScopeGdrEvent,
        AuditServerObjectGdrEvent,
        AuditDatabaseObjectGdrEvent,
        AuditServerOperationEvent,
        AuditServerAlterTraceEvent = 1175,
        AuditServerObjectManagementEvent,
        AuditServerPrincipalManagementEvent,
        AuditDatabaseOperationEvent,
        AuditDatabaseObjectAccessEvent = 1180,
        OledbProviderInformation = 1194,
        MountTape,
        AssemblyLoad,
        XQueryStaticType = 1198,
        QnSubscription,
        QnParameterTable,
        QnTemplate,
        QnDynamics,
        BitmapWarning = 1212,
        DatabaseSuspectDataPage,
        CpuThresholdExceeded,
        AuditFullText = 1235
    }

    [System.Serializable]
    public enum EventNotificationEventGroup {
        Unknown,
        DdlEvents = 10001,
        DdlServerLevelEvents,
        DdlEndpointEvents,
        DdlDatabaseEvents,
        DdlServerSecurityEvents,
        DdlLoginEvents,
        DdlGdrServerEvents,
        DdlAuthorizationServerEvents,
        DdlCredentialEvents,
        DdlServiceMasterKeyEvents,
        DdlExtendedProcedureEvents,
        DdlLinkedServerEvents,
        DdlLinkedServerLoginEvents,
        DdlMessageEvents,
        DdlRemoteServerEvents,
        DdlDatabaseLevelEvents,
        DdlTableViewEvents,
        DdlTableEvents,
        DdlViewEvents,
        DdlIndexEvents,
        DdlStatisticsEvents,
        DdlSynonymEvents,
        DdlFunctionEvents,
        DdlProcedureEvents,
        DdlTriggerEvents,
        DdlEventNotificationEvents,
        DdlAssemblyEvents,
        DdlTypeEvents,
        DdlDatabaseSecurityEvents,
        DdlCertificateEvents,
        DdlUserEvents,
        DdlRoleEvents,
        DdlApplicationRoleEvents,
        DdlSchemaEvents,
        DdlGdrDatabaseEvents,
        DdlAuthorizationDatabaseEvents,
        DdlSymmetricKeyEvents,
        DdlAsymmetricKeyEvents,
        DdlCryptoSignatureEvents,
        DdlMasterKeyEvents,
        DdlSsbEvents,
        DdlMessageTypeEvents,
        DdlContractEvents,
        DdlQueueEvents,
        DdlServiceEvents,
        DdlRouteEvents,
        DdlRemoteServiceBindingEvents,
        DdlXmlSchemaCollectionEvents,
        DdlPartitionEvents,
        DdlPartitionFunctionEvents,
        DdlPartitionSchemeEvents,
        DdlDefaultEvents,
        DdlExtendedPropertyEvents,
        DdlFullTextCatalogEvents,
        DdlPlanGuideEvents,
        DdlRuleEvents,
        DdlEventSessionEvents,
        DdlResourceGovernorEvents,
        DdlResourcePool,
        DdlWorkloadGroup,
        DdlCryptographicProviderEvents,
        DdlDatabaseEncryptionKeyEvents,
        DdlBrokerPriorityEvents,
        DdlServerAuditEvents,
        DdlServerAuditSpecificationEvents,
        DdlDatabaseAuditSpecificationEvents,
        DdlFullTextStopListEvents,
        DdlSearchPropertyListEvents = 10069,
        DdlSequenceEvents,
        DdlAvailabilityGroupEvents,
        DdlDatabaseAuditEvents,
        DdlSecurityPolicyEvents,
        DdlColumnMasterKeyEvents,
        DdlColumnEncryptionKeyEvents,
        DdlExternalResourcePoolEvents,
        DdlExternalLibraryEvents,
        TrcAllEvents = 11000,
        TrcDatabase = 11002,
        TrcErrorsAndWarnings,
        TrcLocks,
        TrcObjects,
        TrcPerformance,
        TrcSecurityAudit = 11008,
        TrcServer,
        TrcStoredProcedures = 11011,
        TrcTSql = 11013,
        TrcUserConfigurable,
        TrcOledb,
        TrcFullText = 11017,
        TrcDeprecation,
        TrcClr = 11020,
        TrcQueryNotifications
    }

    [System.Serializable]
    public enum EventNotificationTarget {
        Unknown,
        Server,
        Database,
        Queue
    }

    [System.Serializable]
    public enum EventSessionEventRetentionModeType {
        Unknown,
        AllowSingleEventLoss,
        AllowMultipleEventLoss,
        NoEventLoss
    }

    [System.Serializable]
    public enum EventSessionMemoryPartitionModeType {
        Unknown,
        None,
        PerNode,
        PerCpu
    }


    [System.Serializable]
    public enum EventSessionScope {
        Server,
        Database
    }

    [System.Serializable]
    public enum ExecuteAsOption {
        Caller,
        Self,
        Owner,
        String,
        Login,
        User
    }

    [System.Serializable]
    public enum ExecuteOptionKind {
        Recompile,
        ResultSets
    }

    [System.Serializable]
    public enum ExternalDataSourceOptionKind {
        ResourceManagerLocation,
        Credential,
        DatabaseName,
        ShardMapName
    }

    [System.Serializable]
    public enum ExternalDataSourceType {
        HADOOP,
        RDBMS,
        SHARD_MAP_MANAGER,
        BLOB_STORAGE
    }

    [System.Serializable]
    public enum ExternalFileFormatOptionKind {
        SerDeMethod,
        FormatOptions,
        FieldTerminator,
        StringDelimiter,
        DateFormat,
        UseTypeDefault,
        DataCompression
    }

    [System.Serializable]
    public enum ExternalFileFormatType {
        DelimitedText,
        RcFile,
        Orc,
        Parquet
    }

    [System.Serializable]
    public enum ExternalFileFormatUseDefaultType {
        False,
        True
    }

    [System.Serializable]
    public enum ExternalResourcePoolAffinityType {
        None,
        Cpu,
        NumaNode
    }

    [System.Serializable]
    public enum ExternalResourcePoolParameterType {
        Unknown,
        MaxCpuPercent,
        MaxMemoryPercent,
        MaxProcesses,
        Affinity
    }

    [System.Serializable]
    public enum ExternalTableOptionKind {
        Distribution,
        FileFormat,
        Location,
        RejectSampleValue,
        RejectType,
        RejectValue,
        SchemaName,
        ObjectName
    }

    [System.Serializable]
    public enum ExternalTableRejectType {
        Value,
        Percentage
    }

    [System.Serializable]
    public enum FailoverActionOptionKind {
        Target
    }

    [System.Serializable]
    public enum FailoverModeOptionKind {
        Automatic,
        Manual
    }

    [System.Serializable]
    public enum FetchOrientation {
        None,
        First,
        Next,
        Prior,
        Last,
        Relative,
        Absolute
    }

    [System.Serializable]
    public enum FileDeclarationOptionKind {
        Name,
        NewName,
        Offline,
        FileName,
        Size,
        MaxSize,
        FileGrowth
    }

    [System.Serializable]
    public enum FipsComplianceLevel {
        Off,
        Entry,
        Intermediate,
        Full
    }

    [System.Serializable]
    public enum FullTextCatalogOptionKind {
        AccentSensitivity
    }

    [System.Serializable]
    public enum FullTextFunctionType {
        None,
        Contains,
        FreeText
    }

    [System.Serializable]
    public enum FullTextIndexOptionKind {
        ChangeTracking,
        StopList,
        SearchPropertyList
    }

    [System.Serializable]
    public enum FunctionOptionKind {
        Encryption,
        SchemaBinding,
        ReturnsNullOnNullInput,
        CalledOnNullInput,
        ExecuteAs,
        NativeCompilation
    }

    [System.Serializable]
    public enum GeneralSetCommandType {
        None,
        Language,
        DateFormat,
        DateFirst,
        DeadlockPriority,
        LockTimeout,
        QueryGovernorCostLimit,
        ContextInfo
    }

    [System.Serializable]
    public enum GeneratedAlwaysType {
        RowStart,
        RowEnd,
        UserIdStart,
        UserIdEnd,
        UserNameStart,
        UserNameEnd
    }

    [System.Serializable]
    public enum GridParameterType {
        None,
        Level1,
        Level2,
        Level3,
        Level4
    }

    [System.Serializable]
    public enum GroupByOption {
        None,
        Cube,
        Rollup
    }

    [System.Serializable]
    public enum HadrDatabaseOptionKind {
        Suspend,
        Resume,
        Off,
        AvailabilityGroup
    }

    [System.Serializable]
    public enum ImportanceParameterType {
        Unknown,
        Low,
        Medium,
        High
    }

    [System.Serializable]
    public enum IndexOptionKind {
        PadIndex,
        FillFactor,
        SortInTempDB,
        IgnoreDupKey,
        StatisticsNoRecompute,
        DropExisting,
        Online,
        AllowRowLocks,
        AllowPageLocks,
        MaxDop,
        LobCompaction,
        FileStreamOn,
        DataCompression,
        MoveTo,
        BucketCount,
        StatisticsIncremental,
        Order,
        CompressAllRowGroups,
        CompressionDelay,
        Resumable,
        MaxDuration,
        WaitAtLowPriority
    }

    [System.Serializable]
    public enum IndexTypeKind {
        Clustered,
        NonClustered,
        NonClusteredHash,
        ClusteredColumnStore,
        NonClusteredColumnStore
    }

    [System.Serializable]
    public enum InsertOption {
        None,
        Into,
        Over
    }

    [System.Serializable]
    public enum IsolationLevel {
        None,
        ReadCommitted,
        ReadUncommitted,
        RepeatableRead,
        Serializable,
        Snapshot
    }

    [System.Serializable]
    public enum JoinHint {
        None,
        Loop,
        Hash,
        Merge,
        Remote
    }

    [System.Serializable]
    [System.Flags]
    public enum JsonForClauseOptions {
        None = 0,
        Auto = 1,
        Path = 2,
        Root = 4,
        IncludeNullValues = 8,
        WithoutArrayWrapper = 0x10
    }

    [System.Serializable]
    public enum KeyOptionKind {
        KeySource,
        Algorithm,
        IdentityValue,
        ProviderKeyName,
        CreationDisposition
    }

    [System.Serializable]
    public enum KeywordCasing {
        Lowercase,
        Uppercase,
        PascalCase
    }

    [System.Serializable]
    public enum LiteralType {
        Integer,
        Real,
        Money,
        Binary,
        String,
        Null,
        Default,
        Max,
        Odbc,
        Identifier,
        Numeric
    }

    [System.Serializable]
    public enum LockEscalationMethod {
        Table,
        Auto,
        Disable
    }

    [System.Serializable]
    public enum LowPriorityLockWaitOptionKind {
        MaxDuration,
        AbortAfterWait
    }

    [System.Serializable]
    public enum MemoryUnit {
        Unspecified,
        Percent,
        Bytes,
        KB,
        MB,
        GB,
        TB,
        PB,
        EB
    }

    [System.Serializable]
    public enum MergeCondition {
        NotSpecified,
        Matched,
        NotMatched,
        NotMatchedByTarget,
        NotMatchedBySource
    }

    [System.Serializable]
    public enum MessageSender {
        None,
        Initiator,
        Target,
        Any
    }

    [System.Serializable]
    public enum MessageValidationMethod {
        NotSpecified,
        None,
        Empty,
        WellFormedXml,
        ValidXml
    }

    [System.Serializable]
    public enum MigrationState {
        Paused,
        Outbound,
        Inbound
    }

    [System.Serializable]
    public enum ModifyFileGroupOption {
        None,
        ReadWrite,
        ReadWriteOld,
        ReadOnly,
        ReadOnlyOld,
        AutogrowAllFiles,
        AutogrowSingleFile
    }

    [System.Serializable]
    public enum NonTransactedFileStreamAccess {
        Off,
        ReadOnly,
        Full
    }

    [System.Serializable]
    public enum NullNotNull {
        NotSpecified,
        Null,
        NotNull
    }

    [System.Serializable]
    public enum OdbcLiteralType {
        Time,
        Date,
        Timestamp,
        Guid
    }

    [System.Serializable]
    public enum OptimizerHintKind {
        Unspecified,
        HashGroup,
        OrderGroup,
        MergeJoin,
        HashJoin,
        LoopJoin,
        ConcatUnion,
        HashUnion,
        MergeUnion,
        KeepUnion,
        ForceOrder,
        RobustPlan,
        KeepPlan,
        KeepFixedPlan,
        ExpandViews,
        AlterColumnPlan,
        ShrinkDBPlan,
        BypassOptimizerQueue,
        UsePlan,
        ParameterizationSimple,
        ParameterizationForced,
        OptimizeCorrelatedUnionAll,
        Recompile,
        Fast,
        CheckConstraintsPlan,
        MaxRecursion,
        MaxDop,
        QueryTraceOn,
        CardinalityTunerLimit,
        TableHints,
        OptimizeFor,
        IgnoreNonClusteredColumnStoreIndex,
        MaxGrantPercent,
        MinGrantPercent,
        NoPerformanceSpool
    }

    public enum OptionState {
        NotSet,
        On,
        Off,
        Primary
    }

    [System.Serializable]
    public enum SoapMethodAction {
        None,
        Add,
        Alter,
        Drop
    }

    public enum SqlVersion {
        Sql90,
        Sql80,
        Sql100,
        Sql110,
        Sql120,
        Sql130,
        Sql140
    }

    [System.Serializable]
    public enum TemporalRetentionPeriodUnit {
        Day,
        Days,
        Week,
        Weeks,
        Month,
        Months,
        Year,
        Years
    }

    [System.Serializable]
    public enum PageVerifyDatabaseOptionKind {
        None,
        Checksum,
        TornPageDetection
    }

    [System.Serializable]
    public enum ParameterlessCallType {
        User,
        CurrentUser,
        SessionUser,
        SystemUser,
        CurrentTimestamp
    }

    [System.Serializable]
    public enum ParameterModifier {
        None,
        Output,
        ReadOnly
    }

    [System.Serializable]
    public enum ParameterStyle {
        None,
        Sql,
        General
    }

    [System.Serializable]
    public enum PartitionFunctionRange {
        NotSpecified,
        Left,
        Right
    }

    [System.Serializable]
    public enum PartitionTableOptionRange {
        NotSpecified,
        Left,
        Right
    }

    [System.Serializable]
    public enum PartnerDatabaseOptionKind {
        None,
        PartnerServer,
        Failover,
        ForceServiceAllowDataLoss,
        Off,
        Resume,
        SafetyFull,
        SafetyOff,
        Suspend,
        Timeout
    }

    [System.Serializable]
    [System.Flags]
    public enum PayloadOptionKinds {
        None = 0,
        WebMethod = 1,
        Batches = 2,
        Wsdl = 4,
        Sessions = 8,
        LoginType = 0x10,
        SessionTimeout = 0x20,
        Database = 0x40,
        Namespace = 0x80,
        Schema = 0x100,
        CharacterSet = 0x200,
        HeaderLimit = 0x400,
        Authentication = 0x800,
        Encryption = 0x1000,
        MessageForwarding = 0x2000,
        MessageForwardSize = 0x4000,
        Role = 0x8000,
        SoapOptions = 0x7FF,
        ServiceBrokerOptions = 0x7800,
        DatabaseMirroringOptions = 0x9800
    }


    [System.Serializable]
    public enum PermissionSetOption {
        None,
        Safe,
        ExternalAccess,
        Unsafe
    }

    [System.Serializable]
    [System.Flags]
    public enum PortTypes {
        None = 0,
        Clear = 1,
        Ssl = 2
    }

    [System.Serializable]
    public enum PrincipalOptionKind {
        CheckExpiration,
        CheckPolicy,
        Sid,
        DefaultDatabase,
        DefaultLanguage,
        Credential,
        Name,
        NoCredential,
        DefaultSchema,
        Login,
        Password,
        Type
    }

    [System.Serializable]
    public enum PrincipalType {
        Null,
        Public,
        Identifier
    }

    [System.Serializable]
    public enum PrivilegeType80 {
        All,
        Select,
        Insert,
        Delete,
        Update,
        Execute,
        References
    }

    [System.Serializable]
    public enum ProcedureOptionKind {
        Encryption,
        Recompile,
        ExecuteAs,
        NativeCompilation,
        SchemaBinding
    }



    [System.Serializable]
    public enum ProcessAffinityType {
        CpuAuto,
        Cpu,
        NumaNode
    }

    [System.Serializable]
    public enum QualifiedJoinType {
        Inner,
        LeftOuter,
        RightOuter,
        FullOuter
    }

    [System.Serializable]
    public enum QueryStoreCapturePolicyOptionKind {
        NONE,
        AUTO,
        ALL
    }

    [System.Serializable]
    public enum QueryStoreDesiredStateOptionKind {
        Off,
        ReadOnly,
        ReadWrite
    }

    [System.Serializable]
    public enum QueryStoreOptionKind {
        Desired_State,
        Query_Capture_Mode,
        Size_Based_Cleanup_Mode,
        Flush_Interval_Seconds,
        Interval_Length_Minutes,
        Current_Storage_Size_MB,
        Max_Plans_Per_Query,
        Stale_Query_Threshold_Days
    }

    [System.Serializable]
    public enum QueryStoreSizeCleanupPolicyOptionKind {
        OFF,
        AUTO
    }

    [System.Serializable]
    public enum QueueOptionKind {
        Status,
        Retention,
        ActivationStatus,
        ActivationProcedureName,
        ActivationMaxQueueReaders,
        ActivationExecuteAs,
        ActivationDrop,
        PoisonMessageHandlingStatus
    }

    [System.Serializable]
    public enum QuoteType {
        NotQuoted,
        SquareBracket,
        DoubleQuote
    }

    [System.Serializable]
    [System.Flags]
    public enum RaiseErrorOptions {
        None = 0,
        Log = 1,
        NoWait = 2,
        SetError = 4
    }

    [System.Serializable]
    public enum RdaTableOption {
        Disable,
        Enable,
        OffWithoutDataRecovery
    }

    [System.Serializable]
    public enum RecoveryDatabaseOptionKind {
        None,
        Full,
        BulkLogged,
        Simple
    }

    [System.Serializable]
    public enum RemoteDataArchiveDatabaseSettingKind {
        Server,
        Credential,
        FederatedServiceAccount
    }

    [System.Serializable]
    public enum RemoteServiceBindingOptionKind {
        User,
        Anonymous
    }

    [System.Serializable]
    public enum ResourcePoolAffinityType {
        None,
        Scheduler,
        NumaNode
    }

    [System.Serializable]
    public enum ResourcePoolParameterType {
        Unknown,
        MaxCpuPercent,
        MaxMemoryPercent,
        MinCpuPercent,
        MinMemoryPercent,
        CapCpuPercent,
        TargetMemoryPercent,
        MinIoPercent,
        MaxIoPercent,
        CapIoPercent,
        Affinity,
        MinIopsPerVolume,
        MaxIopsPerVolume
    }

    [System.Serializable]
    public enum RestoreOptionKind {
        NoLog = 1,
        Checksum,
        NoChecksum,
        ContinueAfterError,
        StopOnError,
        Unload,
        NoUnload,
        Rewind,
        NoRewind,
        NoRecovery,
        Recovery,
        Replace,
        Restart,
        Verbose,
        LoadHistory,
        DboOnly,
        RestrictedUser,
        Partial,
        Snapshot,
        KeepReplication,
        Online,
        CommitDifferentialBase,
        SnapshotImport,
        EnableBroker,
        NewBroker,
        ErrorBrokerConversations,
        Stats,
        File,
        StopAt,
        MediaName,
        MediaPassword,
        Password,
        BlockSize,
        BufferCount,
        MaxTransferSize,
        Standby,
        EnhancedIntegrity,
        SnapshotRestorePhase,
        Move,
        Stop,
        FileStream = 50,
        KeepTemporalRetention
    }

    [System.Serializable]
    public enum RestoreStatementKind {
        None,
        Database,
        TransactionLog,
        FileListOnly,
        VerifyOnly,
        LabelOnly,
        RewindOnly,
        HeaderOnly
    }

    [System.Serializable]
    public enum ResultSetsOptionKind {
        Undefined,
        None,
        ResultSetsDefined
    }

    [System.Serializable]
    public enum ResultSetType {
        Inline,
        Object,
        Type,
        ForXml
    }

    [System.Serializable]
    public enum RouteOptionKind {
        Address,
        BrokerInstance,
        Lifetime,
        MirrorAddress,
        ServiceName
    }

    [System.Serializable]
    public enum SecondaryXmlIndexType {
        NotSpecified,
        Path,
        Property,
        Value
    }

    [System.Serializable]
    public enum SecurityObjectKind {
        NotSpecified,
        ApplicationRole,
        Assembly,
        AsymmetricKey,
        Certificate,
        Contract,
        Database,
        Endpoint,
        FullTextCatalog,
        Login,
        MessageType,
        Object,
        RemoteServiceBinding,
        Role,
        Route,
        Schema,
        Server,
        Service,
        SymmetricKey,
        Type,
        User,
        XmlSchemaCollection,
        FullTextStopList,
        SearchPropertyList,
        ServerRole,
        AvailabilityGroup
    }

    [System.Serializable]
    public enum SecurityPolicyActionType {
        Create,
        AlterPredicates,
        AlterState,
        AlterReplication
    }

    [System.Serializable]
    public enum SecurityPolicyOptionKind {
        State,
        SchemaBinding
    }

    [System.Serializable]
    public enum SecurityPredicateActionType {
        Create,
        Alter,
        Drop
    }

    [System.Serializable]
    public enum SecurityPredicateOperation {
        All,
        AfterInsert,
        AfterUpdate,
        BeforeUpdate,
        BeforeDelete
    }

    [System.Serializable]
    public enum SecurityPredicateType {
        Filter,
        Block
    }

    [System.Serializable]
    public enum SemanticFunctionType {
        None,
        SemanticKeyPhraseTable,
        SemanticSimilarityTable,
        SemanticSimilarityDetailsTable
    }

    [System.Serializable]
    public enum SeparatorType {
        NotSpecified,
        Dot,
        DoubleColon
    }

    [System.Serializable]
    public enum SequenceOptionKind {
        As,
        MinValue,
        MaxValue,
        Cache,
        Cycle,
        Start,
        Increment,
        Restart
    }

    [System.Serializable]
    public enum ServiceBrokerOption {
        None,
        EnableBroker,
        NewBroker,
        ErrorBrokerConversations
    }

    [System.Serializable]
    public enum SessionOptionKind {
        EventRetention,
        MemoryPartition,
        MaxMemory,
        MaxEventSize,
        MaxDispatchLatency,
        TrackCausality,
        StartUpState
    }

    [System.Serializable]
    [System.Flags]
    public enum SetOffsets {
        None = 0,
        Select = 1,
        From = 2,
        Order = 4,
        Compute = 8,
        Table = 0x10,
        Procedure = 0x20,
        Execute = 0x40,
        Statement = 0x80,
        Param = 0x100
    }

    [System.Serializable]
    [System.Flags]
    public enum SetOptions {
        None = 0,
        QuotedIdentifier = 1,
        ConcatNullYieldsNull = 2,
        CursorCloseOnCommit = 4,
        ArithAbort = 8,
        ArithIgnore = 0x10,
        FmtOnly = 0x20,
        NoCount = 0x40,
        NoExec = 0x80,
        NumericRoundAbort = 0x100,
        ParseOnly = 0x200,
        AnsiDefaults = 0x400,
        AnsiNullDfltOff = 0x800,
        AnsiNullDfltOn = 0x1000,
        AnsiNulls = 0x2000,
        AnsiPadding = 0x4000,
        AnsiWarnings = 0x8000,
        ForcePlan = 0x10000,
        ShowPlanAll = 0x20000,
        ShowPlanText = 0x40000,
        ImplicitTransactions = 0x80000,
        RemoteProcTransactions = 0x100000,
        XactAbort = 0x200000,
        DisableDefCnstChk = 0x400000,
        ShowPlanXml = 0x800000,
        NoBrowsetable = 0x1000000
    }


    [System.Serializable]
    [System.Flags]
    public enum SetStatisticsOptions {
        None = 0,
        IO = 1,
        Profile = 2,
        Time = 4,
        Xml = 8
    }

    [System.Serializable]
    public enum SignableElementKind {
        NotSpecified,
        Object,
        Assembly,
        Database
    }

    [System.Serializable]
    public enum SimpleAlterFullTextIndexActionKind {
        None,
        Enable,
        Disable,
        SetChangeTrackingManual,
        SetChangeTrackingAuto,
        SetChangeTrackingOff,
        StartFullPopulation,
        StartIncrementalPopulation,
        StartUpdatePopulation,
        StopPopulation,
        PausePopulation,
        ResumePopulation
    }


    [System.Serializable]
    public enum SoapMethodFormat {
        NotSpecified,
        AllResults,
        RowsetsOnly,
        None
    }


    [System.Serializable]
    public enum SoapMethodSchemas {
        NotSpecified,
        None,
        Standard,
        Default
    }

    [System.Serializable]
    public enum SortOrder {
        NotSpecified,
        Ascending,
        Descending
    }

    [System.Serializable]
    public enum SparseColumnOption {
        None,
        Sparse,
        ColumnSetForAllSparseColumns
    }

    [System.Serializable]
    public enum SpatialIndexingSchemeType {
        None,
        GeometryGrid,
        GeographyGrid,
        GeometryAutoGrid,
        GeographyAutoGrid
    }

    [System.Serializable]
    public enum SqlDataTypeOption {
        None,
        BigInt,
        Int,
        SmallInt,
        TinyInt,
        Bit,
        Decimal,
        Numeric,
        Money,
        SmallMoney,
        Float,
        Real,
        DateTime,
        SmallDateTime,
        Char,
        VarChar,
        Text,
        NChar,
        NVarChar,
        NText,
        Binary,
        VarBinary,
        Image,
        Cursor,
        Sql_Variant,
        Table,
        Timestamp,
        UniqueIdentifier,
        Date = 29,
        Time,
        DateTime2,
        DateTimeOffset,
        Rowversion
    }

    [System.Serializable]
    public enum SqlEngineType {
        All,
        Standalone,
        SqlAzure
    }

    [System.Serializable]
    public enum StatisticsOptionKind {
        FullScan,
        SamplePercent,
        SampleRows,
        StatsStream,
        NoRecompute,
        Resample,
        RowCount,
        PageCount,
        All,
        Columns,
        Index,
        Rows,
        Incremental
    }

    [System.Serializable]
    public enum SubqueryComparisonPredicateType {
        None,
        All,
        Any
    }

    [System.Serializable]
    public enum TableElementType {
        NotSpecified,
        Constraint,
        Column,
        Index,
        Period
    }

    [System.Serializable]
    public enum TableHintKind {
        None,
        FastFirstRow,
        HoldLock,
        NoLock,
        PagLock,
        ReadCommitted,
        ReadPast,
        ReadUncommitted,
        RepeatableRead,
        Rowlock,
        Serializable,
        TabLock,
        TabLockX,
        UpdLock,
        XLock,
        NoExpand,
        NoWait,
        ReadCommittedLock,
        KeepIdentity,
        KeepDefaults,
        IgnoreConstraints,
        IgnoreTriggers,
        ForceSeek,
        Index,
        SpatialWindowMaxCells,
        ForceScan,
        Snapshot
    }

    [System.Serializable]
    public enum TableOptionKind {
        LockEscalation,
        FileStreamOn,
        DataCompression,
        FileTableDirectory,
        FileTableCollateFileName,
        FileTablePrimaryKeyConstraintName,
        FileTableStreamIdUniqueConstraintName,
        FileTableFullPathUniqueConstraintName,
        MemoryOptimized,
        Durability,
        RemoteDataArchive,
        Distribution,
        Partition
    }

    [System.Serializable]
    public enum TableSampleClauseOption {
        NotSpecified,
        Percent,
        Rows
    }

    [System.Serializable]
    public enum TableSwitchOptionKind {
        LowPriorityLockWait
    }

    [System.Serializable]
    public enum TemporalClauseType {
        AsOf,
        FromTo,
        Between,
        ContainedIn,
        TemporalAll
    }

    [System.Serializable]
    public enum TimeUnit {
        Seconds,
        Minutes,
        Hours,
        Days
    }

    [System.Serializable]
    public enum TriggerActionType {
        Delete,
        Insert,
        Update,
        Event,
        LogOn
    }

    [System.Serializable]
    public enum TriggerEnforcement {
        Disable,
        Enable
    }

    [System.Serializable]
    public enum TriggerOptionKind {
        Encryption,
        ExecuteAsClause,
        NativeCompile,
        SchemaBinding
    }

    [System.Serializable]
    public enum TriggerScope {
        Normal,
        Database,
        AllServer
    }

    [System.Serializable]
    public enum TriggerType {
        Unknown,
        For,
        After,
        InsteadOf
    }

    [System.Serializable]
    public enum UnaryExpressionType {
        Positive,
        Negative,
        BitwiseNot
    }

    [System.Serializable]
    public enum UniqueRowFilter {
        NotSpecified,
        All,
        Distinct
    }

    public enum UnqualifiedJoinType {
        CrossJoin,
        CrossApply,
        OuterApply
    }

    [System.Serializable]
    public enum UserLoginOptionType {
        Login,
        Certificate,
        AsymmetricKey,
        WithoutLogin,
        External
    }

    [System.Serializable]
    public enum UserType80 {
        Null,
        Public,
        Users
    }

    [System.Serializable]
    public enum ViewOptionKind {
        Encryption,
        SchemaBinding,
        ViewMetadata
    }

    [System.Serializable]
    public enum WaitForOption {
        Delay,
        Time,
        Statement
    }

    [System.Serializable]
    public enum WindowDelimiterType {
        UnboundedPreceding,
        ValuePreceding,
        CurrentRow,
        ValueFollowing,
        UnboundedFollowing
    }

    [System.Serializable]
    public enum WindowFrameType {
        Rows,
        Range
    }

    [System.Serializable]
    public enum WorkloadGroupParameterType {
        Importance,
        RequestMaxMemoryGrantPercent,
        RequestMaxCpuTimeSec,
        RequestMemoryGrantTimeoutSec,
        MaxDop,
        GroupMaxRequests,
        GroupMinMemoryPercent
    }

    [System.Serializable]
    public enum XmlDataTypeOption {
        None,
        Content,
        Document
    }

    [System.Serializable]
    [System.Flags]
    public enum XmlForClauseOptions {
        None = 0,
        Raw = 1,
        Auto = 2,
        Explicit = 4,
        Path = 8,
        XmlData = 0x10,
        XmlSchema = 0x20,
        Elements = 0x40,
        ElementsXsiNil = 0x80,
        ElementsAbsent = 0x100,
        BinaryBase64 = 0x200,
        Type = 0x400,
        Root = 0x800,
        ElementsAll = 0x1C0
    }
}
