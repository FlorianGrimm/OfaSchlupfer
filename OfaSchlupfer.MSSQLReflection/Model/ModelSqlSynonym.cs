namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// a sql alias
    /// </summary>
    public class ModelSqlSynonym
        : IEquatable<ModelSqlSynonym> {
        private SqlName _Name;
        private SqlName _For;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSynonym"/> class.
        /// </summary>
        public ModelSqlSynonym() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSynonym"/> class.
        /// Copy constructor
        /// </summary>
        /// <param name="src">instance to copy.</param>
        public ModelSqlSynonym(ModelSqlSynonym src) {
            this._Name = src._Name;
            this._For = src._For;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public SqlName For { get { return this._For; } set { this._For = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// a equals b
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equals.</returns>
        public static bool operator ==(ModelSqlSynonym a, ModelSqlSynonym b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// not equals.
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if not equals.</returns>
        public static bool operator !=(ModelSqlSynonym a, ModelSqlSynonym b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return base.Equals(obj as ModelSqlSynonym);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlSynonym other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            ((object)null).ToString();
            return (this.Name == other.Name)
                && (this.For == other.For)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}