namespace OfaSchlupfer.ODataV3 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Csdl;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.ODataV3;

    public class ODataV3RepositoryModelType : ReferenceRepositoryModelType {
        public ODataV3RepositoryModelType(IServiceProvider serviceProvider) : base(serviceProvider) {
            this.Name = "ODataV3";
            this.Description = "ODataV3.";
        }
        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<ODataV3RepositoryModel>();
            } catch (InvalidOperationException) {
                return new ODataV3RepositoryImplementation();
            }
        }
    }

    public abstract class ODataV3RepositoryModel : ReferenceRepositoryModelBase {
        protected ODataV3RepositoryModel() {
        }


    }

    public class ODataV3RepositoryImplementation : ODataV3RepositoryModel, IReferenceRepositoryModel {
        public ODataV3RepositoryImplementation() {
        }

        public string ConnectionString { get; set; }

        public void ReadSchema(string content) {
            //Microsoft.Data.Edm.Csdl.CsdlReader.TryParse()
            //System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            using (var reader = System.Xml.XmlReader.Create(new System.IO.StringReader(content))) {
                var edmModel = EdmxReader.Parse(reader);
                //edmModel.EntityContainers();
            }
        }

        public ModelSchema ReadSchema(System.IO.StreamReader streamReader) {
            //Microsoft.Data.Edm.Csdl.CsdlReader.TryParse()
            //System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            using (var reader = System.Xml.XmlReader.Create(streamReader)) {
                var edmModel = EdmxReader.Parse(reader);
                return this.ConvertSchema(edmModel);
                //edmModel.EntityContainers();
            }
        }

        public ModelSchema ConvertSchema(IEdmModel edmModel) {
            var entityContainers = edmModel.EntityContainers().ToArray();
            var defaultEntityContainer = entityContainers.First(_ => edmModel.IsDefaultEntityContainer(_));
            var entitySets = defaultEntityContainer.EntitySets().ToArray();

            var modelSchema = new ModelSchema();
            var modelEntityRoot = new ModelEntity();
            var complexTypeRoot = new ModelComplexType();
            // TODO: add ns
            modelEntityRoot.Name = new ModelEntityName(defaultEntityContainer.Namespace, null, defaultEntityContainer.Name);
            complexTypeRoot.Name = new ModelEntityName(defaultEntityContainer.Namespace, null, defaultEntityContainer.Name);

            modelEntityRoot.EntityType = complexTypeRoot;
            modelSchema.Entities.Add(modelEntityRoot);
            modelEntityRoot.Kind = ModelEntityKind.Container;

            foreach (var entitySet in entitySets) {
                var elementType = entitySet.ElementType;
                var complexType = new ModelComplexType();
                var modelEntity = new ModelEntity();
                complexType.Name = new ModelEntityName(elementType.Namespace, null, elementType.Name);
                modelEntity.Name = new ModelEntityName(null, null, entitySet.Name);
                modelEntity.EntityType = complexType;
                modelEntity.Kind = ModelEntityKind.EntitySet;

                modelSchema.ComplexTypes.Add(complexType);
                modelSchema.Entities.Add(modelEntity);


                var declaredStructuralProperties = elementType.DeclaredStructuralProperties().ToArray();
                foreach (var declaredStructuralProperty in declaredStructuralProperties) {
                    var declaredStructuralPropertyType = declaredStructuralProperty.Type;
                    var declaredStructuralPropertyTypeDefinition = declaredStructuralPropertyType.Definition;
                    var modelProperty = new ModelProperty();
                    modelProperty.Name = declaredStructuralProperty.Name;
                    if (declaredStructuralPropertyType.IsPrimitive()) {
                        var modelPropertyType = new ModelScalarType();
                        var vas = declaredStructuralProperty.VocabularyAnnotations(edmModel).ToArray();
                        if (declaredStructuralPropertyTypeDefinition is IEdmSchemaElement edmSchemaElement) {
                            modelPropertyType.Name = new ModelEntityName(edmSchemaElement.Namespace, null, edmSchemaElement.Name);
                        } else {
                            modelPropertyType.Name = new ModelEntityName(null, null, declaredStructuralPropertyType.FullName());
                        }
                        modelPropertyType.IsNullable = declaredStructuralPropertyType.IsNullable;
                        modelProperty.Type = modelPropertyType;
                    } else {
                        throw new NotImplementedException();
                    }
                    complexType.Properties.Add(modelProperty);
                }

                //complexType.Properties
            }

            foreach (var entitySet in entitySets) {
                var entityName = new ModelEntityName(null, null, entitySet.Name);
                var modelEntity = modelSchema.Entities.FirstOrDefault(_ => _.Name == entityName);

                var navigationTargets = entitySet.NavigationTargets.ToArray();
                foreach (var navigationTarget in navigationTargets) {
                    //
                    var navigationProperty = navigationTarget.NavigationProperty;

                    if (navigationProperty is IEdmNavigationProperty edmNavigationProperty) {
                        if (navigationProperty.ContainsTarget) {
                        }

                    }
                    var navigationPropertyPartner = navigationProperty.Partner;
                    var targetEntitySet = navigationTarget.TargetEntitySet;
                    //
                    var naviFromProperties = navigationProperty.DependentProperties?.ToArray();
                    var naviToProperties = navigationPropertyPartner.DependentProperties?.ToArray();

                    var modelRelation = new ModelRelation();
                    var targetEntityName = new ModelEntityName(null, null, targetEntitySet.Name);
                    var targetModelEntity = modelSchema.Entities.FirstOrDefault(_ => _.Name == targetEntityName);
                    modelRelation.Name = navigationTarget.TargetEntitySet.Name;

                    //modelRelation.MasterEntity = 
                    //modelRelation.ForeignEntity = targetModelEntity;
                    modelRelation.ForeignName = targetEntityName;
                    modelSchema.Relations.Add(modelRelation);
                }
            }

            return modelSchema;
        }

        public override List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }
    }
}
