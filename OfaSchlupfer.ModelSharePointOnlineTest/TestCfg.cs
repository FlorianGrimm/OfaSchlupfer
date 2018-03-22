namespace OfaSchlupfer {
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    using OfaSchlupfer.Elementary;

    public class TestCfg {
        public static TestCfg Cache;

        public static IConfiguration Configuration;

        public static TestCfg Get(ConfigurationBuilder builder = null) {
            if (Cache != null) { return Cache; }

            if (builder == null) {
                builder = new ConfigurationBuilder();
            }
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"securePath", @"C:\secure"}
            });
            builder.AddEnvironmentVariables();
            var cfg = builder.Build();
            var securePath = cfg["securePath"];
            if (string.IsNullOrEmpty(securePath)) { securePath = @"C:\secure"; }
            builder.SetBasePath(securePath);
            builder.AddJsonFile("OfaSchlupfer.json", true, false);
            Configuration = builder.Build();

            var cache = new TestCfg();
            Configuration.Bind(cache);            
            if (string.IsNullOrEmpty(cache.ConnectionString)) {
                var csb = new System.Data.SqlClient.SqlConnectionStringBuilder();
                csb.DataSource = ".";
                csb.InitialCatalog = "OfaSchlupfer";
                csb.IntegratedSecurity = true;
                cache.ConnectionString = csb.ConnectionString;
            }
            Cache = cache;
            return cache;
        }

        public TestCfg() {
            this.ProjectServer = new RepositoryConnectionString();
        }
        
        public string ConnectionString { get; set; }

        public RepositoryConnectionString ProjectServer { get; set; }
    }    
}
