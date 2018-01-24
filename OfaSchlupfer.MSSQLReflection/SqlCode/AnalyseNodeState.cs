namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.AST;

    /// <summary>
    /// AST bound inforamtion.
    /// </summary>
    public class AnalyseNodeState {
        /// <summary>
        /// Get the related instance - created if needed.
        /// </summary>
        /// <param name="fragment">the fragment</param>
        /// <returns>the related instance</returns>
        public static AnalyseNodeState Get(TSqlFragment fragment) {
            var result = fragment.Tag as AnalyseNodeState;
            if ((object)result == null) {
                result = new AnalyseNodeState() {
                    Fragment = fragment
                };
                fragment.Tag = result;
            }
            return result;
        }

        private AnalyseNodeState() {
        }

        /// <summary>
        /// Gets or sets the Fragment
        /// </summary>
        public TSqlFragment Fragment { get; set; }

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
