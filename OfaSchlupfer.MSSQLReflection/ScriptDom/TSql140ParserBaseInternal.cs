using antlr;
using System;

namespace OfaSchlupfer.ScriptDom {
    internal abstract class TSql140ParserBaseInternal : TSql130ParserBaseInternal {
        protected TSql140ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql140ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql140ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql140ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        protected static bool TryMatch(Literal literal, string keyword) {
            return string.Equals(literal.Value, keyword, StringComparison.OrdinalIgnoreCase);
        }

        protected static void VerifyAllowedIndexOption140(IndexAffectingStatement statement, IndexOption option) {
            TSql80ParserBaseInternal.VerifyAllowedIndexOption(statement, option, SqlVersionFlags.TSql140);
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

        protected static void CheckForDataFileFormatProhibitedOptionsBulkInsert(int encounteredOptions, BulkInsertStatement statement) {
            if ((encounteredOptions & 0x8000010) == 134217744) {
                bool flag = false;
                bool flag2 = false;
                foreach (BulkInsertOption option in statement.Options) {
                    if (option.OptionKind == BulkInsertOptionKind.DataFileFormat) {
                        LiteralBulkInsertOption literalBulkInsertOption = option as LiteralBulkInsertOption;
                        flag = TSql140ParserBaseInternal.TryMatch(literalBulkInsertOption.Value, "CSV");
                    } else if (option.OptionKind == BulkInsertOptionKind.DataFileType) {
                        LiteralBulkInsertOption literalBulkInsertOption2 = option as LiteralBulkInsertOption;
                        flag2 = (!TSql140ParserBaseInternal.TryMatch(literalBulkInsertOption2.Value, "CHAR") && !TSql140ParserBaseInternal.TryMatch(literalBulkInsertOption2.Value, "WIDECHAR"));
                    }
                }
                if (flag && flag2) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46118", statement, TSqlParserResource.SQL46118Message);
                }
            }
        }

        protected static void CheckForDataFileFormatProhibitedOptionsInOpenRowsetBulk(int encounteredOptions, TSqlFragment relatedFragment) {
            if ((encounteredOptions & 0x8000000) != 0 && (encounteredOptions & 0x380000) != 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46119", relatedFragment, TSqlParserResource.SQL46119Message);
            }
        }

        protected Identifier CreateIdentifierFromToken(IToken token) {
            Identifier identifier = new Identifier();
            identifier.Value = token.getText();
            identifier.QuoteType = QuoteType.NotQuoted;
            return identifier;
        }

        protected IdentifierOrScalarExpression CreateIdentifierOrScalarExpressionFromIdentifier(Identifier identifier) {
            IdentifierOrScalarExpression identifierOrScalarExpression = base.FragmentFactory.CreateFragment<IdentifierOrScalarExpression>();
            identifierOrScalarExpression.Identifier = identifier;
            return identifierOrScalarExpression;
        }
    }
}
