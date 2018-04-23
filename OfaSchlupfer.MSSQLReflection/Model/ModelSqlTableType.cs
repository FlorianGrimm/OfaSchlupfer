namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the type of an table like element
    /// </summary>
    public sealed class ModelSqlTableType
        : ModelSqlElementType
        , IEquatable<ModelSqlTableType>
        , IScopeNameResolver
        , IModelSqlObjectWithColumns {
        private readonly List<ModelSqlColumn> _Columns;
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        public ModelSqlTableType() {
            this._Columns = new List<ModelSqlColumn>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        /// <param name="scopeSchema">the scope of the owner - schema</param>
        public ModelSqlTableType(SqlScope scopeSchema) {
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
            this._Schema = schema;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        public ModelSqlTableType(ModelSqlTableType src)
            : base() {
            this.Name = src.Name;
            this.Columns.AddRange(src.Columns);
        }

        /// <summary>
        /// Gets the Columns
        /// </summary>
        public List<ModelSqlColumn> Columns => this._Columns;

        /// <summary>
        /// Add this to the parent
        /// </summary>
        public override void AddToParent() {
            this._Schema.AddTableType(this);
        }

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
            return this.Equals(obj as ModelSqlColumn);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlTableType other) {
            if ((object)other == null) { return false; }
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

        public override ModelSematicScalarType GetScalarType() => null;
    }
}
