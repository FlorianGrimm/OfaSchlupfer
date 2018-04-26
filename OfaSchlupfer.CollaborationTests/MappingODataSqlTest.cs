namespace OfaSchlupfer.CollaborationTests {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Rest.Azure;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.ModelOData;
    using OfaSchlupfer.ModelOData.Edm;
    using OfaSchlupfer.ModelOData.ODataAccess;
    using OfaSchlupfer.ModelSql;
    using OfaSchlupfer.SPO;

    using Xunit;
    using Xunit.Abstractions;

    public class MappingODataSqlTest {
        private readonly ITestOutputHelper output;
        public MappingODataSqlTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void Mapping_OData_SQL_ProjectOnlinemetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();

            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("/_api/ProjectData/[en-us]");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddOfaSchlupferModel();
            services.AddOfaSchlupferEntity();
            services.AddOfaSchlupferODataRepository();
            services.AddSqlRepository();
            services.AddServiceClientCredentials((builder) => { });
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope()) {
                var scopedServiceProvider = scope.ServiceProvider;
                var modelRoot = scopedServiceProvider.GetRequiredService<ModelRoot>();
                var modelRepositorySource = modelRoot.CreateRepository("Source", "OData");
                var modelDefininition = modelRepositorySource.CreateModelDefinition(null);
                Assert.Same(modelDefininition, modelRepositorySource.ModelDefinition);
                modelDefininition.MetaData = System.IO.File.ReadAllText(srcPath);


                var oDataRepositorySource = (ODataRepositoryImplementation)modelRepositorySource.GetReferenceRepositoryModel();
                Assert.NotNull(oDataRepositorySource);
                Assert.Same(modelRepositorySource, oDataRepositorySource.Owner);
                Assert.NotNull(oDataRepositorySource.GetEdmxModel());

                var modelSchemaSource = modelRepositorySource.GetModelSchema(null, null);
                Assert.NotNull(modelSchemaSource);

                EntitySchema entitySchema = modelRepositorySource.ModelSchema.GetEntitySchema();
                Assert.NotNull(entitySchema);

                var modelRepositoryTarget = modelRoot.CreateRepository("Target", "SQL");
                var sqlRepositoryTarget = (SqlRepositoryImplementation)modelRepositoryTarget.GetReferenceRepositoryModel();
                sqlRepositoryTarget.ConnectionString = testCfg.SQLConnectionString;

                Assert.NotNull(sqlRepositoryTarget);

                {
                    var metaModelBuilder = new MetaModelBuilder();
                    var errors = new ModelErrors();
                    var modelSchemaTarget = modelRepositoryTarget.GetModelSchema(metaModelBuilder, errors);
                    Assert.NotNull(modelSchemaTarget);
                    
                    if (errors.HasErrors()) { this.output.WriteLine(errors.ToString()); }
                    Assert.False(errors.HasErrors());

                    Assert.NotNull(modelSchemaTarget);
                    Assert.True(modelSchemaTarget.Entities.Count > 0);
                    Assert.True(modelSchemaTarget.ComplexTypes.Count > 0);
                }
                
                {
                    var mappingModelRepositorySourceTarget = modelRoot.CreateMapping("SourceTarget", modelRepositorySource, modelRepositoryTarget);
                    var mappingModelSchema = mappingModelRepositorySourceTarget.CreateMappingModelSchema("SourceTarget", modelRepositorySource.ModelSchema, modelRepositoryTarget.ModelSchema, true, false, "");

                    var mappingModelBuilder = new MappingModelBuilder();
                    mappingModelBuilder.MappingModelRepository = mappingModelRepositorySourceTarget;

                    var errors = new ModelErrors();
                    mappingModelBuilder.EnabledForCreatedMappings = true;
                    mappingModelBuilder.Comment = "Mapping_OData_SQL_ProjectOnlinemetadata_Test";
                    mappingModelBuilder.Build(errors);

                    if (errors.HasErrors()) { this.output.WriteLine(errors.ToString()); }
                    Assert.False(errors.HasErrors());

                    foreach (var modelEntityTarget in modelRepositoryTarget.ModelSchema.Entities) {
                        Assert.NotNull(modelEntityTarget.EntityTypeName);
                        Assert.NotNull(modelEntityTarget.EntityType);
                    }

                    foreach (var modelComplexTypesTarget in modelRepositoryTarget.ModelSchema.ComplexTypes) {
                        if (modelComplexTypesTarget.Properties.Count == 0) {
                            var message = $"{modelComplexTypesTarget.Name} has no properties";
                            this.output.WriteLine(message);
                            Assert.Equal("Error", message);
                        }
                    }
                }

                {
#warning HEEEEEEEEEEEEEEERE
                    var metaModelBuilder = new MetaModelBuilder();
                    var errors = new ModelErrors();
                    var sqlModelSchemaBuilder = new SqlModelSchemaBuilder();
                    sqlModelSchemaBuilder.BuildModelSqlDatabase(
                        modelRepositoryTarget.ModelSchema,
                        sqlRepositoryTarget.ModelDatabase,
                        metaModelBuilder,
                        errors
                        );
                    if (errors.HasErrors()) { this.output.WriteLine(errors.ToString()); }
                    Assert.False(errors.HasErrors());
                }
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
                        string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\Mapping_OData_SQL_ProjectOnlinemetadata_Test-root.json");
                        System.IO.File.WriteAllText(outputPath, schemaAsJson);
                    } catch {
                        throw;
                    }
                }

                
                {
                    var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    serializeSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
                    serializeSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects;
                    serializeSettings.Converters.Add(new OfaSchlupfer.MSSQLReflection.Model.SqlNameJsonConverter());
                    //serializeSettings.Converters.Add(new OfaSchlupfer.MSSQLReflection.Model.ModelSqlTableJsonConverter());
                    //serializeSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                    //serializeSettings.TraceWriter = new XunitTraceWriter(output);
                    try {
                        var schemaAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(sqlRepositoryTarget.ModelDatabase, Newtonsoft.Json.Formatting.Indented, serializeSettings);
                        string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\Mapping_OData_SQL_ProjectOnlinemetadata_Test-target-ModelDatabase.json");
                        System.IO.File.WriteAllText(outputPath, schemaAsJson);
                    } catch (Exception error) {
                        this.output.WriteLine(error.ToString());
                        throw;
                    }
                }
            }
        }
    }
}
