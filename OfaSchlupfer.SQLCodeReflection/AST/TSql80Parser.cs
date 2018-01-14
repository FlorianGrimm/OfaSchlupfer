namespace OfaSchlupfer.AST {
    using System.Collections.Generic;
    using System.IO;

    [System.Serializable]
    public sealed class TSql80Parser : TSqlParser {
        public TSql80Parser(bool initialQuotedIdentifiers)
            : base(initialQuotedIdentifiers) {
        }

        internal override TSqlLexerBaseInternal GetNewInternalLexer() {
            return new TSql80LexerInternal();
        }

        private TSql80ParserInternal GetNewInternalParser() {
            return new TSql80ParserInternal(base.QuotedIdentifier);
        }

        private TSql80ParserInternal GetNewInternalParserForInput(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParser = this.GetNewInternalParser();
            base.InitializeInternalParserInput((TSql80ParserBaseInternal)newInternalParser, input, out errors, startOffset, startLine, startColumn);
            return newInternalParser;
        }

        public override TSqlFragment Parse(IList<TSqlParserToken> tokens, out IList<ParseError> errors) {
            errors = new List<ParseError>();
            TSql80ParserInternal newInternalParser = this.GetNewInternalParser();
            newInternalParser.InitializeForNewInput(tokens, errors, false);
            return newInternalParser.ParseRuleWithStandardExceptionHandling(newInternalParser.script, "script");
        }

        public override ChildObjectName ParseChildObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointChildObjectName, "entryPointChildObjectName");
        }

        public override SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSchemaObjectName, "entryPointSchemaObjectName");
        }

        public override DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointScalarDataType, "entryPointScalarDataType");
        }

        public override ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointExpression, "entryPointExpression");
        }

        public override BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointBooleanExpression, "entryPointBooleanExpression");
        }

        public override StatementList ParseStatementList(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointStatementList, "entryPointStatementList");
        }

        public override SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSubqueryExpressionWithOptionalCTE, "entryPointSubqueryExpressionWithOptionalCTE");
        }

        public override TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifier, "entryPointConstantOrIdentifier");
        }

        public override TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql80ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifierWithDefault, "entryPointConstantOrIdentifierWithDefault");
        }

        internal override TSqlStatement PhaseOneParse(TextReader input) {
            TSql80ParserInternal newInternalParser = this.GetNewInternalParser();
            return base.PhaseOneParseImpl(newInternalParser, newInternalParser.script, "script", input);
        }
    }
}
