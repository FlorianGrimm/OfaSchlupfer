﻿namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Elementary.SqlAccess;

    // TODO:
    // SELECT * FROM sys.check_constraints;
    // SELECT * FROM sys.default_constraints;
    //
    // SELECT i.name, i.object_id, i.index_id, i.type_desc, i.is_unique, i.is_primary_key, i.is_unique , i.is_unique_constraint, i.filter_definition FROM sys.indexes i INNER JOIN sys.tables t ON i.object_id = t.object_id;
    // SELECT c.object_id, c.index_id, c.index_column_id, c.column_id, c.key_ordinal, c.is_descending_key, c.is_included_column FROM sys.index_columns c INNER JOIN sys.indexes i ON c.object_id = i.object_id INNER JOIN sys.tables t ON i.object_id = t.object_id;
    //
    // SELECT name, object_id, schema_id, type, create_date, modify_date, referenced_object_id, key_index_id, delete_referential_action_desc, update_referential_action_desc, is_system_named FROM sys.foreign_keys;
    // SELECT constraint_object_id, constraint_column_id, referenced_object_id, referenced_column_id FROM sys.foreign_key_columns;
    // SELECT constraint_object_id, constraint_column_id, parent_object_id, parent_column_id, referenced_object_id, referenced_column_id FROM sys.foreign_key_columns;
    // SELECT object_id, definition FROM sys.all_sql_modules WHERE (object_id > 0);

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysDatabase : EntityArrayProp {
        /// <summary>
        /// Select statement for current databases
        /// </summary>
        public const string SELECTCurrentStatement = "SELECT name = DB_NAME(), database_id = DB_ID(), collation_name = CAST(DATABASEPROPERTYEX(DB_NAME(), 'Collation') AS sysname);";

        /// <summary>
        /// Select statement for all databases
        /// </summary>
        public const string SELECTAllStatement = "SELECT name, database_id, collation_name FROM master.sys.databases;";

        /// <summary>
        /// id to schema
        /// </summary>
        public readonly Dictionary<int, SqlSysSchema> SchemaById;

        /// <summary>
        /// list of types
        /// </summary>
        public readonly List<SqlSysType> Types;

        /// <summary>
        /// user_type_id to type
        /// </summary>
        public readonly Dictionary<int, SqlSysType> TypesByUserId;

        /// <summary>
        /// id to object
        /// </summary>
        public readonly Dictionary<int, SqlSysObject> AllObjectsById;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysDatabase"/> class.
        /// </summary>
        public SqlSysDatabase()
            : this(new MetaEntityArrayProp(), new object[0]) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysDatabase"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysDatabase(MetaEntityArrayProp metaData, object[] values)
            : base(metaData, values) {
            this.SchemaById = new Dictionary<int, SqlSysSchema>();
            this.Types = new List<SqlSysType>();
            this.TypesByUserId = new Dictionary<int, SqlSysType>();
            this.AllObjectsById = new Dictionary<int, SqlSysObject>();
        }

#pragma warning disable SA1101 // Prefix local calls with this
        /// <summary>
        /// Gets the dabase name
        /// </summary>
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        /// <summary>
        /// Gets the id od the database
        /// </summary>
        public int database_id { get { return this.GetPropertyAsInt(nameof(database_id)); } }

        /// <summary>
        /// Gets the date the object was created.
        /// </summary>
        public System.DateTime create_date { get { return this.GetPropertyAsDateTime(nameof(create_date)); } }

        /// <summary>
        /// Gets the collation
        /// </summary>
        public string collation_name { get { return this.GetPropertyAsString(nameof(collation_name)); } }
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysDatabase Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysDatabase(metaData, values);
        }

        /// <summary>
        /// Read all objects from the db
        /// </summary>
        /// <param name="sqlTransConnection">the transConnection to use.</param>
        public void ReadAll(SqlTransConnection sqlTransConnection) {
            this.ReadSchemas(sqlTransConnection);
            this.ReadAllObjects(sqlTransConnection);
            this.ReadTypes(sqlTransConnection);
            this.ReadColumns(sqlTransConnection);
            this.ReadParameters(sqlTransConnection);
        }

        /// <summary>
        /// Read the schemas from the database;
        /// </summary>
        /// <param name="sqlTransConnection">the TransConnection.</param>
        /// <returns>the tables</returns>
        public List<SqlSysSchema> ReadSchemas(SqlTransConnection sqlTransConnection) {
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysSchema.SELECTStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysSchema>(sqlResults.First(), SqlSysSchema.Factory);
                result.ForEach((item) => { this.SchemaById[item.schema_id] = item; });
                return result;
            }
        }

        /// <summary>
        /// Read the types from the database.
        /// </summary>
        /// <param name="sqlTransConnection">the TransConnection.</param>
        /// <returns>the columns.</returns>
        public List<SqlSysType> ReadTypes(SqlTransConnection sqlTransConnection) {
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysType.SELECTStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysType>(sqlResults.First(), SqlSysType.Factory);
                result.ForEach((item) => {
                    this.Types.Add(item);
                    this.TypesByUserId[item.user_type_id] = item;
                });
                return result;
            }
        }

        /// <summary>
        /// Read the sys.all_objects from the database.
        /// </summary>
        /// <param name="sqlTransConnection">the TransConnection.</param>
        /// <returns>the columns.</returns>
        public List<SqlSysObject> ReadAllObjects(SqlTransConnection sqlTransConnection) {
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysObject.SELECTStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysObject>(sqlResults.First(), SqlSysObject.Factory);
                result.ForEach((item) => {
                    this.AllObjectsById[item.object_id] = item;
                });
                return result;
            }
        }

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <param name="sqlTransConnection">the TransConnection.</param>
        /// <returns>the columns.</returns>
        public List<SqlSysColumn> ReadColumns(SqlTransConnection sqlTransConnection) {
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysColumn.SELECTStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysColumn>(sqlResults.First(), SqlSysColumn.Factory);
                result.ForEach((item) => {
                    {
                        var obj = this.AllObjectsById.GetValueOrDefault(item.object_id);
                        if (obj != null) {
                            obj.GetColumns().Add(item);
                        }
                    }
                });
                return result;
            }
        }

        /// <summary>
        /// Read the parameters from the database.
        /// </summary>
        /// <param name="sqlTransConnection">the TransConnection.</param>
        /// <returns>the columns.</returns>
        public List<SqlSysParameter> ReadParameters(SqlTransConnection sqlTransConnection) {
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysParameter.SELECTStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysParameter>(sqlResults.First(), SqlSysParameter.Factory);
                result.ForEach((item) => {
                    {
                        var obj = this.AllObjectsById.GetValueOrDefault(item.object_id);
                        if (obj != null) {
                            obj.Parameters.Add(item);
                        }
                    }
                });
                return result;
            }
        }

        /// <summary>
        /// Filter the objects for user table
        /// </summary>
        /// <returns>a list of user tables</returns>
        public List<SqlSysObject> GetTables() {
            return this.AllObjectsById.Values
                .Where(_ => string.Equals(_.type, "U ", StringComparison.Ordinal))
                .ToList();
        }

        /// <summary>
        /// filter th object for view.
        /// </summary>
        /// <returns>a list of views</returns>
        public List<SqlSysObject> GetViews() {
            return this.AllObjectsById.Values
                .Where(_ => string.Equals(_.type, "V ", StringComparison.Ordinal))
                .ToList();
        }
    }
}
