namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlAssociationModel : CsdlAnnotationalModel {
        [JsonIgnore]
        private CsdlSchemaModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel> _AssociationEnd;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model> _ReferentialConstraint;

        public CsdlAssociationModel() {
            this._AssociationEnd = new FreezeableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel>(
                this,
                (item) => item.RoleName,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._ReferentialConstraint = new FreezeableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model>(
                this,
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

        public string FullName => (this.Owner?.Namespace ?? string.Empty) + "." + this.Name;


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public CsdlSchemaModel Owner {
            get {
                return this._Owner;
            }
            set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                this.ThrowIfFrozen();
                this._Owner = value;
                //this.AssociationEnd.Broadcast();
                //this.ReferentialConstraint.Broadcast();
            }
        }

        [JsonProperty]
        public FreezeableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel> AssociationEnd => this._AssociationEnd;

        [JsonProperty]
        public FreezeableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model> ReferentialConstraint => this._ReferentialConstraint;

        public List<CsdlAssociationEndModel> FindAssociationEnd(string roleName) => this._AssociationEnd.FindByKey(roleName);

        public void ResolveNames(ModelErrors errors) {
            foreach (var associationEnd in this.AssociationEnd) {
                associationEnd.ResolveNames(errors);
            }
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(errors);
            }
        }

    }
}