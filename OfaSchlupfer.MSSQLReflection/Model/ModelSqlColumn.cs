﻿#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    /// <summary>
    /// column
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlColumn
        : ModelSqlNamedElement
        , IEquatable<ModelSqlColumn>
        , IScopeNameResolver
        , IModelScalarTypeFacade {
        public static ModelSqlColumn Ensure(IModelSqlObjectWithColumns objectWithColumns, string name) {
            var sqlName = objectWithColumns.Name.Child(name, ObjectLevel.Child);
            return objectWithColumns.Columns.GetValueOrDefault(sqlName)
                ?? new ModelSqlColumn(objectWithColumns, name);
        }

        [JsonIgnore]
        private SqlScope _Scope;

        [JsonIgnore]
        private IModelSqlObjectWithColumns _Owner;

        [JsonIgnore]
        private int? _ColumnId;

        [JsonIgnore]
        private short? _system_type_id;

        [JsonIgnore]
        private int? _user_type_id;

        [JsonIgnore]
        private short? _MaxLength;

        [JsonIgnore]
        private byte? _Precision;

        [JsonIgnore]
        private byte? _Scale;

        [JsonIgnore]
        private string _CollationName;

        [JsonIgnore]
        private bool? _Nullable;

        [JsonIgnore]
        private bool? _FixedLength;

        [JsonIgnore]
        private bool? _Unicode;

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
            this.Owner = owner;
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
            var result = new ModelScalarType {
                Name = scalarType.Name.GetQFullName("[", 2),
                ExternalName = scalarType.GetCondensed(),
                MaxLength = this.MaxLength,
                Scale = this.Scale,
                Precision = this.Precision,
                Nullable = this.Nullable,
                Type = scalarType.GetClrType()
            };
            return result;
        }

        [JsonIgnore]
        public IModelSqlObjectWithColumns Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Columns);
        }


#pragma warning disable SA1107 // Code must not contain multiple statements on one line
#pragma warning disable IDE1006 // Naming Styles

        [JsonProperty]
        public int? ColumnId { get => this._ColumnId; set => this.SetValueProperty(ref this._ColumnId, value); }

        [JsonIgnore]
        public short? system_type_id { get => this._system_type_id; set => this.SetValueProperty(ref this._system_type_id, value); }

        [JsonIgnore]
        public int? user_type_id { get => this._user_type_id; set => this.SetValueProperty(ref this._user_type_id, value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public short? MaxLength { get => this._MaxLength; set => this.SetValueProperty(ref this._MaxLength, value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte? Precision { get => this._Precision; set => this.SetValueProperty(ref this._Precision, value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte? Scale { get => this._Scale; set => this.SetValueProperty(ref this._Scale, value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CollationName { get => this._CollationName; set => this.SetStringProperty(ref this._CollationName, value); }

        [JsonProperty]
        public bool? Nullable { get => this._Nullable; set => this.SetValueProperty(ref this._Nullable, value); }

        /// <summary>
        /// Gets or sets the reference to the SqlType
        /// </summary>
        [JsonProperty(ItemIsReference = false)]
        public ModelSqlType SqlType { get; set; }

#warning TODO SOON
        public IModelScalarTypeFacade ItemType {
            get {
                return null;
            }

            set {
                throw new NotImplementedException();
            }
        }

        [JsonIgnore]
        public bool? Collection {
            get {
                return false;
            }

            set {
                if (value.GetValueOrDefault()) {
                    throw new NotSupportedException();
                }
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? FixedLength { get => this._FixedLength; set => this.SetValueProperty(ref this._FixedLength, value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Unicode { get => this._Unicode; set => this.SetValueProperty(ref this._Unicode, value); }

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
            if (obj is ModelSqlColumn other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlColumn other) {
            if (other is null) { return false; }
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