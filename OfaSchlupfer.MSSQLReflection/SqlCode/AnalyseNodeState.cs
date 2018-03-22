namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// AST bound inforamtion.
    /// </summary>
    public class AnalyseNodeState {
        private ISqlCodeType _SqlCodeType;

        /// <summary>
        /// Gets or sets the Fragment
        /// </summary>
        public readonly SqlNode Fragment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyseNodeState"/> class.
        /// </summary>
        /// <param name="node">the owner</param>
        public AnalyseNodeState(SqlNode node) {
            this.Fragment = node;
        }

        /// <summary>
        /// Gets or sets the Scope.
        /// </summary>
        public SqlCodeScope SqlCodeScope { get; set; }

        /// <summary>
        /// Gets or sets result value
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
        /// Gets or sets OutputType - the outgoing data.
        /// </summary>
        public ISqlCodeType OutputType { get; set; }
    }
}
