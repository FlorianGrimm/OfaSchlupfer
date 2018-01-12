using antlr;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TSqlParser {
        private class ExtractSchemaObjectNameVisitor : TSqlFragmentVisitor {
            public SchemaObjectName SchemaObjectName {
                get;
                private set;
            }

            public SchemaObjectName TriggerTargetName {
                get;
                private set;
            }

            public override void Visit(ProcedureStatementBody node) {
                this.SchemaObjectName = node.ProcedureReference.Name;
            }

            public override void Visit(ViewStatementBody node) {
                this.SchemaObjectName = node.SchemaObjectName;
            }

            public override void Visit(FunctionStatementBody node) {
                this.SchemaObjectName = node.Name;
            }

            public override void Visit(TriggerStatementBody node) {
                this.SchemaObjectName = node.Name;
                this.TriggerTargetName = node.TriggerObject.Name;
            }
        }

        internal const string ScriptEntryMethod = "script";

        private readonly bool _quotedIdentifier;

        public bool QuotedIdentifier {
            get {
                return this._quotedIdentifier;
            }
        }

        internal TSqlParser(bool quotedIdentifiersOn) {
            this._quotedIdentifier = quotedIdentifiersOn;
        }

        public static TSqlParser Create(SqlVersion tsqlParserVersion, bool initialQuotedIdentifiers) {
            switch (tsqlParserVersion) {
                case SqlVersion.Sql80:
                    return new TSql80Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql90:
                    return new TSql90Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql100:
                    return new TSql100Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql110:
                    return new TSql110Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql120:
                    return new TSql120Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql130:
                    return new TSql130Parser(initialQuotedIdentifiers);
                case SqlVersion.Sql140:
                    return new TSql140Parser(initialQuotedIdentifiers);
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SqlScriptGeneratorResource.UnknownEnumValue, new object[2]
                    {
                    tsqlParserVersion,
                    "TSqlParserVersion"
                    }), "tsqlParserVersion");
            }
        }

        public TSqlFragment Parse(TextReader input, out IList<ParseError> errors) {
            return this.Parse(input, out errors, 0, 1, 1);
        }

        public TSqlFragment Parse(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            IList<TSqlParserToken> tokenStream = this.GetTokenStream(input, out errors, startOffset, startLine, startColumn);
            if (errors.Count > 0) {
                return new TSqlScript();
            }
            return this.Parse(tokenStream, out errors);
        }

        public abstract TSqlFragment Parse(IList<TSqlParserToken> tokens, out IList<ParseError> errors);

        public abstract ChildObjectName ParseChildObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public ChildObjectName ParseChildObjectName(TextReader input, out IList<ParseError> errors) {
            return this.ParseChildObjectName(input, out errors, 0, 1, 1);
        }

        public abstract SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public SchemaObjectName ParseSchemaObjectName(TextReader input, out IList<ParseError> errors) {
            return this.ParseSchemaObjectName(input, out errors, 0, 1, 1);
        }

        public abstract DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public DataTypeReference ParseScalarDataType(TextReader input, out IList<ParseError> errors) {
            return this.ParseScalarDataType(input, out errors, 0, 1, 1);
        }

        public abstract TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public TSqlFragment ParseConstantOrIdentifier(TextReader input, out IList<ParseError> errors) {
            return this.ParseConstantOrIdentifier(input, out errors, 0, 1, 1);
        }

        public abstract TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public TSqlFragment ParseConstantOrIdentifierWithDefault(TextReader input, out IList<ParseError> errors) {
            return this.ParseConstantOrIdentifierWithDefault(input, out errors, 0, 1, 1);
        }

        public abstract ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public ScalarExpression ParseExpression(TextReader input, out IList<ParseError> errors) {
            return this.ParseExpression(input, out errors, 0, 1, 1);
        }

        public abstract BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public BooleanExpression ParseBooleanExpression(TextReader input, out IList<ParseError> errors) {
            return this.ParseBooleanExpression(input, out errors, 0, 1, 1);
        }

        public abstract StatementList ParseStatementList(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public StatementList ParseStatementList(TextReader input, out IList<ParseError> errors) {
            return this.ParseStatementList(input, out errors, 0, 1, 1);
        }

        public abstract SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn);

        public SelectStatement ParseSubQueryExpressionWithOptionalCTE(TextReader input, out IList<ParseError> errors) {
            return this.ParseSubQueryExpressionWithOptionalCTE(input, out errors, 0, 1, 1);
        }

        public bool TryParseSqlModuleObjectName(TextReader input, out SchemaObjectName result) {
            TSqlStatement tSqlStatement = this.PhaseOneParse(input);
            ExtractSchemaObjectNameVisitor extractSchemaObjectNameVisitor = new ExtractSchemaObjectNameVisitor();
            result = null;
            if (tSqlStatement != null) {
                tSqlStatement.Accept(extractSchemaObjectNameVisitor);
                result = extractSchemaObjectNameVisitor.SchemaObjectName;
            }
            return result != null;
        }

        public bool TryParseTriggerModule(TextReader input, out SchemaObjectName triggerName, out SchemaObjectName targetName) {
            TSqlStatement tSqlStatement = this.PhaseOneParse(input);
            ExtractSchemaObjectNameVisitor extractSchemaObjectNameVisitor = new ExtractSchemaObjectNameVisitor();
            triggerName = null;
            targetName = null;
            if (tSqlStatement != null) {
                tSqlStatement.Accept(extractSchemaObjectNameVisitor);
                triggerName = extractSchemaObjectNameVisitor.SchemaObjectName;
                targetName = extractSchemaObjectNameVisitor.TriggerTargetName;
            }
            return targetName != null;
        }

        internal abstract TSqlStatement PhaseOneParse(TextReader input);

        public List<TSqlParserToken> GetTokenStream(TextReader input, out IList<ParseError> errors) {
            return this.GetTokenStream(input, out errors, 0, 1, 1);
        }

        public List<TSqlParserToken> GetTokenStream(TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            errors = new List<ParseError>();
            var collection = new List<TSqlParserToken>();
            TSqlLexerBaseInternal newInternalLexer = this.GetNewInternalLexer();
            newInternalLexer.InitializeForNewInput(startOffset, startLine, startColumn, input);
            TSqlParserToken tSqlParserToken = null;
            do {
                try {
                    tSqlParserToken = (TSqlParserToken)newInternalLexer.nextToken();
                    collection.Add(tSqlParserToken);
                } catch (TokenStreamRecognitionException exception) {
                    ParseError item = TSql80ParserBaseInternal.ProcessTokenStreamRecognitionException(exception, newInternalLexer.CurrentOffset);
                    errors.Add(item);
                    return collection;
                } catch (TSqlParseErrorException ex) {
                    errors.Add(ex.ParseError);
                }
            }
            while (tSqlParserToken != null && tSqlParserToken.TokenType != TSqlTokenType.EndOfFile);
            return collection;
        }

        public bool ValidateIdentifier(string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }
            using (StringReader input = new StringReader(name)) {
                IList<ParseError> list = default(IList<ParseError>);
                IList<TSqlParserToken> tokenStream = this.GetTokenStream((TextReader)input, out list, 0, 1, 1);
                if (tokenStream.Count == 2 && tokenStream[1].TokenType == TSqlTokenType.EndOfFile && (tokenStream[0].TokenType == TSqlTokenType.Identifier || tokenStream[0].TokenType == TSqlTokenType.QuotedIdentifier || tokenStream[0].TokenType == TSqlTokenType.AsciiStringOrQuotedIdentifier) && string.Equals(name, tokenStream[0].Text, StringComparison.Ordinal)) {
                    return true;
                }
            }
            return false;
        }

        internal abstract TSqlLexerBaseInternal GetNewInternalLexer();

        internal void InitializeInternalParserInput(TSql80ParserBaseInternal parser, TextReader input, out IList<ParseError> errors, int startOffset, int startLine, int startColumn) {
            IList<TSqlParserToken> tokenStream = this.GetTokenStream(input, out errors, startOffset, startLine, startColumn);
            parser.InitializeForNewInput(tokenStream, errors, false);
        }

        internal TSqlStatement PhaseOneParseImpl(TSql80ParserBaseInternal parser, TSql80ParserBaseInternal.ParserEntryPoint<TSqlScript> entryPoint, string entryPointName, TextReader input) {
            IList<ParseError> errors = default(IList<ParseError>);
            IList<TSqlParserToken> tokenStream = this.GetTokenStream(input, out errors, 0, 1, 1);
            parser.InitializeForNewInput(tokenStream, errors, true);
            bool flag = true;
            while (flag) {
                flag = false;
                try {
                    parser.ParseRuleWithStandardExceptionHandling(entryPoint, entryPointName);
                } catch (PhaseOnePartialAstException ex) {
                    return ex.Statement;
                } catch (PhaseOneBatchException) {
                    flag = true;
                }
            }
            return null;
        }
    }
}
