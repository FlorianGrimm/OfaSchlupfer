namespace OfaSchlupfer.AST {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.AST.Versioning;

    [System.Serializable]
    public sealed class TSql130Parser : TSqlParser {
        private SqlEngineType engineType;

        public TSql130Parser(bool initialQuotedIdentifiers)
            : base(initialQuotedIdentifiers) {
        }

        public TSql130Parser(bool initialQuotedIdentifiers, SqlEngineType engineType)
            : base(initialQuotedIdentifiers) {
            this.engineType = engineType;
        }

        internal override TSqlLexerBaseInternal GetNewInternalLexer() {
            return new TSql130LexerInternal();
        }

        private TSql130ParserInternal GetNewInternalParser() {
            return new TSql130ParserInternal(base.QuotedIdentifier);
        }

        private TSql130ParserInternal GetNewInternalParserForInput(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParser = this.GetNewInternalParser();
            base.InitializeInternalParserInput((TSql80ParserBaseInternal)newInternalParser, input, out errors, startOffset, startLine, startColumn);
            return newInternalParser;
        }

        public override TSqlFragment Parse(IList<TSqlParserToken> tokens, out IList<ParseError> errors) {
            errors = new List<ParseError>();
            TSql130ParserInternal newInternalParser = this.GetNewInternalParser();
            newInternalParser.InitializeForNewInput(tokens, errors, false);
            TSqlFragment tSqlFragment = newInternalParser.ParseRuleWithStandardExceptionHandling(newInternalParser.script, "script");
            if (tSqlFragment != null) {
                VersioningVisitor versioningVisitor = new VersioningVisitor(this.engineType, SqlVersion.Sql130);
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
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointChildObjectName, "entryPointChildObjectName");
        }

        public override SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSchemaObjectName, "entryPointSchemaObjectName");
        }

        public override DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointScalarDataType, "entryPointScalarDataType");
        }

        public override ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointExpression, "entryPointExpression");
        }

        public override BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointBooleanExpression, "entryPointBooleanExpression");
        }

        public override StatementList ParseStatementList(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointStatementList, "entryPointStatementList");
        }

        public override SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSubqueryExpressionWithOptionalCTE, "entryPointSubqueryExpressionWithOptionalCTE");
        }

        internal IPv4 ParseIPv4(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointIPv4Address, "entryPointIPv4Address");
        }

        public override TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifier, "entryPointConstantOrIdentifier");
        }

        public override TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql130ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifierWithDefault, "entryPointConstantOrIdentifierWithDefault");
        }

        internal override TSqlStatement PhaseOneParse(TextReader input) {
            TSql130ParserInternal newInternalParser = this.GetNewInternalParser();
            return base.PhaseOneParseImpl(newInternalParser, newInternalParser.script, "script", input);
        }
    }
}
