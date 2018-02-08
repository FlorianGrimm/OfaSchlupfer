using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.MSSQLReflection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.MSSQLReflection.Model {
    [TestClass()]
    public class ModelSqlDatabaseTests {
        private static ModelSqlDatabase GetTestModelSqlDatabase() {
            ModelSqlServer modelSqlServer = new ModelSqlServer();
            modelSqlServer.Name = SqlName.Root.ChildWellkown("default");

            var serverScope = modelSqlServer.GetScope();

            var result = new ModelSqlDatabase(modelSqlServer, "OfaSchlupfer").AddToParent();
            result.Name = SqlName.Root.ChildWellkown("OfaSchlupfer");

            ModelSqlSchema schema = new ModelSqlSchema(result, "dbo").AddToParent();

            ModelSqlTable table = new ModelSqlTable(schema, "name").AddToParent();

            (new ModelSqlColumn(table, "key")).AddToParent();
            return result;
        }



        [TestMethod()]
        public void ModelSqlDatabase_ResolveTest() {
            var sut = GetTestModelSqlDatabase();
            {
                var act = sut.ResolveObject(SqlName.Schema("dbo"), null);
                Assert.IsNotNull(act);
                Assert.IsInstanceOfType(act, typeof(ModelSqlSchema));
                Assert.AreEqual("dbo", (act as ModelSqlSchema).Name.Name);
            }
            {
                var act = sut.ResolveObject(SqlName.Object("dbo", "name"), null);
                Assert.IsNotNull(act);
                Assert.IsInstanceOfType(act, typeof(ModelSqlTable));
                Assert.AreEqual("dbo.name", (act as ModelSqlTable).Name.GetQFullName(null, 2));
            }
            /*
            {
            var act = sut.GetObject(SqlName.Root.Child("OfaSchlupfer"));
            Assert.IsNotNull(act);
            }             
             */
        }
    }
}