namespace OfaSchlupfer.SQLCodeReflection {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class Utiltiy {
        /// <summary>
        /// Gets or sets the parser Version - default Sql140.
        /// </summary>
        public OfaSchlupfer.AST.SqlVersion ParserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether QuotedIdentifiers is set - default true.
        /// </summary>
        public bool InitialQuotedIdentifiers { get; set; }

        public Utiltiy() {
            this.ParserVersion = OfaSchlupfer.AST.SqlVersion.Sql140;
            this.InitialQuotedIdentifiers = true;
        }

        /// <summary>
        /// Parse TSQL
        /// </summary>
        /// <param name="input">sql code</param>
        /// <returns>the AST</returns>
        public OfaSchlupfer.AST.TSqlFragment Parse(string input) {
            using (var sr = new System.IO.StringReader(input)) {
                IList<OfaSchlupfer.AST.ParseError> errors;
                var parser = OfaSchlupfer.AST.TSqlParser.Create(OfaSchlupfer.AST.SqlVersion.Sql140, true);
                var result = parser.Parse(sr, out errors);
                if ((errors != null) && (errors.Count > 0)) {
                    return null;
                }
                return result;
            }
        }

        /// <summary>
        /// Parse TSQL
        /// </summary>
        /// <param name="input">sql code</param>
        /// <param name="errors">errors</param>
        /// <returns>the ast or null</returns>
        public OfaSchlupfer.AST.TSqlFragment Parse(System.IO.TextReader input, out IList<OfaSchlupfer.AST.ParseError> errors) {
            var parser = OfaSchlupfer.AST.TSqlParser.Create(OfaSchlupfer.AST.SqlVersion.Sql140, true);
            return parser.Parse(input, out errors);
        }

        /// <summary>
        /// Convert create view to alter view
        /// </summary>
        /// <param name="source">the source AST</param>
        /// <returns>the target AST.</returns>
        public OfaSchlupfer.AST.TSqlFragment Gna(OfaSchlupfer.AST.TSqlFragment source) {
            return OfaSchlupfer.SQLCodeReflection.Operations.AlterVisitor.Convert(source);
        }

    }
}
