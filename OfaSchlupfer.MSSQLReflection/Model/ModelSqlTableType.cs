namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// the type of an table like element
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlTableType
        : ModelSqlElementType
        , IEquatable<ModelSqlTableType>
        , IScopeNameResolver
        , IModelSqlObjectWithColumns {

        public static ModelSqlTableType Ensure(ModelSqlSchema modelSqlSchema, string name) {
            var sqlName = modelSqlSchema.Name.Child(name, ObjectLevel.Object);
            return modelSqlSchema.TableTypes.GetValueOrDefault(sqlName)
                ?? new ModelSqlTableType(modelSqlSchema, name);
        }

        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlColumn> _Columns;


        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlIndex> _Indexes;

        [JsonIgnore]
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        public ModelSqlTableType() {
            this._Columns = new FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlColumn>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Owner = owner
                );
            this._Indexes = new FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlIndex>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Owner = owner
                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        /// <param name="scopeSchema">the scope of the owner - schema</param>
        public ModelSqlTableType(SqlScope scopeSchema) : this() {
            this._Scope = (scopeSchema?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlTableType(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this.Schema = schema;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        public ModelSqlTableType(ModelSqlTableType src)
            : this() {
            this.Name = src.Name;
            this.Columns.AddRange(src.Columns);
        }

        [JsonIgnore]
        public override ModelSqlSchema Schema {
            get => this._Schema;
            set {
                if (this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.TableTypes)) {
                    this.Database = value?.Database;
                }
            }
        }

        [JsonIgnore]
        public override ModelSqlDatabase Database {
            get => this._Database;
            set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.TableTypes);
        }

        /// <summary>
        /// Gets the Columns
        /// </summary>
        public FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlColumn> Columns => this._Columns;

        [JsonIgnore]
        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlColumn> IModelSqlObjectWithColumns.Columns => this._Columns;


        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlTableType, SqlName, ModelSqlIndex> Indexes => this._Indexes;

        [JsonIgnore]
        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlIndex> IModelSqlObjectWithColumns.Indexes => this._Indexes;

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        public static bool operator ==(ModelSqlTableType a, ModelSqlTableType b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlTableType a, ModelSqlTableType b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlTableType other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlTableType other) {
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
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        public override ModelSematicScalarType GetScalarType() => null;
    }
}
