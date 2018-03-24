namespace OfaSchlupfer.ModelOData {
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.Model;
    using Xunit;

    public class ODataRepositoryTest {
        [Fact]
        public void ODataRepository_BigPicture() {
            var testCfg = TestCfg.Get();
            var contentMetaDataXml = ReadMetaDataXml(testCfg);

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials();
            services.AddODataRepository();
            var serviceProvider = services.BuildServiceProvider();

            var modelRoot = new ModelRoot();
            var modelRepository1 = new ModelRepository();
            modelRepository1.Name = new ModelEntityName(null, null, "one");
            modelRepository1.RepositoryType = "OData";

            var modelRepository2 = new ModelRepository();
            modelRepository2.Name = new ModelEntityName(null, null, "two");
            modelRepository2.RepositoryType = "OData";

            modelRoot.Repositories.Add(modelRepository1);
            modelRoot.Repositories.Add(modelRepository2);

            var odataRepository1 = modelRepository1.GetReferenceRepositoryModel(serviceProvider);
            var odataRepository2 = modelRepository2.GetReferenceRepositoryModel(serviceProvider);
            Assert.NotNull(odataRepository1);
            Assert.NotNull(odataRepository2);

            //modelRepository1.ModelDefinition.
            //var oDataRepository = serviceProvider.GetRequiredService<ODataRepository>();
            //oDataRepository.ConnectionString = testCfg.ProjectServer;
            //oDataRepository.BuildSchema(contentMetaDataXml);


        }


        [Fact]
        public void ODataRepository_GetUrlMetadata() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            var sut = new ODataRepositoryImplementation(null);
            sut.ConnectionString = testCfg.ProjectServer;
            Assert.NotEqual("", sut.GetUrlMetadata());
            Assert.StartsWith("http", sut.GetUrlMetadata());
            Assert.EndsWith("$metadata", sut.GetUrlMetadata());
        }

        [Fact]
        public void ODataRepository_GetMetadata() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.SolutionFolder));
            var contentMetaDataXml = ReadMetaDataXml(testCfg);

            var modelRepository = new ModelRepository();
            var sut = new ODataRepositoryImplementation(null);
            modelRepository.ReferenceRepositoryModel = sut;
            sut.ConnectionString = testCfg.ProjectServer;
            sut.BuildSchema(contentMetaDataXml);
            try {
                string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataRepository_GetMetadata.json");
                System.IO.File.WriteAllText(outputPath, Newtonsoft.Json.JsonConvert.SerializeObject(
                    sut.ModelSchema,
                    Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings {
                        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
                    }));
            } catch {
                throw;
            }
        }

#if longrunning
        [Fact]
        public async Task ODataRepository_GetMetadataFromSPO() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials();
            services.AddTransient<ODataRepository>();
            var serviceProvider = services.BuildServiceProvider();

            var sut = serviceProvider.GetService<ODataRepository>();
            sut.ConnectionString = testCfg.ProjectServer;
            var metadataContent = await sut.GetMetadataAsync();
            Assert.StartsWith("<", metadataContent);
            sut.ReadSchema(new System.IO.StringReader(metadataContent));
        }
#endif

        private static string ReadMetaDataXml(TestCfg testCfg) {
            string content;
            var metadataPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\metadata.xml");
            using (var reader = new System.IO.StreamReader(metadataPath)) {
                content = reader.ReadToEnd();
            }

            return content;
        }
    }
}
