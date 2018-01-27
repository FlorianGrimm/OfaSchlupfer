namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// AST bound inforamtion.
    /// </summary>
    public class AnalyseNodeState {
        private ISqlCodeType _SqlCodeType;

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
        public ISqlCodeResult ResultValue { get; set; }

        /// <summary>
        /// Gets or sets sqlCodeType
        /// </summary>
        public ISqlCodeType ResultType {
            get {
                return this._SqlCodeType;
            }

            set {
                if (this._SqlCodeType == null) {
                    this._SqlCodeType = value;
                } else {
                    if (value != null) {
                        if (this._SqlCodeType is SqlCodeTypeLazy lazy) {
                            // if this instance is shared solve it
                            lazy.SetResolvedCodeType(value);

                            // but use the new information.
                            this._SqlCodeType = value;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets OutputType - think of
        /// </summary>
        public ISqlCodeType OutputType { get; set; }
    }
}
