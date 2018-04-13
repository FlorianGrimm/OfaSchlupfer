#define NoDevAsserts

namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntitySetModel : CsdlAnnotationalModel {
        // parents
        private CsdlEntityContainerModel _OwnerEntityContainerModel;

        private string _Name;

        private string _EntityTypeName;
        private CsdlEntityTypeModel _EntityTypeModel;

        public readonly CsdlCollection<CsdlNavigationPropertyBindingModel> NavigationPropertyBinding;

        public CsdlEntitySetModel() {
            this.NavigationPropertyBinding = new CsdlCollection<CsdlNavigationPropertyBindingModel>((item) => { item.OwnerEntitySetModel = this; });
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel => this.OwnerEntityContainerModel.SchemaModel;

        public CsdlEntityContainerModel OwnerEntityContainerModel {
            get {
                return this._OwnerEntityContainerModel;
            }
            set {
                this._OwnerEntityContainerModel = value;
            }
        }

        public string Name {
            get {
                return this._Name;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.Ordinal)) { return; }
                this._Name = value;
            }
        }

        public string EntityTypeName {
            get {
                var entityTypeModel = this._EntityTypeModel;
                if (entityTypeModel == null) {
                    return this._EntityTypeName;
                } else {
                    return (entityTypeModel.SchemaModel.Namespace ?? string.Empty) + "." + (entityTypeModel.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._EntityTypeName, value, StringComparison.Ordinal)) { return; }
                this._EntityTypeName = value;
                this._EntityTypeModel = null;
            }
        }

        public CsdlEntityTypeModel EntityTypeModel {
            get {
                if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                    var entityContainer = this.OwnerEntityContainerModel;
                    var schema = entityContainer?.SchemaModel;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }

                }
                return this._EntityTypeModel;
            }
            set {
                this._EntityTypeModel = value;
                this._EntityTypeName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesEntityType(errors);
            foreach (var navigationPropertyBinding in this.NavigationPropertyBinding) {
                navigationPropertyBinding.ResolveNames(errors);
            }
        }

        public void ResolveNamesEntityType(ModelErrors errors) {
            if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindStart(this.EntityTypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindEntityType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                        var oldEntityTypeName = this.EntityTypeName;
                        this.EntityTypeModel = lstFound[0];
                        var newEntityTypeName = this.EntityTypeName;
                        if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                            throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                        }
#else
                            this.EntityTypeModel = lstFound[0];
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorXmlParsing($"{this._EntityTypeName} not found");
                        } else {
                            errors.AddErrorXmlParsing($"{this._EntityTypeName} found #{lstFound.Count} times.");
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorXmlParsing($"{this._EntityTypeName} namespace not found");
                    } else {
                        errors.AddErrorXmlParsing($"{this._EntityTypeName} namespace found #{lstNS.Count} times.");
                    }
                }
            }
        }
    }
}