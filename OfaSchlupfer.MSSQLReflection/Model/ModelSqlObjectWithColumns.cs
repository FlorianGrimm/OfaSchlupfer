namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// anything that owns columns
    /// </summary>
    public abstract class ModelSqlObjectWithColumns {
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

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
        /// <summary>
        /// Gets or sets the object name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets the columns
        /// </summary>
        public Dictionary<SqlName, ModelSqlColumn> Columns => this._Columns;

        /// <summary>
        /// Get the column by name
        /// </summary>
        /// <param name="name">the name to find</param>
        /// <returns>the column or null.</returns>
        public ModelSqlColumn GetColumnByName(SqlName name) => this._Columns.GetValueOrDefault(name);
    }
}