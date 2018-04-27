namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// the database
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlDatabase
        : FreezeableObject
        , IScopeNameResolver {
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSchema> _Schemas;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlType> _Types;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTable> _Tables;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTableType> _TableTypes;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlView> _Views;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlProcedure> _Procedures;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSynonym> _Synonyms;

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
            this._Schemas = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSchema>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Database = owner
                );

            this._Types = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlType>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
            this._Tables = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTable>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
            this._TableTypes = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTableType>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
            this._Views = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlView>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
            this._Procedures = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlProcedure>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
            this._Synonyms = new FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSynonym>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level2,
                (owner, item) => item.Database = owner
                );
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
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFrozen(); this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Database); } }

        [JsonProperty]
        public string NameSql { get { return SqlNameJsonConverter.ConvertToValue(this.Name); } set { this.ThrowIfFrozen(); this._Name = SqlNameJsonConverter.ConvertFromValue(value); } }

        /// <summary>
        /// Gets the server.
        /// </summary>
        [JsonIgnore]
        public ModelSqlServer SqlServer { get => this._SqlServer; set => this.SetOwnerWithChildren(ref this._SqlServer, value, (owner) => owner.Database); }

        /// <summary>
        /// Gets the schemas.
        /// </summary>        
        [JsonProperty(ItemIsReference = true)]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSchema> Schemas => this._Schemas;

        /// <summary>
        /// Gets the types.
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlType> Types => this._Types;

        /// <summary>
        /// Gets the tables.
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTable> Tables => this._Tables;

        /// <summary>
        /// Gets the tables.
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlTableType> TableTypes => this._TableTypes;

        /// <summary>
        /// Gets the views.
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlView> Views => this._Views;

        /// <summary>
        /// Gets the procedures.
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlProcedure> Procedures => this._Procedures;

        /// <summary>
        /// Gets the Synonyms
        /// </summary>
        [JsonIgnore]
        public FreezeableOwnedKeyedCollection<ModelSqlDatabase, SqlName, ModelSqlSynonym> Synonyms => this._Synonyms;

        ///// <summary>
        ///// Add this to parent.
        ///// </summary>
        ///// <returns>this</returns>
        //public ModelSqlDatabase AddToParent() {
        //    this._SqlServer.AddDatabase(this);
        //    return this;
        //}

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
            this.Schemas.Add(schema);
        }

        /// <summary>
        /// Add the type.
        /// </summary>
        /// <param name="type">The type to add.</param>
        public void AddType(ModelSqlType type) {
            if ((object)type == null) { throw new ArgumentNullException(nameof(type)); }
            this.Types.Add(type);
        }

        /// <summary>
        /// Add the table.
        /// </summary>
        /// <param name="table">The table to add.</param>
        public void AddTable(ModelSqlTable table) {
            if ((object)table == null) { throw new ArgumentNullException(nameof(table)); }
            this.Tables.Add(table);
        }

        /// <summary>
        /// Add the view.
        /// </summary>
        /// <param name="view">The view to add.</param>
        public void AddView(ModelSqlView view) {
            if ((object)view == null) { throw new ArgumentNullException(nameof(view)); }
            this.Views.Add(view);
        }

        /// <summary>
        /// Add the procedure.
        /// </summary>
        /// <param name="procedure">The procedure to add.</param>
        public void AddProcedure(ModelSqlProcedure procedure) {
            if ((object)procedure == null) { throw new ArgumentNullException(nameof(procedure)); }
            this.Procedures.Add(procedure);
        }

        /// <summary>
        /// Add the synonym
        /// </summary>
        /// <param name="synonym">the new item</param>
        public void AddSynonym(ModelSqlSynonym synonym) {
            if ((object)synonym == null) { throw new ArgumentNullException(nameof(synonym)); }
            this.Synonyms.Add(synonym);
        }

        /// <summary>
        /// Add the synonym
        /// </summary>
        /// <param name="tableType">the new item</param>
        public void AddTableType(ModelSqlTableType tableType) {
            this._TableTypes.Add(tableType);
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.Schemas.Freeze();
                /*
                this._Types 
                this._Tables 
                this._TableTypes 
                this._Views 
                this._Procedures 
                this._Synonyms 
                */
            }
            return result;
        }
    }
}
