namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// a sql alias
    /// </summary>
    public class ModelSqlSynonym
        : ModelSqlSchemaChild
        , IEquatable<ModelSqlSynonym>
        , IScopeNameResolver {
        public static ModelSqlSynonym Ensure(ModelSqlSchema modelSqlSchema, string name) {
            var sqlName = modelSqlSchema.Name.Child(name, ObjectLevel.Schema);
            return modelSqlSchema.Synonyms.GetValueOrDefault(sqlName)
                ?? new ModelSqlSynonym(modelSqlSchema, name);
        }

        private SqlName _For;
        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSynonym"/> class.
        /// </summary>
        public ModelSqlSynonym() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSynonym"/> class.
        /// </summary>
        /// <param name="scopeSchema">the database scope</param>
        public ModelSqlSynonym(SqlScope scopeSchema) {
            this._Scope = (scopeSchema?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSynonym"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlSynonym(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this.Schema = schema;
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

        [JsonIgnore]
        public override ModelSqlSchema Schema {
            get => this._Schema;
            set {
                if (this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.Synonyms)) {
                    this.Database = value?.Database;
                }
            }
        }

        [JsonIgnore]
        public override ModelSqlDatabase Database {
            get => this._Database;
            set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.Synonyms);
        }

#if weichei
        /// <summary>
        /// Add this to the parent
        /// </summary>
        public override void AddToParent() {
            this._Schema.AddSynonym(this);
        }
#endif

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

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
            if (obj is ModelSqlSynonym other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlSynonym other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                && (this.For == other.For)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            // TODO: ResolveObject
            throw new NotImplementedException();
        }
    }
}