namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Globalization;
    using antlr;

    internal abstract class TSql120ParserBaseInternal : TSql110ParserBaseInternal {
        protected TSql120ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql120ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql120ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql120ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        protected static void CheckLowPriorityLockWaitValue(IntegerLiteral maxDuration, AbortAfterWaitType abortAfterWait) {
            int num = default(int);
            if (!int.TryParse(maxDuration.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) || num > 71582 || num < 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46101", maxDuration, TSqlParserResource.SQL46101Message, maxDuration.Value);
            }
            if (num == 0 && abortAfterWait == AbortAfterWaitType.Self) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46102", maxDuration, TSqlParserResource.SQL46102Message, maxDuration.Value, "SELF");
            }
        }

        protected static void VerifyAllowedIndexOption120(IndexAffectingStatement statement, IndexOption option) {
            TSql80ParserBaseInternal.VerifyAllowedIndexOption(statement, option, SqlVersionFlags.TSql120);
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
    }
}
