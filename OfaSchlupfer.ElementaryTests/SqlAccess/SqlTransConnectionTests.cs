namespace OfaSchlupfer.SqlAccess {
    using System;
    using System.Data.SqlClient;
    using Xunit;

    public class SqlTransConnectionTests {
        [Fact]
        public void TestCfg_Get() {
            var testCfg = TestCfg.Get();
            Assert.NotNull(testCfg);
            Assert.True(!string.IsNullOrEmpty(testCfg.ConnectionString));
        }

        [Fact]
        public void SqlTransConnection_ctor() {
            using (var sut = new SqlTransConnection((SqlConnection)null, null)) {
                Assert.Null(sut.Connection);
                Assert.Null(sut.Transaction);
            }
            using (var sut = new SqlTransConnection(new SqlConnection(), null)) {
                Assert.NotNull(sut.Connection);
                Assert.Null(sut.Transaction);
            }
            var csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".";
            csb.InitialCatalog = "master";
            using (var sut = new SqlTransConnection(csb.ConnectionString)) {
                Assert.NotNull(sut.Connection);
                Assert.Null(sut.Transaction);
            }
        }

        [Fact]
        public void SqlTransConnection_OpenCloseTest() {
            using (var sut = new SqlTransConnection(TestCfg.Get().ConnectionString)) {
                sut.Open();
                Assert.Equal(System.Data.ConnectionState.Open, sut.Connection.State);
                sut.Close();
                Assert.Equal(System.Data.ConnectionState.Closed, sut.Connection.State);
            }
        }

        [Fact]
        public void SqlTransConnection_BeginTransactionTest() {
            using (var sut = new SqlTransConnection(TestCfg.Get().ConnectionString)) {
                sut.Open();
                Assert.Equal(System.Data.ConnectionState.Open, sut.Connection.State);
                var t = sut.BeginTransaction(System.Data.IsolationLevel.Unspecified, "T");
                sut.Commit(null);
                Assert.NotNull(sut.Transaction);
                sut.Commit(t);
                sut.Close();
                Assert.Equal(System.Data.ConnectionState.Closed, sut.Connection.State);
            }
        }

    }
}
