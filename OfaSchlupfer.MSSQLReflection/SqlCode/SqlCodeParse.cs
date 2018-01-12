namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        public object Analyse(TSqlFragment fragment, ModelSqlDatabase modelDatabase) {
            var dbScope = SqlCodeScope.CreateRoot(modelDatabase);
            var bindVisitor = new TSqlBindVisitor(dbScope);
            fragment.Accept(bindVisitor);
            //var analyseVisitor = new TSqlAnalyseVisitor();
            //fragment.Accept(visitor);
            return null;
        }
    }
}
