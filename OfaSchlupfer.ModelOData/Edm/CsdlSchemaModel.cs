using System;
using System.Collections.Generic;
using OfaSchlupfer.Model;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlSchemaModel : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlScalarTypeModel> ScalarTypeModel;
        public readonly CsdlCollection<CsdlEntityTypeModel> EntityType;
        public readonly CsdlCollection<CsdlEntityContainerModel> EntityContainer;
        public readonly CsdlCollection<CsdlAssociationModel> Association;
        
        public string Namespace;

        public EdmxModel EdmxModel;

        public CsdlSchemaModel() {
            this.ScalarTypeModel = new CsdlCollection<CsdlScalarTypeModel>((item) => { item.SchemaModel = this; });
            this.EntityType = new CsdlCollection<CsdlEntityTypeModel>((item) => { item.SchemaModel = this; });
            this.EntityContainer = new CsdlCollection<CsdlEntityContainerModel>((item) => { item.SchemaModel = this; });
            this.Association = new CsdlCollection<CsdlAssociationModel>((item) => { item.SchemaModel = this; });
        }
        
        public void ResolveNames(ModelErrors errors) {
            foreach (var entityType in this.EntityType) {
                entityType.ResolveNames(errors);
            }
            foreach (var entityContainer in this.EntityContainer) {
                entityContainer.ResolveNames(errors);
            }
            foreach (var association in this.Association) {
                association.ResolveNames(errors);
            }
        }

        public List<CsdlScalarTypeModel> FindScalarType(string scalarTypeLocalName) {
            var result = new List<CsdlScalarTypeModel>();
            foreach (var scalarTypeModel in this.ScalarTypeModel) {
                if (string.Equals(scalarTypeModel.Name, scalarTypeLocalName, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(scalarTypeModel);
                }
            }
            return result;
        }

        public List<CsdlEntityTypeModel> FindEntityType(string entityTypeLocalName) {
            var result = new List<CsdlEntityTypeModel>();
            foreach (var entityType in this.EntityType) {
                if (string.Equals(entityType.Name, entityTypeLocalName, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(entityType);
                }
            }
            return result;
        }

        public List<CsdlAssociationModel> FindAssociation(string associationLocalName) {
            var result = new List<CsdlAssociationModel>();
            foreach (var association in this.Association) {
                if (string.Equals(association.Name, associationLocalName, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(association);
                }
            }
            return result;
        }

        public static CsdlSchemaModel AddCoreV3(EdmxModel edmxModel, ModelErrors errors) {
            CsdlSchemaModel schemaModel = new CsdlSchemaModel();
            schemaModel.Namespace = "Edm";
            edmxModel.DataServices.Add(schemaModel);
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Binary"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Boolean"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Byte"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTime"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Decimal"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Double"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Single"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Guid"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int16"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int32"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int64"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "SByte"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "String"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Time"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTimeOffset"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geography"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyCollection"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geometry"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryCollection"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Stream"));
            return schemaModel;
        }
        
        public static CsdlSchemaModel AddCoreV4(EdmxModel edmxModel, ModelErrors errors) {
            CsdlSchemaModel schemaModel = new CsdlSchemaModel();
            schemaModel.Namespace = "Edm";
            edmxModel.DataServices.Add(schemaModel);
            // TODO: V4 Scalar
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Binary"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Boolean"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Byte"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTime"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Decimal"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Double"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Single"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Guid"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int16"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int32"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int64"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "SByte"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "String"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Time"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTimeOffset"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geography"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyCollection"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geometry"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPoint"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiLineString"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPolygon"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryCollection"));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Stream"));
            return schemaModel;
        }


        public void AddScalarType(CsdlScalarTypeModel scalarTypeModel) {
            this.ScalarTypeModel.Add(scalarTypeModel);
        }
    }
}