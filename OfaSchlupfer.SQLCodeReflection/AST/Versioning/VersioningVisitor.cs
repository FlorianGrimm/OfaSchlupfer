namespace OfaSchlupfer.AST.Versioning {
    using System.Collections.Generic;
    using System.Globalization;

    public sealed class VersioningVisitor : TSqlConcreteFragmentVisitor {
        private SqlEngineType _targetEngineType;

        private SqlVersion _targetVersion;

        private List<ParseError> _errors;

        public VersioningVisitor(SqlScriptGeneratorOptions options) {
            this._targetEngineType = options.SqlEngineType;
            this._targetVersion = options.SqlVersion;
            this._errors = new List<ParseError>();
        }

        public VersioningVisitor(SqlEngineType engineType, SqlVersion version) {
            this._targetEngineType = engineType;
            this._targetVersion = version;
            this._errors = new List<ParseError>();
        }

        internal IList<ParseError> GetErrors() {
            return this._errors;
        }

        private void AddVersioningError(int offset, int line, int column, string unsupportedStatement) {
            ParseError item = new ParseError(46117, offset, line, column, string.Format(CultureInfo.CurrentCulture, TSqlParserResource.SQL46117Message, new object[1]
            {
                unsupportedStatement
            }));
            this._errors.Add(item);
        }

        public override void ExplicitVisit(SystemVersioningTableOption node) {
            if (node.OptionState == OptionState.On && node.RetentionPeriod != null && !node.RetentionPeriod.IsInfinity && this._targetEngineType != SqlEngineType.SqlAzure) {
                this.AddVersioningError(node.StartOffset, node.StartLine, node.StartColumn, "HISTORY_RETENTION_PERIOD");
            }
        }
    }
}
