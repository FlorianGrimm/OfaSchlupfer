namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Xunit;

    public class ModelAttributesTest {
        [Fact]
        public void ModelTypes_OwnerIsIgnored_Test() {
            var type = typeof(ModelRoot);
            var modelTypes = type.Assembly.GetExportedTypes().Where(t => t.Namespace == type.Namespace).ToArray();
            foreach (var modelType in modelTypes) {
                var property = modelType.GetProperty("Owner");
                if (property != null) {
                    var attr = property.GetCustomAttribute<JsonIgnoreAttribute>();
                    if (attr == null) {
                        Assert.Equal("Error Owner", $"{property.DeclaringType.Name} - {modelType.Name}");
                    }
                    Assert.NotNull(attr);
                }
            }
        }

        [Fact]
        public void ModelTypes_RefPropertiesAreIgnored_Test() {
            var type = typeof(ModelRoot);
            var modelTypes = type.Assembly.GetExportedTypes()
                .Where(t => t.Namespace == type.Namespace)
                .Where(t => t.Name.StartsWith("Model"))
                .Where(t => t.Name != nameof(ModelBuilder) 
                            && t.Name != nameof(ModelComplexTypeMetaEntity)
                            && t.Name != nameof(ModelRepository)
                            )
                .ToArray();
            var hsmodelTypes = modelTypes.ToHashSet();
            var typeExceptions = new HashSet<Type>();
            typeExceptions.Add(typeof(ModelEntityName));

            var propertyExceptions = new HashSet<string>();
            propertyExceptions.Add("ModelProperty - Type - ModelType");
            //propertyExceptions.Add("MappingRepository - Mapping - MappingSchema");
            //propertyExceptions.Add("ModelRepository - ModelSchema - ModelSchema");
            //propertyExceptions.Add("ModelRepository - ModelDefinition - ModelDefinition");
            
            
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
                                        Assert.Equal("Error RefProperty", propertyInfo);
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
