namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// read infos from sys - schema
    /// </summary>
    public sealed class SqlSysUtiltiy : IDisposable {
        private SqlSysServer CurrentServer;

        /// <summary>
        /// id to Database
        /// </summary>
        public readonly Dictionary<int, SqlSysDatabase> DatabaseById;

        /// <summary>
        /// The current database - set by ReadCurrentDatbase.
        /// </summary>
        public SqlSysDatabase CurrentDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysUtiltiy"/> class.
        /// </summary>
        public SqlSysUtiltiy() {
            this.DatabaseById = new Dictionary<int, SqlSysDatabase>();
        }

        /// <summary>
        /// Gets or sets the TransConnection.
        /// </summary>
        public SqlTransConnection TransConnection { get; set; }

        /// <summary>
        /// Release the TransConnection.
        /// </summary>
        public void Dispose() {
            using (var tc = this.TransConnection) {
                this.TransConnection = null;
            }
        }

        /// <summary>
        /// Read the objects.
        /// </summary>
        /// <param name="db">the database if null the current or the connnection db is used - null is good</param>
        /// <returns>the database</returns>
        public SqlSysDatabase ReadAllFromDatabase(SqlSysDatabase db = null) {
            if (db == null) {
                db = this.CurrentDatabase;
            }
            if (db == null) {
                db = this.ReadCurrentDatbase();
            }
            if (db != null) {
                var sqlTransConnection = this.EnsureOpenTransConnection();
                db.ReadAll(sqlTransConnection);
            }
            return db;
        }

        /// <summary>
        /// Read the server info from the server;
        /// </summary>
        /// <returns>the server - null if no rights</returns>
        public SqlSysServer ReadServer() {
            var sqlTransConnection = this.EnsureOpenTransConnection();
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysServer.SELECTStatment)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityFlexible.ConvertFromSqlResult<SqlSysServer>(nameof(SqlSysServer),sqlResults.First(), SqlSysServer.Factory).FirstOrDefault();
                    this.CurrentServer = result;
                    return result;
                }
            } catch { }
            return null;
        }

        /// <summary>
        /// Read the databases from the server;
        /// </summary>
        /// <returns>the databases</returns>
        public List<SqlSysDatabase> ReadDatabases() {
            var sqlTransConnection = this.EnsureOpenTransConnection();
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTAllStatement)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityFlexible.ConvertFromSqlResult<SqlSysDatabase>(nameof(SqlSysDatabase), sqlResults.First(), SqlSysDatabase.Factory);
                    result.ForEach((item) => { this.DatabaseById[item.database_id] = item; });
                    return result;
                }
            } catch { }
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTCurrentStatement)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityFlexible.ConvertFromSqlResult<SqlSysDatabase>(nameof(SqlSysDatabase), sqlResults.First(), SqlSysDatabase.Factory);
                    result.ForEach((item) => { this.DatabaseById[item.database_id] = item; });
                    return result;
                }
            } catch { }
            return new List<SqlSysDatabase>();
        }

        /// <summary>
        /// Read the current database from the server;
        /// </summary>
        /// <returns>the databases</returns>
        public SqlSysDatabase ReadCurrentDatbase() {
            var sqlTransConnection = this.EnsureOpenTransConnection();
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTCurrentStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityFlexible.ConvertFromSqlResult<SqlSysDatabase>(nameof(SqlSysDatabase), sqlResults.First(), SqlSysDatabase.Factory).FirstOrDefault();
                this.DatabaseById[result.database_id] = result;
                this.CurrentDatabase = result;
                return result;
            }
        }

#if unsure
        /// <summary>
        /// Read the tables from the database;
        /// </summary>
        /// <returns>the tables</returns>
        public List<SqlSysSchema> ReadSchemas() => this.EnsureCurrentDatabase()?.ReadSchemas(this.EnsureOpenTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysType> ReadTypes() => this.EnsureCurrentDatabase()?.ReadTypes(this.EnsureOpenTransConnection());

        /// <summary>
        /// Read the sys.all_objects from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysObject> ReadAllObjects() => this.EnsureCurrentDatabase()?.ReadAllObjects(this.EnsureOpenTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysColumn> ReadColumns() => this.EnsureCurrentDatabase()?.ReadColumns(this.EnsureOpenTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysParameter> ReadParameters() => this.EnsureCurrentDatabase()?.ReadParameters(this.EnsureOpenTransConnection());

#endif

        /// <summary>
        /// Get the transConnection.
        /// </summary>
        /// <returns>a open transconnection</returns>
        public SqlTransConnection EnsureOpenTransConnection() {
            if ((object)this.TransConnection == null) {
                throw new InvalidOperationException("TransConnection is null");
            } else {
                this.TransConnection.Open();
                return this.TransConnection;
            }
        }

        /// <summary>
        /// Get the current database - read if neeed <see cref="ReadCurrentDatbase"/>;
        /// </summary>
        /// <returns>the database.</returns>
        public SqlSysDatabase EnsureCurrentDatabase() => this.CurrentDatabase ?? this.ReadCurrentDatbase();
    }
}
