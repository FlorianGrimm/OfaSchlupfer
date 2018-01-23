namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// anything that owns columns
    /// </summary>
    public abstract class ModelSqlObjectWithColumns
        : IScopeNameResolver {
        private SqlName _Name;

        /// <summary>
        /// the columns
        /// </summary>
        protected Dictionary<SqlName, ModelSqlColumn> _Columns;

        /// <summary>
        /// the analysis codetype
        /// </summary>
        internal OfaSchlupfer.MSSQLReflection.SqlCode.ISqlCodeType SqlCodeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        public ModelSqlObjectWithColumns() {
            this._Columns = new Dictionary<SqlName, ModelSqlColumn>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        /// <param name="src">the source instance.</param>
        public ModelSqlObjectWithColumns(ModelSqlObjectWithColumns src)
            : this() {
            if ((object)src != null) {
                this.Name = src.Name;
                foreach (var kv in src._Columns) {
                    this._Columns[kv.Key] = kv.Value;
                }
            }
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
        /// <summary>
        /// Gets or sets the object name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public virtual SqlScope GetScope() => null;

        /// <summary>
        /// Gets the columns
        /// </summary>
        public Dictionary<SqlName, ModelSqlColumn> Columns => this._Columns;

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public virtual object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            return this.Columns.GetValueOrDefault(name);
        }

        /// <summary>
        /// Add the column
        /// </summary>
        /// <param name="modelSqlColumn">the column to add</param>
        public void AddColumn(ModelSqlColumn modelSqlColumn) {
            this.Columns[modelSqlColumn.Name] = modelSqlColumn;
        }

        /// <summary>
        /// Get the column by name
        /// </summary>
        /// <param name="name">the name to find</param>
        /// <returns>the column or null.</returns>
        public ModelSqlColumn GetColumnByName(SqlName name) => this._Columns.GetValueOrDefault(name);
    }
}