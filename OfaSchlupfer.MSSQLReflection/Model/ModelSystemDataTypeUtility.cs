namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ModelSystemDataTypeUtility {
        public static Type ConvertToClrType(ModelSystemDataType value) {
            switch (value) {
                case ModelSystemDataType.None:
                    break;
                case ModelSystemDataType.BigInt:
                    return typeof(long);
                case ModelSystemDataType.Int:
                    return typeof(int);
                case ModelSystemDataType.SmallInt:
                    return typeof(short);
                case ModelSystemDataType.TinyInt:
                    return typeof(byte);
                case ModelSystemDataType.Bit:
                    return typeof(bool);
                case ModelSystemDataType.Decimal:
                    return typeof(decimal);
                case ModelSystemDataType.Numeric:
#warning double single
                    return typeof(double);
                case ModelSystemDataType.Money:
                    return typeof(decimal);
                case ModelSystemDataType.SmallMoney:
                    return typeof(decimal);
                case ModelSystemDataType.Float:
                    return typeof(float);
                case ModelSystemDataType.Real:
                    return typeof(double);
                case ModelSystemDataType.DateTime:
                    return typeof(DateTime);
                case ModelSystemDataType.SmallDateTime:
                    return typeof(DateTime);
                case ModelSystemDataType.Char:
                    return typeof(string);
                case ModelSystemDataType.VarChar:
                    return typeof(string);
                case ModelSystemDataType.Text:
                    return typeof(string);
                case ModelSystemDataType.NChar:
                    return typeof(string);
                case ModelSystemDataType.NVarChar:
                    return typeof(string);
                case ModelSystemDataType.NText:
                    return typeof(string);
                case ModelSystemDataType.Binary:
                    return typeof(byte[]);
                case ModelSystemDataType.VarBinary:
                    return typeof(byte[]);
                case ModelSystemDataType.Image:
                    return typeof(byte[]);
                case ModelSystemDataType.Cursor:
                    return typeof(object);
                case ModelSystemDataType.Sql_Variant:
                    return typeof(object);
                case ModelSystemDataType.Table:
                    return typeof(object); // ??
                case ModelSystemDataType.Timestamp:
                    return typeof(byte[]);
                case ModelSystemDataType.UniqueIdentifier:
                    return typeof(Guid);
                case ModelSystemDataType.Date:
                    return typeof(DateTime);
                case ModelSystemDataType.Time:
                    return typeof(TimeSpan);
                case ModelSystemDataType.DateTime2:
                    return typeof(DateTime);
                case ModelSystemDataType.DateTimeOffset:
                    return typeof(DateTimeOffset);
                case ModelSystemDataType.Rowversion:
                    return typeof(byte[]);
                default:
                    break;
            }
            return null;
        }

        public static string GetCondensed(SqlName name, ModelSystemDataType systemDataType, short? maxLength, byte? scale, byte? precision) {
            // TODO: this.Scale
            switch (systemDataType) {
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
                    return "char(" + (maxLength.GetValueOrDefault().ToString()) + ")";
                case ModelSystemDataType.VarChar:
                    return "varchar(" + (((maxLength.GetValueOrDefault(-1) <= 0) || (maxLength.GetValueOrDefault(-1) >= 8000)) ? "max" : maxLength.Value.ToString()) + ")";
                case ModelSystemDataType.Text:
                    return "text";
                case ModelSystemDataType.NChar:
                    return "nchar(" + (maxLength.GetValueOrDefault().ToString()) + ")";
                case ModelSystemDataType.NVarChar:
                    return "nvarchar(" + (((maxLength.GetValueOrDefault(-1) <= 0) || (maxLength.GetValueOrDefault(-1) >= 8000)) ? "max" : maxLength.Value.ToString()) + ")";
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
            return name.GetQFullName("[", 2);
        }

        private static Dictionary<string, ModelSystemDataType> _ConvertFromSqlName;
        public static ModelSystemDataType ConvertFromSqlName(SqlName name) {
            if (_ConvertFromSqlName is null) {
                var d = new Dictionary<string, ModelSystemDataType>(StringComparer.OrdinalIgnoreCase);
                d.Add("BigInt", ModelSystemDataType.BigInt);
                d.Add("Binary", ModelSystemDataType.Binary);
                d.Add("Bit", ModelSystemDataType.Bit);
                d.Add("Char", ModelSystemDataType.Char);
                d.Add("Cursor", ModelSystemDataType.Cursor);
                d.Add("Date", ModelSystemDataType.Date);
                d.Add("DateTime", ModelSystemDataType.DateTime);
                d.Add("DateTime2", ModelSystemDataType.DateTime2);
                d.Add("DateTimeOffset", ModelSystemDataType.DateTimeOffset);
                d.Add("Decimal", ModelSystemDataType.Decimal);
                d.Add("Float", ModelSystemDataType.Float);
                d.Add("Image", ModelSystemDataType.Image);
                d.Add("Int", ModelSystemDataType.Int);
                d.Add("Money", ModelSystemDataType.Money);
                d.Add("NChar", ModelSystemDataType.NChar);
                d.Add("NText", ModelSystemDataType.NText);
                d.Add("Numeric", ModelSystemDataType.Numeric);
                d.Add("NVarChar", ModelSystemDataType.NVarChar);
                d.Add("Real", ModelSystemDataType.Real);
                d.Add("Rowversion", ModelSystemDataType.Rowversion);
                d.Add("SmallDateTime", ModelSystemDataType.SmallDateTime);
                d.Add("SmallInt", ModelSystemDataType.SmallInt);
                d.Add("SmallMoney", ModelSystemDataType.SmallMoney);
                d.Add("Sql_Variant", ModelSystemDataType.Sql_Variant);
                d.Add("Table", ModelSystemDataType.Table);
                d.Add("Text", ModelSystemDataType.Text);
                d.Add("Time", ModelSystemDataType.Time);
                d.Add("Timestamp", ModelSystemDataType.Timestamp);
                d.Add("TinyInt", ModelSystemDataType.TinyInt);
                d.Add("UniqueIdentifier", ModelSystemDataType.UniqueIdentifier);
                d.Add("VarBinary", ModelSystemDataType.VarBinary);
                d.Add("VarChar", ModelSystemDataType.VarChar);
                _ConvertFromSqlName = d;
            }
            if (string.Equals(name.Parent.Name, "sys", StringComparison.OrdinalIgnoreCase)) {
                return _ConvertFromSqlName.GetValueOrDefault(name.Name, ModelSystemDataType.None);
            }
            return ModelSystemDataType.None;
        }
    }
}
