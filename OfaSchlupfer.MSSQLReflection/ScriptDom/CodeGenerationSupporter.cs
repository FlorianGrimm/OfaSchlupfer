namespace OfaSchlupfer.ScriptDom {
    internal static class CodeGenerationSupporter {
        internal const string KB = "KB";

        internal const string MB = "MB";

        internal const string GB = "GB";

        internal const string TB = "TB";

        internal const string ACP = "ACP";

        internal const string OEM = "OEM";

        internal const string Tcp = "TCP";

        internal const string Http = "HTTP";

        internal const string Year = "YEAR";

        internal const string Years = "YEARS";

        internal const string Month = "MONTH";

        internal const string Months = "MONTHS";

        internal const string Week = "WEEK";

        internal const string Weeks = "WEEKS";

        internal const string Day = "DAY";

        internal const string Days = "DAYS";

        internal const string Hours = "HOURS";

        internal const string Minute = "MINUTE";

        internal const string Minutes = "MINUTES";

        internal const string RC2 = "RC2";

        internal const string RC4 = "RC4";

        internal const string RC4_128 = "RC4_128";

        internal const string Des = "DES";

        internal const string TripleDes = "TRIPLE_DES";

        internal const string TripleDes3Key = "TRIPLE_DES_3KEY";

        internal const string DesX = "DESX";

        internal const string Aes = "AES";

        internal const string Aes128 = "AES_128";

        internal const string Aes192 = "AES_192";

        internal const string Aes256 = "AES_256";

        internal const string Rsa512 = "RSA_512";

        internal const string Rsa1024 = "RSA_1024";

        internal const string Rsa2048 = "RSA_2048";

        internal const string Rsa3072 = "RSA_3072";

        internal const string Rsa4096 = "RSA_4096";

        internal const string QuotedIdentifier = "QUOTED_IDENTIFIER";

        internal const string ConcatNullYieldsNull = "CONCAT_NULL_YIELDS_NULL";

        internal const string ArithAbort = "ARITHABORT";

        internal const string ArithIgnore = "ARITHIGNORE";

        internal const string FmtOnly = "FMTONLY";

        internal const string NoCompression = "NO_COMPRESSION";

        internal const string NoCount = "NOCOUNT";

        internal const string NoExec = "NOEXEC";

        internal const string NumericRoundAbort = "NUMERIC_ROUNDABORT";

        internal const string ParseOnly = "PARSEONLY";

        internal const string AnsiDefaults = "ANSI_DEFAULTS";

        internal const string AnsiNullDfltOff = "ANSI_NULL_DFLT_OFF";

        internal const string AnsiNullDfltOn = "ANSI_NULL_DFLT_ON";

        internal const string AnsiNulls = "ANSI_NULLS";

        internal const string AnsiPadding = "ANSI_PADDING";

        internal const string AnsiWarnings = "ANSI_WARNINGS";

        internal const string ForcePlan = "FORCEPLAN";

        internal const string ShowPlanAll = "SHOWPLAN_ALL";

        internal const string ShowPlanText = "SHOWPLAN_TEXT";

        internal const string IO = "IO";

        internal const string Profile = "PROFILE";

        internal const string ImplicitTransactions = "IMPLICIT_TRANSACTIONS";

        internal const string RemoteProcTransactions = "REMOTE_PROC_TRANSACTIONS";

        internal const string XactAbort = "XACT_ABORT";

        internal const string Abort = "ABORT";

        internal const string AbortAfterWait = "ABORT_AFTER_WAIT";

        internal const string Absent = "ABSENT";

        internal const string Absolute = "ABSOLUTE";

        internal const string AccentSensitivity = "ACCENT_SENSITIVITY";

        internal const string Action = "ACTION";

        internal const string Active = "ACTIVE";

        internal const string Activation = "ACTIVATION";

        internal const string Add = "ADD";

        internal const string Address = "ADDRESS";

        internal const string Admin = "ADMIN";

        internal const string Affinity = "AFFINITY";

        internal const string After = "AFTER";

        internal const string Aggregate = "AGGREGATE";

        internal const string Algorithm = "ALGORITHM";

        internal const string AlterColumn = "ALTERCOLUMN";

        internal const string All = "ALL";

        internal const string AllConstraints = "ALL_CONSTRAINTS";

        internal const string AllErrorMessages = "ALL_ERRORMSGS";

        internal const string AllIndexes = "ALL_INDEXES";

        internal const string AllLevels = "ALL_LEVELS";

        internal const string AllowConnections = "ALLOW_CONNECTIONS";

        internal const string Allowed = "ALLOWED";

        internal const string AllowMultipleEventLoss = "ALLOW_MULTIPLE_EVENT_LOSS";

        internal const string AllowSingleEventLoss = "ALLOW_SINGLE_EVENT_LOSS";

        internal const string AllowSnapshotIsolation = "ALLOW_SNAPSHOT_ISOLATION";

        internal const string AllowPageLocks = "ALLOW_PAGE_LOCKS";

        internal const string AllowRowLocks = "ALLOW_ROW_LOCKS";

        internal const string AllResults = "ALL_RESULTS";

        internal const string AllSparseColumns = "ALL_SPARSE_COLUMNS";

        internal const string Always = "ALWAYS";

        internal const string Anonymous = "ANONYMOUS";

        internal const string AnsiNullDefault = "ANSI_NULL_DEFAULT";

        internal const string Application = "APPLICATION";

        internal const string ApplicationLog = "APPLICATION_LOG";

        internal const string Apply = "APPLY";

        internal const string ApplyDelay = "APPLY_DELAY";

        internal const string Assembly = "ASSEMBLY";

        internal const string Asymmetric = "ASYMMETRIC";

        internal const string AsynchronousCommit = "ASYNCHRONOUS_COMMIT";

        internal const string At = "AT";

        internal const string Attach = "ATTACH";

        internal const string AttachRebuildLog = "ATTACH_REBUILD_LOG";

        internal const string AttachForceRebuildLog = "ATTACH_FORCE_REBUILD_LOG";

        internal const string Atomic = "ATOMIC";

        internal const string Append = "APPEND";

        internal const string Avg = "AVG";

        internal const string Attested = "ATTESTED";

        internal const string AuditGuid = "AUDIT_GUID";

        internal const string Authentication = "AUTHENTICATION";

        internal const string AuthRealm = "AUTH_REALM";

        internal const string Auto = "AUTO";

        internal const string AutoCleanup = "AUTO_CLEANUP";

        internal const string AutoClose = "AUTO_CLOSE";

        internal const string AutoCreateStatistics = "AUTO_CREATE_STATISTICS";

        internal const string AutogrowAllFiles = "AUTOGROW_ALL_FILES";

        internal const string AutogrowSingleFile = "AUTOGROW_SINGLE_FILE";

        internal const string Automatic = "AUTOMATIC";

        internal const string AutomaticTuning = "AUTOMATIC_TUNING";

        internal const string AutoShrink = "AUTO_SHRINK";

        internal const string AutoUpdateStatistics = "AUTO_UPDATE_STATISTICS";

        internal const string AutoUpdateStatisticsAsync = "AUTO_UPDATE_STATISTICS_ASYNC";

        internal const string Availability = "AVAILABILITY";

        internal const string AvailabilityMode = "AVAILABILITY_MODE";

        internal const string Base64 = "BASE64";

        internal const string Basic = "BASIC";

        internal const string Batches = "BATCHES";

        internal const string BatchSize = "BATCHSIZE";

        internal const string Before = "BEFORE";

        internal const string BeginDialog = "BEGIN_DIALOG";

        internal const string BigInt = "BIGINT";

        internal const string Binding = "BINDING";

        internal const string Binary = "BINARY";

        internal const string Bit = "BIT";

        internal const string BlobStorage = "BLOB_STORAGE";

        internal const string Block = "BLOCK";

        internal const string Blockers = "BLOCKERS";

        internal const string BlockSize = "BLOCKSIZE";

        internal const string BoundingBox = "BOUNDING_BOX";

        internal const string Broker = "BROKER";

        internal const string BrokerInstance = "BROKER_INSTANCE";

        internal const string BufferCount = "BUFFERCOUNT";

        internal const string BucketCount = "BUCKET_COUNT";

        internal const string BulkLogged = "BULK_LOGGED";

        internal const string Bypass = "BYPASS";

        internal const string Cache = "CACHE";

        internal const string Called = "CALLED";

        internal const string Caller = "CALLER";

        internal const string CapCpuPercent = "CAP_CPU_PERCENT";

        internal const string CapIoPercent = "CAP_IO_PERCENT";

        internal const string CardinalityTunerLimit = "CARDINALITY_TUNER_LIMIT";

        internal const string Cast = "CAST";

        internal const string Catalog = "CATALOG";

        internal const string CatalogCollation = "CATALOG_COLLATION";

        internal const string Catch = "CATCH";

        internal const string CellsPerObject = "CELLS_PER_OBJECT";

        internal const string Certificate = "CERTIFICATE";

        internal const string ChangeRetention = "CHANGE_RETENTION";

        internal const string Changes = "CHANGES";

        internal const string ChangeTable = "CHANGETABLE";

        internal const string ChangeTracking = "CHANGE_TRACKING";

        internal const string ChangeTrackingContext = "CHANGE_TRACKING_CONTEXT";

        internal const string Char = "CHAR";

        internal const string CharacterSet = "CHARACTER_SET";

        internal const string CheckConstraints = "CHECK_CONSTRAINTS";

        internal const string CheckConstraintsHint = "CHECKCONSTRAINTS";

        internal const string CheckExpiration = "CHECK_EXPIRATION";

        internal const string CheckPolicy = "CHECK_POLICY";

        internal const string Checksum = "CHECKSUM";

        internal const string ChecksumAgg = "CHECKSUM_AGG";

        internal const string ModularSum = "MODULAR_SUM";

        internal const string ClassifierFunction = "CLASSIFIER_FUNCTION";

        internal const string Cleanup = "CLEANUP";

        internal const string CleanupPolicy = "CLEANUP_POLICY";

        internal const string Clear = "CLEAR";

        internal const string Cluster = "CLUSTER";

        internal const string Clustered = "CLUSTERED";

        internal const string ClearPort = "CLEAR_PORT";

        internal const string CodePage = "CODEPAGE";

        internal const string Collection = "COLLECTION";

        internal const string Column = "COLUMN";

        internal const string ColumnEncryptionKey = "COLUMN_ENCRYPTION_KEY";

        internal const string ColumnMasterKey = "COLUMN_MASTER_KEY";

        internal const string Columns = "COLUMNS";

        internal const string ColumnSet = "COLUMN_SET";

        internal const string ColumnStore = "COLUMNSTORE";

        internal const string ColumnStoreArchive = "COLUMNSTORE_ARCHIVE";

        internal const string CommitDifferentialBase = "COMMIT_DIFFERENTIAL_BASE";

        internal const string Committed = "COMMITTED";

        internal const string CompatibilityLevel = "COMPATIBILITY_LEVEL";

        internal const string Compression = "COMPRESSION";

        internal const string CompressionDelay = "COMPRESSION_DELAY";

        internal const string CompressAllRowGroups = "COMPRESS_ALL_ROW_GROUPS";

        internal const string Concat = "CONCAT";

        internal const string Configuration = "CONFIGURATION";

        internal const string Contained = "CONTAINED";

        internal const string Containment = "CONTAINMENT";

        internal const string Content = "CONTENT";

        internal const string Context = "CONTEXT";

        internal const string ContextInfo = "CONTEXT_INFO";

        internal const string ContinueAfterError = "CONTINUE_AFTER_ERROR";

        internal const string Contract = "CONTRACT";

        internal const string ContractName = "CONTRACT_NAME";

        internal const string Conversation = "CONVERSATION";

        internal const string ConversationGroupId = "CONVERSATION_GROUP_ID";

        internal const string ConversationHandle = "CONVERSATION_HANDLE";

        internal const string Cookie = "COOKIE";

        internal const string Copy = "COPY";

        internal const string CopyOnly = "COPY_ONLY";

        internal const string Correlated = "CORRELATED";

        internal const string Count = "COUNT";

        internal const string CountBig = "COUNT_BIG";

        internal const string Counter = "COUNTER";

        internal const string CountRows = "COUNT_ROWS";

        internal const string Cpu = "CPU";

        internal const string CreateNew = "CREATE_NEW";

        internal const string CreationDisposition = "CREATION_DISPOSITION";

        internal const string Credential = "CREDENTIAL";

        internal const string Cryptographic = "CRYPTOGRAPHIC";

        internal const string Csv = "CSV";

        internal const string Cube = "CUBE";

        internal const string Cuid = "CUID";

        internal const string CursorCloseOnCommit = "CURSOR_CLOSE_ON_COMMIT";

        internal const string CursorDefault = "CURSOR_DEFAULT";

        internal const string Custom = "CUSTOM";

        internal const string Cycle = "Cycle";

        internal const string D = "D";

        internal const string Data = "DATA";

        internal const string Database = "DATABASE";

        internal const string DatabaseDefault = "DATABASE_DEFAULT";

        internal const string DatabaseMirroring = "DATABASE_MIRRORING";

        internal const string DatabaseName = "DATABASE_NAME";

        internal const string DatabaseSnapshot = "DATABASE_SNAPSHOT";

        internal const string DataCompression = "DATA_COMPRESSION";

        internal const string DataConsistencyCheck = "DATA_CONSISTENCY_CHECK";

        internal const string DataFileType = "DATAFILETYPE";

        internal const string DataMirroring = "DATA_MIRRORING";

        internal const string DataPurity = "DATA_PURITY";

        internal const string DataSource = "DATA_SOURCE";

        internal const string Date = "DATE";

        internal const string DateCorrelationOptimization = "DATE_CORRELATION_OPTIMIZATION";

        internal const string DateFirst = "DATEFIRST";

        internal const string DateFormat = "DATEFORMAT";

        internal const string DateFormat2 = "DATE_FORMAT";

        internal const string DateTime = "DATETIME";

        internal const string DateTime2 = "DATETIME2";

        internal const string DateTimeOffset = "DATETIMEOFFSET";

        internal const string Deterministic = "DETERMINISTIC";

        internal const string DboOnly = "DBO_ONLY";

        internal const string DbChaining = "DB_CHAINING";

        internal const string DeadlockPriority = "DEADLOCK_PRIORITY";

        internal const string Decimal = "DECIMAL";

        internal const string Decryption = "DECRYPTION";

        internal const string Default = "DEFAULT";

        internal const string DefaultDatabase = "DEFAULT_DATABASE";

        internal const string DefaultFullTextLanguage = "DEFAULT_FULLTEXT_LANGUAGE";

        internal const string DefaultLanguage = "DEFAULT_LANGUAGE";

        internal const string DefaultSchema = "DEFAULT_SCHEMA";

        internal const string DefaultLogonDomain = "DEFAULT_LOGON_DOMAIN";

        internal const string DensityVector = "DENSITY_VECTOR";

        internal const string Dependents = "DEPENDENTS";

        internal const string Description = "DESCRIPTION";

        internal const string DesiredState = "DESIRED_STATE";

        internal const string Delay = "DELAY";

        internal const string DelayedDurability = "DELAYED_DURABILITY";

        internal const string DelimitedText = "DELIMITEDTEXT";

        internal const string Diagnostics = "DIAGNOSTICS";

        internal const string Dialog = "DIALOG";

        internal const string Differential = "DIFFERENTIAL";

        internal const string Digest = "DIGEST";

        internal const string DirectoryName = "DIRECTORY_NAME";

        internal const string Disable = "DISABLE";

        internal const string Disabled = "DISABLED";

        internal const string DisableBroker = "DISABLE_BROKER";

        internal const string DisableDefCnstChk = "DISABLE_DEF_CNST_CHK";

        internal const string Disk = "DISK";

        internal const string Distribution = "DISTRIBUTION";

        internal const string Document = "DOCUMENT";

        internal const string DollarSign = "$";

        internal const string DollarPartition = "$PARTITION";

        internal const string Drop = "DROP";

        internal const string DropExisting = "DROP_EXISTING";

        internal const string DTSBuffers = "DTS_BUFFERS";

        internal const string Durability = "DURABILITY";

        internal const string Dynamic = "DYNAMIC";

        internal const string Edition = "EDITION";

        internal const string Elements = "ELEMENTS";

        internal const string Emergency = "EMERGENCY";

        internal const string Empty = "EMPTY";

        internal const string Enable = "ENABLE";

        internal const string Enabled = "ENABLED";

        internal const string EnableBroker = "ENABLE_BROKER";

        internal const string Encrypted = "ENCRYPTED";

        internal const string EncryptedValue = "ENCRYPTED_VALUE";

        internal const string Encryption = "ENCRYPTION";

        internal const string EncryptionType = "ENCRYPTION_TYPE";

        internal const string EnhancedIntegrity = "ENHANCEDINTEGRITY";

        internal const string End = "END";

        internal const string Endpoint = "ENDPOINT";

        internal const string EndpointUrl = "ENDPOINT_URL";

        internal const string Entry = "ENTRY";

        internal const string Equal = "=";

        internal const string Error = "ERROR";

        internal const string ErrorBrokerConversations = "ERROR_BROKER_CONVERSATIONS";

        internal const string ErrorDataSource = "ERRORFILE_DATA_SOURCE";

        internal const string ErrorFile = "ERRORFILE";

        internal const string EstimateOnly = "ESTIMATEONLY";

        internal const string Event = "EVENT";

        internal const string EventRetentionMode = "EVENT_RETENTION_MODE";

        internal const string Exclamation = "!";

        internal const string Executable = "EXECUTABLE";

        internal const string Explicit = "EXPLICIT";

        internal const string Expand = "EXPAND";

        internal const string ExpireDate = "EXPIREDATE";

        internal const string ExpiryDate = "EXPIRY_DATE";

        internal const string ExtendedLogicalChecks = "EXTENDED_LOGICAL_CHECKS";

        internal const string Extension = "EXTENSION";

        internal const string External = "EXTERNAL";

        internal const string ExternalAccess = "EXTERNAL_ACCESS";

        internal const string Extract = "EXTRACT";

        internal const string FailOperation = "FAIL_OPERATION";

        internal const string Failover = "FAILOVER";

        internal const string FailoverMode = "FAILOVER_MODE";

        internal const string FailureConditionLevel = "FailureConditionLevel";

        internal const string False = "FALSE";

        internal const string FanIn = "FAN_IN";

        internal const string Fast = "FAST";

        internal const string FastForward = "FAST_FORWARD";

        internal const string FastFirstRow = "FASTFIRSTROW";

        internal const string Federated = "FEDERATED";

        internal const string FederatedServiceAccount = "FEDERATED_SERVICE_ACCOUNT";

        internal const string Federation = "FEDERATION";

        internal const string File = "FILE";

        internal const string FileFormat = "FILE_FORMAT";

        internal const string Filegroup = "FILEGROUP";

        internal const string FileGrowth = "FILEGROWTH";

        internal const string FileListOnly = "FILELISTONLY";

        internal const string FileName = "FILENAME";

        internal const string FilePath = "FILEPATH";

        internal const string FileStream = "FILESTREAM";

        internal const string FileStreamOn = "FILESTREAM_ON";

        internal const string FileTable = "FILETABLE";

        internal const string FileTableCollateFileName = "FILETABLE_COLLATE_FILENAME";

        internal const string FileTableDirectory = "FILETABLE_DIRECTORY";

        internal const string FileTableFullPathUniqueConstraintName = "FILETABLE_FULLPATH_UNIQUE_CONSTRAINT_NAME";

        internal const string FileTableNamespace = "FILETABLE_NAMESPACE";

        internal const string FileTablePrimaryKeyConstraintName = "FILETABLE_PRIMARY_KEY_CONSTRAINT_NAME";

        internal const string FileTableStreamIdUniqueConstraintName = "FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME";

        internal const string FillFactor = "FILLFACTOR";

        internal const string Filtering = "FILTERING";

        internal const string Filter = "FILTER";

        internal const string FilterPredicate = "FILTER_PREDICATE";

        internal const string FireTriggers = "FIRE_TRIGGERS";

        internal const string FirstRow = "FIRSTROW";

        internal const string FieldTerminator = "FIELDTERMINATOR";

        internal const string FieldTerminator2 = "FIELD_TERMINATOR";

        internal const string FieldQuote = "FIELDQUOTE";

        internal const string FipsFlagger = "FIPS_FLAGGER";

        internal const string First = "FIRST";

        internal const string FlushIntervalSeconds = "FLUSH_INTERVAL_SECONDS";

        internal const string FlushIntervalSecondsAlt = "DATA_FLUSH_INTERVAL_SECONDS";

        internal const string Fn = "FN";

        internal const string Float = "FLOAT";

        internal const string For = "FOR";

        internal const string ForceFailoverAllowDataLoss = "FORCE_FAILOVER_ALLOW_DATA_LOSS";

        internal const string ForceScan = "FORCESCAN";

        internal const string ForceSeek = "FORCESEEK";

        internal const string ForceServiceAllowDataLoss = "FORCE_SERVICE_ALLOW_DATA_LOSS";

        internal const string ForwardOnly = "FORWARD_ONLY";

        internal const string Force = "FORCE";

        internal const string Forced = "FORCED";

        internal const string ForceLastGoodPlan = "FORCE_LAST_GOOD_PLAN";

        internal const string Format = "FORMAT";

        internal const string FormatDataSource = "FORMATFILE_DATA_SOURCE";

        internal const string FormatOptions = "FORMAT_OPTIONS";

        internal const string FormatFile = "FORMATFILE";

        internal const string FormatType = "FORMAT_TYPE";

        internal const string Full = "FULL";

        internal const string FullScan = "FULLSCAN";

        internal const string Fulltext = "FULLTEXT";

        internal const string General = "GENERAL";

        internal const string Generated = "GENERATED";

        internal const string GeographyAutoGrid = "GEOGRAPHY_AUTO_GRID";

        internal const string GeographyGrid = "GEOGRAPHY_GRID";

        internal const string GeometryAutoGrid = "GEOMETRY_AUTO_GRID";

        internal const string GeometryGrid = "GEOMETRY_GRID";

        internal const string Get = "GET";

        internal const string Global = "GLOBAL";

        internal const string Governor = "GOVERNOR";

        internal const string Grids = "GRIDS";

        internal const string Group = "GROUP";

        internal const string Grouping = "GROUPING";

        internal const string GroupMaxRequests = "GROUP_MAX_REQUESTS";

        internal const string GroupMinMemoryPercent = "GROUP_MIN_MEMORY_PERCENT";

        internal const string Guid = "GUID";

        internal const string Hadr = "HADR";

        internal const string Hadoop = "HADOOP";

        internal const string Hash = "HASH";

        internal const string Hashed = "HASHED";

        internal const string HeaderLimit = "HEADER_LIMIT";

        internal const string HeaderOnly = "HEADERONLY";

        internal const string HealthCheckTimeout = "HealthCheckTimeout";

        internal const string Heap = "HEAP";

        internal const string Hidden = "HIDDEN";

        internal const string High = "HIGH";

        internal const string Hint = "HINT";

        internal const string Histogram = "HISTOGRAM";

        internal const string HistogramSteps = "HISTOGRAM_STEPS";

        internal const string HistoryRetentionPeriod = "HISTORY_RETENTION_PERIOD";

        internal const string HistoryTable = "HISTORY_TABLE";

        internal const string HonorBrokerPriority = "HONOR_BROKER_PRIORITY";

        internal const string Identity = "IDENTITY";

        internal const string IdentityValue = "IDENTITY_VALUE";

        internal const string IgnoreConstraints = "IGNORE_CONSTRAINTS";

        internal const string IgnoreDupKey = "IGNORE_DUP_KEY";

        internal const string IgnoreNonClusteredColumnStoreIndex = "IGNORE_NONCLUSTERED_COLUMNSTORE_INDEX";

        internal const string IgnoreTriggers = "IGNORE_TRIGGERS";

        internal const string IIf = "IIF";

        internal const string Image = "IMAGE";

        internal const string Immediate = "IMMEDIATE";

        internal const string Importance = "IMPORTANCE";

        internal const string Inbound = "INBOUND";

        internal const string Include = "INCLUDE";

        internal const string IncludeHidden = "INCLUDE_HIDDEN";

        internal const string IncludeNullValues = "INCLUDE_NULL_VALUES";

        internal const string Increment = "INCREMENT";

        internal const string Incremental = "INCREMENTAL";

        internal const string Infinite = "INFINITE";

        internal const string Inherit = "INHERIT";

        internal const string Init = "INIT";

        internal const string Initiator = "INITIATOR";

        internal const string Input = "INPUT";

        internal const string Instead = "INSTEAD";

        internal const string Int = "INT";

        internal const string Integrated = "INTEGRATED";

        internal const string Intermediate = "INTERMEDIATE";

        internal const string IntervalLengthMinutes = "INTERVAL_LENGTH_MINUTES";

        internal const string Insensitive = "INSENSITIVE";

        internal const string IRowset = "IROWSET";

        internal const string Isolation = "ISOLATION";

        internal const string Job = "JOB";

        internal const string Json = "JSON";

        internal const string Keep = "KEEP";

        internal const string KeepDefaults = "KEEPDEFAULTS";

        internal const string KeepFixed = "KEEPFIXED";

        internal const string KeepIdentity = "KEEPIDENTITY";

        internal const string KeepNulls = "KEEPNULLS";

        internal const string KeepReplication = "KEEP_REPLICATION";

        internal const string KeepTemporalRetention = "KEEP_TEMPORAL_RETENTION";

        internal const string Kerberos = "KERBEROS";

        internal const string Key = "KEY";

        internal const string Keys = "KEYS";

        internal const string Keyset = "KEYSET";

        internal const string KeySource = "KEY_SOURCE";

        internal const string KeyStoreProviderName = "KEY_STORE_PROVIDER_NAME";

        internal const string KeyPath = "KEY_PATH";

        internal const string KilobytesPerBatch = "KILOBYTES_PER_BATCH";

        internal const string LabelOnly = "LABELONLY";

        internal const string Language = "LANGUAGE";

        internal const string Last = "LAST";

        internal const string LastRow = "LASTROW";

        internal const string LegacyCardinalityEstimation = "LEGACY_CARDINALITY_ESTIMATION";

        internal const string Level = "LEVEL";

        internal const string Level1 = "LEVEL_1";

        internal const string Level2 = "LEVEL_2";

        internal const string Level3 = "LEVEL_3";

        internal const string Level4 = "LEVEL_4";

        internal const string LifeTime = "LIFETIME";

        internal const string List = "LIST";

        internal const string ListenerIP = "LISTENER_IP";

        internal const string ListenerPort = "LISTENER_PORT";

        internal const string Load = "LOAD";

        internal const string LoadHistory = "LOADHISTORY";

        internal const string LobCompaction = "LOB_COMPACTION";

        internal const string Local = "LOCAL";

        internal const string Location = "LOCATION";

        internal const string LocalServiceName = "LOCAL_SERVICE_NAME";

        internal const string LockTimeout = "LOCK_TIMEOUT";

        internal const string Log = "LOG";

        internal const string Login = "LOGIN";

        internal const string LoginType = "LOGIN_TYPE";

        internal const string Logon = "LOGON";

        internal const string Loop = "LOOP";

        internal const string Low = "LOW";

        internal const string LSquareParen = "[";

        internal const string MaintainIndex = "MAINTAIN_INDEX";

        internal const string Manual = "MANUAL";

        internal const string Mark = "MARK";

        internal const string MarkInUseForRemoval = "MARK_IN_USE_FOR_REMOVAL";

        internal const string Masked = "MASKED";

        internal const string Master = "MASTER";

        internal const string Matched = "MATCHED";

        internal const string Max = "MAX";

        internal const string MaxCpuPercent = "MAX_CPU_PERCENT";

        internal const string MaxDispatchLatency = "MAX_DISPATCH_LATENCY";

        internal const string MaxDop = "MAXDOP";

        internal const string Max_Dop = "MAX_DOP";

        internal const string MaxDuration = "MAX_DURATION";

        internal const string MaxErrors = "MAXERRORS";

        internal const string MaxEventSize = "MAX_EVENT_SIZE";

        internal const string MaxFiles = "MAX_FILES";

        internal const string MaxGrantPercent = "MAX_GRANT_PERCENT";

        internal const string MaxLength = "MAXLENGTH";

        internal const string MaxIoPercent = "MAX_IO_PERCENT";

        internal const string MaxIopsPerVolume = "MAX_IOPS_PER_VOLUME";

        internal const string MaxMemory = "MAX_MEMORY";

        internal const string MaxMemoryPercent = "MAX_MEMORY_PERCENT";

        internal const string MaxPlansPerQuery = "MAX_PLANS_PER_QUERY";

        internal const string MaxProcesses = "MAX_PROCESSES";

        internal const string MaxQueueReaders = "MAX_QUEUE_READERS";

        internal const string MaxQdsSize = "MAX_STORAGE_SIZE_MB";

        internal const string MaxRecursion = "MAXRECURSION";

        internal const string MaxRolloverFiles = "MAX_ROLLOVER_FILES";

        internal const string MaxUnderscoreSize = "MAX_SIZE";

        internal const string MaxSize = "MAXSIZE";

        internal const string MaxTransferSize = "MAXTRANSFERSIZE";

        internal const string MaxValue = "MAXVALUE";

        internal const string MediaDescription = "MEDIADESCRIPTION";

        internal const string MediaName = "MEDIANAME";

        internal const string MediaPassword = "MEDIAPASSWORD";

        internal const string Medium = "MEDIUM";

        internal const string Member = "MEMBER";

        internal const string MemoryOptimized = "MEMORY_OPTIMIZED";

        internal const string MemoryOptimizedData = "MEMORY_OPTIMIZED_DATA";

        internal const string MemoryOptimizedElevateToSnapshot = "MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT";

        internal const string MemoryPartitionMode = "MEMORY_PARTITION_MODE";

        internal const string Merge = "MERGE";

        internal const string Message = "MESSAGE";

        internal const string MessageForwarding = "MESSAGE_FORWARDING";

        internal const string MessageForwardSize = "MESSAGE_FORWARD_SIZE";

        internal const string MigrationState = "MIGRATION_STATE";

        internal const string Min = "MIN";

        internal const string MinGrantPercent = "MIN_GRANT_PERCENT";

        internal const string MinCpuPercent = "MIN_CPU_PERCENT";

        internal const string MinIoPercent = "MIN_IO_PERCENT";

        internal const string MinIopsPerVolume = "MIN_IOPS_PER_VOLUME";

        internal const string MinMemoryPercent = "MIN_MEMORY_PERCENT";

        internal const string MinValue = "MINVALUE";

        internal const string MirrorAddress = "MIRROR_ADDRESS";

        internal const string Mirror = "MIRROR";

        internal const string Mixed = "MIXED";

        internal const string MixedPageAllocation = "MIXED_PAGE_ALLOCATION";

        internal const string Modify = "MODIFY";

        internal const string Money = "MONEY";

        internal const string Move = "MOVE";

        internal const string MultiUser = "MULTI_USER";

        internal const string MustChange = "MUST_CHANGE";

        internal const string Name = "NAME";

        internal const string Namespace = "NAMESPACE";

        internal const string Native = "NATIVE";

        internal const string NativeCompilation = "NATIVE_COMPILATION";

        internal const string NChar = "NCHAR";

        internal const string Negotiate = "NEGOTIATE";

        internal const string Never = "NEVER";

        internal const string NestedTriggers = "NESTED_TRIGGERS";

        internal const string NewAccount = "NEW_ACCOUNT";

        internal const string NewName = "NEWNAME";

        internal const string NewBroker = "NEW_BROKER";

        internal const string NewPassword = "NEW_PASSWORD";

        internal const string Next = "NEXT";

        internal const string No = "NO";

        internal const string NoChecksum = "NO_CHECKSUM";

        internal const string NoEventLoss = "NO_EVENT_LOSS";

        internal const string NoExpand = "NOEXPAND";

        internal const string NoFormat = "NOFORMAT";

        internal const string NoInfoMessages = "NO_INFOMSGS";

        internal const string NoInit = "NOINIT";

        internal const string NoLock = "NOLOCK";

        internal const string NoLog = "NO_LOG";

        internal const string NoBrowsetable = "NO_BROWSETABLE";

        internal const string NonTransactedAccess = "NON_TRANSACTED_ACCESS";

        internal const string NoPerformanceSpool = "NO_PERFORMANCE_SPOOL";

        internal const string NoRecompute = "NORECOMPUTE";

        internal const string NoRecovery = "NORECOVERY";

        internal const string NoReset = "NORESET";

        internal const string NoRewind = "NOREWIND";

        internal const string None = "NONE";

        internal const string NoSkip = "NOSKIP";

        internal const string NoTriggers = "NO_TRIGGERS";

        internal const string NoTruncate = "NO_TRUNCATE";

        internal const string Notification = "NOTIFICATION";

        internal const string NoWait = "NOWAIT";

        internal const string NoUnload = "NOUNLOAD";

        internal const string NoWaitAlterDb = "NO_WAIT";

        internal const string NText = "NTEXT";

        internal const string Ntlm = "NTLM";

        internal const string NumaNode = "NUMANODE";

        internal const string Numeric = "NUMERIC";

        internal const string NVarChar = "NVARCHAR";

        internal const string Object = "OBJECT";

        internal const string ObjectName = "OBJECT_NAME";

        internal const string Off = "OFF";

        internal const string Offline = "OFFLINE";

        internal const string Offset = "OFFSET";

        internal const string OffWithoutDataRecovery = "OFF_WITHOUT_DATA_RECOVERY";

        internal const string Oj = "OJ";

        internal const string OldAccount = "OLD_ACCOUNT";

        internal const string OldPassword = "OLD_PASSWORD";

        internal const string On = "ON";

        internal const string OnFailure = "ON_FAILURE";

        internal const string Online = "ONLINE";

        internal const string Only = "ONLY";

        internal const string OpenExisting = "OPEN_EXISTING";

        internal const string OpenJson = "OPENJSON";

        internal const string OperationMode = "OPERATION_MODE";

        internal const string Optimistic = "OPTIMISTIC";

        internal const string Optimize = "OPTIMIZE";

        internal const string OptimizerQueue = "OPTIMIZER_QUEUE";

        internal const string Order = "ORDER";

        internal const string Orc = "ORC";

        internal const string Out = "OUT";

        internal const string Outbound = "OUTBOUND";

        internal const string Output = "OUTPUT";

        internal const string Override = "OVERRIDE";

        internal const string Owner = "OWNER";

        internal const string PadIndex = "PAD_INDEX";

        internal const string Page = "PAGE";

        internal const string PageCount = "PAGECOUNT";

        internal const string PageVerify = "PAGE_VERIFY";

        internal const string PagLock = "PAGLOCK";

        internal const string Param = "PARAM";

        internal const string Parameter = "PARAMETER";

        internal const string Parameterization = "PARAMETERIZATION";

        internal const string ParameterSniffing = "PARAMETER_SNIFFING";

        internal const string Parquet = "PARQUET";

        internal const string Parse = "PARSE";

        internal const string Partition = "PARTITION";

        internal const string Partitions = "PARTITIONS";

        internal const string Partner = "PARTNER";

        internal const string Password = "PASSWORD";

        internal const string Path = "PATH";

        internal const string Partial = "PARTIAL";

        internal const string Pause = "PAUSE";

        internal const string Paused = "PAUSED";

        internal const string Percentage = "PERCENTAGE";

        internal const string PerCpu = "PER_CPU";

        internal const string Period = "PERIOD";

        internal const string PermissionSet = "PERMISSION_SET";

        internal const string PerNode = "PER_NODE";

        internal const string Persisted = "PERSISTED";

        internal const string PhysicalOnly = "PHYSICAL_ONLY";

        internal const string PhysName = "PHYSNAME";

        internal const string Pivot = "PIVOT";

        internal const string PoisonMessageHandling = "POISON_MESSAGE_HANDLING";

        internal const string Policy = "POLICY";

        internal const string Pool = "POOL";

        internal const string Population = "POPULATION";

        internal const string Ports = "PORTS";

        internal const string Precision = "PRECISION";

        internal const string Predicate = "PREDICATE";

        internal const string Primary = "PRIMARY";

        internal const string PrimaryRole = "PRIMARY_ROLE";

        internal const string Prior = "PRIOR";

        internal const string Priority = "PRIORITY";

        internal const string PriorityLevel = "PRIORITY_LEVEL";

        internal const string Private = "PRIVATE";

        internal const string Privileges = "PRIVILEGES";

        internal const string Process = "PROCESS";

        internal const string PropertySetGuid = "PROPERTY_SET_GUID";

        internal const string PropertyIntId = "PROPERTY_INT_ID";

        internal const string PropertyDescription = "PROPERTY_DESCRIPTION";

        internal const string Provider = "PROVIDER";

        internal const string ProviderKeyName = "PROVIDER_KEY_NAME";

        internal const string Procedure = "PROCEDURE";

        internal const string ProcedureCache = "PROCEDURE_CACHE";

        internal const string ProcedureName = "PROCEDURE_NAME";

        internal const string Property = "PROPERTY";

        internal const string Queue = "QUEUE";

        internal const string QueueDelay = "QUEUE_DELAY";

        internal const string Query = "QUERY";

        internal const string QueryCaptureMode = "QUERY_CAPTURE_MODE";

        internal const string QueryGovernorCostLimit = "QUERY_GOVERNOR_COST_LIMIT";

        internal const string QueryStore = "QUERY_STORE";

        internal const string QueryTraceOn = "QUERYTRACEON";

        internal const string QueryOptimizerHotFixes = "QUERY_OPTIMIZER_HOTFIXES";

        internal const string Randomized = "RANDOMIZED";

        internal const string Range = "RANGE";

        internal const string Raw = "RAW";

        internal const string RcFile = "RCFILE";

        internal const string Rdbms = "RDBMS";

        internal const string ReadCommitted = "READCOMMITTED";

        internal const string ReadCommittedLock = "READCOMMITTEDLOCK";

        internal const string ReadCommittedSnapshot = "READ_COMMITTED_SNAPSHOT";

        internal const string Read = "READ";

        internal const string ReadPast = "READPAST";

        internal const string ReadOnlyOld = "READONLY";

        internal const string ReadOnly = "READ_ONLY";

        internal const string ReadUncommitted = "READUNCOMMITTED";

        internal const string ReadWrite = "READ_WRITE";

        internal const string ReadWriteFilegroups = "READ_WRITE_FILEGROUPS";

        internal const string ReadWriteOld = "READWRITE";

        internal const string Real = "REAL";

        internal const string Rebuild = "REBUILD";

        internal const string Receive = "RECEIVE";

        internal const string Recompile = "RECOMPILE";

        internal const string RecursiveTriggers = "RECURSIVE_TRIGGERS";

        internal const string Recovery = "RECOVERY";

        internal const string Regenerate = "REGENERATE";

        internal const string RejectType = "REJECT_TYPE";

        internal const string RejectSampleValue = "REJECT_SAMPLE_VALUE";

        internal const string RejectValue = "REJECT_VALUE";

        internal const string RelatedConversation = "RELATED_CONVERSATION";

        internal const string RelatedConversationGroup = "RELATED_CONVERSATION_GROUP";

        internal const string Relative = "RELATIVE";

        internal const string Remote = "REMOTE";

        internal const string RemoteDataArchive = "REMOTE_DATA_ARCHIVE";

        internal const string RemoteServiceName = "REMOTE_SERVICE_NAME";

        internal const string Remove = "REMOVE";

        internal const string Reorganize = "REORGANIZE";

        internal const string Repeatable = "REPEATABLE";

        internal const string RepeatableRead = "REPEATABLEREAD";

        internal const string Replace = "REPLACE";

        internal const string Replica = "REPLICA";

        internal const string Replicate = "REPLICATE";

        internal const string Replicated = "REPLICATED";

        internal const string Required = "REQUIRED";

        internal const string ReserveDiskSpace = "RESERVE_DISK_SPACE";

        internal const string Reset = "RESET";

        internal const string Resize = "RESIZE";

        internal const string Resource = "RESOURCE";

        internal const string ResourceManagerLocation = "RESOURCE_MANAGER_LOCATION";

        internal const string RestrictedUser = "RESTRICTED_USER";

        internal const string Resume = "RESUME";

        internal const string Resumable = "RESUMABLE";

        internal const string Result = "RESULT";

        internal const string RetainDays = "RETAINDAYS";

        internal const string Retention = "RETENTION";

        internal const string Returns = "RETURNS";

        internal const string RequestMaxCpuTimeSec = "REQUEST_MAX_CPU_TIME_SEC";

        internal const string RequestMaxMemoryGrantPercent = "REQUEST_MAX_MEMORY_GRANT_PERCENT";

        internal const string RequestMemoryGrantTimeoutSec = "REQUEST_MEMORY_GRANT_TIMEOUT_SEC";

        internal const string RequiredCopiesToCommit = "REQUIRED_COPIES_TO_COMMIT";

        internal const string Resample = "RESAMPLE";

        internal const string Revert = "REVERT";

        internal const string Restart = "RESTART";

        internal const string Rewind = "REWIND";

        internal const string RewindOnly = "REWINDONLY";

        internal const string Robust = "ROBUST";

        internal const string Role = "ROLE";

        internal const string Rollup = "ROLLUP";

        internal const string Root = "ROOT";

        internal const string RoundRobin = "ROUND_ROBIN";

        internal const string Route = "ROUTE";

        internal const string Row = "ROW";

        internal const string Rowguid = "ROWGUID";

        internal const string RowLock = "ROWLOCK";

        internal const string Rows = "ROWS";

        internal const string RowsetsOnly = "ROWSETS_ONLY";

        internal const string RowsPerBatch = "ROWS_PER_BATCH";

        internal const string RowTerminator = "ROWTERMINATOR";

        internal const string Rowversion = "ROWVERSION";

        internal const string RSquareParen = "]";

        internal const string Rule = "RULE";

        internal const string Safe = "SAFE";

        internal const string Safety = "SAFETY";

        internal const string Sample = "SAMPLE";

        internal const string Scheduler = "SCHEDULER";

        internal const string SchemaBinding = "SCHEMABINDING";

        internal const string Schema = "SCHEMA";

        internal const string SchemaAndData = "SCHEMA_AND_DATA";

        internal const string SchemaName = "SCHEMA_NAME";

        internal const string SchemaOnly = "SCHEMA_ONLY";

        internal const string Scheme = "SCHEME";

        internal const string Scoped = "SCOPED";

        internal const string Scroll = "SCROLL";

        internal const string ScrollLocks = "SCROLL_LOCKS";

        internal const string Search = "SEARCH";

        internal const string Secondary = "SECONDARY";

        internal const string SecondaryRole = "SECONDARY_ROLE";

        internal const string Seconds = "SECONDS";

        internal const string Secret = "SECRET";

        internal const string Security = "SECURITY";

        internal const string SecurityPolicy = "SECURITY_POLICY";

        internal const string SecurityLog = "SECURITY_LOG";

        internal const string Selective = "SELECTIVE";

        internal const string Self = "SELF";

        internal const string SemiColon = ";";

        internal const string Send = "SEND";

        internal const string Sent = "SENT";

        internal const string Sequence = "SEQUENCE";

        internal const string SerDeMethod = "SERDE_METHOD";

        internal const string Serializable = "SERIALIZABLE";

        internal const string Server = "SERVER";

        internal const string Service = "SERVICE";

        internal const string ServiceBroker = "SERVICE_BROKER";

        internal const string ServiceName = "SERVICE_NAME";

        internal const string ServiceObjective = "SERVICE_OBJECTIVE";

        internal const string Session = "SESSION";

        internal const string Sessions = "SESSIONS";

        internal const string SessionTimeout = "SESSION_TIMEOUT";

        internal const string SetError = "SETERROR";

        internal const string Sets = "SETS";

        internal const string Sharded = "SHARDED";

        internal const string ShardMapManager = "SHARD_MAP_MANAGER";

        internal const string ShardMapName = "SHARD_MAP_NAME";

        internal const string ShrinkDb = "SHRINKDB";

        internal const string Sid = "SID";

        internal const string Signature = "SIGNATURE";

        internal const string Simple = "SIMPLE";

        internal const string SingleBlob = "SINGLE_BLOB";

        internal const string SingleClob = "SINGLE_CLOB";

        internal const string SingleNClob = "SINGLE_NCLOB";

        internal const string SingleSpace = " ";

        internal const string SingleUser = "SINGLE_USER";

        internal const string Singleton = "SINGLETON";

        internal const string Site = "SITE";

        internal const string Size = "SIZE";

        internal const string SizeBasedCleanupMode = "SIZE_BASED_CLEANUP_MODE";

        internal const string Skip = "SKIP";

        internal const string Soap = "SOAP";

        internal const string SoftNuma = "SOFTNUMA";

        internal const string SortedData = "SORTED_DATA";

        internal const string SortedDataReorg = "SORTED_DATA_REORG";

        internal const string SortInTempDb = "SORT_IN_TEMPDB";

        internal const string Source = "SOURCE";

        internal const string SmallDateTime = "SMALLDATETIME";

        internal const string SmallInt = "SMALLINT";

        internal const string SmallMoney = "SMALLMONEY";

        internal const string Snapshot = "SNAPSHOT";

        internal const string SnapshotImport = "SNAPSHOT_IMPORT";

        internal const string SnapshotRestorePhase = "SNAPSHOTRESTOREPHASE";

        internal const string Spatial = "SPATIAL";

        internal const string SpatialWindowMaxCells = "SPATIAL_WINDOW_MAX_CELLS";

        internal const string Specification = "SPECIFICATION";

        internal const string Split = "SPLIT";

        internal const string Sql = "SQL";

        internal const string SqlDumperDumpFlags = "SqlDumperDumpFlags";

        internal const string SqlDumperDumpPath = "SqlDumperDumpPath";

        internal const string SqlDumperDumpTimeout = "SqlDumperDumpTimeout";

        internal const string SqlLatin1GeneralCP1CIAS = "SQL_LATIN1_GENERAL_CP1_CI_AS";

        internal const string Ssl = "SSL";

        internal const string SslPort = "SSL_PORT";

        internal const string SupplementalLogging = "SUPPLEMENTAL_LOGGING";

        internal const string SuserSid = "SUSER_SID";

        internal const string SuserSname = "SUSER_SNAME";

        internal const string Standard = "STANDARD";

        internal const string Standby = "STANDBY";

        internal const string Start = "START";

        internal const string StartDate = "START_DATE";

        internal const string Started = "STARTED";

        internal const string StartupState = "STARTUP_STATE";

        internal const string Statement = "STATEMENT";

        internal const string State = "STATE";

        internal const string Static = "STATIC";

        internal const string Stats = "STATS";

        internal const string StatsStream = "STATS_STREAM";

        internal const string StatHeader = "STAT_HEADER";

        internal const string StatisticalSemantics = "STATISTICAL_SEMANTICS";

        internal const string StatisticsIncremental = "STATISTICS_INCREMENTAL";

        internal const string StatisticsNoRecompute = "STATISTICS_NORECOMPUTE";

        internal const string Status = "STATUS";

        internal const string StatusOnly = "STATUSONLY";

        internal const string Stdev = "STDEV";

        internal const string Stdevp = "STDEVP";

        internal const string Stop = "STOP";

        internal const string StopAt = "STOPAT";

        internal const string StopAtMark = "STOPATMARK";

        internal const string StopBeforeMark = "STOPBEFOREMARK";

        internal const string StopList = "STOPLIST";

        internal const string Stopped = "STOPPED";

        internal const string StopOnError = "STOP_ON_ERROR";

        internal const string StringDelimiter = "STRING_DELIMITER";

        internal const string StringSplit = "STRING_SPLIT";

        internal const string Style = "STYLE";

        internal const string Subject = "SUBJECT";

        internal const string Subscription = "SUBSCRIPTION";

        internal const string Sum = "SUM";

        internal const string Supported = "SUPPORTED";

        internal const string SuppressMessages = "SUPPRESS_MESSAGES";

        internal const string Suspend = "SUSPEND";

        internal const string Sql_Variant = "SQL_VARIANT";

        internal const string Switch = "SWITCH";

        internal const string Symmetric = "SYMMETRIC";

        internal const string SynchronousCommit = "SYNCHRONOUS_COMMIT";

        internal const string Synonym = "SYNONYM";

        internal const string Sys = "SYS";

        internal const string System = "SYSTEM";

        internal const string SystemTime = "SYSTEM_TIME";

        internal const string SystemVersioning = "SYSTEM_VERSIONING";

        internal const string T = "T";

        internal const string Tab = "\t";

        internal const string Table = "Table";

        internal const string TableResults = "TABLERESULTS";

        internal const string TableSample = "TABLESAMPLE";

        internal const string TabLock = "TABLOCK";

        internal const string TabLockX = "TABLOCKX";

        internal const string Tape = "TAPE";

        internal const string Target = "TARGET";

        internal const string TargetMemoryPercent = "TARGET_MEMORY_PERCENT";

        internal const string TargetRecoveryTime = "TARGET_RECOVERY_TIME";

        internal const string TemporalHistoryRetention = "TEMPORAL_HISTORY_RETENTION";

        internal const string Text = "TEXT";

        internal const string TextImageOn = "TEXTIMAGE_ON";

        internal const string Throw = "THROW";

        internal const string Ties = "TIES";

        internal const string Time = "TIME";

        internal const string Timeout = "TIMEOUT";

        internal const string Timer = "TIMER";

        internal const string TimeStamp = "TIMESTAMP";

        internal const string TinyInt = "TINYINT";

        internal const string TornPageDetection = "TORN_PAGE_DETECTION";

        internal const string TrackCausality = "TRACK_CAUSALITY";

        internal const string TrackColumnsUpdated = "TRACK_COLUMNS_UPDATED";

        internal const string Transaction = "TRANSACTION";

        internal const string TransactionIsolationLevel = "TRANSACTION ISOLATION LEVEL";

        internal const string Transfer = "TRANSFER";

        internal const string TransformNoiseWords = "TRANSFORM_NOISE_WORDS";

        internal const string Trigger = "TRIGGER";

        internal const string Trim = "TRIM";

        internal const string True = "TRUE";

        internal const string TruncateOnly = "TRUNCATE_ONLY";

        internal const string Trustworthy = "TRUSTWORTHY";

        internal const string Try = "TRY";

        internal const string TryCast = "TRY_CAST";

        internal const string TryParse = "TRY_PARSE";

        internal const string TS = "TS";

        internal const string TSql = "TSQL";

        internal const string TwoDigitYearCutoff = "TWO_DIGIT_YEAR_CUTOFF";

        internal const string Type = "TYPE";

        internal const string TypeWarning = "TYPE_WARNING";

        internal const string Unchecked = "UNCHECKED";

        internal const string Uncommitted = "UNCOMMITTED";

        internal const string Undefined = "UNDEFINED";

        internal const string UniqueIdentifier = "UNIQUEIDENTIFIER";

        internal const string Unknown = "UNKNOWN";

        internal const string Unlimited = "UNLIMITED";

        internal const string Unload = "UNLOAD";

        internal const string Unlock = "UNLOCK";

        internal const string Unsafe = "UNSAFE";

        internal const string Unpivot = "UNPIVOT";

        internal const string UpdLock = "UPDLOCK";

        internal const string Used = "USED";

        internal const string UseTypeDefault = "USE_TYPE_DEFAULT";

        internal const string UsePlan = "USEPLAN";

        internal const string User = "USER";

        internal const string Using = "USING";

        internal const string Validation = "VALIDATION";

        internal const string ValidXml = "VALID_XML";

        internal const string Value = "VALUE";

        internal const string Values = "VALUES";

        internal const string Var = "VAR";

        internal const string VarBinary = "VARBINARY";

        internal const string VarChar = "VARCHAR";

        internal const string VardecimalStorageFormat = "VARDECIMAL_STORAGE_FORMAT";

        internal const string Varp = "VARP";

        internal const string VDevNo = "VDEVNO";

        internal const string Verbose = "VERBOSE";

        internal const string VerboseLogging = "VerboseLogging";

        internal const string VerifyOnly = "VERIFYONLY";

        internal const string Version = "VERSION";

        internal const string Views = "VIEWS";

        internal const string ViewMetadata = "VIEW_METADATA";

        internal const string Visibility = "VISIBILITY";

        internal const string VirtualDevice = "VIRTUAL_DEVICE";

        internal const string VStart = "VSTART";

        internal const string WaitAtLowPriority = "WAIT_AT_LOW_PRIORITY";

        internal const string WebMethod = "WEBMETHOD";

        internal const string WellFormedXml = "WELL_FORMED_XML";

        internal const string WideChar = "WIDECHAR";

        internal const string WideCharAnsi = "WIDECHAR_ANSI";

        internal const string WideNative = "WIDENATIVE";

        internal const string Windows = "WINDOWS";

        internal const string Without = "WITHOUT";

        internal const string WithoutArrayWrapper = "WITHOUT_ARRAY_WRAPPER";

        internal const string Witness = "WITNESS";

        internal const string Work = "WORK";

        internal const string Workload = "WORKLOAD";

        internal const string Wsdl = "WSDL";

        internal const string XLock = "XLOCK";

        internal const string XMax = "XMAX";

        internal const string XMin = "XMIN";

        internal const string Xml = "XML";

        internal const string XmlData = "XMLDATA";

        internal const string XmlNamespaces = "XMLNAMESPACES";

        internal const string XmlSchema = "XMLSCHEMA";

        internal const string XsiNil = "XSINIL";

        internal const string XQuery = "XQUERY";

        internal const string YMax = "YMAX";

        internal const string YMin = "YMIN";

        internal const string Unbounded = "UNBOUNDED";

        internal const string Preceding = "PRECEDING";

        internal const string Following = "FOLLOWING";

        internal const string Within = "WITHIN";

        internal const string Zone = "ZONE";

        internal const string ActiveCursors = "ACTIVECURSORS";

        internal const string AddExtendedProc = "ADDEXTENDEDPROC";

        internal const string AddInstance = "ADDINSTANCE";

        internal const string Audit = "AUDIT";

        internal const string AuditEvent = "AUDITEVENT";

        internal const string AutoPilot = "AUTOPILOT";

        internal const string Buffer = "BUFFER";

        internal const string Bytes = "BYTES";

        internal const string CacheProfile = "CACHEPROFILE";

        internal const string CacheStats = "CACHESTATS";

        internal const string CallFulltext = "CALLFULLTEXT";

        internal const string CheckAlloc = "CHECKALLOC";

        internal const string CheckCatalog = "CHECKCATALOG";

        internal const string CheckDb = "CHECKDB";

        internal const string CheckFilegroup = "CHECKFILEGROUP";

        internal const string CheckIdent = "CHECKIDENT";

        internal const string CheckPrimaryFile = "CHECKPRIMARYFILE";

        internal const string CheckTable = "CHECKTABLE";

        internal const string CleanTable = "CLEANTABLE";

        internal const string ClearSpaceCaches = "CLEARSPACECACHES";

        internal const string CollectStats = "COLLECTSTATS";

        internal const string ConcurrencyViolation = "CONCURRENCYVIOLATION";

        internal const string CursorStats = "CURSORSTATS";

        internal const string DbRecover = "DBRECOVER";

        internal const string DbReindex = "DBREINDEX";

        internal const string DbReindexAll = "DBREINDEXALL";

        internal const string DbRepair = "DBREPAIR";

        internal const string DebugBreak = "DEBUGBREAK";

        internal const string DeleteInstance = "DELETEINSTANCE";

        internal const string DetachDb = "DETACHDB";

        internal const string DropCleanBuffers = "DROPCLEANBUFFERS";

        internal const string DropExtendedProc = "DROPEXTENDEDPROC";

        internal const string DumpConfig = "CONFIG";

        internal const string DumpDbInfo = "DBINFO";

        internal const string DumpDbTable = "DBTABLE";

        internal const string DumpLock = "LOCK";

        internal const string DumpLog = "LOG";

        internal const string DumpPage = "PAGE";

        internal const string DumpResource = "RESOURCE";

        internal const string DumpTrigger = "DUMPTRIGGER";

        internal const string ExtentInfo = "EXTENTINFO";

        internal const string FileHeader = "FILEHEADER";

        internal const string FixAllocation = "FIXALLOCATION";

        internal const string Flush = "FLUSH";

        internal const string FlushProcInDb = "FLUSHPROCINDB";

        internal const string ForceGhostCleanup = "FORCEGHOSTCLEANUP";

        internal const string Free = "FREE";

        internal const string FreeProcCache = "FREEPROCCACHE";

        internal const string FreeSessionCache = "FREESESSIONCACHE";

        internal const string FreeSystemCache = "FREESYSTEMCACHE";

        internal const string FreezeIo = "FREEZE_IO";

        internal const string Help = "HELP";

        internal const string IceCapQuery = "ICECAPQUERY";

        internal const string IncrementInstance = "INCREMENTINSTANCE";

        internal const string Ind = "IND";

        internal const string IndexDefrag = "INDEXDEFRAG";

        internal const string InputBuffer = "INPUTBUFFER";

        internal const string InvalidateTextptr = "INVALIDATE_TEXTPTR";

        internal const string InvalidateTextptrObjid = "INVALIDATE_TEXTPTR_OBJID";

        internal const string Latch = "LATCH";

        internal const string LogInfo = "LOGINFO";

        internal const string MapAllocUnit = "MAPALLOCUNIT";

        internal const string MemObjList = "MEMOBJLIST";

        internal const string MemoryMap = "MEMORYMAP";

        internal const string MemoryStatus = "MEMORYSTATUS";

        internal const string Metadata = "METADATA";

        internal const string MovePage = "MOVEPAGE";

        internal const string NoTextptr = "NO_TEXTPTR";

        internal const string OpenTran = "OPENTRAN";

        internal const string OptimizerWhatIf = "OPTIMIZER_WHATIF";

        internal const string OutputBuffer = "OUTPUTBUFFER";

        internal const string PerfMonStats = "PERFMON";

        internal const string PersistStackHash = "PERSISTSTACKHASH";

        internal const string PinTable = "PINTABLE";

        internal const string ProcCache = "PROCCACHE";

        internal const string PrtiPage = "PRTIPAGE";

        internal const string ReadPage = "READPAGE";

        internal const string RenameColumn = "RENAMECOLUMN";

        internal const string RuleOff = "RULEOFF";

        internal const string RuleOn = "RULEON";

        internal const string SeMetadata = "SEMETADATA";

        internal const string SetCpuWeight = "SETCPUWEIGHT";

        internal const string SetInstance = "SETINSTANCE";

        internal const string SetIoWeight = "SETIOWEIGHT";

        internal const string ShowStatistics = "SHOW_STATISTICS";

        internal const string ShowContig = "SHOWCONTIG";

        internal const string ShowDbAffinity = "SHOWDBAFFINITY";

        internal const string ShowFileStats = "SHOWFILESTATS";

        internal const string ShowOffRules = "SHOWOFFRULES";

        internal const string ShowOnRules = "SHOWONRULES";

        internal const string ShowTableAffinity = "SHOWTABLEAFFINITY";

        internal const string ShowText = "SHOWTEXT";

        internal const string ShowWeights = "SHOWWEIGHTS";

        internal const string ShrinkDatabase = "SHRINKDATABASE";

        internal const string ShrinkFile = "SHRINKFILE";

        internal const string Sparse = "SPARSE";

        internal const string SqlMgrStats = "SQLMGRSTATS";

        internal const string SqlPerf = "SQLPERF";

        internal const string StackDump = "STACKDUMP";

        internal const string StaleQueryThresholdDays = "STALE_QUERY_THRESHOLD_DAYS";

        internal const string Tec = "TEC";

        internal const string ThawIo = "THAW_IO";

        internal const string ThrottleIo = "THROTTLE_IO";

        internal const string TraceOff = "TRACEOFF";

        internal const string TraceOn = "TRACEON";

        internal const string TraceStatus = "TRACESTATUS";

        internal const string UnpinTable = "UNPINTABLE";

        internal const string UpdateUsage = "UPDATEUSAGE";

        internal const string UserOptions = "USEROPTIONS";

        internal const string WritePage = "WRITEPAGE";

        internal const string ChineseMacaoSar = "CHINESE (MACAO SAR)";

        internal const string ChineseSingapore = "CHINESE (SINGAPORE)";

        internal const string SerbianCyrillic = "SERBIAN (CYRILLIC)";

        internal const string Spanish = "SPANISH";

        internal const string ChineseHongKong = "CHINESE (HONG KONG SAR, PRC)";

        internal const string SerbianLatin = "SERBIAN (LATIN)";

        internal const string Portuegese = "PORTUGUESE";

        internal const string BritishEnglish = "BRITISH ENGLISH";

        internal const string SimplifiedChinese = "SIMPLIFIED CHINESE";

        internal const string Marathi = "MARATHI";

        internal const string Malayalam = "MALAYALAM";

        internal const string Kannada = "KANNADA";

        internal const string Telugu = "TELUGU";

        internal const string Tamil = "TAMIL";

        internal const string Gujarati = "GUJARATI";

        internal const string Punjabi = "PUNJABI";

        internal const string BengaliIndia = "BENGALI (INDIA)";

        internal const string MalayMalaysia = "MALAY - MALAYSIA";

        internal const string Hindi = "HINDI";

        internal const string Vietnamese = "VIETNAMESE";

        internal const string Lithuanian = "LITHUANIAN";

        internal const string Latvian = "LATVIAN";

        internal const string Slovenian = "SLOVENIAN";

        internal const string Ukrainian = "UKRAINIAN";

        internal const string Indonesian = "INDONESIAN";

        internal const string Urdu = "URDU";

        internal const string Thai = "THAI";

        internal const string Swedish = "SWEDISH";

        internal const string Slovak = "SLOVAK";

        internal const string Croatian = "CROATIAN";

        internal const string Russian = "RUSSIAN";

        internal const string Romanian = "ROMANIAN";

        internal const string Brazilian = "BRAZILIAN";

        internal const string NorwegianBokmal = "NORWEGIAN (BOKMÅL)";

        internal const string Dutch = "DUTCH";

        internal const string Korean = "KOREAN";

        internal const string Japanese = "JAPANESE";

        internal const string Italian = "ITALIAN";

        internal const string Icelandic = "ICELANDIC";

        internal const string Hebrew = "HEBREW";

        internal const string French = "FRENCH";

        internal const string English = "ENGLISH";

        internal const string German = "GERMAN";

        internal const string TraditionalChinese = "TRADITIONAL CHINESE";

        internal const string Catalan = "CATALAN";

        internal const string Bulgarian = "BULGARIAN";

        internal const string Arabic = "ARABIC";

        internal const string Neutral = "NEUTRAL";

        internal const string AddSignature = "ADD_SIGNATURE";

        internal const string AddSignatureSchemaObject = "ADD_SIGNATURE_SCHEMA_OBJECT";

        internal const string AlterAsymmetricKey = "ALTER_ASYMMETRIC_KEY";

        internal const string AlterBrokerPriority = "ALTER_BROKER_PRIORITY";

        internal const string AlterDatabaseAudit = "ALTER_AUDIT";

        internal const string AlterDatabaseAuditSpecification = "ALTER_DATABASE_AUDIT_SPECIFICATION";

        internal const string AlterDatabaseEncryptionKey = "ALTER_DATABASE_ENCRYPTION_KEY";

        internal const string AlterExtendedProperty = "ALTER_EXTENDED_PROPERTY";

        internal const string AlterFullTextCatalog = "ALTER_FULLTEXT_CATALOG";

        internal const string AlterFullTextIndex = "ALTER_FULLTEXT_INDEX";

        internal const string AlterFullTextStopList = "ALTER_FULLTEXT_STOPLIST";

        internal const string AlterMasterKey = "ALTER_MASTER_KEY";

        internal const string AlterPlanGuide = "ALTER_PLAN_GUIDE";

        internal const string AlterSearchPropertyList = "ALTER_SEARCH_PROPERTY_LIST";

        internal const string AlterSequence = "ALTER_SEQUENCE";

        internal const string AlterAvailabilityGroup = "ALTER_AVAILABILITY_GROUP";

        internal const string AlterSecurityPolicy = "ALTER_SECURITY_POLICY";

        internal const string AlterServerConfiguration = "ALTER_SERVER_CONFIGURATION";

        internal const string AlterServerRole = "ALTER_SERVER_ROLE";

        internal const string AlterSymmetricKey = "ALTER_SYMMETRIC_KEY";

        internal const string BindDefault = "BIND_DEFAULT";

        internal const string BindRule = "BIND_RULE";

        internal const string CreateAsymmetricKey = "CREATE_ASYMMETRIC_KEY";

        internal const string CreateBrokerPriority = "CREATE_BROKER_PRIORITY";

        internal const string CreateDatabaseAudit = "CREATE_AUDIT";

        internal const string CreateDatabaseAuditSpecification = "CREATE_DATABASE_AUDIT_SPECIFICATION";

        internal const string CreateDatabaseEncryptionKey = "CREATE_DATABASE_ENCRYPTION_KEY";

        internal const string CreateDefault = "CREATE_DEFAULT";

        internal const string CreateExtendedProperty = "CREATE_EXTENDED_PROPERTY";

        internal const string CreateFullTextCatalog = "CREATE_FULLTEXT_CATALOG";

        internal const string CreateFullTextIndex = "CREATE_FULLTEXT_INDEX";

        internal const string CreateFullTextStopList = "CREATE_FULLTEXT_STOPLIST";

        internal const string CreateMasterKey = "CREATE_MASTER_KEY";

        internal const string CreatePlanGuide = "CREATE_PLAN_GUIDE";

        internal const string CreateRule = "CREATE_RULE";

        internal const string CreateSearchPropertyList = "CREATE_SEARCH_PROPERTY_LIST";

        internal const string CreateSequence = "CREATE_SEQUENCE";

        internal const string CreateAvailabilityGroup = "CREATE_AVAILABILITY_GROUP";

        internal const string CreateSecurityPolicy = "CREATE_SECURITY_POLICY";

        internal const string CreateColumnMasterKey = "CREATE_COLUMN_MASTER_KEY";

        internal const string CreateColumnEncryptionKey = "CREATE_COLUMN_ENCRYPTION_KEY";

        internal const string CreateServerRole = "CREATE_SERVER_ROLE";

        internal const string CreateSpatialIndex = "CREATE_SPATIAL_INDEX";

        internal const string CreateSymmetricKey = "CREATE_SYMMETRIC_KEY";

        internal const string DropAsymmetricKey = "DROP_ASYMMETRIC_KEY";

        internal const string DropBrokerPriority = "DROP_BROKER_PRIORITY";

        internal const string DropDatabaseAudit = "DROP_AUDIT";

        internal const string DropDatabaseAuditSpecification = "DROP_DATABASE_AUDIT_SPECIFICATION";

        internal const string DropDatabaseEncryptionKey = "DROP_DATABASE_ENCRYPTION_KEY";

        internal const string DropDefault = "DROP_DEFAULT";

        internal const string DropExtendedProperty = "DROP_EXTENDED_PROPERTY";

        internal const string DropFullTextCatalog = "DROP_FULLTEXT_CATALOG";

        internal const string DropFullTextIndex = "DROP_FULLTEXT_INDEX";

        internal const string DropFullTextStopList = "DROP_FULLTEXT_STOPLIST";

        internal const string DropMasterKey = "DROP_MASTER_KEY";

        internal const string DropPlanGuide = "DROP_PLAN_GUIDE";

        internal const string DropRule = "DROP_RULE";

        internal const string DropSearchPropertyList = "DROP_SEARCH_PROPERTY_LIST";

        internal const string DropSequence = "DROP_SEQUENCE";

        internal const string DropAvailabilityGroup = "DROP_AVAILABILITY_GROUP";

        internal const string DropSecurityPolicy = "DROP_SECURITY_POLICY";

        internal const string DropColumnMasterKey = "DROP_COLUMN_MASTER_KEY";

        internal const string DropColumnEncryptionKey = "DROP_COLUMN_ENCRYPTION_KEY";

        internal const string DropServerRole = "DROP_SERVER_ROLE";

        internal const string DropSignature = "DROP_SIGNATURE";

        internal const string DropSignatureSchemaObject = "DROP_SIGNATURE_SCHEMA_OBJECT";

        internal const string DropSymmetricKey = "DROP_SYMMETRIC_KEY";

        internal const string Rename = "RENAME";

        internal const string UnbindDefault = "UNBIND_DEFAULT";

        internal const string UnbindRule = "UNBIND_RULE";

        internal const string AlterCredential = "ALTER_CREDENTIAL";

        internal const string AlterCryptographicProvider = "ALTER_CRYPTOGRAPHIC_PROVIDER";

        internal const string AlterDatabaseScopedConfiguration = "ALTER_DATABASE_SCOPED_CONFIGURATION";

        internal const string AlterEventSession = "ALTER_EVENT_SESSION";

        internal const string AlterInstance = "ALTER_INSTANCE";

        internal const string AlterLinkedServer = "ALTER_LINKED_SERVER";

        internal const string AlterMessage = "ALTER_MESSAGE";

        internal const string AlterRemoteServer = "ALTER_REMOTE_SERVER";

        internal const string AlterResourceGovernorConfig = "ALTER_RESOURCE_GOVERNOR_CONFIG";

        internal const string AlterResourcePool = "ALTER_RESOURCE_POOL";

        internal const string AlterExternalResourcePool = "ALTER_EXTERNAL_RESOURCE_POOL";

        internal const string AlterServerAudit = "ALTER_SERVER_AUDIT";

        internal const string AlterServerAuditSpecification = "ALTER_SERVER_AUDIT_SPECIFICATION";

        internal const string AlterServiceMasterKey = "ALTER_SERVICE_MASTER_KEY";

        internal const string AlterWorkloadGroup = "ALTER_WORKLOAD_GROUP";

        internal const string AlterColumnEncryptionKey = "ALTER_COLUMN_ENCRYPTION_KEY";

        internal const string CreateCredential = "CREATE_CREDENTIAL";

        internal const string CreateCryptographicProvider = "CREATE_CRYPTOGRAPHIC_PROVIDER";

        internal const string CreateEventSession = "CREATE_EVENT_SESSION";

        internal const string CreateExtendedProcedure = "CREATE_EXTENDED_PROCEDURE";

        internal const string CreateLinkedServer = "CREATE_LINKED_SERVER";

        internal const string CreateLinkedServerLogin = "CREATE_LINKED_SERVER_LOGIN";

        internal const string CreateMessage = "CREATE_MESSAGE";

        internal const string CreateRemoteServer = "CREATE_REMOTE_SERVER";

        internal const string CreateResourcePool = "CREATE_RESOURCE_POOL";

        internal const string CreateExternalResourcePool = "CREATE_EXTERNAL_RESOURCE_POOL";

        internal const string CreateServerAudit = "CREATE_SERVER_AUDIT";

        internal const string CreateServerAuditSpecification = "CREATE_SERVER_AUDIT_SPECIFICATION";

        internal const string CreateWorkloadGroup = "CREATE_WORKLOAD_GROUP";

        internal const string DropCredential = "DROP_CREDENTIAL";

        internal const string DropCryptographicProvider = "DROP_CRYPTOGRAPHIC_PROVIDER";

        internal const string DropEventSession = "DROP_EVENT_SESSION";

        internal const string DropExtendedProcedure = "DROP_EXTENDED_PROCEDURE";

        internal const string DropLinkedServer = "DROP_LINKED_SERVER";

        internal const string DropLinkedServerLogin = "DROP_LINKED_SERVER_LOGIN";

        internal const string DropMessage = "DROP_MESSAGE";

        internal const string DropRemoteServer = "DROP_REMOTE_SERVER";

        internal const string DropResourcePool = "DROP_RESOURCE_POOL";

        internal const string DropExternalResourcePool = "DROP_EXTERNAL_RESOURCE_POOL";

        internal const string DropServerAudit = "DROP_SERVER_AUDIT";

        internal const string DropServerAuditSpecification = "DROP_SERVER_AUDIT_SPECIFICATION";

        internal const string DropWorkloadGroup = "DROP_WORKLOAD_GROUP";

        internal const string CreateApplicationRole = "CREATE_APPLICATION_ROLE";

        internal const string AlterApplicationRole = "ALTER_APPLICATION_ROLE";

        internal const string DropApplicationRole = "DROP_APPLICATION_ROLE";

        internal const string CreateAssembly = "CREATE_ASSEMBLY";

        internal const string AlterAssembly = "ALTER_ASSEMBLY";

        internal const string DropAssembly = "DROP_ASSEMBLY";

        internal const string AlterAuthorizationDatabase = "ALTER_AUTHORIZATION_DATABASE";

        internal const string CreateCertificate = "CREATE_CERTIFICATE";

        internal const string AlterCertificate = "ALTER_CERTIFICATE";

        internal const string DropCertificate = "DROP_CERTIFICATE";

        internal const string CreateContract = "CREATE_CONTRACT";

        internal const string DropContract = "DROP_CONTRACT";

        internal const string GrantDatabase = "GRANT_DATABASE";

        internal const string DenyDatabase = "DENY_DATABASE";

        internal const string RevokeDatabase = "REVOKE_DATABASE";

        internal const string CreateEventNotification = "CREATE_EVENT_NOTIFICATION";

        internal const string DropEventNotification = "DROP_EVENT_NOTIFICATION";

        internal const string CreateFunction = "CREATE_FUNCTION";

        internal const string AlterFunction = "ALTER_FUNCTION";

        internal const string DropFunction = "DROP_FUNCTION";

        internal const string CreateIndex = "CREATE_INDEX";

        internal const string AlterIndex = "ALTER_INDEX";

        internal const string DropIndex = "DROP_INDEX";

        internal const string CreateMessageType = "CREATE_MESSAGE_TYPE";

        internal const string AlterMessageType = "ALTER_MESSAGE_TYPE";

        internal const string DropMessageType = "DROP_MESSAGE_TYPE";

        internal const string CreatePartitionFunction = "CREATE_PARTITION_FUNCTION";

        internal const string AlterPartitionFunction = "ALTER_PARTITION_FUNCTION";

        internal const string DropPartitionFunction = "DROP_PARTITION_FUNCTION";

        internal const string CreatePartitionScheme = "CREATE_PARTITION_SCHEME";

        internal const string AlterPartitionScheme = "ALTER_PARTITION_SCHEME";

        internal const string DropPartitionScheme = "DROP_PARTITION_SCHEME";

        internal const string CreateProcedure = "CREATE_PROCEDURE";

        internal const string AlterProcedure = "ALTER_PROCEDURE";

        internal const string DropProcedure = "DROP_PROCEDURE";

        internal const string CreateQueue = "CREATE_QUEUE";

        internal const string AlterQueue = "ALTER_QUEUE";

        internal const string DropQueue = "DROP_QUEUE";

        internal const string CreateRemoteServiceBinding = "CREATE_REMOTE_SERVICE_BINDING";

        internal const string AlterRemoteServiceBinding = "ALTER_REMOTE_SERVICE_BINDING";

        internal const string DropRemoteServiceBinding = "DROP_REMOTE_SERVICE_BINDING";

        internal const string CreateRole = "CREATE_ROLE";

        internal const string AlterRole = "ALTER_ROLE";

        internal const string DropRole = "DROP_ROLE";

        internal const string CreateRoute = "CREATE_ROUTE";

        internal const string AlterRoute = "ALTER_ROUTE";

        internal const string DropRoute = "DROP_ROUTE";

        internal const string CreateSchema = "CREATE_SCHEMA";

        internal const string AlterSchema = "ALTER_SCHEMA";

        internal const string DropSchema = "DROP_SCHEMA";

        internal const string CreateService = "CREATE_SERVICE";

        internal const string AlterService = "ALTER_SERVICE";

        internal const string DropService = "DROP_SERVICE";

        internal const string CreateStatistics = "CREATE_STATISTICS";

        internal const string DropStatistics = "DROP_STATISTICS";

        internal const string UpdateStatistics = "UPDATE_STATISTICS";

        internal const string CreateSynonym = "CREATE_SYNONYM";

        internal const string DropSynonym = "DROP_SYNONYM";

        internal const string CreateTable = "CREATE_TABLE";

        internal const string AlterTable = "ALTER_TABLE";

        internal const string DropTable = "DROP_TABLE";

        internal const string CreateTrigger = "CREATE_TRIGGER";

        internal const string AlterTrigger = "ALTER_TRIGGER";

        internal const string DropTrigger = "DROP_TRIGGER";

        internal const string CreateType = "CREATE_TYPE";

        internal const string DropType = "DROP_TYPE";

        internal const string CreateUser = "CREATE_USER";

        internal const string AlterUser = "ALTER_USER";

        internal const string DropUser = "DROP_USER";

        internal const string CreateView = "CREATE_VIEW";

        internal const string AlterView = "ALTER_VIEW";

        internal const string DropView = "DROP_VIEW";

        internal const string CreateXmlSchemaCollection = "CREATE_XML_SCHEMA_COLLECTION";

        internal const string AlterXmlSchemaCollection = "ALTER_XML_SCHEMA_COLLECTION";

        internal const string DropXmlSchemaCollection = "DROP_XML_SCHEMA_COLLECTION";

        internal const string AlterAuthorizationServer = "ALTER_AUTHORIZATION_SERVER";

        internal const string CreateDatabase = "CREATE_DATABASE";

        internal const string AlterDatabase = "ALTER_DATABASE";

        internal const string DropDatabase = "DROP_DATABASE";

        internal const string CreateLogin = "CREATE_LOGIN";

        internal const string AlterLogin = "ALTER_LOGIN";

        internal const string CreateEndpoint = "CREATE_ENDPOINT";

        internal const string DropEndpoint = "DROP_ENDPOINT";

        internal const string DropLogin = "DROP_LOGIN";

        internal const string GrantServer = "GRANT_SERVER";

        internal const string DenyServer = "DENY_SERVER";

        internal const string RevokeServer = "REVOKE_SERVER";

        internal const string AddRoleMember = "ADD_ROLE_MEMBER";

        internal const string AddServerRoleMember = "ADD_SERVER_ROLE_MEMBER";

        internal const string DropRoleMember = "DROP_ROLE_MEMBER";

        internal const string DropServerRoleMember = "DROP_SERVER_ROLE_MEMBER";

        internal const string AlterEndpoint = "ALTER_ENDPOINT";

        internal const string CreateXmlIndex = "CREATE_XML_INDEX";

        internal const string QueueActivation = "QUEUE_ACTIVATION";

        internal const string BrokerQueueDisabled = "BROKER_QUEUE_DISABLED";

        internal const string AssemblyLoad = "ASSEMBLY_LOAD";

        internal const string AuditAddDbUserEvent = "AUDIT_ADD_DB_USER_EVENT";

        internal const string AuditAddLoginEvent = "AUDIT_ADDLOGIN_EVENT";

        internal const string AuditAddLoginToServerRoleEvent = "AUDIT_ADD_LOGIN_TO_SERVER_ROLE_EVENT";

        internal const string AuditAddMemberToDbRoleEvent = "AUDIT_ADD_MEMBER_TO_DB_ROLE_EVENT";

        internal const string AuditAddRoleEvent = "AUDIT_ADD_ROLE_EVENT";

        internal const string AuditAppRoleChangePasswordEvent = "AUDIT_APP_ROLE_CHANGE_PASSWORD_EVENT";

        internal const string AuditBackupRestoreEvent = "AUDIT_BACKUP_RESTORE_EVENT";

        internal const string AuditChangeAuditEvent = "AUDIT_CHANGE_AUDIT_EVENT";

        internal const string AuditChangeDatabaseOwner = "AUDIT_CHANGE_DATABASE_OWNER";

        internal const string AuditDatabaseManagementEvent = "AUDIT_DATABASE_MANAGEMENT_EVENT";

        internal const string AuditDatabaseObjectAccessEvent = "AUDIT_DATABASE_OBJECT_ACCESS_EVENT";

        internal const string AuditDatabaseObjectGdrEvent = "AUDIT_DATABASE_OBJECT_GDR_EVENT";

        internal const string AuditDatabaseObjectManagementEvent = "AUDIT_DATABASE_OBJECT_MANAGEMENT_EVENT";

        internal const string AuditDatabaseObjectTakeOwnershipEvent = "AUDIT_DATABASE_OBJECT_TAKE_OWNERSHIP_EVENT";

        internal const string AuditDatabaseOperationEvent = "AUDIT_DATABASE_OPERATION_EVENT";

        internal const string AuditDatabasePrincipalImpersonationEvent = "AUDIT_DATABASE_PRINCIPAL_IMPERSONATION_EVENT";

        internal const string AuditDatabasePrincipalManagementEvent = "AUDIT_DATABASE_PRINCIPAL_MANAGEMENT_EVENT";

        internal const string AuditDatabaseScopeGdrEvent = "AUDIT_DATABASE_SCOPE_GDR_EVENT";

        internal const string AuditDbccEvent = "AUDIT_DBCC_EVENT";

        internal const string AuditLogin = "AUDIT_LOGIN";

        internal const string AuditLoginChangePasswordEvent = "AUDIT_LOGIN_CHANGE_PASSWORD_EVENT";

        internal const string AuditLoginChangePropertyEvent = "AUDIT_LOGIN_CHANGE_PROPERTY_EVENT";

        internal const string AuditLoginFailed = "AUDIT_LOGIN_FAILED";

        internal const string AuditLoginGdrEvent = "AUDIT_LOGIN_GDR_EVENT";

        internal const string AuditLogout = "AUDIT_LOGOUT";

        internal const string AuditSchemaObjectAccessEvent = "AUDIT_SCHEMA_OBJECT_ACCESS_EVENT";

        internal const string AuditSchemaObjectGdrEvent = "AUDIT_SCHEMA_OBJECT_GDR_EVENT";

        internal const string AuditSchemaObjectManagementEvent = "AUDIT_SCHEMA_OBJECT_MANAGEMENT_EVENT";

        internal const string AuditSchemaObjectTakeOwnershipEvent = "AUDIT_SCHEMA_OBJECT_TAKE_OWNERSHIP_EVENT";

        internal const string AuditServerAlterTraceEvent = "AUDIT_SERVER_ALTER_TRACE_EVENT";

        internal const string AuditServerObjectGdrEvent = "AUDIT_SERVER_OBJECT_GDR_EVENT";

        internal const string AuditServerObjectManagementEvent = "AUDIT_SERVER_OBJECT_MANAGEMENT_EVENT";

        internal const string AuditServerObjectTakeOwnershipEvent = "AUDIT_SERVER_OBJECT_TAKE_OWNERSHIP_EVENT";

        internal const string AuditServerOperationEvent = "AUDIT_SERVER_OPERATION_EVENT";

        internal const string AuditServerPrincipalImpersonationEvent = "AUDIT_SERVER_PRINCIPAL_IMPERSONATION_EVENT";

        internal const string AuditServerPrincipalManagementEvent = "AUDIT_SERVER_PRINCIPAL_MANAGEMENT_EVENT";

        internal const string AuditServerScopeGdrEvent = "AUDIT_SERVER_SCOPE_GDR_EVENT";

        internal const string BlockedProcessReport = "BLOCKED_PROCESS_REPORT";

        internal const string DataFileAutoGrow = "DATA_FILE_AUTO_GROW";

        internal const string DataFileAutoShrink = "DATA_FILE_AUTO_SHRINK";

        internal const string DatabaseMirroringStateChange = "DATABASE_MIRRORING_STATE_CHANGE";

        internal const string DeadlockGraph = "DEADLOCK_GRAPH";

        internal const string DeprecationAnnouncement = "DEPRECATION_ANNOUNCEMENT";

        internal const string DeprecationFinalSupport = "DEPRECATION_FINAL_SUPPORT";

        internal const string ErrorLog = "ERRORLOG";

        internal const string EventLog = "EVENTLOG";

        internal const string Exception = "EXCEPTION";

        internal const string ExchangeSpillEvent = "EXCHANGE_SPILL_EVENT";

        internal const string ExecutionWarnings = "EXECUTION_WARNINGS";

        internal const string FtCrawlAborted = "FT_CRAWL_ABORTED";

        internal const string FtCrawlStarted = "FT_CRAWL_STARTED";

        internal const string FtCrawlStopped = "FT_CRAWL_STOPPED";

        internal const string HashWarning = "HASH_WARNING";

        internal const string LockDeadlock = "LOCK_DEADLOCK";

        internal const string LockDeadlockChain = "LOCK_DEADLOCK_CHAIN";

        internal const string LockEscalation = "LOCK_ESCALATION";

        internal const string LogFileAutoGrow = "LOG_FILE_AUTO_GROW";

        internal const string LogFileAutoShrink = "LOG_FILE_AUTO_SHRINK";

        internal const string MissingColumnStatistics = "MISSING_COLUMN_STATISTICS";

        internal const string MissingJoinPredicate = "MISSING_JOIN_PREDICATE";

        internal const string MountTape = "MOUNT_TAPE";

        internal const string ObjectAltered = "OBJECT_ALTERED";

        internal const string ObjectCreated = "OBJECT_CREATED";

        internal const string ObjectDeleted = "OBJECT_DELETED";

        internal const string OledbCallEvent = "OLEDB_CALL_EVENT";

        internal const string OledbDataReadEvent = "OLEDB_DATAREAD_EVENT";

        internal const string OledbErrors = "OLEDB_ERRORS";

        internal const string OledbProviderInformation = "OLEDB_PROVIDER_INFORMATION";

        internal const string OledbQueryInterfaceEvent = "OLEDB_QUERYINTERFACE_EVENT";

        internal const string QnDynamics = "QN__DYNAMICS";

        internal const string QnParameterTable = "QN__PARAMETER_TABLE";

        internal const string QnSubscription = "QN__SUBSCRIPTION";

        internal const string QnTemplate = "QN__TEMPLATE";

        internal const string ServerMemoryChange = "SERVER_MEMORY_CHANGE";

        internal const string ShowPlanAllForQueryCompile = "SHOWPLAN_ALL_FOR_QUERY_COMPILE";

        internal const string ShowPlanXmlForQueryCompile = "SHOWPLAN_XML_FOR_QUERY_COMPILE";

        internal const string ShowPlanXml = "SHOWPLAN_XML";

        internal const string ShowPlanXmlStatisticsProfile = "SHOWPLAN_XML_STATISTICS_PROFILE";

        internal const string SortWarnings = "SORT_WARNINGS";

        internal const string SpCacheInsert = "SP_CACHEINSERT";

        internal const string SpCacheMiss = "SP_CACHEMISS";

        internal const string SpCacheRemove = "SP_CACHEREMOVE";

        internal const string SpRecompile = "SP_RECOMPILE";

        internal const string SqlStmtRecompile = "SQL_STMTRECOMPILE";

        internal const string TraceFileClose = "TRACE_FILE_CLOSE";

        internal const string UserErrorMessage = "USER_ERROR_MESSAGE";

        internal const string UserConfigurable0 = "USERCONFIGURABLE_0";

        internal const string UserConfigurable1 = "USERCONFIGURABLE_1";

        internal const string UserConfigurable2 = "USERCONFIGURABLE_2";

        internal const string UserConfigurable3 = "USERCONFIGURABLE_3";

        internal const string UserConfigurable4 = "USERCONFIGURABLE_4";

        internal const string UserConfigurable5 = "USERCONFIGURABLE_5";

        internal const string UserConfigurable6 = "USERCONFIGURABLE_6";

        internal const string UserConfigurable7 = "USERCONFIGURABLE_7";

        internal const string UserConfigurable8 = "USERCONFIGURABLE_8";

        internal const string UserConfigurable9 = "USERCONFIGURABLE_9";

        internal const string XQueryStaticType = "XQUERY_STATIC_TYPE";

        internal const string AuditFullText = "AUDIT_FULLTEXT";

        internal const string BitmapWarning = "BITMAP_WARNING";

        internal const string CpuThresholdExceeded = "CPU_THRESHOLD_EXCEEDED";

        internal const string DatabaseSuspectDataPage = "DATABASE_SUSPECT_DATA_PAGE";

        internal const string DdlAsymmetricKeyEvents = "DDL_ASYMMETRIC_KEY_EVENTS";

        internal const string DdlBrokerPriorityEvents = "DDL_BROKER_PRIORITY_EVENTS";

        internal const string DdlCryptoSignatureEvents = "DDL_CRYPTO_SIGNATURE_EVENTS";

        internal const string DdlDatabaseAuditSpecificationEvents = "DDL_DATABASE_AUDIT_SPECIFICATION_EVENTS";

        internal const string DdlDatabaseEncryptionKeyEvents = "DDL_DATABASE_ENCRYPTION_KEY_EVENTS";

        internal const string DdlDefaultEvents = "DDL_DEFAULT_EVENTS";

        internal const string DdlExtendedPropertyEvents = "DDL_EXTENDED_PROPERTY_EVENTS";

        internal const string DdlFullTextCatalogEvents = "DDL_FULLTEXT_CATALOG_EVENTS";

        internal const string DdlFullTextStopListEvents = "DDL_FULLTEXT_STOPLIST_EVENTS";

        internal const string DdlMasterKeyEvents = "DDL_MASTER_KEY_EVENTS";

        internal const string DdlPlanGuideEvents = "DDL_PLAN_GUIDE_EVENTS";

        internal const string DdlRuleEvents = "DDL_RULE_EVENTS";

        internal const string DdlSymmetricKeyEvents = "DDL_SYMMETRIC_KEY_EVENTS";

        internal const string DdlCredentialEvents = "DDL_CREDENTIAL_EVENTS";

        internal const string DdlDatabaseEvents = "DDL_DATABASE_EVENTS";

        internal const string DdlCryptographicProviderEvents = "DDL_CRYPTOGRAPHIC_PROVIDER_EVENTS";

        internal const string DdlEventSessionEvents = "DDL_EVENT_SESSION_EVENTS";

        internal const string DdlExtendedProcedureEvents = "DDL_EXTENDED_PROCEDURE_EVENTS";

        internal const string DdlLinkedServerEvents = "DDL_LINKED_SERVER_EVENTS";

        internal const string DdlLinkedServerLoginEvents = "DDL_LINKED_SERVER_LOGIN_EVENTS";

        internal const string DdlMessageEvents = "DDL_MESSAGE_EVENTS";

        internal const string DdlRemoteServerEvents = "DDL_REMOTE_SERVER_EVENTS";

        internal const string DdlResourceGovernorEvents = "DDL_RESOURCE_GOVERNOR_EVENTS";

        internal const string DdlResourcePool = "DDL_RESOURCE_POOL";

        internal const string DdlSearchPropertyListEvents = "DDL_SEARCH_PROPERTY_LIST_EVENTS";

        internal const string DdlSequenceEvents = "DDL_SEQUENCE_EVENTS";

        internal const string DdlAvailabilityGroupEvents = "DDL_AVAILABILITY_GROUP_EVENTS";

        internal const string DdlDatabaseAuditEvents = "DDL_DATABASE_AUDIT_EVENTS";

        internal const string DdlSecurityPolicyEvents = "DDL_SECURITY_POLICY_EVENTS";

        internal const string DdlServerAuditEvents = "DDL_SERVER_AUDIT_EVENTS";

        internal const string DdlServerAuditSpecificationEvents = "DDL_SERVER_AUDIT_SPECIFICATION_EVENTS";

        internal const string DdlServiceMasterKeyEvents = "DDL_SERVICE_MASTER_KEY_EVENTS";

        internal const string DdlWorkloadGroup = "DDL_WORKLOAD_GROUP";

        internal const string DdlEvents = "DDL_EVENTS";

        internal const string DdlApplicationRoleEvents = "DDL_APPLICATION_ROLE_EVENTS";

        internal const string DdlAssemblyEvents = "DDL_ASSEMBLY_EVENTS";

        internal const string DdlAuthorizationDatabaseEvents = "DDL_AUTHORIZATION_DATABASE_EVENTS";

        internal const string DdlAuthorizationServerEvents = "DDL_AUTHORIZATION_SERVER_EVENTS";

        internal const string DdlCertificateEvents = "DDL_CERTIFICATE_EVENTS";

        internal const string DdlContractEvents = "DDL_CONTRACT_EVENTS";

        internal const string DdlDatabaseLevelEvents = "DDL_DATABASE_LEVEL_EVENTS";

        internal const string DdlDatabaseSecurityEvents = "DDL_DATABASE_SECURITY_EVENTS";

        internal const string DdlEndpointEvents = "DDL_ENDPOINT_EVENTS";

        internal const string DdlEventNotificationEvents = "DDL_EVENT_NOTIFICATION_EVENTS";

        internal const string DdlFunctionEvents = "DDL_FUNCTION_EVENTS";

        internal const string DdlGdrDatabaseEvents = "DDL_GDR_DATABASE_EVENTS";

        internal const string DdlGdrServerEvents = "DDL_GDR_SERVER_EVENTS";

        internal const string DdlIndexEvents = "DDL_INDEX_EVENTS";

        internal const string DdlLoginEvents = "DDL_LOGIN_EVENTS";

        internal const string DdlMessageTypeEvents = "DDL_MESSAGE_TYPE_EVENTS";

        internal const string DdlPartitionEvents = "DDL_PARTITION_EVENTS";

        internal const string DdlPartitionFunctionEvents = "DDL_PARTITION_FUNCTION_EVENTS";

        internal const string DdlPartitionSchemeEvents = "DDL_PARTITION_SCHEME_EVENTS";

        internal const string DdlProcedureEvents = "DDL_PROCEDURE_EVENTS";

        internal const string DdlQueueEvents = "DDL_QUEUE_EVENTS";

        internal const string DdlRemoteServiceBindingEvents = "DDL_REMOTE_SERVICE_BINDING_EVENTS";

        internal const string DdlRoleEvents = "DDL_ROLE_EVENTS";

        internal const string DdlRouteEvents = "DDL_ROUTE_EVENTS";

        internal const string DdlSchemaEvents = "DDL_SCHEMA_EVENTS";

        internal const string DdlServerLevelEvents = "DDL_SERVER_LEVEL_EVENTS";

        internal const string DdlServerSecurityEvents = "DDL_SERVER_SECURITY_EVENTS";

        internal const string DdlServiceEvents = "DDL_SERVICE_EVENTS";

        internal const string DdlSsbEvents = "DDL_SSB_EVENTS";

        internal const string DdlStatisticsEvents = "DDL_STATISTICS_EVENTS";

        internal const string DdlSynonymEvents = "DDL_SYNONYM_EVENTS";

        internal const string DdlTableEvents = "DDL_TABLE_EVENTS";

        internal const string DdlTableViewEvents = "DDL_TABLE_VIEW_EVENTS";

        internal const string DdlTriggerEvents = "DDL_TRIGGER_EVENTS";

        internal const string DdlTypeEvents = "DDL_TYPE_EVENTS";

        internal const string DdlUserEvents = "DDL_USER_EVENTS";

        internal const string DdlViewEvents = "DDL_VIEW_EVENTS";

        internal const string DdlXmlSchemaCollectionEvents = "DDL_XML_SCHEMA_COLLECTION_EVENTS";

        internal const string TrcClr = "TRC_CLR";

        internal const string TrcDatabase = "TRC_DATABASE";

        internal const string TrcDeprecation = "TRC_DEPRECATION";

        internal const string TrcErrorsAndWarnings = "TRC_ERRORS_AND_WARNINGS";

        internal const string TrcFullText = "TRC_FULL_TEXT";

        internal const string TrcLocks = "TRC_LOCKS";

        internal const string TrcObjects = "TRC_OBJECTS";

        internal const string TrcOledb = "TRC_OLEDB";

        internal const string TrcPerformance = "TRC_PERFORMANCE";

        internal const string TrcQueryNotifications = "TRC_QUERY_NOTIFICATIONS";

        internal const string TrcSecurityAudit = "TRC_SECURITY_AUDIT";

        internal const string TrcServer = "TRC_SERVER";

        internal const string TrcStoredProcedures = "TRC_STORED_PROCEDURES";

        internal const string TrcTsql = "TRC_TSQL";

        internal const string TrcUserConfigurable = "TRC_USER_CONFIGURABLE";

        internal const string TrcAllEvents = "TRC_ALL_EVENTS";

        internal const string SuccessfulLoginGroup = "SUCCESSFUL_LOGIN_GROUP";

        internal const string LogoutGroup = "LOGOUT_GROUP";

        internal const string ServerStateChangeGroup = "SERVER_STATE_CHANGE_GROUP";

        internal const string FailedLoginGroup = "FAILED_LOGIN_GROUP";

        internal const string LoginChangePasswordGroup = "LOGIN_CHANGE_PASSWORD_GROUP";

        internal const string ServerRoleMemberChangeGroup = "SERVER_ROLE_MEMBER_CHANGE_GROUP";

        internal const string ServerPrincipalImpersonationGroup = "SERVER_PRINCIPAL_IMPERSONATION_GROUP";

        internal const string ServerObjectOwnershipChangeGroup = "SERVER_OBJECT_OWNERSHIP_CHANGE_GROUP";

        internal const string DatabaseMirroringLoginGroup = "DATABASE_MIRRORING_LOGIN_GROUP";

        internal const string BrokerLoginGroup = "BROKER_LOGIN_GROUP";

        internal const string ServerPermissionChangeGroup = "SERVER_PERMISSION_CHANGE_GROUP";

        internal const string ServerObjectPermissionChangeGroup = "SERVER_OBJECT_PERMISSION_CHANGE_GROUP";

        internal const string ServerOperationGroup = "SERVER_OPERATION_GROUP";

        internal const string TraceChangeGroup = "TRACE_CHANGE_GROUP";

        internal const string ServerObjectChangeGroup = "SERVER_OBJECT_CHANGE_GROUP";

        internal const string ServerPrincipalChangeGroup = "SERVER_PRINCIPAL_CHANGE_GROUP";

        internal const string DatabasePermissionChangeGroup = "DATABASE_PERMISSION_CHANGE_GROUP";

        internal const string SchemaObjectPermissionChangeGroup = "SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP";

        internal const string DatabaseRoleMemberChangeGroup = "DATABASE_ROLE_MEMBER_CHANGE_GROUP";

        internal const string ApplicationRoleChangePasswordGroup = "APPLICATION_ROLE_CHANGE_PASSWORD_GROUP";

        internal const string SchemaObjectAccessGroup = "SCHEMA_OBJECT_ACCESS_GROUP";

        internal const string BackupRestoreGroup = "BACKUP_RESTORE_GROUP";

        internal const string DbccGroup = "DBCC_GROUP";

        internal const string AuditChangeGroup = "AUDIT_CHANGE_GROUP";

        internal const string DatabaseChangeGroup = "DATABASE_CHANGE_GROUP";

        internal const string DatabaseObjectChangeGroup = "DATABASE_OBJECT_CHANGE_GROUP";

        internal const string DatabasePrincipalChangeGroup = "DATABASE_PRINCIPAL_CHANGE_GROUP";

        internal const string SchemaObjectChangeGroup = "SCHEMA_OBJECT_CHANGE_GROUP";

        internal const string DatabasePrincipalImpersonationGroup = "DATABASE_PRINCIPAL_IMPERSONATION_GROUP";

        internal const string DatabaseObjectOwnershipChangeGroup = "DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP";

        internal const string DatabaseOwnershipChangeGroup = "DATABASE_OWNERSHIP_CHANGE_GROUP";

        internal const string SchemaObjectOwnershipChangeGroup = "SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP";

        internal const string DatabaseObjectPermissionChangeGroup = "DATABASE_OBJECT_PERMISSION_CHANGE_GROUP";

        internal const string DatabaseOperationGroup = "DATABASE_OPERATION_GROUP";

        internal const string DatabaseObjectAccessGroup = "DATABASE_OBJECT_ACCESS_GROUP";

        internal const string SuccessfulDatabaseAuthenticationGroup = "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP";

        internal const string FailedDatabaseAuthenticationGroup = "FAILED_DATABASE_AUTHENTICATION_GROUP";

        internal const string DatabaseLogoutGroup = "DATABASE_LOGOUT_GROUP";

        internal const string UserChangePasswordGroup = "USER_CHANGE_PASSWORD_GROUP";

        internal const string UserDefinedAuditGroup = "USER_DEFINED_AUDIT_GROUP";

        internal const string TransactionBeginGroup = "TRANSACTION_BEGIN_GROUP";

        internal const string TransactionCommitGroup = "TRANSACTION_COMMIT_GROUP";

        internal const string TransactionRollbackGroup = "TRANSACTION_ROLLBACK_GROUP";

        internal const string StatementRollbackGroup = "STATEMENT_ROLLBACK_GROUP";

        internal const string TransactionGroup = "TRANSACTION_GROUP";

        internal const string GraphEdge = "EDGE";

        internal const string GraphMatch = "MATCH";

        internal const string GraphNode = "NODE";

        internal const string GraphEdgeId = "EDGE_ID";

        internal const string GraphNodeId = "NODE_ID";

        internal const string GraphFromId = "FROM_ID";

        internal const string GraphToId = "TO_ID";
    }
}
