namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// the database
    /// </summary>
    public sealed class ModelSqlDatabase : BuildTargetBase {
        private ModelDictionary<SqlName, ModelSqlSchema> _Schemas;
        private ModelDictionary<SqlName, ModelSqlType> _Types;
        private ModelDictionary<SqlName, ModelSqlTable> _Tables;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        public ModelSqlDatabase() {
            this._Schemas = new ModelDictionary<SqlName, ModelSqlSchema>();
            this._Types = new ModelDictionary<SqlName, ModelSqlType>();
            this._Tables = new ModelDictionary<SqlName, ModelSqlTable>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlDatabase"/> class.
        /// </summary>
        /// <param name="src">the source - cannot be null.</param>
        /// <param name="schemas">new schemas - can be null.</param>
        /// <param name="types">new types - can be null.</param>
        /// <param name="tables">new tables - can be null.</param>
        public ModelSqlDatabase(
            ModelSqlDatabase src,
            ModelDictionary<SqlName, ModelSqlSchema> schemas,
            ModelDictionary<SqlName, ModelSqlType> types,
            ModelDictionary<SqlName, ModelSqlTable> tables) {
            this._Schemas = ModelDictionary<SqlName, ModelSqlSchema>.FactoryCopy(schemas, src._Schemas);
            this._Types = ModelDictionary<SqlName, ModelSqlType>.FactoryCopy(types, src._Types);
            this._Tables = ModelDictionary<SqlName, ModelSqlTable>.FactoryCopy(tables, src._Tables);
        }

        /// <summary>
        /// Gets the schemas.
        /// </summary>
        public ModelDictionary<SqlName, ModelSqlSchema> Schemas => this._Schemas;

        /// <summary>
        /// Gets the types.
        /// </summary>
        public ModelDictionary<SqlName, ModelSqlType> Types => this._Types;

        /// <summary>
        /// Gets the tables.
        /// </summary>
        public ModelDictionary<SqlName, ModelSqlTable> Tables => this._Tables;

        /// <summary>
        /// Gets the schemas.
        /// </summary>
        /// <returns>the schemas.</returns>
        public ModelSqlSchema[] GetSchemas() => this._Schemas?.GetValues();

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns>the types</returns>
        public ModelSqlType[] GetTypes() => this._Types?.GetValues();

        /// <summary>
        /// Get the sql tables.
        /// </summary>
        /// <returns>the sql tables</returns>
        public ModelSqlTable[] GetTables() => this._Tables?.GetValues();

        /// <summary>
        /// Gets the schema by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlSchema GetSchemaByName(SqlName name) => this._Schemas?.GetByName(name);

        /// <summary>
        /// Gets the type by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlType GetTypeByName(SqlName name) => this._Types?.GetByName(name);

        /// <summary>
        /// Gets the table by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlTable GetTableByName(SqlName name) => this._Tables?.GetByName(name);

        /// <summary>
        /// Gets the named object called name.
        /// </summary>
        /// <param name="name">the name to serach for</param>
        /// <returns>the found object or null.</returns>
        public object GetObject(SqlName name) {
            object result;

            result = this._Types?.GetByName(name);
            if ((object)result != null) { return result; }

            result = this._Tables?.GetByName(name);
            if ((object)result != null) { return result; }

            return null;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="sqlName">the name to search for</param>
        /// <returns>the named object or null.</returns>
        public object Resolve(SqlName sqlName) {
            return this.GetObject(sqlName);
        }

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlDatabase> setUnFrozen, Action<ModelSqlDatabase> setFrozen)
            => new Builder(this, clone, setUnFrozen, setFrozen);

        /// <summary>
        /// Freeze the children of this.
        /// </summary>
        protected override void FreezeChildren() {
            base.FreezeChildren();
            this.Schemas.Freeze();
            this.Types.Freeze();
            this.Tables.Freeze();
        }

        /// <summary>
        /// Create a unfrozen instance
        /// </summary>
        /// <returns>a new instacne</returns>
        protected override IBuildTarget UnFreezeCreateInstance() {
            return new ModelSqlDatabase(this, null, null, null);
        }

        /// <summary>
        /// Builder
        /// </summary>
        public sealed class Builder : BuilderBase<ModelSqlDatabase> {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            internal Builder(ModelSqlDatabase target, bool clone, Action<ModelSqlDatabase> setUnFrozen, Action<ModelSqlDatabase> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

            /// <summary>
            /// Gets or sets the schemas
            /// </summary>
            public ModelDictionary<SqlName, ModelSqlSchema> Schemas {
                get {
                    return this._Target.Schemas;
                }

                set {
                    if (ReferenceEquals(this._Target.Schemas, value)) { return; }
                    this.EnsureUnfrozen()._Schemas = value;
                }
            }

            /// <summary>
            /// Gets or sets the types.
            /// </summary>
            public ModelDictionary<SqlName, ModelSqlType> Types {
                get {
                    return this._Target.Types;
                }

                set {
                    if (ReferenceEquals(this._Target.Types, value)) { return; }
                    this.EnsureUnfrozen()._Types = value;
                }
            }

            /// <summary>
            /// Gets or sets the tables.
            /// </summary>
            public ModelDictionary<SqlName, ModelSqlTable> Tables {
                get {
                    return this._Target.Tables;
                }

                set {
                    if (ReferenceEquals(this._Target.Tables, value)) { return; }
                    this.EnsureUnfrozen()._Tables = value;
                }
            }
        }
    }
}
