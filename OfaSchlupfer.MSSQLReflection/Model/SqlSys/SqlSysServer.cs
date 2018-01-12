namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysServer : EntityArrayProp {
        public const string SELECTStatment = "SELECT servername=@@SERVERNAME, servicename=@@SERVICENAME, version=@@VERSION;";
        public SqlSysServer(MetaEntityArrayProp metaData, object[] values) : base(metaData, values) {
        }
        public string servername { get { return this.GetPropertyAsString(nameof(servername)); } }
        public string servicename { get { return this.GetPropertyAsString(nameof(servicename)); } }
        public string version { get { return this.GetPropertyAsString(nameof(version)); } }

        public static SqlSysServer Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysServer(metaData, values);
        }
    }
}
