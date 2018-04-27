namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// a sql table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn
        //ItemConverterType = typeof(ModelSqlTableJsonConverter)
        )]
    public sealed class ModelSqlTable
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlTable>
        , IScopeNameResolver {
        public static ModelSqlTable Ensure(ModelSqlSchema modelSqlSchema, string name) {
            var sqlName = modelSqlSchema.Name.Child(name, ObjectLevel.Object);
            return modelSqlSchema.Tables.GetValueOrDefault(sqlName)
                ?? new ModelSqlTable(modelSqlSchema, name);
        }

        public static ModelSqlTable Ensure(ModelSqlDatabase database, SqlName name) {
            var schema = ModelSqlSchema.Ensure(database, name.Parent?.Name ?? "dbo");
            return Ensure(schema, name.Name);
        }

        [JsonIgnore]
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        public ModelSqlTable() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="scopeSchema">the scope of the owner - schema</param>
        public ModelSqlTable(SqlScope scopeSchema) {
            this._Scope = (scopeSchema?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlTable(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this.Schema = schema;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        public ModelSqlTable(ModelSqlTable src)
            : base(src) { }

        [JsonIgnore]
        public override ModelSqlSchema Schema {
            get => this._Schema;
            set {
                if (this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.Tables)) {
                    this.Database = value?.Database;
                }
            }
        }

        [JsonIgnore]
        public override ModelSqlDatabase Database {
            get => this._Database;
            set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.Tables);
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public override SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        public static bool operator ==(ModelSqlTable a, ModelSqlTable b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlTable a, ModelSqlTable b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlTable other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlTable other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }
        
        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public override object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            var result = base.ResolveObject(name, context);
            if ((object)result != null) { return result; }

            return null;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
