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
        protected FreezeableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn> _Columns;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        public ModelSqlObjectWithColumns() {
            this._Columns = new FreezeableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn>(
                this,
                (item)=>item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Owner=owner
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
        public FreezeableOwnedKeyedCollection<ModelSqlObjectWithColumns, SqlName, ModelSqlColumn> Columns => this._Columns;

        [JsonIgnore]
        IList<ModelSqlColumn> IModelSqlObjectWithColumns.Columns => this._Columns;

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

        /// <summary>
        /// Add the column
        /// </summary>
        /// <param name="modelSqlColumn">the column to add</param>
        public void AddColumn(ModelSqlColumn modelSqlColumn) {
            if (modelSqlColumn != null) {
                this.Columns.Add(modelSqlColumn);
            }
        }

        /// <summary>
        /// Get the column by name
        /// </summary>
        /// <param name="name">the name to find</param>
        /// <returns>the column or null.</returns>
        public ModelSqlColumn GetColumnByName(SqlName name) {
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