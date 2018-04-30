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
        private readonly FreezableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel> _AssociationEnd;

        [JsonIgnore]
        private readonly FreezableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model> _ReferentialConstraint;

        public CsdlAssociationModel() {
            this._AssociationEnd = new FreezableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel>(
                this,
                (item) => item.RoleName,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
            this._ReferentialConstraint = new FreezableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model>(
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
            get => this._Owner;
            internal set => this.SetOwner(ref _Owner, value);                
        }
        
        [JsonProperty]
        public FreezableOwnedKeyedCollection<CsdlAssociationModel, string, CsdlAssociationEndModel> AssociationEnd => this._AssociationEnd;

        [JsonProperty]
        public FreezableOwnedCollection<CsdlAssociationModel, CsdlReferentialConstraintV3Model> ReferentialConstraint => this._ReferentialConstraint;

        public List<CsdlAssociationEndModel> FindAssociationEnd(string roleName) => this._AssociationEnd.FindByKey(roleName);

        public void ResolveNames(ModelErrors errors) {
            foreach (var associationEnd in this.AssociationEnd) {
                associationEnd.ResolveNames(errors);
            }
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(errors);
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._AssociationEnd.Freeze();
                this._ReferentialConstraint.Freeze();
            }
            return result;
        }
    }
}