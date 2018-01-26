#pragma warning disable SA1600
#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    public class SqlNode {
        public readonly ScriptDom.TSqlFragment SourceTSqlFragment;
        public OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState Analyse;

        public SqlNode() {
            this.Analyse = new OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState(this);
        }

        public SqlNode(ScriptDom.TSqlFragment src) {
            this.Analyse = new OfaSchlupfer.MSSQLReflection.SqlCode.AnalyseNodeState(this);
            this.SourceTSqlFragment = src;
        }

        public virtual void Accept(SqlFragmentVisitor visitor) { }

        public virtual void AcceptChildren(SqlFragmentVisitor visitor) { }
    }

    public static class SqlNodeExtension {
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
