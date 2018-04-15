namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlSchemaModel : CsdlAnnotationalModel {
        [JsonIgnore]
        private EdmxModel _EdmxModel;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel> _ScalarTypeModel;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel> _EntityType;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel> _EntityContainer;
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel> _Association;

        [JsonIgnore]
        private string _Namespace;

        [JsonProperty]
        public string Namespace {
            get {
                return this._Namespace;
            }
            set {
                this.ThrowIfFrozen();
                this._Namespace = value;
            }
        }

        [JsonIgnore]
        public EdmxModel EdmxModel {
            get {
                return this._EdmxModel;
            }
            set {
                if (this._EdmxModel != null) { this.ThrowIfFrozen(); }
                this._EdmxModel = value;
            }
        }


        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel> ScalarTypeModel => this._ScalarTypeModel;

        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel> EntityType => this._EntityType;

        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel> EntityContainer => this._EntityContainer;

        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel> Association => this._Association;

        public CsdlSchemaModel() {
            this._ScalarTypeModel = new FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._EntityType = new FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._EntityContainer = new FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._Association = new FreezeableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
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

        public List<CsdlScalarTypeModel> FindScalarType(string scalarTypeLocalName) => this._ScalarTypeModel.FindByKey(scalarTypeLocalName);

        public List<CsdlEntityTypeModel> FindEntityType(string entityTypeLocalName) => this._EntityType.FindByKey(entityTypeLocalName);

        public List<CsdlAssociationModel> FindAssociation(string associationLocalName) => this._Association.FindByKey(associationLocalName);

        public List<CsdlEntityContainerModel> FindEntityContainer(string entityContainerLocalName) => this._EntityContainer.FindByKey(entityContainerLocalName);


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

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ScalarTypeModel.Freeze();
                this._EntityType.Freeze();
                this._EntityContainer.Freeze();
                this._Association.Freeze();
            }
            return result;
        }
    }
}