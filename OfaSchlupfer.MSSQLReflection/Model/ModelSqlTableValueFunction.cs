#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// ModelSqlTableValueFunction
    /// </summary>
    public sealed class ModelSqlTableValueFunction
        : ModelSqlSchemaChild
        , IEquatable<ModelSqlTableValueFunction> {
        private string _Definition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableValueFunction"/> class.
        /// </summary>
        public ModelSqlTableValueFunction() {
            this._Definition = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableValueFunction"/> class.
        /// Copy contructor.
        /// </summary>
        /// <param name="src">instance to copy.</param>
        public ModelSqlTableValueFunction(ModelSqlTableValueFunction src) {
            this._Name = src._Name;
            this._Definition = src._Definition;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public string Definition { get { return this._Definition; } set { this._Definition = value ?? string.Empty; } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

#if weichei
        public override void AddToParent() {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// a equals b
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equals.</returns>
        public static bool operator ==(ModelSqlTableValueFunction a, ModelSqlTableValueFunction b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// not equals.
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if not equals.</returns>
        public static bool operator !=(ModelSqlTableValueFunction a, ModelSqlTableValueFunction b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlTableValueFunction other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlTableValueFunction other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                && (string.Equals(this.Definition, other.Definition, StringComparison.Ordinal))
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();
    }
}
