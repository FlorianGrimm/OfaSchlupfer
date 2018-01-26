namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// AST bound inforamtion.
    /// </summary>
    public class AnalyseNodeState {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyseNodeState"/> class.
        /// </summary>
        /// <param name="node">the owner</param>
        public AnalyseNodeState(SqlNode node) {
            this.Fragment = node;
        }

        /// <summary>
        /// Gets or sets the Fragment
        /// </summary>
        public SqlNode Fragment { get; set; }

        /// <summary>
        /// Gets or sets the Scope.
        /// </summary>
        public SqlCodeScope SqlCodeScope { get; set; }

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

        /// <summary>
        /// Gets or sets OutputType - think of
        /// </summary>
        public ISqlCodeType OutputType { get; set; }
    }
}
