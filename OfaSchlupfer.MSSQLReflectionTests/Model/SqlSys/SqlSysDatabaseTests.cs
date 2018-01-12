namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;

    [TestClass()]
    public class SqlSysDatabaseTests {
        [TestMethod()]
        public void SqlSysDatabase_SqlSysDatabaseTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                sut.Dispose();
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadAllTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                sut.ReadAllFromDatbase(null);
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadSchemasTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadSchemas();
                Assert.IsTrue(act.Count > 4);
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadAllObjectsTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadAllObjects();
                Assert.IsTrue(act.Count >= 1);
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadTypesTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadTypes();
                Assert.IsTrue(act.Count >= 1);
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadColumnsTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                sut.ReadColumns();
            }
        }
    }
}