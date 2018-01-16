namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// anything that owns columns
    /// </summary>
    public abstract class ModelSqlObjectWithColumns : BuildTargetBase {
        private SqlName _Name;

        /// <summary>
        /// the columns
        /// </summary>
        protected ModelDictionary<SqlName, ModelSqlColumn> _Columns;

        /// <summary>
        /// the analysis codetype
        /// </summary>
        internal OfaSchlupfer.MSSQLReflection.SqlCode.ISqlCodeType SqlCodeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        public ModelSqlObjectWithColumns() {
            this._Columns = new ModelDictionary<SqlName, ModelSqlColumn>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumns"/> class.
        /// </summary>
        /// <param name="src">the source instance</param>
        /// <param name="columns">the new columns - can be null</param>
        public ModelSqlObjectWithColumns(ModelSqlObjectWithColumns src, ModelDictionary<SqlName, ModelSqlColumn> columns) {
            this.Name = src.Name;
            this._Columns = ModelDictionary<SqlName, ModelSqlColumn>.FactoryCopy(this, columns, src._Columns);
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
        /// <summary>
        /// Gets or sets the object name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets the columns
        /// </summary>
        public ModelDictionary<SqlName, ModelSqlColumn> Columns => this._Columns;

        /// <summary>
        /// Get the column by name
        /// </summary>
        /// <param name="name">the name to find</param>
        /// <returns>the column or null.</returns>
        public ModelSqlColumn GetColumnByName(SqlName name) {
            return this._Columns.GetByName(name);
        }

        /// <summary>
        /// builder base
        /// </summary>
        /// <typeparam name="TModel">The final model.</typeparam>
        public abstract class ModelSqlObjectWithColumnsBuilder<TModel>
            : BuilderBase<TModel>
            where TModel : ModelSqlObjectWithColumns {
            /// <summary>
            /// Initializes a new instance of the <see cref="ModelSqlObjectWithColumnsBuilder{TModel}"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            protected ModelSqlObjectWithColumnsBuilder(TModel target, bool clone, Action<TModel> setUnFrozen, Action<TModel> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

            /// <summary>
            /// Gets or sets the columns
            /// </summary>
            public ModelDictionary<SqlName, ModelSqlColumn> Columns {
                get {
                    return this._Target._Columns;
                }

                set {
                    if (ReferenceEquals(this._Target._Columns, value)) { return; }
                    this.EnsureUnfrozen()._Columns = value;
                }
            }
        }
    }
}