namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Namespace}")]
    [JsonObject]
    public class CsdlSchemaModel : CsdlAnnotationalModel {
        [JsonIgnore]
        private EdmxModel _EdmxModel;
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel> _ScalarTypeModel;
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel> _EntityType;
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel> _EntityContainer;
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel> _Association;

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
        public FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel> ScalarTypeModel => this._ScalarTypeModel;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel> EntityType => this._EntityType;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel> EntityContainer => this._EntityContainer;

        [JsonProperty]
        public FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel> Association => this._Association;

        public CsdlSchemaModel() {
            this._ScalarTypeModel = new FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlScalarTypeModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._EntityType = new FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityTypeModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._EntityContainer = new FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlEntityContainerModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._Association = new FreezableOwnedKeyedCollection<CsdlSchemaModel, string, CsdlAssociationModel>(
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
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Binary", new CsdlScalarTypeModelTarget(typeof(byte[]))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Boolean", new CsdlScalarTypeModelTarget(typeof(bool))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Byte", new CsdlScalarTypeModelTarget(typeof(byte))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTime", new CsdlScalarTypeModelTarget(typeof(System.DateTime))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Decimal", new CsdlScalarTypeModelTarget(typeof(decimal))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Double", new CsdlScalarTypeModelTarget(typeof(double))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Single", new CsdlScalarTypeModelTarget(typeof(float))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Guid", new CsdlScalarTypeModelTarget(typeof(Guid))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int16", new CsdlScalarTypeModelTarget(typeof(short))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int32", new CsdlScalarTypeModelTarget(typeof(int))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int64", new CsdlScalarTypeModelTarget(typeof(long))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "SByte", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "String", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Time", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTimeOffset", new CsdlScalarTypeModelTarget(typeof(System.DateTimeOffset))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geography", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyCollection", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geometry", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryCollection", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Stream", new CsdlScalarTypeModelTarget(typeof(string))));
            return schemaModel;
        }

        public static CsdlSchemaModel AddCoreV4(EdmxModel edmxModel, ModelErrors errors) {
            CsdlSchemaModel schemaModel = new CsdlSchemaModel();
            schemaModel.Namespace = "Edm";
            edmxModel.DataServices.Add(schemaModel);
            // TODO: V4 Scalar
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Binary", new CsdlScalarTypeModelTarget(typeof(byte[]))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Boolean", new CsdlScalarTypeModelTarget(typeof(bool))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Byte", new CsdlScalarTypeModelTarget(typeof(byte))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTime", new CsdlScalarTypeModelTarget(typeof(System.DateTime))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Decimal", new CsdlScalarTypeModelTarget(typeof(decimal))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Double", new CsdlScalarTypeModelTarget(typeof(double))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Single", new CsdlScalarTypeModelTarget(typeof(Single))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Guid", new CsdlScalarTypeModelTarget(typeof(Guid))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int16", new CsdlScalarTypeModelTarget(typeof(short))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int32", new CsdlScalarTypeModelTarget(typeof(int))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Int64", new CsdlScalarTypeModelTarget(typeof(long))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "SByte", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "String", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Time", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTimeOffset", new CsdlScalarTypeModelTarget(typeof(System.DateTimeOffset))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geography", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyCollection", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Geometry", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPoint", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiLineString", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPolygon", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryCollection", new CsdlScalarTypeModelTarget(typeof(string))));
            schemaModel.AddScalarType(new CsdlScalarTypeModel("Edm", "Stream", new CsdlScalarTypeModelTarget(typeof(string))));
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