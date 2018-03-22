#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    /// <summary>
    /// type information
    /// </summary>
    public interface ISqlCodeType {
        /// <summary>
        /// Get the resolved code type - lazy support
        /// </summary>
        /// <returns>the type</returns>
        ISqlCodeType GetResolvedCodeType();

        /// <summary>
        /// set the type.
        /// </summary>
        /// <param name="sqlCodeType">the known type.</param>
        void SetResolvedCodeType(ISqlCodeType sqlCodeType);
    }
}
