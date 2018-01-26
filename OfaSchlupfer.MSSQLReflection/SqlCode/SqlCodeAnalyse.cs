namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.MSSQLReflection.AST;
    using OfaSchlupfer.MSSQLReflection.Model;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// Parse and analyse
    /// </summary>
    public sealed class SqlCodeAnalyse {
        /// <summary>
        /// Gets or sets the parser Version - default Sql140.
        /// </summary>
        public ScriptDom.SqlVersion ParserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether QuotedIdentifiers is set - default true.
        /// </summary>
        public bool InitialQuotedIdentifiers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeAnalyse"/> class.
        /// </summary>
        public SqlCodeAnalyse() {
            this.ParserVersion = ScriptDom.SqlVersion.Sql140;
            this.InitialQuotedIdentifiers = true;
        }

        /// <summary>
        /// Parse the sql code
        /// </summary>
        /// <param name="sqlCode">the sql code </param>
        /// <returns>the AST or null.</returns>
        public ScriptDom.TSqlFragment Parse(string sqlCode) {
            var astUtiltiy = (new OfaSchlupfer.MSSQLReflection.AST.AstUtility() { ParserVersion = this.ParserVersion, InitialQuotedIdentifiers = this.InitialQuotedIdentifiers });
            return astUtiltiy.Parse(sqlCode);
        }

        /// <summary>
        /// Convert the AST
        /// </summary>
        /// <param name="fragment">the sql code </param>
        /// <returns>the AST or null.</returns>
        public SqlNode Transport(ScriptDom.TSqlFragment fragment) {
            var astUtiltiy = (new OfaSchlupfer.MSSQLReflection.AST.AstUtility() { ParserVersion = this.ParserVersion, InitialQuotedIdentifiers = this.InitialQuotedIdentifiers });
            return astUtiltiy.Transport(fragment);
        }

        /// <summary>
        /// Parse the sql code and transport
        /// </summary>
        /// <param name="sqlCode">the sql code </param>
        /// <returns>the AST or null.</returns>
        public SqlNode ParseTransport(string sqlCode) {
            var astUtiltiy = (new OfaSchlupfer.MSSQLReflection.AST.AstUtility() { ParserVersion = this.ParserVersion, InitialQuotedIdentifiers = this.InitialQuotedIdentifiers });
            var fragment = astUtiltiy.Parse(sqlCode);
            return astUtiltiy.Transport(fragment);
        }

        /// <summary>
        /// Analyse the sql Code
        /// </summary>
        /// <param name="sqlCode">the sql code to analyse.</param>
        /// <param name="modelDatabase">The model datavase</param>
        /// <returns>the analyse results</returns>
        public List<AnalyseResult> Analyse(string sqlCode, ModelSqlDatabase modelDatabase) {
            var astUtiltiy = (new OfaSchlupfer.MSSQLReflection.AST.AstUtility() { ParserVersion = this.ParserVersion, InitialQuotedIdentifiers = this.InitialQuotedIdentifiers });
            var fragment = astUtiltiy.Parse(sqlCode);
            if (fragment == null) { return null; }
            var node = astUtiltiy.Transport(fragment);
            return this.Analyse(node, modelDatabase);
        }

        /// <summary>
        /// Analyse the AST
        /// </summary>
        /// <param name="node">the parsed AST / transformed.</param>
        /// <param name="modelDatabase">the model</param>
        /// <returns>think of</returns>
        public List<AnalyseResult> Analyse(SqlNode node, ModelSqlDatabase modelDatabase) {
            var scopeNameResolverContext = new ScopeNameResolverContext(modelDatabase);
            var dbScope = SqlCodeScope.CreateRoot(scopeNameResolverContext);
            var bindVisitor = new TSqlBindVisitor(dbScope);
            var result = bindVisitor.Run(node);
            return result;
        }
    }
}
