using System;
using System.Collections.Generic;
using System.Globalization;

namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal abstract class SqlScriptGeneratorVisitor : TSqlConcreteFragmentVisitor {
        internal class ListGenerationOption {
            internal enum SeparatorType {
                Comma,
                Dot,
                Space
            }

            public static ListGenerationOption MultipleLineSelectElementOption = new ListGenerationOption {
                Parenthesised = false,
                AlwaysGenerateParenthesis = false,
                IndentParentheses = false,
                AlignParentheses = false,
                Separator = SeparatorType.Comma,
                NewLineBeforeFirstItem = false,
                NewLineBeforeItems = true,
                MultipleIndentItems = 0
            };

            public bool Parenthesised {
                get;
                set;
            }

            public bool AlwaysGenerateParenthesis {
                get;
                set;
            }

            public bool IndentParentheses {
                get;
                set;
            }

            public bool AlignParentheses {
                get;
                set;
            }

            public bool NewLineBeforeOpenParenthesis {
                get;
                set;
            }

            public bool NewLineAfterOpenParenthesis {
                get;
                set;
            }

            public bool NewLineBeforeCloseParenthesis {
                get;
                set;
            }

            public SeparatorType Separator {
                get;
                set;
            }

            public bool NewLineBeforeFirstItem {
                get;
                set;
            }

            public bool NewLineBeforeItems {
                get;
                set;
            }

            public int MultipleIndentItems {
                get;
                set;
            }

            public static ListGenerationOption CreateOptionFromFormattingConfig(SqlScriptGeneratorOptions formatting) {
                ListGenerationOption listGenerationOption = new ListGenerationOption();
                listGenerationOption.Parenthesised = true;
                listGenerationOption.AlwaysGenerateParenthesis = true;
                listGenerationOption.NewLineBeforeOpenParenthesis = formatting.NewLineBeforeOpenParenthesisInMultilineList;
                listGenerationOption.NewLineAfterOpenParenthesis = true;
                listGenerationOption.IndentParentheses = false;
                listGenerationOption.NewLineBeforeCloseParenthesis = formatting.NewLineBeforeCloseParenthesisInMultilineList;
                listGenerationOption.AlignParentheses = false;
                listGenerationOption.NewLineBeforeItems = true;
                listGenerationOption.NewLineBeforeFirstItem = false;
                listGenerationOption.MultipleIndentItems = 1;
                listGenerationOption.Separator = SeparatorType.Comma;
                return listGenerationOption;
            }
        }

        protected const string ClauseBody = "ClauseBody";

        protected const string SetClauseItemFirstEqualSign = "SetClauseItemFirstEqualSign";

        protected const string SetClauseItemSecondEqualSign = "SetClauseItemSecondEqualSign";

        protected const string InsertColumns = "InsertColumns";

        protected static Dictionary<EndpointState, string> _endpointStateNames = new Dictionary<EndpointState, string>
        {
            {
                EndpointState.Disabled,
                "DISABLED"
            },
            {
                EndpointState.Started,
                "STARTED"
            },
            {
                EndpointState.Stopped,
                "STOPPED"
            }
        };

        protected static Dictionary<EndpointProtocol, string> _endpointProtocolNames = new Dictionary<EndpointProtocol, string>
        {
            {
                EndpointProtocol.Http,
                "HTTP"
            },
            {
                EndpointProtocol.Tcp,
                "TCP"
            }
        };

        protected static Dictionary<EndpointType, string> _endpointTypeNames = new Dictionary<EndpointType, string>
        {
            {
                EndpointType.DatabaseMirroring,
                "DATABASE_MIRRORING"
            },
            {
                EndpointType.ServiceBroker,
                "SERVICE_BROKER"
            },
            {
                EndpointType.Soap,
                "SOAP"
            },
            {
                EndpointType.TSql,
                "TSQL"
            }
        };

        protected static Dictionary<PayloadOptionKinds, TokenGenerator> _payloadOptionKindsGenerators = new Dictionary<PayloadOptionKinds, TokenGenerator>
        {
            {
                PayloadOptionKinds.Authentication,
                (TokenGenerator)new IdentifierGenerator("AUTHENTICATION")
            },
            {
                PayloadOptionKinds.Batches,
                (TokenGenerator)new IdentifierGenerator("BATCHES")
            },
            {
                PayloadOptionKinds.CharacterSet,
                (TokenGenerator)new IdentifierGenerator("CHARACTER_SET")
            },
            {
                PayloadOptionKinds.Database,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Database)
            },
            {
                PayloadOptionKinds.Encryption,
                (TokenGenerator)new IdentifierGenerator("ENCRYPTION")
            },
            {
                PayloadOptionKinds.HeaderLimit,
                (TokenGenerator)new IdentifierGenerator("HEADER_LIMIT")
            },
            {
                PayloadOptionKinds.LoginType,
                (TokenGenerator)new IdentifierGenerator("LOGIN_TYPE")
            },
            {
                PayloadOptionKinds.MessageForwardSize,
                (TokenGenerator)new IdentifierGenerator("MESSAGE_FORWARD_SIZE")
            },
            {
                PayloadOptionKinds.MessageForwarding,
                (TokenGenerator)new IdentifierGenerator("MESSAGE_FORWARDING")
            },
            {
                PayloadOptionKinds.Namespace,
                (TokenGenerator)new IdentifierGenerator("NAMESPACE")
            },
            {
                PayloadOptionKinds.None,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                PayloadOptionKinds.Role,
                (TokenGenerator)new IdentifierGenerator("ROLE")
            },
            {
                PayloadOptionKinds.Schema,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Schema)
            },
            {
                PayloadOptionKinds.SessionTimeout,
                (TokenGenerator)new IdentifierGenerator("SESSION_TIMEOUT")
            },
            {
                PayloadOptionKinds.Sessions,
                (TokenGenerator)new IdentifierGenerator("SESSIONS")
            },
            {
                PayloadOptionKinds.WebMethod,
                (TokenGenerator)new IdentifierGenerator("WEBMETHOD")
            },
            {
                PayloadOptionKinds.Wsdl,
                (TokenGenerator)new IdentifierGenerator("WSDL")
            }
        };

        protected static Dictionary<SimpleAlterFullTextIndexActionKind, List<TokenGenerator>> _simpleAlterFulltextIndexActionKindActions = new Dictionary<SimpleAlterFullTextIndexActionKind, List<TokenGenerator>>
        {
            {
                SimpleAlterFullTextIndexActionKind.Disable,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("DISABLE")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.Enable,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ENABLE")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.PausePopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("PAUSE", true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.ResumePopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("RESUME", true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.StopPopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("STOP", true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.SetChangeTrackingAuto,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Set, true),
                    (TokenGenerator)new IdentifierGenerator("CHANGE_TRACKING", true),
                    (TokenGenerator)new IdentifierGenerator("AUTO")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.SetChangeTrackingManual,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Set, true),
                    (TokenGenerator)new IdentifierGenerator("CHANGE_TRACKING", true),
                    (TokenGenerator)new IdentifierGenerator("MANUAL")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.SetChangeTrackingOff,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Set, true),
                    (TokenGenerator)new IdentifierGenerator("CHANGE_TRACKING", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Off)
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.StartFullPopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("START", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Full, true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.StartIncrementalPopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("START", true),
                    (TokenGenerator)new IdentifierGenerator("INCREMENTAL", true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            },
            {
                SimpleAlterFullTextIndexActionKind.StartUpdatePopulation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("START", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Update, true),
                    (TokenGenerator)new IdentifierGenerator("POPULATION")
                }
            }
        };

        private static Dictionary<AlterTableAlterColumnOption, List<TokenGenerator>> _alterTableAlterColumnOptionNames = new Dictionary<AlterTableAlterColumnOption, List<TokenGenerator>>
        {
            {
                AlterTableAlterColumnOption.AddRowGuidCol,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.RowGuidColumn)
                }
            },
            {
                AlterTableAlterColumnOption.DropRowGuidCol,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.RowGuidColumn)
                }
            },
            {
                AlterTableAlterColumnOption.AddPersisted,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new IdentifierGenerator("PERSISTED")
                }
            },
            {
                AlterTableAlterColumnOption.DropPersisted,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new IdentifierGenerator("PERSISTED")
                }
            },
            {
                AlterTableAlterColumnOption.AddNotForReplication,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Not, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.For, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Replication)
                }
            },
            {
                AlterTableAlterColumnOption.DropNotForReplication,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Not, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.For, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Replication)
                }
            },
            {
                AlterTableAlterColumnOption.AddSparse,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new IdentifierGenerator("SPARSE")
                }
            },
            {
                AlterTableAlterColumnOption.DropSparse,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new IdentifierGenerator("SPARSE")
                }
            },
            {
                AlterTableAlterColumnOption.AddMaskingFunction,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new IdentifierGenerator("MASKED", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.With, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.LeftParenthesis),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Function, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                AlterTableAlterColumnOption.DropMaskingFunction,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new IdentifierGenerator("MASKED")
                }
            },
            {
                AlterTableAlterColumnOption.AddHidden,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add, true),
                    (TokenGenerator)new IdentifierGenerator("HIDDEN")
                }
            },
            {
                AlterTableAlterColumnOption.DropHidden,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop, true),
                    (TokenGenerator)new IdentifierGenerator("HIDDEN")
                }
            }
        };

        protected static Dictionary<TableElementType, TokenGenerator> _tableElementTypeGenerators = new Dictionary<TableElementType, TokenGenerator>
        {
            {
                TableElementType.Column,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Column)
            },
            {
                TableElementType.Constraint,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Constraint)
            },
            {
                TableElementType.Index,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Index)
            },
            {
                TableElementType.Period,
                (TokenGenerator)new IdentifierGenerator("PERIOD")
            },
            {
                TableElementType.NotSpecified,
                (TokenGenerator)new EmptyGenerator()
            }
        };

        protected static Dictionary<AuthenticationTypes, TokenGenerator> _authenticationTypesGenerators = new Dictionary<AuthenticationTypes, TokenGenerator>
        {
            {
                AuthenticationTypes.Basic,
                (TokenGenerator)new IdentifierGenerator("BASIC")
            },
            {
                AuthenticationTypes.Digest,
                (TokenGenerator)new IdentifierGenerator("DIGEST")
            },
            {
                AuthenticationTypes.Integrated,
                (TokenGenerator)new IdentifierGenerator("INTEGRATED")
            },
            {
                AuthenticationTypes.Kerberos,
                (TokenGenerator)new IdentifierGenerator("KERBEROS")
            },
            {
                AuthenticationTypes.Ntlm,
                (TokenGenerator)new IdentifierGenerator("NTLM")
            }
        };

        protected static Dictionary<AuthenticationProtocol, string> _authenticationProtocolNames = new Dictionary<AuthenticationProtocol, string>
        {
            {
                AuthenticationProtocol.Windows,
                "WINDOWS"
            },
            {
                AuthenticationProtocol.WindowsKerberos,
                "KERBEROS"
            },
            {
                AuthenticationProtocol.WindowsNegotiate,
                "NEGOTIATE"
            },
            {
                AuthenticationProtocol.WindowsNtlm,
                "NTLM"
            }
        };

        protected static Dictionary<AutomaticTuningOptionState, string> _optionNames = new Dictionary<AutomaticTuningOptionState, string>
        {
            {
                AutomaticTuningOptionState.Off,
                "OFF"
            },
            {
                AutomaticTuningOptionState.On,
                "ON"
            },
            {
                AutomaticTuningOptionState.Default,
                "DEFAULT"
            }
        };

        protected static Dictionary<DialogOptionKind, string> _dialogOptionNames = new Dictionary<DialogOptionKind, string>
        {
            {
                DialogOptionKind.Lifetime,
                "LIFETIME"
            },
            {
                DialogOptionKind.RelatedConversation,
                "RELATED_CONVERSATION"
            },
            {
                DialogOptionKind.RelatedConversationGroup,
                "RELATED_CONVERSATION_GROUP"
            }
        };

        protected static Dictionary<BinaryQueryExpressionType, TokenGenerator> _binaryQueryExpressionTypeGenerators = new Dictionary<BinaryQueryExpressionType, TokenGenerator>
        {
            {
                BinaryQueryExpressionType.Except,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Except)
            },
            {
                BinaryQueryExpressionType.Intersect,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Intersect)
            },
            {
                BinaryQueryExpressionType.Union,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union)
            }
        };

        protected static Dictionary<BooleanTernaryExpressionType, List<TokenGenerator>> _ternaryExpressionTypeGenerators = new Dictionary<BooleanTernaryExpressionType, List<TokenGenerator>>
        {
            {
                BooleanTernaryExpressionType.Between,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Between)
                }
            },
            {
                BooleanTernaryExpressionType.NotBetween,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Not, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Between)
                }
            }
        };

        private static Dictionary<CertificateOptionKinds, string> _certificateOptionNames = new Dictionary<CertificateOptionKinds, string>
        {
            {
                CertificateOptionKinds.Subject,
                "SUBJECT"
            },
            {
                CertificateOptionKinds.StartDate,
                "START_DATE"
            },
            {
                CertificateOptionKinds.ExpiryDate,
                "EXPIRY_DATE"
            }
        };

        private static readonly Array _commandOptions = Enum.GetValues(typeof(CommandOptions));

        protected static Dictionary<BinaryExpressionType, List<TokenGenerator>> _binaryExpressionTypeGenerators = new Dictionary<BinaryExpressionType, List<TokenGenerator>>
        {
            {
                BinaryExpressionType.Add,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plus)
                }
            },
            {
                BinaryExpressionType.Subtract,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Minus)
                }
            },
            {
                BinaryExpressionType.Multiply,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Star)
                }
            },
            {
                BinaryExpressionType.Divide,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Divide)
                }
            },
            {
                BinaryExpressionType.Modulo,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.PercentSign)
                }
            },
            {
                BinaryExpressionType.BitwiseAnd,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Ampersand)
                }
            },
            {
                BinaryExpressionType.BitwiseOr,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.VerticalLine)
                }
            },
            {
                BinaryExpressionType.BitwiseXor,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Circumflex)
                }
            }
        };

        protected static Dictionary<BooleanComparisonType, List<TokenGenerator>> _booleanComparisonTypeGenerators = new Dictionary<BooleanComparisonType, List<TokenGenerator>>
        {
            {
                BooleanComparisonType.Equals,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                BooleanComparisonType.GreaterThan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.GreaterThan)
                }
            },
            {
                BooleanComparisonType.LessThan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.LessThan)
                }
            },
            {
                BooleanComparisonType.GreaterThanOrEqualTo,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.GreaterThan),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                BooleanComparisonType.LessThanOrEqualTo,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.LessThan),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                BooleanComparisonType.NotEqualToBrackets,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.LessThan),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.GreaterThan)
                }
            },
            {
                BooleanComparisonType.NotEqualToExclamation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Bang),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                BooleanComparisonType.NotLessThan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Bang),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.LessThan)
                }
            },
            {
                BooleanComparisonType.NotGreaterThan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Bang),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.GreaterThan)
                }
            },
            {
                BooleanComparisonType.LeftOuterJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.MultiplyEquals)
                }
            },
            {
                BooleanComparisonType.RightOuterJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.RightOuterJoin)
                }
            }
        };

        protected static Dictionary<BooleanBinaryExpressionType, List<TokenGenerator>> _booleanBinaryExpressionTypeGenerators = new Dictionary<BooleanBinaryExpressionType, List<TokenGenerator>>
        {
            {
                BooleanBinaryExpressionType.And,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.And)
                }
            },
            {
                BooleanBinaryExpressionType.Or,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Or)
                }
            }
        };

        protected bool _generateSemiColon = true;

        private static Dictionary<DeleteUpdateAction, List<TokenGenerator>> _deleteUpdateActionGenerators = new Dictionary<DeleteUpdateAction, List<TokenGenerator>>
        {
            {
                DeleteUpdateAction.Cascade,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Cascade)
                }
            },
            {
                DeleteUpdateAction.NoAction,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("NO", true),
                    (TokenGenerator)new IdentifierGenerator("ACTION")
                }
            },
            {
                DeleteUpdateAction.SetDefault,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Set, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Default)
                }
            },
            {
                DeleteUpdateAction.SetNull,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Set, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Null)
                }
            }
        };

        protected static Dictionary<MessageSender, TokenGenerator> _messageSenderGenerators = new Dictionary<MessageSender, TokenGenerator>
        {
            {
                MessageSender.None,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                MessageSender.Any,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Any)
            },
            {
                MessageSender.Initiator,
                (TokenGenerator)new IdentifierGenerator("INITIATOR")
            },
            {
                MessageSender.Target,
                (TokenGenerator)new IdentifierGenerator("TARGET")
            }
        };

        protected static Dictionary<PermissionSetOption, string> _permissionSetOptionNames = new Dictionary<PermissionSetOption, string>
        {
            {
                PermissionSetOption.ExternalAccess,
                "EXTERNAL_ACCESS"
            },
            {
                PermissionSetOption.Safe,
                "SAFE"
            },
            {
                PermissionSetOption.Unsafe,
                "UNSAFE"
            }
        };

        private static Dictionary<AttachMode, TokenGenerator> _attachModeGenerators = new Dictionary<AttachMode, TokenGenerator>
        {
            {
                AttachMode.Attach,
                (TokenGenerator)new IdentifierGenerator("ATTACH")
            },
            {
                AttachMode.AttachForceRebuildLog,
                (TokenGenerator)new IdentifierGenerator("ATTACH_FORCE_REBUILD_LOG")
            },
            {
                AttachMode.AttachRebuildLog,
                (TokenGenerator)new IdentifierGenerator("ATTACH_REBUILD_LOG")
            },
            {
                AttachMode.Load,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Load)
            }
        };

        protected static Dictionary<ExternalDataSourceType, string> _externalDataSourceTypeNames = new Dictionary<ExternalDataSourceType, string>
        {
            {
                ExternalDataSourceType.HADOOP,
                "HADOOP"
            },
            {
                ExternalDataSourceType.RDBMS,
                "RDBMS"
            },
            {
                ExternalDataSourceType.SHARD_MAP_MANAGER,
                "SHARD_MAP_MANAGER"
            },
            {
                ExternalDataSourceType.BLOB_STORAGE,
                "BLOB_STORAGE"
            }
        };

        protected static Dictionary<ExternalFileFormatType, string> _externalFileFormatTypeNames = new Dictionary<ExternalFileFormatType, string>
        {
            {
                ExternalFileFormatType.DelimitedText,
                "DELIMITEDTEXT"
            },
            {
                ExternalFileFormatType.RcFile,
                "RCFILE"
            },
            {
                ExternalFileFormatType.Orc,
                "ORC"
            },
            {
                ExternalFileFormatType.Parquet,
                "PARQUET"
            }
        };

        private static Dictionary<SecondaryXmlIndexType, string> _secondaryXmlIndexTypeNames = new Dictionary<SecondaryXmlIndexType, string>
        {
            {
                SecondaryXmlIndexType.Path,
                "PATH"
            },
            {
                SecondaryXmlIndexType.Property,
                "PROPERTY"
            },
            {
                SecondaryXmlIndexType.Value,
                "VALUE"
            }
        };

        protected SqlScriptGeneratorOptions _options;

        protected ScriptWriter _writer;

        private Dictionary<TSqlFragment, Dictionary<string, AlignmentPoint>> _alignmentPointsForFragments;

        private static Dictionary<CursorOptionKind, string> _cursorOptionsNames = new Dictionary<CursorOptionKind, string>
        {
            {
                CursorOptionKind.Local,
                "LOCAL"
            },
            {
                CursorOptionKind.Global,
                "GLOBAL"
            },
            {
                CursorOptionKind.Scroll,
                "SCROLL"
            },
            {
                CursorOptionKind.ForwardOnly,
                "FORWARD_ONLY"
            },
            {
                CursorOptionKind.Insensitive,
                "INSENSITIVE"
            },
            {
                CursorOptionKind.Keyset,
                "KEYSET"
            },
            {
                CursorOptionKind.Dynamic,
                "DYNAMIC"
            },
            {
                CursorOptionKind.FastForward,
                "FAST_FORWARD"
            },
            {
                CursorOptionKind.ScrollLocks,
                "SCROLL_LOCKS"
            },
            {
                CursorOptionKind.Optimistic,
                "OPTIMISTIC"
            },
            {
                CursorOptionKind.ReadOnly,
                "READ_ONLY"
            },
            {
                CursorOptionKind.Static,
                "STATIC"
            },
            {
                CursorOptionKind.TypeWarning,
                "TYPE_WARNING"
            }
        };

        private static Dictionary<DatabaseAuditActionKind, TokenGenerator> _databaseAuditActionName = new Dictionary<DatabaseAuditActionKind, TokenGenerator>
        {
            {
                DatabaseAuditActionKind.Select,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Select)
            },
            {
                DatabaseAuditActionKind.Update,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Update)
            },
            {
                DatabaseAuditActionKind.Insert,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Insert)
            },
            {
                DatabaseAuditActionKind.Delete,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Delete)
            },
            {
                DatabaseAuditActionKind.Execute,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Execute)
            },
            {
                DatabaseAuditActionKind.Receive,
                (TokenGenerator)new IdentifierGenerator("RECEIVE")
            },
            {
                DatabaseAuditActionKind.References,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.References)
            }
        };

        private static Dictionary<DbccCommand, string> _dbccCommandNames = new Dictionary<DbccCommand, string>
        {
            {
                DbccCommand.ActiveCursors,
                "ACTIVECURSORS"
            },
            {
                DbccCommand.AddExtendedProc,
                "ADDEXTENDEDPROC"
            },
            {
                DbccCommand.AddInstance,
                "ADDINSTANCE"
            },
            {
                DbccCommand.AuditEvent,
                "AUDITEVENT"
            },
            {
                DbccCommand.AutoPilot,
                "AUTOPILOT"
            },
            {
                DbccCommand.Buffer,
                "BUFFER"
            },
            {
                DbccCommand.Bytes,
                "BYTES"
            },
            {
                DbccCommand.CacheProfile,
                "CACHEPROFILE"
            },
            {
                DbccCommand.CacheStats,
                "CACHESTATS"
            },
            {
                DbccCommand.CallFullText,
                "CALLFULLTEXT"
            },
            {
                DbccCommand.CheckAlloc,
                "CHECKALLOC"
            },
            {
                DbccCommand.CheckCatalog,
                "CHECKCATALOG"
            },
            {
                DbccCommand.CheckConstraints,
                "CHECKCONSTRAINTS"
            },
            {
                DbccCommand.CheckDB,
                "CHECKDB"
            },
            {
                DbccCommand.CheckFileGroup,
                "CHECKFILEGROUP"
            },
            {
                DbccCommand.CheckIdent,
                "CHECKIDENT"
            },
            {
                DbccCommand.CheckPrimaryFile,
                "CHECKPRIMARYFILE"
            },
            {
                DbccCommand.CheckTable,
                "CHECKTABLE"
            },
            {
                DbccCommand.CleanTable,
                "CLEANTABLE"
            },
            {
                DbccCommand.ClearSpaceCaches,
                "CLEARSPACECACHES"
            },
            {
                DbccCommand.CollectStats,
                "COLLECTSTATS"
            },
            {
                DbccCommand.ConcurrencyViolation,
                "CONCURRENCYVIOLATION"
            },
            {
                DbccCommand.CursorStats,
                "CURSORSTATS"
            },
            {
                DbccCommand.DBRecover,
                "DBRECOVER"
            },
            {
                DbccCommand.DBReindex,
                "DBREINDEX"
            },
            {
                DbccCommand.DBReindexAll,
                "DBREINDEXALL"
            },
            {
                DbccCommand.DBRepair,
                "DBREPAIR"
            },
            {
                DbccCommand.DebugBreak,
                "DEBUGBREAK"
            },
            {
                DbccCommand.DeleteInstance,
                "DELETEINSTANCE"
            },
            {
                DbccCommand.DetachDB,
                "DETACHDB"
            },
            {
                DbccCommand.DropCleanBuffers,
                "DROPCLEANBUFFERS"
            },
            {
                DbccCommand.DropExtendedProc,
                "DROPEXTENDEDPROC"
            },
            {
                DbccCommand.DumpConfig,
                "CONFIG"
            },
            {
                DbccCommand.DumpDBInfo,
                "DBINFO"
            },
            {
                DbccCommand.DumpDBTable,
                "DBTABLE"
            },
            {
                DbccCommand.DumpLock,
                "LOCK"
            },
            {
                DbccCommand.DumpLog,
                "LOG"
            },
            {
                DbccCommand.DumpPage,
                "PAGE"
            },
            {
                DbccCommand.DumpResource,
                "RESOURCE"
            },
            {
                DbccCommand.DumpTrigger,
                "DUMPTRIGGER"
            },
            {
                DbccCommand.ErrorLog,
                "ERRORLOG"
            },
            {
                DbccCommand.ExtentInfo,
                "EXTENTINFO"
            },
            {
                DbccCommand.FileHeader,
                "FILEHEADER"
            },
            {
                DbccCommand.FixAllocation,
                "FIXALLOCATION"
            },
            {
                DbccCommand.Flush,
                "FLUSH"
            },
            {
                DbccCommand.FlushProcInDB,
                "FLUSHPROCINDB"
            },
            {
                DbccCommand.ForceGhostCleanup,
                "FORCEGHOSTCLEANUP"
            },
            {
                DbccCommand.Free,
                "FREE"
            },
            {
                DbccCommand.FreeProcCache,
                "FREEPROCCACHE"
            },
            {
                DbccCommand.FreeSessionCache,
                "FREESESSIONCACHE"
            },
            {
                DbccCommand.FreeSystemCache,
                "FREESYSTEMCACHE"
            },
            {
                DbccCommand.FreezeIO,
                "FREEZE_IO"
            },
            {
                DbccCommand.Help,
                "HELP"
            },
            {
                DbccCommand.IcecapQuery,
                "ICECAPQUERY"
            },
            {
                DbccCommand.IncrementInstance,
                "INCREMENTINSTANCE"
            },
            {
                DbccCommand.Ind,
                "IND"
            },
            {
                DbccCommand.IndexDefrag,
                "INDEXDEFRAG"
            },
            {
                DbccCommand.InputBuffer,
                "INPUTBUFFER"
            },
            {
                DbccCommand.InvalidateTextptr,
                "INVALIDATE_TEXTPTR"
            },
            {
                DbccCommand.InvalidateTextptrObjid,
                "INVALIDATE_TEXTPTR_OBJID"
            },
            {
                DbccCommand.Latch,
                "LATCH"
            },
            {
                DbccCommand.LogInfo,
                "LOGINFO"
            },
            {
                DbccCommand.MapAllocUnit,
                "MAPALLOCUNIT"
            },
            {
                DbccCommand.MemObjList,
                "MEMOBJLIST"
            },
            {
                DbccCommand.MemoryMap,
                "MEMORYMAP"
            },
            {
                DbccCommand.MemoryStatus,
                "MEMORYSTATUS"
            },
            {
                DbccCommand.Metadata,
                "METADATA"
            },
            {
                DbccCommand.MovePage,
                "MOVEPAGE"
            },
            {
                DbccCommand.NoTextptr,
                "NO_TEXTPTR"
            },
            {
                DbccCommand.OpenTran,
                "OPENTRAN"
            },
            {
                DbccCommand.OptimizerWhatIf,
                "OPTIMIZER_WHATIF"
            },
            {
                DbccCommand.OutputBuffer,
                "OUTPUTBUFFER"
            },
            {
                DbccCommand.PerfMonStats,
                "PERFMON"
            },
            {
                DbccCommand.PersistStackHash,
                "PERSISTSTACKHASH"
            },
            {
                DbccCommand.PinTable,
                "PINTABLE"
            },
            {
                DbccCommand.ProcCache,
                "PROCCACHE"
            },
            {
                DbccCommand.PrtiPage,
                "PRTIPAGE"
            },
            {
                DbccCommand.ReadPage,
                "READPAGE"
            },
            {
                DbccCommand.RenameColumn,
                "RENAMECOLUMN"
            },
            {
                DbccCommand.RuleOff,
                "RULEOFF"
            },
            {
                DbccCommand.RuleOn,
                "RULEON"
            },
            {
                DbccCommand.SeMetadata,
                "SEMETADATA"
            },
            {
                DbccCommand.SetCpuWeight,
                "SETCPUWEIGHT"
            },
            {
                DbccCommand.SetInstance,
                "SETINSTANCE"
            },
            {
                DbccCommand.SetIOWeight,
                "SETIOWEIGHT"
            },
            {
                DbccCommand.ShowStatistics,
                "SHOW_STATISTICS"
            },
            {
                DbccCommand.ShowContig,
                "SHOWCONTIG"
            },
            {
                DbccCommand.ShowDBAffinity,
                "SHOWDBAFFINITY"
            },
            {
                DbccCommand.ShowFileStats,
                "SHOWFILESTATS"
            },
            {
                DbccCommand.ShowOffRules,
                "SHOWOFFRULES"
            },
            {
                DbccCommand.ShowOnRules,
                "SHOWONRULES"
            },
            {
                DbccCommand.ShowTableAffinity,
                "SHOWTABLEAFFINITY"
            },
            {
                DbccCommand.ShowText,
                "SHOWTEXT"
            },
            {
                DbccCommand.ShowWeights,
                "SHOWWEIGHTS"
            },
            {
                DbccCommand.ShrinkDatabase,
                "SHRINKDATABASE"
            },
            {
                DbccCommand.ShrinkFile,
                "SHRINKFILE"
            },
            {
                DbccCommand.SqlMgrStats,
                "SQLMGRSTATS"
            },
            {
                DbccCommand.SqlPerf,
                "SQLPERF"
            },
            {
                DbccCommand.StackDump,
                "STACKDUMP"
            },
            {
                DbccCommand.Tec,
                "TEC"
            },
            {
                DbccCommand.ThawIO,
                "THAW_IO"
            },
            {
                DbccCommand.ThrottleIO,
                "THROTTLE_IO"
            },
            {
                DbccCommand.TraceOff,
                "TRACEOFF"
            },
            {
                DbccCommand.TraceOn,
                "TRACEON"
            },
            {
                DbccCommand.TraceStatus,
                "TRACESTATUS"
            },
            {
                DbccCommand.UnpinTable,
                "UNPINTABLE"
            },
            {
                DbccCommand.UpdateUsage,
                "UPDATEUSAGE"
            },
            {
                DbccCommand.UsePlan,
                "USEPLAN"
            },
            {
                DbccCommand.UserOptions,
                "USEROPTIONS"
            },
            {
                DbccCommand.WritePage,
                "WRITEPAGE"
            }
        };

        private static Dictionary<DbccOptionKind, TokenGenerator> _dbccOptionsGenerators = new Dictionary<DbccOptionKind, TokenGenerator>
        {
            {
                DbccOptionKind.AllErrorMessages,
                (TokenGenerator)new IdentifierGenerator("ALL_ERRORMSGS")
            },
            {
                DbccOptionKind.CountRows,
                (TokenGenerator)new IdentifierGenerator("COUNT_ROWS")
            },
            {
                DbccOptionKind.NoInfoMessages,
                (TokenGenerator)new IdentifierGenerator("NO_INFOMSGS")
            },
            {
                DbccOptionKind.TableResults,
                (TokenGenerator)new IdentifierGenerator("TABLERESULTS")
            },
            {
                DbccOptionKind.TabLock,
                (TokenGenerator)new IdentifierGenerator("TABLOCK")
            },
            {
                DbccOptionKind.StatHeader,
                (TokenGenerator)new IdentifierGenerator("STAT_HEADER")
            },
            {
                DbccOptionKind.DensityVector,
                (TokenGenerator)new IdentifierGenerator("DENSITY_VECTOR")
            },
            {
                DbccOptionKind.HistogramSteps,
                (TokenGenerator)new IdentifierGenerator("HISTOGRAM_STEPS")
            },
            {
                DbccOptionKind.EstimateOnly,
                (TokenGenerator)new IdentifierGenerator("ESTIMATEONLY")
            },
            {
                DbccOptionKind.Fast,
                (TokenGenerator)new IdentifierGenerator("FAST")
            },
            {
                DbccOptionKind.AllLevels,
                (TokenGenerator)new IdentifierGenerator("ALL_LEVELS")
            },
            {
                DbccOptionKind.AllIndexes,
                (TokenGenerator)new IdentifierGenerator("ALL_INDEXES")
            },
            {
                DbccOptionKind.PhysicalOnly,
                (TokenGenerator)new IdentifierGenerator("PHYSICAL_ONLY")
            },
            {
                DbccOptionKind.AllConstraints,
                (TokenGenerator)new IdentifierGenerator("ALL_CONSTRAINTS")
            },
            {
                DbccOptionKind.StatsStream,
                (TokenGenerator)new IdentifierGenerator("STATS_STREAM")
            },
            {
                DbccOptionKind.Histogram,
                (TokenGenerator)new IdentifierGenerator("HISTOGRAM")
            },
            {
                DbccOptionKind.DataPurity,
                (TokenGenerator)new IdentifierGenerator("DATA_PURITY")
            },
            {
                DbccOptionKind.MarkInUseForRemoval,
                (TokenGenerator)new IdentifierGenerator("MARK_IN_USE_FOR_REMOVAL")
            },
            {
                DbccOptionKind.ExtendedLogicalChecks,
                (TokenGenerator)new IdentifierGenerator("EXTENDED_LOGICAL_CHECKS")
            }
        };

        private static Dictionary<DeviceType, TokenGenerator> _deviceTypeGenerators = new Dictionary<DeviceType, TokenGenerator>
        {
            {
                DeviceType.DatabaseSnapshot,
                (TokenGenerator)new IdentifierGenerator("DATABASE_SNAPSHOT")
            },
            {
                DeviceType.Disk,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Disk)
            },
            {
                DeviceType.Tape,
                (TokenGenerator)new IdentifierGenerator("TAPE")
            },
            {
                DeviceType.VirtualDevice,
                (TokenGenerator)new IdentifierGenerator("VIRTUAL_DEVICE")
            }
        };

        protected static Dictionary<DropClusteredConstraintOptionKind, List<TokenGenerator>> _dropClusteredConstraintOptionTypeGenerators = new Dictionary<DropClusteredConstraintOptionKind, List<TokenGenerator>>
        {
            {
                DropClusteredConstraintOptionKind.MaxDop,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MAXDOP", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                DropClusteredConstraintOptionKind.MoveTo,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MOVE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.To)
                }
            },
            {
                DropClusteredConstraintOptionKind.Online,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ONLINE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                DropClusteredConstraintOptionKind.WaitAtLowPriority,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("WAIT_AT_LOW_PRIORITY", true)
                }
            }
        };

        protected static Dictionary<EndpointEncryptionSupport, TokenGenerator> _endpointEncryptionSupportGenerators = new Dictionary<EndpointEncryptionSupport, TokenGenerator>
        {
            {
                EndpointEncryptionSupport.Disabled,
                (TokenGenerator)new IdentifierGenerator("DISABLED")
            },
            {
                EndpointEncryptionSupport.NotSpecified,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                EndpointEncryptionSupport.Required,
                (TokenGenerator)new IdentifierGenerator("REQUIRED")
            },
            {
                EndpointEncryptionSupport.Supported,
                (TokenGenerator)new IdentifierGenerator("SUPPORTED")
            }
        };

        private static Dictionary<ExecuteAsOption, TokenGenerator> _executeAsOptionGenerators = new Dictionary<ExecuteAsOption, TokenGenerator>
        {
            {
                ExecuteAsOption.Caller,
                (TokenGenerator)new IdentifierGenerator("CALLER")
            },
            {
                ExecuteAsOption.Login,
                (TokenGenerator)new IdentifierGenerator("LOGIN")
            },
            {
                ExecuteAsOption.Owner,
                (TokenGenerator)new IdentifierGenerator("OWNER")
            },
            {
                ExecuteAsOption.Self,
                (TokenGenerator)new IdentifierGenerator("SELF")
            },
            {
                ExecuteAsOption.User,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.User)
            }
        };

        protected static Dictionary<SortOrder, TokenGenerator> _sortOrderGenerators = new Dictionary<SortOrder, TokenGenerator>
        {
            {
                SortOrder.Ascending,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Asc)
            },
            {
                SortOrder.Descending,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Desc)
            },
            {
                SortOrder.NotSpecified,
                (TokenGenerator)new EmptyGenerator()
            }
        };

        protected static Dictionary<ExternalFileFormatUseDefaultType, string> _externalFileFormatUseDefaultTypeNames = new Dictionary<ExternalFileFormatUseDefaultType, string>
        {
            {
                ExternalFileFormatUseDefaultType.False,
                "FALSE"
            },
            {
                ExternalFileFormatUseDefaultType.True,
                "TRUE"
            }
        };

        protected static Dictionary<ExternalTableRejectType, string> _externalTableRejectTypeNames = new Dictionary<ExternalTableRejectType, string>
        {
            {
                ExternalTableRejectType.Value,
                "VALUE"
            },
            {
                ExternalTableRejectType.Percentage,
                "PERCENTAGE"
            }
        };

        private static Dictionary<FetchOrientation, string> _fetchOrientationNames = new Dictionary<FetchOrientation, string>
        {
            {
                FetchOrientation.Absolute,
                "ABSOLUTE"
            },
            {
                FetchOrientation.First,
                "FIRST"
            },
            {
                FetchOrientation.Last,
                "LAST"
            },
            {
                FetchOrientation.Next,
                "NEXT"
            },
            {
                FetchOrientation.Prior,
                "PRIOR"
            },
            {
                FetchOrientation.Relative,
                "RELATIVE"
            }
        };

        protected static Dictionary<NonTransactedFileStreamAccess, string> _nonTransactedFileStreamAccessNames = new Dictionary<NonTransactedFileStreamAccess, string>
        {
            {
                NonTransactedFileStreamAccess.Full,
                "FULL"
            },
            {
                NonTransactedFileStreamAccess.Off,
                "OFF"
            },
            {
                NonTransactedFileStreamAccess.ReadOnly,
                "READ_ONLY"
            }
        };

        protected static Dictionary<FullTextFunctionType, TokenGenerator> _fulltextFunctionTypeGenerators = new Dictionary<FullTextFunctionType, TokenGenerator>
        {
            {
                FullTextFunctionType.Contains,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Contains)
            },
            {
                FullTextFunctionType.FreeText,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.FreeText)
            }
        };

        protected static Dictionary<FunctionOptionKind, List<TokenGenerator>> _functionOptionsGenerators = new Dictionary<FunctionOptionKind, List<TokenGenerator>>
        {
            {
                FunctionOptionKind.CalledOnNullInput,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("CALLED", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.On, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Null, true),
                    (TokenGenerator)new IdentifierGenerator("INPUT")
                }
            },
            {
                FunctionOptionKind.Encryption,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ENCRYPTION")
                }
            },
            {
                FunctionOptionKind.ReturnsNullOnNullInput,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("RETURNS", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Null, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.On, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Null, true),
                    (TokenGenerator)new IdentifierGenerator("INPUT")
                }
            },
            {
                FunctionOptionKind.SchemaBinding,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SCHEMABINDING")
                }
            },
            {
                FunctionOptionKind.NativeCompilation,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("NATIVE_COMPILATION")
                }
            }
        };

        protected static Dictionary<GeneralSetCommandType, TokenGenerator> _generalSetCommandTypeGenerators = new Dictionary<GeneralSetCommandType, TokenGenerator>
        {
            {
                GeneralSetCommandType.ContextInfo,
                (TokenGenerator)new IdentifierGenerator("CONTEXT_INFO")
            },
            {
                GeneralSetCommandType.DateFirst,
                (TokenGenerator)new IdentifierGenerator("DATEFIRST")
            },
            {
                GeneralSetCommandType.DateFormat,
                (TokenGenerator)new IdentifierGenerator("DATEFORMAT")
            },
            {
                GeneralSetCommandType.DeadlockPriority,
                (TokenGenerator)new IdentifierGenerator("DEADLOCK_PRIORITY")
            },
            {
                GeneralSetCommandType.Language,
                (TokenGenerator)new IdentifierGenerator("LANGUAGE")
            },
            {
                GeneralSetCommandType.LockTimeout,
                (TokenGenerator)new IdentifierGenerator("LOCK_TIMEOUT")
            },
            {
                GeneralSetCommandType.None,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                GeneralSetCommandType.QueryGovernorCostLimit,
                (TokenGenerator)new IdentifierGenerator("QUERY_GOVERNOR_COST_LIMIT")
            }
        };

        private static Dictionary<PrincipalOptionKind, string> _loginOptionsNames = new Dictionary<PrincipalOptionKind, string>
        {
            {
                PrincipalOptionKind.CheckExpiration,
                "CHECK_EXPIRATION"
            },
            {
                PrincipalOptionKind.CheckPolicy,
                "CHECK_POLICY"
            },
            {
                PrincipalOptionKind.Credential,
                "CREDENTIAL"
            },
            {
                PrincipalOptionKind.DefaultDatabase,
                "DEFAULT_DATABASE"
            },
            {
                PrincipalOptionKind.DefaultLanguage,
                "DEFAULT_LANGUAGE"
            },
            {
                PrincipalOptionKind.Name,
                "NAME"
            },
            {
                PrincipalOptionKind.Password,
                "PASSWORD"
            },
            {
                PrincipalOptionKind.Sid,
                "SID"
            },
            {
                PrincipalOptionKind.DefaultSchema,
                "DEFAULT_SCHEMA"
            },
            {
                PrincipalOptionKind.Login,
                "LOGIN"
            },
            {
                PrincipalOptionKind.Type,
                "TYPE"
            }
        };

        protected static Dictionary<InsertOption, TokenGenerator> _insertOptionGenerators = new Dictionary<InsertOption, TokenGenerator>
        {
            {
                InsertOption.Into,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Into)
            },
            {
                InsertOption.None,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Into)
            },
            {
                InsertOption.Over,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Over)
            }
        };

        protected static Dictionary<JsonForClauseOptions, TokenGenerator> _jsonForClauseOptionsGenerators = new Dictionary<JsonForClauseOptions, TokenGenerator>
        {
            {
                JsonForClauseOptions.Auto,
                (TokenGenerator)new IdentifierGenerator("AUTO")
            },
            {
                JsonForClauseOptions.Path,
                (TokenGenerator)new IdentifierGenerator("PATH")
            },
            {
                JsonForClauseOptions.Root,
                (TokenGenerator)new IdentifierGenerator("ROOT")
            },
            {
                JsonForClauseOptions.IncludeNullValues,
                (TokenGenerator)new IdentifierGenerator("INCLUDE_NULL_VALUES")
            },
            {
                JsonForClauseOptions.WithoutArrayWrapper,
                (TokenGenerator)new IdentifierGenerator("WITHOUT_ARRAY_WRAPPER")
            }
        };

        protected static Dictionary<EndpointProtocolOptions, string> _endpointProtocolOptionsNames = new Dictionary<EndpointProtocolOptions, string>
        {
            {
                EndpointProtocolOptions.HttpAuthenticationRealm,
                "AUTH_REALM"
            },
            {
                EndpointProtocolOptions.HttpClearPort,
                "CLEAR_PORT"
            },
            {
                EndpointProtocolOptions.HttpDefaultLogonDomain,
                "DEFAULT_LOGON_DOMAIN"
            },
            {
                EndpointProtocolOptions.HttpPath,
                "PATH"
            },
            {
                EndpointProtocolOptions.HttpSite,
                "SITE"
            },
            {
                EndpointProtocolOptions.HttpSslPort,
                "SSL_PORT"
            },
            {
                EndpointProtocolOptions.TcpListenerPort,
                "LISTENER_PORT"
            }
        };

        private static Dictionary<MessageValidationMethod, string> _MessageValidationMethodNames = new Dictionary<MessageValidationMethod, string>
        {
            {
                MessageValidationMethod.Empty,
                "EMPTY"
            },
            {
                MessageValidationMethod.None,
                "NONE"
            },
            {
                MessageValidationMethod.ValidXml,
                "VALID_XML"
            },
            {
                MessageValidationMethod.WellFormedXml,
                "WELL_FORMED_XML"
            }
        };

        protected static Dictionary<OptimizerHintKind, List<TokenGenerator>> _optimizerHintKindsGenerators = new Dictionary<OptimizerHintKind, List<TokenGenerator>>
        {
            {
                OptimizerHintKind.AlterColumnPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ALTERCOLUMN", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.BypassOptimizerQueue,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("BYPASS", true),
                    (TokenGenerator)new IdentifierGenerator("OPTIMIZER_QUEUE")
                }
            },
            {
                OptimizerHintKind.ConcatUnion,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("CONCAT", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union)
                }
            },
            {
                OptimizerHintKind.ExpandViews,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("EXPAND", true),
                    (TokenGenerator)new IdentifierGenerator("VIEWS")
                }
            },
            {
                OptimizerHintKind.ForceOrder,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("FORCE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Order)
                }
            },
            {
                OptimizerHintKind.HashGroup,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("HASH", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Group)
                }
            },
            {
                OptimizerHintKind.HashJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("HASH", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Join)
                }
            },
            {
                OptimizerHintKind.HashUnion,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("HASH", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union)
                }
            },
            {
                OptimizerHintKind.KeepFixedPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("KEEPFIXED", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.KeepPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("KEEP", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.KeepUnion,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("KEEP", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union)
                }
            },
            {
                OptimizerHintKind.LoopJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("LOOP", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Join)
                }
            },
            {
                OptimizerHintKind.MergeJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MERGE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Join)
                }
            },
            {
                OptimizerHintKind.MergeUnion,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MERGE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union)
                }
            },
            {
                OptimizerHintKind.OrderGroup,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Order, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Group)
                }
            },
            {
                OptimizerHintKind.RobustPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ROBUST", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.ShrinkDBPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SHRINKDB", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.ParameterizationSimple,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("PARAMETERIZATION", true),
                    (TokenGenerator)new IdentifierGenerator("SIMPLE")
                }
            },
            {
                OptimizerHintKind.ParameterizationForced,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("PARAMETERIZATION", true),
                    (TokenGenerator)new IdentifierGenerator("FORCED")
                }
            },
            {
                OptimizerHintKind.OptimizeCorrelatedUnionAll,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("OPTIMIZE", true),
                    (TokenGenerator)new IdentifierGenerator("CORRELATED", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Union, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.All)
                }
            },
            {
                OptimizerHintKind.Recompile,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("RECOMPILE")
                }
            },
            {
                OptimizerHintKind.Fast,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("FAST")
                }
            },
            {
                OptimizerHintKind.CheckConstraintsPlan,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("CHECKCONSTRAINTS", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plan)
                }
            },
            {
                OptimizerHintKind.MaxRecursion,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MAXRECURSION")
                }
            },
            {
                OptimizerHintKind.MaxDop,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MAXDOP")
                }
            },
            {
                OptimizerHintKind.IgnoreNonClusteredColumnStoreIndex,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("IGNORE_NONCLUSTERED_COLUMNSTORE_INDEX")
                }
            },
            {
                OptimizerHintKind.QueryTraceOn,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("QUERYTRACEON")
                }
            },
            {
                OptimizerHintKind.MaxGrantPercent,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MAX_GRANT_PERCENT", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                OptimizerHintKind.MinGrantPercent,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MIN_GRANT_PERCENT", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.EqualsSign)
                }
            },
            {
                OptimizerHintKind.NoPerformanceSpool,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("NO_PERFORMANCE_SPOOL")
                }
            }
        };

        private static Dictionary<PageVerifyDatabaseOptionKind, string> _pageVerifyDatabaseOptionKindNames = new Dictionary<PageVerifyDatabaseOptionKind, string>
        {
            {
                PageVerifyDatabaseOptionKind.Checksum,
                "CHECKSUM"
            },
            {
                PageVerifyDatabaseOptionKind.None,
                "NONE"
            },
            {
                PageVerifyDatabaseOptionKind.TornPageDetection,
                "TORN_PAGE_DETECTION"
            }
        };

        protected static Dictionary<ParameterlessCallType, TokenGenerator> _parameterlessCallTypeGenerators = new Dictionary<ParameterlessCallType, TokenGenerator>
        {
            {
                ParameterlessCallType.CurrentTimestamp,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.CurrentTimestamp)
            },
            {
                ParameterlessCallType.CurrentUser,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.CurrentUser)
            },
            {
                ParameterlessCallType.SessionUser,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.SessionUser)
            },
            {
                ParameterlessCallType.SystemUser,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.SystemUser)
            },
            {
                ParameterlessCallType.User,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.User)
            }
        };

        protected static Dictionary<PortTypes, TokenGenerator> _portTypesGenerators = new Dictionary<PortTypes, TokenGenerator>
        {
            {
                PortTypes.Clear,
                (TokenGenerator)new IdentifierGenerator("CLEAR")
            },
            {
                PortTypes.Ssl,
                (TokenGenerator)new IdentifierGenerator("SSL")
            }
        };

        protected static Dictionary<SetOptions, TokenGenerator> _setOptionsGenerators = new Dictionary<SetOptions, TokenGenerator>
        {
            {
                SetOptions.AnsiDefaults,
                (TokenGenerator)new IdentifierGenerator("ANSI_DEFAULTS")
            },
            {
                SetOptions.AnsiNullDfltOff,
                (TokenGenerator)new IdentifierGenerator("ANSI_NULL_DFLT_OFF")
            },
            {
                SetOptions.AnsiNullDfltOn,
                (TokenGenerator)new IdentifierGenerator("ANSI_NULL_DFLT_ON")
            },
            {
                SetOptions.AnsiNulls,
                (TokenGenerator)new IdentifierGenerator("ANSI_NULLS")
            },
            {
                SetOptions.AnsiPadding,
                (TokenGenerator)new IdentifierGenerator("ANSI_PADDING")
            },
            {
                SetOptions.AnsiWarnings,
                (TokenGenerator)new IdentifierGenerator("ANSI_WARNINGS")
            },
            {
                SetOptions.ArithAbort,
                (TokenGenerator)new IdentifierGenerator("ARITHABORT")
            },
            {
                SetOptions.ArithIgnore,
                (TokenGenerator)new IdentifierGenerator("ARITHIGNORE")
            },
            {
                SetOptions.ConcatNullYieldsNull,
                (TokenGenerator)new IdentifierGenerator("CONCAT_NULL_YIELDS_NULL")
            },
            {
                SetOptions.CursorCloseOnCommit,
                (TokenGenerator)new IdentifierGenerator("CURSOR_CLOSE_ON_COMMIT")
            },
            {
                SetOptions.DisableDefCnstChk,
                (TokenGenerator)new IdentifierGenerator("DISABLE_DEF_CNST_CHK")
            },
            {
                SetOptions.FmtOnly,
                (TokenGenerator)new IdentifierGenerator("FMTONLY")
            },
            {
                SetOptions.ForcePlan,
                (TokenGenerator)new IdentifierGenerator("FORCEPLAN")
            },
            {
                SetOptions.ImplicitTransactions,
                (TokenGenerator)new IdentifierGenerator("IMPLICIT_TRANSACTIONS")
            },
            {
                SetOptions.NoCount,
                (TokenGenerator)new IdentifierGenerator("NOCOUNT")
            },
            {
                SetOptions.NoExec,
                (TokenGenerator)new IdentifierGenerator("NOEXEC")
            },
            {
                SetOptions.NumericRoundAbort,
                (TokenGenerator)new IdentifierGenerator("NUMERIC_ROUNDABORT")
            },
            {
                SetOptions.ParseOnly,
                (TokenGenerator)new IdentifierGenerator("PARSEONLY")
            },
            {
                SetOptions.QuotedIdentifier,
                (TokenGenerator)new IdentifierGenerator("QUOTED_IDENTIFIER")
            },
            {
                SetOptions.RemoteProcTransactions,
                (TokenGenerator)new IdentifierGenerator("REMOTE_PROC_TRANSACTIONS")
            },
            {
                SetOptions.ShowPlanAll,
                (TokenGenerator)new IdentifierGenerator("SHOWPLAN_ALL")
            },
            {
                SetOptions.ShowPlanText,
                (TokenGenerator)new IdentifierGenerator("SHOWPLAN_TEXT")
            },
            {
                SetOptions.ShowPlanXml,
                (TokenGenerator)new IdentifierGenerator("SHOWPLAN_XML")
            },
            {
                SetOptions.XactAbort,
                (TokenGenerator)new IdentifierGenerator("XACT_ABORT")
            },
            {
                SetOptions.NoBrowsetable,
                (TokenGenerator)new IdentifierGenerator("NO_BROWSETABLE")
            }
        };

        private static Dictionary<PrivilegeType80, TokenGenerator> _privilegeType80Generators = new Dictionary<PrivilegeType80, TokenGenerator>
        {
            {
                PrivilegeType80.All,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.All)
            },
            {
                PrivilegeType80.Delete,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Delete)
            },
            {
                PrivilegeType80.Execute,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Execute)
            },
            {
                PrivilegeType80.Insert,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Insert)
            },
            {
                PrivilegeType80.References,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.References)
            },
            {
                PrivilegeType80.Select,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Select)
            },
            {
                PrivilegeType80.Update,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Update)
            }
        };

        protected static Dictionary<QualifiedJoinType, List<TokenGenerator>> _qualifiedJoinTypeGenerators = new Dictionary<QualifiedJoinType, List<TokenGenerator>>
        {
            {
                QualifiedJoinType.FullOuter,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Full, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Outer)
                }
            },
            {
                QualifiedJoinType.Inner,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Inner)
                }
            },
            {
                QualifiedJoinType.LeftOuter,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Left, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Outer)
                }
            },
            {
                QualifiedJoinType.RightOuter,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Right, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Outer)
                }
            }
        };

        protected static Dictionary<QueryStoreCapturePolicyOptionKind, string> _captureModeOptionNames = new Dictionary<QueryStoreCapturePolicyOptionKind, string>
        {
            {
                QueryStoreCapturePolicyOptionKind.NONE,
                "NONE"
            },
            {
                QueryStoreCapturePolicyOptionKind.AUTO,
                "AUTO"
            },
            {
                QueryStoreCapturePolicyOptionKind.ALL,
                "ALL"
            }
        };

        protected static Dictionary<QueryStoreSizeCleanupPolicyOptionKind, string> _sizeBasedCleanupOptionNames = new Dictionary<QueryStoreSizeCleanupPolicyOptionKind, string>
        {
            {
                QueryStoreSizeCleanupPolicyOptionKind.OFF,
                "OFF"
            },
            {
                QueryStoreSizeCleanupPolicyOptionKind.AUTO,
                "AUTO"
            }
        };

        private static Dictionary<QueueOptionKind, string> _queueOptionTypeNames = new Dictionary<QueueOptionKind, string>
        {
            {
                QueueOptionKind.ActivationDrop,
                "DROP"
            },
            {
                QueueOptionKind.ActivationMaxQueueReaders,
                "MAX_QUEUE_READERS"
            },
            {
                QueueOptionKind.ActivationProcedureName,
                "PROCEDURE_NAME"
            },
            {
                QueueOptionKind.ActivationStatus,
                "STATUS"
            },
            {
                QueueOptionKind.Retention,
                "RETENTION"
            },
            {
                QueueOptionKind.Status,
                "STATUS"
            }
        };

        protected static Dictionary<RaiseErrorOptions, TokenGenerator> _raiseErrorOptionsGenerators = new Dictionary<RaiseErrorOptions, TokenGenerator>
        {
            {
                RaiseErrorOptions.Log,
                (TokenGenerator)new IdentifierGenerator("LOG")
            },
            {
                RaiseErrorOptions.NoWait,
                (TokenGenerator)new IdentifierGenerator("NOWAIT")
            },
            {
                RaiseErrorOptions.SetError,
                (TokenGenerator)new IdentifierGenerator("SETERROR")
            }
        };

        private static Dictionary<RecoveryDatabaseOptionKind, TokenGenerator> _recoveryDatabaseOptionKindNames = new Dictionary<RecoveryDatabaseOptionKind, TokenGenerator>
        {
            {
                RecoveryDatabaseOptionKind.Full,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Full)
            },
            {
                RecoveryDatabaseOptionKind.BulkLogged,
                (TokenGenerator)new IdentifierGenerator("BULK_LOGGED")
            },
            {
                RecoveryDatabaseOptionKind.Simple,
                (TokenGenerator)new IdentifierGenerator("SIMPLE")
            }
        };

        protected static Dictionary<RestoreOptionKind, TokenGenerator> _restoreOptionKindGenerators = new Dictionary<RestoreOptionKind, TokenGenerator>
        {
            {
                RestoreOptionKind.BlockSize,
                (TokenGenerator)new IdentifierGenerator("BLOCKSIZE")
            },
            {
                RestoreOptionKind.BufferCount,
                (TokenGenerator)new IdentifierGenerator("BUFFERCOUNT")
            },
            {
                RestoreOptionKind.Checksum,
                (TokenGenerator)new IdentifierGenerator("CHECKSUM")
            },
            {
                RestoreOptionKind.CommitDifferentialBase,
                (TokenGenerator)new IdentifierGenerator("COMMIT_DIFFERENTIAL_BASE")
            },
            {
                RestoreOptionKind.ContinueAfterError,
                (TokenGenerator)new IdentifierGenerator("CONTINUE_AFTER_ERROR")
            },
            {
                RestoreOptionKind.DboOnly,
                (TokenGenerator)new IdentifierGenerator("DBO_ONLY")
            },
            {
                RestoreOptionKind.EnableBroker,
                (TokenGenerator)new IdentifierGenerator("ENABLE_BROKER")
            },
            {
                RestoreOptionKind.EnhancedIntegrity,
                (TokenGenerator)new IdentifierGenerator("ENHANCEDINTEGRITY")
            },
            {
                RestoreOptionKind.ErrorBrokerConversations,
                (TokenGenerator)new IdentifierGenerator("ERROR_BROKER_CONVERSATIONS")
            },
            {
                RestoreOptionKind.File,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.File)
            },
            {
                RestoreOptionKind.KeepReplication,
                (TokenGenerator)new IdentifierGenerator("KEEP_REPLICATION")
            },
            {
                RestoreOptionKind.KeepTemporalRetention,
                (TokenGenerator)new IdentifierGenerator("KEEP_TEMPORAL_RETENTION")
            },
            {
                RestoreOptionKind.LoadHistory,
                (TokenGenerator)new IdentifierGenerator("LOADHISTORY")
            },
            {
                RestoreOptionKind.MaxTransferSize,
                (TokenGenerator)new IdentifierGenerator("MAXTRANSFERSIZE")
            },
            {
                RestoreOptionKind.MediaName,
                (TokenGenerator)new IdentifierGenerator("MEDIANAME")
            },
            {
                RestoreOptionKind.MediaPassword,
                (TokenGenerator)new IdentifierGenerator("MEDIAPASSWORD")
            },
            {
                RestoreOptionKind.NewBroker,
                (TokenGenerator)new IdentifierGenerator("NEW_BROKER")
            },
            {
                RestoreOptionKind.NoChecksum,
                (TokenGenerator)new IdentifierGenerator("NO_CHECKSUM")
            },
            {
                RestoreOptionKind.NoLog,
                (TokenGenerator)new IdentifierGenerator("NO_LOG")
            },
            {
                RestoreOptionKind.NoRecovery,
                (TokenGenerator)new IdentifierGenerator("NORECOVERY")
            },
            {
                RestoreOptionKind.NoRewind,
                (TokenGenerator)new IdentifierGenerator("NOREWIND")
            },
            {
                RestoreOptionKind.NoUnload,
                (TokenGenerator)new IdentifierGenerator("NOUNLOAD")
            },
            {
                RestoreOptionKind.Online,
                (TokenGenerator)new IdentifierGenerator("ONLINE")
            },
            {
                RestoreOptionKind.Partial,
                (TokenGenerator)new IdentifierGenerator("PARTIAL")
            },
            {
                RestoreOptionKind.Password,
                (TokenGenerator)new IdentifierGenerator("PASSWORD")
            },
            {
                RestoreOptionKind.Recovery,
                (TokenGenerator)new IdentifierGenerator("RECOVERY")
            },
            {
                RestoreOptionKind.Replace,
                (TokenGenerator)new IdentifierGenerator("REPLACE")
            },
            {
                RestoreOptionKind.Restart,
                (TokenGenerator)new IdentifierGenerator("RESTART")
            },
            {
                RestoreOptionKind.RestrictedUser,
                (TokenGenerator)new IdentifierGenerator("RESTRICTED_USER")
            },
            {
                RestoreOptionKind.Rewind,
                (TokenGenerator)new IdentifierGenerator("REWIND")
            },
            {
                RestoreOptionKind.Snapshot,
                (TokenGenerator)new IdentifierGenerator("SNAPSHOT")
            },
            {
                RestoreOptionKind.SnapshotImport,
                (TokenGenerator)new IdentifierGenerator("SNAPSHOT_IMPORT")
            },
            {
                RestoreOptionKind.SnapshotRestorePhase,
                (TokenGenerator)new IdentifierGenerator("SNAPSHOTRESTOREPHASE")
            },
            {
                RestoreOptionKind.Standby,
                (TokenGenerator)new IdentifierGenerator("STANDBY")
            },
            {
                RestoreOptionKind.Stats,
                (TokenGenerator)new IdentifierGenerator("STATS")
            },
            {
                RestoreOptionKind.StopAt,
                (TokenGenerator)new IdentifierGenerator("STOPAT")
            },
            {
                RestoreOptionKind.StopOnError,
                (TokenGenerator)new IdentifierGenerator("STOP_ON_ERROR")
            },
            {
                RestoreOptionKind.Unload,
                (TokenGenerator)new IdentifierGenerator("UNLOAD")
            },
            {
                RestoreOptionKind.Verbose,
                (TokenGenerator)new IdentifierGenerator("VERBOSE")
            }
        };

        private static Dictionary<RestoreStatementKind, TokenGenerator> _restoreStatementKindGenerators = new Dictionary<RestoreStatementKind, TokenGenerator>
        {
            {
                RestoreStatementKind.None,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                RestoreStatementKind.FileListOnly,
                (TokenGenerator)new IdentifierGenerator("FILELISTONLY")
            },
            {
                RestoreStatementKind.HeaderOnly,
                (TokenGenerator)new IdentifierGenerator("HEADERONLY")
            },
            {
                RestoreStatementKind.LabelOnly,
                (TokenGenerator)new IdentifierGenerator("LABELONLY")
            },
            {
                RestoreStatementKind.RewindOnly,
                (TokenGenerator)new IdentifierGenerator("REWINDONLY")
            },
            {
                RestoreStatementKind.VerifyOnly,
                (TokenGenerator)new IdentifierGenerator("VERIFYONLY")
            }
        };

        protected static Dictionary<DatabaseMirroringEndpointRole, TokenGenerator> _databaseMirroringEndpointRoleGenerators = new Dictionary<DatabaseMirroringEndpointRole, TokenGenerator>
        {
            {
                DatabaseMirroringEndpointRole.NotSpecified,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                DatabaseMirroringEndpointRole.All,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.All)
            },
            {
                DatabaseMirroringEndpointRole.Partner,
                (TokenGenerator)new IdentifierGenerator("PARTNER")
            },
            {
                DatabaseMirroringEndpointRole.Witness,
                (TokenGenerator)new IdentifierGenerator("WITNESS")
            }
        };

        private static Dictionary<RouteOptionKind, string> _RouteOptionTypeNames = new Dictionary<RouteOptionKind, string>
        {
            {
                RouteOptionKind.Address,
                "ADDRESS"
            },
            {
                RouteOptionKind.BrokerInstance,
                "BROKER_INSTANCE"
            },
            {
                RouteOptionKind.Lifetime,
                "LIFETIME"
            },
            {
                RouteOptionKind.MirrorAddress,
                "MIRROR_ADDRESS"
            },
            {
                RouteOptionKind.ServiceName,
                "SERVICE_NAME"
            }
        };

        protected static Dictionary<SecurityObjectKind, List<TokenGenerator>> _securityObjectKindGenerators = new Dictionary<SecurityObjectKind, List<TokenGenerator>>
        {
            {
                SecurityObjectKind.AvailabilityGroup,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("AVAILABILITY", true),
                    (TokenGenerator)new IdentifierGenerator("GROUP")
                }
            },
            {
                SecurityObjectKind.ApplicationRole,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("APPLICATION", true),
                    (TokenGenerator)new IdentifierGenerator("ROLE")
                }
            },
            {
                SecurityObjectKind.Assembly,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ASSEMBLY")
                }
            },
            {
                SecurityObjectKind.AsymmetricKey,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ASYMMETRIC", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Key)
                }
            },
            {
                SecurityObjectKind.Certificate,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("CERTIFICATE")
                }
            },
            {
                SecurityObjectKind.Contract,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("CONTRACT")
                }
            },
            {
                SecurityObjectKind.Database,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Database)
                }
            },
            {
                SecurityObjectKind.Endpoint,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ENDPOINT")
                }
            },
            {
                SecurityObjectKind.FullTextCatalog,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("FULLTEXT", true),
                    (TokenGenerator)new IdentifierGenerator("CATALOG")
                }
            },
            {
                SecurityObjectKind.Login,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("LOGIN")
                }
            },
            {
                SecurityObjectKind.MessageType,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("MESSAGE", true),
                    (TokenGenerator)new IdentifierGenerator("TYPE")
                }
            },
            {
                SecurityObjectKind.Object,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("OBJECT")
                }
            },
            {
                SecurityObjectKind.RemoteServiceBinding,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("REMOTE", true),
                    (TokenGenerator)new IdentifierGenerator("SERVICE", true),
                    (TokenGenerator)new IdentifierGenerator("BINDING")
                }
            },
            {
                SecurityObjectKind.Role,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ROLE")
                }
            },
            {
                SecurityObjectKind.Route,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ROUTE")
                }
            },
            {
                SecurityObjectKind.Schema,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Schema)
                }
            },
            {
                SecurityObjectKind.Server,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SERVER")
                }
            },
            {
                SecurityObjectKind.ServerRole,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SERVER", true),
                    (TokenGenerator)new IdentifierGenerator("ROLE")
                }
            },
            {
                SecurityObjectKind.Service,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SERVICE")
                }
            },
            {
                SecurityObjectKind.SymmetricKey,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SYMMETRIC", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Key)
                }
            },
            {
                SecurityObjectKind.Type,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("TYPE")
                }
            },
            {
                SecurityObjectKind.User,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.User)
                }
            },
            {
                SecurityObjectKind.XmlSchemaCollection,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("XML", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Schema, true),
                    (TokenGenerator)new IdentifierGenerator("COLLECTION")
                }
            },
            {
                SecurityObjectKind.FullTextStopList,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("FULLTEXT", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.StopList)
                }
            },
            {
                SecurityObjectKind.SearchPropertyList,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SEARCH", true),
                    (TokenGenerator)new IdentifierGenerator("PROPERTY", true),
                    (TokenGenerator)new IdentifierGenerator("LIST")
                }
            }
        };

        private static Dictionary<AssignmentKind, TSqlTokenType> _assignmentKindSymbols = new Dictionary<AssignmentKind, TSqlTokenType>
        {
            {
                AssignmentKind.Equals,
                TSqlTokenType.EqualsSign
            },
            {
                AssignmentKind.AddEquals,
                TSqlTokenType.AddEquals
            },
            {
                AssignmentKind.SubtractEquals,
                TSqlTokenType.SubtractEquals
            },
            {
                AssignmentKind.MultiplyEquals,
                TSqlTokenType.MultiplyEquals
            },
            {
                AssignmentKind.DivideEquals,
                TSqlTokenType.DivideEquals
            },
            {
                AssignmentKind.ModEquals,
                TSqlTokenType.ModEquals
            },
            {
                AssignmentKind.BitwiseAndEquals,
                TSqlTokenType.BitwiseAndEquals
            },
            {
                AssignmentKind.BitwiseOrEquals,
                TSqlTokenType.BitwiseOrEquals
            },
            {
                AssignmentKind.BitwiseXorEquals,
                TSqlTokenType.BitwiseXorEquals
            }
        };

        protected static Dictionary<SetOffsets, TokenGenerator> _setOffsetsGenerators = new Dictionary<SetOffsets, TokenGenerator>
        {
            {
                SetOffsets.Compute,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Compute)
            },
            {
                SetOffsets.Execute,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Execute)
            },
            {
                SetOffsets.From,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.From)
            },
            {
                SetOffsets.Order,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Order)
            },
            {
                SetOffsets.Param,
                (TokenGenerator)new IdentifierGenerator("PARAM")
            },
            {
                SetOffsets.Procedure,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Procedure)
            },
            {
                SetOffsets.Select,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Select)
            },
            {
                SetOffsets.Statement,
                (TokenGenerator)new IdentifierGenerator("STATEMENT")
            },
            {
                SetOffsets.Table,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Table)
            }
        };

        protected static Dictionary<IsolationLevel, List<TokenGenerator>> _isolationLevelGenerators = new Dictionary<IsolationLevel, List<TokenGenerator>>
        {
            {
                IsolationLevel.ReadCommitted,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Read, true),
                    (TokenGenerator)new IdentifierGenerator("COMMITTED")
                }
            },
            {
                IsolationLevel.ReadUncommitted,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Read, true),
                    (TokenGenerator)new IdentifierGenerator("UNCOMMITTED")
                }
            },
            {
                IsolationLevel.RepeatableRead,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("REPEATABLE", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Read)
                }
            },
            {
                IsolationLevel.Serializable,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SERIALIZABLE")
                }
            },
            {
                IsolationLevel.Snapshot,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("SNAPSHOT")
                }
            }
        };

        protected static Dictionary<SoapMethodAction, TokenGenerator> _soapMethodActionGenerators = new Dictionary<SoapMethodAction, TokenGenerator>
        {
            {
                SoapMethodAction.None,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                SoapMethodAction.Add,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Add)
            },
            {
                SoapMethodAction.Alter,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Alter)
            },
            {
                SoapMethodAction.Drop,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Drop)
            }
        };

        protected static Dictionary<SoapMethodSchemas, TokenGenerator> _soapMethodSchemasGenerators = new Dictionary<SoapMethodSchemas, TokenGenerator>
        {
            {
                SoapMethodSchemas.Default,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Default)
            },
            {
                SoapMethodSchemas.None,
                (TokenGenerator)new IdentifierGenerator("NONE")
            },
            {
                SoapMethodSchemas.Standard,
                (TokenGenerator)new IdentifierGenerator("STANDARD")
            }
        };

        protected static Dictionary<SoapMethodFormat, string> _soapMethodFormatNames = new Dictionary<SoapMethodFormat, string>
        {
            {
                SoapMethodFormat.AllResults,
                "ALL_RESULTS"
            },
            {
                SoapMethodFormat.None,
                "NONE"
            },
            {
                SoapMethodFormat.RowsetsOnly,
                "ROWSETS_ONLY"
            }
        };

        protected static Dictionary<SqlDataTypeOption, TokenGenerator> _sqlDataTypeOptionGenerators = new Dictionary<SqlDataTypeOption, TokenGenerator>
        {
            {
                SqlDataTypeOption.BigInt,
                (TokenGenerator)new IdentifierGenerator("BIGINT")
            },
            {
                SqlDataTypeOption.Binary,
                (TokenGenerator)new IdentifierGenerator("BINARY")
            },
            {
                SqlDataTypeOption.Bit,
                (TokenGenerator)new IdentifierGenerator("BIT")
            },
            {
                SqlDataTypeOption.Char,
                (TokenGenerator)new IdentifierGenerator("CHAR")
            },
            {
                SqlDataTypeOption.Cursor,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Cursor)
            },
            {
                SqlDataTypeOption.DateTime,
                (TokenGenerator)new IdentifierGenerator("DATETIME")
            },
            {
                SqlDataTypeOption.Decimal,
                (TokenGenerator)new IdentifierGenerator("DECIMAL")
            },
            {
                SqlDataTypeOption.Float,
                (TokenGenerator)new IdentifierGenerator("FLOAT")
            },
            {
                SqlDataTypeOption.Image,
                (TokenGenerator)new IdentifierGenerator("IMAGE")
            },
            {
                SqlDataTypeOption.Int,
                (TokenGenerator)new IdentifierGenerator("INT")
            },
            {
                SqlDataTypeOption.Money,
                (TokenGenerator)new IdentifierGenerator("MONEY")
            },
            {
                SqlDataTypeOption.NChar,
                (TokenGenerator)new IdentifierGenerator("NCHAR")
            },
            {
                SqlDataTypeOption.NText,
                (TokenGenerator)new IdentifierGenerator("NTEXT")
            },
            {
                SqlDataTypeOption.NVarChar,
                (TokenGenerator)new IdentifierGenerator("NVARCHAR")
            },
            {
                SqlDataTypeOption.Numeric,
                (TokenGenerator)new IdentifierGenerator("NUMERIC")
            },
            {
                SqlDataTypeOption.Real,
                (TokenGenerator)new IdentifierGenerator("REAL")
            },
            {
                SqlDataTypeOption.SmallDateTime,
                (TokenGenerator)new IdentifierGenerator("SMALLDATETIME")
            },
            {
                SqlDataTypeOption.SmallInt,
                (TokenGenerator)new IdentifierGenerator("SMALLINT")
            },
            {
                SqlDataTypeOption.SmallMoney,
                (TokenGenerator)new IdentifierGenerator("SMALLMONEY")
            },
            {
                SqlDataTypeOption.Sql_Variant,
                (TokenGenerator)new IdentifierGenerator("SQL_VARIANT")
            },
            {
                SqlDataTypeOption.Table,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Table)
            },
            {
                SqlDataTypeOption.Text,
                (TokenGenerator)new IdentifierGenerator("TEXT")
            },
            {
                SqlDataTypeOption.Timestamp,
                (TokenGenerator)new IdentifierGenerator("TIMESTAMP")
            },
            {
                SqlDataTypeOption.TinyInt,
                (TokenGenerator)new IdentifierGenerator("TINYINT")
            },
            {
                SqlDataTypeOption.UniqueIdentifier,
                (TokenGenerator)new IdentifierGenerator("UNIQUEIDENTIFIER")
            },
            {
                SqlDataTypeOption.VarBinary,
                (TokenGenerator)new IdentifierGenerator("VARBINARY")
            },
            {
                SqlDataTypeOption.VarChar,
                (TokenGenerator)new IdentifierGenerator("VARCHAR")
            },
            {
                SqlDataTypeOption.Date,
                (TokenGenerator)new IdentifierGenerator("DATE")
            },
            {
                SqlDataTypeOption.Time,
                (TokenGenerator)new IdentifierGenerator("TIME")
            },
            {
                SqlDataTypeOption.DateTime2,
                (TokenGenerator)new IdentifierGenerator("DATETIME2")
            },
            {
                SqlDataTypeOption.DateTimeOffset,
                (TokenGenerator)new IdentifierGenerator("DATETIMEOFFSET")
            },
            {
                SqlDataTypeOption.Rowversion,
                (TokenGenerator)new IdentifierGenerator("ROWVERSION")
            }
        };

        protected static Dictionary<SubqueryComparisonPredicateType, TokenGenerator> _subqueryComparisonPredicateTypeGenerators = new Dictionary<SubqueryComparisonPredicateType, TokenGenerator>
        {
            {
                SubqueryComparisonPredicateType.All,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.All)
            },
            {
                SubqueryComparisonPredicateType.Any,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Any)
            }
        };

        protected static Dictionary<TableSampleClauseOption, TokenGenerator> _tableSampleClauseOptionGenerators = new Dictionary<TableSampleClauseOption, TokenGenerator>
        {
            {
                TableSampleClauseOption.NotSpecified,
                (TokenGenerator)new EmptyGenerator()
            },
            {
                TableSampleClauseOption.Percent,
                (TokenGenerator)new KeywordGenerator(TSqlTokenType.Percent)
            },
            {
                TableSampleClauseOption.Rows,
                (TokenGenerator)new IdentifierGenerator("ROWS")
            }
        };

        private static Dictionary<TriggerType, List<TokenGenerator>> _triggerTypeGenerators = new Dictionary<TriggerType, List<TokenGenerator>>
        {
            {
                TriggerType.After,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("AFTER")
                }
            },
            {
                TriggerType.For,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.For)
                }
            },
            {
                TriggerType.InsteadOf,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("INSTEAD", true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Of)
                }
            },
            {
                TriggerType.Unknown,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new EmptyGenerator()
                }
            }
        };

        protected static Dictionary<UnaryExpressionType, List<TokenGenerator>> _unaryExpressionTypeGenerators = new Dictionary<UnaryExpressionType, List<TokenGenerator>>
        {
            {
                UnaryExpressionType.BitwiseNot,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Tilde)
                }
            },
            {
                UnaryExpressionType.Negative,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Minus)
                }
            },
            {
                UnaryExpressionType.Positive,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Plus)
                }
            }
        };

        protected static Dictionary<UnqualifiedJoinType, List<TokenGenerator>> _unqualifiedJoinTypeGenerators = new Dictionary<UnqualifiedJoinType, List<TokenGenerator>>
        {
            {
                UnqualifiedJoinType.CrossApply,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Cross, true),
                    (TokenGenerator)new IdentifierGenerator("APPLY")
                }
            },
            {
                UnqualifiedJoinType.CrossJoin,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Cross, true),
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Join)
                }
            },
            {
                UnqualifiedJoinType.OuterApply,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new KeywordGenerator(TSqlTokenType.Outer, true),
                    (TokenGenerator)new IdentifierGenerator("APPLY")
                }
            }
        };

        protected static Dictionary<ViewOptionKind, string> _viewOptionTypeNames = new Dictionary<ViewOptionKind, string>
        {
            {
                ViewOptionKind.Encryption,
                "ENCRYPTION"
            },
            {
                ViewOptionKind.SchemaBinding,
                "SCHEMABINDING"
            },
            {
                ViewOptionKind.ViewMetadata,
                "VIEW_METADATA"
            }
        };

        protected static Dictionary<WaitForOption, TokenGenerator> _waitForOptionGenerators = new Dictionary<WaitForOption, TokenGenerator>
        {
            {
                WaitForOption.Delay,
                (TokenGenerator)new IdentifierGenerator("DELAY")
            },
            {
                WaitForOption.Time,
                (TokenGenerator)new IdentifierGenerator("TIME")
            }
        };

        protected static Dictionary<XmlDataTypeOption, TokenGenerator> _xmlDataTypeOptionGenerators = new Dictionary<XmlDataTypeOption, TokenGenerator>
        {
            {
                XmlDataTypeOption.Content,
                (TokenGenerator)new IdentifierGenerator("CONTENT")
            },
            {
                XmlDataTypeOption.Document,
                (TokenGenerator)new IdentifierGenerator("DOCUMENT")
            },
            {
                XmlDataTypeOption.None,
                (TokenGenerator)new EmptyGenerator()
            }
        };

        protected static Dictionary<XmlForClauseOptions, List<TokenGenerator>> _xmlForClauseOptionsGenerators = new Dictionary<XmlForClauseOptions, List<TokenGenerator>>
        {
            {
                XmlForClauseOptions.Raw,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("RAW")
                }
            },
            {
                XmlForClauseOptions.Auto,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("AUTO")
                }
            },
            {
                XmlForClauseOptions.Explicit,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("EXPLICIT")
                }
            },
            {
                XmlForClauseOptions.Path,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("PATH")
                }
            },
            {
                XmlForClauseOptions.XmlData,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("XMLDATA")
                }
            },
            {
                XmlForClauseOptions.XmlSchema,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("XMLSCHEMA")
                }
            },
            {
                XmlForClauseOptions.Elements,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ELEMENTS")
                }
            },
            {
                XmlForClauseOptions.ElementsXsiNil,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ELEMENTS", true),
                    (TokenGenerator)new IdentifierGenerator("XSINIL")
                }
            },
            {
                XmlForClauseOptions.ElementsAbsent,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ELEMENTS", true),
                    (TokenGenerator)new IdentifierGenerator("ABSENT")
                }
            },
            {
                XmlForClauseOptions.BinaryBase64,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("BINARY", true),
                    (TokenGenerator)new IdentifierGenerator("BASE64")
                }
            },
            {
                XmlForClauseOptions.Type,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("TYPE")
                }
            },
            {
                XmlForClauseOptions.Root,
                new List<TokenGenerator>
                {
                    (TokenGenerator)new IdentifierGenerator("ROOT")
                }
            }
        };

        internal abstract HashSet<Type> StatementsThatCannotHaveSemiColon {
            get;
        }

        public override void ExplicitVisit(GlobalFunctionTableReference node) {
            this.GenerateFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(AddFileSpec node) {
            this.GenerateFragmentIfNotNull(node.File);
            if (node.FileName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.FileName);
            }
        }

        public override void ExplicitVisit(AddSignatureStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Add);
            this.GenerateCounterSignature(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateModule(node);
            this.NewLineAndIndent();
            this.GenerateCryptos(node);
        }

        public override void ExplicitVisit(AdHocDataSource node) {
            this.GenerateKeyword(TSqlTokenType.OpenDataSource);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.ProviderName);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateFragmentIfNotNull(node.InitString);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(AdHocTableReference node) {
            this.GenerateFragmentIfNotNull(node.DataSource);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.Object);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(AlterApplicationRoleStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateApplicationRoleStatementBase(node);
        }

        public override void ExplicitVisit(AlterAssemblyStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "ASSEMBLY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.Parameters.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.From);
                this.GenerateSpaceAndFragmentIfNotNull(node.Parameters[0]);
            }
            this.GenerateAssemblyOptions(node.Options);
            if (node.IsDropAll || node.DropFiles.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateSpaceSeparatedTokens(TSqlTokenType.Drop, TSqlTokenType.File);
                if (node.IsDropAll) {
                    this.GenerateSpaceAndKeyword(TSqlTokenType.All);
                } else {
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.DropFiles);
                }
            }
            if (node.AddFiles.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateSpaceSeparatedTokens(TSqlTokenType.Add, TSqlTokenType.File, TSqlTokenType.From);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.AddFiles);
            }
        }

        internal void GenerateAssemblyOptions(IList<AssemblyOption> options) {
            if (options != null && options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateCommaSeparatedList(options);
            }
        }

        public override void ExplicitVisit(AssemblyOption node) {
            this.GenerateSpaceSeparatedTokens("UNCHECKED", "DATA");
        }

        public override void ExplicitVisit(PermissionSetAssemblyOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._permissionSetOptionNames, node.PermissionSetOption);
            this.GenerateNameEqualsValue("PERMISSION_SET", valueForEnumKey);
        }

        public override void ExplicitVisit(OnOffAssemblyOption node) {
            this.GenerateOptionStateWithEqualSign("VISIBILITY", node.OptionState);
        }

        public override void ExplicitVisit(AlterAuthorizationStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, TSqlTokenType.Authorization);
            this.NewLineAndIndent();
            this.GenerateFragmentIfNotNull(node.SecurityTargetObject);
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.To);
            if (node.ToSchemaOwner) {
                this.GenerateSpaceSeparatedTokens(TSqlTokenType.Schema, "OWNER");
            } else {
                this.GenerateFragmentIfNotNull(node.PrincipalName);
            }
        }

        public override void ExplicitVisit(AlterAvailabilityGroupStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateIdentifier("AVAILABILITY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            switch (node.AlterAvailabilityGroupStatementType) {
                case AlterAvailabilityGroupStatementType.Action:
                    this.GenerateSpaceAndFragmentIfNotNull(node.Action);
                    break;
                case AlterAvailabilityGroupStatementType.AddDatabase:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Add);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.Databases);
                    break;
                case AlterAvailabilityGroupStatementType.AddReplica:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Add);
                    this.GenerateSpaceAndIdentifier("REPLICA");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.Replicas);
                    break;
                case AlterAvailabilityGroupStatementType.ModifyReplica:
                    this.GenerateSpaceAndIdentifier("MODIFY");
                    this.GenerateSpaceAndIdentifier("REPLICA");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.Replicas);
                    break;
                case AlterAvailabilityGroupStatementType.RemoveDatabase:
                    this.GenerateSpaceAndIdentifier("REMOVE");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.Databases);
                    break;
                case AlterAvailabilityGroupStatementType.RemoveReplica:
                    this.GenerateSpaceAndIdentifier("REMOVE");
                    this.GenerateSpaceAndIdentifier("REPLICA");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.Replicas);
                    break;
                case AlterAvailabilityGroupStatementType.Set:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Set);
                    this.GenerateSpace();
                    this.GenerateParenthesisedCommaSeparatedList(node.Options);
                    break;
            }
        }

        public override void ExplicitVisit(AlterAvailabilityGroupAction node) {
            AlterAvailabilityGroupActionTypeHelper.Instance.GenerateSourceForOption(this._writer, node.ActionType);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node) {
            this.GenerateIdentifier("FAILOVER");
            if (node.Options != null && node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node) {
            this.GenerateNameEqualsValue("TARGET", node.Value);
        }

        public override void ExplicitVisit(AlterBrokerPriorityStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateBrokerPriorityStatementBody(node);
        }

        public override void ExplicitVisit(AlterCertificateStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "CERTIFICATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            switch (node.Kind) {
                case AlterCertificateStatementKind.RemoveAttestedOption:
                    this.GenerateRemoteAttestedOption();
                    break;
                case AlterCertificateStatementKind.RemovePrivateKey:
                    this.GenerateRemovePrivateKey();
                    break;
                case AlterCertificateStatementKind.WithActiveForBeginDialog:
                    this.GenerateKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndIdentifier("ACTIVE");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                    this.GenerateSpace();
                    this.GenerateOptionStateWithEqualSign("BEGIN_DIALOG", node.ActiveForBeginDialog);
                    break;
                case AlterCertificateStatementKind.AttestedBy:
                    this.GenerateAttestedBy(node.AttestedBy);
                    break;
                case AlterCertificateStatementKind.WithPrivateKey:
                    this.GenerateWithPrivateKey(node.PrivateKeyPath, node.EncryptionPassword, node.DecryptionPassword);
                    break;
            }
        }

        public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("COLUMN");
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndIdentifier("KEY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLine();
            if (node.AlterType == ColumnEncryptionKeyAlterType.Add) {
                this.GenerateKeyword(TSqlTokenType.Add);
                goto IL_0069;
            }
            if (node.AlterType == ColumnEncryptionKeyAlterType.Drop) {
                this.GenerateKeyword(TSqlTokenType.Drop);
                goto IL_0069;
            }
            throw new InvalidOperationException("ALTER COLUMN ENCRYPTION KEY statement can be used to either ADD or DROP a column encryption key value");
            IL_0069:
            this.GenerateSpaceAndIdentifier("VALUE");
            this.NewLine();
            this.GenerateCommaSeparatedList(node.ColumnEncryptionKeyValues, true);
        }

        protected void GenerateEndpointBody(AlterCreateEndpointStatementBase node) {
            if (node.State != 0) {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._endpointStateNames, node.State);
                if (valueForEnumKey != null) {
                    this.NewLineAndIndent();
                    this.GenerateNameEqualsValue("STATE", valueForEnumKey);
                }
            }
            if (node.Affinity != null) {
                if (node.State != 0) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                }
                this.NewLineAndIndent();
                this.GenerateFragmentIfNotNull(node.Affinity);
            }
            if (node.Protocol != 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                string valueForEnumKey2 = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._endpointProtocolNames, node.Protocol);
                if (valueForEnumKey2 != null) {
                    this.GenerateSpaceAndIdentifier(valueForEnumKey2);
                }
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.ProtocolOptions, 3);
            }
            if (node.EndpointType != 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.For);
                string valueForEnumKey3 = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._endpointTypeNames, node.EndpointType);
                if (valueForEnumKey3 != null) {
                    this.GenerateSpaceAndIdentifier(valueForEnumKey3);
                }
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.PayloadOptions, 3);
            }
        }

        public override void ExplicitVisit(AlterCredentialStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateCredentialStatementBody(node);
        }

        public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.Add);
            this.GenerateSpaceAndIdentifier("FILEGROUP");
            this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
            if (node.ContainsFileStream) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Contains);
                this.GenerateSpaceAndIdentifier("FILESTREAM");
            }
            if (node.ContainsMemoryOptimizedData) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Contains);
                this.GenerateSpaceAndIdentifier("MEMORY_OPTIMIZED_DATA");
            }
        }

        public override void ExplicitVisit(AlterDatabaseAddFileStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.Add);
            if (node.IsLog) {
                this.GenerateSpaceAndIdentifier("LOG");
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.File);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.FileDeclarations);
            if (node.FileGroup != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                this.GenerateSpaceAndIdentifier("FILEGROUP");
                this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
            }
        }

        public override void ExplicitVisit(AlterDatabaseCollateStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(GenericConfigurationOption node) {
            this.GenerateIdentifier(node.GenericOptionKind.Value);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
            ScalarExpression scalarExpression = node.GenericOptionState.ScalarExpression;
            if (scalarExpression != null && (scalarExpression is StringLiteral || scalarExpression is IntegerLiteral || scalarExpression is UnaryExpression)) {
                this.GenerateFragmentIfNotNull(node.GenericOptionState);
            } else {
                this.GenerateIdentifier(node.GenericOptionState.Identifier.Value);
            }
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateIdentifier("MODIFY");
            this.GenerateSpaceAndIdentifier("FILEGROUP");
            this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
            this.GenerateSpace();
            if (node.NewFileGroupName != null) {
                this.GenerateNameEqualsValue("NAME", node.NewFileGroupName);
            } else if (node.MakeDefault) {
                this.GenerateKeyword(TSqlTokenType.Default);
            } else if (node.UpdatabilityOption != 0) {
                ModifyFilegroupOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.UpdatabilityOption);
                this.GenerateSpaceAndFragmentIfNotNull(node.Termination);
            }
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateIdentifier("MODIFY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.File);
            this.GenerateSpaceAndFragmentIfNotNull(node.FileDeclaration);
        }

        public override void ExplicitVisit(AlterDatabaseModifyNameStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateIdentifier("MODIFY");
            this.GenerateSpace();
            this.GenerateNameEqualsValue("NAME", node.NewDatabaseName);
        }

        public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateIdentifier("REBUILD");
            this.GenerateSpaceAndIdentifier("LOG");
            if (node.FileDeclaration != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.FileDeclaration);
            }
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateIdentifier("REMOVE");
            this.GenerateSpaceAndIdentifier("FILEGROUP");
            this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            this.GenerateSpaceAndIdentifier("REMOVE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.File);
            this.GenerateSpaceAndFragmentIfNotNull(node.File);
        }

        public override void ExplicitVisit(AlterDatabaseSetStatement node) {
            this.GenerateAlterDbStatementHead(node);
            this.NewLineAndIndent();
            bool flag = true;
            foreach (DatabaseOption option in node.Options) {
                if (option.OptionKind != DatabaseOptionKind.MaxSize && option.OptionKind != DatabaseOptionKind.Edition && option.OptionKind != DatabaseOptionKind.ServiceObjective) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                this.GenerateIdentifier("MODIFY");
                this.GenerateSpace();
                AlignmentPoint ap = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateParenthesisedCommaSeparatedList(node.Options, true);
                this.PopAlignmentPoint();
            } else {
                this.GenerateKeyword(TSqlTokenType.Set);
                this.GenerateSpace();
                AlignmentPoint ap2 = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap2);
                this.GenerateCommaSeparatedList(node.Options, true);
                this.PopAlignmentPoint();
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Termination);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node) {
            this.GenerateAlterDatabaseScopedConfigHead(node);
            this.GenerateIdentifier("CLEAR");
            this.GenerateSpaceAndFragmentIfNotNull(node.Option);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node) {
            this.GenerateAlterDatabaseScopedConfigHead(node);
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndFragmentIfNotNull(node.Option);
        }

        protected void GenerateAlterDatabaseScopedConfigHead(AlterDatabaseScopedConfigurationStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, TSqlTokenType.Database);
            this.GenerateSpaceAndIdentifier("SCOPED");
            this.GenerateSpaceAndIdentifier("CONFIGURATION");
            this.GenerateSpace();
            if (node.Secondary) {
                this.GenerateIdentifier("FOR");
                this.GenerateSpaceAndIdentifier("SECONDARY");
                this.GenerateSpace();
            }
        }

        protected void GenerateAlterDbStatementHead(AlterDatabaseStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, TSqlTokenType.Database);
            if (node.UseCurrent) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Current);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            }
        }

        public override void ExplicitVisit(AlterDatabaseTermination node) {
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            if (node.ImmediateRollback) {
                this.GenerateKeyword(TSqlTokenType.Rollback);
                this.GenerateSpaceAndIdentifier("IMMEDIATE");
            } else if (node.RollbackAfter != null) {
                this.GenerateKeyword(TSqlTokenType.Rollback);
                this.GenerateSpaceAndIdentifier("AFTER");
                this.GenerateSpaceAndFragmentIfNotNull(node.RollbackAfter);
                this.GenerateSpaceAndIdentifier("SECONDS");
            } else if (node.NoWait) {
                this.GenerateIdentifier("NO_WAIT");
            }
        }

        public override void ExplicitVisit(AlterEndpointStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("ENDPOINT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            this.GenerateEndpointBody(node);
        }

        public override void ExplicitVisit(AlterExternalDataSourceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("DATA");
            this.GenerateSpaceAndIdentifier("SOURCE");
            this.GenerateAlterExternalDataSourceStatementBody(node);
        }

        protected void GenerateAlterExternalDataSourceStatementBody(ExternalDataSourceStatement node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.Set);
            if (node.Location != null) {
                this.GenerateNameEqualsValue("LOCATION", node.Location);
            }
            this.GenerateAlterExternalDataSourceOptions(node);
        }

        private void GenerateAlterExternalDataSourceOptions(ExternalDataSourceStatement node) {
            if (node.ExternalDataSourceOptions.Count > 0) {
                if (node.Location != null) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                }
                this.GenerateCommaSeparatedList(node.ExternalDataSourceOptions);
            }
        }

        public override void ExplicitVisit(AlterExternalResourcePoolStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateExternalResourcePoolStatementBody(node);
        }

        public override void ExplicitVisit(AlterFederationStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateIdentifier("FEDERATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            switch (node.Kind) {
                case AlterFederationKind.Split:
                    this.GenerateSpaceAndIdentifier("SPLIT");
                    this.GenerateSpaceAndIdentifier("AT");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    break;
                case AlterFederationKind.DropLow:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Drop);
                    this.GenerateSpaceAndIdentifier("AT");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateIdentifier("LOW");
                    this.GenerateSpace();
                    break;
                case AlterFederationKind.DropHigh:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Drop);
                    this.GenerateSpaceAndIdentifier("AT");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateIdentifier("HIGH");
                    this.GenerateSpace();
                    break;
            }
            this.GenerateFragmentIfNotNull(node.DistributionName);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Boundary);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(AlterFullTextCatalogStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "FULLTEXT", "CATALOG");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            switch (node.Action) {
                case AlterFullTextCatalogAction.None:
                    break;
                case AlterFullTextCatalogAction.AsDefault:
                    this.GenerateSpaceSeparatedTokens(TSqlTokenType.As, TSqlTokenType.Default);
                    break;
                case AlterFullTextCatalogAction.Rebuild:
                    this.GenerateIdentifier("REBUILD");
                    if (node.Options != null && node.Options.Count > 0) {
                        this.GenerateSpace();
                        this.GenerateSymbolAndSpace(TSqlTokenType.With);
                        this.GenerateCommaSeparatedList(node.Options);
                    }
                    break;
                case AlterFullTextCatalogAction.Reorganize:
                    this.GenerateIdentifier("REORGANIZE");
                    break;
            }
        }

        public override void ExplicitVisit(AlterFullTextIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(SimpleAlterFullTextIndexAction node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._simpleAlterFulltextIndexActionKindActions, node.ActionKind);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Set);
            this.GenerateFragmentIfNotNull(node.StopListOption);
            this.GenerateWithNoPopulation(node.WithNoPopulation);
        }

        public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Set);
            this.GenerateFragmentIfNotNull(node.SearchPropertyListOption);
            this.GenerateWithNoPopulation(node.WithNoPopulation);
        }

        public override void ExplicitVisit(DropAlterFullTextIndexAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            this.GenerateWithNoPopulation(node.WithNoPopulation);
        }

        public override void ExplicitVisit(AddAlterFullTextIndexAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Add);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            this.GenerateWithNoPopulation(node.WithNoPopulation);
        }

        public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateKeywordAndSpace(TSqlTokenType.Column);
            this.GenerateFragmentIfNotNull(node.Column.Name);
            if (node.Column.StatisticalSemantics) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Add);
            } else {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Drop);
            }
            this.GenerateSpaceAndIdentifier("STATISTICAL_SEMANTICS");
            this.GenerateWithNoPopulation(node.WithNoPopulation);
        }

        protected void GenerateWithNoPopulation(bool withNoPopulation) {
            if (withNoPopulation) {
                this.GenerateSpace();
                this.GenerateSpaceSeparatedTokens(TSqlTokenType.With, "NO", "POPULATION");
            }
        }

        public override void ExplicitVisit(AlterFullTextStopListStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.StopList);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(AlterFunctionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateFunctionStatementBody(node);
        }

        public override void ExplicitVisit(AlterIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateSpace();
            if (node.AlterIndexType == AlterIndexType.Set) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Set);
                this.GenerateParenthesisedCommaSeparatedList(node.IndexOptions);
            } else if (node.AlterIndexType == AlterIndexType.UpdateSelectiveXmlPaths) {
                if (node.XmlNamespaces != null) {
                    this.NewLine();
                    this.GenerateKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndFragmentIfNotNull(node.XmlNamespaces);
                }
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.For);
                this.NewLine();
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                bool flag = true;
                foreach (SelectiveXmlIndexPromotedPath promotedPath in node.PromotedPaths) {
                    if (!flag) {
                        this.GenerateSymbol(TSqlTokenType.Comma);
                    }
                    this.NewLineAndIndent();
                    if (promotedPath.Path == null) {
                        this.GenerateSpaceAndIdentifier("REMOVE");
                        this.GenerateSpace();
                        this.GenerateSpaceAndFragmentIfNotNull(promotedPath.Name);
                    } else {
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Add);
                        this.GenerateSpace();
                        this.GenerateFragmentIfNotNull(promotedPath);
                    }
                    flag = false;
                }
                this.NewLine();
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                AlterIndexTypeHelper.Instance.GenerateSourceForOption(this._writer, node.AlterIndexType);
                this.GenerateSpaceAndFragmentIfNotNull(node.Partition);
                if (node.IndexOptions.Count > 0) {
                    this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    this.GenerateParenthesisedCommaSeparatedList(node.IndexOptions);
                }
            }
        }

        public override void ExplicitVisit(AlterLoginEnableDisableStatement node) {
            this.GenerateAlterLoginHeader(node);
            this.GenerateIdentifier(node.IsEnable ? "ENABLE" : "DISABLE");
        }

        public override void ExplicitVisit(AlterLoginOptionsStatement node) {
            this.GenerateAlterLoginHeader(node);
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateFragmentList(node.Options);
        }

        public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node) {
            this.GenerateAlterLoginHeader(node);
            this.GenerateKeywordAndSpace((TSqlTokenType)(node.IsAdd ? 4 : 54));
            this.GenerateIdentifier("CREDENTIAL");
            this.GenerateSpaceAndFragmentIfNotNull(node.CredentialName);
        }

        private void GenerateAlterLoginHeader(AlterLoginStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("LOGIN");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpace();
        }

        public override void ExplicitVisit(AlterMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpace();
            switch (node.Option) {
                case AlterMasterKeyOption.Regenerate:
                    this.GenerateRegenerateOption(node.Password);
                    break;
                case AlterMasterKeyOption.ForceRegenerate:
                    this.GenerateIdentifier("FORCE");
                    this.GenerateSpace();
                    this.GenerateRegenerateOption(node.Password);
                    break;
                case AlterMasterKeyOption.AddEncryptionByPassword:
                    this.GenerateKeywordAndSpace(TSqlTokenType.Add);
                    this.GenerateEncryptionByPassword(node.Password);
                    break;
                case AlterMasterKeyOption.DropEncryptionByPassword:
                    this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
                    this.GenerateEncryptionByPassword(node.Password);
                    break;
                case AlterMasterKeyOption.AddEncryptionByServiceMasterKey:
                    this.GenerateKeywordAndSpace(TSqlTokenType.Add);
                    this.GenerateEncyptionByServiceMasterKey();
                    break;
                case AlterMasterKeyOption.DropEncryptionByServiceMasterKey:
                    this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
                    this.GenerateEncyptionByServiceMasterKey();
                    break;
            }
        }

        private void GenerateRegenerateOption(Literal password) {
            this.GenerateIdentifier("REGENERATE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpace();
            this.GenerateNameEqualsValue("PASSWORD", password);
        }

        private void GenerateEncyptionByServiceMasterKey() {
            this.GenerateIdentifier("ENCRYPTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
        }

        public override void ExplicitVisit(AlterMessageTypeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("MESSAGE");
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateValidationMethod(node);
        }

        public override void ExplicitVisit(AlterPartitionFunctionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Function);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSymbolAndSpace(TSqlTokenType.LeftParenthesis);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.NewLineAndIndent();
            this.GenerateIdentifier(node.IsSplit ? "SPLIT" : "MERGE");
            if (node.Boundary != null) {
                this.GenerateSpaceAndIdentifier("RANGE");
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.Boundary);
            }
        }

        public override void ExplicitVisit(AlterPartitionSchemeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndIdentifier("SCHEME");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndIdentifier("NEXT");
            this.GenerateSpaceAndIdentifier("USED");
            this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
        }

        public override void ExplicitVisit(AlterProcedureStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateProcedureStatementBody(node);
        }

        public override void ExplicitVisit(AlterQueueStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("QUEUE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateQueueOptions(node.QueueOptions);
        }

        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "REMOTE", "SERVICE", "BINDING");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateBindingOptions(node.Options);
        }

        public override void ExplicitVisit(AlterResourceGovernorStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateIdentifier("RESOURCE");
            this.GenerateSpaceAndIdentifier("GOVERNOR");
            switch (node.Command) {
                case AlterResourceGovernorCommandType.Disable:
                    this.GenerateSpaceAndIdentifier("DISABLE");
                    break;
                case AlterResourceGovernorCommandType.Reconfigure:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Reconfigure);
                    break;
                case AlterResourceGovernorCommandType.ClassifierFunction:
                    this.GenerateResourceGovernorClassifierFunction(node);
                    break;
                case AlterResourceGovernorCommandType.ResetStatistics:
                    this.GenerateSpaceAndIdentifier("RESET");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Statistics);
                    break;
            }
        }

        public void GenerateResourceGovernorClassifierFunction(AlterResourceGovernorStatement node) {
            this.GenerateSpaceAndKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateIdentifier("CLASSIFIER_FUNCTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            if (node.ClassifierFunction != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.ClassifierFunction);
            } else {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Null);
            }
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(AlterResourcePoolStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateResourcePoolStatementBody(node);
        }

        public override void ExplicitVisit(RenameAlterRoleAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateNameEqualsValue("NAME", node.NewName);
        }

        public override void ExplicitVisit(AddMemberAlterRoleAction node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Add, "MEMBER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Member);
        }

        public override void ExplicitVisit(DropMemberAlterRoleAction node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Drop, "MEMBER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Member);
        }

        public override void ExplicitVisit(AlterRoleStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(AlterRouteStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "ROUTE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateRouteOptions(node);
        }

        public override void ExplicitVisit(AlterSchemaStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndIdentifier("TRANSFER");
            if (node.ObjectKind != 0) {
                this.GenerateSpace();
                this.GenerateSourceForSecurityObjectKind(node.ObjectKind);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.ObjectName);
        }

        public override void ExplicitVisit(AlterSearchPropertyListStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SEARCH", "PROPERTY", "LIST");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(AlterSequenceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("SEQUENCE");
            this.GenerateSequenceStatementBody(node);
        }

        public override void ExplicitVisit(AlterSecurityPolicyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("SECURITY");
            this.GenerateSpaceAndIdentifier("POLICY");
            this.GenerateSecurityPolicyStatementBody(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Set, "BUFFER", "POOL", "EXTENSION");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node) {
            this.GenerateFragmentIfNotNull(node.OptionValue);
            if (node.Suboptions.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Suboptions);
            }
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node) {
            AlterServerConfigurationBufferPoolExtensionOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node) {
            AlterServerConfigurationBufferPoolExtensionOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
            this.GenerateSpace();
            MemoryUnitsHelper.Instance.GenerateSourceForOption(this._writer, node.SizeUnit);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Set, "DIAGNOSTICS", "LOG");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node) {
            if (node.OptionKind == AlterServerConfigurationDiagnosticsLogOptionKind.OnOff) {
                this.GenerateFragmentIfNotNull(node.OptionValue);
            } else {
                AlterServerConfigurationDiagnosticsLogOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
            }
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) {
            AlterServerConfigurationDiagnosticsLogOptionKind optionKind = node.OptionKind;
            AlterServerConfigurationDiagnosticsLogOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
            if (node.SizeUnit != 0) {
                this.GenerateSpace();
                MemoryUnitsHelper.Instance.GenerateSourceForOption(this._writer, node.SizeUnit);
            }
        }

        public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Set, "FAILOVER", "CLUSTER", "PROPERTY");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node) {
            AlterServerConfigurationFailoverClusterPropertyOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Set, "HADR", "CLUSTER");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node) {
            AlterServerConfigurationHadrClusterOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            if (node.IsLocal) {
                this.GenerateSpaceAndIdentifier("LOCAL");
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
            }
        }

        public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Set, "SOFTNUMA");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node) {
            if (node.OptionKind == AlterServerConfigurationSoftNumaOptionKind.OnOff) {
                this.GenerateFragmentIfNotNull(node.OptionValue);
            }
        }

        public override void ExplicitVisit(AlterServerConfigurationStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "CONFIGURATION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndIdentifier("PROCESS");
            this.GenerateSpaceAndIdentifier("AFFINITY");
            switch (node.ProcessAffinity) {
                case ProcessAffinityType.CpuAuto:
                    this.GenerateSpaceAndIdentifier("CPU");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpaceAndIdentifier("AUTO");
                    break;
                case ProcessAffinityType.Cpu:
                    this.GenerateSpaceAndIdentifier("CPU");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.ProcessAffinityRanges);
                    break;
                case ProcessAffinityType.NumaNode:
                    this.GenerateSpaceAndIdentifier("NUMANODE");
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpace();
                    this.GenerateCommaSeparatedList(node.ProcessAffinityRanges);
                    break;
            }
        }

        public override void ExplicitVisit(ProcessAffinityRange node) {
            this.GenerateFragmentIfNotNull(node.From);
            if (node.To != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                this.GenerateSpaceAndFragmentIfNotNull(node.To);
            }
        }

        public override void ExplicitVisit(AlterServerRoleStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVER", "ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(AlterServiceMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpace();
            switch (node.Kind) {
                case AlterServiceMasterKeyOption.Regenerate:
                    this.GenerateIdentifier("REGENERATE");
                    break;
                case AlterServiceMasterKeyOption.ForceRegenerate:
                    this.GenerateIdentifier("FORCE");
                    this.GenerateSpaceAndIdentifier("REGENERATE");
                    break;
                case AlterServiceMasterKeyOption.WithNewAccount:
                    this.GenerateWithClause(node, "NEW_ACCOUNT", "NEW_PASSWORD");
                    break;
                case AlterServiceMasterKeyOption.WithOldAccount:
                    this.GenerateWithClause(node, "OLD_ACCOUNT", "OLD_PASSWORD");
                    break;
            }
        }

        private void GenerateWithClause(AlterServiceMasterKeyStatement node, string accountTitle, string passwordTitle) {
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateNameEqualsValue(accountTitle, node.Account);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateNameEqualsValue(passwordTitle, node.Password);
        }

        public override void ExplicitVisit(AlterServiceStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Alter, "SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.QueueName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndIdentifier("QUEUE");
                this.GenerateSpaceAndFragmentIfNotNull(node.QueueName);
            }
            if (node.ServiceContracts.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.ServiceContracts);
            }
        }

        public override void ExplicitVisit(AlterTableAddTableElementStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateAlterTableHead(node);
            if (node.ExistingRowsCheckEnforcement != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateConstraintEnforcement(node.ExistingRowsCheckEnforcement);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.Add);
            this.GenerateSpace();
            AlignmentPoint ap2 = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap2);
            this.GenerateCommaSeparatedList(node.Definition.ColumnDefinitions, true);
            if (node.Definition.ColumnDefinitions.Count > 0 && node.Definition.TableConstraints.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.NewLine();
            }
            if (node.Definition.TableConstraints.Count > 0) {
                this.GenerateCommaSeparatedList(node.Definition.TableConstraints, true);
            }
            if ((node.Definition.ColumnDefinitions.Count > 0 || node.Definition.TableConstraints.Count > 0) && node.Definition.SystemTimePeriod != null) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.NewLine();
            }
            if (node.Definition.SystemTimePeriod != null) {
                this.ExplicitVisit(node.Definition.SystemTimePeriod);
            }
            if (node.Definition.Indexes != null && node.Definition.Indexes.Count > 0) {
                this.GenerateCommaSeparatedList(node.Definition.Indexes, true);
            }
            this.PopAlignmentPoint();
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(AlterTableAlterColumnStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Column);
            this.GenerateSpaceAndFragmentIfNotNull(node.ColumnIdentifier);
            if (node.DataType != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
                this.GenerateSpaceAndCollation(node.Collation);
                if (node.GeneratedAlways.HasValue) {
                    this.GenerateGeneratedAlways(node.GeneratedAlways);
                }
                this.GenerateFragmentIfNotNull(node.StorageOptions);
                this.GenerateSpaceAndFragmentIfNotNull(node.Encryption);
                if (node.MaskingFunction != null) {
                    this.GenerateSpaceAndIdentifier("MASKED");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateKeyword(TSqlTokenType.Function);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpaceAndFragmentIfNotNull(node.MaskingFunction);
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
                if (node.IsHidden) {
                    this.GenerateSpaceAndIdentifier("HIDDEN");
                }
                switch (node.AlterTableAlterColumnOption) {
                    case AlterTableAlterColumnOption.Null:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Null);
                        break;
                    case AlterTableAlterColumnOption.NotNull:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Not);
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Null);
                        break;
                }
            } else {
                List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._alterTableAlterColumnOptionNames, node.AlterTableAlterColumnOption);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateTokenList(valueForEnumKey);
                    if (node.AlterTableAlterColumnOption == AlterTableAlterColumnOption.AddMaskingFunction) {
                        this.GenerateSpaceAndFragmentIfNotNull(node.MaskingFunction);
                        this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                    }
                }
            }
            if (node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(AlterTableAlterIndexStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.IndexIdentifier);
            this.GenerateSpace();
            if (node.AlterIndexType == AlterIndexType.Rebuild) {
                AlterIndexTypeHelper.Instance.GenerateSourceForOption(this._writer, node.AlterIndexType);
                this.GenerateIndexOptions(node.IndexOptions);
            }
        }

        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndIdentifier(node.IsEnable ? "ENABLE" : "DISABLE");
            this.GenerateSpaceAndIdentifier("CHANGE_TRACKING");
            if (node.TrackColumnsUpdated != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateOptionStateWithEqualSign("TRACK_COLUMNS_UPDATED", node.TrackColumnsUpdated);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(AlterTableConstraintModificationStatement node) {
            this.GenerateAlterTableHead(node);
            if (node.ExistingRowsCheckEnforcement != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateConstraintEnforcement(node.ExistingRowsCheckEnforcement);
            }
            this.GenerateSpace();
            this.GenerateConstraintEnforcement(node.ConstraintEnforcement);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Constraint);
            this.GenerateSpace();
            if (node.All) {
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                this.GenerateCommaSeparatedList(node.ConstraintNames);
            }
        }

        public override void ExplicitVisit(AlterTableDropTableElement node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._tableElementTypeGenerators, node.TableElementType);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            if (node.TableElementType != 0) {
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Name);
            if (node.DropClusteredConstraintOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.DropClusteredConstraintOptions);
            }
            if (node.TableElementType == TableElementType.Period) {
                this.GenerateIdentifier("FOR");
                this.GenerateSpaceAndIdentifier("SYSTEM_TIME");
            }
        }

        public override void ExplicitVisit(AlterTableDropTableElementStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Drop);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.AlterTableDropTableElements);
        }

        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndIdentifier(node.IsEnable ? "ENABLE" : "DISABLE");
            this.GenerateSpaceAndIdentifier("FILETABLE_NAMESPACE");
        }

        public override void ExplicitVisit(AlterTableRebuildStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndIdentifier("REBUILD");
            this.GenerateSpaceAndFragmentIfNotNull(node.Partition);
            if (node.IndexOptions.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.IndexOptions);
            }
        }

        public override void ExplicitVisit(AlterTableAlterPartitionStatement node) {
            this.GenerateAlterTableHead(node);
            if (node.IsSplit) {
                this.GenerateSpaceAndIdentifier("SPLIT");
            } else {
                this.GenerateSpaceAndIdentifier("MERGE");
            }
            this.GenerateSpaceAndIdentifier("RANGE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.BoundaryValue);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(AlterTableSetStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Set);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.Options);
        }

        protected void GenerateAlterTableHead(AlterTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
        }

        protected void GenerateConstraintEnforcement(ConstraintEnforcement enforcement) {
            switch (enforcement) {
                case ConstraintEnforcement.NotSpecified:
                    break;
                case ConstraintEnforcement.NoCheck:
                    this.GenerateKeyword(TSqlTokenType.NoCheck);
                    break;
                case ConstraintEnforcement.Check:
                    this.GenerateKeyword(TSqlTokenType.Check);
                    break;
            }
        }

        public override void ExplicitVisit(AlterTableSwitchStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpaceAndIdentifier("SWITCH");
            this.GenerateForPartitionIfNotNull(node.SourcePartitionNumber);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.TargetTable);
            this.GenerateForPartitionIfNotNull(node.TargetPartitionNumber);
            if (this._options.SqlVersion >= SqlVersion.Sql120 && node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        private void GenerateForPartitionIfNotNull(ScalarExpression expression) {
            if (expression != null) {
                this.GenerateSpaceAndIdentifier("PARTITION");
                this.GenerateSpaceAndFragmentIfNotNull(expression);
            }
        }

        public override void ExplicitVisit(AlterTableTriggerModificationStatement node) {
            this.GenerateAlterTableHead(node);
            this.GenerateSpace();
            this.GenerateTriggerEnforcement(node.TriggerEnforcement);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Trigger);
            this.GenerateSpace();
            if (node.All) {
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                this.GenerateCommaSeparatedList(node.TriggerNames);
            }
        }

        public override void ExplicitVisit(AlterTriggerStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpace();
            this.GenerateTriggerStatementBody(node);
        }

        public override void ExplicitVisit(AlterUserStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.User);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.UserOptions);
        }

        public override void ExplicitVisit(AlterViewStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpace();
            this.GenerateViewStatementBody(node);
        }

        public override void ExplicitVisit(AlterWorkloadGroupStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateWorkloadGroupStatementBody(node);
        }

        public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("XML");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            this.GenerateSpaceAndIdentifier("COLLECTION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Add);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(ApplicationRoleOption node) {
            ApplicationRoleOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        protected void GenerateApplicationRoleStatementBase(ApplicationRoleStatement node) {
            this.GenerateIdentifier("APPLICATION");
            this.GenerateSpaceAndIdentifier("ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.ApplicationRoleOptions);
        }

        public override void ExplicitVisit(AssemblyName node) {
            this.GenerateFragmentIfNotNull(node.Name);
            if (node.ClassName != null) {
                this.GenerateSymbol(TSqlTokenType.Dot);
                this.GenerateFragmentIfNotNull(node.ClassName);
            }
        }

        public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node) {
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndIdentifier("ASYMMETRIC");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndFragmentIfNotNull(node.Key);
            this.GenerateCredential(node.Credential);
        }

        public override void ExplicitVisit(CreateAsymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateAsymmetricKeyName(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            if (node.KeySource != null) {
                this.NewLineAndIndent();
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                this.GenerateSpaceAndFragmentIfNotNull(node.KeySource);
            }
            if (node.EncryptionAlgorithm != 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateTokenAndEqualSign("ALGORITHM");
                this.GenerateSpace();
                EncryptionAlgorithmsHelper.Instance.GenerateSourceForOption(this._writer, node.EncryptionAlgorithm);
            }
            if (node.Password != null) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("PASSWORD", node.Password);
            }
        }

        public override void ExplicitVisit(AlterAsymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateAsymmetricKeyName(node.Name);
            this.GenerateSpace();
            switch (node.Kind) {
                case AlterCertificateStatementKind.WithActiveForBeginDialog:
                    break;
                case AlterCertificateStatementKind.RemovePrivateKey:
                    this.GenerateRemovePrivateKey();
                    break;
                case AlterCertificateStatementKind.RemoveAttestedOption:
                    this.GenerateRemoteAttestedOption();
                    break;
                case AlterCertificateStatementKind.AttestedBy:
                    this.GenerateAttestedBy(node.AttestedBy);
                    break;
                case AlterCertificateStatementKind.WithPrivateKey:
                    this.GenerateWithPrivateKey(null, node.EncryptionPassword, node.DecryptionPassword);
                    break;
            }
        }

        public override void ExplicitVisit(DropAsymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateAsymmetricKeyName(node.Name);
            this.GenerateRemoveProviderKeyOpt(node.RemoveProviderKey);
        }

        private void GenerateRemoveProviderKeyOpt(bool generate) {
            if (generate) {
                this.GenerateSpaceAndIdentifier("REMOVE");
                this.GenerateSpaceAndIdentifier("PROVIDER");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            }
        }

        private void GenerateAsymmetricKeyName(Identifier name) {
            this.GenerateSpaceAndIdentifier("ASYMMETRIC");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndFragmentIfNotNull(name);
        }

        public override void ExplicitVisit(AtTimeZoneCall node) {
            this.GenerateFragmentIfNotNull(node.DateValue);
            this.GenerateSpaceAndIdentifier("AT");
            this.GenerateSpaceAndIdentifier("TIME");
            this.GenerateSpaceAndIdentifier("ZONE");
            this.GenerateSpaceAndFragmentIfNotNull(node.TimeZone);
        }

        public override void ExplicitVisit(AuditActionGroupReference node) {
            ServerAuditActionGroupHelper.Instance.GenerateSourceForOption(this._writer, node.Group);
        }

        public override void ExplicitVisit(AuditActionSpecification node) {
            this.GenerateCommaSeparatedList(node.Actions);
            this.GenerateSpaceAndFragmentIfNotNull(node.TargetObject);
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Principals);
        }

        public override void ExplicitVisit(AuditSpecificationPart node) {
            this.GenerateKeywordAndSpace((TSqlTokenType)(node.IsDrop ? 54 : 4));
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Details);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        protected void GenerateAuditSpecificationStatement(AuditSpecificationStatement node) {
            this.GenerateIdentifier("AUDIT");
            this.GenerateSpaceAndIdentifier("SPECIFICATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.SpecificationName);
            if (node.AuditName != null || node is CreateServerAuditSpecificationStatement || node is CreateDatabaseAuditSpecificationStatement) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndIdentifier("SERVER");
                this.GenerateSpaceAndIdentifier("AUDIT");
                this.GenerateSpaceAndFragmentIfNotNull(node.AuditName);
            }
            if (node.Parts.Count > 0) {
                this.NewLineAndIndent();
            }
            this.GenerateList(node.Parts, delegate {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.NewLineAndIndent();
            });
            if (node.AuditState != 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateOptionStateWithEqualSign("STATE", node.AuditState);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(AuditTarget node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.To);
            switch (node.TargetKind) {
                case AuditTargetKind.ApplicationLog:
                    this.GenerateIdentifier("APPLICATION_LOG");
                    break;
                case AuditTargetKind.SecurityLog:
                    this.GenerateIdentifier("SECURITY_LOG");
                    break;
                case AuditTargetKind.File:
                    this.GenerateKeywordAndSpace(TSqlTokenType.File);
                    this.GenerateParenthesisedCommaSeparatedList(node.TargetOptions);
                    break;
            }
        }

        public override void ExplicitVisit(MaxSizeAuditTargetOption node) {
            this.GenerateTokenAndEqualSign("MAXSIZE");
            if (node.IsUnlimited) {
                this.GenerateSpaceAndIdentifier("UNLIMITED");
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.Size);
                this.GenerateSpace();
                MemoryUnitsHelper.Instance.GenerateSourceForOption(this._writer, node.Unit);
            }
        }

        public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node) {
            this.GenerateTokenAndEqualSign("MAX_ROLLOVER_FILES");
            if (node.IsUnlimited) {
                this.GenerateSpaceAndIdentifier("UNLIMITED");
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(LiteralAuditTargetOption node) {
            switch (node.OptionKind) {
                case AuditTargetOptionKind.MaxFiles:
                    this.GenerateNameEqualsValue("MAX_FILES", node.Value);
                    break;
                case AuditTargetOptionKind.FilePath:
                    this.GenerateNameEqualsValue("FILEPATH", node.Value);
                    break;
            }
        }

        public override void ExplicitVisit(OnOffAuditTargetOption node) {
            this.GenerateOptionStateWithEqualSign("RESERVE_DISK_SPACE", node.Value);
        }

        public override void ExplicitVisit(AuthenticationEndpointProtocolOption node) {
            this.GenerateIdentifier("AUTHENTICATION");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateCommaSeparatedFlagOpitons(SqlScriptGeneratorVisitor._authenticationTypesGenerators, node.AuthenticationTypes);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(AuthenticationPayloadOption node) {
            this.GenerateTokenAndEqualSign("AUTHENTICATION");
            this.GenerateCertificateForAuthenticationPayloadOption(node.TryCertificateFirst, node.Certificate);
            if (node.Protocol != 0) {
                this.GenerateSpaceAndIdentifier("WINDOWS");
                if (node.Protocol != AuthenticationProtocol.Windows) {
                    string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._authenticationProtocolNames, node.Protocol);
                    if (valueForEnumKey != null) {
                        this.GenerateSpaceAndIdentifier(valueForEnumKey);
                    }
                }
            }
            this.GenerateCertificateForAuthenticationPayloadOption(!node.TryCertificateFirst, node.Certificate);
        }

        protected void GenerateCertificateForAuthenticationPayloadOption(bool generate, Identifier certificateName) {
            if (generate && certificateName != null) {
                this.GenerateSpaceAndIdentifier("CERTIFICATE");
                this.GenerateSpaceAndFragmentIfNotNull(certificateName);
            }
        }

        public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node) {
            this.GenerateIdentifier("AUTO_CLEANUP");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndKeyword((TSqlTokenType)(node.IsOn ? 105 : 103));
        }

        public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node) {
            OnOffSimpleDbOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            this.GenerateOptionStateOnOff(node.OptionState);
            if (node.HasIncremental) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateIdentifier("INCREMENTAL");
                this.GenerateSpace();
                this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
                this.GenerateOptionStateOnOff(node.IncrementalState);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(AutomaticTuningDatabaseOption node) {
            this.GenerateIdentifier("AUTOMATIC_TUNING");
            this.GenerateSpace();
            switch (node.AutomaticTuningState) {
                case AutomaticTuningState.Inherit:
                    this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                    this.GenerateIdentifier("INHERIT");
                    break;
                case AutomaticTuningState.Auto:
                    this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                    this.GenerateIdentifier("AUTO");
                    break;
                case AutomaticTuningState.Custom:
                    this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                    this.GenerateIdentifier("CUSTOM");
                    break;
                default:
                    this.GenerateParenthesisedCommaSeparatedList(node.Options);
                    break;
            }
        }

        public override void ExplicitVisit(AutomaticTuningCreateIndexOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optionNames, node.Value);
            this.GenerateNameEqualsValue("CREATE_INDEX", valueForEnumKey);
        }

        public override void ExplicitVisit(AutomaticTuningDropIndexOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optionNames, node.Value);
            this.GenerateNameEqualsValue("DROP_INDEX", valueForEnumKey);
        }

        public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optionNames, node.Value);
            this.GenerateNameEqualsValue("FORCE_LAST_GOOD_PLAN", valueForEnumKey);
        }

        public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optionNames, node.Value);
            this.GenerateNameEqualsValue("MAINTAIN_INDEX", valueForEnumKey);
        }

        public override void ExplicitVisit(AvailabilityReplica node) {
            this.GenerateFragmentIfNotNull(node.ServerName);
            if (node.Options != null && node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(AvailabilityModeReplicaOption node) {
            string value = (node.Value == AvailabilityModeOptionKind.AsynchronousCommit) ? "ASYNCHRONOUS_COMMIT" : "SYNCHRONOUS_COMMIT";
            this.GenerateNameEqualsValue("AVAILABILITY_MODE", value);
        }

        public override void ExplicitVisit(FailoverModeReplicaOption node) {
            string value = (node.Value == FailoverModeOptionKind.Automatic) ? "AUTOMATIC" : "MANUAL";
            this.GenerateNameEqualsValue("FAILOVER_MODE", value);
        }

        public override void ExplicitVisit(LiteralReplicaOption node) {
            AvailabilityReplicaOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(SecondaryRoleReplicaOption node) {
            this.GenerateIdentifier("SECONDARY_ROLE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateIdentifier("ALLOW_CONNECTIONS");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            AllowConnectionsOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.AllowConnections);
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(PrimaryRoleReplicaOption node) {
            this.GenerateIdentifier("PRIMARY_ROLE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateIdentifier("ALLOW_CONNECTIONS");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            AllowConnectionsOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.AllowConnections);
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(BackupCertificateStatement node) {
            this.GenerateKeyword(TSqlTokenType.Backup);
            this.GenerateSpaceAndIdentifier("CERTIFICATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateNameEqualsValue(TSqlTokenType.File, node.File);
            if (node.PrivateKeyPath == null && node.DecryptionPassword == null && node.EncryptionPassword == null) {
                return;
            }
            this.NewLineAndIndent();
            this.GenerateWithPrivateKey(node.PrivateKeyPath, node.EncryptionPassword, node.DecryptionPassword);
        }

        public override void ExplicitVisit(BackupDatabaseStatement node) {
            this.GenerateKeyword(TSqlTokenType.Backup);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            if (node.Files != null && node.Files.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateCommaSeparatedList(node.Files);
            }
            this.GenerateDeviceAndOption(node);
        }

        public override void ExplicitVisit(BackupOption node) {
            if (BackupOptionsWithValueHelper.Instance.TryGenerateSourceForOption(this._writer, node.OptionKind)) {
                if (node.Value != null) {
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpaceAndFragmentIfNotNull(node.Value);
                }
            } else {
                BackupOptionsNoValueHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            }
        }

        public override void ExplicitVisit(BackupEncryptionOption node) {
            if (this._options.SqlVersion >= SqlVersion.Sql120) {
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateIdentifier("ALGORITHM");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
                EncryptionAlgorithmsHelper.Instance.GenerateSourceForOption(this._writer, node.Algorithm);
                this.GenerateSymbol(TSqlTokenType.Comma);
                if (node.Encryptor != null) {
                    this.GenerateSpaceAndIdentifier("SERVER");
                    this.GenerateSpace();
                    switch (node.Encryptor.CryptoMechanismType) {
                        case CryptoMechanismType.Certificate:
                            this.GenerateIdentifier("CERTIFICATE");
                            break;
                        case CryptoMechanismType.AsymmetricKey:
                            this.GenerateIdentifier("ASYMMETRIC");
                            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                            break;
                    }
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpaceAndFragmentIfNotNull(node.Encryptor.Identifier);
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(BackupMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Backup);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateNameEqualsValue(TSqlTokenType.File, node.File);
            this.GenerateSpace();
            this.GenerateEncryptionByPassword(node.Password);
        }

        public override void ExplicitVisit(BackupRestoreFileInfo node) {
            switch (node.ItemKind) {
                case BackupRestoreItemKind.None:
                    break;
                case BackupRestoreItemKind.ReadWriteFileGroups:
                    this.GenerateIdentifier("READ_WRITE_FILEGROUPS");
                    break;
                case BackupRestoreItemKind.Page:
                    if (node.Items.Count == 1) {
                        this.GenerateIdentifier("PAGE");
                        this.GenerateSpace();
                        this.GenerateItems(node.Items);
                    }
                    break;
                case BackupRestoreItemKind.Files:
                    this.GenerateKeywordAndSpace(TSqlTokenType.File);
                    this.GenerateItems(node.Items);
                    break;
                case BackupRestoreItemKind.FileGroups:
                    this.GenerateIdentifier("FILEGROUP");
                    this.GenerateSpace();
                    this.GenerateItems(node.Items);
                    break;
            }
        }

        private void GenerateItems(IList<ValueExpression> items) {
            if (items != null) {
                this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                if (items.Count == 1) {
                    this.GenerateFragmentIfNotNull(items[0]);
                } else {
                    this.GenerateParenthesisedCommaSeparatedList(items);
                }
            }
        }

        protected void GenerateCommonRestorePart(BackupRestoreMasterKeyStatementBase node, bool isService) {
            this.GenerateKeyword(TSqlTokenType.Restore);
            if (isService) {
                this.GenerateSpaceAndIdentifier("SERVICE");
            }
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpace();
            this.GenerateNameEqualsValue(TSqlTokenType.File, node.File);
            this.GenerateSpace();
            this.GenerateDecryptionByPassword(node.Password);
        }

        public override void ExplicitVisit(BackupServiceMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Backup);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateNameEqualsValue(TSqlTokenType.File, node.File);
            this.GenerateSpace();
            this.GenerateEncryptionByPassword(node.Password);
        }

        protected void GenerateDeviceAndOption(BackupStatement node) {
            if (node.Devices.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.To);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Devices);
                if (node.MirrorToClauses != null) {
                    foreach (MirrorToClause mirrorToClause in node.MirrorToClauses) {
                        this.NewLineAndIndent();
                        this.GenerateFragmentIfNotNull(mirrorToClause);
                    }
                }
            }
            if (node.Options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(BackupTransactionLogStatement node) {
            this.GenerateKeyword(TSqlTokenType.Backup);
            this.GenerateSpaceAndIdentifier("LOG");
            this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            this.GenerateDeviceAndOption(node);
        }

        public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node) {
            this.GenerateFragmentIfNotNull(node.Index);
        }

        public override void ExplicitVisit(BeginConversationTimerStatement node) {
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            this.GenerateSpaceAndIdentifier("TIMER");
            this.GenerateSpace();
            this.GenerateParenthesisedFragmentIfNotNull(node.Handle);
            this.GenerateSpace();
            this.GenerateNameEqualsValue("TIMEOUT", node.Timeout);
        }

        public override void ExplicitVisit(BeginDialogStatement node) {
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.GenerateSpaceAndIdentifier("DIALOG");
            if (node.IsConversation) {
                this.GenerateSpaceAndIdentifier("CONVERSATION");
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Handle);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.InitiatorServiceName);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.TargetServiceName);
            if (node.InstanceSpec != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.InstanceSpec);
            }
            if (node.ContractName != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndIdentifier("CONTRACT");
                this.GenerateSpaceAndFragmentIfNotNull(node.ContractName);
            }
            this.GenerateDialogOptions(node.Options);
        }

        private void GenerateDialogOptions(IList<DialogOption> options) {
            if (options != null && options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateCommaSeparatedList(options);
            }
        }

        public override void ExplicitVisit(OnOffDialogOption node) {
            this.GenerateOptionStateWithEqualSign("ENCRYPTION", node.OptionState);
        }

        public override void ExplicitVisit(ScalarExpressionDialogOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._dialogOptionNames, node.OptionKind);
            this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
        }

        public override void ExplicitVisit(BeginEndBlockStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.StatementList);
            this.PopAlignmentPoint();
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.End);
        }

        public override void ExplicitVisit(BeginEndAtomicBlockStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.GenerateSpaceAndIdentifier("ATOMIC");
            this.GenerateCommaSeparatedWithClause(node.Options, false, true);
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.StatementList);
            this.PopAlignmentPoint();
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.End);
        }

        public override void ExplicitVisit(LiteralAtomicBlockOption node) {
            AtomicBlockOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(IdentifierAtomicBlockOption node) {
            if (node.Value != null) {
                AtomicBlockOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndIdentifier(node.Value.Value);
            }
        }

        public override void ExplicitVisit(OnOffAtomicBlockOption node) {
            this.GenerateOptionStateWithEqualSign("DELAYED_DURABILITY", node.OptionState);
        }

        public override void ExplicitVisit(BeginTransactionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Begin);
            if (node.Distributed) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Distributed);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Transaction);
            if (node.Name != null) {
                this.GenerateSpace();
                this.GenerateTransactionName(node.Name);
            }
            if (node.MarkDefined) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("MARK");
                this.GenerateSpaceAndFragmentIfNotNull(node.MarkDescription);
            }
        }

        public override void ExplicitVisit(BinaryExpression node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            this.GenerateSpace();
            this.GenerateBinaryOperator(node.BinaryExpressionType);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(BinaryQueryExpression node) {
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.GenerateBinaryQueryExpression(node, alignmentPointForFragment, null, null);
        }

        public void GenerateBinaryQueryExpression(BinaryQueryExpression node, AlignmentPoint clauseBody, SchemaObjectName intoClause, Identifier filegroupClause = null) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateQueryExpression(node.FirstQueryExpression, clauseBody, intoClause, filegroupClause);
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._binaryQueryExpressionTypeGenerators, node.BinaryQueryExpressionType);
            if (valueForEnumKey != null) {
                this.NewLine();
                this.GenerateToken(valueForEnumKey);
            }
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            }
            if (node.SecondQueryExpression != null) {
                this.NewLine();
                AlignmentPoint ap2 = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap2);
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.SecondQueryExpression, clauseBody);
                this.PopAlignmentPoint();
            }
            this.PopAlignmentPoint();
            if (node.OrderByClause != null) {
                this.GenerateSeparatorForOrderBy();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OrderByClause, clauseBody);
            }
            if (node.OffsetClause != null) {
                this.GenerateSeparatorForOffsetClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OffsetClause, clauseBody);
            }
            if (node.ForClause != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.For);
                this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
                this.GenerateSpace();
                AlignmentPoint ap3 = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap3);
                this.GenerateFragmentIfNotNull(node.ForClause);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(BooleanBinaryExpression node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            bool newline = this.RightPredicateOnNewline(node);
            this.GenerateNewLineOrSpace(newline);
            this.GenerateBinaryOperator(node.BinaryExpressionType);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            this.PopAlignmentPoint();
        }

        private bool RightPredicateOnNewline(BooleanBinaryExpression node) {
            return this._options.MultilineWherePredicatesList && this._options.NewLineBeforeWhereClause && (node.BinaryExpressionType == BooleanBinaryExpressionType.And || node.BinaryExpressionType == BooleanBinaryExpressionType.Or);
        }

        public override void ExplicitVisit(BooleanComparisonExpression node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            this.GenerateSpace();
            this.GenerateBinaryOperator(node.ComparisonType);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(BooleanIsNullExpression node) {
            this.GenerateFragmentIfNotNull(node.Expression);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.Is);
            if (node.IsNot) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Not);
            }
            this.GenerateKeyword(TSqlTokenType.Null);
        }

        public override void ExplicitVisit(BooleanNotExpression node) {
            this.GenerateToken(new KeywordGenerator(TSqlTokenType.Not));
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Expression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(BooleanTernaryExpression node) {
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._ternaryExpressionTypeGenerators, node.TernaryExpressionType);
            if (valueForEnumKey != null) {
                this.GenerateSpace();
                this.GenerateTokenList(valueForEnumKey);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            this.GenerateSpaceAndKeyword(TSqlTokenType.And);
            this.GenerateSpaceAndFragmentIfNotNull(node.ThirdExpression);
        }

        public override void ExplicitVisit(BreakStatement node) {
            this.GenerateKeyword(TSqlTokenType.Break);
        }

        public override void ExplicitVisit(BrokerPriorityParameter node) {
            BrokerPriorityParameterHelper.Instance.GenerateSourceForOption(this._writer, node.ParameterType);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            switch (node.IsDefaultOrAny) {
                case BrokerPriorityParameterSpecialType.None:
                    this.GenerateSpaceAndFragmentIfNotNull(node.ParameterValue);
                    break;
                case BrokerPriorityParameterSpecialType.Default:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
                    break;
                case BrokerPriorityParameterSpecialType.Any:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Any);
                    break;
            }
        }

        protected void GenerateBrokerPriorityStatementBody(BrokerPriorityStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateIdentifier("BROKER");
            this.GenerateSpaceAndIdentifier("PRIORITY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            if (node.BrokerPriorityParameters != null && node.BrokerPriorityParameters.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.Set);
                this.GenerateSpace();
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.BrokerPriorityParameters, 2);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(BrowseForClause node) {
            this.GenerateKeyword(TSqlTokenType.Browse);
        }

        public override void ExplicitVisit(BuiltInFunctionTableReference node) {
            this.GenerateSymbol(TSqlTokenType.DoubleColon);
            this.GenerateFragmentIfNotNull(node.Name);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        protected void GenerateOption(BulkInsertBase node) {
            if (node.Options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(OrderBulkInsertOption node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Order);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            if (node.IsUnique) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Unique);
            }
        }

        public override void ExplicitVisit(BulkInsertOption node) {
            if (!OpenRowsetBulkHintOptionsHelper.Instance.TryGenerateSourceForOption(this._writer, node.OptionKind)) {
                BulkInsertFlagOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            }
        }

        public override void ExplicitVisit(LiteralBulkInsertOption node) {
            if (BulkInsertIntOptionsHelper.Instance.TryGenerateSourceForOption(this._writer, node.OptionKind)) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
            } else if (BulkInsertStringOptionsHelper.Instance.TryGenerateSourceForOption(this._writer, node.OptionKind)) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(BulkInsertStatement node) {
            this.GenerateKeyword(TSqlTokenType.Bulk);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Insert);
            this.GenerateSpaceAndFragmentIfNotNull(node.To);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.From);
            this.GenerateOption(node);
        }

        public override void ExplicitVisit(BulkOpenRowset node) {
            this.GenerateKeyword(TSqlTokenType.OpenRowSet);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateKeyword(TSqlTokenType.Bulk);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataFile);
            if (node.Options.Count > 0) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Options);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(ExpressionCallTarget node) {
            this.GenerateFragmentIfNotNull(node.Expression);
            this.GenerateSymbol(TSqlTokenType.Dot);
        }

        public override void ExplicitVisit(MultiPartIdentifierCallTarget node) {
            this.GenerateFragmentIfNotNull(node.MultiPartIdentifier);
            this.GenerateSymbol(TSqlTokenType.Dot);
        }

        public override void ExplicitVisit(UserDefinedTypeCallTarget node) {
            this.GenerateFragmentIfNotNull(node.SchemaObjectName);
            this.GenerateSymbol(TSqlTokenType.DoubleColon);
        }

        public override void ExplicitVisit(SimpleCaseExpression node) {
            this.GenerateKeyword(TSqlTokenType.Case);
            this.GenerateSpaceAndFragmentIfNotNull(node.InputExpression);
            foreach (SimpleWhenClause whenClause in node.WhenClauses) {
                this.GenerateSpaceAndFragmentIfNotNull(whenClause);
            }
            if (node.ElseExpression != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Else);
                this.GenerateSpaceAndFragmentIfNotNull(node.ElseExpression);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.End);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(SearchedCaseExpression node) {
            this.GenerateKeyword(TSqlTokenType.Case);
            foreach (SearchedWhenClause whenClause in node.WhenClauses) {
                this.GenerateSpaceAndFragmentIfNotNull(whenClause);
            }
            if (node.ElseExpression != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Else);
                this.GenerateSpaceAndFragmentIfNotNull(node.ElseExpression);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.End);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(CastCall node) {
            this.GenerateIdentifier("CAST");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Parameter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(CertificateCreateLoginSource node) {
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndIdentifier("CERTIFICATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Certificate);
            this.GenerateCredential(node.Credential);
        }

        public override void ExplicitVisit(CertificateOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._certificateOptionNames, node.Kind);
            if (valueForEnumKey != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
            }
        }

        public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node) {
            this.GenerateIdentifier("CHANGE_RETENTION");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.RetentionPeriod);
            this.GenerateSpace();
            RetentionUnitHelper.Instance.GenerateSourceForOption(this._writer, node.Unit);
        }

        protected void GenerateChangeTablePrefix(SchemaObjectName target, string changeTableKind) {
            this.GenerateIdentifier("CHANGETABLE");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateIdentifier(changeTableKind);
            this.GenerateSpaceAndFragmentIfNotNull(target);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
        }

        public override void ExplicitVisit(ChangeTableChangesTableReference node) {
            this.GenerateChangeTablePrefix(node.Target, "CHANGES");
            this.GenerateFragmentIfNotNull(node.SinceVersion);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(ChangeTableVersionTableReference node) {
            this.GenerateChangeTablePrefix(node.Target, "VERSION");
            this.GenerateParenthesisedCommaSeparatedList(node.PrimaryKeyColumns);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateParenthesisedCommaSeparatedList(node.PrimaryKeyValues);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(ChangeTrackingDatabaseOption node) {
            this.GenerateIdentifier("CHANGE_TRACKING");
            this.GenerateSpace();
            switch (node.OptionState) {
                case OptionState.Off:
                    this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                    this.GenerateKeyword(TSqlTokenType.Off);
                    break;
                case OptionState.On:
                    this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                    this.GenerateKeyword(TSqlTokenType.On);
                    this.GenerateParenthesisedCommaSeparatedList(node.Details);
                    break;
                default:
                    this.GenerateParenthesisedCommaSeparatedList(node.Details);
                    break;
            }
        }

        public override void ExplicitVisit(CharacterSetPayloadOption node) {
            this.GenerateNameEqualsValue("CHARACTER_SET", node.IsSql ? "SQL" : "XML");
        }

        public override void ExplicitVisit(CheckConstraintDefinition node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateConstraintHead(node);
            this.GenerateKeyword(TSqlTokenType.Check);
            if (node.NotForReplication) {
                this.GenerateSpace();
                this.GenerateNotForReplication();
            }
            this.GenerateSpace();
            this.GenerateParenthesisedFragmentIfNotNull(node.CheckCondition);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(CheckpointStatement node) {
            this.GenerateKeyword(TSqlTokenType.Checkpoint);
            this.GenerateSpaceAndFragmentIfNotNull(node.Duration);
        }

        public override void ExplicitVisit(ChildObjectName node) {
            if (node.ServerIdentifier != null) {
                this.GenerateFragmentIfNotNull(node.ServerIdentifier);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            if (node.DatabaseIdentifier != null) {
                this.GenerateFragmentIfNotNull(node.DatabaseIdentifier);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            if (node.SchemaIdentifier != null) {
                this.GenerateFragmentIfNotNull(node.SchemaIdentifier);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            if (node.BaseIdentifier != null) {
                this.GenerateFragmentIfNotNull(node.BaseIdentifier);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            this.GenerateFragmentIfNotNull(node.ChildIdentifier);
        }

        public override void ExplicitVisit(CloseCursorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Close);
            this.GenerateSpaceAndFragmentIfNotNull(node.Cursor);
        }

        public override void ExplicitVisit(CloseMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Close);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
        }

        public override void ExplicitVisit(CloseSymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Close);
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
                this.GenerateSpaceAndIdentifier("SYMMETRIC");
                this.GenerateSpaceAndIdentifier("KEYS");
            } else {
                this.GenerateSpaceAndIdentifier("SYMMETRIC");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            }
        }

        public override void ExplicitVisit(CoalesceExpression node) {
            this.GenerateKeyword(TSqlTokenType.Coalesce);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.Expressions);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(ColumnDefinition node) {
            this.MarkWhenNecessary("name");
            this.GenerateFragmentIfNotNull(node.ColumnIdentifier);
            bool flag = true;
            this.MarkWhenNecessary("type");
            if (node.ComputedColumnExpression != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                this.GenerateSpaceAndFragmentIfNotNull(node.ComputedColumnExpression);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
                if (node.Collation != null) {
                    this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                    this.GenerateSpaceAndCollation(node.Collation);
                }
                if (node.GeneratedAlways.HasValue) {
                    this.GenerateGeneratedAlways(node.GeneratedAlways);
                }
                this.GenerateFragmentIfNotNull(node.StorageOptions);
                this.GenerateSpaceAndFragmentIfNotNull(node.Encryption);
                if (node.IsMasked) {
                    this.GenerateSpaceAndIdentifier("MASKED");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateKeyword(TSqlTokenType.Function);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                    this.GenerateSpaceAndFragmentIfNotNull(node.MaskingFunction);
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
                if (node.IsHidden) {
                    this.GenerateSpaceAndIdentifier("HIDDEN");
                }
                if (node.DefaultConstraint != null) {
                    this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                    this.GenerateSpaceAndFragmentIfNotNull(node.DefaultConstraint);
                }
                this.GenerateIdentity(node.IdentityOptions, "constraint", ref flag);
                if (node.IsRowGuidCol) {
                    this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.RowGuidColumn);
                }
            }
            if (node.IsPersisted) {
                this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                this.GenerateSpaceAndIdentifier("PERSISTED");
            }
            foreach (ConstraintDefinition constraint in node.Constraints) {
                this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                this.GenerateSpaceAndFragmentIfNotNull(constraint);
            }
            if (node.Index != null) {
                this.MarkForConstraintsWhenNecessary("constraint", ref flag);
                this.GenerateSpaceAndFragmentIfNotNull(node.Index);
            }
            this.MarkForConstraintsWhenNecessary("constraint", ref flag);
        }

        public override void ExplicitVisit(ColumnStorageOptions node) {
            switch (node.SparseOption) {
                case SparseColumnOption.ColumnSetForAllSparseColumns:
                    this.GenerateSpaceAndIdentifier("COLUMN_SET");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier("ALL_SPARSE_COLUMNS");
                    break;
                case SparseColumnOption.Sparse:
                    this.GenerateSpaceAndIdentifier("SPARSE");
                    break;
            }
            if (node.IsFileStream) {
                this.GenerateSpaceAndIdentifier("FILESTREAM");
            }
        }

        private void GenerateIdentity(IdentityOptions node, string apName, ref bool firstConstraint) {
            if (node != null) {
                this.MarkForConstraintsWhenNecessary(apName, ref firstConstraint);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Identity);
                if (node.IdentitySeed != null) {
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateFragmentIfNotNull(node.IdentitySeed);
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    this.GenerateFragmentIfNotNull(node.IdentityIncrement);
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
                if (node.IsIdentityNotForReplication) {
                    this.GenerateSpace();
                    this.GenerateNotForReplication();
                }
            }
        }

        private void GenerateGeneratedAlways(GeneratedAlwaysType? node) {
            this.GenerateSpaceAndIdentifier("GENERATED");
            this.GenerateSpaceAndIdentifier("ALWAYS");
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            switch (node.Value) {
                case GeneratedAlwaysType.RowStart:
                    this.GenerateSpaceAndIdentifier("ROW");
                    this.GenerateSpaceAndIdentifier("START");
                    break;
                case GeneratedAlwaysType.RowEnd:
                    this.GenerateSpaceAndIdentifier("ROW");
                    this.GenerateSpaceAndIdentifier("END");
                    break;
                case GeneratedAlwaysType.UserIdStart:
                    this.GenerateSpaceAndIdentifier("SUSER_SID");
                    this.GenerateSpaceAndIdentifier("START");
                    break;
                case GeneratedAlwaysType.UserIdEnd:
                    this.GenerateSpaceAndIdentifier("SUSER_SID");
                    this.GenerateSpaceAndIdentifier("END");
                    break;
                case GeneratedAlwaysType.UserNameStart:
                    this.GenerateSpaceAndIdentifier("SUSER_SNAME");
                    this.GenerateSpaceAndIdentifier("START");
                    break;
                case GeneratedAlwaysType.UserNameEnd:
                    this.GenerateSpaceAndIdentifier("SUSER_SNAME");
                    this.GenerateSpaceAndIdentifier("END");
                    break;
            }
        }

        private void MarkForConstraintsWhenNecessary(string apName, ref bool firstConstraint) {
            if (firstConstraint) {
                this.MarkWhenNecessary(apName);
                firstConstraint = false;
            }
        }

        private void MarkWhenNecessary(string apName) {
            if (this._options.AlignColumnDefinitionFields) {
                AlignmentPoint ap = this.FindOrCreateAlignmentPointByName(apName);
                this.Mark(ap);
            }
        }

        public override void ExplicitVisit(ColumnDefinitionBase node) {
            this.GenerateFragmentIfNotNull(node.ColumnIdentifier);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node) {
            this.GenerateSpaceAndIdentifier("ALGORITHM");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Algorithm);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node) {
            this.GenerateSpaceAndIdentifier("ALGORITHM");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.EncryptionAlgorithm);
        }

        public override void ExplicitVisit(ColumnEncryptionDefinition node) {
            this.GenerateSpaceAndIdentifier("ENCRYPTED");
            this.GenerateSpaceAndKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.NewLineAndIndent();
            this.GenerateCommaSeparatedList(node.Parameters, true, true);
            this.NewLineAndIndent();
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node) {
            this.GenerateSpaceAndIdentifier("COLUMN_ENCRYPTION_KEY");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyValue node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.NewLineAndIndent();
            this.GenerateCommaSeparatedList(node.Parameters, true, true);
            this.NewLine();
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ColumnEncryptionTypeParameter node) {
            this.GenerateSpaceAndIdentifier("ENCRYPTION_TYPE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            switch (node.EncryptionType) {
                case ColumnEncryptionType.Deterministic:
                    this.GenerateSpaceAndIdentifier("DETERMINISTIC");
                    break;
                case ColumnEncryptionType.Randomized:
                    this.GenerateSpaceAndIdentifier("RANDOMIZED");
                    break;
                default:
                    throw new ArgumentException("Encryption type can be DETERMINISTIC or RANDOMIZED", "EncryptionType");
            }
        }

        public override void ExplicitVisit(ColumnMasterKeyNameParameter node) {
            this.GenerateSpaceAndIdentifier("COLUMN_MASTER_KEY");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(ColumnMasterKeyPathParameter node) {
            this.GenerateSpaceAndIdentifier("KEY_PATH");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Path);
        }

        public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node) {
            this.GenerateSpaceAndIdentifier("KEY_STORE_PROVIDER_NAME");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(ColumnReferenceExpression node) {
            this.GenerateFragmentIfNotNull(node.MultiPartIdentifier);
            if (node.ColumnType != 0) {
                if (node.MultiPartIdentifier != null && node.MultiPartIdentifier.Count > 0) {
                    this.GenerateSymbol(TSqlTokenType.Dot);
                }
                switch (node.ColumnType) {
                    case ColumnType.IdentityCol:
                        this.GenerateKeyword(TSqlTokenType.IdentityColumn);
                        break;
                    case ColumnType.RowGuidCol:
                        this.GenerateKeyword(TSqlTokenType.RowGuidColumn);
                        break;
                    case ColumnType.Wildcard:
                        this.GenerateSymbol(TSqlTokenType.Star);
                        break;
                    case ColumnType.PseudoColumnIdentity:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$IDENTITY");
                        break;
                    case ColumnType.PseudoColumnRowGuid:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$ROWGUID");
                        break;
                    case ColumnType.PseudoColumnAction:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$ACTION");
                        break;
                    case ColumnType.PseudoColumnCuid:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$CUID");
                        break;
                    case ColumnType.PseudoColumnGraphEdgeId:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$EDGE_ID");
                        break;
                    case ColumnType.PseudoColumnGraphNodeId:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$NODE_ID");
                        break;
                    case ColumnType.PseudoColumnGraphFromId:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$FROM_ID");
                        break;
                    case ColumnType.PseudoColumnGraphToId:
                        this.GenerateToken(TSqlTokenType.PseudoColumn, "$TO_ID");
                        break;
                }
            }
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(ColumnWithSortOrder node) {
            this.GenerateFragmentIfNotNull(node.Column);
            switch (node.SortOrder) {
                case SortOrder.NotSpecified:
                    break;
                case SortOrder.Ascending:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Asc);
                    break;
                case SortOrder.Descending:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Desc);
                    break;
            }
        }

        public override void ExplicitVisit(CommandSecurityElement80 node) {
            if (node.All) {
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                bool flag = true;
                foreach (CommandOptions commandOption in SqlScriptGeneratorVisitor._commandOptions) {
                    if (commandOption != 0 && (node.CommandOptions & commandOption) == commandOption) {
                        if (flag) {
                            flag = false;
                        } else {
                            this.GenerateSymbol(TSqlTokenType.Comma);
                            this.GenerateSpace();
                        }
                        this.GenerateCommandOptions(commandOption);
                    }
                }
            }
        }

        private void GenerateCommandOptions(CommandOptions option) {
            switch (option) {
                case CommandOptions.CreateDatabase:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                    break;
                case CommandOptions.CreateDefault:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
                    break;
                case CommandOptions.CreateProcedure:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Procedure);
                    break;
                case CommandOptions.CreateFunction:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Function);
                    break;
                case CommandOptions.CreateRule:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Rule);
                    break;
                case CommandOptions.CreateTable:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
                    break;
                case CommandOptions.CreateView:
                    this.GenerateKeyword(TSqlTokenType.Create);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.View);
                    break;
                case CommandOptions.BackupDatabase:
                    this.GenerateKeyword(TSqlTokenType.Backup);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                    break;
                case CommandOptions.BackupLog:
                    this.GenerateKeyword(TSqlTokenType.Backup);
                    this.GenerateSpaceAndIdentifier("LOG");
                    break;
            }
        }

        public override void ExplicitVisit(CommitTransactionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Commit);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Transaction);
            if (node.Name != null) {
                this.GenerateSpace();
                this.GenerateTransactionName(node.Name);
            }
            if (node.DelayedDurabilityOption != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateIdentifier("DELAYED_DURABILITY");
                this.GenerateSpace();
                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
                this.GenerateOptionStateOnOff(node.DelayedDurabilityOption);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        protected void GenerateSpaceAndMemoryUnit(MemoryUnit unit) {
            if (unit != 0) {
                this.GenerateSpace();
                MemoryUnitsHelper.Instance.GenerateSourceForOption(this._writer, unit);
            }
        }

        protected void GenerateOwnerIfNotNull(Identifier owner) {
            if (owner != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.Authorization);
                this.GenerateSpace();
                owner.Accept(this);
            }
        }

        private void GenerateCredential(Identifier identifier) {
            if (identifier != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("CREDENTIAL", identifier);
            }
        }

        protected void GenerateRemovePrivateKey() {
            this.GenerateIdentifier("REMOVE");
            this.GenerateSpaceAndIdentifier("PRIVATE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
        }

        protected void GenerateAttestedBy(Literal attestedBy) {
            this.GenerateIdentifier("ATTESTED");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpaceAndFragmentIfNotNull(attestedBy);
        }

        protected void GenerateRemoteAttestedOption() {
            this.GenerateIdentifier("REMOVE");
            this.GenerateSpaceAndIdentifier("ATTESTED");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
        }

        internal void GenerateWithPrivateKey(Literal privateKeyPath, Literal encryptionPassword, Literal decryptionPassword) {
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndIdentifier("PRIVATE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            bool flag = true;
            if (privateKeyPath != null) {
                flag = false;
                this.GenerateNameEqualsValue(TSqlTokenType.File, privateKeyPath);
            }
            if (decryptionPassword != null) {
                if (!flag) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                } else {
                    flag = false;
                }
                this.GenerateIdentifier("DECRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("PASSWORD", decryptionPassword);
            }
            if (encryptionPassword != null) {
                if (!flag) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                } else {
                    flag = false;
                }
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("PASSWORD", encryptionPassword);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        protected void GenerateSpaceAndCollation(Identifier collation) {
            if (collation != null) {
                this.GenerateSpace();
                this.GenerateKeyword(TSqlTokenType.Collate);
                this.GenerateSpaceAndFragmentIfNotNull(collation);
            }
        }

        protected void GenerateTriggerEnforcement(TriggerEnforcement triggerEnforcement) {
            switch (triggerEnforcement) {
                case TriggerEnforcement.Disable:
                    this.GenerateIdentifier("DISABLE");
                    break;
                case TriggerEnforcement.Enable:
                    this.GenerateIdentifier("ENABLE");
                    break;
            }
        }

        protected void GenerateNotForReplication() {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Not, TSqlTokenType.For, TSqlTokenType.Replication);
        }

        protected void GenerateDecryptionByPassword(Literal password) {
            this.GenerateIdentifier("DECRYPTION");
            this.GenerateSpace();
            this.GenerateByPassword(password);
        }

        protected void GenerateEncryptionByPassword(Literal password) {
            this.GenerateIdentifier("ENCRYPTION");
            this.GenerateSpace();
            this.GenerateByPassword(password);
        }

        protected void GenerateByPassword(Literal password) {
            this.GenerateKeywordAndSpace(TSqlTokenType.By);
            this.GenerateNameEqualsValue("PASSWORD", password);
        }

        protected void GenerateBinaryOperator(BinaryExpressionType operatorType) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._binaryExpressionTypeGenerators, operatorType);
            this.GenerateTokenList(valueForEnumKey);
        }

        protected void GenerateBinaryOperator(BooleanComparisonType operatorType) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._booleanComparisonTypeGenerators, operatorType);
            this.GenerateTokenList(valueForEnumKey);
        }

        protected void GenerateBinaryOperator(BooleanBinaryExpressionType operatorType) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._booleanBinaryExpressionTypeGenerators, operatorType);
            this.GenerateTokenList(valueForEnumKey);
        }

        protected void GenerateUniqueRowFilter(UniqueRowFilter uniqueRowFilter, bool spaceBefore) {
            if (uniqueRowFilter != 0) {
                if (spaceBefore) {
                    this.GenerateSpace();
                }
                switch (uniqueRowFilter) {
                    case UniqueRowFilter.All:
                        this.GenerateKeyword(TSqlTokenType.All);
                        break;
                    case UniqueRowFilter.Distinct:
                        this.GenerateKeyword(TSqlTokenType.Distinct);
                        break;
                }
            }
        }

        protected void GenerateNewLineOrSpace(bool newline) {
            if (newline) {
                this.NewLine();
            } else {
                this.GenerateSpace();
            }
        }

        protected void MarkClauseBodyAlignmentWhenNecessary(bool newline, AlignmentPoint ap) {
            if (newline && this._options.AlignClauseBodies && ap != null) {
                this.Mark(ap);
            }
        }

        protected void MarkInsertColumnsAlignmentPointWhenNecessary(AlignmentPoint ap) {
            if (ap != null) {
                this.Mark(ap);
            }
        }

        protected void GenerateSeparatorForOrderBy() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeOrderByClause);
        }

        protected void GenerateSeparatorForFromClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeFromClause);
        }

        protected void GenerateSeparatorForWhereClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeWhereClause);
        }

        protected void GenerateSeparatorForGroupByClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeGroupByClause);
        }

        protected void GenerateSeparatorForHavingClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeHavingClause);
        }

        protected void GenerateSeparatorForOutputClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeOutputClause);
        }

        protected void GenerateSeparatorForOffsetClause() {
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeOffsetClause);
        }

        protected void GenerateQueryExpressionInParentheses(QueryExpression queryExpression) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            if (queryExpression != null) {
                AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
                this.GenerateFragmentWithAlignmentPointIfNotNull(queryExpression, ap2);
            }
            this.PopAlignmentPoint();
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        private void GenerateSelectElementsList(IList<SelectElement> selectElements) {
            if (!this._options.MultilineSelectElementsList) {
                this.GenerateCommaSeparatedList(selectElements);
            } else {
                this.GenerateFragmentList(selectElements, ListGenerationOption.MultipleLineSelectElementOption);
            }
        }

        protected void GenerateParameters(ParameterizedDataTypeReference node) {
            if (node.Parameters.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Parameters);
            }
        }

        protected void GenerateSemiColonWhenNecessary(TSqlStatement node) {
            if (node != null && this._generateSemiColon && !this.StatementsThatCannotHaveSemiColon.Contains(node.GetType())) {
                this.GenerateSymbol(TSqlTokenType.Semicolon);
            }
        }

        protected void GenerateCommaSeparatedWithClause<T>(IList<T> fragments, bool indent, bool includeParentheses) where T : TSqlFragment {
            if (fragments != null && ((ICollection<T>)fragments).Count > 0) {
                this.NewLine();
                if (indent) {
                    this.Indent();
                }
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                if (includeParentheses) {
                    this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                }
                this.GenerateCommaSeparatedList(fragments);
                if (includeParentheses) {
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
            }
        }

        public override void ExplicitVisit(CommonTableExpression node) {
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
            this.GenerateSpaceAndFragmentIfNotNull(node.ExpressionName);
            if (node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.As);
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
            this.GenerateSpace();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateQueryExpressionInParentheses(node.QueryExpression);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(CompressionEndpointProtocolOption node) {
            this.GenerateNameEqualsValue("COMPRESSION", node.IsEnabled ? "ENABLED" : "DISABLED");
        }

        public override void ExplicitVisit(CompressionPartitionRange node) {
            this.GenerateFragmentIfNotNull(node.From);
            if (node.To != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                this.GenerateSpaceAndFragmentIfNotNull(node.To);
            }
        }

        public override void ExplicitVisit(ComputeClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Compute);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.ComputeFunctions);
            if (node.ByExpressions.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.ByExpressions);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(ComputeFunction node) {
            ComputeFunctionTypeHelper.Instance.GenerateSourceForOption(this._writer, node.ComputeFunctionType);
            this.GenerateParenthesisedFragmentIfNotNull(node.Expression);
        }

        protected void GenerateConstraintHead(ConstraintDefinition node) {
            if (node.ConstraintIdentifier != null) {
                this.GenerateKeyword(TSqlTokenType.Constraint);
                this.GenerateSpaceAndFragmentIfNotNull(node.ConstraintIdentifier);
                this.GenerateSpace();
            }
        }

        protected void GenerateDeleteUpdateAction(DeleteUpdateAction action) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._deleteUpdateActionGenerators, action);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ContainmentDatabaseOption node) {
            this.GenerateIdentifier("CONTAINMENT");
            this.GenerateSpace();
            this.GenerateSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            ContainmentOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(ContinueStatement node) {
            this.GenerateKeyword(TSqlTokenType.Continue);
        }

        public override void ExplicitVisit(ContractMessage node) {
            this.GenerateFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndIdentifier("SENT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._messageSenderGenerators, node.SentBy);
            this.GenerateSpace();
            this.GenerateToken(valueForEnumKey);
        }

        public override void ExplicitVisit(ConvertCall node) {
            this.GenerateKeyword(TSqlTokenType.Convert);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DataType);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.Parameter);
            if (node.Style != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.Style);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(CreateAggregateStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("AGGREGATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters);
            this.NewLineAndIndent();
            this.GenerateIdentifier("RETURNS");
            this.GenerateSpaceAndFragmentIfNotNull(node.ReturnType);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.External);
            this.GenerateSpaceAndIdentifier("NAME");
            this.GenerateSpaceAndFragmentIfNotNull(node.AssemblyName);
        }

        public override void ExplicitVisit(CreateApplicationRoleStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateApplicationRoleStatementBase(node);
        }

        public override void ExplicitVisit(CreateAssemblyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("ASSEMBLY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Parameters);
            this.GenerateAssemblyOptions(node.Options);
        }

        public override void ExplicitVisit(CreateAvailabilityGroupStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateIdentifier("AVAILABILITY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateCommaSeparatedWithClause(node.Options, false, true);
            this.NewLine();
            this.GenerateKeywordAndSpace(TSqlTokenType.For);
            if (node.Databases != null && node.Databases.Count > 0) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Database);
                this.GenerateCommaSeparatedList(node.Databases);
                this.NewLine();
            }
            this.GenerateIdentifier("REPLICA");
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.On);
            this.GenerateCommaSeparatedList(node.Replicas, true);
        }

        public override void ExplicitVisit(LiteralAvailabilityGroupOption node) {
            this.GenerateNameEqualsValue("REQUIRED_COPIES_TO_COMMIT", node.Value);
        }

        public override void ExplicitVisit(CreateBrokerPriorityStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateBrokerPriorityStatementBody(node);
        }

        public override void ExplicitVisit(CreateCertificateStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("CERTIFICATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            if (node.CertificateSource != null) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.From);
                this.GenerateFragmentIfNotNull(node.CertificateSource);
                if (node.PrivateKeyPath != null) {
                    this.NewLineAndIndent();
                    this.GenerateKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndIdentifier("PRIVATE");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateNameEqualsValue(TSqlTokenType.File, node.PrivateKeyPath);
                    if (node.DecryptionPassword != null) {
                        this.GenerateSymbol(TSqlTokenType.Comma);
                        this.GenerateSpaceAndIdentifier("DECRYPTION");
                        this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                        this.GenerateSpace();
                        this.GenerateNameEqualsValue("PASSWORD", node.DecryptionPassword);
                    }
                    if (node.EncryptionPassword != null) {
                        this.GenerateSymbol(TSqlTokenType.Comma);
                        this.GenerateSpace();
                        this.GenerateEncryptionPassword(node.EncryptionPassword);
                    }
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
            } else {
                if (node.EncryptionPassword != null) {
                    this.NewLineAndIndent();
                    this.GenerateEncryptionPassword(node.EncryptionPassword);
                }
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.CertificateOptions);
            }
            if (node.ActiveForBeginDialog != 0) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("ACTIVE");
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpace();
                this.GenerateOptionStateWithEqualSign("BEGIN_DIALOG", node.ActiveForBeginDialog);
            }
        }

        private void GenerateEncryptionPassword(Literal password) {
            if (password != null) {
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("PASSWORD", password);
            }
        }

        public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("COLUMN");
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndIdentifier("KEY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndIdentifier("VALUES");
            this.NewLine();
            this.GenerateCommaSeparatedList(node.ColumnEncryptionKeyValues, true);
        }

        public override void ExplicitVisit(CreateColumnMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("COLUMN");
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndIdentifier("KEY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.NewLineAndIndent();
            this.GenerateCommaSeparatedList(node.Parameters, true, true);
            this.NewLine();
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(CreateColumnStoreIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            if (node.Clustered.HasValue) {
                this.GenerateSpaceAndKeyword((TSqlTokenType)(node.Clustered.Value ? 24 : 98));
            }
            this.GenerateSpaceAndIdentifier("COLUMNSTORE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            if (!node.Clustered.GetValueOrDefault() && node.Columns != null && node.Columns.Count > 0) {
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            if (node.FilterPredicate != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
                this.GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            }
            this.GenerateIndexOptions(node.IndexOptions);
            if (node.OnFileGroupOrPartitionScheme != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }
        }

        public override void ExplicitVisit(CreateContractStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("CONTRACT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.NewLineAndIndent();
            this.GenerateParenthesisedCommaSeparatedList(node.Messages);
        }

        public override void ExplicitVisit(CreateCredentialStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateCredentialStatementBody(node);
            if (node.CryptographicProviderName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndIdentifier("CRYPTOGRAPHIC");
                this.GenerateSpaceAndIdentifier("PROVIDER");
                this.GenerateSpaceAndFragmentIfNotNull(node.CryptographicProviderName);
            }
        }

        public override void ExplicitVisit(CreateDatabaseStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            this.GenerateSpaceAndFragmentIfNotNull(node.Containment);
            if (node.FileGroups != null && node.FileGroups.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.FileGroups);
            }
            if (node.LogOn.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("LOG");
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.LogOn);
            }
            this.GenerateSpaceAndCollation(node.Collation);
            if (node.AttachMode != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._attachModeGenerators, node.AttachMode);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateToken(valueForEnumKey);
                }
            }
            if (node.DatabaseSnapshot != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("SNAPSHOT");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Of);
                this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseSnapshot);
            }
            if (node.CopyOf != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("COPY");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Of);
                this.GenerateSpaceAndFragmentIfNotNull(node.CopyOf);
            }
            if (node.Options != null && node.Options.Count > 0) {
                bool flag = true;
                foreach (DatabaseOption option in node.Options) {
                    if (option.OptionKind != DatabaseOptionKind.MaxSize && option.OptionKind != DatabaseOptionKind.Edition && option.OptionKind != DatabaseOptionKind.ServiceObjective) {
                        flag = false;
                        break;
                    }
                }
                if (flag) {
                    this.NewLineAndIndent();
                    this.GenerateParenthesisedCommaSeparatedList(node.Options, true);
                } else {
                    this.GenerateCommaSeparatedWithClause(node.Options, true, false);
                }
            }
        }

        public override void ExplicitVisit(CreateDefaultStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.Expression != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
            }
        }

        public override void ExplicitVisit(CreateEndpointStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("ENDPOINT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.GenerateSpace();
            this.GenerateEndpointBody(node);
        }

        public override void ExplicitVisit(CreateExternalDataSourceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("DATA");
            this.GenerateSpaceAndIdentifier("SOURCE");
            this.GenerateExternalDataSourceStatementBody(node);
        }

        protected void GenerateExternalDataSourceStatementBody(ExternalDataSourceStatement node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._externalDataSourceTypeNames, node.DataSourceType);
            if (!string.IsNullOrEmpty(valueForEnumKey)) {
                this.NewLineAndIndent();
                this.GenerateNameEqualsValue("TYPE", valueForEnumKey);
            }
            if (node.Location != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.NewLineAndIndent();
                this.GenerateNameEqualsValue("LOCATION", node.Location);
            }
            this.GenerateExternalDataSourceOptions(node);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        private void GenerateExternalDataSourceOptions(ExternalDataSourceStatement node) {
            if (node.ExternalDataSourceOptions.Count > 0) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.NewLineAndIndent();
                this.GenerateCommaSeparatedList(node.ExternalDataSourceOptions, true, true);
            }
        }

        public override void ExplicitVisit(CreateExternalFileFormatStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("FILE");
            this.GenerateSpaceAndIdentifier("FORMAT");
            this.GenerateExternalFileFormatStatementBody(node);
        }

        protected void GenerateExternalFileFormatStatementBody(ExternalFileFormatStatement node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._externalFileFormatTypeNames, node.FormatType);
            if (!string.IsNullOrEmpty(valueForEnumKey)) {
                this.NewLineAndIndent();
                this.GenerateNameEqualsValue("FORMAT_TYPE", valueForEnumKey);
            }
            this.GenerateExternalFileFormatOptions(node);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        private void GenerateExternalFileFormatOptions(ExternalFileFormatStatement node) {
            if (node.ExternalFileFormatOptions.Count > 0) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.NewLineAndIndent();
                this.GenerateCommaSeparatedList(node.ExternalFileFormatOptions, true, true);
            }
        }

        public override void ExplicitVisit(CreateExternalResourcePoolStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateExternalResourcePoolStatementBody(node);
        }

        public override void ExplicitVisit(CreateExternalTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
            this.GenerateExternalTableStatementBody(node);
        }

        protected void GenerateExternalTableStatementBody(ExternalTableStatement node) {
            this.GenerateExternalTableColumnDefinitions(node);
            this.GenerateExternalTableOptions(node);
        }

        private void GenerateExternalTableColumnDefinitions(ExternalTableStatement node) {
            if (node.ColumnDefinitions != null) {
                List<TSqlFragment> list = new List<TSqlFragment>();
                foreach (ExternalTableColumnDefinition columnDefinition in node.ColumnDefinitions) {
                    list.Add(columnDefinition);
                }
                ListGenerationOption option = ListGenerationOption.CreateOptionFromFormattingConfig(this._options);
                this.GenerateFragmentList(list, option);
            }
        }

        private void GenerateExternalTableOptions(ExternalTableStatement node) {
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.With);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            if (node.DataSource != null) {
                this.NewLineAndIndent();
                this.GenerateNameEqualsValue("DATA_SOURCE", node.DataSource);
            }
            if (node.ExternalTableOptions.Count > 0) {
                if (node.DataSource != null) {
                    this.GenerateSymbol(TSqlTokenType.Comma);
                }
                this.NewLineAndIndent();
                this.GenerateCommaSeparatedList(node.ExternalTableOptions, true, true);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(CreateEventNotificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("EVENT");
            this.GenerateSpaceAndIdentifier("NOTIFICATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            if (node.Scope != null) {
                switch (node.Scope.Target) {
                    case EventNotificationTarget.Server:
                        this.GenerateSpaceAndIdentifier("SERVER");
                        break;
                    case EventNotificationTarget.Database:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                        break;
                    case EventNotificationTarget.Queue:
                        this.GenerateSpaceAndIdentifier("QUEUE");
                        this.GenerateSpaceAndFragmentIfNotNull(node.Scope.QueueName);
                        break;
                }
            }
            if (node.WithFanIn) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("FAN_IN");
            }
            if (node.EventTypeGroups != null && node.EventTypeGroups.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.For);
                this.GenerateSpace();
                this.GenerateFragmentList(node.EventTypeGroups);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.BrokerService);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.BrokerInstanceSpecifier);
        }

        public override void ExplicitVisit(CreateFederationStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateIdentifier("FEDERATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DistributionName);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSpaceAndIdentifier("RANGE");
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(CreateFullTextCatalogStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndIdentifier("CATALOG");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.FileGroup != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndIdentifier("FILEGROUP");
                this.GenerateSpaceAndFragmentIfNotNull(node.FileGroup);
            }
            if (node.Path != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.In);
                this.GenerateSpaceAndIdentifier("PATH");
                this.GenerateSpaceAndFragmentIfNotNull(node.Path);
            }
            this.GenerateCommaSeparatedWithClause(node.Options, true, false);
            if (node.IsDefault) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
            }
            this.GenerateOwnerIfNotNull(node.Owner);
        }

        public override void ExplicitVisit(OnOffFullTextCatalogOption node) {
            this.GenerateOptionStateWithEqualSign("ACCENT_SENSITIVITY", node.OptionState);
        }

        public override void ExplicitVisit(CreateFullTextIndexStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Create, "FULLTEXT");
            this.GenerateSpace();
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Index, TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            if (node.FullTextIndexColumns != null && node.FullTextIndexColumns.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateParenthesisedCommaSeparatedList(node.FullTextIndexColumns);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.KeyIndexName);
            this.GenerateFragmentIfNotNull(node.CatalogAndFileGroup);
            if (node.Options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(FullTextCatalogAndFileGroup node) {
            this.NewLineAndIndent();
            this.GenerateKeywordAndSpace(TSqlTokenType.On);
            if (node.FileGroupIsFirst) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateIdentifier("FILEGROUP");
                this.GenerateSpaceAndFragmentIfNotNull(node.FileGroupName);
                if (node.CatalogName != null) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    this.GenerateFragmentIfNotNull(node.CatalogName);
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                if (node.FileGroupName != null) {
                    this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                }
                this.GenerateFragmentIfNotNull(node.CatalogName);
                if (node.FileGroupName != null) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    this.GenerateIdentifier("FILEGROUP");
                    this.GenerateSpaceAndFragmentIfNotNull(node.FileGroupName);
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
            }
        }

        public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node) {
            this.GenerateIdentifier("CHANGE_TRACKING");
            this.GenerateSpace();
            switch (node.Value) {
                case ChangeTrackingOption.Auto:
                    this.GenerateIdentifier("AUTO");
                    break;
                case ChangeTrackingOption.Manual:
                    this.GenerateIdentifier("MANUAL");
                    break;
                case ChangeTrackingOption.Off:
                    this.GenerateKeyword(TSqlTokenType.Off);
                    break;
                case ChangeTrackingOption.OffNoPopulation:
                    this.GenerateKeyword(TSqlTokenType.Off);
                    this.GenerateSymbol(TSqlTokenType.Comma);
                    this.GenerateSpaceAndIdentifier("NO");
                    this.GenerateSpaceAndIdentifier("POPULATION");
                    break;
            }
        }

        public override void ExplicitVisit(StopListFullTextIndexOption node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.StopList);
            if (node.IsOff) {
                this.GenerateKeyword(TSqlTokenType.Off);
            } else {
                this.GenerateFragmentIfNotNull(node.StopListName);
            }
        }

        public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node) {
            this.GenerateIdentifier("SEARCH");
            this.GenerateSpaceAndIdentifier("PROPERTY");
            this.GenerateSpaceAndIdentifier("LIST");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            if (node.IsOff) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.PropertyListName);
            }
        }

        public override void ExplicitVisit(CreateFullTextStopListStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.StopList);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.IsSystemStopList) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                this.GenerateSpaceAndIdentifier("SYSTEM");
                this.GenerateSpaceAndKeyword(TSqlTokenType.StopList);
            } else if (node.SourceStopListName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                if (node.DatabaseName != null) {
                    this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
                    this.GenerateKeyword(TSqlTokenType.Dot);
                } else {
                    this.GenerateSpace();
                }
                this.GenerateFragmentIfNotNull(node.SourceStopListName);
            }
            this.GenerateOwnerIfNotNull(node.Owner);
        }

        public override void ExplicitVisit(CreateFunctionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateFunctionStatementBody(node);
        }

        public override void ExplicitVisit(CreateIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            if (node.Unique) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Unique);
            }
            if (node.Clustered.HasValue) {
                this.GenerateSpaceAndKeyword((TSqlTokenType)(node.Clustered.Value ? 24 : 98));
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            if (node.IncludeColumns != null && node.IncludeColumns.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("INCLUDE");
                this.GenerateParenthesisedCommaSeparatedList(node.IncludeColumns);
            }
            if (node.FilterPredicate != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
                this.GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            }
            this.GenerateIndexOptions(node.IndexOptions);
            if (node.OnFileGroupOrPartitionScheme != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }
            this.GenerateFileStreamOn(node);
        }

        protected virtual void GenerateIndexOptions(IList<IndexOption> options) {
            if (options != null && options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(options);
            }
        }

        private void GenerateFileStreamOn(IFileStreamSpecifier node) {
            if (node.FileStreamOn != null) {
                this.GenerateSpaceAndIdentifier("FILESTREAM_ON");
                this.GenerateSpaceAndFragmentIfNotNull(node.FileStreamOn);
            }
        }

        public override void ExplicitVisit(CreateLoginStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("LOGIN");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateFragmentIfNotNull(node.Source);
        }

        public override void ExplicitVisit(CreateMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            if (node.Password != null) {
                this.GenerateSpaceAndIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpaceAndIdentifier("PASSWORD");
                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Password);
            }
        }

        public override void ExplicitVisit(CreateMessageTypeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("MESSAGE");
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.GenerateValidationMethod(node);
        }

        public override void ExplicitVisit(CreateOrAlterFunctionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateKeywordAndSpace(TSqlTokenType.Or);
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateFunctionStatementBody(node);
        }

        public override void ExplicitVisit(CreateOrAlterProcedureStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateKeywordAndSpace(TSqlTokenType.Or);
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateProcedureStatementBody(node);
        }

        public override void ExplicitVisit(CreateOrAlterTriggerStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateKeywordAndSpace(TSqlTokenType.Or);
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateTriggerStatementBody(node);
        }

        public override void ExplicitVisit(CreateOrAlterViewStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateKeywordAndSpace(TSqlTokenType.Or);
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateViewStatementBody(node);
        }

        public override void ExplicitVisit(CreatePartitionFunctionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Function);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateParenthesisedFragmentIfNotNull(node.ParameterType);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndIdentifier("RANGE");
            switch (node.Range) {
                case PartitionFunctionRange.Left:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Left);
                    break;
                case PartitionFunctionRange.Right:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Right);
                    break;
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Values);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.BoundaryValues, true);
        }

        public override void ExplicitVisit(PartitionParameterType node) {
            this.GenerateFragmentIfNotNull(node.DataType);
            if (node.Collation != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Collate);
                this.GenerateSpaceAndFragmentIfNotNull(node.Collation);
            }
        }

        public override void ExplicitVisit(CreatePartitionSchemeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndIdentifier("SCHEME");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndFragmentIfNotNull(node.PartitionFunction);
            this.NewLineAndIndent();
            if (node.IsAll) {
                this.GenerateKeyword(TSqlTokenType.All);
                this.GenerateSpace();
            }
            this.GenerateKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.FileGroups);
        }

        public override void ExplicitVisit(CreateProcedureStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateProcedureStatementBody(node);
        }

        public override void ExplicitVisit(CreateQueueStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("QUEUE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.QueueOptions != null && node.QueueOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateQueueOptions(node.QueueOptions);
            }
            if (node.OnFileGroup != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroup);
            }
        }

        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("REMOTE");
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndIdentifier("BINDING");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Service);
            this.GenerateBindingOptions(node.Options);
        }

        public override void ExplicitVisit(CreateResourcePoolStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateResourcePoolStatementBody(node);
        }

        public override void ExplicitVisit(CreateRoleStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
        }

        public override void ExplicitVisit(CreateRouteStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("ROUTE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.GenerateRouteOptions(node);
        }

        public override void ExplicitVisit(CreateRuleStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Rule);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(CreateSchemaStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            if (node.StatementList != null && node.StatementList.Statements != null && node.StatementList.Statements.Count > 0) {
                AlignmentPoint ap = new AlignmentPoint();
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                bool generateSemiColon = this._generateSemiColon;
                this._generateSemiColon = false;
                this.GenerateFragmentIfNotNull(node.StatementList);
                this._generateSemiColon = generateSemiColon;
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(CreateSearchPropertyListStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Create, "SEARCH", "PROPERTY", "LIST");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.SourceSearchPropertyList != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.From);
                this.GenerateSpaceAndFragmentIfNotNull(node.SourceSearchPropertyList);
            }
            this.GenerateOwnerIfNotNull(node.Owner);
        }

        public override void ExplicitVisit(CreateSecurityPolicyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("SECURITY");
            this.GenerateSpaceAndIdentifier("POLICY");
            this.GenerateSecurityPolicyStatementBody(node);
        }

        public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            if (!node.IsSecondary) {
                this.GenerateSpaceAndIdentifier("SELECTIVE");
            }
            this.GenerateSpaceAndIdentifier("XML");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.XmlColumn);
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            if (node.IsSecondary) {
                this.NewLine();
                this.GenerateIdentifier("USING");
                this.GenerateSpaceAndIdentifier("XML");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
                this.GenerateSpaceAndFragmentIfNotNull(node.UsingXmlIndexName);
            } else if (node.XmlNamespaces != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndFragmentIfNotNull(node.XmlNamespaces);
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.For);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateSpaceAndFragmentIfNotNull(node.PathName);
            ListGenerationOption listGenerationOption = ListGenerationOption.CreateOptionFromFormattingConfig(this._options);
            listGenerationOption.Parenthesised = false;
            listGenerationOption.AlwaysGenerateParenthesis = false;
            this.GenerateFragmentList(node.PromotedPaths, listGenerationOption);
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            if (node.IndexOptions != null && node.IndexOptions.Count > 0) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.IndexOptions);
            }
        }

        public override void ExplicitVisit(CreateSequenceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("SEQUENCE");
            this.GenerateSequenceStatementBody(node);
        }

        public override void ExplicitVisit(CreateServerRoleStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Create, "SERVER", "ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
        }

        public override void ExplicitVisit(CreateServiceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndIdentifier("QUEUE");
            this.GenerateSpaceAndFragmentIfNotNull(node.QueueName);
            if (node.ServiceContracts != null && node.ServiceContracts.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateParenthesisedCommaSeparatedList(node.ServiceContracts);
            }
        }

        public override void ExplicitVisit(CreateSpatialIndexStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateIdentifier("SPATIAL");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.Object);
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.SpatialColumnName);
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            this.PopAlignmentPoint();
            if (node.SpatialIndexingScheme != 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateIdentifier("USING");
                this.GenerateSpace();
                SpatialIndexingSchemeTypeHelper.Instance.GenerateSourceForOption(this._writer, node.SpatialIndexingScheme);
                this.PopAlignmentPoint();
            }
            if (node.SpatialIndexOptions != null && node.SpatialIndexOptions.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.SpatialIndexOptions, 2);
                this.PopAlignmentPoint();
            }
            if (node.OnFileGroup != null) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroup);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(SpatialIndexRegularOption node) {
            this.GenerateFragmentIfNotNull(node.Option);
        }

        public override void ExplicitVisit(BoundingBoxSpatialIndexOption node) {
            this.GenerateIdentifier("BOUNDING_BOX");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.BoundingBoxParameters != null && node.BoundingBoxParameters.Count > 0) {
                this.GenerateParenthesisedCommaSeparatedList(node.BoundingBoxParameters);
            }
        }

        public override void ExplicitVisit(BoundingBoxParameter node) {
            if (node.Parameter != 0) {
                BoundingBoxParameterTypeHelper.Instance.GenerateSourceForOption(this._writer, node.Parameter);
                this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(GridsSpatialIndexOption node) {
            this.GenerateIdentifier("GRIDS");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.GridParameters != null && node.GridParameters.Count > 0) {
                this.GenerateParenthesisedCommaSeparatedList(node.GridParameters);
            }
        }

        public override void ExplicitVisit(GridParameter node) {
            if (node.Parameter != 0) {
                GridParameterTypeHelper.Instance.GenerateSourceForOption(this._writer, node.Parameter);
                this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
            }
            ImportanceParameterHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node) {
            this.GenerateIdentifier("CELLS_PER_OBJECT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(CreateStatisticsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Statistics);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            if (node.FilterPredicate != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
                this.GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            }
            if (node.StatisticsOptions != null && node.StatisticsOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.StatisticsOptions);
            }
        }

        public override void ExplicitVisit(CreateSynonymStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("SYNONYM");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndFragmentIfNotNull(node.ForName);
        }

        public override void ExplicitVisit(CreateTableStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
            if (node.Definition != null) {
                List<TSqlFragment> list = new List<TSqlFragment>();
                foreach (ColumnDefinition columnDefinition in node.Definition.ColumnDefinitions) {
                    list.Add(columnDefinition);
                }
                foreach (ConstraintDefinition tableConstraint in node.Definition.TableConstraints) {
                    list.Add(tableConstraint);
                }
                foreach (IndexDefinition index in node.Definition.Indexes) {
                    list.Add(index);
                }
                ListGenerationOption option = ListGenerationOption.CreateOptionFromFormattingConfig(this._options);
                if (node.Definition.SystemTimePeriod != null) {
                    list.Add(node.Definition.SystemTimePeriod);
                }
                this.GenerateFragmentList(list, option);
            }
            if (node.AsEdge) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("EDGE");
            }
            if (node.AsFileTable) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("FILETABLE");
            }
            if (node.AsNode) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("NODE");
            }
            this.PopAlignmentPoint();
            if (node.FederationScheme != null) {
                this.GenerateSpaceAndIdentifier("FEDERATED");
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(node.FederationScheme.DistributionName);
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.FederationScheme.ColumnName);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
            if (node.OnFileGroupOrPartitionScheme != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }
            if (node.TextImageOn != null) {
                this.GenerateSpaceAndIdentifier("TEXTIMAGE_ON");
                this.GenerateSpaceAndFragmentIfNotNull(node.TextImageOn);
            }
            this.GenerateFileStreamOn(node);
            this.GenerateCommaSeparatedWithClause(node.Options, false, true);
        }

        public override void ExplicitVisit(CreateTriggerStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpace();
            this.GenerateTriggerStatementBody(node);
        }

        public override void ExplicitVisit(CreateTypeTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.NewLineAndIndent();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            bool flag = false;
            this.GenerateColumnsConstraintsIndexes(node.Definition.ColumnDefinitions, ref flag);
            this.GenerateColumnsConstraintsIndexes(node.Definition.TableConstraints, ref flag);
            this.GenerateColumnsConstraintsIndexes(node.Definition.Indexes, ref flag);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateCommaSeparatedWithClause(node.Options, false, true);
            this.PopAlignmentPoint();
        }

        private void GenerateColumnsConstraintsIndexes<T>(IList<T> fragmentList, ref bool commaNeeded) where T : TSqlFragment {
            if (fragmentList != null && ((ICollection<T>)fragmentList).Count > 0) {
                if (commaNeeded) {
                    this.GenerateSymbol(TSqlTokenType.Comma);
                    this.NewLine();
                }
                this.GenerateCommaSeparatedList(fragmentList, true);
                commaNeeded = true;
            }
        }

        public override void ExplicitVisit(CreateTypeUddtStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSpaceAndFragmentIfNotNull(node.NullableConstraint);
        }

        public override void ExplicitVisit(CreateTypeUdtStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateSpaceAndKeyword(TSqlTokenType.External);
            this.GenerateSpaceAndIdentifier("NAME");
            this.GenerateSpaceAndFragmentIfNotNull(node.AssemblyName);
        }

        public override void ExplicitVisit(CreateUserStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.User);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndFragmentIfNotNull(node.UserLoginOption);
            if (node.UserOptions != null && node.UserOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.UserOptions);
            }
        }

        public override void ExplicitVisit(CreateViewStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpace();
            this.GenerateViewStatementBody(node);
        }

        public override void ExplicitVisit(CreateWorkloadGroupStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateWorkloadGroupStatementBody(node);
        }

        public override void ExplicitVisit(CreateXmlIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            if (node.Primary) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Primary);
            }
            this.GenerateSpaceAndIdentifier("XML");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.OnName);
            this.GenerateParenthesisedFragmentIfNotNull(node.XmlColumn);
            if (node.SecondaryXmlIndexName != null) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("USING");
                this.GenerateSpaceAndIdentifier("XML");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
                this.GenerateSpaceAndFragmentIfNotNull(node.SecondaryXmlIndexName);
                if (node.SecondaryXmlIndexType != 0) {
                    string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._secondaryXmlIndexTypeNames, node.SecondaryXmlIndexType);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier(valueForEnumKey);
                }
            }
            if (node.IndexOptions != null && node.IndexOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.IndexOptions);
            }
        }

        public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("XML");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            this.GenerateSpaceAndIdentifier("COLLECTION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        protected void GenerateCredentialStatementBody(CredentialStatement node) {
            if (node.IsDatabaseScoped) {
                this.GenerateIdentifier("DATABASE");
                this.GenerateSpaceAndIdentifier("SCOPED");
                this.GenerateSpace();
            }
            this.GenerateIdentifier("CREDENTIAL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.Identity != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateNameEqualsValue(TSqlTokenType.Identity, node.Identity);
            }
            if (node.Secret != null) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateNameEqualsValue("SECRET", node.Secret);
            }
        }

        public override void ExplicitVisit(CreateCryptographicProviderStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateIdentifier("CRYPTOGRAPHIC");
            this.GenerateSpaceAndIdentifier("PROVIDER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.CryptographicProviderFile(node.File, ap);
        }

        public void CryptographicProviderFile(Literal node, AlignmentPoint ap) {
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeywordAndSpace(TSqlTokenType.From);
            this.GenerateNameEqualsValue(TSqlTokenType.File, node);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(AlterCryptographicProviderStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateIdentifier("CRYPTOGRAPHIC");
            this.GenerateSpaceAndIdentifier("PROVIDER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.Option == EnableDisableOptionType.None) {
                this.CryptographicProviderFile(node.File, ap);
            } else {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                EnableDisableOptionTypeHelper.Instance.GenerateSourceForOption(this._writer, node.Option);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(DropCryptographicProviderStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateIdentifier("CRYPTOGRAPHIC");
            this.GenerateSpaceAndIdentifier("PROVIDER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(CryptoMechanism node) {
            switch (node.CryptoMechanismType) {
                case CryptoMechanismType.Certificate:
                    this.GenerateIdentifier("CERTIFICATE");
                    this.GenerateIdentifierWithPassword(node);
                    break;
                case CryptoMechanismType.AsymmetricKey:
                    this.GenerateIdentifier("ASYMMETRIC");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                    this.GenerateIdentifierWithPassword(node);
                    break;
                case CryptoMechanismType.SymmetricKey:
                    this.GenerateIdentifier("SYMMETRIC");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                    this.GenerateIdentifierWithPassword(node);
                    break;
                case CryptoMechanismType.Password:
                    this.GenerateNameEqualsValue("PASSWORD", node.PasswordOrSignature);
                    break;
            }
        }

        private void GenerateIdentifierWithPassword(CryptoMechanism node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Identifier);
            if (node.PasswordOrSignature != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                string name = (node.PasswordOrSignature.LiteralType == LiteralType.Binary) ? "SIGNATURE" : "PASSWORD";
                this.GenerateSpace();
                this.GenerateNameEqualsValue(name, node.PasswordOrSignature);
            }
        }

        public override void ExplicitVisit(CompressionDelayIndexOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
            if (node.TimeUnit != 0) {
                this.GenerateSpace();
                CompressionDelayTimeUnitHelper.Instance.GenerateSourceForOption(this._writer, node.TimeUnit);
            }
        }

        public SqlScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter writer) {
            this._options = options;
            this._writer = writer;
            this._alignmentPointsForFragments = new Dictionary<TSqlFragment, Dictionary<string, AlignmentPoint>>();
        }

        protected void NewLineAndIndent() {
            this.NewLine();
            this.Indent();
        }

        protected void Indent() {
            this.Indent(this._options.IndentationSize);
        }

        protected void NewLineAndIndent(int indentSize) {
            this.NewLine();
            this.Indent(indentSize);
        }

        protected void Indent(int indentSize) {
            this._writer.Indent(indentSize);
        }

        protected void Mark(AlignmentPoint ap) {
            this._writer.Mark(ap);
        }

        protected void NewLine() {
            this._writer.NewLine();
        }

        protected void PushAlignmentPoint(AlignmentPoint ap) {
            this._writer.PushNewLineAlignmentPoint(ap);
        }

        protected void PopAlignmentPoint() {
            this._writer.PopNewLineAlignmentPoint();
        }

        protected void MarkAndPushAlignmentPoint(AlignmentPoint ap) {
            this.Mark(ap);
            this.PushAlignmentPoint(ap);
        }

        protected AlignmentPoint FindOrCreateAlignmentPointByName(string apName) {
            return this._writer.FindOrCreateAlignmentPoint(apName);
        }

        protected void AddAlignmentPointForFragment(TSqlFragment node, AlignmentPoint ap) {
            if (node != null && ap != null && !string.IsNullOrEmpty(ap.Name)) {
                Dictionary<string, AlignmentPoint> dictionary = default(Dictionary<string, AlignmentPoint>);
                if (!this._alignmentPointsForFragments.TryGetValue(node, out dictionary)) {
                    dictionary = new Dictionary<string, AlignmentPoint>();
                    this._alignmentPointsForFragments.Add(node, dictionary);
                }
                if (!string.IsNullOrEmpty(ap.Name) && !dictionary.ContainsKey(ap.Name)) {
                    dictionary.Add(ap.Name, ap);
                }
            }
        }

        protected AlignmentPoint GetAlignmentPointForFragment(TSqlFragment node, string name) {
            AlignmentPoint result = null;
            Dictionary<string, AlignmentPoint> dictionary = default(Dictionary<string, AlignmentPoint>);
            if (node != null && !string.IsNullOrEmpty(name) && this._alignmentPointsForFragments.TryGetValue(node, out dictionary) && !dictionary.TryGetValue(name, out result)) {
                result = null;
            }
            return result;
        }

        protected void ClearAlignmentPointsForFragment(TSqlFragment node) {
            if (node != null) {
                this._alignmentPointsForFragments.Remove(node);
            }
        }

        public override void ExplicitVisit(CursorDefaultDatabaseOption node) {
            this.GenerateIdentifier("CURSOR_DEFAULT");
            this.GenerateSpaceAndIdentifier(node.IsLocal ? "LOCAL" : "GLOBAL");
        }

        public override void ExplicitVisit(CursorDefinition node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.Cursor);
            foreach (CursorOption option in node.Options) {
                if (option.OptionKind != CursorOptionKind.Insensitive) {
                    this.GenerateFragmentIfNotNull(option);
                }
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.For);
            this.GenerateSpace();
            this.MarkAndPushAlignmentPoint(ap);
            bool generateSemiColon = this._generateSemiColon;
            this._generateSemiColon = false;
            this.GenerateFragmentIfNotNull(node.Select);
            this._generateSemiColon = generateSemiColon;
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(CursorOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._cursorOptionsNames, node.OptionKind);
            this.GenerateSpaceAndIdentifier(valueForEnumKey);
        }

        public override void ExplicitVisit(CursorId node) {
            if (node.IsGlobal) {
                this.GenerateIdentifier("GLOBAL");
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DatabaseAuditAction node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._databaseAuditActionName, node.ActionKind);
            this.GenerateToken(valueForEnumKey);
        }

        public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            this.GenerateSpace();
            this.GenerateAuditSpecificationStatement(node);
        }

        public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            this.GenerateSpace();
            this.GenerateAuditSpecificationStatement(node);
        }

        public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            this.GenerateSpaceAndIdentifier("AUDIT");
            this.GenerateSpaceAndIdentifier("SPECIFICATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DatabaseConfigurationClearOption node) {
            DatabaseConfigClearOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
        }

        public override void ExplicitVisit(DatabaseConfigurationSetOption node) {
            DatabaseConfigSetOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
        }

        public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateDatabaseEncryptionKeyHeader();
            if (node.Regenerate) {
                this.GenerateSpaceAndIdentifier("REGENERATE");
            }
            this.GenerateSpace();
            this.GenerateDatabaseEncryptionKeyStatementBody(node);
        }

        public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateDatabaseEncryptionKeyHeader();
            this.GenerateSpace();
            this.GenerateDatabaseEncryptionKeyStatementBody(node);
        }

        public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateDatabaseEncryptionKeyHeader();
        }

        private void GenerateDatabaseEncryptionKeyHeader() {
            this.GenerateKeyword(TSqlTokenType.Database);
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
        }

        protected void GenerateDatabaseEncryptionKeyStatementBody(DatabaseEncryptionKeyStatement node) {
            if (node.Algorithm != 0) {
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("ALGORITHM");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
                DatabaseEncryptionKeyAlgorithmHelper.Instance.GenerateSourceForOption(this._writer, node.Algorithm);
            }
            if (node.Encryptor != null) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpaceAndIdentifier("SERVER");
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(node.Encryptor);
            }
        }

        public override void ExplicitVisit(DatabaseOption node) {
            SimpleDbOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
        }

        public override void ExplicitVisit(DataCompressionOption node) {
            this.GenerateTokenAndEqualSign("DATA_COMPRESSION");
            this.GenerateSpace();
            DataCompressionLevelHelper.Instance.GenerateSourceForOption(this._writer, node.CompressionLevel);
            if (node.PartitionRanges.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndIdentifier("PARTITIONS");
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.PartitionRanges);
            }
        }

        public override void ExplicitVisit(DataModificationTableReference node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DataModificationSpecification);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(DbccNamedLiteral node) {
            if (node.Name != null) {
                this.GenerateNameEqualsValue(node.Name, node.Value);
            } else {
                this.GenerateFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(DbccStatement node) {
            this.GenerateKeyword(TSqlTokenType.Dbcc);
            if (node.Command == DbccCommand.Free) {
                this.GenerateSpace();
                this.GenerateIdentifierWithoutCasing(node.DllName);
            } else {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._dbccCommandNames, node.Command);
                if (valueForEnumKey != null) {
                    this.GenerateSpaceAndIdentifier(valueForEnumKey);
                }
            }
            if (node.ParenthesisRequired || node.Literals.Count > 0) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateCommaSeparatedList(node.Literals);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
            if (node.Options != null && node.Options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                if (node.OptionsUseJoin) {
                    this.GenerateJoinSeparatedList(node.Options);
                } else {
                    this.GenerateCommaSeparatedList(node.Options);
                }
            }
        }

        public override void ExplicitVisit(DbccOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._dbccOptionsGenerators, node.OptionKind);
            this.GenerateToken(valueForEnumKey);
        }

        protected void GenerateJoinSeparatedList<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateList(list, delegate {
                this.GenerateSpace();
                this.GenerateSymbol(TSqlTokenType.Join);
                this.GenerateSpace();
            });
        }

        public override void ExplicitVisit(DeallocateCursorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Deallocate);
            this.GenerateSpaceAndFragmentIfNotNull(node.Cursor);
        }

        public override void ExplicitVisit(DeclareCursorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Declare);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.CursorDefinition != null && node.CursorDefinition.Options != null) {
                foreach (CursorOption option in node.CursorDefinition.Options) {
                    if (option.OptionKind == CursorOptionKind.Insensitive) {
                        this.GenerateFragmentIfNotNull(option);
                    }
                }
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.CursorDefinition);
        }

        public override void ExplicitVisit(DeclareTableVariableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Declare);
            this.GenerateSpaceAndFragmentIfNotNull(node.Body);
        }

        public override void ExplicitVisit(DeclareTableVariableBody node) {
            this.GenerateFragmentIfNotNull(node.VariableName);
            if (node.AsDefined) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.NewLineAndIndent();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateCommaSeparatedList(node.Definition.ColumnDefinitions, true);
            if (node.Definition.ColumnDefinitions != null && node.Definition.ColumnDefinitions.Count > 0 && node.Definition.TableConstraints != null && node.Definition.TableConstraints.Count > 0) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.NewLine();
            }
            this.GenerateCommaSeparatedList(node.Definition.TableConstraints, true);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            this.GenerateFragmentIfNotNull(node.VariableName);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSpaceAndFragmentIfNotNull(node.Nullable);
            if (node.Value != null) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(DeclareVariableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Declare);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Declarations);
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node) {
            this.GenerateConstraintHead(node);
            this.GenerateKeywordAndSpace(TSqlTokenType.Default);
            this.GenerateFragmentIfNotNull(node.Expression);
            if (node.Column != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndFragmentIfNotNull(node.Column);
            }
            if (node.WithValues) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Values);
            }
        }

        public override void ExplicitVisit(DelayedDurabilityDatabaseOption node) {
            this.GenerateIdentifier("DELAYED_DURABILITY");
            this.GenerateSpace();
            this.GenerateSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            DelayedDurabilityOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(DeleteStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
            this.MarkAndPushAlignmentPoint(ap);
            if (node.WithCtesAndXmlNamespaces != null) {
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WithCtesAndXmlNamespaces, ap2);
                this.NewLine();
            }
            this.GenerateFragmentIfNotNull(node.DeleteSpecification);
            this.GenerateOptimizerHints(node.OptimizerHints);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(DeleteSpecification node) {
            AlignmentPoint alignmentPoint = new AlignmentPoint("ClauseBody");
            this.GenerateKeyword(TSqlTokenType.Delete);
            if (node.TopRowFilter != null) {
                this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPoint);
                this.GenerateSpaceAndFragmentIfNotNull(node.TopRowFilter);
                this.NewLine();
            }
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPoint);
            this.GenerateSpaceAndFragmentIfNotNull(node.Target);
            if (node.OutputIntoClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputIntoClause, alignmentPoint);
            }
            if (node.OutputClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputClause, alignmentPoint);
            }
            this.GenerateFromClause(node.FromClause, alignmentPoint);
            if (node.WhereClause != null) {
                this.GenerateSeparatorForWhereClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WhereClause, alignmentPoint);
            }
        }

        public override void ExplicitVisit(DenyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Deny);
            this.GenerateSpace();
            this.GeneratePermissionOnToClauses(node);
            if (node.CascadeOption) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Cascade);
            }
            this.GenerateAsClause(node);
        }

        public override void ExplicitVisit(DenyStatement80 node) {
            this.GenerateKeyword(TSqlTokenType.Deny);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityElement80);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityUserClause80);
            if (node.CascadeOption) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.Cascade);
            }
        }

        public override void ExplicitVisit(QueryDerivedTable node) {
            this.GenerateQueryExpressionInParentheses(node.QueryExpression);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(InlineDerivedTable node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateSymbolAndSpace(TSqlTokenType.Values);
            this.GenerateCommaSeparatedList(node.RowValues);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(DeviceInfo node) {
            if (node.LogicalDevice != null) {
                this.GenerateFragmentIfNotNull(node.LogicalDevice);
            } else {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._deviceTypeGenerators, node.DeviceType);
                if (valueForEnumKey != null) {
                    this.GenerateNameEqualsValue(valueForEnumKey, node.PhysicalDevice);
                }
            }
        }

        public override void ExplicitVisit(MirrorToClause node) {
            this.GenerateIdentifier("MIRROR");
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Devices);
        }

        public override void ExplicitVisit(DiskStatement node) {
            this.GenerateIdentifier("DISK");
            switch (node.DiskStatementType) {
                case DiskStatementType.Init:
                    this.GenerateSpaceAndIdentifier("INIT");
                    break;
                case DiskStatementType.Resize:
                    this.GenerateSpaceAndIdentifier("RESIZE");
                    break;
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(DiskStatementOption node) {
            DiskStatementOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            this.GenerateSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(DropAggregateStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("AGGREGATE");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropApplicationRoleStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("APPLICATION");
            this.GenerateSpaceAndIdentifier("ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropAssemblyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("ASSEMBLY");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
            if (node.WithNoDependents) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("NO");
                this.GenerateSpaceAndIdentifier("DEPENDENTS");
            }
        }

        public override void ExplicitVisit(DropAvailabilityGroupStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateIdentifier("AVAILABILITY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropBrokerPriorityStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("BROKER");
            this.GenerateSpaceAndIdentifier("PRIORITY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropCertificateStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("CERTIFICATE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        protected void GenerateOptionHeader(DropClusteredConstraintOption node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._dropClusteredConstraintOptionTypeGenerators, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(DropClusteredConstraintValueOption node) {
            this.GenerateOptionHeader(node);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(DropClusteredConstraintMoveOption node) {
            this.GenerateOptionHeader(node);
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node) {
            this.GenerateLowPriorityWaitOptions(node.Options);
        }

        public override void ExplicitVisit(DropClusteredConstraintStateOption node) {
            this.GenerateOptionHeader(node);
            this.GenerateSpace();
            this.GenerateOptionStateOnOff(node.OptionState);
        }

        public override void ExplicitVisit(DropColumnEncryptionKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("COLUMN");
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndIdentifier("KEY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropColumnMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("COLUMN");
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndIdentifier("KEY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropContractStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("CONTRACT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropCredentialStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            if (node.IsDatabaseScoped) {
                this.GenerateSpaceAndIdentifier("DATABASE");
                this.GenerateSpaceAndIdentifier("SCOPED");
            }
            this.GenerateSpaceAndIdentifier("CREDENTIAL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropDatabaseStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Databases);
        }

        public override void ExplicitVisit(DropDefaultStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropEndpointStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("ENDPOINT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropExternalDataSourceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("DATA");
            this.GenerateSpaceAndIdentifier("SOURCE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropExternalFileFormatStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("FILE");
            this.GenerateSpaceAndIdentifier("FORMAT");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropExternalResourcePoolStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("RESOURCE");
            this.GenerateSpaceAndIdentifier("POOL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropExternalTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("EXTERNAL");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropEventNotificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("EVENT");
            this.GenerateSpaceAndIdentifier("NOTIFICATION");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Notifications);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.Scope);
        }

        public override void ExplicitVisit(DropFederationStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateIdentifier("FEDERATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropFullTextCatalogStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndIdentifier("CATALOG");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropFullTextIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.TableName);
        }

        public override void ExplicitVisit(DropFullTextStopListStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("FULLTEXT");
            this.GenerateSpaceAndKeyword(TSqlTokenType.StopList);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropFunctionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Function);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropIndexClause node) {
            this.GenerateFragmentIfNotNull(node.Index);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.Object);
            this.GenerateCommaSeparatedWithClause(node.Options, true, true);
        }

        public override void ExplicitVisit(MoveToDropIndexOption node) {
            this.GenerateIdentifier("MOVE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.MoveTo);
        }

        public override void ExplicitVisit(FileStreamOnDropIndexOption node) {
            this.GenerateIdentifier("FILESTREAM_ON");
            this.GenerateSpaceAndFragmentIfNotNull(node.FileStreamOn);
        }

        public override void ExplicitVisit(DropIndexStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.DropIndexClauses);
        }

        public override void ExplicitVisit(DropLoginStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("LOGIN");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
        }

        public override void ExplicitVisit(DropMessageTypeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("MESSAGE");
            this.GenerateSpaceAndIdentifier("TYPE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropPartitionFunctionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Function);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropPartitionSchemeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("PARTITION");
            this.GenerateSpaceAndIdentifier("SCHEME");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropProcedureStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Procedure);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropQueueStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("QUEUE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropRemoteServiceBindingStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("REMOTE");
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndIdentifier("BINDING");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropResourcePoolStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("RESOURCE");
            this.GenerateSpaceAndIdentifier("POOL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropRoleStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("ROLE");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropRouteStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("ROUTE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropRuleStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Rule);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropSchemaStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Schema);
            if (node.DropBehavior == DropSchemaBehavior.Cascade) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Cascade);
            } else if (node.DropBehavior == DropSchemaBehavior.Restrict) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Restrict);
            }
        }

        public override void ExplicitVisit(DropSearchPropertyListStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Drop, "SEARCH", "PROPERTY", "LIST");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropSecurityPolicyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("SECURITY");
            this.GenerateSpaceAndIdentifier("POLICY");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropSequenceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("SEQUENCE");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropServerRoleStatement node) {
            this.GenerateSpaceSeparatedTokens(TSqlTokenType.Drop, "SERVER", "ROLE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropServiceStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("SERVICE");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropSignatureStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateCounterSignature(node);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpace();
            this.GenerateModule(node);
            this.NewLineAndIndent();
            this.GenerateCryptos(node);
        }

        public override void ExplicitVisit(DropStatisticsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Statistics);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropSynonymStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("SYNONYM");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropTriggerStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Trigger);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
            switch (node.TriggerScope) {
                case TriggerScope.Normal:
                    break;
                case TriggerScope.Database:
                    this.NewLineAndIndent();
                    this.GenerateKeyword(TSqlTokenType.On);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                    break;
                case TriggerScope.AllServer:
                    this.NewLineAndIndent();
                    this.GenerateKeyword(TSqlTokenType.On);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.All);
                    this.GenerateSpaceAndIdentifier("SERVER");
                    break;
            }
        }

        public override void ExplicitVisit(DropTypeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("TYPE");
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropUserStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.User);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropViewStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndKeyword(TSqlTokenType.View);
            if (node.IsIfExists) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.If);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Exists);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Objects);
        }

        public override void ExplicitVisit(DropWorkloadGroupStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("WORKLOAD");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DropXmlSchemaCollectionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("XML");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
            this.GenerateSpaceAndIdentifier("COLLECTION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(DurabilityTableOption node) {
            this.GenerateTokenAndEqualSign("DURABILITY");
            switch (node.DurabilityTableOptionKind) {
                case DurabilityTableOptionKind.SchemaAndData:
                    this.GenerateSpaceAndIdentifier("SCHEMA_AND_DATA");
                    break;
                case DurabilityTableOptionKind.SchemaOnly:
                    this.GenerateSpaceAndIdentifier("SCHEMA_ONLY");
                    break;
            }
        }

        public override void ExplicitVisit(EnabledDisabledPayloadOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._payloadOptionKindsGenerators, node.Kind);
            if (valueForEnumKey != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.IsEnabled ? "ENABLED" : "DISABLED");
            }
        }

        public override void ExplicitVisit(EnableDisableTriggerStatement node) {
            this.GenerateTriggerEnforcement(node.TriggerEnforcement);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Trigger);
            this.GenerateSpace();
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            } else {
                this.GenerateCommaSeparatedList(node.TriggerNames);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.TriggerObject);
        }

        public override void ExplicitVisit(EncryptedValueParameter node) {
            this.GenerateSpaceAndIdentifier("ENCRYPTED_VALUE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(EncryptionPayloadOption node) {
            this.GenerateTokenAndEqualSign("ENCRYPTION");
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._endpointEncryptionSupportGenerators, node.EncryptionSupport);
            if (valueForEnumKey != null) {
                this.GenerateSpace();
                this.GenerateToken(valueForEnumKey);
            }
            if (node.EncryptionSupport != EndpointEncryptionSupport.Disabled && node.EncryptionSupport != 0) {
                if (node.AlgorithmPartOne != 0 || node.AlgorithmPartTwo != 0) {
                    this.GenerateSpaceAndIdentifier("ALGORITHM");
                }
                this.GenerateSpaceAndAlgorithm(node.AlgorithmPartOne);
                this.GenerateSpaceAndAlgorithm(node.AlgorithmPartTwo);
            }
        }

        private void GenerateSpaceAndAlgorithm(EncryptionAlgorithmPreference alg) {
            switch (alg) {
                case EncryptionAlgorithmPreference.NotSpecified:
                    break;
                case EncryptionAlgorithmPreference.Aes:
                    this.GenerateSpaceAndIdentifier("AES");
                    break;
                case EncryptionAlgorithmPreference.Rc4:
                    this.GenerateSpaceAndIdentifier("RC4");
                    break;
            }
        }

        public override void ExplicitVisit(AssemblyEncryptionSource node) {
            this.GenerateIdentifier("ASSEMBLY");
            this.GenerateSpaceAndFragmentIfNotNull(node.Assembly);
        }

        public override void ExplicitVisit(FileEncryptionSource node) {
            if (node.IsExecutable) {
                this.GenerateIdentifier("EXECUTABLE");
                this.GenerateSpace();
            }
            this.GenerateNameEqualsValue(TSqlTokenType.File, node.File);
        }

        public override void ExplicitVisit(ProviderEncryptionSource node) {
            this.GenerateIdentifier("PROVIDER");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.KeyOptions.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.KeyOptions);
            }
        }

        public override void ExplicitVisit(EndConversationStatement node) {
            this.GenerateKeyword(TSqlTokenType.End);
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Conversation);
            if (node.WithCleanup) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("CLEANUP");
            } else if (node.ErrorCode != null && node.ErrorDescription != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("ERROR", node.ErrorCode);
                this.GenerateSpace();
                this.GenerateNameEqualsValue("DESCRIPTION", node.ErrorDescription);
            }
        }

        public override void ExplicitVisit(EndpointAffinity node) {
            switch (node.Kind) {
                case AffinityKind.Admin:
                    this.GenerateNameEqualsValue("AFFINITY", "ADMIN");
                    break;
                case AffinityKind.None:
                    this.GenerateNameEqualsValue("AFFINITY", "NONE");
                    break;
                case AffinityKind.Integer:
                    this.GenerateNameEqualsValue("AFFINITY", node.Value);
                    break;
            }
        }

        public override void ExplicitVisit(EventGroupContainer node) {
            if (!AuditEventGroupHelper.Instance.TryGenerateSourceForOption(this._writer, node.EventGroup)) {
                TriggerEventGroupHelper.Instance.GenerateSourceForOption(this._writer, node.EventGroup);
            }
        }

        public override void ExplicitVisit(EventNotificationObjectScope node) {
            switch (node.Target) {
                case EventNotificationTarget.Server:
                    this.GenerateIdentifier("SERVER");
                    break;
                case EventNotificationTarget.Database:
                    this.GenerateKeyword(TSqlTokenType.Database);
                    break;
                case EventNotificationTarget.Queue:
                    this.GenerateIdentifier("QUEUE");
                    this.GenerateSpaceAndFragmentIfNotNull(node.QueueName);
                    break;
            }
        }

        public override void ExplicitVisit(CreateEventSessionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateEventSessionParameters(node);
            this.GenerateEventDeclarations(node);
            this.GenerateTargetDeclarations(node);
            this.GenerateEventSessionOptions(node);
        }

        public void GenerateEventSessionParameters(EventSessionStatement node) {
            this.GenerateIdentifier("EVENT");
            this.GenerateSpaceAndIdentifier("SESSION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            switch (node.SessionScope) {
                case EventSessionScope.Server:
                    this.GenerateSpaceAndIdentifier("SERVER");
                    break;
                case EventSessionScope.Database:
                    this.GenerateSpaceAndIdentifier("DATABASE");
                    break;
                default:
                    throw new InvalidOperationException("Unexpected value for EventSessionScope: " + node.SessionScope.ToString());
            }
            this.GenerateSpace();
        }

        public void GenerateEventDeclarations(EventSessionStatement node) {
            if (node.EventDeclarations != null && node.EventDeclarations.Count > 0) {
                this.GenerateCommaSeparatedList(node.EventDeclarations);
            }
        }

        public void GenerateTargetDeclarations(EventSessionStatement node) {
            if (node.TargetDeclarations != null && node.TargetDeclarations.Count > 0) {
                if (node is CreateEventSessionStatement) {
                    this.GenerateSpace();
                }
                this.GenerateCommaSeparatedList(node.TargetDeclarations);
            }
        }

        public void GenerateEventSessionOptions(EventSessionStatement node) {
            if (node.SessionOptions != null && node.SessionOptions.Count > 0) {
                this.NewLine();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.SessionOptions, 2);
            }
        }

        public override void ExplicitVisit(EventDeclaration node) {
            this.NewLine();
            this.GenerateKeywordAndSpace(TSqlTokenType.Add);
            this.GenerateIdentifier("EVENT");
            this.GenerateSpaceAndFragmentIfNotNull(node.ObjectName);
            if (node.EventDeclarationSetParameters.Count > 0 || node.EventDeclarationActionParameters.Count > 0 || node.EventDeclarationPredicateParameter != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            }
            if (node.EventDeclarationSetParameters != null && node.EventDeclarationSetParameters.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.Set);
                this.GenerateFragmentList(node.EventDeclarationSetParameters, ListGenerationOption.MultipleLineSelectElementOption);
            }
            if (node.EventDeclarationActionParameters != null && node.EventDeclarationActionParameters.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("ACTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentList(node.EventDeclarationActionParameters, ListGenerationOption.MultipleLineSelectElementOption);
                this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            }
            if (node.EventDeclarationPredicateParameter != null) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.Where);
                this.GenerateFragmentIfNotNull(node.EventDeclarationPredicateParameter);
            }
            if (node.EventDeclarationSetParameters.Count <= 0 && node.EventDeclarationActionParameters.Count <= 0 && node.EventDeclarationPredicateParameter == null) {
                return;
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(EventDeclarationSetParameter node) {
            this.GenerateFragmentIfNotNull(node.EventField);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
            this.GenerateFragmentIfNotNull(node.EventValue);
        }

        public override void ExplicitVisit(EventSessionObjectName node) {
            this.GenerateFragmentIfNotNull(node.MultiPartIdentifier);
        }

        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node) {
            this.GenerateFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.SourceDeclaration);
            this.GenerateKeyword(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.EventValue);
            this.GenerateKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(TargetDeclaration node) {
            this.NewLine();
            this.GenerateKeywordAndSpace(TSqlTokenType.Add);
            this.GenerateIdentifier("TARGET");
            this.GenerateSpaceAndFragmentIfNotNull(node.ObjectName);
            if (node.TargetDeclarationParameters != null && node.TargetDeclarationParameters.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.Set);
                this.GenerateFragmentList(node.TargetDeclarationParameters, ListGenerationOption.MultipleLineSelectElementOption);
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(LiteralSessionOption node) {
            switch (node.OptionKind) {
                case SessionOptionKind.MaxMemory:
                    this.GenerateIdentifier("MAX_MEMORY");
                    break;
                case SessionOptionKind.MaxEventSize:
                    this.GenerateIdentifier("MAX_EVENT_SIZE");
                    break;
            }
            this.GenerateIntegerValueSessionOption(node);
        }

        public override void ExplicitVisit(MaxDispatchLatencySessionOption node) {
            this.GenerateIdentifier("MAX_DISPATCH_LATENCY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.IsInfinite) {
                this.GenerateIdentifier("INFINITE");
            } else {
                this.GenerateFragmentIfNotNull(node.Value);
                this.GenerateSpace();
                this.GenerateIdentifier("SECONDS");
            }
        }

        public void GenerateIntegerValueSessionOption(LiteralSessionOption node) {
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.Value);
            this.GenerateSpace();
            SessionOptionUnitHelper.Instance.GenerateSourceForOption(this._writer, node.Unit);
        }

        public override void ExplicitVisit(OnOffSessionOption node) {
            switch (node.OptionKind) {
                case SessionOptionKind.TrackCausality:
                    this.GenerateOptionState("TRACK_CAUSALITY", node.OptionState, true);
                    break;
                case SessionOptionKind.StartUpState:
                    this.GenerateOptionState("STARTUP_STATE", node.OptionState, true);
                    break;
            }
        }

        public override void ExplicitVisit(EventRetentionSessionOption node) {
            this.GenerateIdentifier("EVENT_RETENTION_MODE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            EventSessionEventRetentionModeTypeHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(MemoryPartitionSessionOption node) {
            this.GenerateIdentifier("MEMORY_PARTITION_MODE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            EventSessionMemoryPartitionModeTypeHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(AlterEventSessionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateEventSessionParameters(node);
            switch (node.StatementType) {
                case AlterEventSessionStatementType.AddEventDeclarationOptionalSessionOptions:
                    this.GenerateEventDeclarations(node);
                    this.GenerateEventSessionOptions(node);
                    break;
                case AlterEventSessionStatementType.AddTargetDeclarationOptionalSessionOptions:
                    this.GenerateTargetDeclarations(node);
                    this.GenerateEventSessionOptions(node);
                    break;
                case AlterEventSessionStatementType.DropEventSpecificationOptionalSessionOptions:
                    this.GenerateCommaSeparatedDropDeclarations(node.DropEventDeclarations, "EVENT");
                    this.GenerateEventSessionOptions(node);
                    break;
                case AlterEventSessionStatementType.DropTargetSpecificationOptionalSessionOptions:
                    this.GenerateCommaSeparatedDropDeclarations(node.DropTargetDeclarations, "TARGET");
                    this.GenerateEventSessionOptions(node);
                    break;
                case AlterEventSessionStatementType.RequiredSessionOptions:
                    this.GenerateEventSessionOptions(node);
                    break;
                case AlterEventSessionStatementType.AlterStateIsStart:
                    this.NewLine();
                    this.GenerateNameEqualsValue("STATE", "START");
                    break;
                case AlterEventSessionStatementType.AlterStateIsStop:
                    this.NewLine();
                    this.GenerateNameEqualsValue("STATE", "STOP");
                    break;
            }
        }

        public override void ExplicitVisit(DropEventSessionStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateIdentifier("EVENT");
            this.GenerateSpaceAndIdentifier("SESSION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            switch (node.SessionScope) {
                case EventSessionScope.Server:
                    this.GenerateSpaceAndIdentifier("SERVER");
                    break;
                case EventSessionScope.Database:
                    this.GenerateSpaceAndIdentifier("DATABASE");
                    break;
                default:
                    throw new InvalidOperationException("Unexpected value for EventSessionScope: " + node.SessionScope.ToString());
            }
        }

        public void GenerateCommaSeparatedDropDeclarations<T>(IList<T> list, string declaration) where T : TSqlFragment {
            if (list != null) {
                bool flag = true;
                foreach (T item in (IEnumerable<T>)list) {
                    if (flag) {
                        this.NewLine();
                        this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
                        this.GenerateIdentifier(declaration);
                        flag = false;
                    } else {
                        this.GenerateKeyword(TSqlTokenType.Comma);
                        this.NewLine();
                        this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
                        this.GenerateIdentifier(declaration);
                    }
                    this.GenerateSpaceAndFragmentIfNotNull((TSqlFragment)(object)item);
                }
            }
        }

        public override void ExplicitVisit(EventTypeContainer node) {
            if (!AuditEventTypeHelper.Instance.TryGenerateSourceForOption(this._writer, node.EventType)) {
                TriggerEventTypeHelper.Instance.GenerateSourceForOption(this._writer, node.EventType);
            }
        }

        protected void GenerateParameters(ExecutableEntity node) {
            this.GenerateCommaSeparatedList(node.Parameters);
        }

        public override void ExplicitVisit(ExecutableProcedureReference node) {
            if (node.AdHocDataSource != null) {
                this.GenerateFragmentIfNotNull(node.AdHocDataSource);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            this.GenerateFragmentIfNotNull(node.ProcedureReference);
            this.GenerateSpace();
            this.GenerateParameters(node);
        }

        public override void ExplicitVisit(ExecutableStringList node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            for (int i = 0; i < node.Strings.Count; i++) {
                if (i > 0) {
                    this.GenerateSpaceAndSymbol(TSqlTokenType.Plus);
                    this.GenerateSpace();
                }
                this.GenerateFragmentIfNotNull(node.Strings[i]);
            }
            if (node.Parameters.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateParameters(node);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ExecuteAsClause node) {
            this.GenerateKeyword(TSqlTokenType.Execute);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            switch (node.ExecuteAsOption) {
                case ExecuteAsOption.Caller:
                    this.GenerateSpaceAndIdentifier("CALLER");
                    break;
                case ExecuteAsOption.Self:
                    this.GenerateSpaceAndIdentifier("SELF");
                    break;
                case ExecuteAsOption.Owner:
                    this.GenerateSpaceAndIdentifier("OWNER");
                    break;
                case ExecuteAsOption.String:
                case ExecuteAsOption.Login:
                case ExecuteAsOption.User:
                    this.GenerateSpaceAndFragmentIfNotNull(node.Literal);
                    break;
            }
        }

        public override void ExplicitVisit(ExecuteAsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Execute);
            this.GenerateSpaceAndFragmentIfNotNull(node.ExecuteContext);
            if (node.WithNoRevert) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("NO");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Revert);
            } else if (node.Cookie != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("COOKIE");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Into);
                this.GenerateSpaceAndFragmentIfNotNull(node.Cookie);
            }
        }

        public override void ExplicitVisit(ExecuteContext node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.As);
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._executeAsOptionGenerators, node.Kind);
            if (node.Principal != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.Principal);
            } else {
                this.GenerateToken(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ExecuteParameter node) {
            if (node.Variable != null) {
                this.GenerateFragmentIfNotNull(node.Variable);
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
            }
            if (node.ParameterValue != null) {
                this.GenerateFragmentIfNotNull(node.ParameterValue);
            }
            if (node.IsOutput) {
                this.GenerateSpaceAndIdentifier("OUTPUT");
            }
        }

        public override void ExplicitVisit(ExecuteStatement node) {
            this.GenerateKeyword(TSqlTokenType.Execute);
            this.GenerateExecuteSpecificationBody(node.ExecuteSpecification);
            this.GenerateCommaSeparatedWithClause(node.Options, true, false);
        }

        public override void ExplicitVisit(ExecuteSpecification node) {
            this.GenerateKeyword(TSqlTokenType.Execute);
            this.GenerateExecuteSpecificationBody(node);
        }

        private void GenerateExecuteSpecificationBody(ExecuteSpecification node) {
            if (node != null) {
                if (node.Variable != null) {
                    this.GenerateSpaceAndFragmentIfNotNull(node.Variable);
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                }
                this.GenerateSpaceAndFragmentIfNotNull(node.ExecutableEntity);
                this.GenerateSpaceAndFragmentIfNotNull(node.ExecuteContext);
                if (node.LinkedServer != null) {
                    this.GenerateSpaceAndIdentifier("AT");
                    this.GenerateSpaceAndFragmentIfNotNull(node.LinkedServer);
                }
            }
        }

        public override void ExplicitVisit(ExecuteOption node) {
            this.GenerateIdentifier("RECOMPILE");
        }

        public override void ExplicitVisit(ExistsPredicate node) {
            this.GenerateKeyword(TSqlTokenType.Exists);
            this.GenerateSpaceAndFragmentIfNotNull(node.Subquery);
        }

        public override void ExplicitVisit(ExpressionWithSortOrder node) {
            this.GenerateFragmentIfNotNull(node.Expression);
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._sortOrderGenerators, node.SortOrder);
            if (valueForEnumKey != null && node.SortOrder != 0) {
                this.GenerateSpace();
                this.GenerateToken(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node) {
            ExternalDataSourceOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(ExternalFileFormatContainerOption node) {
            ExternalFileFormatOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            if (node.Suboptions.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Suboptions);
            }
        }

        public override void ExplicitVisit(ExternalFileFormatLiteralOption node) {
            ExternalFileFormatOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._externalFileFormatUseDefaultTypeNames, node.ExternalFileFormatUseDefaultType);
            if (!string.IsNullOrEmpty(valueForEnumKey)) {
                this.GenerateNameEqualsValue("USE_TYPE_DEFAULT", valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ExternalTableColumnDefinition node) {
            this.GenerateFragmentIfNotNull(node.ColumnDefinition.ColumnIdentifier);
            this.GenerateSpaceAndFragmentIfNotNull(node.ColumnDefinition.DataType);
            if (node.ColumnDefinition.Collation != null) {
                this.GenerateSpaceAndCollation(node.ColumnDefinition.Collation);
            }
            if (node.NullableConstraint != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.NullableConstraint);
            }
        }

        public override void ExplicitVisit(ExternalResourcePoolParameter node) {
            ExternalResourcePoolParameterHelper.Instance.GenerateSourceForOption(this._writer, node.ParameterType);
            if (node.ParameterType != ExternalResourcePoolParameterType.Affinity) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.ParameterValue);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.AffinitySpecification);
            }
        }

        public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node) {
            ExternalResourcePoolAffinityHelper.Instance.GenerateSourceForOption(this._writer, node.AffinityType);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.IsAuto) {
                this.GenerateIdentifier("AUTO");
            } else if (node.PoolAffinityRanges != null && node.PoolAffinityRanges.Count > 0) {
                this.GenerateParenthesisedCommaSeparatedList(node.PoolAffinityRanges);
            }
        }

        protected void GenerateExternalResourcePoolStatementBody(ExternalResourcePoolStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateIdentifier("EXTERNAL");
            this.GenerateSpaceAndIdentifier("RESOURCE");
            this.GenerateSpaceAndIdentifier("POOL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.ExternalResourcePoolParameters != null && node.ExternalResourcePoolParameters.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.ExternalResourcePoolParameters, 2);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(ExternalTableDistributionOption node) {
            this.GenerateNameEqualsValue("DISTRIBUTION", node.Value);
        }

        public override void ExplicitVisit(TableDistributionOption node) {
            TableOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(TableIndexOption node) {
            this.GenerateFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(TablePartitionOption node) {
            TableOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.PartitionColumn);
            this.GenerateFragmentIfNotNull(node.PartitionOptionSpecs);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(TablePartitionOptionSpecifications node) {
            this.GenerateSpaceAndIdentifier("RANGE");
            switch (node.Range) {
                case PartitionTableOptionRange.Left:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Left);
                    break;
                case PartitionTableOptionRange.Right:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Right);
                    break;
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Values);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.BoundaryValues, true);
        }

        public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node) {
            ExternalTableOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(ExternalTableRejectTypeOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._externalTableRejectTypeNames, node.Value);
            if (!string.IsNullOrEmpty(valueForEnumKey)) {
                this.GenerateNameEqualsValue("REJECT_TYPE", valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node) {
            this.GenerateIdentifier("REPLICATED");
        }

        public override void ExplicitVisit(TableReplicateDistributionPolicy node) {
            this.GenerateIdentifier("REPLICATE");
        }

        public override void ExplicitVisit(TableClusteredIndexType node) {
            this.GenerateIdentifier("CLUSTERED");
            if (node.ColumnStore) {
                this.GenerateSpaceAndIdentifier("COLUMNSTORE");
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Index);
            if (!node.ColumnStore) {
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
        }

        public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node) {
            this.GenerateIdentifier("ROUND_ROBIN");
        }

        public override void ExplicitVisit(TableRoundRobinDistributionPolicy node) {
            this.GenerateIdentifier("ROUND_ROBIN");
        }

        public override void ExplicitVisit(TableNonClusteredIndexType node) {
            this.GenerateIdentifier("HEAP");
        }

        public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node) {
            this.GenerateIdentifier("SHARDED");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.ShardingColumn);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(TableHashDistributionPolicy node) {
            this.GenerateIdentifier("HASH");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DistributionColumn);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ExtractFromExpression node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.ExtractedElement);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(FetchCursorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Fetch);
            if (node.FetchType != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.FetchType);
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Cursor);
            if (node.IntoVariables.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Into);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.IntoVariables);
            }
        }

        public override void ExplicitVisit(FetchType node) {
            if (node.Orientation != 0) {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._fetchOrientationNames, node.Orientation);
                if (valueForEnumKey != null) {
                    this.GenerateIdentifier(valueForEnumKey);
                    if (node.Orientation != FetchOrientation.Absolute && node.Orientation != FetchOrientation.Relative) {
                        return;
                    }
                    this.GenerateSpaceAndFragmentIfNotNull(node.RowOffset);
                }
            }
        }

        public override void ExplicitVisit(FileDeclaration node) {
            if (node.IsPrimary) {
                this.GenerateKeyword(TSqlTokenType.Primary);
            }
            this.GenerateParenthesisedCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(NameFileDeclarationOption node) {
            string name = node.IsNewName ? "NEWNAME" : "NAME";
            this.GenerateNameEqualsValue(name, node.LogicalFileName);
        }

        public override void ExplicitVisit(FileNameFileDeclarationOption node) {
            this.GenerateNameEqualsValue("FILENAME", node.OSFileName);
        }

        public override void ExplicitVisit(SizeFileDeclarationOption node) {
            this.GenerateNameEqualsValue("SIZE", node.Size);
            this.GenerateSpaceAndMemoryUnit(node.Units);
        }

        public override void ExplicitVisit(MaxSizeFileDeclarationOption node) {
            if (node.MaxSize != null) {
                this.GenerateNameEqualsValue("MAXSIZE", node.MaxSize);
                this.GenerateSpaceAndMemoryUnit(node.Units);
            }
            if (node.Unlimited) {
                this.GenerateNameEqualsValue("MAXSIZE", "UNLIMITED");
            }
        }

        public override void ExplicitVisit(FileGrowthFileDeclarationOption node) {
            this.GenerateNameEqualsValue("FILEGROWTH", node.GrowthIncrement);
            this.GenerateSpaceAndMemoryUnit(node.Units);
        }

        public override void ExplicitVisit(FileDeclarationOption node) {
            FileDeclarationOptionKind optionKind = node.OptionKind;
            if (optionKind == FileDeclarationOptionKind.Offline) {
                this.GenerateIdentifier("OFFLINE");
            }
        }

        public override void ExplicitVisit(FileGroupDefinition node) {
            this.NewLineAndIndent();
            if (node.Name != null) {
                this.GenerateIdentifier("FILEGROUP");
                this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            }
            if (node.ContainsFileStream) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Contains);
                this.GenerateSpaceAndIdentifier("FILESTREAM");
            }
            if (node.ContainsMemoryOptimizedData) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Contains);
                this.GenerateSpaceAndIdentifier("MEMORY_OPTIMIZED_DATA");
            }
            if (node.IsDefault) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Default);
            }
            this.GenerateCommaSeparatedList(node.FileDeclarations);
        }

        public override void ExplicitVisit(FileGroupOrPartitionScheme node) {
            this.GenerateFragmentIfNotNull(node.Name);
            if (node.PartitionSchemeColumns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.PartitionSchemeColumns);
            }
        }

        public override void ExplicitVisit(FileStreamDatabaseOption node) {
            this.GenerateIdentifier("FILESTREAM");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            if (node.NonTransactedAccess.HasValue) {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._nonTransactedFileStreamAccessNames, node.NonTransactedAccess.Value);
                this.GenerateNameEqualsValue("NON_TRANSACTED_ACCESS", valueForEnumKey);
            }
            if (node.NonTransactedAccess.HasValue && node.DirectoryName != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpace();
            }
            if (node.DirectoryName != null) {
                this.GenerateNameEqualsValue("DIRECTORY_NAME", node.DirectoryName);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(FileStreamOnTableOption node) {
            this.GenerateIdentifier("FILESTREAM_ON");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(FileTableCollateFileNameTableOption node) {
            this.GenerateNameEqualsValue("FILETABLE_COLLATE_FILENAME", node.Value);
        }

        public override void ExplicitVisit(FileTableConstraintNameTableOption node) {
            switch (node.OptionKind) {
                case TableOptionKind.FileTableFullPathUniqueConstraintName:
                    this.GenerateNameEqualsValue("FILETABLE_FULLPATH_UNIQUE_CONSTRAINT_NAME", node.Value);
                    break;
                case TableOptionKind.FileTablePrimaryKeyConstraintName:
                    this.GenerateNameEqualsValue("FILETABLE_PRIMARY_KEY_CONSTRAINT_NAME", node.Value);
                    break;
                case TableOptionKind.FileTableStreamIdUniqueConstraintName:
                    this.GenerateNameEqualsValue("FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME", node.Value);
                    break;
            }
        }

        public override void ExplicitVisit(FileTableDirectoryTableOption node) {
            this.GenerateNameEqualsValue("FILETABLE_DIRECTORY", node.Value);
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node) {
            this.GenerateConstraintHead(node);
            this.GenerateKeyword(TSqlTokenType.Foreign);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            if (node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.References);
            this.GenerateSpaceAndFragmentIfNotNull(node.ReferenceTableName);
            if (node.ReferencedTableColumns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.ReferencedTableColumns);
            }
            if (node.DeleteAction != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Delete);
                this.GenerateSpace();
                this.GenerateDeleteUpdateAction(node.DeleteAction);
            }
            if (node.UpdateAction != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Update);
                this.GenerateSpace();
                this.GenerateDeleteUpdateAction(node.UpdateAction);
            }
            if (node.NotForReplication) {
                this.GenerateSpace();
                this.GenerateNotForReplication();
            }
        }

        public override void ExplicitVisit(FromClause node) {
            this.GenerateFromClause(node, null);
        }

        protected void GenerateFromClause(FromClause fromClause, AlignmentPoint clauseBody) {
            if (fromClause != null) {
                IList<TableReference> tableReferences = fromClause.TableReferences;
                if (tableReferences.Count > 0) {
                    this.GenerateSeparatorForFromClause();
                    AlignmentPoint ap = new AlignmentPoint();
                    this.MarkAndPushAlignmentPoint(ap);
                    this.GenerateKeyword(TSqlTokenType.From);
                    this.MarkClauseBodyAlignmentWhenNecessary(this._options.NewLineBeforeFromClause, clauseBody);
                    this.GenerateSpace();
                    AlignmentPoint ap2 = new AlignmentPoint();
                    this.MarkAndPushAlignmentPoint(ap2);
                    this.GenerateCommaSeparatedList(tableReferences);
                    this.PopAlignmentPoint();
                    this.PopAlignmentPoint();
                }
            }
        }

        public override void ExplicitVisit(FullTextIndexColumn node) {
            this.GenerateFragmentIfNotNull(node.Name);
            if (node.TypeColumn != null) {
                this.GenerateSpaceAndIdentifier("TYPE");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Column);
                this.GenerateSpaceAndFragmentIfNotNull(node.TypeColumn);
            }
            if (node.LanguageTerm != null) {
                this.GenerateSpaceAndIdentifier("LANGUAGE");
                this.GenerateSpaceAndFragmentIfNotNull(node.LanguageTerm);
            }
            if (node.StatisticalSemantics) {
                this.GenerateSpaceAndIdentifier("STATISTICAL_SEMANTICS");
            }
        }

        public override void ExplicitVisit(FullTextPredicate node) {
            if (node.FullTextFunctionType != 0) {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._fulltextFunctionTypeGenerators, node.FullTextFunctionType);
                if (valueForEnumKey != null) {
                    this.GenerateToken(valueForEnumKey);
                }
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            if (node.PropertyName != null) {
                this.GenerateIdentifier("PROPERTY");
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateCommaSeparatedList(node.Columns);
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.PropertyName);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateFragmentIfNotNull(node.Value);
            if (node.LanguageTerm != null) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateIdentifier("LANGUAGE");
                this.GenerateSpaceAndFragmentIfNotNull(node.LanguageTerm);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(FullTextStopListAction node) {
            if (node.IsAdd) {
                this.GenerateKeyword(TSqlTokenType.Add);
            } else {
                this.GenerateKeyword(TSqlTokenType.Drop);
            }
            if (!node.IsAll) {
                this.GenerateSpaceAndFragmentIfNotNull(node.StopWord);
            } else {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            }
            if (node.LanguageTerm != null) {
                this.GenerateSpaceAndIdentifier("LANGUAGE");
                this.GenerateSpaceAndFragmentIfNotNull(node.LanguageTerm);
            }
        }

        public override void ExplicitVisit(FullTextTableReference node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            switch (node.FullTextFunctionType) {
                case FullTextFunctionType.FreeText:
                    this.GenerateKeyword(TSqlTokenType.FreeTextTable);
                    break;
                case FullTextFunctionType.Contains:
                    this.GenerateKeyword(TSqlTokenType.ContainsTable);
                    break;
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.TableName);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            if (node.PropertyName != null) {
                this.GenerateIdentifier("PROPERTY");
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateCommaSeparatedList(node.Columns);
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.PropertyName);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                int count = node.Columns.Count;
                if (count == 1) {
                    this.GenerateFragmentIfNotNull(node.Columns[0]);
                } else {
                    this.GenerateParenthesisedCommaSeparatedList(node.Columns);
                }
            }
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.SearchCondition);
            if (node.Language != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndIdentifier("LANGUAGE");
                this.GenerateSpaceAndFragmentIfNotNull(node.Language);
            }
            if (node.TopN != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.TopN);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(LeftFunctionCall node) {
            this.GenerateKeyword(TSqlTokenType.Left);
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(RightFunctionCall node) {
            this.GenerateKeyword(TSqlTokenType.Right);
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(FunctionCall node) {
            this.GenerateFragmentIfNotNull(node.CallTarget);
            this.GenerateFragmentIfNotNull(node.FunctionName);
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            if (node.FunctionName.Value.ToUpper(CultureInfo.InvariantCulture) == "TRIM" && node.Parameters.Count == 2) {
                this.GenerateFragmentIfNotNull(node.Parameters[0]);
                this.GenerateSpace();
                this.GenerateKeyword(TSqlTokenType.From);
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(node.Parameters[1]);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                this.GenerateUniqueRowFilter(node.UniqueRowFilter, false);
                if (node.UniqueRowFilter != 0 && node.Parameters.Count > 0) {
                    this.GenerateSpace();
                }
                this.GenerateCommaSeparatedList(node.Parameters);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                this.GenerateSpaceAndFragmentIfNotNull(node.WithinGroupClause);
                this.GenerateSpaceAndFragmentIfNotNull(node.OverClause);
            }
            this.GenerateSpaceAndCollation(node.Collation);
        }

        protected void GenerateFunctionStatementBody(FunctionStatementBody node) {
            this.GenerateKeyword(TSqlTokenType.Function);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLine();
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters);
            if (node.Parameters == null || node.Parameters.Count == 0) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateSpaceAndSymbol(TSqlTokenType.RightParenthesis);
            }
            this.NewLine();
            this.GenerateIdentifier("RETURNS");
            this.GenerateSpace();
            SelectFunctionReturnType selectFunctionReturnType = node.ReturnType as SelectFunctionReturnType;
            if (selectFunctionReturnType != null) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Table);
            } else {
                this.GenerateFragmentIfNotNull(node.ReturnType);
            }
            this.GenerateCommaSeparatedWithClause(node.Options, false, false);
            if (node.OrderHint != null) {
                this.NewLine();
                this.GenerateFragmentIfNotNull(node.OrderHint);
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.As);
            this.NewLine();
            if (selectFunctionReturnType != null) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Return);
                this.GenerateFragmentIfNotNull(selectFunctionReturnType);
            } else if (node.MethodSpecifier != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.MethodSpecifier);
            } else if (node.StatementList != null) {
                this.GenerateFragmentIfNotNull(node.StatementList);
            }
        }

        public override void ExplicitVisit(FunctionOption node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._functionOptionsGenerators, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ExecuteAsFunctionOption node) {
            this.GenerateFragmentIfNotNull(node.ExecuteAs);
        }

        public override void ExplicitVisit(GeneralSetCommand node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._generalSetCommandTypeGenerators, node.CommandType);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Parameter);
        }

        public override void ExplicitVisit(GetConversationGroupStatement node) {
            this.GenerateIdentifier("GET");
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.GroupId);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.Queue);
        }

        public override void ExplicitVisit(GoToStatement node) {
            this.GenerateKeyword(TSqlTokenType.GoTo);
            this.GenerateSpaceAndFragmentIfNotNull(node.LabelName);
        }

        public override void ExplicitVisit(GrantStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Grant);
            this.GeneratePermissionOnToClauses(node);
            if (node.WithGrantOption) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Grant);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
            }
            this.GenerateAsClause(node);
        }

        public override void ExplicitVisit(GrantStatement80 node) {
            this.GenerateKeyword(TSqlTokenType.Grant);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityElement80);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityUserClause80);
            if (node.WithGrantOption) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Grant);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
            }
            if (node.AsClause != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.AsClause);
            }
        }

        public override void ExplicitVisit(GraphMatchPredicate node) {
            this.GenerateIdentifier("MATCH");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Expression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(GraphMatchExpression node) {
            this.GenerateFragmentIfNotNull(node.LeftNode);
            if (!node.ArrowOnRight) {
                this.GenerateSymbol(TSqlTokenType.LessThan);
            }
            this.GenerateSymbol(TSqlTokenType.Minus);
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Edge);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSymbol(TSqlTokenType.Minus);
            if (node.ArrowOnRight) {
                this.GenerateSymbol(TSqlTokenType.GreaterThan);
            }
            this.GenerateFragmentIfNotNull(node.RightNode);
        }

        public override void ExplicitVisit(GroupByClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            }
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(this._options.NewLineBeforeGroupByClause, alignmentPointForFragment);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.GroupingSpecifications);
            if (node.GroupByOption != 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                GroupByOptionHelper.Instance.GenerateSourceForOption(this._writer, node.GroupByOption);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(ExpressionGroupingSpecification node) {
            this.GenerateFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(CompositeGroupingSpecification node) {
            this.GenerateParenthesisedCommaSeparatedList(node.Items);
        }

        public override void ExplicitVisit(CubeGroupingSpecification node) {
            this.GenerateIdentifier("CUBE");
            this.GenerateParenthesisedCommaSeparatedList(node.Arguments);
        }

        public override void ExplicitVisit(RollupGroupingSpecification node) {
            this.GenerateIdentifier("ROLLUP");
            this.GenerateParenthesisedCommaSeparatedList(node.Arguments);
        }

        public override void ExplicitVisit(GrandTotalGroupingSpecification node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(GroupingSetsGroupingSpecification node) {
            this.GenerateIdentifier("GROUPING");
            this.GenerateSpaceAndIdentifier("SETS");
            this.GenerateParenthesisedCommaSeparatedList(node.Sets);
        }

        public override void ExplicitVisit(HadrDatabaseOption node) {
            this.GenerateIdentifier("HADR");
            switch (node.HadrOption) {
                case HadrDatabaseOptionKind.Suspend:
                    this.GenerateSpaceAndIdentifier("SUSPEND");
                    break;
                case HadrDatabaseOptionKind.Resume:
                    this.GenerateSpaceAndIdentifier("RESUME");
                    break;
                case HadrDatabaseOptionKind.Off:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
                    break;
            }
        }

        public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node) {
            this.GenerateIdentifier("HADR");
            this.GenerateSpaceAndIdentifier("AVAILABILITY");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.GroupName);
        }

        public override void ExplicitVisit(HavingClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Having);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(this._options.NewLineBeforeHavingClause, alignmentPointForFragment);
            this.GenerateSpaceAndFragmentIfNotNull(node.SearchCondition);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(Identifier node) {
            if (node.Value != null) {
                if (node.QuoteType == QuoteType.NotQuoted) {
                    this.GenerateIdentifierWithoutCheck(node.Value);
                } else {
                    this.GenerateQuotedIdentifier(node.Value, node.QuoteType);
                }
            }
        }

        private void GenerateQuotedIdentifier(string identifier, QuoteType quoteType) {
            this.GenerateIdentifierWithoutCheck(Identifier.EncodeIdentifier(identifier, quoteType));
        }

        public override void ExplicitVisit(IdentifierDatabaseOption node) {
            DatabaseOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(PrincipalOption node) {
            this.GenerateIdentifier("NO");
            this.GenerateSpaceAndIdentifier("CREDENTIAL");
        }

        public override void ExplicitVisit(IdentifierPrincipalOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._loginOptionsNames, node.OptionKind);
            this.GenerateNameEqualsValue(valueForEnumKey, node.Identifier);
        }

        public override void ExplicitVisit(IdentityFunctionCall node) {
            this.GenerateKeyword(TSqlTokenType.Identity);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DataType);
            if (node.Seed != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.Seed);
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.Increment);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(IfStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.If);
            this.GenerateSpaceAndFragmentIfNotNull(node.Predicate);
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.ThenStatement);
            this.GenerateSemiColonWhenNecessary(node.ThenStatement);
            this.PopAlignmentPoint();
            if (node.ElseStatement != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.Else);
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateFragmentIfNotNull(node.ElseStatement);
                this.GenerateSemiColonWhenNecessary(node.ElseStatement);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(IgnoreDupKeyIndexOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateOptionStateOnOff(node.OptionState);
            if (this._options.SqlVersion >= SqlVersion.Sql140 && OptionState.On == node.OptionState && node.SuppressMessagesOption.HasValue) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateIdentifier("SUPPRESS_MESSAGES");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
                if (node.SuppressMessagesOption == true) {
                    this.GenerateOptionStateOnOff(OptionState.On);
                } else {
                    this.GenerateOptionStateOnOff(OptionState.Off);
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(IIfCall node) {
            this.GenerateIdentifier("IIF");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Predicate);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateFragmentIfNotNull(node.ThenExpression);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateFragmentIfNotNull(node.ElseExpression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(IndexDefinition node) {
            this.GenerateKeyword(TSqlTokenType.Index);
            if (node.Name != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            }
            if (node.Unique) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Unique);
            }
            if (node.IndexType != null) {
                switch (node.IndexType.IndexTypeKind) {
                    case IndexTypeKind.Clustered:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Clustered);
                        break;
                    case IndexTypeKind.NonClustered:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        break;
                    case IndexTypeKind.NonClusteredHash:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        this.GenerateSpaceAndIdentifier("HASH");
                        break;
                    case IndexTypeKind.ClusteredColumnStore:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Clustered);
                        this.GenerateSpaceAndIdentifier("COLUMNSTORE");
                        break;
                    case IndexTypeKind.NonClusteredColumnStore:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        this.GenerateSpaceAndIdentifier("COLUMNSTORE");
                        break;
                }
            }
            if (node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            if (node.FilterPredicate != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
                this.GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            }
            if (node.IndexOptions.Count > 0) {
                this.GenerateIndexOptions(node.IndexOptions);
            }
            if (node.OnFileGroupOrPartitionScheme != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }
            this.GenerateFileStreamOn(node);
        }

        public override void ExplicitVisit(IndexExpressionOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(IndexStateOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateOptionStateOnOff(node.OptionState);
        }

        public override void ExplicitVisit(InPredicate node) {
            this.GenerateFragmentIfNotNull(node.Expression);
            if (node.NotDefined) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Not);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.In);
            if (node.Values.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Values);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Subquery);
        }

        public override void ExplicitVisit(InsertBulkColumnDefinition node) {
            this.GenerateFragmentIfNotNull(node.Column);
            switch (node.NullNotNull) {
                case NullNotNull.NotSpecified:
                    break;
                case NullNotNull.Null:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Null);
                    break;
                case NullNotNull.NotNull:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Not);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Null);
                    break;
            }
        }

        public override void ExplicitVisit(InsertBulkStatement node) {
            this.GenerateKeyword(TSqlTokenType.Insert);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Bulk);
            this.GenerateSpaceAndFragmentIfNotNull(node.To);
            if (node.ColumnDefinitions.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.ColumnDefinitions);
            }
            this.GenerateOption(node);
        }

        public override void ExplicitVisit(InsertStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
            this.MarkAndPushAlignmentPoint(ap);
            if (node.WithCtesAndXmlNamespaces != null) {
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WithCtesAndXmlNamespaces, ap2);
                this.NewLine();
            }
            this.GenerateFragmentIfNotNull(node.InsertSpecification);
            this.GenerateOptimizerHints(node.OptimizerHints);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(InsertSpecification node) {
            AlignmentPoint ap = new AlignmentPoint("ClauseBody");
            AlignmentPoint ap2 = new AlignmentPoint("InsertColumns");
            this.GenerateKeyword(TSqlTokenType.Insert);
            this.MarkClauseBodyAlignmentWhenNecessary(true, ap);
            if (node.TopRowFilter != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.TopRowFilter);
            }
            this.GenerateSpaceAndInsertOption(node.InsertOption);
            if (node.Target != null) {
                this.GenerateSpace();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.Target, ap2);
                if (node.Columns.Count > 0) {
                    this.MarkInsertColumnsAlignmentPointWhenNecessary(ap2);
                    this.GenerateSpace();
                    this.GenerateParenthesisedCommaSeparatedList(node.Columns);
                }
            }
            if (node.OutputIntoClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputIntoClause, ap);
            }
            if (node.OutputClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputClause, ap);
            }
            this.NewLine();
            if (node.InsertSource != null) {
                this.AddAlignmentPointForFragment(node.InsertSource, ap);
                this.AddAlignmentPointForFragment(node.InsertSource, ap2);
                bool generateSemiColon = this._generateSemiColon;
                this._generateSemiColon = false;
                this.GenerateFragmentIfNotNull(node.InsertSource);
                this._generateSemiColon = generateSemiColon;
                this.ClearAlignmentPointsForFragment(node.InsertSource);
            }
        }

        private void GenerateSpaceAndInsertOption(InsertOption insertOption) {
            if (insertOption != 0) {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._insertOptionGenerators, insertOption);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateToken(valueForEnumKey);
                }
            }
        }

        public override void ExplicitVisit(InternalOpenRowset node) {
            this.GenerateKeyword(TSqlTokenType.OpenRowSet);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Identifier);
            if (node.VarArgs.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            }
            this.GenerateCommaSeparatedList(node.VarArgs);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(ScalarExpressionSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(BooleanExpressionSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(IdentifierSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(SchemaObjectNameSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(SelectStatementSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(StatementListSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(TSqlFragmentSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(TSqlStatementSnippet node) {
            if (node.Script != null) {
                this.GenerateIdentifierWithoutCheck(node.Script);
            }
        }

        public override void ExplicitVisit(IPv4 node) {
            this.GenerateFragmentIfNotNull(node.OctetOne);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.OctetTwo);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.OctetThree);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.OctetFour);
        }

        public override void ExplicitVisit(JoinParenthesisTableReference node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.Join);
            this.PopAlignmentPoint();
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(JsonForClause node) {
            this.GenerateIdentifier("JSON");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(JsonForClauseOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._jsonForClauseOptionsGenerators, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            if (node.Value != null) {
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Kill);
            this.GenerateSpaceAndIdentifier("QUERY");
            this.GenerateSpaceAndIdentifier("NOTIFICATION");
            this.GenerateSpaceAndIdentifier("SUBSCRIPTION");
            if (node.All) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.All);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.SubscriptionId);
            }
        }

        public override void ExplicitVisit(KillStatement node) {
            this.GenerateKeyword(TSqlTokenType.Kill);
            this.GenerateSpaceAndFragmentIfNotNull(node.Parameter);
            if (node.WithStatusOnly) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("STATUSONLY");
            }
        }

        public override void ExplicitVisit(KillStatsJobStatement node) {
            this.GenerateKeyword(TSqlTokenType.Kill);
            this.GenerateSpaceAndIdentifier("STATS");
            this.GenerateSpaceAndIdentifier("JOB");
            this.GenerateSpaceAndFragmentIfNotNull(node.JobId);
        }

        public override void ExplicitVisit(LabelStatement node) {
            this.GenerateIdentifierWithoutCasing(node.Value);
        }

        public override void ExplicitVisit(LikePredicate node) {
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            if (node.NotDefined) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Not);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Like);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            if (node.EscapeExpression != null) {
                this.GenerateSpace();
                if (node.OdbcEscape) {
                    this.GenerateSymbol(TSqlTokenType.LeftCurly);
                }
                this.GenerateKeyword(TSqlTokenType.Escape);
                this.GenerateSpaceAndFragmentIfNotNull(node.EscapeExpression);
                if (node.OdbcEscape) {
                    this.GenerateSpaceAndSymbol(TSqlTokenType.RightCurly);
                }
            }
        }

        public override void ExplicitVisit(LineNoStatement node) {
            this.GenerateKeyword(TSqlTokenType.LineNo);
            this.GenerateSpaceAndFragmentIfNotNull(node.LineNo);
        }

        public override void ExplicitVisit(ListenerIPEndpointProtocolOption node) {
            this.GenerateIdentifier("LISTENER_IP");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.IsAll) {
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                if (node.IPv6 != null) {
                    this.GenerateFragmentIfNotNull(node.IPv6);
                } else {
                    this.GenerateFragmentIfNotNull(node.IPv4PartOne);
                    if (node.IPv4PartTwo != null) {
                        this.GenerateSymbol(TSqlTokenType.Colon);
                        this.GenerateFragmentIfNotNull(node.IPv4PartTwo);
                    }
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(IntegerLiteral node) {
            this.GenerateToken(TSqlTokenType.Integer, node.Value);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(NumericLiteral node) {
            this.GenerateToken(TSqlTokenType.Numeric, node.Value);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(StringLiteral node) {
            if (!node.IsNational) {
                string text = "'" + node.Value.Replace("'", "''") + "'";
                this.GenerateToken(TSqlTokenType.AsciiStringLiteral, text);
            } else {
                string text2 = "N'" + node.Value.Replace("'", "''") + "'";
                this.GenerateToken(TSqlTokenType.UnicodeStringLiteral, text2);
            }
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(BinaryLiteral node) {
            this.GenerateToken(TSqlTokenType.HexLiteral, node.Value);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(DefaultLiteral node) {
            this.GenerateKeyword(TSqlTokenType.Default);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(MaxLiteral node) {
            this.GenerateIdentifier("MAX");
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(MoneyLiteral node) {
            this.GenerateToken(TSqlTokenType.Money, node.Value);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(NullLiteral node) {
            this.GenerateKeyword(TSqlTokenType.Null);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(RealLiteral node) {
            this.GenerateToken(TSqlTokenType.Real, node.Value);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(IdentifierLiteral node) {
            if (node.QuoteType == QuoteType.NotQuoted) {
                this.GenerateIdentifierWithoutCheck(node.Value);
            } else {
                this.GenerateQuotedIdentifier(node.Value, node.QuoteType);
            }
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(VariableReference node) {
            this.GenerateToken(TSqlTokenType.Variable, node.Name);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(GlobalVariableExpression node) {
            this.GenerateToken(TSqlTokenType.Variable, node.Name);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(OdbcLiteral node) {
            this.GenerateOdbcLiteralPrefix(node);
            if (!node.IsNational) {
                string text = "'" + node.Value.Replace("'", "''") + "'";
                this.GenerateToken(TSqlTokenType.AsciiStringLiteral, text);
            } else {
                string text2 = "N'" + node.Value.Replace("'", "''") + "'";
                this.GenerateToken(TSqlTokenType.UnicodeStringLiteral, text2);
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.RightCurly);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        private void GenerateOdbcLiteralPrefix(OdbcLiteral node) {
            this.GenerateSymbolAndSpace(TSqlTokenType.LeftCurly);
            switch (node.OdbcLiteralType) {
                case OdbcLiteralType.Time:
                    this.GenerateIdentifier("T");
                    break;
                case OdbcLiteralType.Date:
                    this.GenerateIdentifier("D");
                    break;
                case OdbcLiteralType.Timestamp:
                    this.GenerateIdentifier("TS");
                    break;
                case OdbcLiteralType.Guid:
                    this.GenerateIdentifier("GUID");
                    break;
            }
            this.GenerateSpace();
        }

        public override void ExplicitVisit(LiteralEndpointProtocolOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._endpointProtocolOptionsNames, node.Kind);
            if (valueForEnumKey != null) {
                if (node.Value != null) {
                    this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
                } else {
                    this.GenerateNameEqualsValue(valueForEnumKey, "NONE");
                }
            }
        }

        public override void ExplicitVisit(LiteralPayloadOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._payloadOptionKindsGenerators, node.Kind);
            if (valueForEnumKey != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
            }
        }

        public override void ExplicitVisit(LockEscalationTableOption node) {
            this.GenerateIdentifier("LOCK_ESCALATION");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            LockEscalationMethodHelper.Instance.GenerateSourceForOption(this._writer, node.Value);
        }

        public override void ExplicitVisit(LoginTypePayloadOption node) {
            this.GenerateNameEqualsValue("LOGIN_TYPE", node.IsWindows ? "WINDOWS" : "MIXED");
        }

        internal void GenerateLowPriorityWaitOptions(IList<LowPriorityLockWaitOption> options) {
            if (options != null && options.Count > 0) {
                LowPriorityLockWaitMaxDurationOption lowPriorityLockWaitMaxDurationOption = null;
                LowPriorityLockWaitAbortAfterWaitOption fragment = null;
                foreach (LowPriorityLockWaitOption option in options) {
                    if (option.OptionKind == LowPriorityLockWaitOptionKind.MaxDuration) {
                        lowPriorityLockWaitMaxDurationOption = (option as LowPriorityLockWaitMaxDurationOption);
                    } else if (option.OptionKind == LowPriorityLockWaitOptionKind.AbortAfterWait) {
                        fragment = (option as LowPriorityLockWaitAbortAfterWaitOption);
                    }
                }
                this.GenerateIdentifier("WAIT_AT_LOW_PRIORITY");
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(lowPriorityLockWaitMaxDurationOption);
                if (lowPriorityLockWaitMaxDurationOption != null) {
                    this.GenerateSymbol(TSqlTokenType.Comma);
                    this.GenerateSpace();
                }
                this.GenerateFragmentIfNotNull(fragment);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node) {
            this.GenerateTokenAndEqualSign("MAX_DURATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.MaxDuration);
            if (node.Unit.HasValue) {
                this.GenerateSpace();
                LowPriorityLockWaitMaxDurationTimeUnitHelper.Instance.GenerateSourceForOption(this._writer, node.Unit.Value);
            }
        }

        public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node) {
            this.GenerateTokenAndEqualSign("ABORT_AFTER_WAIT");
            this.GenerateSpace();
            AbortAfterWaitTypeHelper.Instance.GenerateSourceForOption(this._writer, node.AbortAfterWait);
        }

        public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node) {
            this.GenerateLowPriorityWaitOptions(node.Options);
        }

        public override void ExplicitVisit(MaxDopConfigurationOption node) {
            DatabaseConfigSetOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
            if (node.Primary) {
                this.GenerateKeyword(TSqlTokenType.Primary);
            } else {
                this.GenerateFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(MaxDurationOption node) {
            this.GenerateTokenAndEqualSign("MAX_DURATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.MaxDuration);
            if (node.Unit.HasValue) {
                this.GenerateSpace();
                LowPriorityLockWaitMaxDurationTimeUnitHelper.Instance.GenerateSourceForOption(this._writer, node.Unit.Value);
            }
        }

        public override void ExplicitVisit(MaxSizeDatabaseOption node) {
            this.GenerateNameEqualsValue("MAXSIZE", node.MaxSize);
            this.GenerateSpaceAndMemoryUnit(node.Units);
        }

        public override void ExplicitVisit(MemoryOptimizedTableOption node) {
            this.GenerateOptionStateWithEqualSign("MEMORY_OPTIMIZED", node.OptionState);
        }

        public override void ExplicitVisit(MergeActionClause node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.When);
            switch (node.Condition) {
                case MergeCondition.Matched:
                    this.GenerateIdentifier("MATCHED");
                    break;
                case MergeCondition.NotMatched:
                    this.GenerateKeyword(TSqlTokenType.Not);
                    this.GenerateSpaceAndIdentifier("MATCHED");
                    break;
                case MergeCondition.NotMatchedBySource:
                    this.GenerateKeyword(TSqlTokenType.Not);
                    this.GenerateSpaceAndIdentifier("MATCHED");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                    this.GenerateSpaceAndIdentifier("SOURCE");
                    break;
                case MergeCondition.NotMatchedByTarget:
                    this.GenerateKeyword(TSqlTokenType.Not);
                    this.GenerateSpaceAndIdentifier("MATCHED");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                    this.GenerateSpaceAndIdentifier("TARGET");
                    break;
            }
            if (node.SearchCondition != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.And);
                this.GenerateSpaceAndFragmentIfNotNull(node.SearchCondition);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Then);
            this.GenerateSpaceAndFragmentIfNotNull(node.Action);
        }

        public override void ExplicitVisit(MergeStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
            this.MarkAndPushAlignmentPoint(ap);
            if (node.WithCtesAndXmlNamespaces != null) {
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WithCtesAndXmlNamespaces, ap2);
                this.NewLine();
            }
            this.GenerateFragmentIfNotNull(node.MergeSpecification);
            this.GenerateOptimizerHints(node.OptimizerHints);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(MergeSpecification node) {
            AlignmentPoint ap = new AlignmentPoint("ClauseBody");
            this.GenerateKeyword(TSqlTokenType.Merge);
            this.MarkClauseBodyAlignmentWhenNecessary(false, ap);
            if (node.TopRowFilter != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.TopRowFilter);
            }
            this.GenerateSpace();
            this.GenerateKeyword(TSqlTokenType.Into);
            if (node.Target != null) {
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(node.Target);
                this.NewLine();
            }
            if (node.TableAlias != null) {
                this.GenerateSpace();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(node.TableAlias);
            }
            this.NewLine();
            this.GenerateIdentifier("USING");
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.TableReference);
            this.GenerateSpace();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.SearchCondition);
            this.NewLine();
            if (node.ActionClauses != null) {
                this.GenerateList(node.ActionClauses, delegate {
                    this.NewLine();
                });
            }
            if (node.OutputIntoClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputIntoClause, ap);
            }
            if (node.OutputClause != null) {
                this.AddAlignmentPointForFragment(node.OutputClause, ap);
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(node.OutputClause);
            }
        }

        public override void ExplicitVisit(UpdateMergeAction node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Update);
            AlignmentPoint alignmentPoint = new AlignmentPoint("ClauseBody");
            this.GenerateSetClauses(node.SetClauses, alignmentPoint);
        }

        public override void ExplicitVisit(DeleteMergeAction node) {
            this.GenerateKeyword(TSqlTokenType.Delete);
        }

        public override void ExplicitVisit(InsertMergeAction node) {
            AlignmentPoint ap = new AlignmentPoint("InsertColumns");
            this.GenerateKeyword(TSqlTokenType.Insert);
            AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
            this.AddAlignmentPointForFragment(node.Source, ap2);
            if (node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            if (node.Source != null) {
                this.GenerateSpace();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.Source, ap);
            }
        }

        protected void GenerateValidationMethod(MessageTypeStatementBase node) {
            if (node.ValidationMethod != 0) {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._MessageValidationMethodNames, node.ValidationMethod);
                this.NewLineAndIndent();
                this.GenerateNameEqualsValue("VALIDATION", valueForEnumKey);
                if (node.ValidationMethod == MessageValidationMethod.ValidXml && node.XmlSchemaCollectionName != null) {
                    this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Schema);
                    this.GenerateSpaceAndIdentifier("COLLECTION");
                    this.GenerateSpaceAndFragmentIfNotNull(node.XmlSchemaCollectionName);
                }
            }
        }

        public override void ExplicitVisit(MethodSpecifier node) {
            this.GenerateKeyword(TSqlTokenType.External);
            this.GenerateSpaceAndIdentifier("NAME");
            this.GenerateSpaceAndFragmentIfNotNull(node.AssemblyName);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.ClassName);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.MethodName);
        }

        protected void GenerateBulkColumnTimestamp(TextModificationStatement node) {
            if (node.Bulk) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Bulk);
            }
            this.GenerateFragmentIfNotNull(node.Column);
            this.GenerateSpaceAndFragmentIfNotNull(node.TextId);
            if (node.Timestamp != null) {
                this.GenerateSpace();
                this.GenerateNameEqualsValue("TIMESTAMP", node.Timestamp);
            }
        }

        public override void ExplicitVisit(MoveConversationStatement node) {
            this.GenerateIdentifier("MOVE");
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Conversation);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.Group);
        }

        public override void ExplicitVisit(MoveRestoreOption node) {
            this.GenerateIdentifier("MOVE");
            this.GenerateSpaceAndFragmentIfNotNull(node.LogicalFileName);
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpaceAndFragmentIfNotNull(node.OSFileName);
        }

        public override void ExplicitVisit(MultiPartIdentifier node) {
            this.GenerateDotSeparatedList(node.Identifiers);
        }

        public override void ExplicitVisit(NamedTableReference node) {
            this.GenerateFragmentIfNotNull(node.SchemaObject);
            if (node.TemporalClause != null) {
                this.ExplicitVisit(node.TemporalClause);
            }
            this.GenerateSpaceAndAlias(node.Alias);
            this.GenerateSpaceAndFragmentIfNotNull(node.TableSampleClause);
            this.GenerateWithTableHints(node.TableHints);
        }

        public override void ExplicitVisit(SchemaObjectFunctionTableReference node) {
            this.GenerateFragmentIfNotNull(node.SchemaObject);
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(NextValueForExpression node) {
            this.GenerateSpaceAndIdentifier("NEXT");
            this.GenerateSpaceAndIdentifier("VALUE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndFragmentIfNotNull(node.SequenceName);
            if (node.OverClause != null) {
                this.GenerateSpace();
                this.ExplicitVisit(node.OverClause);
            }
        }

        public override void ExplicitVisit(NullableConstraintDefinition node) {
            this.GenerateConstraintHead(node);
            if (!node.Nullable) {
                this.GenerateKeywordAndSpace(TSqlTokenType.Not);
            }
            this.GenerateKeyword(TSqlTokenType.Null);
        }

        public override void ExplicitVisit(NullIfExpression node) {
            this.GenerateKeyword(TSqlTokenType.NullIf);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            this.GenerateFragmentIfNotNull(node.SecondExpression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(OdbcConvertSpecification node) {
            this.GenerateFragmentIfNotNull(node.Identifier);
        }

        public override void ExplicitVisit(OdbcFunctionCall node) {
            this.GenerateSymbol(TSqlTokenType.LeftCurly);
            this.GenerateSpaceAndIdentifier("FN");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.ParametersUsed) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.RightCurly);
        }

        public override void ExplicitVisit(OdbcQualifiedJoinTableReference node) {
            this.GenerateSymbol(TSqlTokenType.LeftCurly);
            this.GenerateSpaceAndIdentifier("OJ");
            this.GenerateSpaceAndFragmentIfNotNull(node.TableReference);
            this.GenerateSpaceAndSymbol(TSqlTokenType.RightCurly);
        }

        public override void ExplicitVisit(OffsetClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateIdentifier("OFFSET");
            this.GenerateSpaceAndFragmentIfNotNull(node.OffsetExpression);
            this.GenerateSpaceAndIdentifier("ROWS");
            if (node.FetchExpression != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Fetch);
                this.GenerateSpaceAndIdentifier("NEXT");
                this.GenerateSpaceAndFragmentIfNotNull(node.FetchExpression);
                this.GenerateSpaceAndIdentifier("ROWS");
                this.GenerateSpaceAndIdentifier("ONLY");
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node) {
            this.GenerateLowPriorityWaitOptions(node.Options);
        }

        public override void ExplicitVisit(OnlineIndexOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            this.GenerateOptionStateOnOff(node.OptionState);
            if (this._options.SqlVersion >= SqlVersion.Sql120 && node.OptionState == OptionState.On && node.LowPriorityLockWaitOption != null) {
                this.GenerateSpace();
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(node.LowPriorityLockWaitOption);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(OrderIndexOption node) {
            IndexOptionHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateCommaSeparatedList(node.Columns);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(OnOffDatabaseOption node) {
            OnOffSimpleDbOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            if (OnOffSimpleDbOptionsHelper.Instance.RequiresEqualsSign(node.OptionKind)) {
                this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
            }
            this.GenerateOptionStateOnOff(node.OptionState);
        }

        public override void ExplicitVisit(OpenCursorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Open);
            this.GenerateSpaceAndFragmentIfNotNull(node.Cursor);
        }

        public override void ExplicitVisit(OpenJsonTableReference node) {
            this.GenerateIdentifier("OPENJSON");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Variable);
            if (node.RowPattern != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.RowPattern);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            if (node.SchemaDeclarationItems.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.SchemaDeclarationItems);
            }
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(OpenMasterKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Open);
            this.GenerateSpaceAndIdentifier("MASTER");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpace();
            this.GenerateDecryptionByPassword(node.Password);
        }

        public override void ExplicitVisit(OnOffPrimaryConfigurationOption node) {
            DatabaseConfigSetOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpace();
            this.GenerateKeywordAndSpace(TSqlTokenType.EqualsSign);
            if (node.OptionState == DatabaseConfigurationOptionState.Primary) {
                this.GenerateIdentifier("PRIMARY");
            } else {
                this.GenerateDatabaseConfigurationOptionStateOnOff(node.OptionState);
            }
        }

        public override void ExplicitVisit(OpenQueryTableReference node) {
            this.GenerateKeyword(TSqlTokenType.OpenQuery);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.LinkedServer);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.Query);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(OpenRowsetTableReference node) {
            this.GenerateKeyword(TSqlTokenType.OpenRowSet);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.ProviderName);
            this.GenerateSymbol(TSqlTokenType.Comma);
            if (node.ProviderString != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.ProviderString);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.DataSource);
                this.GenerateSymbol(TSqlTokenType.Semicolon);
                this.GenerateSpaceAndFragmentIfNotNull(node.UserId);
                this.GenerateSymbol(TSqlTokenType.Semicolon);
                this.GenerateSpaceAndFragmentIfNotNull(node.Password);
            }
            this.GenerateSymbol(TSqlTokenType.Comma);
            if (node.Query != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.Query);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.Object);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(OpenSymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Open);
            this.GenerateSpaceAndIdentifier("SYMMETRIC");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.GenerateSpaceAndIdentifier("DECRYPTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpaceAndFragmentIfNotNull(node.DecryptionMechanism);
        }

        public override void ExplicitVisit(OpenXmlTableReference node) {
            this.GenerateKeyword(TSqlTokenType.OpenXml);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Variable);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.RowPattern);
            if (node.Flags != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.Flags);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            if (node.TableName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndFragmentIfNotNull(node.TableName);
            } else if (node.SchemaDeclarationItems.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.SchemaDeclarationItems);
            }
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(LiteralOptimizerHint node) {
            if (node.HintKind == OptimizerHintKind.UsePlan) {
                if (node.Value != null && node.Value.LiteralType == LiteralType.Integer) {
                    this.GenerateIdentifier("USEPLAN");
                } else {
                    this.GenerateKeyword(TSqlTokenType.Use);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Plan);
                }
            } else {
                List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optimizerHintKindsGenerators, node.HintKind);
                if (valueForEnumKey != null) {
                    this.GenerateTokenList(valueForEnumKey);
                }
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(OptimizerHint node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._optimizerHintKindsGenerators, node.HintKind);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        protected void GenerateOptimizerHints(IList<OptimizerHint> hints) {
            if (hints != null && hints.Count > 0) {
                this.NewLine();
                AlignmentPoint ap = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeywordAndSpace(TSqlTokenType.Option);
                this.GenerateParenthesisedCommaSeparatedList(hints);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(OptimizeForOptimizerHint node) {
            this.GenerateIdentifier("OPTIMIZE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            if (node.IsForUnknown) {
                this.GenerateSpaceAndIdentifier("UNKNOWN");
            } else {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Pairs);
            }
        }

        public override void ExplicitVisit(TableHintsOptimizerHint node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Table);
            this.GenerateIdentifier("HINT");
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.ObjectName);
            if (node.TableHints.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateCommaSeparatedList(node.TableHints);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(VariableValuePair node) {
            this.GenerateFragmentIfNotNull(node.Variable);
            if (node.IsForUnknown) {
                this.GenerateSpaceAndIdentifier("UNKNOWN");
            } else {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(OnOffOptionValue node) {
            if (node.OptionState == OptionState.On) {
                this.GenerateKeyword(TSqlTokenType.On);
            } else if (node.OptionState == OptionState.Off) {
                this.GenerateKeyword(TSqlTokenType.Off);
            }
        }

        public override void ExplicitVisit(LiteralOptionValue node) {
            this.GenerateFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(OrderByClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Order);
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(this._options.NewLineBeforeOrderByClause, alignmentPointForFragment);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.OrderByElements);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(OutputClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateIdentifier("OUTPUT");
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.SelectColumns);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(OutputIntoClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateIdentifier("OUTPUT");
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.SelectColumns);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Into);
            this.GenerateSpaceAndFragmentIfNotNull(node.IntoTable);
            if (node.IntoTableColumns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.IntoTableColumns);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(OverClause node) {
            this.GenerateKeyword(TSqlTokenType.Over);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            bool flag = node.Partitions.Count > 0;
            if (flag) {
                this.GenerateIdentifier("PARTITION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Partitions);
            }
            if (node.OrderByClause != null) {
                if (flag) {
                    this.GenerateSpace();
                }
                AlignmentPoint ap = new AlignmentPoint("ClauseBody");
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OrderByClause, ap);
                this.GenerateSpaceAndFragmentIfNotNull(node.WindowFrameClause);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(PageVerifyDatabaseOption node) {
            this.GenerateIdentifier("PAGE_VERIFY");
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._pageVerifyDatabaseOptionKindNames, node.Value);
            if (valueForEnumKey != null) {
                this.GenerateSpaceAndIdentifier(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ParameterizationDatabaseOption node) {
            this.GenerateIdentifier("PARAMETERIZATION");
            this.GenerateSpaceAndIdentifier(node.IsSimple ? "SIMPLE" : "FORCED");
        }

        public override void ExplicitVisit(ParameterlessCall node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._parameterlessCallTypeGenerators, node.ParameterlessCallType);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(ParenthesisExpression node) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Expression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(ParseCall node) {
            this.GenerateIdentifier("PARSE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.StringValue);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            if (node.Culture != null) {
                this.GenerateSpace();
                this.GenerateIdentifier("USING");
                this.GenerateSpaceAndFragmentIfNotNull(node.Culture);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(PartitionFunctionCall node) {
            if (node.DatabaseName != null) {
                this.GenerateFragmentIfNotNull(node.DatabaseName);
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            this.GenerateIdentifier("$PARTITION");
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.FunctionName);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters);
        }

        public override void ExplicitVisit(PartitionSpecifier node) {
            this.GenerateIdentifier("PARTITION");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.All) {
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                this.GenerateFragmentIfNotNull(node.Number);
            }
        }

        public override void ExplicitVisit(PartnerDatabaseOption node) {
            this.GenerateIdentifier("PARTNER");
            this.GenerateSpace();
            if (node.PartnerServer != null) {
                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.PartnerServer);
            } else if (node.PartnerOption == PartnerDatabaseOptionKind.SafetyFull) {
                this.GenerateIdentifier("SAFETY");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Full);
            } else if (node.PartnerOption == PartnerDatabaseOptionKind.SafetyOff) {
                this.GenerateIdentifier("SAFETY");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
            } else {
                PartnerDbOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.PartnerOption);
            }
            if (node.PartnerOption == PartnerDatabaseOptionKind.Timeout && node.Timeout != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.Timeout);
            }
        }

        public override void ExplicitVisit(PasswordAlterPrincipalOption node) {
            this.GenerateNameEqualsValue("PASSWORD", node.Password);
            if (node.OldPassword != null) {
                this.GenerateSpace();
                this.GenerateNameEqualsValue("OLD_PASSWORD", node.OldPassword);
            } else {
                if (node.MustChange) {
                    this.GenerateSpaceAndIdentifier("MUST_CHANGE");
                }
                if (node.Hashed) {
                    this.GenerateSpaceAndIdentifier("HASHED");
                }
                if (node.Unlock) {
                    this.GenerateSpaceAndIdentifier("UNLOCK");
                }
            }
        }

        public override void ExplicitVisit(PasswordCreateLoginSource node) {
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpace();
            this.GenerateNameEqualsValue("PASSWORD", node.Password);
            if (node.Hashed) {
                this.GenerateSpaceAndIdentifier("HASHED");
            }
            if (node.MustChange) {
                this.GenerateSpaceAndIdentifier("MUST_CHANGE");
            }
            if (node.Options != null && node.Options.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateFragmentList(node.Options);
            }
        }

        public override void ExplicitVisit(Permission node) {
            this.GenerateSpaceSeparatedList(node.Identifiers);
            if (node.Columns != null && node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
        }

        public override void ExplicitVisit(PivotedTableReference node) {
            this.GenerateFragmentIfNotNull(node.TableReference);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Pivot);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.AggregateFunctionIdentifier);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateCommaSeparatedList(node.ValueColumns);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndFragmentIfNotNull(node.PivotColumn);
            this.GenerateSpaceAndKeyword(TSqlTokenType.In);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.InColumns, true);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(PortsEndpointProtocolOption node) {
            this.GenerateIdentifier("PORTS");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateCommaSeparatedFlagOpitons(SqlScriptGeneratorVisitor._portTypesGenerators, node.PortTypes);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(PredicateSetStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Set);
            this.GenerateCommaSeparatedFlagOpitons(SqlScriptGeneratorVisitor._setOptionsGenerators, node.Options);
            this.GenerateSpaceAndKeyword((TSqlTokenType)(node.IsOn ? 105 : 103));
        }

        public override void ExplicitVisit(PrintStatement node) {
            this.GenerateKeyword(TSqlTokenType.Print);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(Privilege80 node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._privilegeType80Generators, node.PrivilegeType80);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            if (node.Columns != null && node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
        }

        public override void ExplicitVisit(PrivilegeSecurityElement80 node) {
            if (node.Privileges != null && node.Privileges.Count > 0) {
                this.GenerateCommaSeparatedList(node.Privileges);
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
                if (node.Columns != null && node.Columns.Count > 0) {
                    this.GenerateSpace();
                    this.GenerateParenthesisedCommaSeparatedList(node.Columns);
                }
            }
        }

        public override void ExplicitVisit(ProcedureParameter node) {
            this.GenerateFragmentIfNotNull(node.VariableName);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            if (node.IsVarying) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Varying);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Nullable);
            if (node.Value != null) {
                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                this.GenerateFragmentIfNotNull(node.Value);
            }
            switch (node.Modifier) {
                case ParameterModifier.None:
                    break;
                case ParameterModifier.Output:
                    this.GenerateSpaceAndIdentifier("OUTPUT");
                    break;
                case ParameterModifier.ReadOnly:
                    this.GenerateSpaceAndIdentifier("READONLY");
                    break;
            }
        }

        public override void ExplicitVisit(ProcedureReference node) {
            this.GenerateFragmentIfNotNull(node.Name);
            if (node.Number != null) {
                this.GenerateToken(TSqlTokenType.ProcNameSemicolon, ";");
                this.GenerateFragmentIfNotNull(node.Number);
            }
        }

        protected void GenerateProcedureStatementBody(ProcedureStatementBody node) {
            this.GenerateKeyword(TSqlTokenType.Procedure);
            this.GenerateSpaceAndFragmentIfNotNull(node.ProcedureReference);
            if (node.Parameters != null && node.Parameters.Count > 0) {
                this.NewLine();
                this.GenerateCommaSeparatedList(node.Parameters);
            }
            this.GenerateCommaSeparatedWithClause(node.Options, false, false);
            if (node.IsForReplication) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Replication);
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.As);
            if (node.StatementList != null) {
                this.NewLine();
                this.GenerateFragmentIfNotNull(node.StatementList);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.MethodSpecifier);
        }

        public override void ExplicitVisit(ProcedureOption node) {
            switch (node.OptionKind) {
                case ProcedureOptionKind.ExecuteAs:
                    break;
                case ProcedureOptionKind.Encryption:
                    this.GenerateIdentifier("ENCRYPTION");
                    break;
                case ProcedureOptionKind.Recompile:
                    this.GenerateIdentifier("RECOMPILE");
                    break;
                case ProcedureOptionKind.NativeCompilation:
                    this.GenerateIdentifier("NATIVE_COMPILATION");
                    break;
                case ProcedureOptionKind.SchemaBinding:
                    this.GenerateIdentifier("SCHEMABINDING");
                    break;
            }
        }

        public override void ExplicitVisit(ExecuteAsProcedureOption node) {
            this.GenerateFragmentIfNotNull(node.ExecuteAs);
        }

        public override void ExplicitVisit(QualifiedJoin node) {
            this.GenerateFragmentIfNotNull(node.FirstTableReference);
            this.GenerateNewLineOrSpace(this._options.NewLineBeforeJoinClause);
            this.GenerateQualifiedJoinType(node.QualifiedJoinType);
            if (node.JoinHint != 0) {
                this.GenerateSpace();
                JoinHintHelper.Instance.GenerateSourceForOption(this._writer, node.JoinHint);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.Join);
            this.NewLine();
            this.GenerateFragmentIfNotNull(node.SecondTableReference);
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.SearchCondition);
        }

        private void GenerateQualifiedJoinType(QualifiedJoinType qualifiedJoinType) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._qualifiedJoinTypeGenerators, qualifiedJoinType);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(QueryParenthesisExpression node) {
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.GenerateQueryParenthesisExpression(node, alignmentPointForFragment, null, null);
        }

        public void GenerateQueryParenthesisExpression(QueryParenthesisExpression node, AlignmentPoint clauseBody, SchemaObjectName intoClause, Identifier filegroupClause = null) {
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateQueryExpression(node.QueryExpression, clauseBody, intoClause, filegroupClause);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            if (node.OrderByClause != null) {
                this.GenerateSeparatorForOrderBy();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OrderByClause, clauseBody);
            }
            if (node.OffsetClause != null) {
                this.GenerateSeparatorForOffsetClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OffsetClause, clauseBody);
            }
            if (node.ForClause != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.For);
                this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
                this.GenerateSpace();
                AlignmentPoint ap = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateFragmentIfNotNull(node.ForClause);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(QuerySpecification node) {
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.GenerateQuerySpecification(node, alignmentPointForFragment, null, null);
        }

        protected void GenerateQuerySpecification(QuerySpecification node, AlignmentPoint clauseBody, SchemaObjectName intoClause, Identifier filegroupClause = null) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Select);
            this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
            this.GenerateUniqueRowFilter(node.UniqueRowFilter, true);
            this.GenerateSpaceAndFragmentIfNotNull(node.TopRowFilter);
            this.GenerateSpace();
            this.GenerateSelectElementsList(node.SelectElements);
            if (intoClause != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.Into);
                this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
                this.GenerateSpaceAndFragmentIfNotNull(intoClause);
            }
            if (filegroupClause != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.On);
                this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
                this.GenerateSpaceAndFragmentIfNotNull(filegroupClause);
            }
            this.GenerateFromClause(node.FromClause, clauseBody);
            if (node.WhereClause != null) {
                this.GenerateSeparatorForWhereClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WhereClause, clauseBody);
            }
            if (node.GroupByClause != null) {
                this.GenerateSeparatorForGroupByClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.GroupByClause, clauseBody);
            }
            if (node.HavingClause != null) {
                this.GenerateSeparatorForHavingClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.HavingClause, clauseBody);
            }
            if (node.OrderByClause != null) {
                this.GenerateSeparatorForOrderBy();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OrderByClause, clauseBody);
            }
            if (node.OffsetClause != null) {
                this.GenerateSeparatorForOffsetClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OffsetClause, clauseBody);
            }
            if (node.ForClause != null) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.For);
                this.MarkClauseBodyAlignmentWhenNecessary(true, clauseBody);
                this.GenerateSpace();
                AlignmentPoint ap2 = new AlignmentPoint();
                this.MarkAndPushAlignmentPoint(ap2);
                this.GenerateFragmentIfNotNull(node.ForClause);
                this.PopAlignmentPoint();
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(QueryStoreCapturePolicyOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._captureModeOptionNames, node.Value);
            this.GenerateNameEqualsValue("QUERY_CAPTURE_MODE", valueForEnumKey);
        }

        public override void ExplicitVisit(QueryStoreDatabaseOption node) {
            this.GenerateIdentifier("QUERY_STORE");
            this.GenerateSpace();
            if (node.Clear) {
                this.GenerateIdentifier("CLEAR");
            } else if (node.ClearAll) {
                this.GenerateIdentifier("CLEAR");
                this.GenerateSpace();
                this.GenerateKeyword(TSqlTokenType.All);
            } else {
                switch (node.OptionState) {
                    case OptionState.Off:
                        this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                        this.GenerateKeyword(TSqlTokenType.Off);
                        break;
                    case OptionState.On:
                        this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
                        this.GenerateKeyword(TSqlTokenType.On);
                        this.GenerateParenthesisedCommaSeparatedList(node.Options);
                        break;
                    default:
                        this.GenerateParenthesisedCommaSeparatedList(node.Options);
                        break;
                }
            }
        }

        public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node) {
            this.GenerateNameEqualsValue("DATA_FLUSH_INTERVAL_SECONDS", node.FlushInterval);
        }

        public override void ExplicitVisit(QueryStoreIntervalLengthOption node) {
            this.GenerateNameEqualsValue("INTERVAL_LENGTH_MINUTES", node.StatsIntervalLength);
        }

        public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node) {
            this.GenerateNameEqualsValue("MAX_STORAGE_SIZE_MB", node.MaxQdsSize);
        }

        public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node) {
            this.GenerateNameEqualsValue("MAX_PLANS_PER_QUERY", node.MaxPlansPerQuery);
        }

        public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node) {
            this.GenerateIdentifier("CLEANUP_POLICY");
            this.GenerateSpace();
            this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateNameEqualsValue("STALE_QUERY_THRESHOLD_DAYS", node.StaleQueryThreshold);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(QueryStoreDesiredStateOption node) {
            if (node.OperationModeSpecified) {
                this.GenerateIdentifier("OPERATION_MODE");
            } else {
                this.GenerateIdentifier("DESIRED_STATE");
            }
            this.GenerateSpace();
            this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
            if (node.Value == QueryStoreDesiredStateOptionKind.ReadWrite) {
                this.GenerateIdentifier("READ_WRITE");
            } else if (node.Value == QueryStoreDesiredStateOptionKind.ReadOnly) {
                this.GenerateIdentifier("READ_ONLY");
            }
        }

        public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._sizeBasedCleanupOptionNames, node.Value);
            this.GenerateNameEqualsValue("SIZE_BASED_CLEANUP_MODE", valueForEnumKey);
        }

        public override void ExplicitVisit(QueueStateOption node) {
            if (node.OptionKind == QueueOptionKind.PoisonMessageHandlingStatus) {
                this.GenerateIdentifier("POISON_MESSAGE_HANDLING");
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateOptionStateWithEqualSign("STATUS", node.OptionState);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else {
                string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._queueOptionTypeNames, node.OptionKind);
                if (valueForEnumKey != null) {
                    this.GenerateOptionStateWithEqualSign(valueForEnumKey, node.OptionState);
                }
            }
        }

        protected void GenerateQueueOptions(IList<QueueOption> queueOptions) {
            List<QueueOption> list = new List<QueueOption>();
            List<QueueOption> list2 = new List<QueueOption>();
            foreach (QueueOption queueOption in queueOptions) {
                switch (queueOption.OptionKind) {
                    case QueueOptionKind.Status:
                    case QueueOptionKind.Retention:
                    case QueueOptionKind.PoisonMessageHandlingStatus:
                        list.Add(queueOption);
                        break;
                    case QueueOptionKind.ActivationStatus:
                    case QueueOptionKind.ActivationProcedureName:
                    case QueueOptionKind.ActivationMaxQueueReaders:
                    case QueueOptionKind.ActivationExecuteAs:
                    case QueueOptionKind.ActivationDrop:
                        list2.Add(queueOption);
                        break;
                }
            }
            this.GenerateCommaSeparatedList(list);
            if (list.Count > 0 && list2.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            }
            if (list2.Count > 0) {
                this.GenerateIdentifier("ACTIVATION");
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(list2);
            }
        }

        public override void ExplicitVisit(QueueOption node) {
            if (node.OptionKind == QueueOptionKind.ActivationDrop) {
                this.GenerateKeyword(TSqlTokenType.Drop);
            }
        }

        public override void ExplicitVisit(QueueProcedureOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._queueOptionTypeNames, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.OptionValue);
            }
        }

        public override void ExplicitVisit(QueueValueOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._queueOptionTypeNames, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.OptionValue);
            }
        }

        public override void ExplicitVisit(QueueExecuteAsOption node) {
            this.GenerateFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(RaiseErrorLegacyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Raiserror);
            this.GenerateSpaceAndFragmentIfNotNull(node.FirstParameter);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondParameter);
        }

        public override void ExplicitVisit(RaiseErrorStatement node) {
            this.GenerateKeyword(TSqlTokenType.Raiserror);
            this.GenerateSpace();
            this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.FirstParameter);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondParameter);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.ThirdParameter);
            if (node.OptionalParameters.Count > 0) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                this.GenerateCommaSeparatedList(node.OptionalParameters);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            if (node.RaiseErrorOptions != 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateCommaSeparatedFlagOpitons(SqlScriptGeneratorVisitor._raiseErrorOptionsGenerators, node.RaiseErrorOptions);
            }
        }

        public override void ExplicitVisit(ReadOnlyForClause node) {
            this.GenerateKeyword(TSqlTokenType.Read);
            this.GenerateSpaceAndIdentifier("ONLY");
        }

        public override void ExplicitVisit(ReadTextStatement node) {
            this.GenerateKeyword(TSqlTokenType.ReadText);
            this.GenerateSpaceAndFragmentIfNotNull(node.Column);
            this.GenerateSpaceAndFragmentIfNotNull(node.TextPointer);
            this.GenerateSpaceAndFragmentIfNotNull(node.Offset);
            this.GenerateSpaceAndFragmentIfNotNull(node.Size);
            if (node.HoldLock) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.HoldLock);
            }
        }

        public override void ExplicitVisit(ReceiveStatement node) {
            this.GenerateIdentifier("RECEIVE");
            if (node.Top != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Top);
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.Top);
            }
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.SelectElements);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.Queue);
            if (node.Into != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Into);
                this.GenerateSpaceAndFragmentIfNotNull(node.Into);
            }
            if (node.Where != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
                this.GenerateSpace();
                this.GenerateNameEqualsValue(node.IsConversationGroupIdWhere ? "CONVERSATION_GROUP_ID" : "CONVERSATION_HANDLE", node.Where);
            }
        }

        public override void ExplicitVisit(ReconfigureStatement node) {
            this.GenerateKeyword(TSqlTokenType.Reconfigure);
            if (node.WithOverride) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("OVERRIDE");
            }
        }

        public override void ExplicitVisit(RecoveryDatabaseOption node) {
            this.GenerateIdentifier("RECOVERY");
            this.GenerateSpace();
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._recoveryDatabaseOptionKindNames, node.Value);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node) {
            if (node.OptionState == OptionState.NotSet) {
                this.GenerateIdentifier("REMOTE_DATA_ARCHIVE");
            } else {
                this.GenerateOptionStateWithEqualSign("REMOTE_DATA_ARCHIVE", node.OptionState);
            }
            if (node.Settings.Count > 0) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                bool flag = true;
                foreach (RemoteDataArchiveDatabaseSetting setting in node.Settings) {
                    if (!flag) {
                        this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    } else {
                        flag = false;
                    }
                    switch (setting.SettingKind) {
                        case RemoteDataArchiveDatabaseSettingKind.Server: {
                                RemoteDataArchiveDbServerSetting remoteDataArchiveDbServerSetting = setting as RemoteDataArchiveDbServerSetting;
                                this.GenerateNameEqualsValue("SERVER", remoteDataArchiveDbServerSetting.Server);
                                break;
                            }
                        case RemoteDataArchiveDatabaseSettingKind.Credential: {
                                RemoteDataArchiveDbCredentialSetting remoteDataArchiveDbCredentialSetting = setting as RemoteDataArchiveDbCredentialSetting;
                                this.GenerateIdentifier("CREDENTIAL");
                                this.GenerateSpace();
                                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                                this.GenerateSpaceAndFragmentIfNotNull(remoteDataArchiveDbCredentialSetting.Credential);
                                break;
                            }
                        case RemoteDataArchiveDatabaseSettingKind.FederatedServiceAccount: {
                                RemoteDataArchiveDbFederatedServiceAccountSetting remoteDataArchiveDbFederatedServiceAccountSetting = setting as RemoteDataArchiveDbFederatedServiceAccountSetting;
                                this.GenerateOptionStateWithEqualSign("FEDERATED_SERVICE_ACCOUNT", (OptionState)(remoteDataArchiveDbFederatedServiceAccountSetting.IsOn ? 1 : 2));
                                break;
                            }
                    }
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(RemoteDataArchiveTableOption node) {
            this.GenerateIdentifier("REMOTE_DATA_ARCHIVE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            RdaTableOptionHelper.Instance.GenerateSourceForOption(this._writer, node.RdaTableOption);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateIdentifier("MIGRATION_STATE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            MigrationStateHelper.Instance.GenerateSourceForOption(this._writer, node.MigrationState);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node) {
            this.GenerateIdentifier("REMOTE_DATA_ARCHIVE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            RdaTableOptionHelper.Instance.GenerateSourceForOption(this._writer, node.RdaTableOption);
            if (!node.IsMigrationStateSpecified && !node.IsFilterPredicateSpecified) {
                return;
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            if (node.IsMigrationStateSpecified) {
                this.GenerateIdentifier("MIGRATION_STATE");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
                MigrationStateHelper.Instance.GenerateSourceForOption(this._writer, node.MigrationState);
            }
            if (node.IsMigrationStateSpecified && node.IsFilterPredicateSpecified) {
                this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            }
            if (node.IsFilterPredicateSpecified && node.FilterPredicate != null) {
                this.GenerateIdentifier("FILTER_PREDICATE");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.FilterPredicate);
            } else if (node.IsFilterPredicateSpecified) {
                this.GenerateIdentifier("FILTER_PREDICATE");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndSymbol(TSqlTokenType.Null);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        protected void GenerateBindingOptions(IList<RemoteServiceBindingOption> options) {
            if (options != null && options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(options);
            }
        }

        public override void ExplicitVisit(UserRemoteServiceBindingOption node) {
            if (node.User != null) {
                this.GenerateNameEqualsValue(TSqlTokenType.User, node.User);
            }
        }

        public override void ExplicitVisit(OnOffRemoteServiceBindingOption node) {
            this.GenerateOptionStateWithEqualSign("ANONYMOUS", node.OptionState);
        }

        public override void ExplicitVisit(ResourcePoolParameter node) {
            ResourcePoolParameterHelper.Instance.GenerateSourceForOption(this._writer, node.ParameterType);
            if (node.ParameterType != ResourcePoolParameterType.Affinity) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.ParameterValue);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.AffinitySpecification);
            }
        }

        public override void ExplicitVisit(ResourcePoolAffinitySpecification node) {
            ResourcePoolAffinityHelper.Instance.GenerateSourceForOption(this._writer, node.AffinityType);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            if (node.IsAuto) {
                this.GenerateIdentifier("AUTO");
            } else if (node.PoolAffinityRanges != null && node.PoolAffinityRanges.Count > 0) {
                this.GenerateParenthesisedCommaSeparatedList(node.PoolAffinityRanges);
            }
        }

        public override void ExplicitVisit(LiteralRange node) {
            this.GenerateFragmentIfNotNull(node.From);
            if (node.To != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                this.GenerateSpaceAndFragmentIfNotNull(node.To);
            }
        }

        protected void GenerateResourcePoolStatementBody(ResourcePoolStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateIdentifier("RESOURCE");
            this.GenerateSpaceAndIdentifier("POOL");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.ResourcePoolParameters != null && node.ResourcePoolParameters.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.ResourcePoolParameters, 2);
                this.PopAlignmentPoint();
            }
        }

        public override void ExplicitVisit(RestoreMasterKeyStatement node) {
            this.GenerateCommonRestorePart(node, false);
            this.GenerateSpace();
            this.GenerateEncryptionByPassword(node.EncryptionPassword);
            if (node.IsForce) {
                this.GenerateSpaceAndIdentifier("FORCE");
            }
        }

        public override void ExplicitVisit(RestoreOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._restoreOptionKindGenerators, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(ScalarExpressionRestoreOption node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._restoreOptionKindGenerators, node.OptionKind);
            if (valueForEnumKey != null && node.Value != null) {
                this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
            }
        }

        public override void ExplicitVisit(RestoreServiceMasterKeyStatement node) {
            this.GenerateCommonRestorePart(node, true);
            if (node.IsForce) {
                this.GenerateSpaceAndIdentifier("FORCE");
            }
        }

        public override void ExplicitVisit(RestoreStatement node) {
            this.GenerateKeyword(TSqlTokenType.Restore);
            if (node.Kind == RestoreStatementKind.TransactionLog) {
                this.GenerateSpaceAndIdentifier("LOG");
                this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            } else if (node.Kind == RestoreStatementKind.Database) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Database);
                this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
            } else {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._restoreStatementKindGenerators, node.Kind);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateToken(valueForEnumKey);
                }
            }
            if (node.Files.Count > 0) {
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Files);
            }
            if (node.Devices.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Devices);
            }
            if (node.Options.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(ResultSetsExecuteOption node) {
            this.GenerateIdentifier("RESULT");
            this.GenerateSpaceAndIdentifier("SETS");
            switch (node.ResultSetsOptionKind) {
                case ResultSetsOptionKind.Undefined:
                    this.GenerateSpaceAndIdentifier("UNDEFINED");
                    break;
                case ResultSetsOptionKind.None:
                    this.GenerateSpaceAndIdentifier("NONE");
                    break;
                case ResultSetsOptionKind.ResultSetsDefined:
                    this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.Definitions, 2);
                    break;
            }
        }

        public override void ExplicitVisit(ResultSetDefinition node) {
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndIdentifier("XML");
        }

        public override void ExplicitVisit(SchemaObjectResultSetDefinition node) {
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            switch (node.ResultSetType) {
                case ResultSetType.Object:
                    this.GenerateSpaceAndIdentifier("OBJECT");
                    break;
                case ResultSetType.Type:
                    this.GenerateSpaceAndIdentifier("TYPE");
                    break;
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(InlineResultSetDefinition node) {
            this.GenerateParenthesisedCommaSeparatedList(node.ResultColumnDefinitions);
        }

        public override void ExplicitVisit(ResultColumnDefinition node) {
            this.GenerateFragmentIfNotNull(node.ColumnDefinition);
            this.GenerateSpaceAndFragmentIfNotNull(node.Nullable);
        }

        public override void ExplicitVisit(ReturnStatement node) {
            this.GenerateKeyword(TSqlTokenType.Return);
            if (node.Expression != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
            }
        }

        public override void ExplicitVisit(RevertStatement node) {
            this.GenerateKeyword(TSqlTokenType.Revert);
            if (node.Cookie != null) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateNameEqualsValue("COOKIE", node.Cookie);
            }
        }

        public override void ExplicitVisit(RevokeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Revoke);
            if (node.GrantOptionFor) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Grant);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            }
            this.GenerateSpace();
            this.GeneratePermissionOnToClauses(node);
            if (node.CascadeOption) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Cascade);
            }
            this.GenerateAsClause(node);
        }

        public override void ExplicitVisit(RevokeStatement80 node) {
            this.GenerateKeyword(TSqlTokenType.Revoke);
            if (node.GrantOptionFor) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Grant);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityElement80);
            this.GenerateSpaceAndKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecurityUserClause80);
            if (node.CascadeOption) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Cascade);
            }
            if (node.AsClause != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.AsClause);
            }
        }

        public override void ExplicitVisit(RolePayloadOption node) {
            this.GenerateTokenAndEqualSign("ROLE");
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._databaseMirroringEndpointRoleGenerators, node.Role);
            if (valueForEnumKey != null) {
                this.GenerateSpace();
                this.GenerateToken(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(RollbackTransactionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Rollback);
            if (node.Name != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Transaction);
                this.GenerateSpace();
                this.GenerateTransactionName(node.Name);
            }
        }

        public override void ExplicitVisit(RouteOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._RouteOptionTypeNames, node.OptionKind);
            this.GenerateNameEqualsValue(valueForEnumKey, node.Literal);
        }

        protected void GenerateRouteOptions(RouteStatement node) {
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.RouteOptions);
        }

        public override void ExplicitVisit(SaveTransactionStatement node) {
            this.GenerateKeyword(TSqlTokenType.Save);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Transaction);
            this.GenerateSpace();
            this.GenerateTransactionName(node.Name);
        }

        public override void ExplicitVisit(ScalarFunctionReturnType node) {
            this.GenerateFragmentIfNotNull(node.DataType);
        }

        public override void ExplicitVisit(ScalarSubquery node) {
            this.GenerateQueryExpressionInParentheses(node.QueryExpression);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(SchemaDeclarationItem node) {
            this.GenerateFragmentIfNotNull(node.ColumnDefinition);
            this.GenerateSpaceAndFragmentIfNotNull(node.Mapping);
        }

        public override void ExplicitVisit(SchemaDeclarationItemOpenjson node) {
            this.GenerateFragmentIfNotNull(node.ColumnDefinition);
            this.GenerateSpaceAndFragmentIfNotNull(node.Mapping);
            if (node.AsJson) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndIdentifier("JSON");
            }
        }

        public override void ExplicitVisit(SchemaObjectName node) {
            this.GenerateDotSeparatedList(node.Identifiers);
        }

        public override void ExplicitVisit(SchemaPayloadOption node) {
            this.GenerateNameEqualsValue(TSqlTokenType.Schema, node.IsStandard ? "STANDARD" : "NONE");
        }

        public override void ExplicitVisit(AddSearchPropertyListAction node) {
            this.GenerateKeyword(TSqlTokenType.Add);
            this.GenerateSpaceAndFragmentIfNotNull(node.PropertyName);
            this.GenerateSpaceAndKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
            this.GenerateSpaceAndIdentifier("PROPERTY_SET_GUID");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Guid);
            this.GenerateKeyword(TSqlTokenType.Comma);
            this.GenerateSpaceAndIdentifier("PROPERTY_INT_ID");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Id);
            if (node.Description != null) {
                this.GenerateKeyword(TSqlTokenType.Comma);
                this.GenerateSpaceAndIdentifier("PROPERTY_DESCRIPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Description);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(DropSearchPropertyListAction node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndFragmentIfNotNull(node.PropertyName);
        }

        public override void ExplicitVisit(OnOffPrincipalOption node) {
            string optionName = string.Empty;
            switch (node.OptionKind) {
                case PrincipalOptionKind.CheckExpiration:
                    optionName = "CHECK_EXPIRATION";
                    break;
                case PrincipalOptionKind.CheckPolicy:
                    optionName = "CHECK_POLICY";
                    break;
            }
            this.GenerateOptionStateWithEqualSign(optionName, node.OptionState);
        }

        public void GenerateSecurityPolicyStatementBody(SecurityPolicyStatement node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            for (int i = 0; i < node.SecurityPredicateActions.Count; i++) {
                this.GenerateFragmentIfNotNull(node.SecurityPredicateActions[i]);
                if (i < node.SecurityPredicateActions.Count - 1) {
                    this.GenerateSymbol(TSqlTokenType.Comma);
                }
            }
            if (node.SecurityPolicyOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                for (int j = 0; j < node.SecurityPolicyOptions.Count; j++) {
                    this.GenerateFragmentIfNotNull(node.SecurityPolicyOptions[j]);
                    if (j < node.SecurityPolicyOptions.Count - 1) {
                        this.GenerateSymbol(TSqlTokenType.Comma);
                        this.GenerateSpace();
                    }
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
            if (node.ActionType != 0 && node.ActionType != SecurityPolicyActionType.AlterReplication) {
                return;
            }
            if (node.NotForReplication) {
                this.NewLineAndIndent();
                if (node.ActionType == SecurityPolicyActionType.AlterReplication) {
                    this.GenerateKeyword(TSqlTokenType.Add);
                    this.GenerateSpace();
                }
                this.GenerateKeyword(TSqlTokenType.Not);
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Replication);
            } else if (node.ActionType == SecurityPolicyActionType.AlterReplication) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.Drop);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Not);
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Replication);
            }
        }

        public override void ExplicitVisit(SecurityPredicateAction node) {
            this.NewLineAndIndent();
            if (node.ActionType == SecurityPredicateActionType.Create) {
                this.GenerateKeyword(TSqlTokenType.Add);
            } else if (node.ActionType == SecurityPredicateActionType.Alter) {
                this.GenerateKeyword(TSqlTokenType.Alter);
            } else {
                this.GenerateKeyword(TSqlTokenType.Drop);
            }
            if (node.SecurityPredicateType == SecurityPredicateType.Filter) {
                this.GenerateSpaceAndIdentifier("FILTER");
            } else {
                this.GenerateSpaceAndIdentifier("BLOCK");
            }
            this.GenerateSpaceAndIdentifier("PREDICATE");
            if (node.ActionType != SecurityPredicateActionType.Drop) {
                this.GenerateSpaceAndFragmentIfNotNull(node.FunctionCall);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.TargetObjectName);
            switch (node.SecurityPredicateOperation) {
                case SecurityPredicateOperation.AfterInsert:
                    this.GenerateSpaceAndIdentifier("AFTER");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Insert);
                    break;
                case SecurityPredicateOperation.AfterUpdate:
                    this.GenerateSpaceAndIdentifier("AFTER");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Update);
                    break;
                case SecurityPredicateOperation.BeforeDelete:
                    this.GenerateSpaceAndIdentifier("BEFORE");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Delete);
                    break;
                case SecurityPredicateOperation.BeforeUpdate:
                    this.GenerateSpaceAndIdentifier("BEFORE");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Update);
                    break;
            }
        }

        public override void ExplicitVisit(SecurityPolicyOption node) {
            if (node.OptionKind == SecurityPolicyOptionKind.State) {
                this.GenerateIdentifier("STATE");
            } else {
                this.GenerateIdentifier("SCHEMABINDING");
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndKeyword((TSqlTokenType)((node.OptionState == OptionState.On) ? 105 : 103));
        }

        public override void ExplicitVisit(SecurityPrincipal node) {
            switch (node.PrincipalType) {
                case PrincipalType.Null:
                    this.GenerateKeyword(TSqlTokenType.Null);
                    break;
                case PrincipalType.Public:
                    this.GenerateKeyword(TSqlTokenType.Public);
                    break;
                case PrincipalType.Identifier:
                    this.GenerateFragmentIfNotNull(node.Identifier);
                    break;
            }
        }

        protected void GeneratePermissionOnToClauses(SecurityStatement node) {
            this.GenerateCommaSeparatedList(node.Permissions);
            if (node.SecurityTargetObject != null) {
                this.NewLineAndIndent();
                this.GenerateFragmentIfNotNull(node.SecurityTargetObject);
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Principals);
        }

        protected void GenerateAsClause(SecurityStatement node) {
            if (node.AsClause != null) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.AsClause);
            }
        }

        public override void ExplicitVisit(SecurityTargetObject node) {
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpace();
            if (node.ObjectKind != 0) {
                this.GenerateSourceForSecurityObjectKind(node.ObjectKind);
            }
            this.GenerateFragmentIfNotNull(node.ObjectName);
            if (node.Columns != null && node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
        }

        protected void GenerateSourceForSecurityObjectKind(SecurityObjectKind type) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._securityObjectKindGenerators, type);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
            this.GenerateSymbol(TSqlTokenType.DoubleColon);
        }

        public override void ExplicitVisit(SecurityTargetObjectName node) {
            this.GenerateFragmentIfNotNull(node.MultiPartIdentifier);
        }

        public override void ExplicitVisit(SecurityUserClause80 node) {
            switch (node.UserType80) {
                case UserType80.Null:
                    this.GenerateKeyword(TSqlTokenType.Null);
                    break;
                case UserType80.Public:
                    this.GenerateKeyword(TSqlTokenType.Public);
                    break;
                case UserType80.Users:
                    if (node.Users != null && node.Users.Count > 0) {
                        this.GenerateCommaSeparatedList(node.Users);
                    }
                    break;
            }
        }

        public override void ExplicitVisit(SelectFunctionReturnType node) {
            if (node.SelectStatement != null) {
                this.NewLineAndIndent();
                this.GenerateFragmentIfNotNull(node.SelectStatement);
                this.NewLine();
            }
        }

        public override void ExplicitVisit(SelectInsertSource node) {
            AlignmentPoint ap = new AlignmentPoint("ClauseBody");
            this.GenerateFragmentWithAlignmentPointIfNotNull(node.Select, ap);
        }

        public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node) {
            this.GenerateNameEqualsValue(node.Name.Value, node.Path);
            if (node.XQueryDataType == null && node.MaxLength == null && !node.IsSingleton && node.SQLDataType == null) {
                return;
            }
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            if ((node.XQueryDataType != null || node.MaxLength != null || node.IsSingleton) && node.SQLDataType == null) {
                this.GenerateSpaceAndIdentifier("XQUERY");
                this.GenerateSpaceAndFragmentIfNotNull(node.XQueryDataType);
                if (node.MaxLength != null) {
                    this.GenerateSpaceAndIdentifier("MAXLENGTH");
                    this.GenerateKeyword(TSqlTokenType.LeftParenthesis);
                    this.GenerateFragmentIfNotNull(node.MaxLength);
                    this.GenerateKeyword(TSqlTokenType.RightParenthesis);
                }
                goto IL_00cf;
            }
            if (node.SQLDataType != null) {
                this.GenerateSpaceAndIdentifier("SQL");
                this.GenerateSpaceAndFragmentIfNotNull(node.SQLDataType);
            }
            goto IL_00cf;
            IL_00cf:
            if (node.IsSingleton) {
                this.GenerateSpaceAndIdentifier("SINGLETON");
            }
        }

        public override void ExplicitVisit(SelectScalarExpression node) {
            this.GenerateFragmentIfNotNull(node.Expression);
            if (node.ColumnName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(node.ColumnName);
            }
        }

        public override void ExplicitVisit(SelectSetVariable node) {
            this.GenerateFragmentIfNotNull(node.Variable);
            TSqlTokenType valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._assignmentKindSymbols, node.AssignmentKind);
            this.GenerateSpaceAndSymbol(valueForEnumKey);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(SelectStarExpression node) {
            this.GenerateFragmentIfNotNull(node.Qualifier);
            if (node.Qualifier != null && node.Qualifier.Count > 0) {
                this.GenerateSymbol(TSqlTokenType.Dot);
            }
            this.GenerateSymbol(TSqlTokenType.Star);
        }

        public override void ExplicitVisit(SelectStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint alignmentPoint = new AlignmentPoint("ClauseBody");
            this.MarkAndPushAlignmentPoint(ap);
            if (node.WithCtesAndXmlNamespaces != null) {
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WithCtesAndXmlNamespaces, alignmentPoint);
                this.NewLine();
            }
            this.GenerateQueryExpression(node.QueryExpression, alignmentPoint, node.Into, node.On);
            foreach (ComputeClause computeClause in node.ComputeClauses) {
                this.NewLine();
                this.GenerateFragmentWithAlignmentPointIfNotNull(computeClause, alignmentPoint);
            }
            this.GenerateOptimizerHints(node.OptimizerHints);
            this.PopAlignmentPoint();
        }

        private void GenerateQueryExpression(QueryExpression queryExpression, AlignmentPoint clauseBody, SchemaObjectName intoClause, Identifier filegroupClause = null) {
            QuerySpecification querySpecification = queryExpression as QuerySpecification;
            if (querySpecification != null) {
                this.GenerateQuerySpecification(querySpecification, clauseBody, intoClause, filegroupClause);
            } else {
                BinaryQueryExpression binaryQueryExpression = queryExpression as BinaryQueryExpression;
                if (binaryQueryExpression != null) {
                    this.GenerateBinaryQueryExpression(binaryQueryExpression, clauseBody, intoClause, filegroupClause);
                } else {
                    QueryParenthesisExpression queryParenthesisExpression = queryExpression as QueryParenthesisExpression;
                    if (queryParenthesisExpression != null) {
                        this.GenerateQueryParenthesisExpression(queryParenthesisExpression, clauseBody, intoClause, filegroupClause);
                    }
                }
            }
        }

        public override void ExplicitVisit(SemanticTableReference node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            switch (node.SemanticFunctionType) {
                case SemanticFunctionType.SemanticKeyPhraseTable:
                    this.GenerateKeyword(TSqlTokenType.SemanticKeyPhraseTable);
                    break;
                case SemanticFunctionType.SemanticSimilarityTable:
                    this.GenerateKeyword(TSqlTokenType.SemanticSimilarityTable);
                    break;
                case SemanticFunctionType.SemanticSimilarityDetailsTable:
                    this.GenerateKeyword(TSqlTokenType.SemanticSimilarityDetailsTable);
                    break;
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.TableName);
            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
            int count = node.Columns.Count;
            if (count == 1) {
                this.GenerateFragmentIfNotNull(node.Columns[0]);
            } else {
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            if (node.SourceKey != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.SourceKey);
            }
            if (node.MatchedColumn != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.MatchedColumn);
            }
            if (node.MatchedKey != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.MatchedKey);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(SendStatement node) {
            this.GenerateIdentifier("SEND");
            this.GenerateSpaceAndKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndIdentifier("CONVERSATION");
            this.GenerateSpace();
            if (this._options.SqlVersion >= SqlVersion.Sql110) {
                this.GenerateParenthesisedCommaSeparatedList(node.ConversationHandles);
            } else {
                this.GenerateCommaSeparatedList(node.ConversationHandles);
            }
            if (node.MessageTypeName != null) {
                this.GenerateSpaceAndIdentifier("MESSAGE");
                this.GenerateSpaceAndIdentifier("TYPE");
                this.GenerateSpaceAndFragmentIfNotNull(node.MessageTypeName);
            }
            if (node.MessageBody != null) {
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.MessageBody);
            }
        }

        public void GenerateSequenceStatementBody(SequenceStatement node) {
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            foreach (SequenceOption sequenceOption in node.SequenceOptions) {
                this.GenerateFragmentIfNotNull(sequenceOption);
            }
        }

        public override void ExplicitVisit(DataTypeSequenceOption node) {
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
        }

        public override void ExplicitVisit(SequenceOption node) {
            this.NewLineAndIndent();
            if (node.NoValue) {
                this.GenerateIdentifier("NO");
                this.GenerateSpace();
            }
            switch (node.OptionKind) {
                case SequenceOptionKind.MinValue:
                    this.GenerateIdentifier("MINVALUE");
                    break;
                case SequenceOptionKind.MaxValue:
                    this.GenerateIdentifier("MAXVALUE");
                    break;
                case SequenceOptionKind.Cache:
                    this.GenerateIdentifier("CACHE");
                    break;
                case SequenceOptionKind.Cycle:
                    this.GenerateIdentifier("Cycle");
                    break;
            }
        }

        public override void ExplicitVisit(ScalarExpressionSequenceOption node) {
            this.NewLineAndIndent();
            switch (node.OptionKind) {
                case SequenceOptionKind.MinValue:
                    this.GenerateIdentifier("MINVALUE");
                    break;
                case SequenceOptionKind.MaxValue:
                    this.GenerateIdentifier("MAXVALUE");
                    break;
                case SequenceOptionKind.Cache:
                    this.GenerateIdentifier("CACHE");
                    break;
                case SequenceOptionKind.Increment:
                    this.GenerateIdentifier("INCREMENT");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                    break;
                case SequenceOptionKind.Start:
                    this.GenerateIdentifier("START");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    break;
                case SequenceOptionKind.Restart:
                    this.GenerateIdentifier("RESTART");
                    if (node.OptionValue != null) {
                        this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                    }
                    break;
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.OptionValue);
        }

        public override void ExplicitVisit(AlterServerAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSpaceAndIdentifier("SERVER");
            this.GenerateSpace();
            this.GenerateAuditSpecificationStatement(node);
        }

        public override void ExplicitVisit(CreateServerAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSpaceAndIdentifier("SERVER");
            this.GenerateSpace();
            this.GenerateAuditSpecificationStatement(node);
        }

        public override void ExplicitVisit(DropServerAuditSpecificationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSpaceAndIdentifier("SERVER");
            this.GenerateSpaceAndIdentifier("AUDIT");
            this.GenerateSpaceAndIdentifier("SPECIFICATION");
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(QueueDelayAuditOption node) {
            this.GenerateNameEqualsValue("QUEUE_DELAY", node.Delay);
        }

        public override void ExplicitVisit(AuditGuidAuditOption node) {
            this.GenerateNameEqualsValue("AUDIT_GUID", node.Guid);
        }

        public override void ExplicitVisit(OnFailureAuditOption node) {
            this.GenerateTokenAndEqualSign("ON_FAILURE");
            switch (node.OnFailureAction) {
                case AuditFailureActionType.Shutdown:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Shutdown);
                    break;
                case AuditFailureActionType.Continue:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Continue);
                    break;
                case AuditFailureActionType.FailOperation:
                    this.GenerateSpaceAndIdentifier("FAIL_OPERATION");
                    break;
            }
        }

        public override void ExplicitVisit(StateAuditOption node) {
            this.GenerateOptionStateWithEqualSign("STATE", node.Value);
        }

        public override void ExplicitVisit(CreateServerAuditStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Create);
            this.GenerateServerAuditName(node.AuditName);
            this.GenerateSpaceAndFragmentIfNotNull(node.AuditTarget);
            this.GenerateServerAuditOptions(node);
            if (node.PredicateExpression != null) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.Where);
                this.GenerateFragmentIfNotNull(node.PredicateExpression);
            }
        }

        public override void ExplicitVisit(AlterServerAuditStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Alter);
            this.GenerateServerAuditName(node.AuditName);
            if (node.NewName != null) {
                this.GenerateSpaceAndIdentifier("MODIFY");
                this.GenerateSpace();
                this.GenerateNameEqualsValue("NAME", node.NewName);
            } else if (node.RemoveWhere) {
                this.GenerateSpaceAndIdentifier("REMOVE");
                this.GenerateSpaceAndKeyword(TSqlTokenType.Where);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.AuditTarget);
                this.GenerateServerAuditOptions(node);
                if (node.PredicateExpression != null) {
                    this.NewLineAndIndent();
                    this.GenerateKeywordAndSpace(TSqlTokenType.Where);
                    this.GenerateFragmentIfNotNull(node.PredicateExpression);
                }
            }
        }

        public override void ExplicitVisit(DropServerAuditStatement node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Drop);
            this.GenerateServerAuditName(node.Name);
        }

        private void GenerateServerAuditName(Identifier name) {
            this.GenerateIdentifier("SERVER");
            this.GenerateSpaceAndIdentifier("AUDIT");
            this.GenerateSpaceAndFragmentIfNotNull(name);
        }

        private void GenerateServerAuditOptions(ServerAuditStatement node) {
            if (node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(ServiceContract node) {
            switch (node.Action) {
                case AlterAction.Add:
                    this.GenerateKeyword(TSqlTokenType.Add);
                    this.GenerateSpaceAndIdentifier("CONTRACT");
                    this.GenerateSpace();
                    break;
                case AlterAction.Drop:
                    this.GenerateKeyword(TSqlTokenType.Drop);
                    this.GenerateSpaceAndIdentifier("CONTRACT");
                    this.GenerateSpace();
                    break;
            }
            this.GenerateFragmentIfNotNull(node.Name);
        }

        public override void ExplicitVisit(SessionTimeoutPayloadOption node) {
            if (node.IsNever) {
                this.GenerateNameEqualsValue("SESSION_TIMEOUT", "NEVER");
            } else {
                this.GenerateNameEqualsValue("SESSION_TIMEOUT", node.Timeout);
            }
        }

        protected void GenerateSetClauses(IList<SetClause> setClauses, AlignmentPoint alignmentPoint) {
            this.NewLine();
            if (this._options.IndentSetClause) {
                this.Indent();
            }
            this.GenerateKeyword(TSqlTokenType.Set);
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPoint);
            this.GenerateSpace();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateCommaSeparatedList(setClauses, this._options.MultilineSetClauseItems);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(FunctionCallSetClause node) {
            this.AlignWhenNecessary("SetClauseItemFirstEqualSign");
            this.GenerateFragmentIfNotNull(node.MutatorFunction);
        }

        public override void ExplicitVisit(AssignmentSetClause node) {
            if (node.Variable != null) {
                this.GenerateFragmentIfNotNull(node.Variable);
                this.AlignWhenNecessary("SetClauseItemFirstEqualSign");
            }
            if (node.Column != null && node.Variable != null) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Column);
            if (node.Column != null || node.Variable != null) {
                this.AlignWhenNecessary("SetClauseItemSecondEqualSign");
                TSqlTokenType valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._assignmentKindSymbols, node.AssignmentKind);
                this.GenerateSpaceAndSymbol(valueForEnumKey);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.NewValue);
        }

        private void AlignWhenNecessary(string apName) {
            if (this._options.MultilineSetClauseItems && this._options.AlignSetClauseItem) {
                AlignmentPoint ap = this.FindOrCreateAlignmentPointByName(apName);
                this.Mark(ap);
            }
        }

        public override void ExplicitVisit(SetCommandStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Commands);
        }

        public override void ExplicitVisit(SetErrorLevelStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Errlvl);
            this.GenerateSpaceAndFragmentIfNotNull(node.Level);
        }

        public override void ExplicitVisit(SetFipsFlaggerCommand node) {
            this.GenerateIdentifier("FIPS_FLAGGER");
            this.GenerateSpace();
            FipsComplianceLevelHelper.Instance.GenerateSourceForOption(this._writer, node.ComplianceLevel);
        }

        public override void ExplicitVisit(SetIdentityInsertStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.IdentityInsert);
            this.GenerateSpaceAndFragmentIfNotNull(node.Table);
            this.GenerateSpaceAndKeyword((TSqlTokenType)(node.IsOn ? 105 : 103));
        }

        public override void ExplicitVisit(SetOffsetsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Offsets);
            this.GenerateSpace();
            this.GenerateCommaSeparatedFlagOpitons(SqlScriptGeneratorVisitor._setOffsetsGenerators, node.Options);
            this.GenerateSpaceAndKeyword((TSqlTokenType)(node.IsOn ? 105 : 103));
        }

        public override void ExplicitVisit(SetRowCountStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.RowCount);
            this.GenerateSpaceAndFragmentIfNotNull(node.NumberRows);
        }

        public override void ExplicitVisit(SetStatisticsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Statistics);
            this.GenerateSpace();
            SetStatisticsOptionsHelper.Instance.GenerateCommaSeparatedFlagOptions(this._writer, node.Options);
            this.GenerateSpace();
            this.GenerateKeyword((TSqlTokenType)(node.IsOn ? 105 : 103));
        }

        public override void ExplicitVisit(SetTextSizeStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.TextSize);
            this.GenerateSpaceAndFragmentIfNotNull(node.TextSize);
        }

        public override void ExplicitVisit(SetTransactionIsolationLevelStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Transaction);
            this.GenerateSpaceAndIdentifier("ISOLATION");
            this.GenerateSpaceAndIdentifier("LEVEL");
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._isolationLevelGenerators, node.Level);
            if (valueForEnumKey != null) {
                this.GenerateSpace();
                this.GenerateTokenList(valueForEnumKey);
            }
        }

        public override void ExplicitVisit(SetUserStatement node) {
            this.GenerateKeyword(TSqlTokenType.SetUser);
            this.GenerateSpaceAndFragmentIfNotNull(node.UserName);
            if (node.WithNoReset) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("NORESET");
            }
        }

        public override void ExplicitVisit(SetVariableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Set);
            this.GenerateSpaceAndFragmentIfNotNull(node.Variable);
            if (node.SeparatorType != 0) {
                switch (node.SeparatorType) {
                    case SeparatorType.Dot:
                        this.GenerateSymbol(TSqlTokenType.Dot);
                        break;
                    case SeparatorType.DoubleColon:
                        this.GenerateSymbol(TSqlTokenType.DoubleColon);
                        break;
                }
                this.GenerateFragmentIfNotNull(node.Identifier);
                if (node.FunctionCallExists) {
                    this.GenerateSpace();
                    this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                    this.GenerateCommaSeparatedList(node.Parameters);
                    this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                }
            }
            if (node.Expression != null) {
                TSqlTokenType valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._assignmentKindSymbols, node.AssignmentKind);
                this.GenerateSpaceAndSymbol(valueForEnumKey);
                this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
            }
            if (node.CursorDefinition != null) {
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.CursorDefinition);
            }
        }

        public override void ExplicitVisit(ShutdownStatement node) {
            this.GenerateKeyword(TSqlTokenType.Shutdown);
            if (node.WithNoWait) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("NOWAIT");
            }
        }

        public override void ExplicitVisit(LiteralPrincipalOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._loginOptionsNames, node.OptionKind);
            this.GenerateNameEqualsValue(valueForEnumKey, node.Value);
        }

        protected void GenerateCounterSignature(SignatureStatementBase node) {
            if (node.IsCounter) {
                this.GenerateIdentifier("COUNTER");
                this.GenerateSpace();
            }
            this.GenerateIdentifier("SIGNATURE");
        }

        protected void GenerateModule(SignatureStatementBase node) {
            switch (node.ElementKind) {
                case SignableElementKind.Object:
                    this.GenerateIdentifier("OBJECT");
                    this.GenerateSymbol(TSqlTokenType.DoubleColon);
                    break;
                case SignableElementKind.Assembly:
                    this.GenerateIdentifier("ASSEMBLY");
                    this.GenerateSymbol(TSqlTokenType.DoubleColon);
                    break;
                case SignableElementKind.Database:
                    this.GenerateKeyword(TSqlTokenType.Database);
                    this.GenerateSymbol(TSqlTokenType.DoubleColon);
                    break;
            }
            this.GenerateFragmentIfNotNull(node.Element);
        }

        protected void GenerateCryptos(SignatureStatementBase node) {
            this.GenerateKeyword(TSqlTokenType.By);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Cryptos);
        }

        protected void GenerateSpaceAndAlias(Identifier alias) {
            if (alias != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                this.GenerateSpaceAndFragmentIfNotNull(alias);
            }
        }

        protected void GenerateTableAndColumnAliases(TableReferenceWithAliasAndColumns node) {
            this.GenerateSpaceAndAlias(node.Alias);
            this.GenerateParenthesisedCommaSeparatedList(node.Columns);
        }

        public override void ExplicitVisit(SoapMethod node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._soapMethodActionGenerators, node.Action);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            this.GenerateSpaceAndIdentifier("WEBMETHOD");
            if (node.Namespace != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.Namespace);
                this.GenerateSymbol(TSqlTokenType.Dot);
            } else {
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Alias);
            if (node.Action != SoapMethodAction.Drop) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                if (node.Name != null) {
                    this.GenerateNameEqualsValue("NAME", node.Name);
                }
                if (node.Schema != 0) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    this.GenerateTokenAndEqualSign(TSqlTokenType.Schema);
                    TokenGenerator valueForEnumKey2 = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._soapMethodSchemasGenerators, node.Schema);
                    if (valueForEnumKey2 != null) {
                        this.GenerateSpace();
                        this.GenerateToken(valueForEnumKey2);
                    }
                }
                if (node.Format != 0) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    string valueForEnumKey3 = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._soapMethodFormatNames, node.Format);
                    if (valueForEnumKey3 != null) {
                        this.GenerateNameEqualsValue("FORMAT", valueForEnumKey3);
                    }
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(SqlDataTypeReference node) {
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._sqlDataTypeOptionGenerators, node.SqlDataTypeOption);
            if (valueForEnumKey != null) {
                this.GenerateToken(valueForEnumKey);
            }
            this.GenerateParameters(node);
        }

        public override void ExplicitVisit(StatementList node) {
            if (node.Statements != null) {
                bool flag = true;
                foreach (TSqlStatement statement in node.Statements) {
                    if (flag) {
                        flag = false;
                    } else {
                        this.NewLine();
                    }
                    this.GenerateFragmentIfNotNull(statement);
                    this.GenerateSemiColonWhenNecessary(statement);
                }
            }
        }

        public override void ExplicitVisit(StatisticsOption node) {
            switch (node.OptionKind) {
                case StatisticsOptionKind.SamplePercent:
                case StatisticsOptionKind.SampleRows:
                case StatisticsOptionKind.StatsStream:
                case StatisticsOptionKind.RowCount:
                case StatisticsOptionKind.PageCount:
                    break;
                case StatisticsOptionKind.FullScan:
                    this.GenerateIdentifier("FULLSCAN");
                    break;
                case StatisticsOptionKind.NoRecompute:
                    this.GenerateIdentifier("NORECOMPUTE");
                    break;
                case StatisticsOptionKind.Resample:
                    this.GenerateIdentifier("RESAMPLE");
                    break;
                case StatisticsOptionKind.All:
                    this.GenerateKeyword(TSqlTokenType.All);
                    break;
                case StatisticsOptionKind.Columns:
                    this.GenerateIdentifier("COLUMNS");
                    break;
                case StatisticsOptionKind.Index:
                    this.GenerateKeyword(TSqlTokenType.Index);
                    break;
                case StatisticsOptionKind.Rows:
                    this.GenerateIdentifier("ROWS");
                    break;
            }
        }

        public override void ExplicitVisit(LiteralStatisticsOption node) {
            switch (node.OptionKind) {
                case StatisticsOptionKind.NoRecompute:
                case StatisticsOptionKind.Resample:
                    break;
                case StatisticsOptionKind.SamplePercent:
                    this.GenerateIdentifier("SAMPLE");
                    this.GenerateSpaceAndFragmentIfNotNull(node.Literal);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Percent);
                    break;
                case StatisticsOptionKind.SampleRows:
                    this.GenerateIdentifier("SAMPLE");
                    this.GenerateSpaceAndFragmentIfNotNull(node.Literal);
                    this.GenerateSpaceAndIdentifier("ROWS");
                    break;
                case StatisticsOptionKind.StatsStream:
                    this.GenerateNameEqualsValue("STATS_STREAM", node.Literal);
                    break;
                case StatisticsOptionKind.RowCount:
                    this.GenerateNameEqualsValue(TSqlTokenType.RowCount, node.Literal);
                    break;
                case StatisticsOptionKind.PageCount:
                    this.GenerateNameEqualsValue("PAGECOUNT", node.Literal);
                    break;
            }
        }

        public override void ExplicitVisit(OnOffStatisticsOption node) {
            string optionName = string.Empty;
            StatisticsOptionKind optionKind = node.OptionKind;
            if (optionKind == StatisticsOptionKind.Incremental) {
                optionName = "INCREMENTAL";
            }
            this.GenerateOptionStateWithEqualSign(optionName, node.OptionState);
        }

        public override void ExplicitVisit(ResampleStatisticsOption node) {
            string text = string.Empty;
            StatisticsOptionKind optionKind = node.OptionKind;
            if (optionKind == StatisticsOptionKind.Resample) {
                text = "RESAMPLE";
            }
            this.GenerateIdentifier(text);
            if (node.Partitions.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndIdentifier("PARTITIONS");
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Partitions);
            }
        }

        public override void ExplicitVisit(StatisticsPartitionRange node) {
            this.GenerateFragmentIfNotNull(node.From);
            if (node.To != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                this.GenerateSpaceAndFragmentIfNotNull(node.To);
            }
        }

        public override void ExplicitVisit(StopRestoreOption node) {
            this.GenerateNameEqualsValue(node.IsStopAt ? "STOPATMARK" : "STOPBEFOREMARK", node.Mark);
            if (node.After != null) {
                this.GenerateSpaceAndIdentifier("AFTER");
                this.GenerateSpaceAndFragmentIfNotNull(node.After);
            }
        }

        public override void ExplicitVisit(SubqueryComparisonPredicate node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.Expression);
            this.PopAlignmentPoint();
            this.GenerateSpace();
            this.GenerateBinaryOperator(node.ComparisonType);
            if (node.SubqueryComparisonPredicateType != 0) {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._subqueryComparisonPredicateTypeGenerators, node.SubqueryComparisonPredicateType);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateToken(valueForEnumKey);
                }
            }
            AlignmentPoint ap2 = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap2);
            this.GenerateSpaceAndFragmentIfNotNull(node.Subquery);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(CreateSymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Create);
            this.GenerateSymmetricKeyName(node.Name);
            this.GenerateOwnerIfNotNull(node.Owner);
            if (node.Provider != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                this.GenerateSpaceAndIdentifier("PROVIDER");
                this.GenerateSpaceAndFragmentIfNotNull(node.Provider);
            }
            if (node.KeyOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeywordAndSpace(TSqlTokenType.With);
                this.GenerateCommaSeparatedList(node.KeyOptions);
            }
            if (node.EncryptingMechanisms.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateIdentifier("ENCRYPTION");
                this.GenerateSpaceAndKeyword(TSqlTokenType.By);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.EncryptingMechanisms);
            }
        }

        public override void ExplicitVisit(AlterSymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Alter);
            this.GenerateSymmetricKeyName(node.Name);
            this.GenerateSpaceAndKeyword((TSqlTokenType)(node.IsAdd ? 4 : 54));
            this.GenerateSpaceAndIdentifier("ENCRYPTION");
            this.GenerateSpaceAndKeyword(TSqlTokenType.By);
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.EncryptingMechanisms);
        }

        public override void ExplicitVisit(DropSymmetricKeyStatement node) {
            this.GenerateKeyword(TSqlTokenType.Drop);
            this.GenerateSymmetricKeyName(node.Name);
            this.GenerateRemoveProviderKeyOpt(node.RemoveProviderKey);
        }

        public override void ExplicitVisit(AlgorithmKeyOption node) {
            this.GenerateTokenAndEqualSign("ALGORITHM");
            this.GenerateSpace();
            EncryptionAlgorithmsHelper.Instance.GenerateSourceForOption(this._writer, node.Algorithm);
        }

        public override void ExplicitVisit(IdentityValueKeyOption node) {
            this.GenerateNameEqualsValue("IDENTITY_VALUE", node.IdentityPhrase);
        }

        public override void ExplicitVisit(KeySourceKeyOption node) {
            this.GenerateNameEqualsValue("KEY_SOURCE", node.PassPhrase);
        }

        public override void ExplicitVisit(ProviderKeyNameKeyOption node) {
            this.GenerateNameEqualsValue("PROVIDER_KEY_NAME", node.KeyName);
        }

        public override void ExplicitVisit(CreationDispositionKeyOption node) {
            this.GenerateTokenAndEqualSign("CREATION_DISPOSITION");
            this.GenerateSpaceAndIdentifier(node.IsCreateNew ? "CREATE_NEW" : "OPEN_EXISTING");
        }

        private void GenerateSymmetricKeyName(Identifier name) {
            this.GenerateSpaceAndIdentifier("SYMMETRIC");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            this.GenerateSpaceAndFragmentIfNotNull(name);
        }

        public override void ExplicitVisit(SystemTimePeriodDefinition node) {
            this.GenerateIdentifier("PERIOD");
            this.GenerateSpaceAndIdentifier("FOR");
            this.GenerateSpaceAndIdentifier("SYSTEM_TIME");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.StartTimeColumn);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpace();
            this.GenerateFragmentIfNotNull(node.EndTimeColumn);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(SystemVersioningTableOption node) {
            this.GenerateIdentifier("SYSTEM_VERSIONING");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            if (node.OptionState == OptionState.On) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                if (node.ConsistencyCheckEnabled == OptionState.NotSet && node.HistoryTable == null && node.RetentionPeriod == null) {
                    return;
                }
                bool flag = false;
                this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
                if (node.HistoryTable != null) {
                    this.GenerateIdentifier("HISTORY_TABLE");
                    this.GenerateKeyword(TSqlTokenType.EqualsSign);
                    this.GenerateFragmentIfNotNull(node.HistoryTable);
                    flag = true;
                }
                if (node.ConsistencyCheckEnabled != 0) {
                    if (flag) {
                        this.GenerateKeyword(TSqlTokenType.Comma);
                    }
                    this.GenerateSpaceAndIdentifier("DATA_CONSISTENCY_CHECK");
                    this.GenerateKeyword(TSqlTokenType.EqualsSign);
                    if (node.ConsistencyCheckEnabled == OptionState.On) {
                        this.GenerateKeyword(TSqlTokenType.On);
                    } else {
                        this.GenerateKeyword(TSqlTokenType.Off);
                    }
                    flag = true;
                }
                if (node.RetentionPeriod != null) {
                    if (flag) {
                        this.GenerateKeyword(TSqlTokenType.Comma);
                    }
                    this.GenerateSpaceAndIdentifier("HISTORY_RETENTION_PERIOD");
                    this.GenerateKeyword(TSqlTokenType.EqualsSign);
                    if (node.RetentionPeriod.IsInfinity) {
                        this.GenerateIdentifier("INFINITE");
                    } else {
                        this.GenerateFragmentIfNotNull(node.RetentionPeriod.Duration);
                        this.GenerateSpace();
                        TemporalRetentionPeriodUnitHelper.Instance.GenerateSourceForOption(this._writer, node.RetentionPeriod.Units);
                    }
                }
                this.GenerateKeyword(TSqlTokenType.RightParenthesis);
            } else {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
            }
        }

        protected void GenerateWithTableHints(IList<TableHint> tableHints) {
            if (tableHints.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(tableHints);
            }
        }

        public override void ExplicitVisit(TableHint node) {
            TableHintOptionsHelper.Instance.GenerateSourceForOption(this._writer, node.HintKind);
        }

        public override void ExplicitVisit(IndexTableHint node) {
            this.GenerateKeywordAndSpace(TSqlTokenType.Index);
            this.GenerateParenthesisedCommaSeparatedList(node.IndexValues);
        }

        public override void ExplicitVisit(LiteralTableHint node) {
            this.GenerateNameEqualsValue("SPATIAL_WINDOW_MAX_CELLS", node.Value);
        }

        public override void ExplicitVisit(ForceSeekTableHint node) {
            this.GenerateIdentifier("FORCESEEK");
            if (node.IndexValue != null) {
                this.GenerateSpace();
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(node.IndexValue);
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.ColumnValues);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(TableSampleClause node) {
            this.GenerateKeyword(TSqlTokenType.TableSample);
            if (node.System) {
                this.GenerateSpaceAndIdentifier("SYSTEM");
            }
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.SampleNumber);
            TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._tableSampleClauseOptionGenerators, node.TableSampleClauseOption);
            if (valueForEnumKey != null && node.TableSampleClauseOption != 0) {
                this.GenerateSpace();
                this.GenerateToken(valueForEnumKey);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            if (node.RepeatSeed != null) {
                this.GenerateSpaceAndIdentifier("REPEATABLE");
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.RepeatSeed);
            }
        }

        public override void ExplicitVisit(TableValuedFunctionReturnType node) {
            this.NewLineAndIndent();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.DeclareTableVariableBody);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node) {
            this.GenerateIdentifier("TARGET_RECOVERY_TIME");
            this.GenerateSpace();
            this.GenerateSymbolAndSpace(TSqlTokenType.EqualsSign);
            this.GenerateFragmentIfNotNull(node.RecoveryTime);
            this.GenerateSpace();
            TargetRecoveryTimeUnitHelper.Instance.GenerateSourceForOption(this._writer, node.Unit);
        }

        public override void ExplicitVisit(ThrowStatement node) {
            this.GenerateIdentifier("THROW");
            this.GenerateSpaceAndFragmentIfNotNull(node.ErrorNumber);
            if (node.ErrorNumber != null && node.Message != null) {
                this.GenerateKeyword(TSqlTokenType.Comma);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Message);
            if (node.Message != null && node.State != null) {
                this.GenerateKeyword(TSqlTokenType.Comma);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.State);
        }

        public override void ExplicitVisit(TopRowFilter node) {
            this.GenerateKeyword(TSqlTokenType.Top);
            this.GenerateSpaceAndFragmentIfNotNull(node.Expression);
            if (node.Percent) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Percent);
            }
            if (node.WithTies) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("TIES");
            }
        }

        public override void ExplicitVisit(TemporalClause node) {
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndIdentifier("SYSTEM_TIME");
            switch (node.TemporalClauseType) {
                case TemporalClauseType.AsOf:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.As);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Of);
                    this.GenerateSpace();
                    break;
                case TemporalClauseType.FromTo:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.From);
                    this.GenerateSpace();
                    break;
                case TemporalClauseType.Between:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Between);
                    this.GenerateSpace();
                    break;
                case TemporalClauseType.ContainedIn:
                    this.GenerateSpaceAndIdentifier("CONTAINED");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.In);
                    this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
                    break;
                case TemporalClauseType.TemporalAll:
                    this.GenerateSpaceAndKeyword(TSqlTokenType.All);
                    break;
            }
            if (node.TemporalClauseType != TemporalClauseType.TemporalAll) {
                this.GenerateFragmentIfNotNull(node.StartTime);
                if (node.TemporalClauseType != 0) {
                    switch (node.TemporalClauseType) {
                        case TemporalClauseType.FromTo:
                            this.GenerateSpaceAndKeyword(TSqlTokenType.To);
                            break;
                        case TemporalClauseType.Between:
                            this.GenerateSpaceAndKeyword(TSqlTokenType.And);
                            break;
                        case TemporalClauseType.ContainedIn:
                            this.GenerateKeyword(TSqlTokenType.Comma);
                            break;
                    }
                    this.GenerateSpaceAndFragmentIfNotNull(node.EndTime);
                    if (node.TemporalClauseType == TemporalClauseType.ContainedIn) {
                        this.GenerateKeyword(TSqlTokenType.RightParenthesis);
                    }
                }
            }
        }

        protected void GenerateTransactionName(object node) {
            string text = node as string;
            if (text != null) {
                this.GenerateIdentifierWithoutCasing(text);
            } else {
                TSqlFragment tSqlFragment = node as TSqlFragment;
                if (tSqlFragment != null) {
                    this.GenerateFragmentIfNotNull(tSqlFragment);
                }
            }
        }

        public override void ExplicitVisit(TriggerAction node) {
            switch (node.TriggerActionType) {
                case TriggerActionType.Delete:
                    this.GenerateKeyword(TSqlTokenType.Delete);
                    break;
                case TriggerActionType.Insert:
                    this.GenerateKeyword(TSqlTokenType.Insert);
                    break;
                case TriggerActionType.Update:
                    this.GenerateKeyword(TSqlTokenType.Update);
                    break;
                case TriggerActionType.Event:
                    this.GenerateFragmentIfNotNull(node.EventTypeGroup);
                    break;
                case TriggerActionType.LogOn:
                    this.GenerateIdentifier("LOGON");
                    break;
            }
        }

        public override void ExplicitVisit(TriggerObject node) {
            switch (node.TriggerScope) {
                case TriggerScope.Normal:
                    this.GenerateFragmentIfNotNull(node.Name);
                    break;
                case TriggerScope.Database:
                    this.GenerateKeyword(TSqlTokenType.Database);
                    break;
                case TriggerScope.AllServer:
                    this.GenerateKeyword(TSqlTokenType.All);
                    this.GenerateSpaceAndIdentifier("SERVER");
                    break;
            }
        }

        public override void ExplicitVisit(TriggerOption node) {
            switch (node.OptionKind) {
                case TriggerOptionKind.ExecuteAsClause:
                    break;
                case TriggerOptionKind.Encryption:
                    this.GenerateIdentifier("ENCRYPTION");
                    break;
                case TriggerOptionKind.NativeCompile:
                    this.GenerateIdentifier("NATIVE_COMPILATION");
                    break;
                case TriggerOptionKind.SchemaBinding:
                    this.GenerateIdentifier("SCHEMABINDING");
                    break;
            }
        }

        public override void ExplicitVisit(ExecuteAsTriggerOption node) {
            this.GenerateFragmentIfNotNull(node.ExecuteAsClause);
        }

        protected void GenerateTriggerStatementBody(TriggerStatementBody node) {
            this.GenerateKeyword(TSqlTokenType.Trigger);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.On);
            this.GenerateSpaceAndFragmentIfNotNull(node.TriggerObject);
            this.GenerateCommaSeparatedWithClause(node.Options, true, false);
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._triggerTypeGenerators, node.TriggerType);
            if (valueForEnumKey != null) {
                this.NewLineAndIndent();
                this.GenerateTokenList(valueForEnumKey);
            }
            if (node.TriggerActions != null && node.TriggerActions.Count > 0) {
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.TriggerActions);
            }
            if (node.WithAppend) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("APPEND");
            }
            if (node.IsNotForReplication) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.Not);
                this.GenerateSpaceAndKeyword(TSqlTokenType.For);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Replication);
            }
            this.NewLineAndIndent();
            this.GenerateKeyword(TSqlTokenType.As);
            this.GenerateSpace();
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.StatementList);
            this.PopAlignmentPoint();
            this.GenerateSpaceAndFragmentIfNotNull(node.MethodSpecifier);
        }

        public override void ExplicitVisit(TruncateTableStatement node) {
            this.GenerateKeyword(TSqlTokenType.Truncate);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Table);
            this.GenerateSpaceAndFragmentIfNotNull(node.TableName);
            if (node.PartitionRanges != null && node.PartitionRanges.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
                this.GenerateSpaceAndIdentifier("PARTITIONS");
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.PartitionRanges);
                this.GenerateSpaceAndKeyword(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(TryCastCall node) {
            this.GenerateIdentifier("TRY_CAST");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.Parameter);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(TryCatchStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.GenerateSpaceAndIdentifier("TRY");
            if (node.TryStatements.Statements.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateFragmentIfNotNull(node.TryStatements);
                this.PopAlignmentPoint();
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.End);
            this.GenerateSpaceAndIdentifier("TRY");
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.Begin);
            this.GenerateSpaceAndIdentifier("CATCH");
            if (node.CatchStatements.Statements.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateFragmentIfNotNull(node.CatchStatements);
                this.PopAlignmentPoint();
            }
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.End);
            this.GenerateSpaceAndIdentifier("CATCH");
        }

        public override void ExplicitVisit(TryConvertCall node) {
            this.GenerateKeyword(TSqlTokenType.TryConvert);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.DataType);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.Parameter);
            if (node.Style != null) {
                this.GenerateSymbol(TSqlTokenType.Comma);
                this.GenerateSpaceAndFragmentIfNotNull(node.Style);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(TryParseCall node) {
            this.GenerateIdentifier("TRY_PARSE");
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.StringValue);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.DataType);
            if (node.Culture != null) {
                this.GenerateSpace();
                this.GenerateIdentifier("USING");
                this.GenerateSpaceAndFragmentIfNotNull(node.Culture);
            }
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(TSEqualCall node) {
            this.GenerateKeyword(TSqlTokenType.TSEqual);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.FirstExpression);
            this.GenerateSymbol(TSqlTokenType.Comma);
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondExpression);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(TSqlBatch node) {
            foreach (TSqlStatement statement in node.Statements) {
                this.GenerateFragmentIfNotNull(statement);
                this.GenerateSemiColonWhenNecessary(statement);
                if (!(statement is TSqlStatementSnippet)) {
                    this.NewLine();
                    this.NewLine();
                }
            }
        }

        public override void ExplicitVisit(TSqlScript node) {
            bool flag = true;
            foreach (TSqlBatch batch in node.Batches) {
                if (flag) {
                    flag = false;
                } else {
                    this.NewLine();
                    this.GenerateKeyword(TSqlTokenType.Go);
                    this.NewLine();
                }
                this.GenerateFragmentIfNotNull(batch);
            }
        }

        public override void ExplicitVisit(UnaryExpression node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._unaryExpressionTypeGenerators, node.UnaryExpressionType);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
            if (node.Expression is UnaryExpression && node.UnaryExpressionType == UnaryExpressionType.Negative && (node.Expression as UnaryExpression).UnaryExpressionType == UnaryExpressionType.Negative) {
                this.GenerateSpace();
            }
            this.GenerateFragmentIfNotNull(node.Expression);
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node) {
            this.GenerateConstraintHead(node);
            if (node.IsPrimaryKey) {
                this.GenerateKeyword(TSqlTokenType.Primary);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
            } else {
                this.GenerateKeyword(TSqlTokenType.Unique);
            }
            if (node.Clustered.HasValue && node.IndexType == null) {
                this.GenerateSpaceAndKeyword((TSqlTokenType)(node.Clustered.Value ? 24 : 98));
            }
            if (node.IndexType != null) {
                switch (node.IndexType.IndexTypeKind) {
                    case IndexTypeKind.Clustered:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.Clustered);
                        break;
                    case IndexTypeKind.NonClusteredHash:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        this.GenerateSpaceAndIdentifier("HASH");
                        break;
                    case IndexTypeKind.NonClustered:
                        this.GenerateSpaceAndKeyword(TSqlTokenType.NonClustered);
                        break;
                }
            }
            if (node.Columns.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.Columns);
            }
            if (node.IndexOptions.Count > 0) {
                this.GenerateIndexOptions(node.IndexOptions);
            }
            if (node.OnFileGroupOrPartitionScheme != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                this.GenerateSpaceAndFragmentIfNotNull(node.OnFileGroupOrPartitionScheme);
            }
            this.GenerateFileStreamOn(node);
        }

        public override void ExplicitVisit(UnpivotedTableReference node) {
            this.GenerateFragmentIfNotNull(node.TableReference);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Unpivot);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            this.GenerateFragmentIfNotNull(node.ValueColumn);
            this.GenerateSpaceAndKeyword(TSqlTokenType.For);
            this.GenerateSpaceAndFragmentIfNotNull(node.PivotColumn);
            this.GenerateSpaceAndKeyword(TSqlTokenType.In);
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.InColumns, true);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(UnqualifiedJoin node) {
            this.GenerateFragmentIfNotNull(node.FirstTableReference);
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._unqualifiedJoinTypeGenerators, node.UnqualifiedJoinType);
            if (valueForEnumKey != null) {
                this.GenerateSpace();
                this.GenerateTokenList(valueForEnumKey);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.SecondTableReference);
        }

        public override void ExplicitVisit(UpdateCall node) {
            this.GenerateKeyword(TSqlTokenType.Update);
            this.GenerateSpace();
            this.GenerateParenthesisedFragmentIfNotNull(node.Identifier);
        }

        public override void ExplicitVisit(UpdateForClause node) {
            this.GenerateKeyword(TSqlTokenType.Update);
            if (node.Columns.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Of);
                this.GenerateSpace();
            }
            this.GenerateCommaSeparatedList(node.Columns);
        }

        public override void ExplicitVisit(UpdateStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint ap2 = new AlignmentPoint("ClauseBody");
            this.MarkAndPushAlignmentPoint(ap);
            if (node.WithCtesAndXmlNamespaces != null) {
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WithCtesAndXmlNamespaces, ap2);
                this.NewLine();
            }
            this.GenerateFragmentIfNotNull(node.UpdateSpecification);
            this.GenerateOptimizerHints(node.OptimizerHints);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(UpdateSpecification node) {
            AlignmentPoint alignmentPoint = new AlignmentPoint("ClauseBody");
            this.GenerateKeyword(TSqlTokenType.Update);
            this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPoint);
            if (node.TopRowFilter != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.TopRowFilter);
                this.NewLine();
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.Target);
            this.GenerateSetClauses(node.SetClauses, alignmentPoint);
            if (node.OutputIntoClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputIntoClause, alignmentPoint);
            }
            if (node.OutputClause != null) {
                this.GenerateSeparatorForOutputClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.OutputClause, alignmentPoint);
            }
            this.GenerateFromClause(node.FromClause, alignmentPoint);
            if (node.WhereClause != null) {
                this.GenerateSeparatorForWhereClause();
                this.GenerateFragmentWithAlignmentPointIfNotNull(node.WhereClause, alignmentPoint);
            }
        }

        public override void ExplicitVisit(UpdateStatisticsStatement node) {
            this.GenerateKeyword(TSqlTokenType.Update);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Statistics);
            this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
            if (node.SubElements.Count > 0) {
                this.GenerateSpace();
                this.GenerateParenthesisedCommaSeparatedList(node.SubElements);
            }
            if (node.StatisticsOptions.Count > 0) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.StatisticsOptions);
            }
        }

        public override void ExplicitVisit(UpdateTextStatement node) {
            this.GenerateKeyword(TSqlTokenType.UpdateText);
            this.GenerateSpace();
            this.GenerateBulkColumnTimestamp(node);
            this.GenerateSpaceAndFragmentIfNotNull(node.InsertOffset);
            this.GenerateSpaceAndFragmentIfNotNull(node.DeleteLength);
            this.NewLine();
            this.GenerateKeyword(TSqlTokenType.With);
            this.GenerateSpaceAndIdentifier("LOG");
            if (node.SourceColumn != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.SourceColumn);
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.SourceParameter);
        }

        public override void ExplicitVisit(UseFederationStatement node) {
            this.GenerateKeyword(TSqlTokenType.Use);
            this.GenerateSpaceAndIdentifier("FEDERATION");
            if (node.FederationName == null) {
                this.GenerateSpaceAndIdentifier("ROOT");
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.FederationName);
                this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(node.DistributionName);
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.Value);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("FILTERING");
                this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                if (node.Filtering) {
                    this.GenerateSpaceAndKeyword(TSqlTokenType.On);
                } else {
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
                }
                this.GenerateSymbol(TSqlTokenType.Comma);
            }
            this.GenerateSpaceAndIdentifier("RESET");
        }

        public override void ExplicitVisit(UseHintList node) {
            this.GenerateKeyword(TSqlTokenType.Use);
            this.GenerateSpace();
            this.GenerateIdentifier("HINT");
            this.GenerateParenthesisedCommaSeparatedList(node.Hints);
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            this.GenerateFragmentIfNotNull(node.Name);
            this.GenerateParameters(node);
        }

        public override void ExplicitVisit(UserDefinedTypePropertyAccess node) {
            this.GenerateFragmentIfNotNull(node.CallTarget);
            this.GenerateFragmentIfNotNull(node.PropertyName);
            this.GenerateSpaceAndCollation(node.Collation);
        }

        public override void ExplicitVisit(UserLoginOption node) {
            switch (node.UserLoginOptionType) {
                case UserLoginOptionType.Login:
                    this.GenerateKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier("LOGIN");
                    this.GenerateSpaceAndFragmentIfNotNull(node.Identifier);
                    break;
                case UserLoginOptionType.Certificate:
                    this.GenerateKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier("CERTIFICATE");
                    this.GenerateSpaceAndFragmentIfNotNull(node.Identifier);
                    break;
                case UserLoginOptionType.AsymmetricKey:
                    this.GenerateKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier("ASYMMETRIC");
                    this.GenerateSpaceAndKeyword(TSqlTokenType.Key);
                    this.GenerateSpaceAndFragmentIfNotNull(node.Identifier);
                    break;
                case UserLoginOptionType.External:
                    this.GenerateKeyword(TSqlTokenType.For);
                    this.GenerateSpaceAndIdentifier("EXTERNAL");
                    this.GenerateSpaceAndIdentifier("PROVIDER");
                    break;
                case UserLoginOptionType.WithoutLogin:
                    this.GenerateIdentifier("WITHOUT");
                    this.GenerateSpaceAndIdentifier("LOGIN");
                    break;
            }
        }

        public override void ExplicitVisit(UseStatement node) {
            this.GenerateKeyword(TSqlTokenType.Use);
            this.GenerateSpaceAndFragmentIfNotNull(node.DatabaseName);
        }

        public static TValue GetValueForEnumKey<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key) where TKey : struct, IConvertible {
            TValue result = default(TValue);
            dict.TryGetValue(key, out result);
            return result;
        }

        protected void GenerateFragmentList<T>(IList<T> fragmentList) where T : TSqlFragment {
            bool flag = true;
            foreach (T item in (IEnumerable<T>)fragmentList) {
                TSqlFragment fragment = (TSqlFragment)(object)item;
                if (flag) {
                    flag = false;
                } else {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                }
                this.GenerateFragmentIfNotNull(fragment);
            }
        }

        protected void GenerateOptionStateWithEqualSign(string optionName, OptionState optionState) {
            this.GenerateOptionState(optionName, optionState, true);
        }

        protected void GenerateOptionState(string optionName, OptionState optionState) {
            this.GenerateOptionState(optionName, optionState, false);
        }

        protected void GenerateOptionState(string optionName, OptionState optionState, bool generateEqualSign) {
            if (optionState != 0) {
                this.GenerateIdentifier(optionName);
                if (generateEqualSign) {
                    this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
                }
                this.GenerateSpace();
                this.GenerateOptionStateOnOff(optionState);
            }
        }

        protected void GenerateDatabaseConfigurationOptionStateOnOff(DatabaseConfigurationOptionState optionState) {
            switch (optionState) {
                case DatabaseConfigurationOptionState.On:
                    this.GenerateKeyword(TSqlTokenType.On);
                    break;
                case DatabaseConfigurationOptionState.Off:
                    this.GenerateKeyword(TSqlTokenType.Off);
                    break;
            }
        }

        protected void GenerateOptionStateOnOff(OptionState optionState) {
            switch (optionState) {
                case OptionState.On:
                    this.GenerateKeyword(TSqlTokenType.On);
                    break;
                case OptionState.Off:
                    this.GenerateKeyword(TSqlTokenType.Off);
                    break;
            }
        }

        protected void GenerateOptionStateInSql80Style(string optionName, OptionState optionState) {
            if (optionState == OptionState.On) {
                this.GenerateIdentifier(optionName);
            }
        }

        protected void GenerateNameEqualsValue(string name, TSqlFragment value) {
            this.GenerateTokenAndEqualSign(name);
            this.GenerateSpaceAndFragmentIfNotNull(value);
        }

        protected void GenerateNameEqualsValue(string name, string value) {
            this.GenerateTokenAndEqualSign(name);
            this.GenerateSpaceAndIdentifier(value);
        }

        protected void GenerateNameEqualsValue(TSqlTokenType keywordId, TSqlFragment value) {
            this.GenerateTokenAndEqualSign(keywordId);
            this.GenerateSpaceAndFragmentIfNotNull(value);
        }

        protected void GenerateNameEqualsValue(TSqlTokenType keywordId, string value) {
            this.GenerateTokenAndEqualSign(keywordId);
            this.GenerateSpaceAndIdentifier(value);
        }

        protected void GenerateNameEqualsValue(TokenGenerator generator, TSqlFragment value) {
            this.GenerateToken(generator);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(value);
        }

        protected void GenerateNameEqualsValue(TokenGenerator generator, string value) {
            this.GenerateToken(generator);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndIdentifier(value);
        }

        protected void GenerateTokenAndEqualSign(string idText) {
            this.GenerateIdentifierWithoutCasing(idText);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
        }

        protected void GenerateTokenAndEqualSign(TSqlTokenType keywordId) {
            this.GenerateKeyword(keywordId);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
        }

        protected void GenerateFragmentIfNotNull(TSqlFragment fragment) {
            if (fragment != null) {
                fragment.Accept(this);
            }
        }

        protected void GenerateSpaceAndFragmentIfNotNull(TSqlFragment fragment) {
            if (fragment != null) {
                this.GenerateSpace();
                this.GenerateFragmentIfNotNull(fragment);
            }
        }

        protected void GenerateParenthesisedFragmentIfNotNull(TSqlFragment fragment) {
            if (fragment != null) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(fragment);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        protected void GenerateCommaSeparatedList<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateCommaSeparatedList(list, false);
        }

        protected void GenerateCommaSeparatedList<T>(IList<T> list, bool insertNewLine) where T : TSqlFragment {
            this.GenerateList(list, delegate {
                this.GenerateSymbol(TSqlTokenType.Comma);
                if (insertNewLine) {
                    this.NewLine();
                } else {
                    this.GenerateSpace();
                }
            });
        }

        protected void GenerateCommaSeparatedList<T>(IList<T> list, bool insertNewLine, bool indent) where T : TSqlFragment {
            this.GenerateList(list, delegate {
                this.GenerateSymbol(TSqlTokenType.Comma);
                if (insertNewLine) {
                    this.NewLine();
                    if (indent) {
                        this.Indent();
                    }
                } else {
                    this.GenerateSpace();
                }
            });
        }

        protected void GenerateDotSeparatedList<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateList(list, delegate {
                this.GenerateSymbol(TSqlTokenType.Dot);
            });
        }

        protected void GenerateSpaceSeparatedList<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateList(list, delegate {
                this.GenerateSpace();
            });
        }

        private void GenerateList<T>(IList<T> list, Action gen) where T : TSqlFragment {
            if (list != null) {
                bool flag = true;
                foreach (T item in (IEnumerable<T>)list) {
                    if (flag) {
                        flag = false;
                    } else {
                        gen();
                    }
                    this.GenerateFragmentIfNotNull((TSqlFragment)(object)item);
                }
            }
        }

        protected void GenerateParenthesisedCommaSeparatedList<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateParenthesisedCommaSeparatedList(list, false);
        }

        protected void GenerateParenthesisedCommaSeparatedList<T>(IList<T> list, bool alwaysGenerateParenthses) where T : TSqlFragment {
            if (list != null && ((ICollection<T>)list).Count > 0) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateCommaSeparatedList(list);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            } else if (alwaysGenerateParenthses) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        protected void GenerateFragmentList<T>(IList<T> list, ListGenerationOption option) where T : TSqlFragment {
            AlignmentPoint ap = new AlignmentPoint();
            AlignmentPoint ap2 = new AlignmentPoint();
            bool flag = option.AlwaysGenerateParenthesis || (((ICollection<T>)list).Count > 0 && option.Parenthesised);
            if (flag) {
                if (option.NewLineBeforeOpenParenthesis) {
                    this.NewLine();
                } else {
                    this.GenerateSpace();
                }
                if (option.IndentParentheses) {
                    this.Indent();
                }
                this.Mark(ap);
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                if (option.NewLineAfterOpenParenthesis) {
                    this.NewLine();
                }
            }
            bool flag2 = true;
            foreach (T item in (IEnumerable<T>)list) {
                if (flag2) {
                    if (option.NewLineBeforeFirstItem && !option.NewLineAfterOpenParenthesis) {
                        this.NewLine();
                    }
                    flag2 = false;
                } else {
                    this.GenerateSeparator(option);
                    if (option.NewLineBeforeItems) {
                        this.NewLine();
                    }
                }
                for (int i = 0; i < option.MultipleIndentItems; i++) {
                    this.Indent();
                }
                if (option.NewLineBeforeItems) {
                    this.Mark(ap2);
                }
                this.GenerateFragmentIfNotNull((TSqlFragment)(object)item);
            }
            if (flag) {
                if (option.NewLineBeforeCloseParenthesis) {
                    this.NewLine();
                    if (option.AlignParentheses) {
                        this.Mark(ap);
                    }
                }
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        protected void GenerateAlignedParenthesizedOptionsWithMultipleIndent<T>(IList<T> list, int indentValue) where T : TSqlFragment {
            ListGenerationOption listGenerationOption = ListGenerationOption.CreateOptionFromFormattingConfig(this._options);
            listGenerationOption.AlignParentheses = true;
            listGenerationOption.MultipleIndentItems = indentValue;
            if (((ICollection<T>)list).Count > 0) {
                this.GenerateFragmentList(list, listGenerationOption);
            } else {
                this.GenerateParenthesisedCommaSeparatedList(list, true);
            }
        }

        protected void GenerateAlignedParenthesizedOptions<T>(IList<T> list) where T : TSqlFragment {
            this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(list, 0);
        }

        private void GenerateSeparator(ListGenerationOption option) {
            switch (option.Separator) {
                case ListGenerationOption.SeparatorType.Comma:
                    this.GenerateSymbol(TSqlTokenType.Comma);
                    if (!option.NewLineBeforeItems) {
                        this.GenerateSpace();
                    }
                    break;
                case ListGenerationOption.SeparatorType.Dot:
                    this.GenerateSymbol(TSqlTokenType.Dot);
                    break;
                case ListGenerationOption.SeparatorType.Space:
                    this.GenerateSpace();
                    break;
            }
        }

        protected void GenerateSpace() {
            this._writer.AddToken(ScriptGeneratorSupporter.CreateWhitespaceToken(1));
        }

        protected void GenerateKeyword(TSqlTokenType keywordId) {
            this._writer.AddKeyword(keywordId);
        }

        protected void GenerateKeywordAndSpace(TSqlTokenType keywordId) {
            this.GenerateKeyword(keywordId);
            this.GenerateSpace();
        }

        protected void GenerateSpaceAndKeyword(TSqlTokenType keywordId) {
            this.GenerateSpace();
            this.GenerateKeyword(keywordId);
        }

        protected void GenerateSymbol(TSqlTokenType symbolId) {
            this.GenerateKeyword(symbolId);
        }

        protected void GenerateToken(TSqlTokenType tokenType, string text) {
            TSqlParserToken token = new TSqlParserToken(tokenType, text);
            this._writer.AddToken(token);
        }

        protected void GenerateSpaceAndSymbol(TSqlTokenType symbolId) {
            this.GenerateSpace();
            this.GenerateSymbol(symbolId);
        }

        protected void GenerateSymbolAndSpace(TSqlTokenType symbolId) {
            this.GenerateSymbol(symbolId);
            this.GenerateSpace();
        }

        protected void GenerateIdentifier(string text) {
            this._writer.AddIdentifierWithCasing(text);
        }

        protected void GenerateIdentifierWithoutCheck(string text) {
            this._writer.AddIdentifierWithoutCasing(text);
        }

        protected void GenerateIdentifierWithoutCasing(string text) {
            this._writer.AddIdentifierWithoutCasing(text);
        }

        protected void GenerateSpaceAndIdentifier(string idText) {
            this.GenerateSpace();
            this.GenerateIdentifier(idText);
        }

        protected void GenerateToken(TSqlTokenType tokenType, string text, bool applyCasing) {
            if (applyCasing) {
                text = ScriptGeneratorSupporter.GetCasedString(text, this._options.KeywordCasing);
            }
            TSqlParserToken token = new TSqlParserToken(tokenType, text);
            this._writer.AddToken(token);
        }

        protected void GenerateCommaSeparatedFlagOpitons<TKey>(Dictionary<TKey, TokenGenerator> optionsGenerators, TKey options) where TKey : struct, IConvertible {
            bool flag = true;
            ulong num = Convert.ToUInt64(options, CultureInfo.InvariantCulture);
            foreach (TKey key in optionsGenerators.Keys) {
                ulong num2 = Convert.ToUInt64(key, CultureInfo.InvariantCulture);
                if ((num2 & num) == num2) {
                    TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(optionsGenerators, key);
                    if (valueForEnumKey != null) {
                        if (flag) {
                            flag = false;
                        } else {
                            this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                        }
                        this.GenerateToken(valueForEnumKey);
                    }
                }
            }
        }

        protected void GenerateToken(TokenGenerator generator) {
            generator.Generate(this._writer);
        }

        protected void GenerateTokenList(List<TokenGenerator> generatorList) {
            foreach (TokenGenerator generator in generatorList) {
                generator.Generate(this._writer);
            }
        }

        protected void GenerateSpaceSeparatedTokens(TSqlTokenType keywordId, params string[] identifiers) {
            this.GenerateKeyword(keywordId);
            foreach (string idText in identifiers) {
                this.GenerateSpaceAndIdentifier(idText);
            }
        }

        protected void GenerateSpaceSeparatedTokens(params TSqlTokenType[] keywords) {
            bool flag = true;
            foreach (TSqlTokenType keywordId in keywords) {
                if (flag) {
                    flag = false;
                } else {
                    this.GenerateSpace();
                }
                this.GenerateKeyword(keywordId);
            }
        }

        protected void GenerateSpaceSeparatedTokens(params string[] identifiers) {
            bool flag = true;
            foreach (string text in identifiers) {
                if (flag) {
                    flag = false;
                } else {
                    this.GenerateSpace();
                }
                this.GenerateIdentifier(text);
            }
        }

        protected void GenerateFragmentWithAlignmentPointIfNotNull(TSqlFragment node, AlignmentPoint ap) {
            if (node != null && ap != null) {
                this.AddAlignmentPointForFragment(node, ap);
                this.GenerateFragmentIfNotNull(node);
                this.ClearAlignmentPointsForFragment(node);
            }
        }

        public override void ExplicitVisit(LiteralDatabaseOption node) {
            DatabaseOptionKindHelper.Instance.GenerateSourceForOption(this._writer, node.OptionKind);
            this.GenerateSpaceAndSymbol(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.Value);
        }

        public override void ExplicitVisit(ValuesInsertSource node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            if (node.IsDefaultValues) {
                this.GenerateKeyword(TSqlTokenType.Default);
                this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Values);
            } else {
                this.GenerateKeywordAndSpace(TSqlTokenType.Values);
                this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
                AlignmentPoint alignmentPointForFragment2 = this.GetAlignmentPointForFragment(node, "InsertColumns");
                this.MarkInsertColumnsAlignmentPointWhenNecessary(alignmentPointForFragment2);
                this.GenerateCommaSeparatedList(node.RowValues, true);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(RowValue node) {
            this.GenerateParenthesisedCommaSeparatedList(node.ColumnValues);
        }

        public override void ExplicitVisit(VariableTableReference node) {
            this.GenerateFragmentIfNotNull(node.Variable);
            this.GenerateSpaceAndAlias(node.Alias);
        }

        public override void ExplicitVisit(VariableMethodCallTableReference node) {
            this.GenerateFragmentIfNotNull(node.Variable);
            this.GenerateSymbol(TSqlTokenType.Dot);
            this.GenerateFragmentIfNotNull(node.MethodName);
            this.GenerateParenthesisedCommaSeparatedList(node.Parameters, true);
            this.GenerateTableAndColumnAliases(node);
        }

        public override void ExplicitVisit(ViewOption node) {
            string valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._viewOptionTypeNames, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateIdentifier(valueForEnumKey);
            }
        }

        protected void GenerateViewStatementBody(ViewStatementBody node) {
            this.GenerateKeyword(TSqlTokenType.View);
            this.GenerateSpaceAndFragmentIfNotNull(node.SchemaObjectName);
            if (node.Columns.Count > 0) {
                if (this._options.MultilineViewColumnsList) {
                    ListGenerationOption option = ListGenerationOption.CreateOptionFromFormattingConfig(this._options);
                    this.GenerateFragmentList(node.Columns, option);
                } else {
                    this.GenerateSpace();
                    this.GenerateParenthesisedCommaSeparatedList(node.Columns);
                }
            }
            if (node.ViewOptions.Count > 0) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.ViewOptions);
            }
            this.GenerateNewLineOrSpace(this._options.AsKeywordOnOwnLine);
            this.GenerateKeyword(TSqlTokenType.As);
            this.NewLine();
            if (this._options.IndentViewBody) {
                this.Indent();
            }
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            bool generateSemiColon = this._generateSemiColon;
            this._generateSemiColon = false;
            this.GenerateFragmentIfNotNull(node.SelectStatement);
            this._generateSemiColon = generateSemiColon;
            this.PopAlignmentPoint();
            if (node.WithCheckOption) {
                this.NewLine();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Check);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Option);
            }
        }

        public override void ExplicitVisit(WaitAtLowPriorityOption node) {
            this.GenerateLowPriorityWaitOptions(node.Options);
        }

        public override void ExplicitVisit(WaitForStatement node) {
            this.GenerateKeyword(TSqlTokenType.WaitFor);
            if (node.WaitForOption == WaitForOption.Statement) {
                this.GenerateSpace();
                bool generateSemiColon = this._generateSemiColon;
                this._generateSemiColon = false;
                this.GenerateParenthesisedFragmentIfNotNull(node.Statement);
                this._generateSemiColon = generateSemiColon;
                if (node.Timeout != null) {
                    this.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                    this.GenerateSpaceAndIdentifier("TIMEOUT");
                    this.GenerateSpaceAndFragmentIfNotNull(node.Timeout);
                }
            } else {
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._waitForOptionGenerators, node.WaitForOption);
                if (valueForEnumKey != null) {
                    this.GenerateSpace();
                    this.GenerateToken(valueForEnumKey);
                }
                this.GenerateSpaceAndFragmentIfNotNull(node.Parameter);
            }
        }

        public override void ExplicitVisit(SimpleWhenClause node) {
            this.GenerateKeyword(TSqlTokenType.When);
            this.GenerateSpaceAndFragmentIfNotNull(node.WhenExpression);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Then);
            this.GenerateSpaceAndFragmentIfNotNull(node.ThenExpression);
        }

        public override void ExplicitVisit(SearchedWhenClause node) {
            this.GenerateKeyword(TSqlTokenType.When);
            this.GenerateSpaceAndFragmentIfNotNull(node.WhenExpression);
            this.GenerateSpaceAndKeyword(TSqlTokenType.Then);
            this.GenerateSpaceAndFragmentIfNotNull(node.ThenExpression);
        }

        public override void ExplicitVisit(WhereClause node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateKeyword(TSqlTokenType.Where);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.MarkClauseBodyAlignmentWhenNecessary(this._options.NewLineBeforeWhereClause, alignmentPointForFragment);
            if (node.SearchCondition != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.SearchCondition);
            } else {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Current);
                this.GenerateSpaceAndKeyword(TSqlTokenType.Of);
                this.GenerateSpaceAndFragmentIfNotNull(node.Cursor);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(WhileStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateKeyword(TSqlTokenType.While);
            this.GenerateSpaceAndFragmentIfNotNull(node.Predicate);
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateFragmentIfNotNull(node.Statement);
            this.GenerateSemiColonWhenNecessary(node.Statement);
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(WindowFrameClause node) {
            switch (node.WindowFrameType) {
                case WindowFrameType.Rows:
                    this.GenerateIdentifier("ROWS");
                    break;
                case WindowFrameType.Range:
                    this.GenerateIdentifier("RANGE");
                    break;
            }
            if (node.Bottom != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Between);
                this.GenerateSpaceAndFragmentIfNotNull(node.Top);
                this.GenerateSpaceAndKeyword(TSqlTokenType.And);
                this.GenerateSpaceAndFragmentIfNotNull(node.Bottom);
            } else {
                this.GenerateSpaceAndFragmentIfNotNull(node.Top);
            }
        }

        public override void ExplicitVisit(WindowDelimiter node) {
            switch (node.WindowDelimiterType) {
                case WindowDelimiterType.CurrentRow:
                    this.GenerateKeyword(TSqlTokenType.Current);
                    this.GenerateSpaceAndIdentifier("ROW");
                    break;
                case WindowDelimiterType.UnboundedPreceding:
                    this.GenerateIdentifier("UNBOUNDED");
                    this.GenerateSpaceAndIdentifier("PRECEDING");
                    break;
                case WindowDelimiterType.UnboundedFollowing:
                    this.GenerateIdentifier("UNBOUNDED");
                    this.GenerateSpaceAndIdentifier("FOLLOWING");
                    break;
                case WindowDelimiterType.ValuePreceding:
                    this.GenerateFragmentIfNotNull(node.OffsetValue);
                    this.GenerateSpaceAndIdentifier("PRECEDING");
                    break;
                case WindowDelimiterType.ValueFollowing:
                    this.GenerateFragmentIfNotNull(node.OffsetValue);
                    this.GenerateSpaceAndIdentifier("FOLLOWING");
                    break;
            }
        }

        public override void ExplicitVisit(WindowsCreateLoginSource node) {
            this.GenerateKeyword(TSqlTokenType.From);
            this.GenerateSpaceAndIdentifier("WINDOWS");
            if (node.Options != null && node.Options.Count > 0) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateCommaSeparatedList(node.Options);
            }
        }

        public override void ExplicitVisit(WithCtesAndXmlNamespaces node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.MarkAndPushAlignmentPoint(ap);
            AlignmentPoint alignmentPointForFragment = this.GetAlignmentPointForFragment(node, "ClauseBody");
            this.GenerateKeyword(TSqlTokenType.With);
            if (node.ChangeTrackingContext != null) {
                this.GenerateSpaceAndIdentifier("CHANGE_TRACKING_CONTEXT");
                this.GenerateSpaceAndKeyword(TSqlTokenType.LeftParenthesis);
                this.GenerateFragmentIfNotNull(node.ChangeTrackingContext);
                this.GenerateKeyword(TSqlTokenType.RightParenthesis);
                if (node.CommonTableExpressions.Count > 0) {
                    this.GenerateKeyword(TSqlTokenType.Comma);
                }
            }
            if (node.XmlNamespaces != null) {
                this.MarkClauseBodyAlignmentWhenNecessary(true, alignmentPointForFragment);
                this.GenerateSpaceAndFragmentIfNotNull(node.XmlNamespaces);
            }
            if (node.CommonTableExpressions.Count > 0) {
                if (node.XmlNamespaces != null) {
                    this.GenerateSymbol(TSqlTokenType.Comma);
                    this.NewLine();
                }
                foreach (CommonTableExpression commonTableExpression in node.CommonTableExpressions) {
                    this.AddAlignmentPointForFragment(commonTableExpression, alignmentPointForFragment);
                }
                this.GenerateCommaSeparatedList(node.CommonTableExpressions, true);
                foreach (CommonTableExpression commonTableExpression2 in node.CommonTableExpressions) {
                    this.ClearAlignmentPointsForFragment(commonTableExpression2);
                }
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(WithinGroupClause node) {
            this.GenerateIdentifier("WITHIN");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndSymbol(TSqlTokenType.LeftParenthesis);
            AlignmentPoint ap = new AlignmentPoint("ClauseBody");
            this.GenerateFragmentWithAlignmentPointIfNotNull(node.OrderByClause, ap);
            this.GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(WitnessDatabaseOption node) {
            this.GenerateIdentifier("WITNESS");
            this.GenerateSpace();
            if (node.WitnessServer != null) {
                this.GenerateSymbol(TSqlTokenType.EqualsSign);
                this.GenerateSpaceAndFragmentIfNotNull(node.WitnessServer);
            } else if (node.IsOff) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.Off);
            }
        }

        protected void GenerateWorkloadGroupStatementBody(WorkloadGroupStatement node) {
            AlignmentPoint ap = new AlignmentPoint();
            this.GenerateIdentifier("WORKLOAD");
            this.GenerateSpaceAndKeyword(TSqlTokenType.Group);
            this.GenerateSpaceAndFragmentIfNotNull(node.Name);
            if (node.WorkloadGroupParameters != null && node.WorkloadGroupParameters.Count > 0) {
                this.NewLineAndIndent();
                this.MarkAndPushAlignmentPoint(ap);
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpace();
                this.GenerateAlignedParenthesizedOptionsWithMultipleIndent(node.WorkloadGroupParameters, 2);
                this.PopAlignmentPoint();
            }
            if (node.PoolName == null && node.ExternalPoolName == null) {
                return;
            }
            this.NewLineAndIndent();
            this.MarkAndPushAlignmentPoint(ap);
            this.GenerateIdentifier("USING");
            if (node.PoolName != null) {
                this.GenerateSpaceAndFragmentIfNotNull(node.PoolName);
                if (node.ExternalPoolName != null) {
                    this.GenerateKeyword(TSqlTokenType.Comma);
                }
            }
            if (node.ExternalPoolName != null) {
                this.GenerateSpaceAndKeyword(TSqlTokenType.External);
                this.GenerateSpaceAndFragmentIfNotNull(node.ExternalPoolName);
            }
            this.PopAlignmentPoint();
        }

        public override void ExplicitVisit(WorkloadGroupResourceParameter node) {
            WorkloadGroupResourceParameterHelper.Instance.GenerateSourceForOption(this._writer, node.ParameterType);
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpaceAndFragmentIfNotNull(node.ParameterValue);
        }

        public override void ExplicitVisit(WorkloadGroupImportanceParameter node) {
            this.GenerateIdentifier("IMPORTANCE");
            this.GenerateSpaceAndKeyword(TSqlTokenType.EqualsSign);
            this.GenerateSpace();
            ImportanceParameterHelper.Instance.GenerateSourceForOption(this._writer, node.ParameterValue);
        }

        public override void ExplicitVisit(WriteTextStatement node) {
            this.GenerateKeyword(TSqlTokenType.WriteText);
            this.GenerateSpace();
            this.GenerateBulkColumnTimestamp(node);
            if (node.WithLog) {
                this.NewLineAndIndent();
                this.GenerateKeyword(TSqlTokenType.With);
                this.GenerateSpaceAndIdentifier("LOG");
            }
            this.GenerateSpaceAndFragmentIfNotNull(node.SourceParameter);
        }

        public override void ExplicitVisit(WsdlPayloadOption node) {
            if (node.IsNone) {
                this.GenerateNameEqualsValue("WSDL", "NONE");
            } else {
                this.GenerateNameEqualsValue("WSDL", node.Value);
            }
        }

        public override void ExplicitVisit(XmlDataTypeReference node) {
            this.GenerateIdentifier("XML");
            if (node.XmlSchemaCollection != null) {
                this.GenerateSymbol(TSqlTokenType.LeftParenthesis);
                TokenGenerator valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._xmlDataTypeOptionGenerators, node.XmlDataTypeOption);
                if (valueForEnumKey != null) {
                    this.GenerateToken(valueForEnumKey);
                }
                this.GenerateSpaceAndFragmentIfNotNull(node.XmlSchemaCollection);
                this.GenerateSymbol(TSqlTokenType.RightParenthesis);
            }
        }

        public override void ExplicitVisit(XmlForClause node) {
            this.GenerateIdentifier("XML");
            this.GenerateSpace();
            this.GenerateCommaSeparatedList(node.Options);
        }

        public override void ExplicitVisit(XmlForClauseOption node) {
            List<TokenGenerator> valueForEnumKey = SqlScriptGeneratorVisitor.GetValueForEnumKey(SqlScriptGeneratorVisitor._xmlForClauseOptionsGenerators, node.OptionKind);
            if (valueForEnumKey != null) {
                this.GenerateTokenList(valueForEnumKey);
            }
            if (node.Value != null) {
                this.GenerateSpace();
                this.GenerateParenthesisedFragmentIfNotNull(node.Value);
            }
        }

        public override void ExplicitVisit(XmlNamespaces node) {
            this.GenerateIdentifier("XMLNAMESPACES");
            this.GenerateSpace();
            this.GenerateParenthesisedCommaSeparatedList(node.XmlNamespacesElements);
        }

        public override void ExplicitVisit(XmlNamespacesAliasElement node) {
            this.GenerateFragmentIfNotNull(node.String);
            this.GenerateSpaceAndKeyword(TSqlTokenType.As);
            this.GenerateSpaceAndFragmentIfNotNull(node.Identifier);
        }

        public override void ExplicitVisit(XmlNamespacesDefaultElement node) {
            this.GenerateKeyword(TSqlTokenType.Default);
            this.GenerateSpaceAndFragmentIfNotNull(node.String);
        }
    }
}
