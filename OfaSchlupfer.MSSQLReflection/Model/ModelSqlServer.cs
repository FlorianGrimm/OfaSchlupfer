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
        private SqlName _Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlServer"/> class.
        /// </summary>
        public ModelSqlServer() {
            this._Database = new Dictionary<SqlName, ModelSqlDatabase>(SqlNameEqualityComparer.Level1);
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Server); } }

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
        /// Add the database
        /// </summary>
        /// <param name="modelSqlDatabase">the datbase to add</param>
        public void AddDatabase(ModelSqlDatabase modelSqlDatabase) {
            if ((object)modelSqlDatabase == null) { throw new ArgumentNullException(nameof(modelSqlDatabase)); }
            this.Database.Add(modelSqlDatabase.Name, modelSqlDatabase);
        }

        /// <summary>
        /// Set the database
        /// </summary>
        /// <param name="modelSqlDatabase">the datbase to add</param>
        public void SetDatabase(ModelSqlDatabase modelSqlDatabase) {
            if ((object)modelSqlDatabase == null) { throw new ArgumentNullException(nameof(modelSqlDatabase)); }
            this.Database[modelSqlDatabase.Name] = modelSqlDatabase;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            // if ((object)name != null)
            {
                if ((name.ObjectLevel == ObjectLevel.Database)
                    || (name.ObjectLevel == ObjectLevel.Unknown)) {
                    var result = this._Database.GetValueOrDefault(name);
                    if ((object)result != null) { return result; }
                }
            }
#warning TODO check if name has 3 parts - than use the 3rd and go ahead with 2
            {
                var schemaName = name.Parent;
                var dbName = schemaName?.Parent;
                if (!ReferenceEquals(dbName, null) && ReferenceEquals(dbName?.Parent, SqlName.Root)) {
                    var result = this._Database.GetValueOrDefault(dbName);
                    if ((object)result != null) { return result; }
                }

                var serverName = dbName?.Parent;
                if (!ReferenceEquals(serverName, null) && ReferenceEquals(serverName?.Parent, SqlName.Root)) {
                    if (serverName.Name == this.Name.Name) {
                        var result = this._Database.GetValueOrDefault(serverName);
                        if ((object)result != null) { return result; }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }
    }
}
