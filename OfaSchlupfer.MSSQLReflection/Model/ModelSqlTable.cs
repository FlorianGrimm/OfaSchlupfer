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
        private ModelSqlSchema _Schema;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        public ModelSqlTable() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="ownerScope">the scope of the owner - schema</param>
        public ModelSqlTable(SqlScope ownerScope) {
            this._Scope = (ownerScope?.CreateChildScope()) ?? (SqlScope.Root.CreateChildScope(this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlTable(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name);
            this._Schema = schema;
        }

        /// <summary>
        /// Add this to the parent
        /// </summary>
        /// <returns>this</returns>
        public ModelSqlTable AddToParent() {
            this._Schema.AddTable(this);
            return this;
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
        public override SqlScope GetScope() {
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
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="level">the level to find the item at.</param>
        /// <returns>the named object or null.</returns>
        public override object ResolveObject(SqlName name, ObjectLevel level) {
            var result = base.ResolveObject(name, level);
            if ((object)result != null) { return result; }

            return null;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
