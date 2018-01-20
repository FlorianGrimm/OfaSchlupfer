namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// a sql table
    /// </summary>
    public sealed class ModelSqlTable
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlTable>
        , IScopeNameResolver {
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        public ModelSqlTable() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="scopeDatbase">the database scope</param>
        public ModelSqlTable(SqlScope scopeDatbase) {
            this._Scope = (scopeDatbase?.CreateChildScope()) ?? (SqlScope.Root.CreateChildScope(this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        public ModelSqlTable(ModelSqlTable src)
            : base(src) {
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = SqlScope.Root.CreateChildScope(this));
        }

        public static bool operator ==(ModelSqlTable a, ModelSqlTable b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlTable a, ModelSqlTable b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return this.Equals(obj as ModelSqlColumn);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlTable other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        /// <summary>
        /// Resolve a column.
        /// </summary>
        /// <param name="name">name to find</param>
        /// <returns>the column or null</returns>
        public override object Resolve(SqlName name) {
            var result = base.Resolve(name);
            if ((object)result != null) { return result; }

            return null;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
