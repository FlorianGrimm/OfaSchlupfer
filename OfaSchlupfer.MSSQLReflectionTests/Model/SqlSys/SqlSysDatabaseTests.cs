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
        public void SqlSysDatabase_ReadServerTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadServer();
                Assert.IsNotNull(act);
            }
        }

        [TestMethod()]
        public void SqlSysDatabase_ReadDatbasesTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadDatabases();
                Assert.IsTrue(act.Count > 1);
            }
        }

#if unsure
        [TestMethod()]
        public void SqlSysDatabase_ReadSchemasTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadSchemas();
                Assert.IsTrue(act.Count > 4);
            }
        }
#endif


        [TestMethod()]
        public void SqlSysDatabase_ReadAllTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadAllFromDatabase(null);
                Assert.IsTrue(act.AllObjectsById.Count > 0);
                Assert.IsTrue(act.GetTables().Count > 0);
                Assert.IsTrue(act.GetViews().Count > 0);
            }
        }

#if unsure

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
                var act = sut.ReadColumns();
                Assert.IsTrue(act.Count >= 1);
            }
        }
#endif
    }
}