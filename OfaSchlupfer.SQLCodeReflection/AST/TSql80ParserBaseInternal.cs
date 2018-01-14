namespace OfaSchlupfer.AST {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using antlr;
    using antlr.collections.impl;

    internal abstract class TSql80ParserBaseInternal : LLkParser {
        internal delegate T ParserEntryPoint<T>() where T : TSqlFragment;

        private const int LookAhead = 2;

        private readonly TSqlFragmentFactory _fragmentFactory = new TSqlFragmentFactory();

        private IList<ParseError> _parseErrors;

        private bool _phaseOne;

        protected TSqlWhitespaceTokenFilter _tokenSource;

        private bool _initialQuotedIdentifiersOn = true;

        private int _phaseOnePreviousStatementLevelErrorLine = -1;

        private int _phaseOnePreviousStatementLevelErrorColumn = -1;

        private static readonly BitSet _statementLevelRecoveryTokens;

        private static readonly BitSet _phaseOneBatchLevelRecoveryTokens;

        private static readonly BitSet _ddlStatementBeginnerTokens;

        private static HashSet<SqlDataTypeOption> _possibleSingleParameterDataTypes;

        private static Dictionary<IndexAffectingStatement, string> _indexOptionContainerStatementNames;

        private static readonly List<IndexAffectingStatement> StatementsWithBucketCount;

        public TSqlFragmentFactory FragmentFactory {
            get {
                return this._fragmentFactory;
            }
        }

        public bool PhaseOne {
            get {
                return this._phaseOne;
            }

            set {
                this._phaseOne = value;
            }
        }

        protected TSql80ParserBaseInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
        }

        protected TSql80ParserBaseInternal(ParserSharedInputState state, int k)
            : base(state, k) {
        }

        protected TSql80ParserBaseInternal(TokenStream lexer, int k)
            : base(lexer, k) {
        }

        public TSql80ParserBaseInternal(bool initialQuotedIdentifiersOn)
            : base(2) {
            this._initialQuotedIdentifiersOn = initialQuotedIdentifiersOn;
        }

        public void InitializeForNewInput(IList<TSqlParserToken> tokens, IList<ParseError> errors, bool phaseOne) {
            this._tokenSource = new TSqlWhitespaceTokenFilter(this._initialQuotedIdentifiersOn, tokens);
            this._parseErrors = errors;
            this._fragmentFactory.SetTokenStream(tokens);
            this.PhaseOne = phaseOne;
            this.setTokenBuffer(new TokenBuffer(this._tokenSource));
            this.resetState();
        }

        static TSql80ParserBaseInternal() {
            TSql80ParserBaseInternal._statementLevelRecoveryTokens = new BitSet(4);
            TSql80ParserBaseInternal._phaseOneBatchLevelRecoveryTokens = new BitSet(3);
            TSql80ParserBaseInternal._ddlStatementBeginnerTokens = new BitSet(2);
            TSql80ParserBaseInternal._possibleSingleParameterDataTypes = new HashSet<SqlDataTypeOption>
            {
                SqlDataTypeOption.Char,
                SqlDataTypeOption.VarChar,
                SqlDataTypeOption.NChar,
                SqlDataTypeOption.NVarChar,
                SqlDataTypeOption.Decimal,
                SqlDataTypeOption.Float,
                SqlDataTypeOption.Numeric,
                SqlDataTypeOption.Binary,
                SqlDataTypeOption.VarBinary,
                SqlDataTypeOption.Time,
                SqlDataTypeOption.DateTime2,
                SqlDataTypeOption.DateTimeOffset
            };
            TSql80ParserBaseInternal._indexOptionContainerStatementNames = new Dictionary<IndexAffectingStatement, string>
            {
                {
                    IndexAffectingStatement.AlterTableAddElement,
                    "ALTER TABLE"
                },
                {
                    IndexAffectingStatement.AlterTableRebuildAllPartitions,
                    "ALTER TABLE REBUILD PARTITION"
                },
                {
                    IndexAffectingStatement.AlterTableRebuildOnePartition,
                    "ALTER TABLE REBUILD PARTITION"
                },
                {
                    IndexAffectingStatement.AlterIndexRebuildAllPartitions,
                    "ALTER INDEX REBUILD PARTITION"
                },
                {
                    IndexAffectingStatement.AlterIndexRebuildOnePartition,
                    "ALTER INDEX REBUILD PARTITION"
                },
                {
                    IndexAffectingStatement.AlterIndexSet,
                    "ALTER INDEX"
                },
                {
                    IndexAffectingStatement.AlterIndexReorganize,
                    "ALTER INDEX REORGANIZE"
                },
                {
                    IndexAffectingStatement.CreateColumnStoreIndex,
                    "CREATE COLUMNSTORE INDEX"
                },
                {
                    IndexAffectingStatement.CreateIndex,
                    "CREATE INDEX"
                },
                {
                    IndexAffectingStatement.CreateTable,
                    "CREATE TABLE"
                },
                {
                    IndexAffectingStatement.CreateTableInlineIndex,
                    "CREATE TABLE (inline index)"
                },
                {
                    IndexAffectingStatement.CreateType,
                    "CREATE TYPE"
                },
                {
                    IndexAffectingStatement.CreateXmlIndex,
                    "CREATE XML INDEX"
                },
                {
                    IndexAffectingStatement.CreateOrAlterFunction,
                    "CREATE/ALTER FUNCTION"
                },
                {
                    IndexAffectingStatement.DeclareTableVariable,
                    "DECLARE"
                },
                {
                    IndexAffectingStatement.CreateSpatialIndex,
                    "CREATE SPATIAL INDEX"
                },
                {
                    IndexAffectingStatement.AlterTableAlterIndexRebuild,
                    "ALTER TABLE ALTER INDEX REBUILD"
                },
                {
                    IndexAffectingStatement.AlterTableAlterColumn,
                    "ALTER TABLE ALTER COLUMN"
                },
                {
                    IndexAffectingStatement.AlterIndexResume,
                    "ALTER INDEX RESUME"
                }
            };
            TSql80ParserBaseInternal.StatementsWithBucketCount = new List<IndexAffectingStatement>
            {
                IndexAffectingStatement.CreateTable,
                IndexAffectingStatement.CreateTableInlineIndex,
                IndexAffectingStatement.CreateType,
                IndexAffectingStatement.AlterTableAlterIndexRebuild
            };
            TSql80ParserBaseInternal._ddlStatementBeginnerTokens.add(35);
            TSql80ParserBaseInternal._ddlStatementBeginnerTokens.add(6);
            TSql80ParserBaseInternal._statementLevelRecoveryTokens.add(219);
            TSql80ParserBaseInternal._statementLevelRecoveryTokens.add(204);
            TSql80ParserBaseInternal._statementLevelRecoveryTokens.orInPlace(TSql80ParserBaseInternal._ddlStatementBeginnerTokens);
            TSql80ParserBaseInternal._phaseOneBatchLevelRecoveryTokens.add(219);
            TSql80ParserBaseInternal._phaseOneBatchLevelRecoveryTokens.orInPlace(TSql80ParserBaseInternal._ddlStatementBeginnerTokens);
        }

        protected void ResetQuotedIdentifiersSettingToInitial() {
            this._tokenSource.QuotedIdentifier = this._initialQuotedIdentifiersOn;
        }

        internal static void UpdateTokenInfo(TSqlFragment fragment, IToken token) {
            TSqlWhitespaceTokenFilter.TSqlParserTokenProxyWithIndex tSqlParserTokenProxyWithIndex = (TSqlWhitespaceTokenFilter.TSqlParserTokenProxyWithIndex)token;
            int tokenIndex = tSqlParserTokenProxyWithIndex.TokenIndex;
            if (tokenIndex != -1) {
                fragment.UpdateTokenInfo(tokenIndex, tokenIndex);
            }
        }

        protected static void AddAndUpdateTokenInfo<TFragmentType>(TSqlFragment node, IList<TFragmentType> collection, TFragmentType item) where TFragmentType : TSqlFragment {
            ((ICollection<TFragmentType>)collection).Add(item);
            node.UpdateTokenInfo((TSqlFragment)(object)item);
        }

        protected static void AddAndUpdateTokenInfo<TFragmentType>(TSqlFragment node, IList<TFragmentType> collection, IList<TFragmentType> otherCollection) where TFragmentType : TSqlFragment {
            foreach (TFragmentType item in (IEnumerable<TFragmentType>)otherCollection) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(node, collection, item);
            }
        }

        protected static string DecodeAsciiStringLiteral(string encodedValue) {
            int length = encodedValue.Length;
            string text = encodedValue.Substring(1, length - 2);
            if (encodedValue[0] == '"') {
                return text.Replace("\"\"", "\"");
            }
            return text.Replace("''", "'");
        }

        protected static string DecodeUnicodeStringLiteral(string encodedValue) {
            int length = encodedValue.Length;
            return encodedValue.Substring(2, length - 3).Replace("''", "'");
        }

        protected static bool IsAsciiStringLob(string asciiValue) {
            return asciiValue.Length > 8000;
        }

        protected static bool IsUnicodeStringLob(string unicodeValue) {
            return unicodeValue.Length > 8000;
        }

        protected static bool IsBinaryLiteralLob(string binaryValue) {
            return binaryValue.Length - 2 > 16000;
        }

        protected void AddParseError(ParseError parseError) {
            this._parseErrors.Add(parseError);
        }

        protected void RecoverAtStatementLevel(int statementStartLine, int statementStartColumn) {
            this.consumeUntil(TSql80ParserBaseInternal._statementLevelRecoveryTokens);
            int line = this.LT(1).getLine();
            int column = this.LT(1).getColumn();
            if (line == statementStartLine && column == statementStartColumn) {
                if (this.PhaseOne && this._phaseOnePreviousStatementLevelErrorLine != line && this._phaseOnePreviousStatementLevelErrorColumn != column) {
                    this._phaseOnePreviousStatementLevelErrorLine = line;
                    this._phaseOnePreviousStatementLevelErrorColumn = column;
                    throw new PhaseOneBatchException();
                }
                this.consume();
            }
        }

        protected void SkipInitialDdlTokens() {
            if (TSql80ParserBaseInternal._ddlStatementBeginnerTokens.member(this.LA(1))) {
                this.consume();
            }
        }

        protected void RecoverAtBatchLevel() {
            if (this.PhaseOne) {
                this.SkipInitialDdlTokens();
                this.consumeUntil(TSql80ParserBaseInternal._phaseOneBatchLevelRecoveryTokens);
                if (this.LA(1) == 219) {
                    return;
                }
                if (this.LA(1) == 1) {
                    return;
                }
                throw new PhaseOneBatchException();
            }
            this.consumeUntil(219);
        }

        protected void ThrowPartialAstIfPhaseOne(TSqlStatement statement) {
            if (!this.PhaseOne) {
                return;
            }
            throw new PhaseOnePartialAstException(statement);
        }

        protected void ThrowConstraintIfPhaseOne(ConstraintDefinition constraint) {
            if (!this.PhaseOne) {
                return;
            }
            throw new PhaseOneConstraintException(constraint);
        }

        protected bool NextTokenMatches(string keyword) {
            if (this.LA(1) != 1) {
                return string.Equals(this.LT(1).getText(), keyword, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        protected bool NextTokenMatches(string keyword, int which) {
            if (this.LA(which) != 1) {
                return string.Equals(this.LT(which).getText(), keyword, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        protected bool NextTokenMatchesOneOf(params string[] keywords) {
            if (this.LA(1) == 1) {
                return false;
            }
            string text = this.LT(1).getText();
            foreach (string a in keywords) {
                if (string.Equals(a, text, StringComparison.OrdinalIgnoreCase)) {
                    return true;
                }
            }
            return false;
        }

        protected void ThrowIfEndOfFileOrBatch() {
            if (this.LA(1) != 1 && this.LA(1) != 219) {
                return;
            }
            throw new TSqlParseErrorException(null, true);
        }

        protected void AddBinaryExpression(ref ScalarExpression result, ScalarExpression expression, BinaryExpressionType type) {
            BinaryExpression binaryExpression = this.FragmentFactory.CreateFragment<BinaryExpression>();
            binaryExpression.FirstExpression = result;
            binaryExpression.SecondExpression = expression;
            binaryExpression.BinaryExpressionType = type;
            result = binaryExpression;
        }

        protected void AddBinaryExpression(ref BooleanExpression result, BooleanExpression expression, BooleanBinaryExpressionType type) {
            BooleanBinaryExpression booleanBinaryExpression = this.FragmentFactory.CreateFragment<BooleanBinaryExpression>();
            booleanBinaryExpression.FirstExpression = result;
            booleanBinaryExpression.SecondExpression = expression;
            booleanBinaryExpression.BinaryExpressionType = type;
            result = booleanBinaryExpression;
        }

        protected Identifier GetEmptyIdentifier(IToken token) {
            Identifier identifier = this.FragmentFactory.CreateFragment<Identifier>();
            TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
            identifier.SetIdentifier(string.Empty);
            return identifier;
        }

        protected static void CheckXmlForClauseOptionDuplication(XmlForClauseOptions current, XmlForClauseOptions newOption, IToken token) {
            if ((current & newOption) != 0) {
                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
            if ((newOption & XmlForClauseOptions.ElementsAll) == XmlForClauseOptions.None) {
                return;
            }
            if ((current & XmlForClauseOptions.ElementsAll) == XmlForClauseOptions.None) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static void AddIdentifierToListWithCheck(List<Identifier> list, Identifier item, int max) {
            if (list.Count == max) {
                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(item);
            }
            list.Add(item);
        }

        protected static void CheckOptionDuplication(ref int encountered, int newOption, TSqlFragment vOption) {
            TSql80ParserBaseInternal.CheckOptionDuplication(ref encountered, newOption, TSql80ParserBaseInternal.GetFirstToken(vOption));
        }

        protected static void CheckOptionDuplication(ref int encountered, int newOption, IToken token) {
            int num = 1 << newOption;
            if ((encountered & num) == num) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46049", token, TSqlParserResource.SQL46049Message, token.getText());
            }
            encountered |= num;
        }

        protected static void CheckOptionDuplication(ref ulong encountered, int newOption, TSqlFragment vOption) {
            TSql80ParserBaseInternal.CheckOptionDuplication(ref encountered, newOption, TSql80ParserBaseInternal.GetFirstToken(vOption));
        }

        protected static void CheckOptionDuplication(ref ulong encountered, int newOption, IToken token) {
            ulong num = (ulong)(1L << newOption);
            if ((encountered & num) == num) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46049", token, TSqlParserResource.SQL46049Message, token.getText());
            }
            encountered |= num;
        }

        protected IdentifierOrValueExpression IdentifierOrValueExpression(Identifier identifier) {
            IdentifierOrValueExpression identifierOrValueExpression = this.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            identifierOrValueExpression.Identifier = identifier;
            return identifierOrValueExpression;
        }

        protected IdentifierOrValueExpression IdentifierOrValueExpression(ValueExpression valueExpression) {
            IdentifierOrValueExpression identifierOrValueExpression = this.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            identifierOrValueExpression.ValueExpression = valueExpression;
            return identifierOrValueExpression;
        }

        protected static OdbcLiteralType ParseOdbcLiteralType(IToken token) {
            if (TSql80ParserBaseInternal.TryMatch(token, "T")) {
                return OdbcLiteralType.Time;
            }
            if (TSql80ParserBaseInternal.TryMatch(token, "D")) {
                return OdbcLiteralType.Date;
            }
            if (TSql80ParserBaseInternal.TryMatch(token, "TS")) {
                return OdbcLiteralType.Timestamp;
            }
            if (TSql80ParserBaseInternal.TryMatch(token, "GUID")) {
                return OdbcLiteralType.Guid;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static OptimizerHintKind ParseJoinOptimizerHint(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "MERGE":
                    return OptimizerHintKind.MergeJoin;
                case "HASH":
                    return OptimizerHintKind.HashJoin;
                case "LOOP":
                    return OptimizerHintKind.LoopJoin;
                default:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
        }

        protected static OptimizerHintKind ParseUnionOptimizerHint(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "CONCAT":
                    return OptimizerHintKind.ConcatUnion;
                case "HASH":
                    return OptimizerHintKind.HashUnion;
                case "MERGE":
                    return OptimizerHintKind.MergeUnion;
                case "KEEP":
                    return OptimizerHintKind.KeepUnion;
                default:
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
            }
        }

        protected bool IsNextRuleSelectParenthesis() {
            bool result = false;
            if (this.LA(1) == 191 && this.LA(2) == 140) {
                return true;
            }
            int pos = this.mark();
            this.consume();
            int num = 1;
            bool flag = true;
            while (flag) {
                switch (this.LA(1)) {
                    case 191:
                        num++;
                        break;
                    case 192:
                        num--;
                        if (num == 0) {
                            flag = false;
                        }
                        break;
                    case 1:
                        flag = false;
                        break;
                    case 36:
                    case 59:
                    case 72:
                    case 85:
                    case 87:
                    case 90:
                    case 114:
                    case 158:
                        if (num == 1) {
                            result = true;
                            flag = false;
                        }
                        break;
                }
                this.consume();
            }
            this.rewind(pos);
            return result;
        }

        protected bool IsNextRuleBooleanParenthesis() {
            if (this.LA(1) != 191) {
                return false;
            }
            bool result = false;
            int pos = this.mark();
            this.consume();
            int num = 1;
            int num2 = 0;
            int num3 = 0;
            bool flag = true;
            while (flag) {
                switch (this.LA(1)) {
                    case 191:
                        num++;
                        break;
                    case 192:
                        if (num == num3) {
                            num3 = 0;
                        }
                        num--;
                        if (num == 0) {
                            flag = false;
                        }
                        break;
                    case 1:
                        flag = false;
                        break;
                    case 7:
                    case 14:
                    case 31:
                    case 62:
                    case 69:
                    case 83:
                    case 89:
                    case 94:
                    case 99:
                    case 112:
                    case 157:
                    case 160:
                    case 188:
                    case 196:
                    case 205:
                    case 206:
                    case 207:
                    case 208:
                        if (num2 == 0 && num3 == 0) {
                            result = true;
                            flag = false;
                        }
                        break;
                    case 20:
                        num2++;
                        break;
                    case 56:
                        num2--;
                        break;
                    case 140:
                        if (num3 == 0) {
                            num3 = num;
                        }
                        break;
                }
                this.consume();
            }
            this.rewind(pos);
            return result;
        }

        protected bool SaveGuessing(out IToken marker) {
            marker = null;
            if (base.inputState.guessing == 0) {
                return false;
            }
            marker = this.LT(1);
            return true;
        }

        protected bool SkipGuessing(IToken marker) {
            if (marker == null) {
                return false;
            }
            if (base.inputState.guessing == 0) {
                return false;
            }
            while (this.LA(1) != 1 && this.LT(1) != marker) {
                this.consume();
            }
            return true;
        }

        protected static void Match(IToken token, string keyword) {
            if (!string.Equals(token.getText(), keyword, StringComparison.OrdinalIgnoreCase)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46005", token, TSqlParserResource.SQL46005Message, keyword, token.getText());
            }
        }

        protected static void Match(Identifier id, string constant) {
            if (string.Equals(id.Value, constant, StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(id);
        }

        protected static void Match(Identifier id, string constant, IToken tokenForError) {
            if (string.Equals(id.Value, constant, StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(tokenForError);
        }

        protected static void Match(IToken token, string keyword, string alternate) {
            if (string.Equals(token.getText(), keyword, StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            if (string.Equals(token.getText(), alternate, StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
        }

        protected static bool TryMatch(IToken token, string keyword) {
            return string.Equals(token.getText(), keyword, StringComparison.OrdinalIgnoreCase);
        }

        protected static bool TryMatch(Identifier identifier, string keyword) {
            return string.Equals(identifier.Value, keyword, StringComparison.OrdinalIgnoreCase);
        }

        protected static void MatchString(Literal literal, params string[] keywords) {
            string value = literal.Value;
            foreach (string b in keywords) {
                if (string.Equals(value, b, StringComparison.OrdinalIgnoreCase)) {
                    return;
                }
            }
            TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(TSql80ParserBaseInternal.GetFirstToken(literal));
        }

        protected static SqlDataTypeOption ParseDataType(string token) {
            switch (token.ToUpperInvariant()) {
                case "BIGINT":
                    return SqlDataTypeOption.BigInt;
                case "INTEGER":
                case "INT":
                    return SqlDataTypeOption.Int;
                case "SMALLINT":
                    return SqlDataTypeOption.SmallInt;
                case "TINYINT":
                    return SqlDataTypeOption.TinyInt;
                case "BIT":
                    return SqlDataTypeOption.Bit;
                case "DEC":
                case "DECIMAL":
                    return SqlDataTypeOption.Decimal;
                case "NUMERIC":
                    return SqlDataTypeOption.Numeric;
                case "MONEY":
                    return SqlDataTypeOption.Money;
                case "SMALLMONEY":
                    return SqlDataTypeOption.SmallMoney;
                case "FLOAT":
                    return SqlDataTypeOption.Float;
                case "REAL":
                    return SqlDataTypeOption.Real;
                case "DATETIME":
                    return SqlDataTypeOption.DateTime;
                case "SMALLDATETIME":
                    return SqlDataTypeOption.SmallDateTime;
                case "CHARACTER":
                case "CHAR":
                    return SqlDataTypeOption.Char;
                case "VARCHAR":
                    return SqlDataTypeOption.VarChar;
                case "TEXT":
                    return SqlDataTypeOption.Text;
                case "NCHAR":
                case "NCHARACTER":
                    return SqlDataTypeOption.NChar;
                case "NVARCHAR":
                    return SqlDataTypeOption.NVarChar;
                case "NTEXT":
                    return SqlDataTypeOption.NText;
                case "BINARY":
                    return SqlDataTypeOption.Binary;
                case "VARBINARY":
                    return SqlDataTypeOption.VarBinary;
                case "IMAGE":
                    return SqlDataTypeOption.Image;
                case "CURSOR":
                    return SqlDataTypeOption.Cursor;
                case "SQL_VARIANT":
                    return SqlDataTypeOption.Sql_Variant;
                case "TABLE":
                    return SqlDataTypeOption.Table;
                case "ROWVERSION":
                    return SqlDataTypeOption.Rowversion;
                case "TIMESTAMP":
                    return SqlDataTypeOption.Timestamp;
                case "UNIQUEIDENTIFIER":
                    return SqlDataTypeOption.UniqueIdentifier;
                default:
                    return SqlDataTypeOption.None;
            }
        }

        protected static IndexOptionKind ParseIndexLegacyWithOption(IToken token) {
            IndexOptionKind result = default(IndexOptionKind);
            if (!((OptionsHelper<IndexOptionKind>)IndexOptionHelper.Instance).TryParseOption(token, SqlVersionFlags.TSql80, out result)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46015", token, TSqlParserResource.SQL46015Message, token.getText());
            }
            return result;
        }

        protected static void ThrowWrongIndexOptionError(IndexAffectingStatement statement, TSqlFragment option) {
            string text = string.Empty;
            if (option.FirstTokenIndex >= 0 && option.ScriptTokenStream != null && option.FirstTokenIndex < option.ScriptTokenStream.Count) {
                TSqlParserToken tSqlParserToken = option.ScriptTokenStream[option.FirstTokenIndex];
                text = tSqlParserToken.Text;
            }
            string empty = default(string);
            if (!TSql80ParserBaseInternal._indexOptionContainerStatementNames.TryGetValue(statement, out empty)) {
                empty = string.Empty;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46057", option, TSqlParserResource.SQL46057Message, text, empty);
        }

        protected static void CheckFillFactorRange(Literal value) {
            int num = default(int);
            if (int.TryParse(value.Value, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out num) && num >= 1 && num <= 100) {
                return;
            }
            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46060", value, TSqlParserResource.SQL46060Message, value.Value);
        }

        protected static void CheckIdentifierLength(Identifier value) {
            if (value.Value.Length > 128) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46095", value, TSqlParserResource.SQL46095Message, value.Value.Substring(0, 128));
            }
        }

        protected static void CheckIdentifierLiteralLength(IdentifierLiteral value) {
            if (value.Value.Length > 128) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46095", value, TSqlParserResource.SQL46095Message, value.Value.Substring(0, 128));
            }
        }

        protected static void ThrowIfPercentValueOutOfRange(ScalarExpression expr) {
            Literal literal = null;
            if (expr is ParenthesisExpression) {
                ParenthesisExpression parenthesisExpression = expr as ParenthesisExpression;
                if (parenthesisExpression != null) {
                    TSql80ParserBaseInternal.ThrowIfPercentValueOutOfRange(parenthesisExpression.Expression);
                }
            } else if (expr is UnaryExpression) {
                UnaryExpression unaryExpression = expr as UnaryExpression;
                if (unaryExpression != null) {
                    if (unaryExpression.UnaryExpressionType == UnaryExpressionType.Negative) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46094", expr, TSqlParserResource.SQL46094Message);
                    } else {
                        TSql80ParserBaseInternal.ThrowIfPercentValueOutOfRange(unaryExpression.Expression);
                    }
                }
            } else {
                literal = (expr as Literal);
                if (literal != null) {
                    if (literal.LiteralType != LiteralType.Real && literal.LiteralType != LiteralType.Numeric && literal.LiteralType != 0) {
                        return;
                    }
                    double num = default(double);
                    if (double.TryParse(literal.Value, NumberStyles.Float, (IFormatProvider)CultureInfo.InvariantCulture, out num) && !(num < 0.0) && !(num > 100.0)) {
                        return;
                    }
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46094", expr, TSqlParserResource.SQL46094Message);
                }
            }
        }

        protected static void VerifyAllowedIndexOption(IndexAffectingStatement statement, IndexOption option) {
            TSql80ParserBaseInternal.VerifyAllowedIndexOption(statement, option, SqlVersionFlags.None);
        }

        protected static void VerifyAllowedIndexOption(IndexAffectingStatement statement, IndexOption option, SqlVersionFlags versionFlags) {
            bool flag = false;
            if (option.OptionKind == IndexOptionKind.FileStreamOn && statement != 0) {
                flag = true;
            }
            if (option.OptionKind == IndexOptionKind.BucketCount && !TSql80ParserBaseInternal.StatementsWithBucketCount.Contains(statement)) {
                flag = true;
            }
            if (option.OptionKind == IndexOptionKind.DataCompression && (versionFlags & SqlVersionFlags.TSql120AndAbove) == SqlVersionFlags.None) {
                DataCompressionOption dataCompressionOption = option as DataCompressionOption;
                if (dataCompressionOption.CompressionLevel == DataCompressionLevel.ColumnStore || dataCompressionOption.CompressionLevel == DataCompressionLevel.ColumnStoreArchive) {
                    flag = true;
                }
            }
            switch (statement) {
                case IndexAffectingStatement.AlterIndexRebuildOnePartition:
                    if (option.OptionKind != IndexOptionKind.SortInTempDB && option.OptionKind != IndexOptionKind.MaxDop && option.OptionKind != IndexOptionKind.DataCompression && option.OptionKind != IndexOptionKind.Resumable && option.OptionKind != IndexOptionKind.MaxDuration) {
                        if (option.OptionKind == IndexOptionKind.Online && (versionFlags & SqlVersionFlags.TSql120AndAbove) != 0) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterTableRebuildOnePartition:
                    if (option.OptionKind != IndexOptionKind.SortInTempDB && option.OptionKind != IndexOptionKind.MaxDop && option.OptionKind != IndexOptionKind.DataCompression) {
                        if (option.OptionKind == IndexOptionKind.Online && (versionFlags & SqlVersionFlags.TSql120AndAbove) != 0) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterIndexRebuildAllPartitions:
                    if (option.OptionKind != IndexOptionKind.DropExisting && option.OptionKind != IndexOptionKind.LobCompaction && option.OptionKind != IndexOptionKind.Order) {
                        break;
                    }
                    flag = true;
                    break;
                case IndexAffectingStatement.AlterTableRebuildAllPartitions:
                    if (option.OptionKind != IndexOptionKind.DropExisting && option.OptionKind != IndexOptionKind.LobCompaction && option.OptionKind != IndexOptionKind.Order && option.OptionKind != IndexOptionKind.Resumable && option.OptionKind != IndexOptionKind.MaxDuration) {
                        break;
                    }
                    flag = true;
                    break;
                case IndexAffectingStatement.AlterIndexReorganize:
                    if (option.OptionKind != IndexOptionKind.LobCompaction) {
                        if (option.OptionKind == IndexOptionKind.CompressAllRowGroups && (versionFlags & SqlVersionFlags.TSql130AndAbove) != 0) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterIndexSet:
                    if (option.OptionKind != IndexOptionKind.AllowRowLocks && option.OptionKind != IndexOptionKind.AllowPageLocks && option.OptionKind != IndexOptionKind.IgnoreDupKey && option.OptionKind != IndexOptionKind.StatisticsNoRecompute) {
                        if (option.OptionKind == IndexOptionKind.CompressionDelay && (versionFlags & SqlVersionFlags.TSql130AndAbove) != 0) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterIndexResume:
                    if (option.OptionKind != IndexOptionKind.MaxDop && option.OptionKind != IndexOptionKind.MaxDuration && option.OptionKind != IndexOptionKind.WaitAtLowPriority) {
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterTableAddElement:
                    if (option.OptionKind != IndexOptionKind.DropExisting && option.OptionKind != IndexOptionKind.LobCompaction && option.OptionKind != IndexOptionKind.Order && option.OptionKind != IndexOptionKind.Resumable && option.OptionKind != IndexOptionKind.MaxDuration) {
                        break;
                    }
                    flag = true;
                    break;
                case IndexAffectingStatement.CreateTable:
                case IndexAffectingStatement.CreateOrAlterFunction:
                case IndexAffectingStatement.DeclareTableVariable:
                    if (option.OptionKind == IndexOptionKind.SortInTempDB || option.OptionKind == IndexOptionKind.Online || option.OptionKind == IndexOptionKind.MaxDop || option.OptionKind == IndexOptionKind.LobCompaction || option.OptionKind == IndexOptionKind.DropExisting || option.OptionKind == IndexOptionKind.Order || option.OptionKind == IndexOptionKind.Resumable || option.OptionKind == IndexOptionKind.MaxDuration) {
                        flag = true;
                    } else if (option.OptionKind == IndexOptionKind.DataCompression) {
                        DataCompressionOption dataCompressionOption2 = option as DataCompressionOption;
                        if (dataCompressionOption2.CompressionLevel != DataCompressionLevel.ColumnStore && dataCompressionOption2.CompressionLevel != DataCompressionLevel.ColumnStoreArchive) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.CreateColumnStoreIndex:
                    if (option.OptionKind == IndexOptionKind.DataCompression) {
                        DataCompressionOption dataCompressionOption3 = option as DataCompressionOption;
                        if ((versionFlags & SqlVersionFlags.TSql120AndAbove) != 0 && dataCompressionOption3.CompressionLevel != 0 && dataCompressionOption3.CompressionLevel != DataCompressionLevel.Row && dataCompressionOption3.CompressionLevel != DataCompressionLevel.Page) {
                            break;
                        }
                        flag = true;
                    } else if (option.OptionKind == IndexOptionKind.SortInTempDB || option.OptionKind == IndexOptionKind.Order || option.OptionKind == IndexOptionKind.CompressionDelay) {
                        if ((versionFlags & SqlVersionFlags.TSql130AndAbove) == SqlVersionFlags.None) {
                            flag = true;
                        }
                    } else if (option.OptionKind == IndexOptionKind.Online) {
                        if ((versionFlags & SqlVersionFlags.TSql140) == SqlVersionFlags.None) {
                            flag = true;
                        }
                    } else if (option.OptionKind != IndexOptionKind.DropExisting && option.OptionKind != IndexOptionKind.MaxDop) {
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.CreateType:
                    if (option.OptionKind != IndexOptionKind.IgnoreDupKey && option.OptionKind != IndexOptionKind.BucketCount) {
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.CreateIndex:
                case IndexAffectingStatement.CreateTableInlineIndex:
                    if (option.OptionKind == IndexOptionKind.LobCompaction || option.OptionKind == IndexOptionKind.Order || option.OptionKind == IndexOptionKind.Resumable || option.OptionKind == IndexOptionKind.MaxDuration) {
                        flag = true;
                    } else if (option.OptionKind == IndexOptionKind.DataCompression) {
                        DataCompressionOption dataCompressionOption5 = option as DataCompressionOption;
                        if (dataCompressionOption5.CompressionLevel != DataCompressionLevel.ColumnStore && dataCompressionOption5.CompressionLevel != DataCompressionLevel.ColumnStoreArchive) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.CreateXmlIndex:
                    if (option.OptionKind == IndexOptionKind.DataCompression || option.OptionKind == IndexOptionKind.LobCompaction || option.OptionKind == IndexOptionKind.Resumable || option.OptionKind == IndexOptionKind.MaxDuration) {
                        flag = true;
                    } else if (option.OptionKind == IndexOptionKind.IgnoreDupKey) {
                        IndexStateOption indexStateOption = option as IndexStateOption;
                        if (indexStateOption != null) {
                            flag = (indexStateOption.OptionState == OptionState.On);
                        }
                    }
                    break;
                case IndexAffectingStatement.CreateSpatialIndex:
                    if (option.OptionKind == IndexOptionKind.DataCompression) {
                        DataCompressionOption dataCompressionOption4 = option as DataCompressionOption;
                        if ((versionFlags & SqlVersionFlags.TSql110AndAbove) != 0 && dataCompressionOption4.CompressionLevel != DataCompressionLevel.ColumnStore && dataCompressionOption4.CompressionLevel != DataCompressionLevel.ColumnStoreArchive) {
                            break;
                        }
                        flag = true;
                    } else {
                        if (option.OptionKind != IndexOptionKind.LobCompaction && option.OptionKind != IndexOptionKind.FileStreamOn && option.OptionKind != IndexOptionKind.Resumable && option.OptionKind != IndexOptionKind.MaxDuration) {
                            break;
                        }
                        flag = true;
                    }
                    break;
                case IndexAffectingStatement.AlterTableAlterIndexRebuild:
                    if ((versionFlags & SqlVersionFlags.TSql130AndAbove) != 0 && option.OptionKind == IndexOptionKind.BucketCount) {
                        break;
                    }
                    flag = true;
                    break;
                case IndexAffectingStatement.AlterTableAlterColumn:
                    if ((versionFlags & SqlVersionFlags.TSql130AndAbove) != 0 && option.OptionKind == IndexOptionKind.Online) {
                        break;
                    }
                    flag = true;
                    break;
            }
            if (flag) {
                TSql80ParserBaseInternal.ThrowWrongIndexOptionError(statement, option);
            }
        }

        protected static void ThrowSyntaxErrorIfNotCreateAlterTable(IndexAffectingStatement statement, IToken atToken) {
            if (statement != IndexAffectingStatement.CreateTable && statement != 0) {
                TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(atToken);
            }
        }

        protected static FunctionOptionKind ParseAlterCreateFunctionWithOption(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "ENCRYPTION":
                    return FunctionOptionKind.Encryption;
                case "SCHEMABINDING":
                    return FunctionOptionKind.SchemaBinding;
                default:
                    throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46026", token, TSqlParserResource.SQL46026Message, token.getText()));
            }
        }

        protected static StatisticsOptionKind ParseCreateStatisticsWithOption(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "FULLSCAN":
                    return StatisticsOptionKind.FullScan;
                case "NORECOMPUTE":
                    return StatisticsOptionKind.NoRecompute;
                default:
                    throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46018", token, TSqlParserResource.SQL46018Message, token.getText()));
            }
        }

        protected static StatisticsOptionKind ParseSampleOptionsWithOption(IToken token) {
            if (string.Compare("ROWS", token.getText(), StringComparison.OrdinalIgnoreCase) == 0) {
                return StatisticsOptionKind.SampleRows;
            }
            throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46019", token, TSqlParserResource.SQL46019Message, token.getText()));
        }

        protected static TriggerEnforcement ParseTriggerEnforcement(IToken token) {
            switch (token.getText().ToUpperInvariant()) {
                case "ENABLE":
                    return TriggerEnforcement.Enable;
                case "DISABLE":
                    return TriggerEnforcement.Disable;
                default:
                    throw new NoViableAltException(token, token.getFilename());
            }
        }

        protected static void CheckSpecialColumn(ColumnReferenceExpression column) {
            if (column.ColumnType == ColumnType.Regular) {
                return;
            }
            if (column.MultiPartIdentifier == null) {
                return;
            }
            if (column.MultiPartIdentifier.Count < 4) {
                return;
            }
            throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46028", TSql80ParserBaseInternal.GetFirstToken(column), TSqlParserResource.SQL46028Message));
        }

        protected static void CheckStarQualifier(SelectStarExpression column) {
            if (column.Qualifier != null) {
                int count = column.Qualifier.Count;
                if (count >= 4) {
                    throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46028", TSql80ParserBaseInternal.GetFirstToken(column), TSqlParserResource.SQL46028Message));
                }
                if (count != 0) {
                    if (count >= 1 && !string.IsNullOrEmpty(column.Qualifier[count - 1].Value)) {
                        return;
                    }
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46016", column, TSqlParserResource.SQL46016Message);
                }
            }
        }

        protected static void CheckTableNameExistsForColumn(ColumnReferenceExpression column, bool multiPartRequisite) {
            int num = (column.MultiPartIdentifier != null) ? column.MultiPartIdentifier.Count : 0;
            if (!multiPartRequisite) {
                if (column.ColumnType == ColumnType.Regular && num == 1) {
                    return;
                }
                if (column.ColumnType != 0 && num == 0) {
                    return;
                }
            }
            bool flag = false;
            if (column.ColumnType == ColumnType.Regular) {
                if (num >= 2 && !string.IsNullOrEmpty(column.MultiPartIdentifier[num - 2].Value)) {
                    flag = true;
                }
            } else if (num >= 1 && !string.IsNullOrEmpty(column.MultiPartIdentifier[num - 1].Value)) {
                flag = true;
            }
            if (!flag) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46016", column, TSqlParserResource.SQL46016Message);
            }
        }

        protected static void CheckTwoPartNameForSchemaObjectName(SchemaObjectName name, string statementType) {
            if (name.DatabaseIdentifier == null) {
                return;
            }
            if (string.IsNullOrEmpty(name.DatabaseIdentifier.Value)) {
                return;
            }
            throw new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46021", TSql80ParserBaseInternal.GetFirstToken(name), TSqlParserResource.SQL46021Message, statementType));
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputString")]
        protected static void CheckIfValidLanguageString(Literal inputString) {
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputString")]
        protected static void CheckIfValidLanguageIdentifier(Identifier inputString) {
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputValue")]
        protected static void CheckIfValidLanguageInteger(Literal inputValue) {
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputValue")]
        protected static void CheckIfValidLanguageHex(Literal inputValue) {
        }

        protected static bool IsStopAtBeforeMarkRestoreOption(IToken token) {
            if (!TSql80ParserBaseInternal.TryMatch(token, "STOPATMARK")) {
                return TSql80ParserBaseInternal.TryMatch(token, "STOPBEFOREMARK");
            }
            return true;
        }

        protected StopRestoreOption CreateStopRestoreOption(IToken optionBeginning, ValueExpression mark, ValueExpression afterClause) {
            StopRestoreOption stopRestoreOption = this.FragmentFactory.CreateFragment<StopRestoreOption>();
            if (TSql80ParserBaseInternal.TryMatch(optionBeginning, "STOPATMARK")) {
                stopRestoreOption.IsStopAt = true;
                stopRestoreOption.OptionKind = RestoreOptionKind.StopAt;
            } else {
                stopRestoreOption.OptionKind = RestoreOptionKind.Stop;
            }
            stopRestoreOption.Mark = mark;
            if (afterClause != null) {
                stopRestoreOption.After = afterClause;
            }
            return stopRestoreOption;
        }

        protected ScalarExpressionRestoreOption CreateSimpleRestoreOptionWithValue(IToken optionBeginning, ScalarExpression optionValue) {
            ScalarExpressionRestoreOption scalarExpressionRestoreOption = this.FragmentFactory.CreateFragment<ScalarExpressionRestoreOption>();
            scalarExpressionRestoreOption.OptionKind = RestoreOptionWithValueHelper.Instance.ParseOption(optionBeginning);
            scalarExpressionRestoreOption.Value = optionValue;
            return scalarExpressionRestoreOption;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "entryPoint")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "exception")]
        protected void CreateInternalError(string entryPoint, Exception exception) {
            string sQL46001Message = TSqlParserResource.SQL46001Message;
            ParseError parseError = new ParseError(46001, this._tokenSource.LastToken.Offset, this._tokenSource.LastToken.Line, this._tokenSource.LastToken.Column, sQL46001Message);
            this.AddParseError(parseError);
        }

        protected void SetFunctionBodyStatement(FunctionStatementBody parent, BeginEndBlockStatement compoundStatement) {
            if (compoundStatement != null) {
                StatementList statementList = this.FragmentFactory.CreateFragment<StatementList>();
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(statementList, statementList.Statements, compoundStatement);
                parent.StatementList = statementList;
            }
        }

        protected static void AddConstraintToColumn(ConstraintDefinition constraint, ColumnDefinition column) {
            DefaultConstraintDefinition defaultConstraintDefinition = constraint as DefaultConstraintDefinition;
            if (defaultConstraintDefinition != null) {
                if (column.DefaultConstraint != null) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46012", constraint, TSqlParserResource.SQL46012Message);
                }
                column.DefaultConstraint = defaultConstraintDefinition;
            } else {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(column, column.Constraints, constraint);
            }
        }

        protected void PutIdentifiersIntoFunctionCall(FunctionCall functionCall, MultiPartIdentifier identifiers) {
            int count = identifiers.Count;
            functionCall.FunctionName = identifiers[count - 1];
            if (count > 1) {
                MultiPartIdentifierCallTarget multiPartIdentifierCallTarget = this.FragmentFactory.CreateFragment<MultiPartIdentifierCallTarget>();
                MultiPartIdentifier multiPartIdentifier = this.FragmentFactory.CreateFragment<MultiPartIdentifier>();
                for (int i = 0; i < count - 1; i++) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(multiPartIdentifier, multiPartIdentifier.Identifiers, identifiers[i]);
                }
                multiPartIdentifierCallTarget.MultiPartIdentifier = multiPartIdentifier;
                functionCall.CallTarget = multiPartIdentifierCallTarget;
            }
        }

        protected void VerifyColumnDataType(ColumnDefinition column) {
            if (column.DataType != null) {
                return;
            }
            if (string.Equals(column.ColumnIdentifier.Value, "TIMESTAMP", StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            throw this.GetUnexpectedTokenErrorException();
        }

        protected void CreateSetClauseColumn(AssignmentSetClause setClause, MultiPartIdentifier multiPartIdentifier) {
            ColumnReferenceExpression columnReferenceExpression = this.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            columnReferenceExpression.ColumnType = ColumnType.Regular;
            columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
            setClause.Column = columnReferenceExpression;
        }

        protected static void ProcessNationalAndVarying(SqlDataTypeReference type, IToken nationalToken, bool isVarying) {
            if (nationalToken != null && isVarying) {
                if (type.SqlDataTypeOption == SqlDataTypeOption.Char) {
                    type.SqlDataTypeOption = SqlDataTypeOption.NVarChar;
                } else {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46002", nationalToken, TSqlParserResource.SQL46002Message, TSql80ParserBaseInternal.GetSqlDataTypeName(type.SqlDataTypeOption));
                }
            } else if (nationalToken != null) {
                switch (type.SqlDataTypeOption) {
                    case SqlDataTypeOption.Char:
                        type.SqlDataTypeOption = SqlDataTypeOption.NChar;
                        break;
                    case SqlDataTypeOption.Text:
                        type.SqlDataTypeOption = SqlDataTypeOption.NText;
                        break;
                    default:
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46003", nationalToken, TSqlParserResource.SQL46003Message, TSql80ParserBaseInternal.GetSqlDataTypeName(type.SqlDataTypeOption));
                        break;
                }
            } else if (isVarying) {
                switch (type.SqlDataTypeOption) {
                    case SqlDataTypeOption.Binary:
                        type.SqlDataTypeOption = SqlDataTypeOption.VarBinary;
                        break;
                    case SqlDataTypeOption.Char:
                        type.SqlDataTypeOption = SqlDataTypeOption.VarChar;
                        break;
                    case SqlDataTypeOption.NChar:
                        type.SqlDataTypeOption = SqlDataTypeOption.NVarChar;
                        break;
                    default:
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46004", type, TSqlParserResource.SQL46004Message, TSql80ParserBaseInternal.GetSqlDataTypeName(type.SqlDataTypeOption));
                        break;
                }
            }
        }

        protected static string GetSqlDataTypeName(SqlDataTypeOption type) {
            if (type == SqlDataTypeOption.None) {
                return TSqlParserResource.UserDefined;
            }
            return type.ToString();
        }

        protected static void CheckSqlDataTypeParameters(SqlDataTypeReference dataType) {
            switch (dataType.Parameters.Count) {
                case 0:
                    break;
                case 1:
                    if (!TSql80ParserBaseInternal._possibleSingleParameterDataTypes.Contains(dataType.SqlDataTypeOption)) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46008", dataType, TSqlParserResource.SQL46008Message, dataType.SqlDataTypeOption.ToString());
                    }
                    if (dataType.Parameters[0].LiteralType == LiteralType.Max) {
                        if (dataType.SqlDataTypeOption != SqlDataTypeOption.Char && dataType.SqlDataTypeOption != SqlDataTypeOption.NChar && dataType.SqlDataTypeOption != SqlDataTypeOption.Binary) {
                            break;
                        }
                        TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(TSql80ParserBaseInternal.GetFirstToken(dataType.Parameters[0]));
                    }
                    break;
                case 2:
                    if (dataType.SqlDataTypeOption != SqlDataTypeOption.Decimal && dataType.SqlDataTypeOption != SqlDataTypeOption.Numeric) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46009", dataType, TSqlParserResource.SQL46009Message, dataType.SqlDataTypeOption.ToString());
                    }
                    break;
            }
        }

        protected bool IsTableReference(bool allowMultipleTableHints) {
            if (this.LA(1) != 191) {
                return true;
            }
            int pos = this.mark();
            try {
                this.consume();
                if ((this.LA(1) == 232 || this.LA(1) == 78) && (this.LA(2) == 192 || allowMultipleTableHints)) {
                    QuoteType quoteType = default(QuoteType);
                    string tokenString = Identifier.DecodeIdentifier(this.LT(1).getText(), out quoteType);
                    TableHintKind tableHintKind = default(TableHintKind);
                    if (((OptionsHelper<TableHintKind>)TableHintOptionsHelper.Instance).TryParseOption(tokenString, SqlVersionFlags.TSql80, out tableHintKind)) {
                        return true;
                    }
                }
            } finally {
                this.rewind(pos);
            }
            return false;
        }

        internal T ParseRuleWithStandardExceptionHandling<T>(ParserEntryPoint<T> entryPoint, string entryPointName) where T : TSqlFragment {
            T result = null;
            try {
                result = entryPoint();
                return result;
            } catch (TSqlParseErrorException ex) {
                if (!ex.DoNotLog) {
                    this.AddParseError(ex.ParseError);
                    return result;
                }
                return result;
            } catch (NoViableAltException ex2) {
                ParseError faultTolerantUnexpectedTokenError = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex2.token, ex2, this._tokenSource.LastToken.Offset);
                this.AddParseError(faultTolerantUnexpectedTokenError);
                return result;
            } catch (MismatchedTokenException ex3) {
                ParseError faultTolerantUnexpectedTokenError2 = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex3.token, ex3, this._tokenSource.LastToken.Offset);
                this.AddParseError(faultTolerantUnexpectedTokenError2);
                return result;
            } catch (RecognitionException) {
                ParseError unexpectedTokenError = TSql80ParserBaseInternal.GetUnexpectedTokenError(this.LT(1));
                this.AddParseError(unexpectedTokenError);
                return result;
            } catch (TokenStreamRecognitionException exception) {
                ParseError parseError = TSql80ParserBaseInternal.ProcessTokenStreamRecognitionException(exception, this._tokenSource.LastToken.Offset);
                this.AddParseError(parseError);
                return result;
            } catch (ANTLRException exception2) {
                this.CreateInternalError(entryPointName, exception2);
                return result;
            } catch (StackOverflowException exception3) {
                this.CreateInternalError(entryPointName, exception3);
                return result;
            } catch (NullReferenceException exception4) {
                this.CreateInternalError(entryPointName, exception4);
                return result;
            } catch (ArgumentException exception5) {
                this.CreateInternalError(entryPointName, exception5);
                return result;
            } catch (IndexOutOfRangeException exception6) {
                this.CreateInternalError(entryPointName, exception6);
                return result;
            }
        }

        protected void SetNameForDoublePrecisionType(DataTypeReference dataType, IToken doubleToken, IToken precisionToken) {
            Identifier identifier = this.FragmentFactory.CreateFragment<Identifier>();
            identifier.Value = "FLOAT";
            TSql80ParserBaseInternal.UpdateTokenInfo(identifier, doubleToken);
            TSql80ParserBaseInternal.UpdateTokenInfo(identifier, precisionToken);
            dataType.Name = this.FragmentFactory.CreateFragment<SchemaObjectName>();
            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dataType.Name, dataType.Name.Identifiers, identifier);
            TSql80ParserBaseInternal.UpdateTokenInfo(dataType, doubleToken);
            TSql80ParserBaseInternal.UpdateTokenInfo(dataType, precisionToken);
        }

        protected static void CheckForTemporaryFunction(SchemaObjectName name) {
            if (name.BaseIdentifier != null && name.BaseIdentifier.Value != null && name.BaseIdentifier.Value.StartsWith("#", StringComparison.Ordinal)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46093", name, TSqlParserResource.SQL46093Message, name.BaseIdentifier.Value);
            }
        }

        protected static void CheckForTemporaryView(SchemaObjectName name) {
            if (name.BaseIdentifier != null && name.BaseIdentifier.Value != null && name.BaseIdentifier.Value.StartsWith("#", StringComparison.Ordinal)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46092", name, TSqlParserResource.SQL46092Message, name.BaseIdentifier.Value);
            }
        }

        protected static IToken GetFirstToken(TSqlFragment fragment) {
            if (fragment.ScriptTokenStream != null && fragment.FirstTokenIndex != -1) {
                return fragment.ScriptTokenStream[fragment.FirstTokenIndex];
            }
            return null;
        }

        public static void ThrowParseErrorException(string identifier, TSqlFragment fragment, string messageTemplate, params string[] args) {
            TSql80ParserBaseInternal.ThrowParseErrorException(identifier, TSql80ParserBaseInternal.GetFirstToken(fragment), messageTemplate, args);
        }

        public static void ThrowParseErrorException(string identifier, IToken token, string messageTemplate, params string[] args) {
            ParseError error = TSql80ParserBaseInternal.CreateParseError(identifier, token, messageTemplate, args);
            throw new TSqlParseErrorException(error);
        }

        public static ParseError CreateParseError(string identifier, IToken token, string messageTemplate, params string[] args) {
            TSqlWhitespaceTokenFilter.TSqlParserTokenProxyWithIndex tSqlParserTokenProxyWithIndex = token as TSqlWhitespaceTokenFilter.TSqlParserTokenProxyWithIndex;
            int line;
            int column;
            int offset;
            if (tSqlParserTokenProxyWithIndex != null) {
                line = tSqlParserTokenProxyWithIndex.Token.Line;
                column = tSqlParserTokenProxyWithIndex.Token.Column;
                offset = tSqlParserTokenProxyWithIndex.Token.Offset;
            } else {
                TSqlParserToken tSqlParserToken = token as TSqlParserToken;
                if (tSqlParserToken != null) {
                    line = tSqlParserToken.Line;
                    column = tSqlParserToken.Column;
                    offset = tSqlParserToken.Offset;
                } else {
                    line = 1;
                    column = 1;
                    offset = 0;
                }
            }
            return TSql80ParserBaseInternal.CreateParseError(identifier, offset, line, column, messageTemplate, args);
        }

        public static ParseError CreateParseError(string identifier, int offset, int line, int column, string messageTemplate, params string[] args) {
            return new ParseError(int.Parse(identifier.Substring(3), CultureInfo.InvariantCulture), offset, line, column, string.Format(CultureInfo.CurrentCulture, messageTemplate, args));
        }

        internal static ParseError ProcessTokenStreamRecognitionException(TokenStreamRecognitionException exception, int lastOffset) {
            NoViableAltException ex = exception.recog as NoViableAltException;
            if (ex != null) {
                return TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex.token, ex, lastOffset);
            }
            MismatchedTokenException ex2 = exception.recog as MismatchedTokenException;
            if (ex2 != null) {
                return TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex2.token, ex2, lastOffset);
            }
            NoViableAltForCharException ex3 = exception.recog as NoViableAltForCharException;
            if (ex3 != null) {
                return TSql80ParserBaseInternal.CreateParseError("SQL46010", lastOffset, ex3.getLine(), ex3.getColumn(), TSqlParserResource.SQL46010Message, ex3.foundChar.ToString());
            }
            return new ParseError(46001, lastOffset, exception.recog.getLine(), exception.recog.getColumn(), TSqlParserResource.SQL46001Message);
        }

        internal static ParseError GetFaultTolerantUnexpectedTokenError(IToken token, RecognitionException exception, int lastOffset) {
            if (token == null) {
                return new ParseError(46001, lastOffset, exception.getLine(), exception.getColumn(), TSqlParserResource.SQL46001Message);
            }
            return TSql80ParserBaseInternal.GetUnexpectedTokenError(token);
        }

        public static ParseError GetIncorrectSyntaxError(IToken token) {
            return TSql80ParserBaseInternal.CreateParseError("SQL46010", token, TSqlParserResource.SQL46010Message, token.getText());
        }

        public static void ThrowIncorrectSyntaxErrorException(TSqlFragment fragment) {
            TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(TSql80ParserBaseInternal.GetFirstToken(fragment));
        }

        public static void ThrowIncorrectSyntaxErrorException(IToken token) {
            ParseError incorrectSyntaxError = TSql80ParserBaseInternal.GetIncorrectSyntaxError(token);
            throw new TSqlParseErrorException(incorrectSyntaxError);
        }

        protected TSqlParseErrorException GetUnexpectedTokenErrorException() {
            return TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(this.LT(1));
        }

        protected ParseError GetUnexpectedTokenError() {
            return TSql80ParserBaseInternal.GetUnexpectedTokenError(this.LT(1));
        }

        internal static ParseError GetUnexpectedTokenError(IToken token) {
            if (token.Type == 1) {
                return TSql80ParserBaseInternal.CreateParseError("SQL46029", token, TSqlParserResource.SQL46029Message);
            }
            return TSql80ParserBaseInternal.GetIncorrectSyntaxError(token);
        }

        internal static TSqlParseErrorException GetUnexpectedTokenErrorException(IToken token) {
            ParseError unexpectedTokenError = TSql80ParserBaseInternal.GetUnexpectedTokenError(token);
            return new TSqlParseErrorException(unexpectedTokenError);
        }

        protected static TSqlParseErrorException GetUnexpectedTokenErrorException(Identifier identifier) {
            string text = (identifier.QuoteType == QuoteType.NotQuoted) ? identifier.Value : Identifier.EncodeIdentifier(identifier.Value);
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46010", TSql80ParserBaseInternal.GetFirstToken(identifier), TSqlParserResource.SQL46010Message, text));
        }
    }
}
