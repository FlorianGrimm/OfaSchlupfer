namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Sequence of Types
    /// </summary>
    public sealed class SqlCodeTypeSequence : ISqlCodeType {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeTypeSequence"/> class.
        /// </summary>
        public SqlCodeTypeSequence() {
        }

        /// <summary>
        /// Get the resolved code type - lazy support
        /// </summary>
        /// <returns>the type</returns>
        public ISqlCodeType GetResolvedCodeType() {
            return this;
        }

        /// <summary>
        /// set the type.
        /// </summary>
        /// <param name="sqlCodeType">the known type.</param>
        public void SetResolvedCodeType(ISqlCodeType sqlCodeType) {
            if (ReferenceEquals(sqlCodeType, this)) { return; }
            throw new InvalidOperationException();
        }
    }
}
