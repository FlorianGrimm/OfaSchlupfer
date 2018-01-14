using antlr;

namespace OfaSchlupfer.AST {
    internal abstract class TSql110ParserBaseInternal : TSql100ParserBaseInternal {
        private static string[] _optionsValidForCreateDatabase = new string[7]
        {
            "CONTAINMENT",
            "DEFAULT_LANGUAGE",
            "DEFAULT_FULLTEXT_LANGUAGE",
            "FILESTREAM",
            "NESTED_TRIGGERS",
            "TRANSFORM_NOISE_WORDS",
            "TWO_DIGIT_YEAR_CUTOFF"
        };

        protected TSql110ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql110ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql110ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql110ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
        }

        private static bool isFollowingDelimiter(WindowDelimiter delimiter) {
            if (delimiter != null) {
                if (delimiter.WindowDelimiterType != WindowDelimiterType.ValueFollowing) {
                    return delimiter.WindowDelimiterType == WindowDelimiterType.UnboundedFollowing;
                }
                return true;
            }
            return false;
        }

        private static bool isPrecedingDelimiter(WindowDelimiter delimiter) {
            if (delimiter != null) {
                if (delimiter.WindowDelimiterType != WindowDelimiterType.ValuePreceding) {
                    return delimiter.WindowDelimiterType == WindowDelimiterType.UnboundedPreceding;
                }
                return true;
            }
            return false;
        }

        protected static void CheckWindowFrame(WindowFrameClause windowFrameClause) {
            bool flag = windowFrameClause.Top != null && (windowFrameClause.Top.WindowDelimiterType == WindowDelimiterType.ValuePreceding || windowFrameClause.Top.WindowDelimiterType == WindowDelimiterType.ValueFollowing);
            bool flag2 = windowFrameClause.Bottom != null && (windowFrameClause.Bottom.WindowDelimiterType == WindowDelimiterType.ValuePreceding || windowFrameClause.Bottom.WindowDelimiterType == WindowDelimiterType.ValueFollowing);
            if (windowFrameClause.WindowFrameType == WindowFrameType.Range && (flag || flag2)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46099", windowFrameClause, TSqlParserResource.SQL46099Message);
            }
            if (windowFrameClause.Top == null) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
            if (windowFrameClause.Bottom == null && TSql110ParserBaseInternal.isFollowingDelimiter(windowFrameClause.Top)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
            if (TSql110ParserBaseInternal.isFollowingDelimiter(windowFrameClause.Top) && TSql110ParserBaseInternal.isPrecedingDelimiter(windowFrameClause.Bottom)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
            if (windowFrameClause.Top.WindowDelimiterType == WindowDelimiterType.UnboundedFollowing || (windowFrameClause.Bottom != null && windowFrameClause.Bottom.WindowDelimiterType == WindowDelimiterType.UnboundedPreceding)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
            if (TSql110ParserBaseInternal.isFollowingDelimiter(windowFrameClause.Top) && windowFrameClause.Bottom != null && windowFrameClause.Bottom.WindowDelimiterType == WindowDelimiterType.CurrentRow) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
            if (windowFrameClause.Top.WindowDelimiterType == WindowDelimiterType.CurrentRow && TSql110ParserBaseInternal.isPrecedingDelimiter(windowFrameClause.Bottom)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46100", windowFrameClause, TSqlParserResource.SQL46100Message);
            }
        }

        protected string[] OptionValidForCreateDatabase() {
            return TSql110ParserBaseInternal._optionsValidForCreateDatabase;
        }
    }
}
