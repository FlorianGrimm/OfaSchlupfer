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

            var edmxModel = sut.Read(srcPath, true, null);
            Assert.NotNull(edmxModel);
            Assert.NotNull(edmxModel.Version);
            Assert.Equal(3, edmxModel.DataServices.Count);
            Assert.Equal(0, edmxModel.DataServices[0].EntityContainer.Count);
            Assert.Equal(1, edmxModel.DataServices[1].EntityContainer.Count);

            var csdlSchemaModels = edmxModel.DataServices.ToArray();

            var entityContainers = csdlSchemaModels
                .SelectMany((schema) => schema.EntityContainer)
                .ToArray();

            var entitySets = entityContainers
                .SelectMany((entityContainer) => entityContainer.EntitySet)
                .ToArray();
            foreach (var entitySet in entitySets) {
                Assert.NotNull(entitySet.EntityTypeModel);
            }

            var properties = entitySets
                .SelectMany((entitySet) => entitySet.EntityTypeModel.Property)
                .ToArray();
            foreach (var property in properties) {
                Assert.NotNull(property.TypeName);
            }

            var associationSets = entityContainers
                .SelectMany((entityContainer) => entityContainer.AssociationSet)
                .ToArray();
            foreach (var associationSet in associationSets) {
                Assert.NotNull(associationSet.AssociationModel);
            }

            var associationSetEnds = associationSets
                .SelectMany((associationSet) => associationSet.End)
                .ToArray();
            foreach (var end in associationSetEnds) {
                Assert.NotNull(end);
                Assert.NotNull(end.EntitySetName);
                Assert.NotNull(end.EntitySetModel);
                Assert.NotNull(end.Owner.AssociationModel.FindAssociationEnd(end.RoleName));
            }

            var entityTypes = csdlSchemaModels
                .SelectMany((csdlSchemaModel) => csdlSchemaModel.EntityType)
                .ToArray();

            foreach (var entityType in entityTypes) {
                foreach (var property in entityType.Property) {
                    Assert.NotNull(property.ScalarType);
                }
                foreach (var key in entityType.Keys) {
                    Assert.NotNull(key.Property);
                }
                foreach (var property in entityType.NavigationProperty) {
                    if (property.RelationshipName != null) {
                        Assert.NotNull(property.RelationshipModel);
                        if (property.FromRoleName != null) {
                            Assert.NotNull(property.RelationshipModel.FindAssociationEnd(property.FromRoleName));
                        }
                    }
                    //foreach(var end in property.en)
                }
            }


            var associations = csdlSchemaModels
                .SelectMany((schemaModel) => schemaModel.Association)
                .ToArray();

            foreach (var association in associations) {
                Assert.NotNull(association.Name);
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

            var edmxModel = sut.Read(srcPath, true, null);
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

            var edmxModel = sut.Read(srcPath, true, null);
            Assert.NotNull(edmxModel);
            Assert.NotNull(edmxModel.Version);
            Assert.Equal(3, edmxModel.DataServices.Count);

            var schemaModels = edmxModel.DataServices.ToArray();

            var entityContainers = schemaModels
                .SelectMany((schema) => schema.EntityContainer)
                .ToArray();

            var entitySets = entityContainers
                .SelectMany((entityContainer) => entityContainer.EntitySet)
                .ToArray();
            foreach (var entitySet in entitySets) {
                Assert.NotNull(entitySet.EntityTypeModel);
            }

            var properties = entitySets
                .SelectMany((entitySet) => entitySet.EntityTypeModel.Property)
                .ToArray();
            foreach (var property in properties) {
                Assert.NotNull(property.TypeName);
            }

            var associationSets = entityContainers
                .SelectMany((entityContainer) => entityContainer.AssociationSet)
                .ToArray();
            foreach (var associationSet in associationSets) {
                Assert.NotNull(associationSet.AssociationModel);
            }

            var associationSetEnds = associationSets
                .SelectMany((associationSet) => associationSet.End)
                .ToArray();
            foreach (var end in associationSetEnds) {
                Assert.NotNull(end);
                Assert.NotNull(end.EntitySetName);
                Assert.NotNull(end.EntitySetModel);
                Assert.NotNull(end.Owner.AssociationModel.FindAssociationEnd(end.RoleName));
            }

            var entityTypes = schemaModels
                .SelectMany((schemaModel) => schemaModel.EntityType)
                .ToArray();

            foreach (var entityType in entityTypes) {
                foreach (var property in entityType.Property) {
                    Assert.NotNull(property.ScalarType);
                }
                foreach (var key in entityType.Keys) {
                    Assert.NotNull(key.Property);
                }
                foreach (var navigationProperty in entityType.NavigationProperty) {
                    Assert.Null(navigationProperty.RelationshipName);
                    Assert.Null(navigationProperty.FromRoleName);
                    Assert.Null(navigationProperty.ToRoleName);

                    if (navigationProperty.TypeName != null) {
                        Assert.NotNull(navigationProperty.TypeName);
                        Assert.NotNull(navigationProperty.TypeModel);
                        Assert.NotNull(navigationProperty.PartnerName);
                        Assert.NotNull(navigationProperty.PartnerModel);
                    }

                    foreach (var referentialConstraint in navigationProperty.ReferentialConstraint) {
                        Assert.NotNull(referentialConstraint.Property);
                        Assert.NotNull(referentialConstraint.ReferencedProperty);
                    }

                    //foreach(var end in property.en)
                }
            }

            var associations = schemaModels
                .SelectMany((schemaModel) => schemaModel.Association)
                .ToArray();

            foreach (var association in associations) {
                Assert.NotNull(association.Name);
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
    }
}
