namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlEntityTypeModel : CsdlAnnotationalModel, ICsdlTypeModel {
        [JsonIgnore]
        private CsdlSchemaModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private string _BaseType;

        [JsonIgnore]
        private bool _Abstract;

        [JsonIgnore]
        private bool _OpenType;

        [JsonIgnore]
        private bool _HasStream;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPropertyModel> _Property;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlNavigationPropertyModel> _NavigationProperty;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPrimaryKeyModel> _Keys;

        public CsdlEntityTypeModel() {
            this._Property = new FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPropertyModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._NavigationProperty = new FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlNavigationPropertyModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._Keys = new FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPrimaryKeyModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        [JsonProperty]
        public string BaseType {
            get {
                return this._BaseType;
            }
            set {
                this.ThrowIfFrozen();
                this._BaseType = value;
            }
        }


        [JsonProperty]
        public bool Abstract {
            get {
                return this._Abstract;
            }
            set {
                this.ThrowIfFrozen();
                this._Abstract = value;
            }
        }


        [JsonProperty]
        public bool OpenType {
            get {
                return this._OpenType;
            }
            set {
                this.ThrowIfFrozen();
                this._OpenType = value;
            }
        }


        [JsonProperty]
        public bool HasStream {
            get {
                return this._HasStream;
            }
            set {
                this.ThrowIfFrozen();
                this._HasStream = value;
            }
        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public CsdlSchemaModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref _Owner, value);
        }

        public string FullName => (this.Owner?.Namespace ?? string.Empty) + "." + (this.Name ?? string.Empty);

        public FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPropertyModel> Property => this._Property;
        public FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlNavigationPropertyModel> NavigationProperty => this._NavigationProperty;
        public FreezeableOwnedKeyedCollection<CsdlEntityTypeModel, string, CsdlPrimaryKeyModel> Keys => this._Keys;

        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => this;

        public void ResolveNames(ModelErrors errors) {
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

        public List<CsdlPropertyModel> FindProperty(string name) => this._Property.FindByKey(name);

        public List<CsdlNavigationPropertyModel> FindNavigationProperty(string name) => this._NavigationProperty.FindByKey(name);

        public List<CsdlPrimaryKeyModel> FindPrimaryKey(string name) => this._Keys.FindByKey(name);

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Property.Freeze();
                this._NavigationProperty.Freeze();
                this._Keys.Freeze();
            }
            return result;
        }
    }
}