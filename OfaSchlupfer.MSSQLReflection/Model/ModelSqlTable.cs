namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// a sql table
    /// </summary>
    public sealed class ModelSqlTable
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlTable>
        , IScopeNameResolver {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        public ModelSqlTable() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        public ModelSqlTable(ModelSqlTable src)
            : base(src) {
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
