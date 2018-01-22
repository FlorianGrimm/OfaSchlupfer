#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class SqlResolveScope {
        public SqlResolveScope Parent;
        public SqlScope Scope;
        public ModelSqlDatabase Database;
        public ModelSqlSchema Schema;
        public List<SqlName> Names;

        public SqlResolveScope(SqlScope scope) {
            this.Names = new List<SqlName>();
            this.Parent = null;
            this.Scope = scope;
        }

        public SqlResolveScope(SqlResolveScope parent, SqlScope scope) {
            this.Names = new List<SqlName>();
            this.Parent = parent;
            this.Scope = scope;
        }

        public object ResolveObject(SqlName name) {
            return null;
        }

        public object ResolveColumn(SqlName name) {
            return null;
        }
    }
}
