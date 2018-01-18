#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// ModelSqlProcedure
    /// </summary>
    public sealed class ModelSqlProcedure
        : BuildTargetBase
        , IEquatable<ModelSqlProcedure>
        , IBuildTarget<ModelSqlProcedure, ModelSqlProcedure.Builder> {
        private SqlName _Name;

        private string _Definition;

        public ModelSqlProcedure() {
            this._Definition = string.Empty;
        }

        public ModelSqlProcedure(ModelSqlProcedure src) {
            this._Name = src._Name;
            this._Definition = src._Definition;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = value; } }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public string Definition { get { return this._Definition; } set { this._Definition = value ?? string.Empty; } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// a equals b
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equals.</returns>
        public static bool operator ==(ModelSqlProcedure a, ModelSqlProcedure b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// not equals.
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if not equals.</returns>
        public static bool operator !=(ModelSqlProcedure a, ModelSqlProcedure b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return base.Equals(obj as ModelSqlProcedure);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlProcedure other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            ((object)null).ToString();
            return (this.Name == other.Name)
                && (string.Equals(this.Definition, other.Definition, StringComparison.Ordinal))
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
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlProcedure> setUnFrozen, Action<ModelSqlProcedure> setFrozen)
            => new Builder(this, clone, setUnFrozen, setFrozen);

        /// <summary>
        /// Builder
        /// </summary>
        public sealed class Builder : BuilderBase<ModelSqlProcedure> {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            internal Builder(ModelSqlProcedure target, bool clone, Action<ModelSqlProcedure> setUnFrozen, Action<ModelSqlProcedure> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

            public SqlName Name { get { return this._Target._Name; } set { if (this._Target._Name == value) { return; } this.EnsureUnfrozen()._Name = value; } }

            public string Definition { get { return this._Target._Definition; } set { if (string.Equals(this._Target._Definition, value ?? string.Empty, StringComparison.Ordinal)) { return; } this.EnsureUnfrozen()._Definition = value ?? string.Empty; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line
        }
    }
}
