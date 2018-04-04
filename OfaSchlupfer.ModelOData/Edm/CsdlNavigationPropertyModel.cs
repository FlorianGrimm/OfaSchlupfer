namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlNavigationPropertyModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;

        // V3
        private string _RelationshipName;
        private CsdlAssociationModel _RelationshipModel;
        private string _FromRoleName;
        private CsdlAssociationEndModel _FromRoleModel;
        private string _ToRoleName;
        private CsdlAssociationEndModel _ToRoleModel;

        // V4
        private string _TypeName;
        private ICsdlTypeModel _TypeModel;
        private string _PartnerName;
        private CsdlNavigationPropertyModel _PartnerModel;

        public string Name;

        public CsdlNavigationPropertyModel() {
        }

        // V3
        public string RelationshipName {
            get {
                if (this._RelationshipModel != null) {
                    return this._RelationshipModel.FullName;
                } else {
                    return this._RelationshipName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RelationshipName, value, StringComparison.Ordinal)) { return; }
                this._RelationshipName = value;
                this._RelationshipModel = null;
            }
        }
        public CsdlAssociationModel RelationshipModel {
            get {
                if (this._RelationshipModel == null && this._RelationshipName != null) {
                    this.ResolveNamesRelationship(CsdlErrors.GetIgnorance());
                }
                return this._RelationshipModel;
            }
            set {
                this._RelationshipModel = value;
                this._RelationshipName = null;
            }
        }

        public string FromRoleName {
            get {
                var fromRoleModel1 = this._FromRoleModel;
                if (fromRoleModel1 != null) {
                    return fromRoleModel1.RoleName;
                } else {
                    return this._FromRoleName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._ToRoleName, value, StringComparison.Ordinal)) { return; }
                this._FromRoleName = value;
                this._FromRoleModel = null;
            }
        }

        public CsdlAssociationEndModel FromRoleModel {
            get {
                if (this._ToRoleModel == null && this._ToRoleName != null) {
                    this.ResolveNamesFromRole(CsdlErrors.GetIgnorance());
                }
                return this._FromRoleModel;
            }
            set {
                this._FromRoleModel = value;
                this._FromRoleName = null;
            }
        }

        public string ToRoleName {
            get {
                var toRoleModel = this._ToRoleModel;
                if (toRoleModel != null) {
                    return toRoleModel.RoleName;
                } else {
                    return this._ToRoleName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._ToRoleName, value, StringComparison.Ordinal)) { return; }
                this._ToRoleName = value;
                this._ToRoleModel = null;
            }
        }
        public CsdlAssociationEndModel ToRoleModel {
            get {
                if (this._ToRoleModel == null && this._ToRoleName != null) {
                    this.ResolveNamesToRole(CsdlErrors.GetIgnorance());
                }
                return this._ToRoleModel;
            }
            set {
                this._ToRoleModel = value;
                this._ToRoleName = null;
            }
        }

        public bool ContainsTarget;

        // V4
        public string TypeName {
            get {
                if (this._TypeModel != null) {
                    return this._TypeModel.FullName;
                } else {
                    return this._TypeName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.Ordinal)) { return; }
                this._TypeName = value;
                this._TypeModel = null;
            }
        }

        public ICsdlTypeModel TypeModel {
            get {
                if (this._TypeModel == null && this._TypeName != null) {
                    this.ResolveNamesType(CsdlErrors.GetIgnorance());
                }
                return this._TypeModel;
            }
            set {
                this._TypeModel = value;
                this._TypeName = null;
            }
        }


        public string PartnerName {
            get {
                if (this._PartnerModel != null) {
                    return this._PartnerModel.Name;
                } else {
                    return this._PartnerName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._PartnerName, value, StringComparison.Ordinal)) { return; }
                this._PartnerName = value;
                this._PartnerModel = null;
            }
        }


        public CsdlNavigationPropertyModel PartnerModel {
            get {
                if (this._PartnerModel == null && this._PartnerName != null) {
                    this.ResolveNamesType(CsdlErrors.GetIgnorance());
                }
                return this._PartnerModel;
            }
            set {
                this._PartnerModel = value;
                this._PartnerName = null;
            }
        }

        public bool Nullable;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel => this._SchemaModel;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            // TODO
            this.ResolveNamesRelationship(errors);
            this.ResolveNamesFromRole(errors);
            this.ResolveNamesToRole(errors);
            this.ResolveNamesType(errors);
            this.ResolveNamesPartner(errors);
        }

        public void ResolveNamesRelationship(CsdlErrors errors) {
            if (this._RelationshipModel == null && this._RelationshipName != null) {
                EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindStart(this.RelationshipName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindAssociation(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.RelationshipName;
                            this.RelationshipModel = lstFound[0];
                            var newEntityTypeName = this.RelationshipName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this.RelationshipModel = lstFound[0];
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddError($"{this._RelationshipName} not found");
                        } else {
                            errors.AddError($"{this._RelationshipName} found #{lstFound.Count} times.");
                        }
                    }
                }
            }
        }

        public void ResolveNamesFromRole(CsdlErrors csdlErrors) {
            if (this._FromRoleModel == null && this._FromRoleName != null) {
                var relationshipModel = this._RelationshipModel;
                if (relationshipModel == null) {
                    this.ResolveNamesRelationship(csdlErrors);
                    relationshipModel = this._RelationshipModel;
                }
                if (relationshipModel != null) {
                    var end = relationshipModel.FindAssociationEnd(this.FromRoleName);
                    if (end == null) {
                        csdlErrors.AddError($"FromRole {this._FromRoleName} not found in {this.RelationshipName}.");
                    } else {
                        this.FromRoleModel = end;
                    }
                }
            }
        }

        public void ResolveNamesToRole(CsdlErrors csdlErrors) {
            if (this._ToRoleModel == null && this._ToRoleName != null) {
                var relationshipModel = this._RelationshipModel;
                if (relationshipModel == null) {
                    this.ResolveNamesRelationship(csdlErrors);
                    relationshipModel = this._RelationshipModel;
                }
                if (relationshipModel != null) {
                    var end = relationshipModel.FindAssociationEnd(this.ToRoleName);
                    if (end == null) {
                        csdlErrors.AddError($"ToRole {this._ToRoleName} not found in {this.RelationshipName}.");
                    } else {
                        this.ToRoleModel = end;
                    }
                }
            }
        }

        public void ResolveNamesType(CsdlErrors errors) {
            if (this._TypeModel == null && this._TypeName != null) {
                var collection = CsdlEntityCollectionTypeModel.Create(this._TypeName, this.OwnerEntityTypeModel);
                if (collection != null) {
                    collection.ResolveNames(errors);
                    this.TypeModel = collection;
                    return;
#warning here
                } else {
                    EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
                    if ((edmxModel != null)) {
                        var lstNS = edmxModel.FindStart(this.TypeName);
                        if (lstNS.Count == 1) {
                            (var localName, var schemaFound) = lstNS[0];
                            var lstFound = schemaFound.FindEntityType(localName);
                            if (lstFound.Count == 1) {
#if DevAsserts
                                var oldEntityTypeName = this.TypeName;
                                this.TypeModel = lstFound[0];
                                var newEntityTypeName = this.TypeName;
                                if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                    throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                                }
#else
                                this.TypeModel = lstFound[0];
#endif
                            } else if (lstFound.Count == 0) {
                                errors.AddError($"{this.TypeName} not found");
                            } else {
                                errors.AddError($"{this.TypeName} found #{lstFound.Count} times.");
                            }
                        } else if (lstNS.Count == 0) {
                            errors.AddError($"{this.TypeName} namespace not found");
                        } else {
                            errors.AddError($"{this.TypeName} namespace found #{lstNS.Count} times.");
                        }
                    }
                }
            }
        }
        public void ResolveNamesPartner(CsdlErrors errors) {
            if (this._PartnerModel == null && this._PartnerName != null) {
                var typeModel = this._TypeModel;
                if (typeModel == null) { this.ResolveNamesType(errors); typeModel = this._TypeModel; }
                if (typeModel != null) {
                    var entityTypeModel = typeModel.GetEntityTypeModel();
                    if (entityTypeModel != null) {
                        var lstNavProperty = entityTypeModel.FindNavigationProperty(this._PartnerName);
                        if (lstNavProperty.Count == 1) {
                            this.PartnerModel = lstNavProperty[0];
                        } else if (lstNavProperty.Count == 0) {
                            errors.AddError($"Property {this.PartnerName} in {entityTypeModel.FullName} not found.");
                        } else {
                            errors.AddError($"Property {this.PartnerName} in {entityTypeModel.FullName} found #{lstNavProperty.Count} times.");
                        }
                    }
                }
                // TODO

            }
        }
    }
}