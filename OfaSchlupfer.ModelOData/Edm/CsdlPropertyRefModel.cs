namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyRefModel : CsdlAnnotationalModel {
        private CsdlSchemaModel _SchemaModel;
        private CsdlReferentialConstraintPartnerModel _OwnerReferentialConstraintPartnerModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
        private string _Name;
        private CsdlPropertyModel _Property;

        public CsdlPropertyRefModel() {
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
                if (!ReferenceEquals(value, this._OwnerEntityTypeModel?.SchemaModel)) {
                    this._OwnerEntityTypeModel = null;
                }
                if (!ReferenceEquals(value, this._OwnerReferentialConstraintPartnerModel?.SchemaModel)) {
                    this._OwnerReferentialConstraintPartnerModel = null;
                }
            }
        }

        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public CsdlReferentialConstraintPartnerModel OwnerReferentialConstraintPartnerModel {
            get {
                return this._OwnerReferentialConstraintPartnerModel;
            }
            set {
                this._OwnerReferentialConstraintPartnerModel = value;
                this.SchemaModel = value?.SchemaModel;
            }
        }
        public string Name {
            get {
                return this._Name;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.OrdinalIgnoreCase)) { return; }
                this._Name = value;
                if ((object)this._Property != null) {
                    if (string.Equals(this._Name, this.Property.Name, StringComparison.OrdinalIgnoreCase)) {
                        this._Property = null;
                    }
                }
            }
        }

        public CsdlPropertyModel Property {
            get {
                if (((object)this._Name != null) && ((object)this._Property == null)) {
                    if ((object)this._OwnerEntityTypeModel != null) {
                        var edmxModel = this.SchemaModel?.EdmxModel;
                        //this._SchemaModel
                        // this._OwnerEntityTypeModel
                        if (((object)edmxModel != null) && ((object)this._SchemaModel != null) && ((object)this._OwnerEntityTypeModel != null)) {
                            try {
                                this.ResolveNames(edmxModel, this._SchemaModel, this._OwnerEntityTypeModel, null);
                            } catch {
                            }
                        }
                    } else if ((object)this._OwnerReferentialConstraintPartnerModel != null) {
                        var edmxModel = this.SchemaModel?.EdmxModel;
                        var ownerReferentialConstraintModel = this._OwnerReferentialConstraintPartnerModel?.OwnerReferentialConstraintModel;
                        var ownerAssociationModel = ownerReferentialConstraintModel?.OwnerAssociationModel;
                        //this._SchemaModel
                        // this._OwnerEntityTypeModel
                        if (((object)edmxModel != null) && ((object)ownerAssociationModel != null)) {
                            try {
                                this.ResolveNames(edmxModel, this._SchemaModel, ownerAssociationModel, ownerReferentialConstraintModel, this._OwnerReferentialConstraintPartnerModel, null);
                            } catch {
                            }
                        }
                    }
                }
                return this._Property;
            }
            set {
                if (ReferenceEquals(this._Property, value)) { return; }
                this._Property = value;
                this._Name = value?.Name;
                //if ((object)value != null) {
                //    this._Name = value.Name;
                //} else {
                //    this._Name = null;
                //}
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlAssociationModel associationModel, CsdlReferentialConstraintModel referentialConstraintModel, CsdlReferentialConstraintPartnerModel csdlReferentialConstraintPartnerModel, CsdlErrors errors) {
            // TODO: resolve this.Name
            
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlEntityTypeModel entityTypeModel, CsdlErrors errors) {
            // TODO
            var lstProperty = entityTypeModel.FindProperty(this.Name);
            if (lstProperty.Count == 1) {
                this.Property = lstProperty[0];
            } else if (lstProperty.Count == 0) {
                errors.AddError("TODO");
            } else {
                errors.AddError("TODO");
            }
            //throw new Exception(this.Name);
        }
    }
}