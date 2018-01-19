#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// ModelSqlProcedure
    /// </summary>
    public sealed class ModelSqlProcedure
        : IEquatable<ModelSqlProcedure> {
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
    }
}
