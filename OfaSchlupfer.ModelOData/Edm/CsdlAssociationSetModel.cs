namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlAssociationSetModel
        : CsdlAnnotationalModel {
        [JsonIgnore]
        private readonly FreezeableOwnedCollection<CsdlAssociationSetModel, CsdlAssociationSetEndModel> _End;

        // parents
        [JsonIgnore]
        private CsdlEntityContainerModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private string _AssociationName;

        [JsonIgnore]
        private CsdlAssociationModel _AssociationModel;

        public CsdlAssociationSetModel() {
            this._End = new FreezeableOwnedCollection<CsdlAssociationSetModel, CsdlAssociationSetEndModel>(
                this,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        [JsonIgnore]
        public CsdlEntityContainerModel Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        [JsonProperty]
        public string AssociationName {
            get {
                var associationModel = this._AssociationModel;
                if (associationModel == null) {
                    return this._AssociationName;
                } else {
                    return (associationModel.Owner.Namespace ?? string.Empty) + "." + (associationModel.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._AssociationName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._AssociationName = value;
                this._AssociationModel = null;
            }
        }

        [JsonIgnore]
        public CsdlAssociationModel AssociationModel {
            get {
                if (this._AssociationModel == null) {
                    if (this.Owner != null) {
                        var schemaModel = this.Owner?.Owner;
                        var edmxModel = schemaModel?.EdmxModel;
                        if (edmxModel != null) {
                            return this.ResolveNamesAssociation(ModelErrors.GetIgnorance());
                        }
                    }

                }
                return this._AssociationModel;
            }
            set {
                if (ReferenceEquals(this._AssociationModel, value)) { return; }
                this.ThrowIfFrozen();
                this._AssociationModel = value;
                this._AssociationName = null;
            }
        }

        [JsonProperty]
        public FreezeableOwnedCollection<CsdlAssociationSetModel, CsdlAssociationSetEndModel> End => this._End;

        //public List<CsdlAssociationSetEndModel> FindEnd(string endLocalName) => this._End.FindByKey(endLocalName);

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesAssociation(errors);
            foreach (var end in this.End) {
                end.ResolveNames(errors);
            }
        }

        public CsdlAssociationModel ResolveNamesAssociation(ModelErrors errors) {
            if (this._AssociationModel == null && this._AssociationName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.AssociationName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindAssociation(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldAssociationName = this.AssociationName;
                            this._AssociationModel = lstFound[0];
                            this._AssociationName = null;
                            var newAssociationName = this.AssociationName;
                            if (!string.Equals(oldAssociationName, newAssociationName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldAssociationName} != {newAssociationName}");
                            }
#else
                            this._AssociationModel = lstFound[0];
                            this._AssociationName = null;
#endif
                            return lstFound[0];
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this._AssociationName} not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this._AssociationName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this._AssociationName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._AssociationName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
            return this._AssociationModel;
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._End.Freeze();
            }
            return result;
        }

    }
}