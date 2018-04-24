namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    using OfaSchlupfer.Entity;

    using Xunit;
    using Xunit.Abstractions;

    public class MappingModelBuilderTest {
        private readonly ITestOutputHelper output;
        public MappingModelBuilderTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void MappingModelBuilder_1_Test() {
            var testCfg = TestCfg.Get();
            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlineModelSchema.json");

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddOfaSchlupferModel();
            services.AddOfaSchlupferEntity();
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope()) {
                var scopedServiceProvider = scope.ServiceProvider;
                var modelRoot = scopedServiceProvider.GetRequiredService<ModelRoot>();
                var modelRepositorySource = modelRoot.CreateRepository("Source", null);
                var modelRepositoryTarget = modelRoot.CreateRepository("Target", null);

                var mappingModelRepository = new MappingModelRepository();
                mappingModelRepository = modelRoot.CreateMapping("SourceTarget", modelRepositorySource, modelRepositoryTarget);

                var jsonContent = System.IO.File.ReadAllText(srcPath);
                var modelSchemaSource = ModelJsonUtility.DeserializeModelFromJson<ModelSchema>(jsonContent, null);
                Assert.NotNull(modelSchemaSource);
                modelRepositorySource.ModelSchema = modelSchemaSource;

                var modelSchemaTarget = new ModelSchema();
                modelRepositoryTarget.ModelSchema = modelSchemaTarget;

                var mappingModelBuilder = new MappingModelBuilder();
                mappingModelBuilder.MappingModelRepository = mappingModelRepository;

                var errors = new ModelErrors();
                mappingModelBuilder.Build(errors);

                if (errors.HasErrors()) { output.WriteLine(errors.ToString()); }
                Assert.False(errors.HasErrors());

                {
                    var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    serializeSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
                    serializeSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                    var schemaAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(modelRoot, Newtonsoft.Json.Formatting.Indented, serializeSettings);
                    try {
                        string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\MappingModelBuilder_1_Test.json");
                        System.IO.File.WriteAllText(outputPath, schemaAsJson);
                    } catch {
                        throw;
                    }
                }
            }
        }
    }
}
