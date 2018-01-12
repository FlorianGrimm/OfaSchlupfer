namespace OfaSchlupfer.MSSQLReflection {
    using System.Data.SqlClient;

    public class TestCfg {
        public string ConnectionString { get; private set; }

        public static TestCfg Get() {
            string server;
            string db = "OfaSchlupfer";
            if (System.Environment.GetEnvironmentVariable("COMPUTERNAME") == "SOL-AA-14-B") {
                server = "higatangan.dev.solvin.local";
            } else {
                server = ".";
            }
            var csb = new SqlConnectionStringBuilder();
            csb.DataSource = server;
            csb.InitialCatalog = db;
            csb.IntegratedSecurity = true;
            return new TestCfg() {
                ConnectionString = csb.ConnectionString
            };
        }
    }
}
