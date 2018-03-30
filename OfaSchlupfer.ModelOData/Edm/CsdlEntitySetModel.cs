#define NoDevAsserts

namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntitySetModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityContainerModel _OwnerEntityContainerModel;

        private string _EntityTypeName;
        private CsdlEntityTypeModel _EntityTypeModelObject;
        public string Name;

        // set by add
        public CsdlEntityContainerModel EntityContainer;

        public CsdlEntitySetModel() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if (!ReferenceEquals(value, this._OwnerEntityContainerModel?.SchemaModel)) {
                    this._OwnerEntityContainerModel = null;
                }
            }
        }

        public CsdlEntityContainerModel OwnerEntityContainerModel {
            get {
                return this._OwnerEntityContainerModel;
            }
            set {
                this._OwnerEntityContainerModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public string EntityTypeName {
            get {
                var etmo = this._EntityTypeModelObject;
                if (etmo == null) {
                    return this._EntityTypeName;
                } else {
                    return (etmo.SchemaModel.Namespace ?? string.Empty) + "." + (etmo.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._EntityTypeName, value, StringComparison.OrdinalIgnoreCase)) { return; }
                this._EntityTypeName = value;
                this._EntityTypeModelObject = null;
            }
        }
        public CsdlEntityTypeModel EntityTypeModelObject {
            get {
                if (this._EntityTypeModelObject == null && this._EntityTypeName != null) {
                    var entityContainer = this.EntityContainer;
                    var schema = entityContainer?.SchemaModel;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null) {
                        try {
                            this.ResolveNames(edmxModel, schema, entityContainer, null);
                        } catch {
                        }
                    }

                }
                return this._EntityTypeModelObject;
            }
            set {
                this._EntityTypeModelObject = value;
                this._EntityTypeName = null;
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schema, CsdlEntityContainerModel entityContainer, CsdlErrors errors) {
            var lstNS = edmxModel.FindStart(this.EntityTypeName);
            if (lstNS.Count == 1) {
                (var localName, var schemaFound) = lstNS[0];
                var lstFound = schemaFound.FindEntityType(localName);
                if (lstFound.Count == 1) {
#if DevAsserts
                    var oldEntityTypeName = this.EntityTypeName;
                    this.EntityTypeModelObject = lstFound[0];
                    var newEntityTypeName = this.EntityTypeName;
                    if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                        throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                    }
#else
                    this.EntityTypeModelObject = lstFound[0];
#endif
                } else if (lstFound.Count == 0) {
                    errors.AddError($"{this._EntityTypeName} not found");
                } else {
                    errors.AddError($"{this._EntityTypeName} found #{lstFound.Count} times.");
                }
            } else if (lstNS.Count == 0) {
                errors.AddError($"{this._EntityTypeName} namespace not found");
            } else {
                errors.AddError($"{this._EntityTypeName} namespace found #{lstNS.Count} times.");
            }
        }
    }
}