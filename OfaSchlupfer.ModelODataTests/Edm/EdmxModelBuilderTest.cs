namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using OfaSchlupfer.Model;

    using Xunit;
    using Xunit.Abstractions;

    public class EdmxModelBuilderTest {
        private readonly ITestOutputHelper output;

        public EdmxModelBuilderTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void EdmxModelBuilder_ProjectOnlinemetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var errors = new ModelErrors();
            var edmxModel = edmReader.Read(srcPath, true, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Read HasErrors", errors.ToString());
            }

            EdmxModelSchemaBuilder edmxModelBuilder = new EdmxModelSchemaBuilder();
            var modelSchema = edmxModelBuilder.Build(edmxModel, null, null, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Builder HasErrors", errors.ToString());
            }

            var defaultEntityContainer = edmxModel.DataServices.SelectMany(_ => _.EntityContainer).FirstOrDefault(_ => _.IsDefaultEntityContainer);
            Assert.Equal(defaultEntityContainer.EntitySet.Count, modelSchema.Entities.Count);
            foreach (var entity in modelSchema.Entities) {
                if (entity.EntityType == null) {
                    throw new Xunit.Sdk.XunitException($"{entity.Name} has no EntityType.");
                }
                Assert.True(entity.EntityType.Properties.Count > 0);
                foreach (var property in entity.EntityType.Properties) {
                    Assert.NotNull(property.Name);
                    Assert.NotNull(property.Type);
                    //if (string.IsNullOrEmpty(property.Name)) {
                    //    property.Type
                    //}
                }
                foreach (var navigationProperty in entity.EntityType.NavigationProperty) {
                    Assert.NotNull(navigationProperty.Name);
                    Assert.NotNull(navigationProperty.ExternalName);
                    Assert.NotNull(navigationProperty.ItemType);
                }
            }
        }


        [Fact]
        public void EdmxModelBuilder_v3northwindmetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\v3northwindmetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var errors = new ModelErrors();
            var edmxModel = edmReader.Read(srcPath, true, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Read HasErrors", errors.ToString());
            }

            EdmxModelSchemaBuilder edmxModelBuilder = new EdmxModelSchemaBuilder();
            var modelSchema = edmxModelBuilder.Build(edmxModel, null, null, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Builder HasErrors", errors.ToString());
            }

            var defaultEntityContainer = edmxModel.DataServices.SelectMany(_ => _.EntityContainer).FirstOrDefault(_ => _.IsDefaultEntityContainer);
            Assert.Equal(defaultEntityContainer.EntitySet.Count, modelSchema.Entities.Count);
            foreach (var entity in modelSchema.Entities) {
                if (entity.EntityType == null) {
                    throw new Xunit.Sdk.XunitException($"{entity.Name} has no EntityType.");
                }
                Assert.True(entity.EntityType.Properties.Count > 0);
                foreach (var property in entity.EntityType.Properties) {
                    Assert.NotNull(property.Name);
                    Assert.NotNull(property.Type);
                    //if (string.IsNullOrEmpty(property.Name)) {
                    //    property.Type
                    //}
                }
                foreach (var navigationProperty in entity.EntityType.NavigationProperty) {
                    Assert.NotNull(navigationProperty.Name);
                    Assert.NotNull(navigationProperty.ExternalName);
                    Assert.NotNull(navigationProperty.ItemType);
                }
            }
        }

#warning later OData V4 EdmxModelBuilder_v4northwindmetadata_Test
        //        [Fact]
        private void EdmxModelBuilder_v4northwindmetadata_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\v4northwindmetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var errors = new ModelErrors();
            var edmxModel = edmReader.Read(srcPath, true, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Read HasErrors", errors.ToString());
            }

            EdmxModelSchemaBuilder edmxModelBuilder = new EdmxModelSchemaBuilder();
            var modelSchema = edmxModelBuilder.Build(edmxModel, null, null, errors);
            if (errors.HasErrors()) {
                output.WriteLine(errors.ToString());
                Assert.Equal("Error Builder HasErrors", errors.ToString());
            }

            var defaultEntityContainer = edmxModel.DataServices.SelectMany(_ => _.EntityContainer).FirstOrDefault(_ => _.IsDefaultEntityContainer);
            Assert.Equal(defaultEntityContainer.EntitySet.Count, modelSchema.Entities.Count);
            foreach (var entity in modelSchema.Entities) {
                if (entity.EntityType == null) {
                    throw new Xunit.Sdk.XunitException($"{entity.Name} has no EntityType.");
                }
                Assert.True(entity.EntityType.Properties.Count > 0);
                foreach (var property in entity.EntityType.Properties) {
                    Assert.NotNull(property.Name);
                    Assert.NotNull(property.Type);
                    //if (string.IsNullOrEmpty(property.Name)) {
                    //    property.Type
                    //}
                }
                foreach (var navigationProperty in entity.EntityType.NavigationProperty) {
                    Assert.NotNull(navigationProperty.Name);
                    Assert.NotNull(navigationProperty.ExternalName);
                    Assert.NotNull(navigationProperty.ItemType);
                }
            }
        }
    }
}
