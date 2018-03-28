namespace OfaSchlupfer.ODataV3Tests {
    using System;
    using Xunit;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using OfaSchlupfer.SPO;
    using OfaSchlupfer.ODataV3;

    public class ODataV3RepositoryModelTest {
        [Fact]
        public void ReadSchemaTest() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials();
            services.AddODataV3Repository();
            var serviceProvider = services.BuildServiceProvider();

            //serviceProvider.GetRequiredService<ODataV3RepositoryModel>();
            var sut = new ODataV3RepositoryImplementation();
            using (var sr = new System.IO.StreamReader(System.IO.Path.Combine(testCfg.SolutionFolder, @"test\metadata.xml"))) {
                var schema = sut.ReadSchema(sr);
                sut.ModelSchema = schema;
            }
            try {
                string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataV3RepositoryModelTest_ReadSchema.json");
                System.IO.File.WriteAllText(outputPath, Newtonsoft.Json.JsonConvert.SerializeObject(
                    sut.ModelSchema,
                    Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings {
                        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
                    }));
            } catch {
                throw;
            }
        }
    }
}
