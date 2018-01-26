namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    public class SqlNode {
        public readonly ScriptDom.TSqlFragment SourceTSqlFragment;
        public object Tag;

        public SqlNode() {
        }

        public SqlNode(ScriptDom.TSqlFragment src) {
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
