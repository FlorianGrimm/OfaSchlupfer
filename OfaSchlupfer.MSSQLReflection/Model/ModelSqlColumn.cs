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

        public SqlName Name { get; set; }

        public int ColumnId { get; set; }

        public short system_type_id { get; set; }

        public int user_type_id { get; set; }

        public short MaxLength { get; set; }

        public byte Precision { get; set; }

        public byte Scale { get; set; }

        public string CollationName { get; set; }

        public bool IsNullable { get; set; }

        /// <summary>
        /// Gets or sets the reference to the SqlType
        /// </summary>
        public ModelSqlType SqlType { get; set; }

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