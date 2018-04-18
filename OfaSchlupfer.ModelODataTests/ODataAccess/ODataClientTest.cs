namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Rest.Azure;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.ModelOData.Edm;
    using OfaSchlupfer.SPO;
    using Xunit;

    public class ODataClientTest {
#if !LongRunning
        [Fact]
        [Trait("Category", "hot")]
        public async Task ODataClient_1_Test() {
            await _ODataClient_1_Test();
        }
#endif

        private async Task _ODataClient_1_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("/_api/ProjectData/[en-us]");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddServiceClientCredentials((builder) => { });
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var edmxModel = edmReader.Read(srcPath, true, null);

            var modelDefinition = new ModelDefinition();
            modelDefinition.Kind = "OData";
            modelDefinition.MetaData = "";

            //var clientFactory = serviceProvider.GetRequiredService<IHttpClientDispatcherFactory>();
            //var oDataClient = new ODataClient(clientFactory, serviceProvider);
            //oDataClient.EdmxModel = edmxModel;

            var cred = new SharePointOnlineServiceClientCredentials(repCSProjectServer, null);
            var oDataClient = new ODataServiceClient(new Uri(repCSProjectServer.GetUrlNormalized()), cred, null);

            var modelRoot = new ModelRoot();

            EdmxModelSchemaBuilder edmxModelBuilder = new EdmxModelSchemaBuilder();
            var modelSchema = edmxModelBuilder.Build(edmxModel, null, null, null);
            var modelRepository = new ModelRepository();
            //modelRepository.ModelDefinition = modelDefinition;
            modelRepository.ModelSchema = modelSchema;
            modelRepository.Name = "PS";
            modelRoot.Repositories.Add(modelRepository);

            oDataClient.ModelRepository = new ModelRepository();
            //var builder = new ModelBuilder();
            //oDataClient.EdmxModel = edmxModel;

            var oDataRequest = oDataClient.Query("Projects");
            // oDataClient.ConnectionString = repCSProjectServer;
            // oDataClient.SetConnectionString(repCSProjectServer, "/_api/ProjectData/[en-us]");
            var t = oDataClient.SendAsync<string>("Projects", oDataRequest, async (aor, dr) => {
                string responseContent = await aor.Response.Content.ReadAsStringAsync();
                aor.Body = responseContent;
            }, CancellationToken.None);

            var oDataResponce = await t;
            Assert.NotNull(oDataResponce);
            Assert.NotNull(oDataResponce.Body);
            Assert.StartsWith("{\"d\"", oDataResponce.Body);
            //var httpClient = clientFactory.CreateHttpClient(repCSProjectServer)
        }

        [Fact]
        [Trait("Category", "hot")]
        public void ODataClient_2_Translate_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("/_api/ProjectData/[en-us]");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddServiceClientCredentials((builder) => { });
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;
            var edmxModel = edmReader.Read(srcPath, true, null);

            var modelRoot = new ModelRoot();
            var modelRepository = new ModelRepository();
            modelRepository.Name = "ProjectServer";
            modelRoot.Repositories.Add(modelRepository);

            var oDataRepository = new ODataRepositoryImplementation();
            modelRepository.ReferenceRepositoryModel = oDataRepository;
            oDataRepository.EdmxModel = edmxModel;

            Assert.NotNull(modelRepository.GetModelSchema());

            var cred = new SharePointOnlineServiceClientCredentials(repCSProjectServer, null);
            var oDataClient = new ODataServiceClient(new Uri(repCSProjectServer.GetUrlNormalized()), cred, null);
            oDataClient.ModelRepository = modelRepository;

            // TODO: here soon //oDataClient.EdmxModel = edmxModel;

            var oDataRequest = oDataClient.Query("Projects");
            // oDataClient.ConnectionString = repCSProjectServer;
            // oDataClient.SetConnectionString(repCSProjectServer, "/_api/ProjectData/[en-us]");

            var srcPathData = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlineData-Projects.json");
            var responceContentString = System.IO.File.ReadAllText(srcPathData);

            var operationResponse = new AzureOperationResponse<ODataRequest>();
            operationResponse.Request = new System.Net.Http.HttpRequestMessage();
            operationResponse.Response = new System.Net.Http.HttpResponseMessage() { Content = new System.Net.Http.StringContent(responceContentString) };

            //ODataResponce oDataResponce = new ODataResponce();
            //oDataResponce.ResponceContentString = System.IO.File.ReadAllText(srcPathData);

            ODataDeserializtion d = new ODataDeserializtion(oDataRequest, oDataClient);
            var deserializeResult = d.Deserialize(responceContentString);
            Assert.NotNull(deserializeResult);
            Assert.IsType<List<IEntity>>(deserializeResult);
            var lstEntity = deserializeResult as List<IEntity>;
            Assert.Equal(60, lstEntity.Count);

            Assert.NotNull(modelRepository.ModelSchema);
            EntitySchema entitySchema = modelRepository.ModelSchema.GetEntitySchema();
            Assert.NotNull(entitySchema);

            {
                var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                serializeSettings.Converters.Add(new EntityJsonConverter());
                var rejson = Newtonsoft.Json.JsonConvert.SerializeObject(lstEntity, Newtonsoft.Json.Formatting.Indented, serializeSettings);
                try {
                    string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataClient_2_Translate_Test_Data.json");
                    System.IO.File.WriteAllText(outputPath, rejson);
                } catch {
                    throw;
                }

                // var entitySchema = new EntitySchema(null);
                // entitySchema.Add(null, lstEntity[0].MetaData);

                var deserializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                deserializeSettings.Converters.Add(new EntityJsonConverter(entitySchema));
                var reDeserializeResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IEntity>>(rejson, deserializeSettings);
                Assert.NotNull(reDeserializeResult);
                Assert.IsType<List<IEntity>>(reDeserializeResult);
            }
            {
                var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                serializeSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
                serializeSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                var schemaAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(entitySchema, Newtonsoft.Json.Formatting.Indented, serializeSettings);
                try {
                    string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataClient_2_Translate_Test_EntitySchema.json");
                    System.IO.File.WriteAllText(outputPath, schemaAsJson);
                } catch {
                    throw;
                }
            }
        }
    }
}
