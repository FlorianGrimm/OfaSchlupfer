#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;
    using OfaSchlupfer.Elementary;

    /// <summary>
    /// column
    /// </summary>
    public sealed class ModelSqlColumn
        : IEquatable<ModelSqlColumn> {
        private SqlName _Name;
        private int _ColumnId;
        private short _system_type_id;
        private int _user_type_id;
        private short _MaxLength;
        private byte _Precision;
        private byte _Scale;
        private string _CollationName;
        private bool _IsNullable;
        private ModelSqlType _SqlType;

        public ModelSqlColumn() {
        }

        public ModelSqlColumn(ModelSqlColumn src) {
            this.Name = src.Name;
            this.ColumnId = src.ColumnId;
            this.MaxLength = src.MaxLength;
            this.Scale = src.Scale;
            this.Precision = src.Precision;
            this.CollationName = src.CollationName;
            this.IsNullable = src.IsNullable;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        public SqlName Name { get { return this._Name; } set { this._Name = value; } }

        public int ColumnId { get { return this._ColumnId; } set { this._ColumnId = value; } }

        public short system_type_id { get { return this._system_type_id; } set { this._system_type_id = value; } }

        public int user_type_id { get { return this._user_type_id; } set { this._user_type_id = value; } }

        public short MaxLength { get { return this._MaxLength; } set { this._MaxLength = value; } }

        public byte Precision { get { return this._Precision; } set { this._Precision = value; } }

        public byte Scale { get { return this._Scale; } set { this._Scale = value; } }

        public string CollationName { get { return this._CollationName; } set { this._CollationName = value; } }

        public bool IsNullable { get { return this._IsNullable; } set { this._IsNullable = value; } }

        /// <summary>
        /// Gets or sets the reference to the SqlType
        /// </summary>
        public ModelSqlType SqlType { get { return this._SqlType; } set { this._SqlType = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

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
                && (this.IsNullable == other.IsNullable)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}