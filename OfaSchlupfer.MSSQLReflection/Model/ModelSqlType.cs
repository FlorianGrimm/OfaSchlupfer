#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    /// <summary>
    /// ModelSqlType
    /// </summary>
    public sealed class ModelSqlType
        : ModelSqlElementType
        , IEquatable<ModelSqlType> {
        private short _MaxLength;
        private byte _Precision;
        private byte _Scale;
        private string _CollationName;
        private bool _IsNullable;

        public ModelSqlType() { }

        public ModelSqlType(ModelSqlType src) {
            this.Name = src.Name;
            this.MaxLength = src.MaxLength;
            this.Precision = src.Precision;
            this.Scale = src.Scale;
            this.Precision = src.Precision;
            this.CollationName = src.CollationName;
            this.IsNullable = src.IsNullable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlType"/> class.
        /// </summary>
        /// <param name="schema">the owner schema</param>
        /// <param name="name">the name</param>
        public ModelSqlType(ModelSqlSchema schema, string name) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this._Schema = schema;
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
        public short MaxLength { get { return this._MaxLength; } set { this._MaxLength = value; } }

        /// <summary>
        /// Gets or sets the Precision of float types.
        /// </summary>
        public byte Precision { get { return this._Precision; } set { this._Precision = value; } }

        /// <summary>
        /// Gets or sets the Scale of float types..
        /// </summary>
        public byte Scale { get { return this._Scale; } set { this._Scale = value; } }

        /// <summary>
        /// Gets or sets the collation of the type - can be null.
        /// </summary>
        public string CollationName { get { return this._CollationName; } set { this._CollationName = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the type is null-able.
        /// </summary>
        public bool IsNullable { get { return this._IsNullable; } set { this._IsNullable = value; } }

        public ModelSqlType BaseOnType { get; set; }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Add this to the parent
        /// </summary>
        public override void AddToParent() {
            this._Schema.AddType(this);
        }

        private ModelTypeScalar _ScalarType;

        /// <summary>
        /// Get the scalar type.
        /// </summary>
        /// <returns>The scalartype or null</returns>
        public ModelTypeScalar GetScalarType() {
            return this._ScalarType ?? (this._ScalarType = new ModelTypeScalar() {
                Name = this.Name,
                MaxLength = this.MaxLength,
                Precision = this.Precision,
                Scale = this.Scale,
                CollationName = this.CollationName,
                IsNullable = this.IsNullable
            });
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
            return base.Equals(obj as ModelSqlType);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlType other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            ((object)null).ToString();
            return (this.Name == other.Name)
                && (this.MaxLength == other.MaxLength)
                && (this.Precision == other.Precision)
                && (this.Scale == other.Scale)
                && (this.CollationName == other.CollationName)
                && (this.IsNullable == other.IsNullable)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}