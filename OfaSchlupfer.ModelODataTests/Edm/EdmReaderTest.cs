namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class EdmReaderTest {

        [Fact]
        public void EdmReader_ProjectOnlinemetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            //serviceProvider.GetRequiredService<ODataV3RepositoryModel>();
            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");

            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var sut = new EdmReader(serviceProvider);
            sut.MetadataResolver = cachedMetadataResolver;

            var schema = sut.Read(srcPath);
            Assert.NotNull(schema);
            Assert.NotNull(sut.EdmxModel);
            Assert.NotNull(sut.EdmxModel.Version);

            //var schema = sut.ReadSchema(sr);
            //sut.ModelSchema = schema;

            //try {
            //    string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataV3RepositoryModelTest_ReadSchema.json");
            //    System.IO.File.WriteAllText(outputPath, Newtonsoft.Json.JsonConvert.SerializeObject(
            //        sut.ModelSchema,
            //        Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings {
            //            PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
            //        }));
            //} catch {
            //    throw;
            //}
        }

        [Fact]
        public void EdmReader_v3northwindmetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            //serviceProvider.GetRequiredService<ODataV3RepositoryModel>();
            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\v3northwindmetadata.xml");

            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var sut = new EdmReader(serviceProvider);
            sut.MetadataResolver = cachedMetadataResolver;

            var schema = sut.Read(srcPath);
            Assert.NotNull(schema);
            Assert.NotNull(sut.EdmxModel);
            Assert.NotNull(sut.EdmxModel.Version);

            //var schema = sut.ReadSchema(sr);
            //sut.ModelSchema = schema;

            //try {
            //    string outputPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\temp\ODataV3RepositoryModelTest_ReadSchema.json");
            //    System.IO.File.WriteAllText(outputPath, Newtonsoft.Json.JsonConvert.SerializeObject(
            //        sut.ModelSchema,
            //        Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings {
            //            PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
            //        }));
            //} catch {
            //    throw;
            //}
        }
    }
}
