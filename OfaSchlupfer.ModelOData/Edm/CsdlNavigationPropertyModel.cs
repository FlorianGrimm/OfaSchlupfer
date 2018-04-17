namespace OfaSchlupfer.ModelOData.Edm {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlNavigationPropertyModel
        : FreezeableObject {
        // parents
        [JsonIgnore]
        private CsdlEntityTypeModel _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private bool _Nullable;

        // V3
        [JsonIgnore]
        private string _RelationshipName;
        [JsonIgnore]
        private CsdlAssociationModel _RelationshipModel;
        [JsonIgnore]
        private string _FromRoleName;
        [JsonIgnore]
        private CsdlAssociationEndModel _FromRoleModel;
        [JsonIgnore]
        private string _ToRoleName;
        [JsonIgnore]
        private CsdlAssociationEndModel _ToRoleModel;

        // V4
        [JsonIgnore]
        private string _TypeName;
        [JsonIgnore]
        private ICsdlTypeModel _TypeModel;
        [JsonIgnore]
        private string _PartnerName;
        [JsonIgnore]
        private CsdlNavigationPropertyModel _PartnerModel;

        [JsonIgnore]
        private FreezeableOwnedCollection<CsdlNavigationPropertyModel, CsdlReferentialConstraintV4Model> _ReferentialConstraint;

        public CsdlNavigationPropertyModel() {
            this._ReferentialConstraint = new FreezeableOwnedCollection<CsdlNavigationPropertyModel, CsdlReferentialConstraintV4Model>(
                this,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        // V3
        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._RelationshipName = value;
                this._RelationshipModel = null;
            }
        }

        [JsonIgnore]
        public CsdlAssociationModel RelationshipModel {
            get {
                if (this._RelationshipModel == null && this._RelationshipName != null) {
                    return this.ResolveNamesRelationship(ModelErrors.GetIgnorance());
                }
                return this._RelationshipModel;
            }
            set {
                this.ThrowIfFrozen();
                this._RelationshipModel = value;
                this._RelationshipName = null;
            }
        }

        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._FromRoleName = value;
                this._FromRoleModel = null;
            }
        }

        [JsonIgnore]
        public CsdlAssociationEndModel FromRoleModel {
            get {
                if (this._ToRoleModel == null && this._ToRoleName != null) {
                    this.ResolveNamesFromRole(ModelErrors.GetIgnorance());
                }
                return this._FromRoleModel;
            }
            set {
                this.ThrowIfFrozen();
                this._FromRoleModel = value;
                this._FromRoleName = null;
            }
        }

        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._ToRoleName = value;
                this._ToRoleModel = null;
            }
        }

        [JsonIgnore]
        public CsdlAssociationEndModel ToRoleModel {
            get {
                if (this._ToRoleModel == null && this._ToRoleName != null) {
                    this.ResolveNamesToRole(ModelErrors.GetIgnorance());
                }
                return this._ToRoleModel;
            }
            set {
                this.ThrowIfFrozen();
                this._ToRoleModel = value;
                this._ToRoleName = null;
            }
        }

        public bool ContainsTarget;

        // V4
        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._TypeName = value;
                this._TypeModel = null;
            }
        }

        [JsonIgnore]
        public ICsdlTypeModel TypeModel {
            get {
                if (this._TypeModel == null && this._TypeName != null) {
                    this.ResolveNamesType(ModelErrors.GetIgnorance());
                }
                return this._TypeModel;
            }
            set {
                this.ThrowIfFrozen();
                this._TypeModel = value;
                this._TypeName = null;
            }
        }

        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._PartnerName = value;
                this._PartnerModel = null;
            }
        }


        [JsonIgnore]
        public CsdlNavigationPropertyModel PartnerModel {
            get {
                if (this._PartnerModel == null && this._PartnerName != null) {
                    this.ResolveNamesType(ModelErrors.GetIgnorance());
                }
                return this._PartnerModel;
            }
            set {
                this.ThrowIfFrozen();
                this._PartnerModel = value;
                this._PartnerName = null;
            }
        }


        [JsonProperty]
        public bool Nullable {
            get {
                return this._Nullable;
            }
            set {
                this.ThrowIfFrozen();
                this._Nullable = value;
            }
        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public CsdlEntityTypeModel Owner {
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
        public FreezeableOwnedCollection<CsdlNavigationPropertyModel, CsdlReferentialConstraintV4Model> ReferentialConstraint => this._ReferentialConstraint;

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesRelationship(errors);
            this.ResolveNamesFromRole(errors);
            this.ResolveNamesToRole(errors);
            this.ResolveNamesType(errors);
            this.ResolveNamesPartner(errors);
            foreach (var referentialConstraint in this.ReferentialConstraint) {
                referentialConstraint.ResolveNames(errors);
            }
        }

        public CsdlAssociationModel ResolveNamesRelationship(ModelErrors errors) {
            if (this._RelationshipModel == null && this._RelationshipName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.RelationshipName);
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
                            this._RelationshipModel = lstFound[0];
                            this._RelationshipName = null;
#endif
                            return lstFound[0];
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this._RelationshipName} not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this._RelationshipName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this._RelationshipName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._RelationshipName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
            return this._RelationshipModel;
        }

        public void ResolveNamesFromRole(ModelErrors csdlErrors) {
            if (this._FromRoleModel == null && this._FromRoleName != null) {
                var relationshipModel = this._RelationshipModel;
                if (relationshipModel == null) {
                    this.ResolveNamesRelationship(csdlErrors);
                    relationshipModel = this._RelationshipModel;
                }
                if (relationshipModel != null) {
                    var lstEnd = relationshipModel.FindAssociationEnd(this.FromRoleName);
                    if (lstEnd.Count == 1) {
                        this._FromRoleModel = lstEnd[0];
                        this._FromRoleName = null;
                    } else if (lstEnd.Count == 0) {
                        csdlErrors.AddErrorOrThrow($"FromRole {this._FromRoleName} not found in {this.RelationshipName}.", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        csdlErrors.AddErrorOrThrow($"FromRole {this._FromRoleName}  found #{lstEnd.Count} times in {this.RelationshipName}.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }

        public void ResolveNamesToRole(ModelErrors csdlErrors) {
            if (this._ToRoleModel == null && this._ToRoleName != null) {
                var relationshipModel = this._RelationshipModel;
                if (relationshipModel == null) {
                    this.ResolveNamesRelationship(csdlErrors);
                    relationshipModel = this._RelationshipModel;
                }
                if (relationshipModel != null) {
                    var lstEnd = relationshipModel.FindAssociationEnd(this.ToRoleName);
                    if (lstEnd.Count == 1) {
                        this._ToRoleModel = lstEnd[0];
                        this._ToRoleName = null;
                    } else if (lstEnd.Count == 0) {
                        csdlErrors.AddErrorOrThrow($"ToRole {this._FromRoleName} not found in {this.RelationshipName}.", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        csdlErrors.AddErrorOrThrow($"ToRole {this._FromRoleName}  found #{lstEnd.Count} times in {this.RelationshipName}.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }

        public void ResolveNamesType(ModelErrors errors) {
            if (this._TypeModel == null && this._TypeName != null) {
#warning ResolveNamesType collection
                var collection = CsdlEntityCollectionTypeModel.Create(this._TypeName, this.Owner);
                if (collection != null) {
                    collection.ResolveNames(errors);
                    this._TypeModel = collection;
                    return;
                } else {
                    EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                    if ((edmxModel != null)) {
                        var lstNS = edmxModel.FindDataServicesWithStart(this.TypeName);
                        if (lstNS.Count == 1) {
                            (var localName, var schemaFound) = lstNS[0];
                            var lstFound = schemaFound.FindEntityType(localName);
                            if (lstFound.Count == 1) {
#if !DevAsserts
                                var oldTypeName = this.TypeName;
                                this._TypeModel = lstFound[0];
                                this._TypeName = null;
                                var newTypeName = this.TypeName;
                                if (!string.Equals(oldTypeName, newTypeName, StringComparison.Ordinal)) {
                                    throw new Exception($"{oldTypeName} != {newTypeName}");
                                }
#else
                                this._TypeModel = lstFound[0];
                                this._TypeName = null;
#endif
                            } else if (lstFound.Count == 0) {
                                errors.AddErrorOrThrow($"{this.TypeName} not found", this.Name, ResolveNameNotFoundException.Factory);
                            } else {
                                errors.AddErrorOrThrow($"{this.TypeName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                            }
                        } else if (lstNS.Count == 0) {
                            errors.AddErrorOrThrow($"{this.TypeName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this.TypeName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    }
                }
            }
        }

        public CsdlNavigationPropertyModel ResolveNamesPartner(ModelErrors errors) {
            if (this._PartnerModel == null && this._PartnerName != null) {
                var typeModel = this._TypeModel;
                if (typeModel == null) { this.ResolveNamesType(errors); typeModel = this._TypeModel; }
                if (typeModel != null) {
                    var entityTypeModel = typeModel.GetEntityTypeModel();
                    if (entityTypeModel != null) {
                        var lstNavProperty = entityTypeModel.FindNavigationProperty(this._PartnerName);
                        if (lstNavProperty.Count == 1) {
                            this._PartnerModel = lstNavProperty[0];
                            this._PartnerName = null;
                            return lstNavProperty[0]; ;
                        } else if (lstNavProperty.Count == 0) {
                            errors.AddErrorOrThrow($"Property {this.PartnerName} in {entityTypeModel.FullName} not found.", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"Property {this.PartnerName} in {entityTypeModel.FullName} found #{lstNavProperty.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    }
                }
                // TODO
            }
            return this._PartnerModel;
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ReferentialConstraint.Freeze();
            }
            return result;
        }
    }
}