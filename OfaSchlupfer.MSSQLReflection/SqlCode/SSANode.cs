namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// SSA
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Index}")]
    public class SSANode {
        private static int _Index;

        /// <summary>
        /// Index
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Initializes a new instance of the <see cref="SSANode"/> class.
        /// </summary>
        public SSANode() {
            this.Index = System.Threading.Interlocked.Increment(ref _Index);
        }
    }
}
