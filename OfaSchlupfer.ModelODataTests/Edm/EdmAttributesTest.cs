namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using OfaSchlupfer.Freezable;

    using Xunit;
    using Xunit.Abstractions;

    public class EdmAttributesTest {
        private readonly ITestOutputHelper output;

        public EdmAttributesTest(ITestOutputHelper output) {
            this.output = output;
        }

        [Fact]
        public void ModelTypes_OwnerIsIgnored_Test() {

            var type = typeof(EdmxModel);
            var modelTypes = type.Assembly.GetExportedTypes().Where(t => t.Namespace == type.Namespace).ToArray();
            foreach (var modelType in modelTypes) {
                if (modelType.IsClass) {
                    var property = modelType.GetProperty("Owner");
                    if (property != null) {
                        if (property.GetCustomAttribute<JsonIgnoreAttribute>() == null) {
                            Assert.Equal("Error Owner", $"{modelType} - {property.Name} - {property.PropertyType.Name}");
                        }
                        if (modelType.GetCustomAttribute<JsonObjectAttribute>(false) == null) {
                            Assert.Equal("Error JsonObject", $"{modelType}");
                        }
                    }
                }
            }
        }

        [Fact]
        public void ModelTypes_RefPropertiesAreIgnored_Test() {
            var type = typeof(EdmxModel);
            var modelTypes = type.Assembly.GetExportedTypes()
                .Where(t => t.Namespace == type.Namespace)
                //.Where(t => t.Name.StartsWith("Model"))
                //.Where(t => t.Name != "ModelBuilder")
                .ToArray();
            var hsmodelTypes = modelTypes.ToHashSet();
            var typeExceptions = new HashSet<Type>();
            //typeExceptions.Add(typeof(ModelEntityName));

            var propertyExceptions = new HashSet<string> {
                "CsdlPropertyModel - ScalarType - CsdlScalarTypeModel",
                "CsdlReferentialConstraintV3Model - Principal - CsdlReferentialConstraintPartnerV3Model",
                "CsdlReferentialConstraintV3Model - Dependent - CsdlReferentialConstraintPartnerV3Model",
                "CsdlPropertyModel - ScalarTypePersitent - CsdlScalarTypeModel"
            };

            foreach (var modelType in modelTypes) {
                if (modelType.IsClass) {
                    if (modelType.GetCustomAttributes<JsonObjectAttribute>(true).Count() > 0) {
                        var properties = modelType.GetProperties();
                        foreach (var property in properties) {
                            if (typeExceptions.Contains(property.PropertyType)) {
                                continue;
                            }
                            if (hsmodelTypes.Contains(property.PropertyType)) {
                                if (property != null) {
                                    var attr = property.GetCustomAttribute<JsonIgnoreAttribute>();
                                    if (attr == null) {
                                        if (property.GetCustomAttributes<JsonConverterAttribute>().Count() > 0) { continue; }

                                        var propertyInfo = $"{modelType.Name} - {property.Name} - {property.PropertyType.Name}";
                                        if (propertyExceptions.Contains(propertyInfo)) { continue; }
                                        this.output.WriteLine(propertyInfo);
                                        // Assert.Equal("Error JsonIgnore", propertyInfo);
                                        throw new Xunit.Sdk.XunitException(propertyInfo);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [Fact]
        public void ModelTypes_Freeze_Test() {
            var type = typeof(EdmxModel);
            var modelTypes = type.Assembly.GetExportedTypes();
            foreach (var modelType in modelTypes) {
                if (modelType.IsClass) {
                    if (modelType.GetInterfaces().Contains(typeof(OfaSchlupfer.Freezable.IFreezable))) {
                        var properties = modelType.GetProperties();
                        foreach (var property in properties) {
                            var propertyType = property.PropertyType;

                            if (propertyType.FullName.Contains("FreezeableOwnedCollection")) {
                                if (
                                    (propertyType.GetGenericTypeDefinition() == typeof(FreezableCollection<>))
                                    || (propertyType.GetGenericTypeDefinition() == typeof(FreezableDictionary<,>))
                                    || (propertyType.GetGenericTypeDefinition() == typeof(FreezableOwnedCollection<,>))
                                    || (propertyType.GetGenericTypeDefinition() == typeof(FreezableOwnedDictionary<,,>))
                                    || (propertyType.GetGenericTypeDefinition() == typeof(FreezableOwnedKeyedCollection<,,>))
                                ) {
                                    if (modelType.GetMethod("Freeze").DeclaringType != modelType) {
                                        Assert.Equal("Error Freeze missing", modelType.Name);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
