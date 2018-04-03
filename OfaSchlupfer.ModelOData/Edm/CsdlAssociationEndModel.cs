namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlAssociationModel _OwnerAssociationModel;

        private string _TypeName;
        private CsdlEntityTypeModel _TypeModel;

        public CsdlAssociationEndModel() {
        }

        public string RoleName;
        //public string EntitySetName;

        public string Multiplicity;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if (!ReferenceEquals(value, this._OwnerAssociationModel?.SchemaModel)) {
                    this._OwnerAssociationModel = null;
                }
            }
        }

        public CsdlAssociationModel OwnerAssociationModel {
            get {
                return this._OwnerAssociationModel;
            }
            set {
                this._OwnerAssociationModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public string TypeName {
            get {

                var entityTypeModel = this._TypeModel;
                if (entityTypeModel == null) {
                    return this._TypeName;
                } else {
                    return (entityTypeModel.SchemaModel.Namespace ?? string.Empty) + "." + (entityTypeModel.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.OrdinalIgnoreCase)) { return; }
                this._TypeName = value;
                this._TypeModel = null;
            }
        }

        public CsdlEntityTypeModel TypeModel {
            get {
                if (this._TypeModel == null && this._TypeName != null) {
                    var associationModel = this.OwnerAssociationModel;
                    var schema = this.SchemaModel;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null && associationModel != null) {
                        this.ResolveNames(CsdlErrors.GetIgnorance());
                    }
                }
                return this._TypeModel;
            }
            set {
                this._TypeModel = value;
                this._TypeName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
            if ((edmxModel != null)) {
                var lstNS = edmxModel.FindStart(this.TypeName);
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
                        this.TypeModel = lstFound[0];
#endif
                    } else if (lstFound.Count == 0) {
                        errors.AddError($"{this._TypeName} not found");
                    } else {
                        errors.AddError($"{this._TypeName} found #{lstFound.Count} times.");
                    }
                } else if (lstNS.Count == 0) {
                    errors.AddError($"{this._TypeName} namespace not found");
                } else {
                    errors.AddError($"{this._TypeName} namespace found #{lstNS.Count} times.");
                }
            }
        }
    }
}