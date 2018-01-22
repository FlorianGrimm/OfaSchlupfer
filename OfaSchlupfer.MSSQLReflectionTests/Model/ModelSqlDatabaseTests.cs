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
            modelSqlServer.Name = SqlName.Root.ChildWellkown("localhost");

            var serverScope = modelSqlServer.GetScope();

            var result = new ModelSqlDatabase(modelSqlServer, "OfaSchlupfer").AddToParent();
            result.Name = SqlName.Root.ChildWellkown("OfaSchlupfer");

            ModelSqlSchema schema = new ModelSqlSchema(result, "dbo").AddToParent();

            ModelSqlTable table = new ModelSqlTable(schema, "name").AddToParent();

            (new ModelSqlColumn(table, "key")).AddToParent();
            return result;
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetSchemasTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetTypesTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetTablesTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetSchemaByNameTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetTypeByNameTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetTableByNameTest() {
        }

        [TestMethod()]
        public void ModelSqlDatabase_GetObjectTest() {
            var sut = GetTestModelSqlDatabase();
            {
                var act = sut.GetObject(SqlName.Root.Child("dbo"), ObjectLevel.Schema);
                Assert.IsNotNull(act as ModelSqlSchema);
                Assert.AreEqual("dbo", (act as ModelSqlSchema).Name.Name);
            }
            /*
            {
            var act = sut.GetObject(SqlName.Root.Child("OfaSchlupfer"));
            Assert.IsNotNull(act);
            }             
             */
        }

        [TestMethod()]
        public void ModelSqlDatabase_ResolveTest() {
        }
    }
}