namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    /// <summary>
    /// http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part3-csdl/odata-v4.0-errata03-os-part3-csdl-complete.html#_Toc453752607
    /// </summary>
    [JsonObject]
    public class CsdlNavigationPropertyBindingModel
        : CsdlAnnotationalModel {
        [JsonIgnore]
        private CsdlEntitySetModel _Owner;

        [JsonIgnore]
        private string _TargetName;


        [JsonIgnore]
        private string _PathName;

        [JsonIgnore]
        private CsdlNavigationPropertyModel _PathModel;

        public CsdlNavigationPropertyBindingModel() {
        }

        [JsonIgnore]
        public CsdlEntitySetModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }


        [JsonProperty]
        public string TargetName {
            get {
                return this._TargetName;
            }
            set {
                this.ThrowIfFrozen();
                this._TargetName = value;
            }
        }

        [JsonProperty]
        public string PathName {
            get {
                if (this._PathModel != null) {
                    return this._PathModel.Name;
                } else {
                    return this._PathName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._PathName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._PathName = value;
                this._PathModel = null;
            }
        }

        [JsonIgnore]
        public CsdlNavigationPropertyModel PathModel {
            get {
                if (this._PathModel == null && this._PathName != null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._PathModel;
            }
            set {
                this.ThrowIfFrozen();
                this._PathModel = value;
                this._PathName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesPath(errors);
        }

        public void ResolveNamesPath(ModelErrors errors) {
            if ((this._PathName == null) && (this._PathModel != null)) {
                var entitySetModel = this.Owner;
                var entityTypeModel = entitySetModel?.EntityTypeModel;
                if (entityTypeModel != null) {
                    var lstNavProperty = entityTypeModel.FindNavigationProperty(this.PathName);
                    if (lstNavProperty.Count == 1) {
                        this._PathModel = lstNavProperty[0];
                        this._PathName = null;
                    } else if (lstNavProperty.Count == 0) {
                        errors.AddErrorOrThrow($"Property {this._TargetName} in {entityTypeModel.FullName} not found.", this._TargetName ?? this._PathName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Property {this._TargetName} in {entityTypeModel.FullName} found #{lstNavProperty.Count} times.", this._PathName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}