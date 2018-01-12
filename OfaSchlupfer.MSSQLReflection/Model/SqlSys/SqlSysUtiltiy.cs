namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// read infos from sys - schema
    /// </summary>
    public sealed class SqlSysUtiltiy : IDisposable {
        public SqlSysDatabase CurrentDatabase;
        private SqlSysServer CurrentServer;
        public readonly Dictionary<int, SqlSysDatabase> DatabaseById;

        /// <summary>
        /// ctor
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
        public SqlSysDatabase ReadAllFromDatbase(SqlSysDatabase db = null) {
            if (db == null) {
                db = this.CurrentDatabase;
            }
            if (db == null) {
                db = this.ReadCurrentDatbase();
            }
            if (db != null) {
                var sqlTransConnection = ensureTransConnection();
                db.ReadAll(sqlTransConnection);
            }
            return db;
        }


        /// <summary>
        /// Read the server info from the server;
        /// </summary>
        /// <returns>the server - null if no rights</returns>
        public SqlSysServer ReadServer() {
            var sqlTransConnection = ensureTransConnection();
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysServer.SELECTStatment)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityArrayProp.ConvertFromSqlResult<SqlSysServer>(sqlResults.First(), SqlSysServer.Factory).FirstOrDefault();
                    this.CurrentServer = result;
                    return result;
                }
            } catch {
            }
            return null;
        }

        /// <summary>
        /// Read the databases from the server;
        /// </summary>
        /// <returns>the databases</returns>
        public List<SqlSysDatabase> ReadDatbases() {
            var sqlTransConnection = ensureTransConnection();
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTAllStatement)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityArrayProp.ConvertFromSqlResult<SqlSysDatabase>(sqlResults.First(), SqlSysDatabase.Factory);
                    result.ForEach((item) => { this.DatabaseById[item.database_id] = item; });
                    return result;
                }
            } catch {
            }
            try {
                using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTCurrentStatement)) {
                    var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                    var result = EntityArrayProp.ConvertFromSqlResult<SqlSysDatabase>(sqlResults.First(), SqlSysDatabase.Factory);
                    result.ForEach((item) => { this.DatabaseById[item.database_id] = item; });
                    return result;
                }
            } catch {
            }
            return new List<SqlSysDatabase>();
        }

        /// <summary>
        /// Read the current database from the server;
        /// </summary>
        /// <returns>the databases</returns>
        public SqlSysDatabase ReadCurrentDatbase() {
            var sqlTransConnection = ensureTransConnection();
            using (var command = sqlTransConnection.SqlCommand(System.Data.CommandType.Text, SqlSysDatabase.SELECTCurrentStatement)) {
                var sqlResults = SqlUtility.ExecuteReader(command, false, false);
                var result = EntityArrayProp.ConvertFromSqlResult<SqlSysDatabase>(sqlResults.First(), SqlSysDatabase.Factory).FirstOrDefault();
                this.DatabaseById[result.database_id] = result;
                this.CurrentDatabase = result;
                return result;
            }
        }

        /// <summary>
        /// Read the tables from the database;
        /// </summary>
        /// <returns>the tables</returns>
        public List<SqlSysSchema> ReadSchemas() => this.ensureCurrentDatabase()?.ReadSchemas(ensureTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysType> ReadTypes() => this.ensureCurrentDatabase()?.ReadTypes(ensureTransConnection());


        /// <summary>
        /// Read the sys.all_objects from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysObject> ReadAllObjects() => this.ensureCurrentDatabase()?.ReadAllObjects(ensureTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysColumn> ReadColumns() => this.ensureCurrentDatabase()?.ReadColumns(ensureTransConnection());

        /// <summary>
        /// Read the columns from the database.
        /// </summary>
        /// <returns>the columns.</returns>
        public List<SqlSysParameter> ReadParameters() => this.ensureCurrentDatabase()?.ReadParameters(ensureTransConnection());


        private SqlTransConnection ensureTransConnection() {
            if ((object)this.TransConnection == null) {
                throw new InvalidOperationException("TransConnection is null");
            } else {
                this.TransConnection.Open();
                return this.TransConnection;
            }
        }

        private SqlSysDatabase ensureCurrentDatabase() => this.CurrentDatabase ?? this.ReadCurrentDatbase();
    }
}
