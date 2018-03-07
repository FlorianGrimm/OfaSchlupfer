namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.SqlAccess;
    using Xunit;

    public class SqlSysDatabaseTests {
        [Fact]
        public void SqlSysDatabase_SqlSysDatabaseTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                sut.Dispose();
            }
        }


        [Fact]
        public void SqlSysDatabase_ReadServerTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadServer();
                Assert.NotNull(act);
            }
        }

        [Fact]
        public void SqlSysDatabase_ReadDatbasesTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadDatabases();
                Assert.True(act.Count > 1);
            }
        }

#if unsure
        [Fact]
        public void SqlSysDatabase_ReadSchemasTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadSchemas();
                Assert.True(act.Count > 4);
            }
        }
#endif


        [Fact]
        public void SqlSysDatabase_ReadAllTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadAllFromDatabase(null);
                Assert.True(act.AllObjectsById.Count > 0);
                Assert.True(act.GetTables().Count > 0);
                Assert.True(act.GetViews().Count > 0);
            }
        }

#if unsure

        [Fact]
        public void SqlSysDatabase_ReadAllObjectsTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadAllObjects();
                Assert.True(act.Count >= 1);
            }
        }

        [Fact]
        public void SqlSysDatabase_ReadTypesTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadTypes();
                Assert.True(act.Count >= 1);
            }
        }

        [Fact]
        public void SqlSysDatabase_ReadColumnsTest() {
            using (var sut = new SqlSysUtiltiy()) {
                sut.TransConnection = new SqlTransConnection(TestCfg.Get().ConnectionString);
                var act = sut.ReadColumns();
                Assert.True(act.Count >= 1);
            }
        }
#endif
    }
}