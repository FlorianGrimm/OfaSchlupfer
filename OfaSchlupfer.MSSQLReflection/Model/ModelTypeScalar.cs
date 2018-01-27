namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the scalar type of sql
    /// </summary>
    public sealed class ModelTypeScalar : ModelType {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTypeScalar"/> class.
        /// </summary>
        public ModelTypeScalar() { }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>the name or null</returns>
        public override string GetName() {
            return this.TypeName.GetQFullName("[");
        }

        /// <summary>
        /// get the system condensed sql string;
        /// </summary>
        /// <returns>the sql string</returns>
        public string GetCondensed() {
            // TODO: this.Scale
            switch (this.SystemDataType) {
                case ModelSystemDataType.None:
                    break;
                case ModelSystemDataType.BigInt:
                    return "bigint";
                case ModelSystemDataType.Int:
                    return "int";
                case ModelSystemDataType.SmallInt:
                    return "smallInt";
                case ModelSystemDataType.TinyInt:
                    return "tinyInt";
                case ModelSystemDataType.Bit:
                    return "bit";
                case ModelSystemDataType.Decimal:
                    return "decimal";
                case ModelSystemDataType.Numeric:
                    return "numeric";
                case ModelSystemDataType.Money:
                    return "money";
                case ModelSystemDataType.SmallMoney:
                    return "smallmoney";
                case ModelSystemDataType.Float:
                    return "float";
                case ModelSystemDataType.Real:
                    return "real";
                case ModelSystemDataType.DateTime:
                    return "datetime";
                case ModelSystemDataType.SmallDateTime:
                    return "smalldatetime";
                case ModelSystemDataType.Char:
                    return "char(" + (this.MaxLength.GetValueOrDefault().ToString()) + ")";
                case ModelSystemDataType.VarChar:
                    return "varchar(" + ((this.MaxLength.GetValueOrDefault() <= 0) ? "max" : this.MaxLength.Value.ToString()) + ")";
                case ModelSystemDataType.Text:
                    return "text";
                case ModelSystemDataType.NChar:
                    return "nchar(" + (this.MaxLength.GetValueOrDefault().ToString()) + ")";
                case ModelSystemDataType.NVarChar:
                    return "nvarchar(" + ((this.MaxLength.GetValueOrDefault() <= 0) ? "max" : this.MaxLength.Value.ToString()) + ")";
                case ModelSystemDataType.NText:
                    return "ntext";
                case ModelSystemDataType.Binary:
                    return "binary";
                case ModelSystemDataType.VarBinary:
                    return "varbinary";
                case ModelSystemDataType.Image:
                    return "image";
                case ModelSystemDataType.Cursor:
                    return "cursor";
                case ModelSystemDataType.Sql_Variant:
                    return "sql_variant";
                case ModelSystemDataType.Table:
                    return "table"; // ??
                case ModelSystemDataType.Timestamp:
                    return "timestamp";
                case ModelSystemDataType.UniqueIdentifier:
                    return "uniqueidentifier";
                case ModelSystemDataType.Date:
                    return "date";
                case ModelSystemDataType.Time:
                    return "time";
                case ModelSystemDataType.DateTime2:
                    return "datetime2";
                case ModelSystemDataType.DateTimeOffset:
                    return "datetimeoffset";
                case ModelSystemDataType.Rowversion:
                    return "rowversion";
                default:
                    break;
            }
            return "??";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTypeScalar"/> class.
        /// </summary>
        /// <param name="src">the source</param>
        public ModelTypeScalar(ModelTypeScalar src) {
            if ((object)src != null) {
                this.SystemDataType = src.SystemDataType;
                this.TypeName = src.TypeName;
                this.MaxLength = src.MaxLength;
                this.Scale = src.Scale;
                this.Precision = src.Precision;
                this.CollationName = src.CollationName;
                this.IsNullable = src.IsNullable;
            }
        }

        /// <summary>
        /// Gets or sets the datatype
        /// </summary>
        public ModelSystemDataType SystemDataType { get; set; }

        /// <summary>
        /// Gets or sets the MaxLength.
        /// </summary>
        public short? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the Precision.
        /// </summary>
        public byte? Precision { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        public byte? Scale { get; set; }

        /// <summary>
        /// Gets or sets the CollationName.
        /// </summary>
        public string CollationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is nullable.
        /// </summary>
        public bool? IsNullable { get; set; }
    }
}
