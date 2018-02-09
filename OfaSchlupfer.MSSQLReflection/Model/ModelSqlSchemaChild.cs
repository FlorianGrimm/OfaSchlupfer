namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// a child of a schema.
    /// </summary>
    public class ModelSqlSchemaChild {
        /// <summary>
        /// the name.
        /// </summary>
        protected SqlName _Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchemaChild"/> class.
        /// </summary>
        public ModelSqlSchemaChild() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchemaChild"/> class.
        /// </summary>
        /// <param name="src">the copy source.</param>
        public ModelSqlSchemaChild(ModelSqlSchemaChild src) {
            this._Name = src._Name;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
