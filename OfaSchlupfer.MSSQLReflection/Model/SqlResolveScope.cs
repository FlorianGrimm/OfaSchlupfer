#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public sealed class SqlResolveScope {
        [JsonIgnore]
        public SqlResolveScope Parent;
        [JsonIgnore]
        public SqlScope Scope;
        [JsonIgnore]
        public ModelSqlDatabase Database;
        [JsonIgnore]
        public ModelSqlSchema Schema;
        [JsonIgnore]
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
