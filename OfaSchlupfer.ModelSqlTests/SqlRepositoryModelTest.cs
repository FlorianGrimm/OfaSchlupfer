namespace OfaSchlupfer.ModelSql {
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.Model;
    using Xunit;
    using Xunit.Abstractions;

    public class SqlRepositoryModelTest {
        private readonly ITestOutputHelper output;
        public SqlRepositoryModelTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void SqlRepositoryImplementation_ReadSQLSchema_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repSQLConnectionString = testCfg.SQLConnectionString;


            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            var modelRoot = new ModelRoot();
            var modelRepository = new ModelRepository();
            modelRepository.Name = "ProjectServerSQL";
            modelRoot.Repositories.Add(modelRepository);

            SqlRepositoryModel sqlRepository = new SqlRepositoryImplementation();
            sqlRepository.ConnectionString = repSQLConnectionString;
            modelRepository.ReferenceRepositoryModel = sqlRepository;

            var errors = new ModelErrors();
            MetaModelBuilder metaModelBuilder = new MetaModelBuilder();

            sqlRepository.ReadSQLSchema(metaModelBuilder, errors);

            if (errors.HasErrors()) { output.WriteLine(errors.ToString()); }
            Assert.False(errors.HasErrors());

            Assert.NotNull(sqlRepository.ModelSchema);
            Assert.True(sqlRepository.ModelSchema.ComplexTypes.Count > 0);


        }
    }
}
