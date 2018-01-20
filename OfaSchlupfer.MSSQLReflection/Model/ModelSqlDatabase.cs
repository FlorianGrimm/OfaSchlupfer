namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// the database
    /// </summary>
    public sealed class ModelSqlDatabase : IScopeNameResolver {
        private readonly Dictionary<SqlName, ModelSqlSchema> _Schemas;
        private readonly Dictionary<SqlName, ModelSqlType> _Types;
        private readonly Dictionary<SqlName, ModelSqlTable> _Tables;
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        public ModelSqlDatabase()
            : this((SqlScope)null) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        /// <param name="scope">the scope</param>
        public ModelSqlDatabase(SqlScope scope) {
            this._Scope = (scope ?? SqlScope.Root).CreateChildScope(this);
            this._Schemas = new Dictionary<SqlName, ModelSqlSchema>();
            this._Types = new Dictionary<SqlName, ModelSqlType>();
            this._Tables = new Dictionary<SqlName, ModelSqlTable>();
        }

        /// <summary>
        /// Gets the schemas.
        /// </summary>
        public Dictionary<SqlName, ModelSqlSchema> Schemas => this._Schemas;

        /// <summary>
        /// Gets the types.
        /// </summary>
        public Dictionary<SqlName, ModelSqlType> Types => this._Types;

        /// <summary>
        /// Gets the tables.
        /// </summary>
        public Dictionary<SqlName, ModelSqlTable> Tables => this._Tables;

        /// <summary>
        /// Gets the schemas.
        /// </summary>
        /// <returns>the schemas.</returns>
        public ModelSqlSchema[] GetSchemas() => this._Schemas.Values.ToArray();

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns>the types</returns>
        public ModelSqlType[] GetTypes() => this._Types.Values.ToArray();

        /// <summary>
        /// Get the sql tables.
        /// </summary>
        /// <returns>the sql tables</returns>
        public ModelSqlTable[] GetTables() => this._Tables.Values.ToArray();

        /// <summary>
        /// Gets the schema by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlSchema GetSchemaByName(SqlName name) => this._Schemas.GetValueOrDefault(name);

        /// <summary>
        /// Gets the type by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlType GetTypeByName(SqlName name) => this._Types.GetValueOrDefault(name);

        /// <summary>
        /// Gets the table by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlTable GetTableByName(SqlName name) => this._Tables.GetValueOrDefault(name);

        /// <summary>
        /// Gets the named object called name.
        /// </summary>
        /// <param name="name">the name to serach for</param>
        /// <returns>the found object or null.</returns>
        public object GetObject(SqlName name) {
            object result;

            result = this._Schemas.GetValueOrDefault(name);
            if ((object)result != null) { return result; }

            result = this._Types.GetValueOrDefault(name);
            if ((object)result != null) { return result; }

            result = this._Tables.GetValueOrDefault(name);
            if ((object)result != null) { return result; }

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
        /// Add schema.
        /// </summary>
        /// <param name="schema">the schema to add.</param>
        public void AddSchema(ModelSqlSchema schema) {
            if ((object)schema == null) { throw new ArgumentNullException(nameof(schema)); }
            this.Schemas.Add(schema.Name, schema);
        }

        /// <summary>
        /// Set schema.
        /// </summary>
        /// <param name="schema">the schema to set.</param>
        public void SetSchema(ModelSqlSchema schema) {
            if ((object)schema == null) { throw new ArgumentNullException(nameof(schema)); }
            this.Schemas[schema.Name] = schema;
        }

        /// <summary>
        /// Add the type.
        /// </summary>
        /// <param name="type">The type to add.</param>
        public void AddType(ModelSqlType type) {
            if ((object)type == null) { throw new ArgumentNullException(nameof(type)); }
            this.Types.Add(type.Name, type);
        }

        /// <summary>
        /// Set the type.
        /// </summary>
        /// <param name="type">The type to set.</param>
        public void SetType(ModelSqlType type) {
            if ((object)type == null) { throw new ArgumentNullException(nameof(type)); }
            this.Types[type.Name] = type;
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
