#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using OfaSchlupfer.Model;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// column
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlColumn
        : ModelSqlNamedElement
        , IEquatable<ModelSqlColumn>
        , IScopeNameResolver
        , IModelScalarTypeFacade {
        [JsonIgnore]
        private SqlScope _Scope;

        [JsonIgnore]
        private IModelSqlObjectWithColumns _Owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlColumn"/> class.
        /// </summary>
        public ModelSqlColumn()
            : this((SqlScope)null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlColumn"/> class.
        /// </summary>
        /// <param name="ownerScope">scope</param>
        public ModelSqlColumn(SqlScope ownerScope) {
            this._Scope = ownerScope;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlColumn"/> class.
        /// </summary>
        /// <param name="owner">the owner</param>
        /// <param name="name">the column name</param>
        public ModelSqlColumn(IModelSqlObjectWithColumns owner, string name)
            : this(owner.GetScope()) {
            this.Name = owner.Name.ChildWellkown(name);
            this._Owner = owner;
        }

        public ModelSqlColumn(ModelSqlColumn src) {
            this.Name = src.Name;
            this.ColumnId = src.ColumnId;
            this.MaxLength = src.MaxLength;
            this.Scale = src.Scale;
            this.Precision = src.Precision;
            this.CollationName = src.CollationName;
            this.Nullable = src.Nullable;
        }

        public ModelScalarType SuggestType(MetaModelBuilder metaModelBuilder) {
            //ModelTypeScalar scalarType = this.Type?.GetScalarType();
            ModelSematicScalarType scalarType = this.SqlType.GetScalarType();
            var result = new ModelScalarType();
            result.Name = scalarType.Name.GetQFullName("[", 2);
            result.ExternalName = scalarType.GetCondensed();
            result.MaxLength = this.MaxLength;
            result.Scale = this.Scale;
            result.Precision = this.Precision;
            result.Nullable = this.Nullable;
            result.Type = scalarType.GetClrType();
            return result;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        [JsonProperty]
        public int ColumnId { get; set; }

        [JsonProperty]
        public short system_type_id { get; set; }

        [JsonProperty]
        public int user_type_id { get; set; }

        [JsonProperty]
        public short MaxLength { get; set; }

        [JsonProperty]
        public byte Precision { get; set; }

        [JsonProperty]
        public byte Scale { get; set; }

        [JsonProperty]
        public string CollationName { get; set; }

        [JsonProperty]
        public bool Nullable { get; set; }

        /// <summary>
        /// Gets or sets the reference to the SqlType
        /// </summary>
#warning [JsonIgnore]
        [JsonIgnore]
        public ModelSqlType SqlType { get; set; }

        public IModelScalarTypeFacade ItemType {
            get {
                return null;
            }

            set {
                throw new NotImplementedException();
            }
        }

        [JsonIgnore]
        public bool Collection {
            get {
                return false;
            }

            set {
                if (value) {
                    throw new NotSupportedException();
                }
            }
        }

        [JsonProperty]
        public bool FixedLength { get; set; }

        [JsonProperty]
        public bool Unicode { get; set; }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            return null;
        }

        /// <summary>
        /// Add this to its parent.
        /// </summary>
        /// <returns>this</returns>
        public ModelSqlColumn AddToParent() {
            this._Owner.AddColumn(this);
            return this;
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        public static bool operator ==(ModelSqlColumn a, ModelSqlColumn b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlColumn a, ModelSqlColumn b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return this.Equals(obj as ModelSqlColumn);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlColumn other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                && (this.ColumnId == other.ColumnId)
                && (this.MaxLength == other.MaxLength)
                && (this.Precision == other.Precision)
                && (this.Scale == other.Scale)
                && (this.CollationName == other.CollationName)
                && (this.Nullable == other.Nullable)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}