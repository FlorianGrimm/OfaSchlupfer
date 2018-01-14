namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Parse and analyse
    /// </summary>
    public sealed class SqlCodeParse {
        /// <summary>
        /// Gets or sets the parser Version - default Sql140.
        /// </summary>
        public OfaSchlupfer.AST.SqlVersion ParserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether QuotedIdentifiers is set - default true.
        /// </summary>
        public bool InitialQuotedIdentifiers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeParse"/> class.
        /// </summary>
        public SqlCodeParse() {
            this.ParserVersion = OfaSchlupfer.AST.SqlVersion.Sql140;
            this.InitialQuotedIdentifiers = true;
        }

        /// <summary>
        /// Parse TSQL
        /// </summary>
        /// <param name="input">sql code</param>
        /// <returns>the AST</returns>
        public OfaSchlupfer.AST.TSqlFragment Parse(string input) {
            var sr = new StringReader(input);
            IList<OfaSchlupfer.AST.ParseError> errors;
            var parser = OfaSchlupfer.AST.TSqlParser.Create(OfaSchlupfer.AST.SqlVersion.Sql140, true);
            var result = parser.Parse(sr, out errors);
            if ((errors != null) && (errors.Count > 0)) {
                return null;
            }
            return result;
        }

        /// <summary>
        /// Parse TSQL
        /// </summary>
        /// <param name="input">sql code</param>
        /// <param name="errors">errors</param>
        /// <returns>the ast or null</returns>
        public OfaSchlupfer.AST.TSqlFragment Parse(TextReader input, out IList<OfaSchlupfer.AST.ParseError> errors) {
            var parser = OfaSchlupfer.AST.TSqlParser.Create(OfaSchlupfer.AST.SqlVersion.Sql140, true);
            return parser.Parse(input, out errors);
        }

        /// <summary>
        /// Analyse the AST
        /// </summary>
        /// <param name="fragment">the parsed AST</param>
        /// <param name="modelDatabase">the model</param>
        /// <returns>think of</returns>
        public List<AnalyseResult> Analyse(OfaSchlupfer.AST.TSqlFragment fragment, ModelSqlDatabase modelDatabase) {
            var dbScope = SqlCodeScope.CreateRoot(modelDatabase);
            var bindVisitor = new TSqlBindVisitor(dbScope);
            var result = bindVisitor.Run(fragment);
            return result;
        }
    }
}
