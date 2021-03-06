﻿#pragma warning disable SA1602

namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// the same as Microsoft.SqlServer.TransactSql.ScriptDom.SqlDataTypeOption
    /// </summary>
    public enum ModelSystemDataType {
        None = 0,
        BigInt = 1,
        Int = 2,
        SmallInt = 3,
        TinyInt = 4,
        Bit = 5,
        Decimal = 6,
        Numeric = 7,
        Money = 8,
        SmallMoney = 9,
        Float = 10,
        Real = 11,
        DateTime = 12,
        SmallDateTime = 13,
        Char = 14,
        VarChar = 15,
        Text = 16,
        NChar = 17,
        NVarChar = 18,
        NText = 19,
        Binary = 20,
        VarBinary = 21,
        Image = 22,
        Cursor = 23,
        Sql_Variant = 24,
        Table = 25,
        Timestamp = 26,
        UniqueIdentifier = 27,
        Date = 29,
        Time = 30,
        DateTime2 = 31,
        DateTimeOffset = 32,
        Rowversion = 33
    }
}
