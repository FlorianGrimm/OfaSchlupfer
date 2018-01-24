namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using System.IO;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Parse and analyse
    /// </summary>
    public sealed class SqlCodeAnalyse {
        /// <summary>
        /// Gets or sets the parser Version - default Sql140.
        /// </summary>
        public OfaSchlupfer.AST.SqlVersion ParserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether QuotedIdentifiers is set - default true.
        /// </summary>
        public bool InitialQuotedIdentifiers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeAnalyse"/> class.
        /// </summary>
        public SqlCodeAnalyse() {
            this.ParserVersion = OfaSchlupfer.AST.SqlVersion.Sql140;
            this.InitialQuotedIdentifiers = true;
        }

        /// <summary>
        /// Parse the sql code
        /// </summary>
        /// <param name="sqlCode">the sql code </param>
        /// <returns>the AST or null.</returns>
        public OfaSchlupfer.AST.TSqlFragment Parse(string sqlCode) {
            return new OfaSchlupfer.SQLCodeReflection.Utiltiy().Parse(sqlCode);
        }

        /// <summary>
        /// Analyse the sql Code
        /// </summary>
        /// <param name="sqlCode">the sql code to analyse.</param>
        /// <param name="modelDatabase">The model datavase</param>
        /// <returns>the analyse results</returns>
        public List<AnalyseResult> Analyse(string sqlCode, ModelSqlDatabase modelDatabase) {
            var utiltiy = new OfaSchlupfer.SQLCodeReflection.Utiltiy();
            var fragment = utiltiy.Parse(sqlCode);
            if (fragment == null) { return null; }
            return this.Analyse(fragment, modelDatabase);
        }

        /// <summary>
        /// Analyse the AST
        /// </summary>
        /// <param name="fragment">the parsed AST</param>
        /// <param name="modelDatabase">the model</param>
        /// <returns>think of</returns>
        public List<AnalyseResult> Analyse(OfaSchlupfer.AST.TSqlFragment fragment, ModelSqlDatabase modelDatabase) {
            var scopeNameResolverContext = new ScopeNameResolverContext(modelDatabase);
            var dbScope = SqlCodeScope.CreateRoot(scopeNameResolverContext);
            var bindVisitor = new TSqlBindVisitor(dbScope);
            var result = bindVisitor.Run(fragment);
            return result;
        }
    }
}
