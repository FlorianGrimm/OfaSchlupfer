namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Server
    /// </summary>
    public class ModelSqlServer
        : IScopeNameResolver {
        private readonly Dictionary<SqlName, ModelSqlDatabase> _Database;
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlServer"/> class.
        /// </summary>
        public ModelSqlServer() {
            this._Database = new Dictionary<SqlName, ModelSqlDatabase>();
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        public Dictionary<SqlName, ModelSqlDatabase> Database => this._Database;

        /// <summary>
        /// Gets the type by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlDatabase GetTypeByName(SqlName name) => this._Database.GetValueOrDefault(name);

        /// <summary>
        /// Gets the named object called name.
        /// </summary>
        /// <param name="name">the name to serach for</param>
        /// <returns>the found object or null.</returns>
        public object GetObject(SqlName name) {
            object result;

            result = this._Database.GetValueOrDefault(name);
            if ((object)result != null) { return result; }

            // TODO check if name has 3 parts - than use the 3rd and go ahead with 2
            if ((object)name != null) {
                var schemaName = name.Parent;
                var dbName = schemaName?.Parent;
                if (!ReferenceEquals(dbName, null) && ReferenceEquals(dbName?.Parent, SqlName.Root)) {
                    result = this._Database.GetValueOrDefault(dbName);
                    if ((object)result != null) { return result; }
                }

                var serverName = dbName?.Parent;
                if (!ReferenceEquals(serverName, null) && ReferenceEquals(serverName?.Parent, SqlName.Root)) {
                    if (serverName.Name == this.Name) {
                        result = this._Database.GetValueOrDefault(serverName);
                    }
                    if ((object)result != null) { return result; }
                }
            }

            return null;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="sqlName">the name to search for</param>
        /// <returns>the named object or null.</returns>
        public object Resolve(SqlName sqlName) {
            return this.GetObject(sqlName);
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = SqlScope.Root.CreateChildScope(this));
        }
    }
}
