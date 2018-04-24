namespace OfaSchlupfer.CollaborationTests {
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Rest.Azure;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.ModelOData;
    using OfaSchlupfer.ModelOData.Edm;
    using OfaSchlupfer.ModelOData.ODataAccess;
    using OfaSchlupfer.SPO;

    using Xunit;
    using Xunit.Abstractions;

    public class MappingTest {
        private readonly ITestOutputHelper output;
        public MappingTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void MappingTest1() {
            var testCfg = OfaSchlupfer.TestCfg.Get();

            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("/_api/ProjectData/[en-us]");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddOfaSchlupferModel();
            services.AddOfaSchlupferEntity();
            services.AddServiceClientCredentials((builder) => { });
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();
            
            using (var scope = serviceProvider.CreateScope()) {
                var scopedServiceProvider = scope.ServiceProvider;
                var modelRoot = scopedServiceProvider.GetRequiredService<ModelRoot>();
                var modelRepositorySource = modelRoot.CreateRepository("Source", "OData");

                var cachedMetadataResolver = new CachedMetadataResolver();
                cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
                var edmReader = new EdmReader(serviceProvider);
                edmReader.MetadataResolver = cachedMetadataResolver;
                var edmxModel = edmReader.Read(srcPath, true, null);

                var oDataRepositorySource = new ODataRepositoryImplementation();
                modelRepositorySource.ReferencedRepositoryModel = oDataRepositorySource;
                oDataRepositorySource.EdmxModel = edmxModel;

                Assert.NotNull(modelRepositorySource.GetModelSchema());

          

                var modelSchemaSource = modelRepositorySource.ModelSchema;
                Assert.NotNull(modelSchemaSource);
                EntitySchema entitySchema = modelRepositorySource.ModelSchema.GetEntitySchema();
                Assert.NotNull(entitySchema);
                var modelRepositoryTarget = modelRoot.CreateRepository("Target", null);

                var mappingModelRepository = new MappingModelRepository();
                mappingModelRepository = modelRoot.CreateMapping("SourceTarget", modelRepositorySource, modelRepositoryTarget);

                var modelSchemaTarget = new ModelSchema();
                modelRepositoryTarget.ModelSchema = modelSchemaTarget;

                var mappingModelBuilder = new MappingModelBuilder();
                mappingModelBuilder.MappingModelRepository = mappingModelRepository;

                var errors = new ModelErrors();
                mappingModelBuilder.Build(errors);

                if (errors.HasErrors()) { output.WriteLine(errors.ToString()); }
                Assert.False(errors.HasErrors());

                var cred = new SharePointOnlineServiceClientCredentials(repCSProjectServer, null);
                var oDataClient = new ODataServiceClient(new Uri(repCSProjectServer.GetUrlNormalized()), cred, null);
                oDataClient.ModelRepository = modelRepositorySource;

                var oDataRequest = oDataClient.Query("Projects");
                // oDataClient.ConnectionString = repCSProjectServer;
                // oDataClient.SetConnectionString(repCSProjectServer, "/_api/ProjectData/[en-us]");

                var srcPathData = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlineData-Projects.json");
                var responceContentString = System.IO.File.ReadAllText(srcPathData);

                var operationResponse = new AzureOperationResponse<ODataRequest>();
                operationResponse.Request = new System.Net.Http.HttpRequestMessage();
                operationResponse.Response = new System.Net.Http.HttpResponseMessage() { Content = new System.Net.Http.StringContent(responceContentString) };

                ODataDeserializtion d = new ODataDeserializtion(oDataRequest, oDataClient);
                var deserializeResult = d.Deserialize(responceContentString);
                Assert.NotNull(deserializeResult);
                Assert.IsType<List<IEntity>>(deserializeResult);
                var lstEntity = deserializeResult as List<IEntity>;
                Assert.Equal(60, lstEntity.Count);

                {
                    var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    serializeSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
                    serializeSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                    var schemaAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(modelRoot, Newtonsoft.Json.Formatting.Indented, serializeSettings);
                    try {
                        string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\MappingTest1.json");
                        System.IO.File.WriteAllText(outputPath, schemaAsJson);
                    } catch {
                        throw;
                    }
                }
            }
        }
    }
}
