namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// Result
    /// </summary>
    public class AnalyseResult {
        /// <summary>
        /// Gets or sets the Fragment
        /// </summary>
        public SqlNode Fragment { get; set; }

        /// <summary>
        /// Gets or sets the DeclarationScope.
        /// </summary>
        public SqlCodeScope DeclarationScope { get; set; }

        /// <summary>
        /// Gets or sets the last scope.
        /// </summary>
        public SqlCodeScope LastScope { get; set; }

        /// <summary>
        /// Gets or sets SqlCodeResult
        /// </summary>
        public ISqlCodeResult SqlCodeResult { get; set; }

        /// <summary>
        /// Gets or sets sqlCodeType
        /// </summary>
        public ISqlCodeType SqlCodeType { get; set; }
    }
}
