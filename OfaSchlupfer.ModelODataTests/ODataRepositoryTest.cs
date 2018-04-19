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
            //services.AddHttpClient((builder) => {
            //    // builder.Logger= 
            //    // TODO: TODO Add Credentials
            //    //builder.AddSharePointOnlineCredentials
            //});
            services.AddServiceClientCredentials((builder) => { });
            services.AddOfaSchlupferODataRepository();
            services.AddOfaSchlupferModel();
            services.AddOfaSchlupferEntity();

            var serviceProvider = services.BuildServiceProvider();

            var modelRoot = new ModelRoot(serviceProvider);
            var modelRepository1 = modelRoot.CreateRepository("one", "OData");

            var modelRepository2 = modelRoot.CreateRepository("two", "OData");

            var odataRepository1 = modelRepository1.GetReferenceRepositoryModel();
            var odataRepository2 = modelRepository2.GetReferenceRepositoryModel();
            Assert.NotNull(odataRepository1);
            Assert.NotNull(odataRepository2);
        }

#if lateragain
        [Fact]
        public void ODataRepository_GetUrlMetadata() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("/_api/ProjectData/[en-us]");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            var sut = new ODataRepositoryImplementation(null);
            sut.SetConnectionString(testCfg.ProjectServer, "/_api/ProjectData/[en-us]");
            Assert.NotEqual("", sut.GetUrlMetadata());
            Assert.StartsWith("http", sut.GetUrlMetadata());
            Assert.EndsWith("$metadata", sut.GetUrlMetadata());
        }
#endif

#if lateragain
        [Fact]
        public void ODataRepository_GetMetadata() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.SolutionFolder));
            var contentMetaDataXml = ReadMetaDataXml(testCfg);

            var modelRepository = new ModelRepository();
            var sut = new ODataRepositoryImplementation(null);
            modelRepository.ReferenceRepositoryModel = sut;
            sut.SetConnectionString(testCfg.ProjectServer, "/_api/ProjectData/[en-us]");
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
#endif
        private static string ReadMetaDataXml(TestCfg testCfg) {
            string content;
            var metadataPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            using (var reader = new System.IO.StreamReader(metadataPath)) {
                content = reader.ReadToEnd();
            }

            return content;
        }
    }
}
