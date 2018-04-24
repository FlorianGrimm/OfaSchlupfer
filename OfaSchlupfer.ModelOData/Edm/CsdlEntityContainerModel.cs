namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlEntityContainerModel : CsdlAnnotationalModel {
        [JsonIgnore]
        private CsdlSchemaModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private bool _IsDefaultEntityContainer;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlEntitySetModel> _EntitySet;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlAssociationSetModel> _AssociationSet;

        public CsdlEntityContainerModel() {
            this._EntitySet = new FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlEntitySetModel>(
                this,
                (item) => item.Name,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._AssociationSet = new FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlAssociationSetModel>(
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
        public bool IsDefaultEntityContainer {
            get {
                return this._IsDefaultEntityContainer;
            }
            set {
                this.ThrowIfFrozen();
                this._IsDefaultEntityContainer = value;
            }
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public CsdlSchemaModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref _Owner, value);
        }

        public FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlAssociationSetModel> AssociationSet => this._AssociationSet;

        public FreezeableOwnedKeyedCollection<CsdlEntityContainerModel, string, CsdlEntitySetModel> EntitySet => this._EntitySet;

        public List<CsdlAssociationSetModel> FindAssociationSet(string name) => this._AssociationSet.FindByKey(name);

        public List<CsdlEntitySetModel> FindEntitySet(string localName) => this._EntitySet.FindByKey(localName);

        public void ResolveNames(ModelErrors errors) {
            foreach (var entitySet in this.EntitySet) {
                entitySet.ResolveNames(errors);
            }
            foreach (var associationSet in this.AssociationSet) {
                associationSet.ResolveNames(errors);
            }
        }
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._AssociationSet.Freeze();
                this._EntitySet.Freeze();
            }
            return result;
        }

    }
}