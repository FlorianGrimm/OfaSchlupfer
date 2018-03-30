using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlSchemaModel : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlEntityTypeModel> EntityType;
        public readonly CsdlCollection<CsdlEntityContainerModel> EntityContainer;
        public readonly CsdlCollection<CsdlAssociationModel> Association;
        public string Namespace;
        public EdmxModel EdmxModel;

        public CsdlSchemaModel() {
            this.EntityType = new CsdlCollection<CsdlEntityTypeModel>((item) => { item.SchemaModel = this; });
            this.EntityContainer = new CsdlCollection<CsdlEntityContainerModel>((item) => { item.SchemaModel = this; });
            this.Association = new CsdlCollection<CsdlAssociationModel>((item) => { item.SchemaModel = this; });
        }

        public void ResolveNames(EdmxModel edmxModel, List<string> errors) {
            foreach (var entityType in this.EntityType) {
                entityType.ResolveNames(edmxModel, this, errors);
            }
            foreach (var entityContainer in this.EntityContainer) {
                entityContainer.ResolveNames(edmxModel, this, errors);
            }
            foreach (var association in this.Association) {
                association.ResolveNames(edmxModel, this, errors);
            }
        }

        public List<CsdlEntityTypeModel> FindEntityType(string entityTypeName) {
            var result = new List<CsdlEntityTypeModel>();
            foreach (var entityType in this.EntityType) {
                if (string.Equals(entityType.Name, entityTypeName, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(entityType);
                }
            }
            return result;
        }
    }
}