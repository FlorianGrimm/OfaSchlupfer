#define NoDevAsserts

namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlEntitySetModel : CsdlAnnotationalModel {
        // parents
        [JsonIgnore]
        private CsdlEntityContainerModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private string _EntityTypeName;

        [JsonIgnore]
        private CsdlEntityTypeModel _EntityTypeModel;

        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<CsdlEntitySetModel, string, CsdlNavigationPropertyBindingModel> _NavigationPropertyBinding;

        public CsdlEntitySetModel() {
            this._NavigationPropertyBinding = new FreezableOwnedKeyedCollection<CsdlEntitySetModel, string, CsdlNavigationPropertyBindingModel>(
                this,
                (item) => item.PathName,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public CsdlEntityContainerModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

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

        public string EntityTypeName {
            get {
                var entityTypeModel = this._EntityTypeModel;
                if (entityTypeModel == null) {
                    return this._EntityTypeName;
                } else {
                    return (entityTypeModel.Owner.Namespace ?? string.Empty) + "." + (entityTypeModel.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._EntityTypeName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._EntityTypeName = value;
                this._EntityTypeModel = null;
            }
        }

        [JsonIgnore]
        public CsdlEntityTypeModel EntityTypeModel {
            get {
                if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                    var entityContainer = this.Owner;
                    var schema = entityContainer?.Owner;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }

                }
                return this._EntityTypeModel;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityTypeModel = value;
                this._EntityTypeName = null;
            }
        }

        [JsonProperty]
        public FreezableOwnedKeyedCollection<CsdlEntitySetModel, string, CsdlNavigationPropertyBindingModel> NavigationPropertyBinding => this._NavigationPropertyBinding;

        public List<CsdlNavigationPropertyBindingModel> FindNavigationPropertyBinding(string name) => this._NavigationPropertyBinding.FindByKey(name);

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesEntityType(errors);
            foreach (var navigationPropertyBinding in this.NavigationPropertyBinding) {
                navigationPropertyBinding.ResolveNames(errors);
            }
        }

        public void ResolveNamesEntityType(ModelErrors errors) {
            if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                EdmxModel edmxModel = this._Owner.Owner?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.EntityTypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindEntityType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.EntityTypeName;
                            this._EntityTypeModel = lstFound[0];
                            this._EntityTypeName = null;
                            var newEntityTypeName = this.EntityTypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this._EntityTypeModel = lstFound[0];
                            this._EntityTypeName = null;
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this._EntityTypeName} not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this._EntityTypeName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this._EntityTypeName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._EntityTypeName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._NavigationPropertyBinding.Freeze();
            }
            return result;
        }
    }
}