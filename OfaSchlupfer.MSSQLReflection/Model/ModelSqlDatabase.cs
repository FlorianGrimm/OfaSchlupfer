namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// the database
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlDatabase
        : IScopeNameResolver {
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlSchema> _Schemas;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlType> _Types;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlTable> _Tables;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlTableType> _TableTypes;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlView> _Views;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlProcedure> _Procedures;
        [JsonIgnore]
        private readonly Dictionary<SqlName, ModelSqlSynonym> _Synonyms;

        [JsonIgnore]
        private SqlScope _Scope;
        [JsonIgnore]
        private ModelSqlServer _SqlServer;
        [JsonIgnore]
        private SqlName _Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        public ModelSqlDatabase() {
            this._Schemas = new Dictionary<SqlName, ModelSqlSchema>(SqlNameEqualityComparer.Level1);
            this._Types = new Dictionary<SqlName, ModelSqlType>(SqlNameEqualityComparer.Level2);
            this._Tables = new Dictionary<SqlName, ModelSqlTable>(SqlNameEqualityComparer.Level2);
            this._TableTypes = new Dictionary<SqlName, ModelSqlTableType>(SqlNameEqualityComparer.Level2);
            this._Views = new Dictionary<SqlName, ModelSqlView>(SqlNameEqualityComparer.Level2);
            this._Procedures = new Dictionary<SqlName, ModelSqlProcedure>(SqlNameEqualityComparer.Level2);
            this._Synonyms = new Dictionary<SqlName, ModelSqlSynonym>(SqlNameEqualityComparer.Level2);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        /// <param name="scope">the scope</param>
        public ModelSqlDatabase(SqlScope scope)
            : this() {
            this._Scope = (scope?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        /// <param name="sqlServer">the owner</param>
        /// <param name="name">the name of the database</param>
        public ModelSqlDatabase(ModelSqlServer sqlServer, string name)
            : this(sqlServer.GetScope()) {
            this.Name = sqlServer.Name.Child(name, ObjectLevel.Database);
            this._SqlServer = sqlServer;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Database); } }

        /// <summary>
        /// Gets the server.
        /// </summary>
        [JsonIgnore]
        public ModelSqlServer SqlServer => this._SqlServer;

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
        /// Gets the tables.
        /// </summary>
        public Dictionary<SqlName, ModelSqlTableType> TableTypes => this._TableTypes;

        /// <summary>
        /// Gets the views.
        /// </summary>
        public Dictionary<SqlName, ModelSqlView> Views => this._Views;

        /// <summary>
        /// Gets the procedures.
        /// </summary>
        public Dictionary<SqlName, ModelSqlProcedure> Procedures => this._Procedures;

        /// <summary>
        /// Gets the Synonyms
        /// </summary>
        public Dictionary<SqlName, ModelSqlSynonym> Synonyms => this._Synonyms;

        /// <summary>
        /// Add this to parent.
        /// </summary>
        /// <returns>this</returns>
        public ModelSqlDatabase AddToParent() {
            this._SqlServer.AddDatabase(this);
            return this;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            if (name.ObjectLevel == ObjectLevel.Database) {
                if (name.LevelCount == 1 && SqlNameEqualityComparer.Level1.Equals(this.Name, name)) {
                    return this;
                }
                if (name.LevelCount == 2 && this.Name.Equals(name)) {
                    return this;
                }
                return null;
            }
            {
                var result = this._Schemas.GetValueOrDefault(name);
                if ((object)result != null) { return result; }
            }
            {
                var result = this._Types.GetValueOrDefault(name);
                if ((object)result != null) { return result; }
            }
            {
                var result = this._Tables.GetValueOrDefault(name);
                if ((object)result != null) { return result; }
            }
            return null;
        }

        /// <summary>
        /// Add schema.
        /// </summary>
        /// <param name="schema">the schema to add.</param>
        public void AddSchema(ModelSqlSchema schema) {
            if ((object)schema == null) { throw new ArgumentNullException(nameof(schema)); }
            this.Schemas[schema.Name] = schema;
        }

        /// <summary>
        /// Add the type.
        /// </summary>
        /// <param name="type">The type to add.</param>
        public void AddType(ModelSqlType type) {
            if ((object)type == null) { throw new ArgumentNullException(nameof(type)); }
            this.Types[type.Name] = type;
        }

        /// <summary>
        /// Add the table.
        /// </summary>
        /// <param name="table">The table to add.</param>
        public void AddTable(ModelSqlTable table) {
            if ((object)table == null) { throw new ArgumentNullException(nameof(table)); }
            this.Tables.Add(table.Name, table);
            this.Tables[table.Name] = table;
        }

        /// <summary>
        /// Add the view.
        /// </summary>
        /// <param name="view">The view to add.</param>
        public void AddView(ModelSqlView view) {
            if ((object)view == null) { throw new ArgumentNullException(nameof(view)); }
            this.Views[view.Name] = view;
        }

        /// <summary>
        /// Add the procedure.
        /// </summary>
        /// <param name="procedure">The procedure to add.</param>
        public void AddProcedure(ModelSqlProcedure procedure) {
            if ((object)procedure == null) { throw new ArgumentNullException(nameof(procedure)); }
            this.Procedures[procedure.Name] = procedure;
        }

        /// <summary>
        /// Add the synonym
        /// </summary>
        /// <param name="synonym">the new item</param>
        public void AddSynonym(ModelSqlSynonym synonym) {
            if ((object)synonym == null) { throw new ArgumentNullException(nameof(synonym)); }
            this.Synonyms[synonym.Name] = synonym;
        }

        /// <summary>
        /// Add the synonym
        /// </summary>
        /// <param name="tableType">the new item</param>
        public void AddTableType(ModelSqlTableType tableType) {
            this._TableTypes[tableType.Name] = tableType;
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
