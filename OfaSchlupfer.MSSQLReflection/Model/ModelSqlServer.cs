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
            ModelSqlDatabase database = null;
            {
                var nameA = name.GetAncestorAtLevel(ObjectLevel.Database);
                if ((object)nameA != null) {
                    if ((nameA.LevelCount == 1) && (nameA.ObjectLevel == ObjectLevel.Database)) {
                        database = this._Database.GetValueOrDefault(nameA);
                    }
                } else if ((nameA.LevelCount == 2) && (nameA.ObjectLevel == ObjectLevel.Database)) {
                    if (SqlNameEqualityComparer.Level1.Equals(this.Name, nameA.Parent /* Server */)) {
                        database = this._Database.GetValueOrDefault(nameA);
                    } else {
                        return null;
                    }
                }
                if (ReferenceEquals(nameA, name)) { return database; }
                if ((object)database != null) {
                    return database.ResolveObject(name, context);
                }
            }
#if false
            {
                if ((name.Level == 1) && (name.ObjectLevel == ObjectLevel.Database)) {
                    return this._Database.GetValueOrDefault(name);
                }
                if ((name.Level == 1) && (name.ObjectLevel == ObjectLevel.Unknown)) {
                    var result = this._Database.GetValueOrDefault(name);
                    if ((object)result != null) { return result; }
                }
                if ((name.Level == 2) && (name.ObjectLevel == ObjectLevel.Database)) {
                    if (SqlNameEqualityComparer.Level1.Equals(this.Name, name.Parent)) {
                        var result = this._Database.GetValueOrDefault(name);
                        if ((object)result != null) { return result; }
                    } else {
                        return null;
                    }
                }
                if ((name.Level == 2) && (name.ObjectLevel == ObjectLevel.Unknown)) {
                    if (SqlNameEqualityComparer.Level1.Equals(this.Name, name.Parent)) {
                        var result = this._Database.GetValueOrDefault(name);
                        if ((object)result != null) { return result; }
                    } else {
                        return null;
                    }
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
#endif
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
