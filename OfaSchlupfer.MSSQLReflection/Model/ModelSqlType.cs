#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    /// <summary>
    /// ModelSqlType
    /// </summary>
    [JsonObject(IsReference = false)]
    public sealed class ModelSqlType
        : ModelSqlElementType
        , IEquatable<ModelSqlType>
        , OfaSchlupfer.Model.IModelScalarTypeFacade {
        public static ModelSqlType Ensure(ModelSqlSchema modelSqlSchema, string name) {
            var sqlName = modelSqlSchema.Name.Child(name, ObjectLevel.Object);
            return modelSqlSchema.Types.GetValueOrDefault(sqlName)
                ?? new ModelSqlType(modelSqlSchema, name);
        }

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
        private ModelSqlType _BaseOnType;

        [JsonIgnore]
        private ModelSematicScalarType _ScalarType;

        [JsonIgnore]
        private bool? _FixedLength;

        [JsonIgnore]
        private bool? _Unicode;

        public ModelSqlType() { }

        public ModelSqlType(ModelSqlType src) {
            this.Name = src.Name;
            this.MaxLength = src.MaxLength;
            this.Precision = src.Precision;
            this.Scale = src.Scale;
            this.Precision = src.Precision;
            this.CollationName = src.CollationName;
            this.Nullable = src.Nullable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlType"/> class.
        /// </summary>
        /// <param name="schema">the owner schema</param>
        /// <param name="name">the name</param>
        public ModelSqlType(ModelSqlSchema schema, string name) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this.Schema = schema;
        }

        [JsonIgnore]
        public override ModelSqlSchema Schema {
            get => this._Schema;
            set {
                if (this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.Types)) {
                    this.Database = value?.Database;
                }
            }
        }

        [JsonIgnore]
        public override ModelSqlDatabase Database {
            get => this._Database;
            set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.Types);
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

#if thinkof
        private int _ColumnId;
        /// <summary>
        /// Gets or sets the ColumnId hte order.
        /// </summary>
        public int ColumnId { get { return this._ColumnId; } set { this._ColumnId = value; } }
#endif

        /// <summary>
        /// Gets or sets the MaxLength of char types.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public short? MaxLength { get { return this._MaxLength; } set { this.SetValueProperty(ref this._MaxLength, value); } }

        /// <summary>
        /// Gets or sets the Precision of float types.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte? Precision { get { return this._Precision; } set { this.SetValueProperty(ref this._Precision, value); } }

        /// <summary>
        /// Gets or sets the Scale of float types..
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte? Scale { get { return this._Scale; } set { this.SetValueProperty(ref this._Scale, value); } }

        /// <summary>
        /// Gets or sets the collation of the type - can be null.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CollationName { get { return this._CollationName; } set { this.SetStringProperty(ref this._CollationName, value); } }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the type is null-able.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Nullable { get { return this._Nullable; } set { this.SetValueProperty(ref this._Nullable, value); } }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, IsReference = true)]
        public ModelSqlType BaseOnType { get { return this._BaseOnType; } set { this.SetRefProperty(ref this._BaseOnType, value); } }

#warning thinkof
        [JsonProperty]
        public ModelSematicScalarType ScalarType {
            get { return this._ScalarType; }
            set { this.SetRefProperty(ref this._ScalarType, value); }
        }

        public IModelScalarTypeFacade ItemType {
            get {
                return null;
            }

            set {
                throw new NotImplementedException();
            }
        }

        public bool? Collection {
            get {
                return null;
            }

            set {
                throw new NotImplementedException();
            }
        }

        public bool? FixedLength { get { return this._FixedLength; } set { this.SetValueProperty(ref this._FixedLength, value); } }

        public bool? Unicode { get { return this._Unicode; } set { this.SetValueProperty(ref this._Unicode, value); } }
        
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

#if weichei
        /// <summary>
        /// Add this to the parent
        /// </summary>
        public override void AddToParent() {
            this._Schema.AddType(this);
        }
#endif

        /// <summary>
        /// Get the scalar type.
        /// </summary>
        /// <returns>The scalartype or null</returns>
        public override ModelSematicScalarType GetScalarType() {
#warning TODO respect BaseOnType
            if (!(this._ScalarType is null)) {
                return this._ScalarType;
            }
            var modelType = ModelSematicType.Create(this);
            if (modelType is ModelSematicScalarType modelTypeScalar) {
                if (this.IsFrozen()) {
                    this._ScalarType = modelTypeScalar;
                }
                return modelTypeScalar;
            }
#warning TODO doublicate value handling
            var result= new ModelSematicScalarType() {
                Name = this.Name,
                SystemDataType = this.GetSystemDataType(),
                MaxLength = this.MaxLength,
                Precision = this.Precision,
                Scale = this.Scale,
                CollationName = this.CollationName,
                IsNullable = this.Nullable
            };
            if (this.IsFrozen()) {
                this._ScalarType = result;
            }
            return result;
        }

        /// <summary>
        /// a equals b
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equals.</returns>
        public static bool operator ==(ModelSqlType a, ModelSqlType b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// not equals.
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if not equals.</returns>
        public static bool operator !=(ModelSqlType a, ModelSqlType b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlType other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlType other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
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


        private ModelSystemDataType GetSystemDataType() {
            return ModelSystemDataTypeUtility.ConvertFromSqlName(this.Name);
        }
    }
}