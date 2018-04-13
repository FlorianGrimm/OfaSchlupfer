namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlAssociationSetEndModel
        : CsdlAnnotationalModel {
        [JsonIgnore]
        private CsdlAssociationSetModel _Owner;
        [JsonIgnore]
        private string _RoleName;
        [JsonIgnore]
        private string _EntitySetName;
        [JsonIgnore]
        private CsdlEntitySetModel _EntitySetModel;

        public CsdlAssociationSetEndModel() {
        }

        [JsonIgnore]
        public CsdlAssociationSetModel Owner {
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
        public string RoleName {
            get {
                return this._RoleName;
            }
            set {
                this.ThrowIfFrozen();
                this._RoleName = value;
            }
        }

        [JsonProperty]
        public string EntitySetName {
            get {
                var entitySetModel = this._EntitySetModel;
                if (entitySetModel != null) {
                    return entitySetModel.Name;
                } else {
                    return this._EntitySetName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._EntitySetName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._EntitySetName = value;
                this._EntitySetModel = null;
            }
        }

        [JsonIgnore]
        public CsdlEntitySetModel EntitySetModel {
            get {
                if ((object)this._EntitySetModel == null) {
                    var entityContainerModel = this.Owner.Owner;
                    var schemaModel = entityContainerModel?.Owner;
                    var edmxModel = schemaModel?.EdmxModel;
                    if (edmxModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }
                }
                return this._EntitySetModel;
            }
            set {
                this.ThrowIfFrozen();
                this._EntitySetModel = value;
                this._EntitySetName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesEntitySetName(errors);
        }

        public void ResolveNamesEntitySetName(ModelErrors errors) {
            if (this._EntitySetModel == null && this._EntitySetName != null) {
                var entityContainer = this.Owner?.Owner;
                if ((entityContainer != null)) {
                    var lstFound = entityContainer.FindEntitySet(this.EntitySetName);
                    if (lstFound.Count == 1) {
#if DevAsserts
                        var oldEntityTypeName = this.EntityTypeName;
                        this._EntitySetModel = lstFound[0];
                        this._EntitySetName = null;
                        var newEntityTypeName = this.EntityTypeName;
                        if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                            throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                        }
#else
                        this._EntitySetModel = lstFound[0];
                        this._EntitySetName = null;
#endif
                    } else if (lstFound.Count == 0) {
                        errors.AddErrorOrThrow($"{this._EntitySetName} not found", this.RoleName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._EntitySetName} found #{lstFound.Count} times.", this.RoleName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}