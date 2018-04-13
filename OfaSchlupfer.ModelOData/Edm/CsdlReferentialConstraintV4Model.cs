namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlReferentialConstraintV4Model : CsdlAnnotationalModel {
        [JsonIgnore]
        private CsdlNavigationPropertyModel _Owner;

        //V4
        [JsonIgnore]
        private string _PropertyName;
        [JsonIgnore]
        private CsdlPropertyModel _PropertyModel;
        [JsonIgnore]
        private string _ReferencedPropertyName;
        [JsonIgnore]
        private CsdlPropertyModel _ReferencedPropertyModel;

        public CsdlReferentialConstraintV4Model() {
        }

        [JsonIgnore]
        public CsdlNavigationPropertyModel Owner {
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
        public string PropertyName {
            get {
                if (_PropertyModel != null) {
                    return this._PropertyModel.Name;
                } else {
                    return this._PropertyName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._PropertyName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._PropertyName = value;
                this._PropertyModel = null;
            }
        }

        [JsonIgnore]
        public CsdlPropertyModel Property {
            get {
                if (((object)this._PropertyName != null) && ((object)this._PropertyModel == null)) {
                    this.ResolveNamesProperty(ModelErrors.GetIgnorance());
                }
                return this._PropertyModel;
            }
            set {
                if (ReferenceEquals(this._PropertyModel, value)) { return; }
                this.ThrowIfFrozen();
                this._PropertyModel = value;
                this._PropertyName = null;
            }
        }

        [JsonProperty]
        public string ReferencedPropertyName {
            get {
                return this._ReferencedPropertyName;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._ReferencedPropertyName, value, StringComparison.Ordinal)) { return; }
                this._ReferencedPropertyName = value;
                this._ReferencedPropertyModel = null;
            }
        }

        [JsonIgnore]
        public CsdlPropertyModel ReferencedProperty {
            get {
                if (((object)this._ReferencedPropertyName != null) && ((object)this._ReferencedPropertyModel == null)) {
                    this.ResolveNamesReferencedProperty(ModelErrors.GetIgnorance());
                }
                return this._ReferencedPropertyModel;
            }
            set {
                if (ReferenceEquals(this._ReferencedPropertyModel, value)) { return; }
                this._ReferencedPropertyModel = value;
                this._ReferencedPropertyName = value?.Name;
            }
        }


        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesProperty(errors);
            this.ResolveNamesReferencedProperty(errors);

        }

        public void ResolveNamesProperty(ModelErrors errors) {
            if (this._PropertyModel == null && this._PropertyName != null) {
                if ((object)this._Owner != null) {
                    var ownerEntityTypeModel = this._Owner.Owner;
                    var lstProperty = ownerEntityTypeModel.FindProperty(this._PropertyName);
                    if (lstProperty.Count == 1) {
                        this._PropertyModel = lstProperty[0];
                        this._PropertyName = null;
                    } else if (lstProperty.Count == 0) {
                        errors.AddErrorOrThrow($"Property '{this._PropertyName}' not found in {ownerEntityTypeModel.FullName}.", this._Owner?.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Property '{this._PropertyName}' found #{lstProperty.Count} times in {ownerEntityTypeModel.FullName}.", this._Owner?.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }

        public void ResolveNamesReferencedProperty(ModelErrors errors) {
            if (this._ReferencedPropertyModel == null && this._ReferencedPropertyName != null) {
                if ((object)this._Owner != null) {
                    var entityTypeModel = this._Owner.TypeModel?.GetEntityTypeModel();
                    if (entityTypeModel != null) {
                        var lstReferencedProperty = entityTypeModel.FindProperty(this._ReferencedPropertyName);
                        if (lstReferencedProperty.Count == 1) {
                            this.ReferencedProperty = lstReferencedProperty[0];
                        } else if (lstReferencedProperty.Count == 0) {
                            errors.AddErrorOrThrow($"ReferencedProperty '{this._ReferencedPropertyName}' not found in {entityTypeModel.FullName}.", this._Owner?.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"ReferencedProperty '{this._ReferencedPropertyName}' found #{lstReferencedProperty.Count} times in {entityTypeModel.FullName}.", this._Owner?.Name, ResolveNameNotUniqueException.Factory);
                        }
                    }
                }
            }
        }
    }
}