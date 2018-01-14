#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// ModelSqlType
    /// </summary>
    public sealed class ModelSqlType : BuildTargetBase, IEquatable<ModelSqlType> {
        private SqlName _Name;
        private int _ColumnId;

        private short _MaxLength;
        private byte _Precision;
        private byte _Scale;
        private string _CollationName;
        private bool _IsNullable;
        internal OfaSchlupfer.MSSQLReflection.SqlCode.ISqlCodeType SqlCodeType;

        public ModelSqlType() {
        }

        public ModelSqlType(ModelSqlType src) {
            this.Name = src.Name;
            this.MaxLength = src.MaxLength;
            this.Precision = src.Precision;
            this.Scale = src.Scale;
            this.Precision = src.Precision;
            this.CollationName = src.CollationName;
            this.IsNullable = src.IsNullable;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }

        /// <summary>
        /// Gets or sets the ColumnId hte order.
        /// </summary>
        public int ColumnId { get { return this._ColumnId; } set { this.ThrowIfFozen(); this._ColumnId = value; } }

        /// <summary>
        /// Gets or sets the MaxLength of char types.
        /// </summary>
        public short MaxLength { get { return this._MaxLength; } set { this.ThrowIfFozen(); this._MaxLength = value; } }

        /// <summary>
        /// Gets or sets the Precision of float types.
        /// </summary>
        public byte Precision { get { return this._Precision; } set { this.ThrowIfFozen(); this._Precision = value; } }

        /// <summary>
        /// Gets or sets the Scale of float types..
        /// </summary>
        public byte Scale { get { return this._Scale; } set { this.ThrowIfFozen(); this._Scale = value; } }

        /// <summary>
        /// Gets or sets the collation of the type - can be null.
        /// </summary>
        public string CollationName { get { return this._CollationName; } set { this.ThrowIfFozen(); this._CollationName = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the type is null-able.
        /// </summary>
        public bool IsNullable { get { return this._IsNullable; } set { this.ThrowIfFozen(); this._IsNullable = value; } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

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

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlType> setUnFrozen, Action<ModelSqlType> setFrozen)
            => new Builder(this, clone, setUnFrozen, setFrozen);

        /// <summary>
        /// Builder
        /// </summary>
        public sealed class Builder : BuilderBase<ModelSqlType> {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            internal Builder(ModelSqlType target, bool clone, Action<ModelSqlType> setUnFrozen, Action<ModelSqlType> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

            public SqlName Name { get { return this._Target._Name; } set { if (this._Target._Name == value) { return; } this.EnsureUnfrozen()._Name = value; } }

            public int ColumnId { get { return this._Target._ColumnId; } set { if (this._Target._ColumnId == value) { return; } this.EnsureUnfrozen()._ColumnId = value; } }

            public short MaxLength { get { return this._Target._MaxLength; } set { if (this._Target._MaxLength == value) { return; } this.EnsureUnfrozen()._MaxLength = value; } }

            public byte Precision { get { return this._Target._Precision; } set { if (this._Target._Precision == value) { return; } this.EnsureUnfrozen()._Precision = value; } }

            public byte Scale { get { return this._Target._Scale; } set { if (this._Target._Scale == value) { return; } this.EnsureUnfrozen()._Scale = value; } }

            public string CollationName { get { return this._Target._CollationName; } set { if (this._Target._CollationName == value) { return; } this.EnsureUnfrozen()._CollationName = value; } }

            public bool IsNullable { get { return this._Target._IsNullable; } set { if (this._Target._IsNullable == value) { return; } this.EnsureUnfrozen()._IsNullable = value; } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line
        }
    }
}