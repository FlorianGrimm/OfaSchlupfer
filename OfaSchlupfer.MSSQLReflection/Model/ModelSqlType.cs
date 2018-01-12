namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;

    /// <summary>
    /// ModelSqlType
    /// </summary>
    public sealed class ModelSqlType : BuildTargetBase, IEquatable<ModelSqlType> {
        private SqlName _Name;
        private int _ColumnId;
        //private short _system_type_id;
        //private int _user_type_id;
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

        //public SqlName Name { get; set; }
        //public short system_type_id { get; set; }
        //public int user_type_id { get; set; }
        //public short MaxLength { get; set; }
        //public byte Precision { get; set; }
        //public byte Scale { get; set; }
        //public string CollationName { get; set; }
        //public bool IsNullable { get; set; }

        public SqlName Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }
        public int ColumnId { get { return this._ColumnId; } set { this.ThrowIfFozen(); this._ColumnId = value; } }
        //public short system_type_id { get { return this._system_type_id; } set { this.ThrowIfFozen(); this._system_type_id = value; } }
        //public int user_type_id { get { return this._user_type_id; } set { this.ThrowIfFozen(); this._user_type_id = value; } }
        public short MaxLength { get { return this._MaxLength; } set { this.ThrowIfFozen(); this._MaxLength = value; } }
        public byte Precision { get { return this._Precision; } set { this.ThrowIfFozen(); this._Precision = value; } }
        public byte Scale { get { return this._Scale; } set { this.ThrowIfFozen(); this._Scale = value; } }
        public string CollationName { get { return this._CollationName; } set { this.ThrowIfFozen(); this._CollationName = value; } }
        public bool IsNullable { get { return this._IsNullable; } set { this.ThrowIfFozen(); this._IsNullable = value; } }


        public static bool operator ==(ModelSqlType a, ModelSqlType b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlType a, ModelSqlType b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        public override bool Equals(object obj) {
            return base.Equals(obj as ModelSqlType);
        }

        public bool Equals(ModelSqlType other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                && (this.MaxLength == other.MaxLength)
                && (this.Precision == other.Precision)
                && (this.Scale == other.Scale)
                && (this.CollationName == other.CollationName)
                && (this.IsNullable == other.IsNullable)
                ;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

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
            internal Builder(ModelSqlType target, bool clone, Action<ModelSqlType> setUnFrozen, Action<ModelSqlType> setFozen)
                : base(target, clone, setUnFrozen, setFozen) {
            }
            public SqlName Name { get { return this._Target._Name; } set { if (this._Target._Name == value) { return; } this.EnsureUnfrozen()._Name = value; } }
            public int ColumnId { get { return this._Target._ColumnId; } set { if (this._Target._ColumnId == value) { return; } this.EnsureUnfrozen()._ColumnId = value; } }
            //public short system_type_id { get { return this._Target._system_type_id; } set { if (this._Target._system_type_id == value) { return; } this.EnsureUnfrozen()._system_type_id = value; } }
            //public int user_type_id { get { return this._Target._user_type_id; } set { if (this._Target._user_type_id == value) { return; } this.EnsureUnfrozen()._user_type_id = value; } }
            public short MaxLength { get { return this._Target._MaxLength; } set { if (this._Target._MaxLength == value) { return; } this.EnsureUnfrozen()._MaxLength = value; } }
            public byte Precision { get { return this._Target._Precision; } set { if (this._Target._Precision == value) { return; } this.EnsureUnfrozen()._Precision = value; } }
            public byte Scale { get { return this._Target._Scale; } set { if (this._Target._Scale == value) { return; } this.EnsureUnfrozen()._Scale = value; } }
            public string CollationName { get { return this._Target._CollationName; } set { if (this._Target._CollationName == value) { return; } this.EnsureUnfrozen()._CollationName = value; } }
            public bool IsNullable { get { return this._Target._IsNullable; } set { if (this._Target._IsNullable == value) { return; } this.EnsureUnfrozen()._IsNullable = value; } }
        }
    }
}