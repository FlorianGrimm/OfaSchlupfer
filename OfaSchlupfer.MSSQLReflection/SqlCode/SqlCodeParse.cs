namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.ScriptDom;

    public sealed class SqlCodeParse {
        public TSqlFragment Parse(string input) {
            var sr = new StringReader(input);
            IList<ParseError> errors;
            var parser = TSqlParser.Create(SqlVersion.Sql140, true);
            var result = parser.Parse(sr, out errors);
            if ((errors != null) && (errors.Count > 0)) {
                return null;
            }
            return result;
        }

        public TSqlFragment Parse(TextReader input, out IList<ParseError> errors) {
            var parser = TSqlParser.Create(SqlVersion.Sql140, true);
            return parser.Parse(input, out errors);
        }

        public List<AnalyseResult> Analyse(TSqlFragment fragment, ModelSqlDatabase modelDatabase) {
            var dbScope = SqlCodeScope.CreateRoot(modelDatabase);
            var bindVisitor = new TSqlBindVisitor(dbScope);
            var result = bindVisitor.Run(fragment);
            return result;
        }
    }
}
