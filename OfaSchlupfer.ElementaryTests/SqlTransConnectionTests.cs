namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.Elementary;

    [TestClass()]
    public class SqlTransConnectionTests {
        [TestMethod()]
        public void SqlTransConnection_ctor() {
            using (var sut = new SqlTransConnection((SqlConnection)null, null)) {
                Assert.IsNull(sut.Connection);
                Assert.IsNull(sut.Transaction);
            }
            using (var sut = new SqlTransConnection(new SqlConnection(), null)) {
                Assert.IsNotNull(sut.Connection);
                Assert.IsNull(sut.Transaction);
            }
            var csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".";
            csb.InitialCatalog = "master";
            using (var sut = new SqlTransConnection(csb.ConnectionString)) {
                Assert.IsNotNull(sut.Connection);
                Assert.IsNull(sut.Transaction);
            }
        }

        [TestMethod()]
        public void SqlTransConnection_OpenCloseTest() {
            using (var sut = new SqlTransConnection(TestCfg.Get().ConnectionString)) {
                sut.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, sut.Connection.State);
                sut.Close();
                Assert.AreEqual(System.Data.ConnectionState.Closed, sut.Connection.State);
            }
        }

        [TestMethod()]
        public void SqlTransConnection_BeginTransactionTest() {
            using (var sut = new SqlTransConnection(TestCfg.Get().ConnectionString)) {
                sut.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, sut.Connection.State);
                var t = sut.BeginTransaction(System.Data.IsolationLevel.Unspecified, "T");
                sut.Commit(null);
                Assert.IsNotNull(sut.Transaction);
                sut.Commit(t);
                sut.Close();
                Assert.AreEqual(System.Data.ConnectionState.Closed, sut.Connection.State);
            }
        }

#if false
        [TestMethod()]
        public void SqlTransConnection_CommitTest() {

        }

        [TestMethod()]
        public void SqlTransConnection_RollbackTest() {

        }

        [TestMethod()]
        public void SqlTransConnection_SqlCommandTest() {

        }
#endif
    }
}