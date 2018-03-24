#if no
namespace OfaSchlupfer.ModelOData {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Validation;
    using OfaSchlupfer.Model;

    public class ODataModelBuilder : ModelBuilder {
        public ODataModelBuilder() {
        }

        public IEdmModel EdmModel { get; set; }

        public override List<string> Build() {
            var resultErrors = new List<string>();
            var modelDefinition = this.ModelDefinition;
            var modelSchema = this.ModelSchema ?? (this.ModelSchema = new ModelSchema());
            this.EdmModel = null;

            IEdmModel edmModel;
            using (var reader = new System.IO.StringReader(modelDefinition.MetaData)) {
                using (var xmlReader = System.Xml.XmlReader.Create(reader)) {
                    IEnumerable<EdmError> edmErrors;
                    var parseResult = Microsoft.Data.Edm.Csdl.EdmxReader.TryParse(xmlReader, out edmModel, out edmErrors);
                    if (!parseResult) {
                        resultErrors.AddRange(edmErrors.Select(_ => _.ErrorMessage));
                        //throw new InvalidOperationException("Failed to load model : " + string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage)));
                        return resultErrors;
                    }
                }
            }

            this.EdmModel = edmModel;
            // this.Rules.

            var lstTypeDefinition = edmModel.SchemaElements.Where(schemaElement => schemaElement.SchemaElementKind == Microsoft.Data.Edm.EdmSchemaElementKind.TypeDefinition).ToList();
            var lstValueTerm = edmModel.SchemaElements.Where(schemaElement => schemaElement.SchemaElementKind == Microsoft.Data.Edm.EdmSchemaElementKind.ValueTerm).ToList();
            var lstEntityContainer = edmModel.SchemaElements.Where(schemaElement => schemaElement.SchemaElementKind == Microsoft.Data.Edm.EdmSchemaElementKind.EntityContainer).ToList();

            var typeDefinitionsByName = new Dictionary<ModelEntityName, ModelTableType>(ModelUtility.Instance.ModelEntityNameEqualityComparer);
            var entityByName = new Dictionary<ModelEntityName, ModelEntity>(ModelUtility.Instance.ModelEntityNameEqualityComparer);

            foreach (var typeDefinition in lstTypeDefinition) {
                // typeDefinition.FullName
                if (typeDefinition is Microsoft.Data.Edm.IEdmStructuredType structuredType) {
                    var modelTableType = new ModelTableType();
                    modelTableType.Name = ConvertToModelEntityName(typeDefinition);
                    modelSchema.TableTypes.Add(modelTableType);
                    typeDefinitionsByName[modelTableType.Name] = modelTableType;
                    var declaredStructuralProperties = structuredType.DeclaredStructuralProperties().ToArray();
                    var declaredProperties = structuredType.DeclaredProperties.ToArray();
                    foreach (var declaredProperty in declaredProperties) {
                        if (declaredProperty.PropertyKind == EdmPropertyKind.None) {
                            var modelProperty = new ModelProperty();
                            modelProperty.Name = declaredProperty.Name;
                            // modelProperty.Type
                            var declaredPropertyType = declaredProperty.Type;
                            modelTableType.Properties.Add(modelProperty);
                        } else if (declaredProperty.PropertyKind == EdmPropertyKind.Structural) {
                            var modelProperty = new ModelProperty();
                            modelProperty.Name = declaredProperty.Name;
                            // modelProperty.Type
                            var declaredPropertyType = declaredProperty.Type;
                            if (declaredPropertyType is IEdmPrimitiveTypeReference primitiveTypeReference) {
                                var modelScalarType = new ModelScalarType();
                                var definition = primitiveTypeReference.Definition;
                                if (definition is Microsoft.Data.Edm.IEdmSchemaElement definitionAsSchemaElement) {
                                    var definitionName = ConvertToModelEntityName(definitionAsSchemaElement);
                                    modelScalarType.Name = definitionName;
                                } else {
                                    throw new InvalidOperationException();
                                }
                                modelScalarType.IsNullable = primitiveTypeReference.IsNullable;
                                modelProperty.Type = modelScalarType;
                            } else {
                            }
                            modelTableType.Properties.Add(modelProperty);
                        } else if (declaredProperty.PropertyKind == EdmPropertyKind.Navigation) {
                            var modelProperty = new ModelProperty();
                            modelProperty.Name = declaredProperty.Name;
                            modelTableType.Properties.Add(modelProperty);
                        }
                    }
                }
            }

            foreach (IEdmSchemaElement schemaElement in lstEntityContainer) {
                if (schemaElement is Microsoft.Data.Edm.IEdmEntityContainer entityContainer) {

                    bool isDefaultEntityContainer = false;
                    var annoIsDefaultEntityContainer = edmModel.DirectValueAnnotationsManager.GetDirectValueAnnotations(entityContainer).FirstOrDefault(_ => _.NamespaceUri == "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" && _.Name == "IsDefaultEntityContainer");
                    if (annoIsDefaultEntityContainer?.Value is Microsoft.Data.Edm.Library.Values.EdmStringConstant stringConstant) {
                        if (string.Equals(stringConstant.Value, "true", StringComparison.OrdinalIgnoreCase) || stringConstant.Value == "1") {
                            isDefaultEntityContainer = true;
                        }
                    } else if (annoIsDefaultEntityContainer?.Value is Microsoft.Data.Edm.Library.Values.EdmBooleanConstant booleanConstant) {
                        if (booleanConstant.Value) {
                            isDefaultEntityContainer = true;
                        }
                    }
                    if (isDefaultEntityContainer) {
                        var entityName = ConvertToModelEntityName(entityContainer);
                        modelSchema.RootEntityName = entityName;
                        //if (modelSchema.Name == null) {
                        //    modelSchema.Name = entityName;
                        //}
                    }

                    var modelEntityContainer = new ModelEntity();
                    modelEntityContainer.Name = ConvertToModelEntityName(entityContainer);
                    modelEntityContainer.Kind = ModelEntityKind.Container;
                    modelSchema.Entities.Add(modelEntityContainer);
                    var modelEntityContainerTableType = new ModelTableType();
                    modelEntityContainerTableType.Name = ConvertToModelEntityName(entityContainer);
                    modelEntityContainer.TableType = modelEntityContainerTableType;

                    var elements = entityContainer.Elements;

                    var entitySets = entityContainer.EntitySets();
                    foreach (var entitySet in entitySets) {
                        var modelEntitySet = new ModelEntity();
                        modelEntitySet.Name = ConvertToModelEntityName(entitySet, entityContainer);
                        modelEntitySet.Kind = ModelEntityKind.EntitySet;
                        var elementTypeName = ConvertToModelEntityName(entitySet.ElementType);
                        modelEntitySet.TableType = typeDefinitionsByName.GetValueOrDefault(elementTypeName);
                        modelSchema.Entities.Add(modelEntitySet);
                        entityByName[modelEntitySet.Name] = modelEntitySet;

                        //var property = new ModelProperty();
                        //property.Name = entitySet.Name;
                        //property.Type = new ModelT;

                        //modelEntityContainerTableType.Properties.Add(property);
                        //var modelRelation = new ModelRelation();
                        //modelRelation.Name = entitySet.Name;
                        //modelRelation.Master = modelEntityContainer;
                        //modelRelation.Child = modelEntitySet;
                        //modelSchema.Relations.Add(modelRelation);
                        //   entitySet.ContainerElementKind== EdmContainerElementKind.EntitySet
                        //   entitySet.ContainerElementKind == EdmContainerElementKind.FunctionImport
                    }

                    foreach (var entitySet in entitySets) {
                        var entitySetName = ConvertToModelEntityName(entitySet, entityContainer);
                        var modelEntitySet = entityByName.GetValueOrDefault(entitySetName);

                        var navigationTargets = entitySet.NavigationTargets;
                        foreach (var navigationTarget in navigationTargets) {
                            var navigationProperty = navigationTarget.NavigationProperty;
                            var targetEntitySet = navigationTarget.TargetEntitySet;
                            var targetEntitySetName = targetEntitySet.Name;
                            var dependentProperties = navigationProperty.DependentProperties;
                            var partner = navigationProperty.Partner;
                            var partnerName = partner.Name;
                            var modelRelation = new ModelRelation();
                            modelRelation.Name = navigationTarget.NavigationProperty.Name;
                            modelRelation.Master = modelEntitySet;
                            modelRelation.Child = null;
                            //if (targetEntitySet.ElementType is IEdmSchemaElement elementType) {
                            //    modelRelation.Child = entityByName.GetValueOrDefault(ConvertToModelEntityName(elementType));
                            //}
                            modelSchema.Relations.Add(modelRelation);
#warning here
                        }

                        //-		[0]	{Microsoft.Data.Edm.Library.EdmNavigationTargetMapping}	Microsoft.Data.Edm.IEdmNavigationTargetMapping {Microsoft.Data.Edm.Library.EdmNavigationTargetMapping}
                    }
                }
            }


            return resultErrors;
        }

        private ModelEntityName ConvertToModelEntityName(IEdmSchemaElement element) {
            if (element == null) {
                return null;
            } else {
                return new ModelEntityName(element.Namespace, element.FullName(), element.Name);
            }
        }
        private ModelEntityName ConvertToModelEntityName(IEdmNamedElement element, IEdmEntityContainer entityContainer) {
            return new ModelEntityName(entityContainer.Namespace, element.Name, element.Name);
        }

    }
}

#endif