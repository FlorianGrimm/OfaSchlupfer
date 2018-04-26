namespace OfaSchlupfer.SqlAccess {
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// SqlUtility
    /// </summary>
    public static class SqlUtility {
        /// <summary>
        /// Gets the value or DBNull.Value
        /// </summary>
        /// <param name="value">any value</param>
        /// <returns>The value or DBNull.Value</returns>
        public static object OrDBNull(object value) {
            if (value is null) { return DBNull.Value; }
            return value;
        }

        /// <summary>
        /// Replace the DBNULL.Value with null.
        /// </summary>
        /// <param name="values">the read values from sql</param>
        public static void ReplaceDBNullByNull(object[] values) {
            // DBNULL to null
            var cnt = values.Length;
            for (int idx = 0; idx < cnt; idx++) {
                if (values[idx] == DBNull.Value) {
                    values[idx] = null;
                }
            }
        }

        public static List<SqlReadResult> ExecuteReader(SqlCommand command, bool meassure, bool log) {
            var result = new List<SqlReadResult>();
            if (meassure) {
                using (SqlCommand commandS = new SqlCommand()) {
                    commandS.Connection = command.Connection;
                    commandS.CommandText = "SET STATISTICS IO ON;";
                    if (command.Transaction != null) {
                        commandS.Transaction = command.Transaction;
                    }
                    commandS.ExecuteNonQuery();
                }
            }
            using (var m = (meassure || log) ? (new SqlMeassure(command.Connection)) : null) {
                using (var reader = command.ExecuteReader()) {
                    var nextResult = true;
                    for (int resultIndex = 0; (resultIndex == 0) || nextResult; resultIndex++) {
                        var readResult = new SqlReadResult() { ResultIndex = resultIndex };
                        result.Add(readResult);

                        int fieldCount = -1;
                        string[] fieldNames = null;
                        string[] fieldTypes = null;
                        for (int rowIndex = 0; reader.Read(); rowIndex++) {
                            if (rowIndex == 0) {
                                fieldCount = readResult.FieldCount = reader.FieldCount;
                                fieldNames = new string[fieldCount];
                                fieldTypes = new string[fieldCount];
                                for (int fieldIndex = 0; fieldIndex < fieldCount; fieldIndex++) {
                                    fieldNames[fieldIndex] = reader.GetName(fieldIndex);
                                    fieldTypes[fieldIndex] = reader.GetDataTypeName(fieldIndex);
                                }
                                readResult.FieldNames = fieldNames;
                                readResult.FieldTypes = fieldTypes;
                            }
                            var values = new object[fieldCount];
                            reader.GetValues(values);
                            ReplaceDBNullByNull(values);
                            readResult.Add(values);
                        }
                        if (readResult.FieldCount == 0) {
                            fieldCount = readResult.FieldCount = reader.FieldCount;
                            fieldNames = new string[fieldCount];
                            fieldTypes = new string[fieldCount];
                            for (int fieldIndex = 0; fieldIndex < fieldCount; fieldIndex++) {
                                fieldNames[fieldIndex] = reader.GetName(fieldIndex);
                                fieldTypes[fieldIndex] = reader.GetDataTypeName(fieldIndex);
                            }
                            readResult.FieldNames = fieldNames;
                            readResult.FieldTypes = fieldTypes;
                        }
                        nextResult = (reader.NextResult());
                        if (m != null) {
                            readResult.MeassureMessage.AddRange(m.Messages);
                            readResult.MeassureError.AddRange(m.Errors);
                            m.Messages.Clear();
                            m.Errors.Clear();
                        }
                    }
                }
            }
            return result;
        }
    }
}
