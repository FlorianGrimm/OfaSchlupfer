using Newtonsoft.Json;

namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// a child of a schema.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class ModelSqlSchemaChild {
        /// <summary>
        /// the name.
        /// </summary>
        [JsonIgnore]
        protected SqlName _Name;

        /// <summary>
        /// the owning schema
        /// </summary>
        [JsonIgnore]
        protected ModelSqlSchema _Schema;

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
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

        [JsonProperty]
        public string NameSql { get { return SqlNameJsonConverter.ConvertToValue(this.Name); } set { this._Name = SqlNameJsonConverter.ConvertFromValue(value); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Add this to the parent
        /// </summary>
        public abstract void AddToParent();

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
