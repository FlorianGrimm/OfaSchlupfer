namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Model;

    public class SqlRepository : IRepository {
        public SqlRepository() {
        }

        public string ConnectionString { get; set; }

        public void ReadSchema() {
            var utility = new MSSQLReflection.Utility() { ConnectionString = this.ConnectionString };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            // modelDatabase.Tables.Values.Where(tbl=>tbl.Schema==)
        }
    }
}
