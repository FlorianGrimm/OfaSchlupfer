namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using antlr;

    internal abstract class TSql100ParserBaseInternal : TSql90ParserBaseInternal {
        protected TSql100ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql100ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql100ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql100ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        protected AutoCleanupChangeTrackingOptionDetail CreateAutoCleanupDetail(IToken firstToken, IToken lastToken, ref bool autoCleanupEncountered) {
            TSql80ParserBaseInternal.Match(firstToken, "AUTO_CLEANUP");
            if (autoCleanupEncountered) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46050", firstToken, TSqlParserResource.SQL46050Message, firstToken.getText());
            }
            autoCleanupEncountered = true;
            AutoCleanupChangeTrackingOptionDetail autoCleanupChangeTrackingOptionDetail = base.FragmentFactory.CreateFragment<AutoCleanupChangeTrackingOptionDetail>();
            TSql80ParserBaseInternal.UpdateTokenInfo(autoCleanupChangeTrackingOptionDetail, firstToken);
            TSql80ParserBaseInternal.UpdateTokenInfo(autoCleanupChangeTrackingOptionDetail, lastToken);
            autoCleanupChangeTrackingOptionDetail.IsOn = (lastToken.Type == 105);
            return autoCleanupChangeTrackingOptionDetail;
        }

        protected static SqlDataTypeOption ParseDataType100(string token) {
            switch (token.ToUpperInvariant()) {
                case "DATE":
                    return SqlDataTypeOption.Date;
                case "TIME":
                    return SqlDataTypeOption.Time;
                case "DATETIME2":
                    return SqlDataTypeOption.DateTime2;
                case "DATETIMEOFFSET":
                    return SqlDataTypeOption.DateTimeOffset;
                default:
                    return TSql80ParserBaseInternal.ParseDataType(token);
            }
        }

        protected static void CheckBrokerPriorityParameterDuplication(int current, BrokerPriorityParameterType newOption, IToken token) {
            if ((current & 1 << (int)newOption) != 0) {
                TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token);
            }
        }

        protected static void UpdateBrokerPriorityEncounteredOptions(ref int encountered, BrokerPriorityParameter vBrokerPriorityParameter) {
            encountered |= 1 << (int)vBrokerPriorityParameter.ParameterType;
        }

        protected static void CheckBoundingBoxParameterDuplication(int current, BoundingBoxParameterType newOption, IToken token) {
            if ((current & 1 << (int)newOption) != 0) {
                TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token);
            }
        }

        protected static void UpdateBoundingBoxParameterEncounteredOptions(ref int encountered, BoundingBoxParameter vBoundingBoxParameter) {
            encountered |= 1 << (int)vBoundingBoxParameter.Parameter;
        }

        protected static void CheckIfValidSpatialIndexOptionValue(IndexAffectingStatement statement, IndexOption option) {
            IndexStateOption indexStateOption = option as IndexStateOption;
            if (indexStateOption != null && indexStateOption.OptionKind == IndexOptionKind.IgnoreDupKey && indexStateOption.OptionState == OptionState.On) {
                TSql80ParserBaseInternal.ThrowWrongIndexOptionError(statement, indexStateOption);
            }
        }

        protected static void SetFileStreamStorageOption(ColumnStorageOptions storageOptions, IToken fileStreamToken, DataTypeReference columnType, IndexAffectingStatement statementType) {
            if (statementType == IndexAffectingStatement.AlterTableAddElement || statementType == IndexAffectingStatement.CreateTable) {
                SqlDataTypeReference sqlDataTypeReference = columnType as SqlDataTypeReference;
                if (sqlDataTypeReference != null && sqlDataTypeReference.SqlDataTypeOption == SqlDataTypeOption.VarBinary && sqlDataTypeReference.Parameters.Count == 1 && sqlDataTypeReference.Parameters[0].LiteralType == LiteralType.Max) {
                    storageOptions.IsFileStream = true;
                } else {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46051", fileStreamToken, TSqlParserResource.SQL46051Message);
                }
            } else {
                TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(fileStreamToken);
            }
        }

        protected static void SetSparseStorageOption(ColumnStorageOptions columnStorage, SparseColumnOption option, IToken token, IndexAffectingStatement statementType) {
            switch (statementType) {
                case IndexAffectingStatement.AlterTableAddElement:
                case IndexAffectingStatement.CreateTable:
                case IndexAffectingStatement.CreateOrAlterFunction:
                case IndexAffectingStatement.DeclareTableVariable:
                    if (statementType == IndexAffectingStatement.CreateOrAlterFunction && option == SparseColumnOption.ColumnSetForAllSparseColumns) {
                        TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token);
                    }
                    columnStorage.SparseOption = option;
                    break;
                default:
                    TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token);
                    break;
            }
        }

        protected static void CheckComparisonOperandForIndexFilter(ScalarExpression rightOperand, bool convertAllowed) {
            UnaryExpression unaryExpression = rightOperand as UnaryExpression;
            if (unaryExpression != null) {
                TSql100ParserBaseInternal.CheckComparisonOperandForIndexFilter(unaryExpression.Expression, convertAllowed);
            } else {
                Literal literal = rightOperand as Literal;
                if (literal != null && literal.LiteralType != LiteralType.Max) {
                    return;
                }
                ParenthesisExpression parenthesisExpression = rightOperand as ParenthesisExpression;
                if (parenthesisExpression != null) {
                    TSql100ParserBaseInternal.CheckComparisonOperandForIndexFilter(parenthesisExpression.Expression, convertAllowed);
                } else {
                    if (convertAllowed) {
                        ConvertCall convertCall = rightOperand as ConvertCall;
                        if (convertCall != null) {
                            TSql100ParserBaseInternal.CheckComparisonOperandForIndexFilter(convertCall.Parameter, false);
                            return;
                        }
                        CastCall castCall = rightOperand as CastCall;
                        if (castCall != null) {
                            TSql100ParserBaseInternal.CheckComparisonOperandForIndexFilter(castCall.Parameter, false);
                            return;
                        }
                    }
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46059", rightOperand, TSqlParserResource.SQL46059Message);
                }
            }
        }

        protected static void CheckPartitionAllSpecifiedForIndexRebuild(PartitionSpecifier partitionSpecifier, IList<IndexOption> indexOptions) {
            if (partitionSpecifier == null) {
                foreach (IndexOption indexOption in indexOptions) {
                    DataCompressionOption dataCompressionOption = indexOption as DataCompressionOption;
                    if (dataCompressionOption != null && dataCompressionOption.PartitionRanges.Count > 0) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46061", indexOption, TSqlParserResource.SQL46061Message);
                    }
                }
            }
        }

        protected static void ThrowIfWrongGuidFormat(Literal literal) {
            string pattern = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}";
            if (!Regex.IsMatch(literal.Value, pattern, RegexOptions.CultureInvariant)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46055", literal, TSqlParserResource.SQL46055Message);
            }
        }

        protected static void ThrowIfTooLargeAuditFileSize(Literal size, int shift) {
            ulong num = default(ulong);
            if (ulong.TryParse(size.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num <= 18446744073709551615uL >> 20 + shift) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46054", size, TSqlParserResource.SQL46054Message);
        }

        protected static void CheckForCellsPerObjectValueRange(Literal value) {
            int num = default(int);
            if (int.TryParse(value.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num >= 1 && num <= 8192) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46073", value, TSqlParserResource.SQL46073Message, value.Value);
        }
    }
}
