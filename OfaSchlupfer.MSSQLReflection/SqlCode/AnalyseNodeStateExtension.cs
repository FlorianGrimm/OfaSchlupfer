namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension
    /// </summary>
    public static class AnalyseNodeStateExtension {
        /// <summary>
        /// Get the related AnalyseResult
        /// </summary>
        /// <param name="that">this.</param>
        /// <returns>the related AnalyseResult</returns>
        public static AnalyseNodeState Related(this OfaSchlupfer.AST.TSqlFragment that) => OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState.Get(that);
    }
}
