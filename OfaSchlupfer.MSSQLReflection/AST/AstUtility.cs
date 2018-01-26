#pragma warning disable SA1516
#pragma warning disable SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    public class AstUtility {
        /// <summary>
        /// Gets or sets the parser Version - default Sql140.
        /// </summary>
        public ScriptDom.SqlVersion ParserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether QuotedIdentifiers is set - default true.
        /// </summary>
        public bool InitialQuotedIdentifiers { get; set; }

        /// <summary>
        /// Gets or sets the sql engine type.
        /// </summary>
        public ScriptDom.SqlEngineType SqlEngineType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AstUtility"/> class.
        /// </summary>
        public AstUtility() {
            this.ParserVersion = ScriptDom.SqlVersion.Sql140;
            this.InitialQuotedIdentifiers = true;
            this.SqlEngineType = ScriptDom.SqlEngineType.All;
        }

        /// <summary>
        /// Parse SQL
        /// </summary>
        /// <param name="sqlCode">the SQL Text</param>
        /// <returns>the AST.</returns>
        public ScriptDom.TSqlFragment Parse(string sqlCode) {
            using (var sr = new System.IO.StringReader(sqlCode)) {
                var parser = new ScriptDom.TSql140Parser(true, ScriptDom.SqlEngineType.All);

                IList<ScriptDom.ParseError> errors;
                var result = parser.Parse(sr, out errors);
                if ((errors != null) && (errors.Count > 0)) {
                    return null;
                }
                return result;
            }
        }

        /// <summary>
        /// Convert the AST
        /// </summary>
        /// <param name="fragment">original AST</param>
        /// <returns>limited AST</returns>
        public SqlNode Transport(ScriptDom.TSqlFragment fragment) {
            return Copier.Copy<SqlNode>(fragment);
        }
    }
}
