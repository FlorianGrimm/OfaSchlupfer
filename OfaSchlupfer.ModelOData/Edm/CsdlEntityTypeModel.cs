namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntityTypeModel : CsdlAnnotationalModel, ICsdlTypeModel {
        private CsdlSchemaModel _SchemaModel;

        public CsdlEntityTypeModel() {
            this.Property = new CsdlCollection<CsdlPropertyModel>((item) => { item.ÒwnerEntityTypeModel = this; });
            this.NavigationProperty = new CsdlCollection<CsdlNavigationPropertyModel>((item) => { item.OwnerEntityTypeModel = this; });
            this.Keys = new CsdlCollection<CsdlPrimaryKeyModel>((item) => { item.OwnerEntityTypeModel = this; });
        }

        public string Name;
        public string BaseType;
        public bool Abstract;
        public bool OpenType;
        public bool HasStream;
        public readonly CsdlCollection<CsdlPropertyModel> Property;
        public readonly CsdlCollection<CsdlNavigationPropertyModel> NavigationProperty;
        public readonly CsdlCollection<CsdlPrimaryKeyModel> Keys;

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

        public string FullName => (this.SchemaModel?.Namespace ?? string.Empty) + "." + (this.Name ?? string.Empty);

        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => this;

        public void ResolveNames(CsdlErrors errors) {
            foreach (var property in this.Property) {
                property.ResolveNames(errors);
            }
            foreach (var navigationProperty in this.NavigationProperty) {
                navigationProperty.ResolveNames(errors);
            }
            foreach (var key in this.Keys) {
                key.ResolveNames(errors);
            }
        }

        public List<CsdlPropertyModel> FindProperty(string name) {
            var result = new List<CsdlPropertyModel>();

            foreach (var property in this.Property) {
                if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(property);
                }
            }

            return result;
        }

        public List<CsdlNavigationPropertyModel> FindNavigationProperty(string name) {
            var result = new List<CsdlNavigationPropertyModel>();

            foreach (var property in this.NavigationProperty) {
                if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(property);
                }
            }

            return result;
        }
    }
}