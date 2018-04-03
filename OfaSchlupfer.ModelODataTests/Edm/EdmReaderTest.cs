#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.

namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            var edmxModel = sut.Read(srcPath, null);
            Assert.NotNull(edmxModel);
            Assert.NotNull(edmxModel.Version);
            Assert.Equal(3, edmxModel.DataServices.Count);
            Assert.Equal(0, edmxModel.DataServices[0].EntityContainer.Count);
            Assert.Equal(1, edmxModel.DataServices[1].EntityContainer.Count);

            var entitySets = edmxModel.DataServices
                .SelectMany((schema) => schema.EntityContainer)
                .SelectMany((entityContainer) => entityContainer.EntitySet).ToArray();
            foreach (var entitySet in entitySets) {
                Assert.NotNull(entitySet.EntityTypeModel);
            }

            var properties = entitySets
                .SelectMany((entitySet)=> entitySet.EntityTypeModel.Property)
                .ToArray();
            foreach (var property in properties) {
                Assert.NotNull(property.TypeName);
            }

            var associationSets = edmxModel.DataServices
                .SelectMany((schema) => schema.EntityContainer)
                .SelectMany((entityContainer) => entityContainer.AssociationSet).ToArray();
            foreach (var associationSet in associationSets) {
                Assert.NotNull(associationSet.Name);
                Assert.NotNull(associationSet.AssociationName);
                Assert.NotNull(associationSet.AssociationModel);
            }

            var associationSetEnds = edmxModel.DataServices
                .SelectMany((schema) => schema.EntityContainer)
                .SelectMany((entityContainer) => entityContainer.AssociationSet)
                .SelectMany((associationSet) => associationSet.End)
                .ToArray();
            foreach (var end in associationSetEnds) {
                Assert.NotNull(end);
                Assert.NotNull(end.EntitySetName);
                Assert.NotNull(end.EntitySetModel);
            }
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

            var edmxModel = sut.Read(srcPath, null);
            Assert.NotNull(edmxModel);
            Assert.NotNull(edmxModel.Version);
            Assert.Equal(3, edmxModel.DataServices.Count);

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
        public void EdmReader_v4northwindmetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            //serviceProvider.GetRequiredService<ODataV3RepositoryModel>();
            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\v4northwindmetadata.xml");

            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var sut = new EdmReader(serviceProvider);
            sut.MetadataResolver = cachedMetadataResolver;

            var edmxModel = sut.Read(srcPath, null);
            Assert.NotNull(edmxModel);
            Assert.NotNull(edmxModel.Version);
            Assert.Equal(3, edmxModel.DataServices.Count);

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
