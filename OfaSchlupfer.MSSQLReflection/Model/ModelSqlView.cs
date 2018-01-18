namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// a sql view
    /// </summary>
    public sealed class ModelSqlView
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlView> {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlView"/> class.
        /// </summary>
        public ModelSqlView() {
        }

        public static bool operator ==(ModelSqlView a, ModelSqlView b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlView a, ModelSqlView b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return this.Equals(obj as ModelSqlColumn);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlView other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
