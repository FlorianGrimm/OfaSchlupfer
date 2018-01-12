using System;
using System.Collections.Generic;
using System.IO;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TSql120Parser : TSqlParser {
        public TSql120Parser(bool initialQuotedIdentifiers)
            : base(initialQuotedIdentifiers) {
        }

        internal override TSqlLexerBaseInternal GetNewInternalLexer() {
            return new TSql120LexerInternal();
        }

        private TSql120ParserInternal GetNewInternalParser() {
            return new TSql120ParserInternal(base.QuotedIdentifier);
        }

        private TSql120ParserInternal GetNewInternalParserForInput(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParser = this.GetNewInternalParser();
            base.InitializeInternalParserInput((TSql80ParserBaseInternal)newInternalParser, input, out errors, startOffset, startLine, startColumn);
            return newInternalParser;
        }

        public override TSqlFragment Parse(IList<TSqlParserToken> tokens, out IList<ParseError> errors) {
            errors = new List<ParseError>();
            TSql120ParserInternal newInternalParser = this.GetNewInternalParser();
            newInternalParser.InitializeForNewInput(tokens, errors, false);
            return newInternalParser.ParseRuleWithStandardExceptionHandling(newInternalParser.script, "script");
        }

        public override ChildObjectName ParseChildObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointChildObjectName, "entryPointChildObjectName");
        }

        public override SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSchemaObjectName, "entryPointSchemaObjectName");
        }

        public override DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointScalarDataType, "entryPointScalarDataType");
        }

        public override ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointExpression, "entryPointExpression");
        }

        public override BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointBooleanExpression, "entryPointBooleanExpression");
        }

        public override StatementList ParseStatementList(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointStatementList, "entryPointStatementList");
        }

        public override SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointSubqueryExpressionWithOptionalCTE, "entryPointSubqueryExpressionWithOptionalCTE");
        }

        internal IPv4 ParseIPv4(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointIPv4Address, "entryPointIPv4Address");
        }

        public override TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifier, "entryPointConstantOrIdentifier");
        }

        public override TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            TSql120ParserInternal newInternalParserForInput = this.GetNewInternalParserForInput(input, out errors, startOffset, startLine, startColumn);
            return newInternalParserForInput.ParseRuleWithStandardExceptionHandling(newInternalParserForInput.entryPointConstantOrIdentifierWithDefault, "entryPointConstantOrIdentifierWithDefault");
        }

        internal override TSqlStatement PhaseOneParse(TextReader input) {
            TSql120ParserInternal newInternalParser = this.GetNewInternalParser();
            return base.PhaseOneParseImpl(newInternalParser, newInternalParser.script, "script", input);
        }
    }
}
