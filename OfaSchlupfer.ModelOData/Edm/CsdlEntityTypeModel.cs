namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntityTypeModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlEntityTypeModel() {
            this.Property = new CsdlCollection<CsdlPropertyModel>((item) => { item.SchemaModel = this.SchemaModel; });
            this.NavigationProperty = new CsdlCollection<CsdlNavigationPropertyModel>((item) => { item.SchemaModel = this.SchemaModel; });
            this.Keys = new CsdlCollection<CsdlPropertyRefModel>((item) => { item.SchemaModel = this.SchemaModel; });
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
            internal set {
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

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel csdlSchemaModel, List<string> errors) {
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            foreach (var property in this.Property) {
                property.ResolveNames(nameResolver);
            }
            foreach (var navigationProperty in this.NavigationProperty) {
                navigationProperty.ResolveNames(nameResolver);
            }
            foreach (var key in this.Keys) {
                key.ResolveNames(nameResolver);
            }
        }
    }
}