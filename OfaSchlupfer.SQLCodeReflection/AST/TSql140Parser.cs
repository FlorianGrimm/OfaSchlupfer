namespace OfaSchlupfer.AST {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.AST.Versioning;

    [System.Serializable]
    public sealed class TSql140Parser : TSqlParser {
        private SqlEngineType engineType;

        public TSql140Parser(bool initialQuotedIdentifiers)
            : base(initialQuotedIdentifiers) {
        }

        public TSql140Parser(bool initialQuotedIdentifiers, SqlEngineType engineType)
            : base(initialQuotedIdentifiers) {
            this.engineType = engineType;
        }

        internal override TSqlLexerBaseInternal GetNewInternalLexer() {
            return new TSql140LexerInternal();
        }

        private TSql140ParserInternal GetNewInternalParser() {
            return new TSql140ParserInternal(base.QuotedIdentifier);
        }

        private TSql140ParserInternal GetNewInternalParserForInput(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParser = this.GetNewInternalParser();
            base.InitializeInternalParserInput((TSql80ParserBaseInternal)newInternalParser, input, out errors, startOffset, startLine, startColumn);
            return newInternalParser;
        }

        public override TSqlFragment Parse(IList<TSqlParserToken> tokens, out IList<ParseError> errors) {
            errors = new List<ParseError>();
            TSql140ParserInternal newInternalParser = this.GetNewInternalParser();
            newInternalParser.InitializeForNewInput(tokens, errors, false);
            TSqlFragment tSqlFragment = newInternalParser.ParseRuleWithStandardExceptionHandling(newInternalParser.script, "script");
            if (tSqlFragment != null) {
                VersioningVisitor versioningVisitor = new VersioningVisitor(this.engineType, SqlVersion.Sql140);
                tSqlFragment.Accept(versioningVisitor);
                {
                    foreach (ParseError error in versioningVisitor.GetErrors()) {
                        errors.Add(error);
                    }
                    return tSqlFragment;
                }
            }
            return tSqlFragment;
        }

        public override ChildObjectName ParseChildObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointChildObjectName, "entryPointChildObjectName");
        }

        public override SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSchemaObjectName, "entryPointSchemaObjectName");
        }

        public override DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointScalarDataType, "entryPointScalarDataType");
        }

        public override ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointExpression, "entryPointExpression");
        }

        public override BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointBooleanExpression, "entryPointBooleanExpression");
        }

        public override StatementList ParseStatementList(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointStatementList, "entryPointStatementList");
        }

        public override SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSubqueryExpressionWithOptionalCTE, "entryPointSubqueryExpressionWithOptionalCTE");
        }

        internal IPv4 ParseIPv4(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointIPv4Address, "entryPointIPv4Address");
        }

        public override TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifier, "entryPointConstantOrIdentifier");
        }

        public override TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql140ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifierWithDefault, "entryPointConstantOrIdentifierWithDefault");
        }

        internal override TSqlStatement PhaseOneParse(TextReader input) {
            TSql140ParserInternal newInternalParser = this.GetNewInternalParser();
            return base.PhaseOneParseImpl(newInternalParser, newInternalParser.script, "script", input);
        }
    }
}
