namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// a sql table
    /// </summary>
    public sealed class ModelSqlTable
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlTable>
        , IBuildTarget<ModelSqlTable, ModelSqlTable.Builder> {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        public ModelSqlTable() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTable"/> class.
        /// </summary>
        /// <param name="src">Copy source</param>
        /// <param name="columns">alternatic columns</param>
        public ModelSqlTable(ModelSqlTable src, ModelDictionary<SqlName, ModelSqlColumn> columns)
            : base(src, columns) {
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

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setTarget">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlTable> setTarget, Action<ModelSqlTable> setFrozen)
            => new Builder(this, clone, setTarget, setFrozen);

        /// <inheritdoc/>
        protected override void FreezeChildren() {
            base.FreezeChildren();
            foreach (var column in this.Columns.GetValues()) {
                column?.Freeze();
            }
        }

        /// <summary>
        /// Create a unfrozen instance
        /// </summary>
        /// <returns>a new instacne</returns>
        protected override IBuildTarget UnFreezeCreateInstance() {
            return new ModelSqlTable(this, null);
        }

        /// <summary>
        /// Builder
        /// </summary>
        public sealed class Builder : ModelSqlObjectWithColumnsBuilder<ModelSqlTable> {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            internal Builder(ModelSqlTable target, bool clone, Action<ModelSqlTable> setUnFrozen, Action<ModelSqlTable> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }
        }
    }
}
