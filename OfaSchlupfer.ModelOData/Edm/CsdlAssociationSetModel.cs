using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationSetModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityContainerModel _OwnerEntityContainerModel;

        private string _Name;
        public readonly CsdlCollection<CsdlAssociationSetEndModel> End;

        private string _AssociationName;
        private CsdlAssociationModel _AssociationModel;

        public CsdlAssociationSetModel() {
            this.End = new CsdlCollection<CsdlAssociationSetEndModel>((item) => { item.OwnerAssociationSet = this; });
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

        public string AssociationName {
            get {
                var associationModel = this._AssociationModel;
                if (associationModel == null) {
                    return this._AssociationName;
                } else {
                    return (associationModel.SchemaModel.Namespace ?? string.Empty) + "." + (associationModel.Name ?? string.Empty);
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._AssociationName, value, StringComparison.Ordinal)) { return; }
                this._AssociationName = value;
                this._AssociationModel = null;
            }
        }

        public CsdlAssociationModel AssociationModel {
            get {
                if (this._AssociationModel == null) {
                    if (this.OwnerEntityContainerModel != null) {
                        var schemaModel = this.OwnerEntityContainerModel?.SchemaModel;
                        var edmxModel = schemaModel?.EdmxModel;
                        if (edmxModel != null) {
                            this.ResolveNamesAssociation(CsdlErrors.GetIgnorance());
                        }
                    }

                }
                return this._AssociationModel;
            }
            set {
                if (ReferenceEquals(this._AssociationModel, value)) { return; }
                this._AssociationModel = value;
                this._AssociationName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            this.ResolveNamesAssociation(errors);
            foreach (var end in this.End) {
                end.ResolveNames(errors);
            }
        }

        public void ResolveNamesAssociation(CsdlErrors errors) {
            if (this._AssociationModel == null && this._AssociationName != null) {
                EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindStart(this.AssociationName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindAssociation(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                    var oldEntityTypeName = this.EntityTypeName;
                    this.EntityTypeModelObject = lstFound[0];
                    var newEntityTypeName = this.EntityTypeName;
                    if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                        throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                    }
#else
                            this.AssociationModel = lstFound[0];
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddError($"{this._AssociationName} not found");
                        } else {
                            errors.AddError($"{this._AssociationName} found #{lstFound.Count} times.");
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddError($"{this._AssociationName} namespace not found");
                    } else {
                        errors.AddError($"{this._AssociationName} namespace found #{lstNS.Count} times.");
                    }
                }
            }
        }
    }
}