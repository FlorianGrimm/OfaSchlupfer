using Newtonsoft.Json;
using OfaSchlupfer.Freezable;

namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// a child of a schema.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class ModelSqlSchemaChild
        : FreezeableObject {
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

        [JsonIgnore]
        protected ModelSqlDatabase _Database;

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

        [JsonIgnore]
        public virtual ModelSqlSchema Schema {
            get => this._Schema;
            set => this._Schema = value;
        }

        [JsonIgnore]
        public virtual ModelSqlDatabase Database {
            get => this._Database;
            set => this._Database = value;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFrozen(); this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Object); } }

        [JsonIgnore]
        public string QName { get => this.Name.GetQFullName("[", 2); }

        [JsonProperty]
        public string NameSql { get { return SqlNameJsonConverter.ConvertToValue(this.Name); } set { this.ThrowIfFrozen(); this._Name = SqlNameJsonConverter.ConvertFromValue(value); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

#if weichei
        /// <summary>
        /// Add this to the parent
        /// </summary>
        public abstract void AddToParent();
#endif
        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
