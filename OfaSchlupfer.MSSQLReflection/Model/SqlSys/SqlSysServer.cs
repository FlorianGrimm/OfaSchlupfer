#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysServer : EntityArrayProp {
        public const string SELECTStatment = "SELECT servername=@@SERVERNAME, servicename=@@SERVICENAME, version=@@VERSION;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysServer"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysServer(MetaEntityArrayProp metaData, object[] values)
            : base(metaData, values) {
            this.Databases = new Dictionary<SqlName, SqlSysDatabase>();
        }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        public Dictionary<SqlName, SqlSysDatabase> Databases { get; }

#pragma warning disable SA1101 // Prefix local calls with this
        public string servername { get { return this.GetPropertyAsString(nameof(servername)); } }

        public string servicename { get { return this.GetPropertyAsString(nameof(servicename)); } }

        public string version { get { return this.GetPropertyAsString(nameof(version)); } }

#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysServer Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysServer(metaData, values);
        }
    }
}
