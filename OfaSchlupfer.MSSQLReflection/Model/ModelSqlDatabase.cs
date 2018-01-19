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

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        public ModelSqlDatabase() {
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
    }
}
