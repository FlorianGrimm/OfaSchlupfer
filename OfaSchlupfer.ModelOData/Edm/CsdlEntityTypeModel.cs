namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntityTypeModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlEntityTypeModel() {
            this.Property = new CsdlCollection<CsdlPropertyModel>((item) => { item.ÒwnerEntityTypeModel = this; });
            this.NavigationProperty = new CsdlCollection<CsdlNavigationPropertyModel>((item) => { item.OwnerEntityTypeModel = this; });
            this.Keys = new CsdlCollection<CsdlPropertyRefModel>((item) => { item.OwnerEntityTypeModel = this; });
        }

        public string Name;
        public string BaseType;
        public bool Abstract;
        public bool OpenType;
        public bool HasStream;
        public readonly CsdlCollection<CsdlPropertyModel> Property;
        public readonly CsdlCollection<CsdlNavigationPropertyModel> NavigationProperty;
        public readonly CsdlCollection<CsdlPropertyRefModel> Keys;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if ((object)value != null) {
                    this.Property.Broadcast();
                    this.NavigationProperty.Broadcast();
                    this.Keys.Broadcast();
                }
            }
        }

        public void BuildNameResolver(CsdlNameResolver nameResolver) {
            nameResolver.AddEntityType(this.SchemaModel.Namespace, this.Name, this);

            foreach (var property in this.Property) {
                property.BuildNameResolver(this, nameResolver);
            }
            foreach (var navigationProperty in this.NavigationProperty) {
                navigationProperty.BuildNameResolver(this, nameResolver);
            }
            //foreach (var key in this.Keys) { }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlErrors errors) {
            foreach (var property in this.Property) {
                property.ResolveNames(edmxModel, schemaModel, this, errors);
            }
            foreach (var navigationProperty in this.NavigationProperty) {
                navigationProperty.ResolveNames(edmxModel, schemaModel, this, errors);
            }
            foreach (var key in this.Keys) {
                key.ResolveNames(edmxModel, schemaModel, this, errors);
            }
        }
    }
}