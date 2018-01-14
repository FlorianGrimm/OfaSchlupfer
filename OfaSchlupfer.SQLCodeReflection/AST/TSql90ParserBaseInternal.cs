namespace OfaSchlupfer.AST {
    using System;
    using System.Globalization;
    using antlr;

    internal abstract class TSql90ParserBaseInternal : TSql80ParserBaseInternal {
        protected const int BulkInsertOptionsProhibitedInOpenRowset = 34866;

        private const int CheckForFormatFileOptionInOpenRowsetBulkMask = 3670272;

        protected TSql90ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql90ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql90ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql90ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        protected static AuthenticationTypes AggregateAuthenticationType(AuthenticationTypes current, AuthenticationTypes newOption, IToken token) {
            AuthenticationTypes authenticationTypes = current | newOption;
            if (authenticationTypes == current) {
                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
            return authenticationTypes;
        }

        protected static void CheckForFormatFileOptionInOpenRowsetBulk(int encounteredOptions, TSqlFragment relatedFragment) {
            if ((encounteredOptions & 0x380100) == 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46082", relatedFragment, TSqlParserResource.SQL46082Message);
            }
        }

        protected static PortTypes AggregatePortType(PortTypes current, PortTypes newOption, IToken token) {
            PortTypes portTypes = current | newOption;
            if (portTypes == current) {
                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
            return portTypes;
        }

        protected static void CheckCertificateOptionDupication(CertificateOptionKinds current, CertificateOptionKinds newOption, IToken token) {
            if ((current & newOption) != newOption) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static void CheckIfEndpointOptionAllowed(EndpointProtocolOptions current, EndpointProtocolOptions newOption, EndpointProtocol protocol, IToken token) {
            if ((current & newOption) == newOption) {
                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
            if (protocol != EndpointProtocol.Tcp || (newOption & EndpointProtocolOptions.TcpOptions) == newOption) {
                if (protocol != EndpointProtocol.Http) {
                    return;
                }
                if ((newOption & EndpointProtocolOptions.HttpOptions) == newOption) {
                    return;
                }
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static void CheckIfPayloadOptionAllowed(PayloadOptionKinds current, PayloadOptionKinds newOption, EndpointType endpointType, IToken token) {
            switch (endpointType) {
                case EndpointType.TSql:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                case EndpointType.Soap:
                    if ((newOption & PayloadOptionKinds.SoapOptions) == newOption) {
                        goto default;
                    }
                    goto IL_0035;
                default: {
                        if (endpointType != EndpointType.DatabaseMirroring || (newOption & PayloadOptionKinds.DatabaseMirroringOptions) == newOption) {
                            if (endpointType != EndpointType.ServiceBroker) {
                                break;
                            }
                            if ((newOption & PayloadOptionKinds.ServiceBrokerOptions) == newOption) {
                                break;
                            }
                        }
                        goto IL_0035;
                    }
                    IL_0035:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
            if ((current & newOption) != newOption) {
                return;
            }
            if (newOption == PayloadOptionKinds.WebMethod) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static SecurityObjectKind ParseSecurityObjectKind(Identifier identifier) {
            switch (identifier.Value.ToUpperInvariant()) {
                case "ASSEMBLY":
                    return SecurityObjectKind.Assembly;
                case "CERTIFICATE":
                    return SecurityObjectKind.Certificate;
                case "CONTRACT":
                    return SecurityObjectKind.Contract;
                case "DATABASE":
                    return SecurityObjectKind.Database;
                case "ENDPOINT":
                    return SecurityObjectKind.Endpoint;
                case "LOGIN":
                    return SecurityObjectKind.Login;
                case "OBJECT":
                    return SecurityObjectKind.Object;
                case "ROLE":
                    return SecurityObjectKind.Role;
                case "ROUTE":
                    return SecurityObjectKind.Route;
                case "SCHEMA":
                    return SecurityObjectKind.Schema;
                case "SERVER":
                    return SecurityObjectKind.Server;
                case "SERVICE":
                    return SecurityObjectKind.Service;
                case "TYPE":
                    return SecurityObjectKind.Type;
                case "USER":
                    return SecurityObjectKind.User;
                default:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(identifier);
            }
        }

        protected static SecurityObjectKind ParseSecurityObjectKind(Identifier identifier1, Identifier identifier2) {
            switch (identifier1.Value.ToUpperInvariant()) {
                case "APPLICATION":
                    TSql80ParserBaseInternal.Match(identifier2, "ROLE");
                    return SecurityObjectKind.ApplicationRole;
                case "ASYMMETRIC":
                    TSql80ParserBaseInternal.Match(identifier2, "KEY");
                    return SecurityObjectKind.AsymmetricKey;
                case "AVAILABILITY":
                    TSql80ParserBaseInternal.Match(identifier2, "GROUP");
                    return SecurityObjectKind.AvailabilityGroup;
                case "FULLTEXT":
                    if (TSql80ParserBaseInternal.TryMatch(identifier2, "CATALOG")) {
                        return SecurityObjectKind.FullTextCatalog;
                    }
                    TSql80ParserBaseInternal.Match(identifier2, "STOPLIST");
                    return SecurityObjectKind.FullTextStopList;
                case "MESSAGE":
                    TSql80ParserBaseInternal.Match(identifier2, "TYPE");
                    return SecurityObjectKind.MessageType;
                case "SERVER":
                    TSql80ParserBaseInternal.Match(identifier2, "ROLE");
                    return SecurityObjectKind.ServerRole;
                case "SYMMETRIC":
                    TSql80ParserBaseInternal.Match(identifier2, "KEY");
                    return SecurityObjectKind.SymmetricKey;
                default:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(identifier1);
            }
        }

        protected static SecurityObjectKind ParseSecurityObjectKind(Identifier identifier1, Identifier identifier2, Identifier identifier3) {
            switch (identifier1.Value.ToUpperInvariant()) {
                case "XML":
                    TSql80ParserBaseInternal.Match(identifier2, "SCHEMA");
                    TSql80ParserBaseInternal.Match(identifier3, "COLLECTION");
                    return SecurityObjectKind.XmlSchemaCollection;
                case "REMOTE":
                    TSql80ParserBaseInternal.Match(identifier2, "SERVICE");
                    TSql80ParserBaseInternal.Match(identifier3, "BINDING");
                    return SecurityObjectKind.RemoteServiceBinding;
                case "SEARCH":
                    TSql80ParserBaseInternal.Match(identifier2, "PROPERTY");
                    TSql80ParserBaseInternal.Match(identifier3, "LIST");
                    return SecurityObjectKind.SearchPropertyList;
                default:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(identifier1);
            }
        }

        protected static bool IsXml(Identifier identifier) {
            return string.Equals(identifier.Value, "XML", StringComparison.OrdinalIgnoreCase);
        }

        protected static bool IsSys(Identifier identifier) {
            return string.Equals(identifier.Value, "SYS", StringComparison.OrdinalIgnoreCase);
        }

        protected bool IsStatementIsNext() {
            if (this.LA(1) == 56) {
                return base.NextTokenMatches("CONVERSATION", 2);
            }
            return true;
        }

        public static string Unquote(string value) {
            if (string.IsNullOrEmpty(value)) {
                return value;
            }
            int num = value.IndexOf('\'');
            int num2 = value.LastIndexOf('\'');
            string result = value;
            if (num != -1 && num2 != num) {
                if (num < 2 && num2 != num && num2 == value.Length - 1) {
                    if (num == 1) {
                        if (value[0] == 'N') {
                            result = value.Substring(num + 1, num2 - num - 1);
                        }
                    } else {
                        result = value.Substring(num + 1, num2 - num);
                    }
                }
                return result;
            }
            return result;
        }

        protected static EncryptionAlgorithmPreference RecognizeAesOrRc4(Identifier id, IToken tokenForError) {
            string a = TSql90ParserBaseInternal.Unquote(id.Value);
            if (string.Equals(a, "AES", StringComparison.OrdinalIgnoreCase)) {
                return EncryptionAlgorithmPreference.Aes;
            }
            if (string.Equals(a, "RC4", StringComparison.OrdinalIgnoreCase)) {
                return EncryptionAlgorithmPreference.Rc4;
            }
            throw new TSqlParseErrorException(TSql80ParserBaseInternal.GetUnexpectedTokenError(tokenForError));
        }

        protected static AuthenticationProtocol RecognizeAuthenticationProtocol(Identifier id, IToken tokenForError) {
            string a = TSql90ParserBaseInternal.Unquote(id.Value);
            if (string.Equals(a, "NTLM", StringComparison.OrdinalIgnoreCase)) {
                return AuthenticationProtocol.WindowsNtlm;
            }
            if (string.Equals(a, "KERBEROS", StringComparison.OrdinalIgnoreCase)) {
                return AuthenticationProtocol.WindowsKerberos;
            }
            if (string.Equals(a, "NEGOTIATE", StringComparison.OrdinalIgnoreCase)) {
                return AuthenticationProtocol.WindowsNegotiate;
            }
            throw new TSqlParseErrorException(TSql80ParserBaseInternal.GetUnexpectedTokenError(tokenForError));
        }

        protected static void RecognizeAlterLoginSecAdminPasswordOption(IToken token, PasswordAlterPrincipalOption astNode) {
            if (TSql80ParserBaseInternal.TryMatch(token, "MUST_CHANGE")) {
                if (astNode.MustChange) {
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                }
                astNode.MustChange = true;
            } else if (TSql80ParserBaseInternal.TryMatch(token, "HASHED")) {
                if (astNode.Hashed) {
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                }
                astNode.Hashed = true;
            } else {
                TSql80ParserBaseInternal.Match(token, "UNLOCK");
                if (astNode.Unlock) {
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                }
                astNode.Unlock = true;
            }
            TSql80ParserBaseInternal.UpdateTokenInfo(astNode, token);
        }

        protected static TValue EnableDisableMatcher<TValue>(IToken token, TValue enableValue, TValue disableValue) {
            if (TSql80ParserBaseInternal.TryMatch(token, "ENABLE")) {
                return enableValue;
            }
            TSql80ParserBaseInternal.Match(token, "DISABLE");
            return disableValue;
        }

        protected static void AddConstraintToComputedColumn(ConstraintDefinition constraint, ColumnDefinition column) {
            bool flag = false;
            if (constraint is NullableConstraintDefinition) {
                NullableConstraintDefinition nullableConstraintDefinition = (NullableConstraintDefinition)constraint;
                flag = nullableConstraintDefinition.Nullable;
            }
            if (!column.IsPersisted && !(constraint is UniqueConstraintDefinition)) {
                goto IL_0033;
            }
            if (column.IsPersisted && flag) {
                goto IL_0033;
            }
            goto IL_0049;
            IL_0049:
            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(column, column.Constraints, constraint);
            return;
            IL_0033:
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46011", constraint, TSqlParserResource.SQL46011Message);
            goto IL_0049;
        }

        protected static IndexAffectingStatement GetAlterIndexStatementKind(AlterIndexStatement alterIndex) {
            if (alterIndex.AlterIndexType == AlterIndexType.Reorganize) {
                return IndexAffectingStatement.AlterIndexReorganize;
            }
            if (alterIndex.AlterIndexType == AlterIndexType.Resume) {
                return IndexAffectingStatement.AlterIndexResume;
            }
            if (alterIndex.Partition != null && !alterIndex.Partition.All) {
                return IndexAffectingStatement.AlterIndexRebuildOnePartition;
            }
            return IndexAffectingStatement.AlterIndexRebuildAllPartitions;
        }

        protected static void CheckForDistinctInWindowedAggregate(FunctionCall functionCall, IToken distinctToken) {
            if (functionCall.UniqueRowFilter == UniqueRowFilter.Distinct && functionCall.OverClause != null && distinctToken != null) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46086", distinctToken, TSqlParserResource.SQL46086Message);
            }
        }

        protected Literal CreateIntLiteralFromNumericToken(IToken token, int textOffset, int textLength) {
            IntegerLiteral integerLiteral = base.FragmentFactory.CreateFragment<IntegerLiteral>();
            TSql80ParserBaseInternal.UpdateTokenInfo(integerLiteral, token);
            integerLiteral.Value = token.getText().Substring(textOffset, textLength);
            return integerLiteral;
        }

        protected bool SplitNumericIntoIpParts(IToken token, out Literal frag1, out Literal frag2) {
            string text = token.getText();
            int length = text.Length;
            int num = text.IndexOf('.');
            if (num == 0) {
                frag1 = null;
                frag2 = this.CreateIntLiteralFromNumericToken(token, 1, length - 1);
                return false;
            }
            if (num == length - 1) {
                frag1 = this.CreateIntLiteralFromNumericToken(token, 0, num);
                frag2 = null;
                return false;
            }
            frag1 = this.CreateIntLiteralFromNumericToken(token, 0, num);
            frag2 = this.CreateIntLiteralFromNumericToken(token, num + 1, length - num - 1);
            return true;
        }

        protected Literal GetIPv4FragmentFromDotNumberNumeric(IToken token) {
            Literal literal = default(Literal);
            Literal literal2 = default(Literal);
            this.SplitNumericIntoIpParts(token, out literal, out literal2);
            if (literal == null && literal2 != null) {
                return literal2;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected Literal GetIPv4FragmentFromNumberDotNumeric(IToken token) {
            Literal literal = default(Literal);
            Literal literal2 = default(Literal);
            this.SplitNumericIntoIpParts(token, out literal, out literal2);
            if (literal != null && literal2 == null) {
                return literal;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected void GetIPv4FragmentsFromNumberDotNumberNumeric(IToken token, out Literal frag1, out Literal frag2) {
            if (this.SplitNumericIntoIpParts(token, out frag1, out frag2)) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static void CheckDmlTriggerActionDuplication(int current, TriggerAction vTriggerAction) {
            if ((current & 1 << (int)vTriggerAction.TriggerActionType) != 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46090", vTriggerAction, TSqlParserResource.SQL46090Message, vTriggerAction.TriggerActionType.ToString());
            }
        }

        protected static void UpdateDmlTriggerActionEncounteredOptions(ref int encountered, TriggerAction vTriggerAction) {
            encountered |= 1 << (int)vTriggerAction.TriggerActionType;
        }

        protected static void ThrowIfInvalidListenerPortValue(Literal value) {
            int num = default(int);
            if (int.TryParse(value.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num <= 32767 && num >= 1024) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46087", value, TSqlParserResource.SQL46087Message, value.Value);
        }

        protected static void ThrowIfMaxdopValueOutOfRange(Literal value) {
            int num = default(int);
            if (int.TryParse(value.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num <= 32767 && num >= 0) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46091", value, TSqlParserResource.SQL46091Message, value.Value);
        }

        protected EventTypeContainer CreateEventTypeContainer(EventNotificationEventType eventTypeValue, IToken token) {
            EventTypeContainer eventTypeContainer = base.FragmentFactory.CreateFragment<EventTypeContainer>();
            eventTypeContainer.EventType = eventTypeValue;
            TSql80ParserBaseInternal.UpdateTokenInfo(eventTypeContainer, token);
            return eventTypeContainer;
        }

        protected EventGroupContainer CreateEventGroupContainer(EventNotificationEventGroup eventGroupValue, IToken token) {
            EventGroupContainer eventGroupContainer = base.FragmentFactory.CreateFragment<EventGroupContainer>();
            eventGroupContainer.EventGroup = eventGroupValue;
            TSql80ParserBaseInternal.UpdateTokenInfo(eventGroupContainer, token);
            return eventGroupContainer;
        }
    }
}
