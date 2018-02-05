namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.ModelSql;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.Model;

    [TestClass()]
    public class SqlRepositoryTests {
        [TestMethod()]
        public void SqlRepository_SqlRepositoryTest() {
            var modelRoot = new ModelRoot();
            var modelRepository = new ModelRepository() { Name = "S", SqlSchemaName = "prj", Type = "SQL" };
            modelRoot.Repositories.Add(modelRepository);
            // TODO: modelRepository.GetRepository();

            var sqlRepository = new SqlRepository();
            modelRepository.Repository = sqlRepository;
            sqlRepository.ConnectionString = TestCfg.Get().ConnectionString;
            sqlRepository.ReadSchema();
        }
    }
}