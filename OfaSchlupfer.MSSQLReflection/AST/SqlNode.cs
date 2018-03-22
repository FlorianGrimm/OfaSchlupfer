#pragma warning disable SA1402

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.SqlCode;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// Base SqlNode
    /// </summary>
    public class SqlNode {
        /// <summary>
        /// the orignal AST.
        /// </summary>
        public readonly ScriptDom.TSqlFragment SourceTSqlFragment;

        /// <summary>
        /// SSA
        /// </summary>
        public SSANode SSA;

        /// <summary>
        /// think of
        /// </summary>
        public OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState Analyse;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlNode"/> class.
        /// </summary>
        public SqlNode() {
            this.Analyse = new OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlNode"/> class.
        /// </summary>
        /// <param name="src">the source.</param>
        public SqlNode(ScriptDom.TSqlFragment src) {
            this.Analyse = new OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState(this);
            this.SourceTSqlFragment = src;
        }

        /// <summary>
        /// Visitor Accept
        /// </summary>
        /// <param name="visitor">visitor callback.</param>
        [System.Diagnostics.DebuggerStepThrough]
        public virtual void Accept(SqlFragmentVisitor visitor) { }

        /// <summary>
        /// Visitor AcceptChildren
        /// </summary>
        /// <param name="visitor">visitor callback.</param>
        [System.Diagnostics.DebuggerStepThrough]
        public virtual void AcceptChildren(SqlFragmentVisitor visitor) { }
    }

    /// <summary>
    /// Extension
    /// </summary>
    public static class SqlNodeExtension {
        /// <summary>
        /// Accept each item in list
        /// </summary>
        /// <typeparam name="T">the type of the item.</typeparam>
        /// <param name="that">the list.</param>
        /// <param name="visitor">the visitor callback.</param>
        public static void Accept<T>(this List<T> that, SqlFragmentVisitor visitor)
            where T : SqlNode {
            if (that != null) {
                for (int i = 0, count = that.Count; i < count; i++) {
                    that[i].Accept(visitor);
                }
            }
        }
    }
}
