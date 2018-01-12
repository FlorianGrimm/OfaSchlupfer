using antlr;
using System;
using System.Globalization;

namespace OfaSchlupfer.ScriptDom {
    internal abstract class TSql130ParserBaseInternal : TSql120ParserBaseInternal {
        protected TSql130ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql130ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql130ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql130ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        protected static void VerifyAllowedIndexOption130(IndexAffectingStatement statement, IndexOption option) {
            TSql80ParserBaseInternal.VerifyAllowedIndexOption(statement, option, SqlVersionFlags.TSql130);
            if (option is OnlineIndexOption) {
                OnlineIndexOption onlineIndexOption = option as OnlineIndexOption;
                if (onlineIndexOption.LowPriorityLockWaitOption != null) {
                    switch (statement) {
                        case IndexAffectingStatement.AlterTableRebuildOnePartition:
                        case IndexAffectingStatement.AlterTableRebuildAllPartitions:
                        case IndexAffectingStatement.AlterIndexRebuildOnePartition:
                        case IndexAffectingStatement.AlterIndexRebuildAllPartitions:
                            break;
                        default:
                            TSql80ParserBaseInternal.ThrowWrongIndexOptionError(statement, onlineIndexOption.LowPriorityLockWaitOption);
                            break;
                    }
                }
            }
        }

