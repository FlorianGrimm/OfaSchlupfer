namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    /// <summary>
    /// AssociationEnd
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    [JsonObject]
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        // parents
        [JsonIgnore]
        private CsdlAssociationModel _Owner;

        [JsonIgnore]
        private string _RoleName;

        [JsonIgnore]
        private string _Multiplicity;

        [JsonIgnore]
        private string _TypeName;

        [JsonIgnore]
        private CsdlEntityTypeModel _TypeModel;

        public CsdlAssociationEndModel() { }


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

        public string FullName => (this._Owner.FullName ?? string.Empty) + "." + (this.RoleName);


        [JsonProperty]
        public string Multiplicity {
            get {
                return this._Multiplicity;
            }
            set {
                this.ThrowIfFrozen();
                this._Multiplicity = value;
            }
        }

        [JsonIgnore]
        public CsdlAssociationModel Owner {
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
        public string TypeName {
            get {
                var entityTypeModel = this._TypeModel;
                if (entityTypeModel == null) {
                    return this._TypeName;
                } else {
                    return entityTypeModel.FullName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._TypeName = value;
                this._TypeModel = null;
            }
        }

        [JsonIgnore]
        public CsdlEntityTypeModel TypeModel {
            get {
                if (this._TypeModel == null && this._TypeName != null) {
                    var associationModel = this.Owner;
                    var schema = this._Owner?.Owner;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null && associationModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }
                }
                return this._TypeModel;
            }
            set {
                this.ThrowIfFrozen();
                this._TypeModel = value;
                this._TypeName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesTypeName(errors);
        }

        public void ResolveNamesTypeName(ModelErrors errors) {
            if (this._TypeModel == null && this._TypeName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.TypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindEntityType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.TypeName;
                            this._TypeModel = lstFound[0];
                            this._TypeName = null;
                            var newEntityTypeName = this.TypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this._TypeModel = lstFound[0];
                            this._TypeName = null;
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this._TypeName} not found", this.FullName, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this._TypeName} found #{lstFound.Count} times.", this.FullName, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this._TypeName} namespace not found", this.FullName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._TypeName} namespace found #{lstNS.Count} times.", this.FullName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}