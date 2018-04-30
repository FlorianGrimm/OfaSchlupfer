namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// anything that owns columns
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class ModelSqlObjectWithColumns
        : ModelSqlSchemaChild
        , IScopeNameResolver
        , IModelSqlObjectWithColumns {
        /// <summary>
        /// the columns
        /// </summary>
        [JsonIgnore]
        protected FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn> _Columns;

        [JsonIgnore]
        protected FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlIndex> _Indexes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        public ModelSqlObjectWithColumns() {
            this._Columns = new FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Owner = owner
                );
            this._Indexes = new FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlIndex>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Owner = owner
                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        /// <param name="src">the source instance.</param>
        public ModelSqlObjectWithColumns(ModelSqlObjectWithColumns src)
            : this() {
            if ((object)src != null) {
                this.Name = src.Name;
                this._Columns.AddRange(src.Columns);
            }
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public virtual SqlScope GetScope() => null;

        /// <summary>
        /// Gets the columns
        /// </summary>
        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn> Columns => this._Columns;

        [JsonIgnore]
        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlColumn> IModelSqlObjectWithColumns.Columns => this._Columns;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlIndex> Indexes => this._Indexes;

        [JsonIgnore]
        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlIndex> IModelSqlObjectWithColumns.Indexes => this._Indexes;

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public virtual object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            for (int idx = 0; idx < this.Columns.Count; idx++) {
                var column = this.Columns[idx];
                if (column.Name.Equals(name)) {
                    return column;
                }
            }
            return null;
        }
    }
}