        protected static void CheckTemporalPeriodInTableDefinition(TableDefinition definition, bool isInAlterStatement) {
            bool flag = !isInAlterStatement || (definition.ColumnDefinitions != null && definition.ColumnDefinitions.Count > 0);
            if (definition.SystemTimePeriod != null && flag) {
                bool flag2 = false;
                bool flag3 = false;
                foreach (ColumnDefinition columnDefinition in definition.ColumnDefinitions) {
                    if (definition.SystemTimePeriod.StartTimeColumn.Value == columnDefinition.ColumnIdentifier.Value) {
                        GeneratedAlwaysType? generatedAlways = columnDefinition.GeneratedAlways;
                        if (generatedAlways.GetValueOrDefault() != 0 || !generatedAlways.HasValue) {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46103", definition, TSqlParserResource.SQL46103Message);
                        } else {
                            flag2 = true;
                        }
                    } else if (definition.SystemTimePeriod.EndTimeColumn.Value == columnDefinition.ColumnIdentifier.Value) {
                        if (columnDefinition.GeneratedAlways != GeneratedAlwaysType.RowEnd) {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46104", definition, TSqlParserResource.SQL46104Message);
                        } else {
                            flag3 = true;
                        }
                    } else if (columnDefinition.GeneratedAlways.HasValue) {
                        GeneratedAlwaysType? generatedAlways2 = columnDefinition.GeneratedAlways;
                        if (generatedAlways2.GetValueOrDefault() == GeneratedAlwaysType.RowStart && generatedAlways2.HasValue) {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46103", definition, TSqlParserResource.SQL46103Message);
                        } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.RowEnd) {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46104", definition, TSqlParserResource.SQL46104Message);
                        }
                    }
                }
                if (!isInAlterStatement || flag2 || flag3) {
                    if (!flag2) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46105", definition, TSqlParserResource.SQL46105Message);
                    }
                    if (!flag3) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46106", definition, TSqlParserResource.SQL46106Message);
                    }
                }
            }
            TSql130ParserBaseInternal.CheckTemporalGeneratedAlwaysColumns(definition, isInAlterStatement);
        }

        protected static void CheckTemporalGeneratedAlwaysColumns(TableDefinition definition, bool isInAlterStatement) {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            int num = 0;
            foreach (ColumnDefinition columnDefinition in definition.ColumnDefinitions) {
                GeneratedAlwaysType? generatedAlways = columnDefinition.GeneratedAlways;
                if (generatedAlways.GetValueOrDefault() == GeneratedAlwaysType.RowStart && generatedAlways.HasValue) {
                    num++;
                    if (flag5) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46109", definition, TSqlParserResource.SQL46109Message);
                    } else {
                        flag5 = true;
                    }
                } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.RowEnd) {
                    num++;
                    if (flag6) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46109", definition, TSqlParserResource.SQL46109Message);
                    } else {
                        flag6 = true;
                    }
                } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.UserIdStart) {
                    num++;
                    if (flag) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46109", definition, TSqlParserResource.SQL46109Message);
                    } else {
                        flag = true;
                    }
                } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.UserIdEnd) {
                    num++;
                    if (flag2) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46110", definition, TSqlParserResource.SQL46110Message);
                    } else {
                        flag2 = true;
                    }
                } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.UserNameStart) {
                    num++;
                    if (flag3) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46111", definition, TSqlParserResource.SQL46111Message);
                    } else {
                        flag3 = true;
                    }
                } else if (columnDefinition.GeneratedAlways == GeneratedAlwaysType.UserNameEnd) {
                    num++;
                    if (flag4) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46112", definition, TSqlParserResource.SQL46112Message);
                    } else {
                        flag4 = true;
                    }
                }
            }
            if (num > 0 && !isInAlterStatement && definition.SystemTimePeriod == null) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46113", definition, TSqlParserResource.SQL46113Message);
            }
        }

        protected static void CheckRetentionPeriodDuration(ScalarExpression duration) {
            int num = (!(duration is UnaryExpression)) ? int.Parse((duration as IntegerLiteral).Value, CultureInfo.InvariantCulture) : (-int.Parse(((duration as UnaryExpression).Expression as IntegerLiteral).Value, CultureInfo.InvariantCulture));
            if (num <= 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46116", duration, TSqlParserResource.SQL46116Message, num.ToString(CultureInfo.CurrentCulture));
            }
        }

        protected static void CheckHekatonTableForInlineFilteredIndexes(CreateTableStatement statement) {
            if (TSql130ParserBaseInternal.IsMemoryOptimized(statement)) {
                foreach (ColumnDefinition columnDefinition in statement.Definition.ColumnDefinitions) {
                    if (columnDefinition.Index != null && columnDefinition.Index.FilterPredicate != null) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46107", statement.Definition, TSqlParserResource.SQL46107Message);
                    }
                }
                foreach (IndexDefinition index in statement.Definition.Indexes) {
                    if (index.FilterPredicate != null) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46107", statement.Definition, TSqlParserResource.SQL46107Message);
                    }
                }
            }
        }

        protected static void CheckHekatonTableForNonClusteredColumnStoreIndexes(CreateTableStatement statement) {
            if (TSql130ParserBaseInternal.IsMemoryOptimized(statement)) {
                foreach (ColumnDefinition columnDefinition in statement.Definition.ColumnDefinitions) {
                    if (columnDefinition.Index != null && columnDefinition.Index.IndexType.IndexTypeKind == IndexTypeKind.NonClusteredColumnStore) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46108", statement.Definition, TSqlParserResource.SQL46108Message);
                    }
                }
                foreach (IndexDefinition index in statement.Definition.Indexes) {
                    if (index.IndexType.IndexTypeKind == IndexTypeKind.NonClusteredColumnStore) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46108", statement.Definition, TSqlParserResource.SQL46108Message);
                    }
                }
            }
        }

        private static bool IsMemoryOptimized(CreateTableStatement statement) {
            foreach (TableOption option in statement.Options) {
                if (option.OptionKind == TableOptionKind.MemoryOptimized) {
                    return true;
                }
            }
            return false;
        }

        protected static void ThrowIfCompressionDelayValueOutOfRange(Literal value) {
            int num = default(int);
            if (int.TryParse(value.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num <= 10080 && num >= 0) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46114", value, TSqlParserResource.SQL46114Message, value.Value);
        }

        protected new static FunctionOptionKind ParseAlterCreateFunctionWithOption(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "ENCRYPTION":
                    return FunctionOptionKind.Encryption;
                case "SCHEMABINDING":
                    return FunctionOptionKind.SchemaBinding;
                case "NATIVE_COMPILATION":
                    return FunctionOptionKind.NativeCompilation;
                default:
                    throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46026", token, TSqlParserResource.SQL46026Message, token.getText()));
            }
        }

        protected bool NextIdentifierMatchesOneOf(params string[] keywords) {
            if (this.LA(1) == 232) {
                string text = this.LT(1).getText();
                foreach (string a in keywords) {
                    if (string.Equals(a, text, StringComparison.OrdinalIgnoreCase)) {
                        return true;
                    }
                }
            } else if (this.LA(1) == 233) {
                QuoteType quoteType = default(QuoteType);
                string b = Identifier.DecodeIdentifier(this.LT(1).getText(), out quoteType);
                foreach (string a2 in keywords) {
                    if (string.Equals(a2, b, StringComparison.OrdinalIgnoreCase)) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
