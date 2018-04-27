namespace OfaSchlupfer.MSSQLReflection.Model {
    using Xunit;


    public class ModelSqlDatabaseTests {
        private static ModelSqlDatabase GetTestModelSqlDatabase() {
            ModelSqlServer modelSqlServer = new ModelSqlServer();
            modelSqlServer.Name = new SqlName(null, "default", ObjectLevel.Server);

            var serverScope = modelSqlServer.GetScope();

            var result = new ModelSqlDatabase(modelSqlServer, "OfaSchlupfer");
            result.Name = new SqlName(null, "OfaSchlupfer", ObjectLevel.Database);

            ModelSqlSchema schema = new ModelSqlSchema(result, "dbo");

            ModelSqlTable table = new ModelSqlTable(schema, "name");

            var col = (new ModelSqlColumn(table, "key"));
            return result;
        }

        [Fact]
        public void ModelSqlDatabase_ResolveTest() {
            var sut = GetTestModelSqlDatabase();
            {
                var act = sut.ResolveObject(SqlName.Schema("dbo"), null);
                Assert.NotNull(act);
                Assert.IsType<ModelSqlSchema>(act);
                Assert.Equal("dbo", (act as ModelSqlSchema).Name.Name);
            }
            {
                var act = sut.ResolveObject(SqlName.Object("dbo", "name"), null);
                Assert.NotNull(act);
                Assert.IsType<ModelSqlTable>(act);
                Assert.Equal("dbo.name", (act as ModelSqlTable).Name.GetQFullName(null, 2));
            }
            /*
            {
            var act = sut.GetObject(SqlName.Root.Child("OfaSchlupfer"));
            Assert.NotNull(act);
            }             
             */
        }
    }
}