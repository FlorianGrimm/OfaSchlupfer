#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlSchema
        : FreezableObject
        , IEquatable<ModelSqlSchema>
        , IScopeNameResolver
        , IContainerNamedReferences {
        /// <summary>
        /// Get or Create the schema
        /// </summary>
        /// <param name="database">the database</param>
        /// <param name="name">the name of the schema</param>
        /// <returns>old or new schema</returns>
        public static ModelSqlSchema Ensure(ModelSqlDatabase database, string name) {
            var sqlName = database.Name.Child(name, ObjectLevel.Schema);
            return database.Schemas.GetValueOrDefault(sqlName)
                ?? new ModelSqlSchema(database, name);
        }

        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlType> _Types;
        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTable> _Tables;
        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTableType> _TableTypes;
        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlView> _Views;
        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlProcedure> _Procedures;
        private readonly FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlSynonym> _Synonyms;
        private SqlName _Name;
        private SqlScope _Scope;
        private ModelSqlDatabase _Database;

        public ModelSqlSchema() {
            var keyComparer = SqlNameEqualityComparer.Level2;
            this._Types = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlType>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
            this._Tables = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTable>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
            this._TableTypes = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTableType>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
            this._Views = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlView>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
            this._Procedures = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlProcedure>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
            this._Synonyms = new FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlSynonym>(
                this,
                (item) => item.Name,
                keyComparer,
                (owner, item) => item.Schema = owner
                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="scopeDatbase">the database scope.</param>
        public ModelSqlSchema(SqlScope scopeDatbase)
            : this() {
            this._Scope = (scopeDatbase?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="database">the owner</param>
        /// <param name="name">the name of the schema</param>
        public ModelSqlSchema(ModelSqlDatabase database, string name)
            : this(database.GetScope()) {
            this.Name = database.Name.Child(name, ObjectLevel.Schema);
            this.Database = database;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="src">copy source</param>
        public ModelSqlSchema(ModelSqlSchema src) {
            // TODO: copy properties
            this.Name = src.Name;
        }

        public ModelSqlDatabase Database { get => this._Database; set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.Schemas); }

#warning weichei
        /*
        public void AddType(ModelSqlType modelSqlType) {
            // this._Types[modelSqlType.Name] = modelSqlType;
            this._Types.Add(modelSqlType);
            this._Database.Types.Add(modelSqlType);
        }

        public void AddTable(ModelSqlTable modelSqlTable) {
            // this._Tables[modelSqlTable.Name] = modelSqlTable;
            this._Tables.Add(modelSqlTable);
            this._Database.Tables.Add(modelSqlTable);
        }

        public void AddView(ModelSqlView modelSqlView) {
            // this._Views[modelSqlView.Name] = modelSqlView;
            this._Views.Add(modelSqlView);
            this._Database.Views.Add(modelSqlView);
        }

        public void AddProcedure(ModelSqlProcedure modelSqlProcedure) {
            // this._Procedures[modelSqlProcedure.Name] = modelSqlProcedure;
            this._Procedures.Add(modelSqlProcedure);
            this._Database.Procedures.Add(modelSqlProcedure);
        }

        public void AddSynonym(ModelSqlSynonym modelSqlSynonym) {
            // this._Synonyms[modelSqlSynonym.Name] = modelSqlSynonym;
            this._Synonyms.Add(modelSqlSynonym);
            this._Database.Synonyms.Add(modelSqlSynonym);
        }

        public void AddTableType(ModelSqlTableType modelSqlTableType) {
            // this._TableTypes[modelSqlTableType.Name] = modelSqlTableType;
            this._TableTypes.Add(modelSqlTableType);
            this._Database.TableTypes.Add(modelSqlTableType);
        }
        */

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFrozen(); this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Schema); } }

        [JsonProperty]
        public string NameSql { get { return SqlNameJsonConverter.ConvertToValue(this.Name); } set { this.ThrowIfFrozen(); this._Name = SqlNameJsonConverter.ConvertFromValue(value); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            throw new NotImplementedException();
        }

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlType> Types => this._Types;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTable> Tables => this._Tables;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlTableType> TableTypes => this._TableTypes;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlView> Views => this._Views;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlProcedure> Procedures => this._Procedures;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlSchema, SqlName, ModelSqlSynonym> Synonyms => this._Synonyms;


#warning weichei
        ///// <summary>
        ///// Gets the types.
        ///// </summary>
        //public Dictionary<SqlName, ModelSqlType> Types => this._Types;

        ///// <summary>
        ///// Gets the tables.
        ///// </summary>
        ////[JsonProperty]
        //public Dictionary<SqlName, ModelSqlTable> Tables => this._Tables;

        ////[JsonProperty("Tables")]
        //public List<ModelSqlTable> TableList => this._Tables.Values.ToList();

        ///// <summary>
        ///// Gets the tables.
        ///// </summary>
        //public Dictionary<SqlName, ModelSqlTableType> TableTypes => this._TableTypes;

        ///// <summary>
        ///// Gets the views.
        ///// </summary>
        //public Dictionary<SqlName, ModelSqlView> Views => this._Views;

        ///// <summary>
        ///// Gets the procedures.
        ///// </summary>
        //public Dictionary<SqlName, ModelSqlProcedure> Procedures => this._Procedures;

        ///// <summary>
        ///// Gets the Synonyms
        ///// </summary>
        //public Dictionary<SqlName, ModelSqlSynonym> Synonyms => this._Synonyms;

        public static bool operator ==(ModelSqlSchema a, ModelSqlSchema b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlSchema a, ModelSqlSchema b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlSchema other) {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(ModelSqlSchema other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        public override string ToString() => this.Name.ToString();

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Types.Freeze();
                this._Tables.Freeze();
                this._TableTypes.Freeze();
                this._Views.Freeze();
                this._Procedures.Freeze();
                this._Synonyms.Freeze();
            }
            return result;
        }

        public void ResolveNamedReferences(ModelErrors errors) {
#warning  public virtual void ResolveNamedReferences(ModelErrors errors) {
        }
    }
}
