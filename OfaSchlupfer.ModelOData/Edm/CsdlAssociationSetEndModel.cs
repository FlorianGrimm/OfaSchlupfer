namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CsdlAssociationSetEndModel : CsdlAnnotationalModel {
        private CsdlAssociationSetModel _OwnerAssociationSet;
        private string _EntitySetName;
        private CsdlEntitySetModel _EntitySetModel;

        public CsdlAssociationSetEndModel() {
        }

        public CsdlAssociationSetModel OwnerAssociationSet {
            get {
                return this._OwnerAssociationSet;
            }
            set {
                this._OwnerAssociationSet = value;
            }
        }

        public string RoleName { get; set; }

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
                this._EntitySetName = value;
                this._EntitySetModel = null;
            }
        }

        public CsdlEntitySetModel EntitySetModel {
            get {
                if ((object)this._EntitySetModel == null) {
                    var entityContainerModel = this.OwnerAssociationSet.OwnerEntityContainerModel;
                    var schemaModel = entityContainerModel?.SchemaModel;
                    var edmxModel = schemaModel?.EdmxModel;
                    if (edmxModel != null) {
                        this.ResolveNames(CsdlErrors.GetIgnorance());
                    }
                }
                return this._EntitySetModel;
            }
            set {
                this._EntitySetModel = value;
                this._EntitySetName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            this.ResolveNamesEntitySetName(errors);
        }

        public void ResolveNamesEntitySetName(CsdlErrors errors) {
            if (this._EntitySetModel == null && this._EntitySetName != null) {
                var entityContainer = this.OwnerAssociationSet?.OwnerEntityContainerModel;
                if ((entityContainer != null)) {
                    var lstFound = entityContainer.FindEntitySet(this.EntitySetName);
                    if (lstFound.Count == 1) {
#if DevAsserts
                    var oldEntityTypeName = this.EntityTypeName;
                    this.EntityTypeModelObject = lstFound[0];
                    var newEntityTypeName = this.EntityTypeName;
                    if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                        throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                    }
#else
                        this.EntitySetModel = lstFound[0];
#endif
                    } else if (lstFound.Count == 0) {
                        errors.AddError($"{this._EntitySetName} not found");
                    } else {
                        errors.AddError($"{this._EntitySetName} found #{lstFound.Count} times.");
                    }
                }
            }
        }
    }
}