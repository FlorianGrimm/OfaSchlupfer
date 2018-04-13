namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using OfaSchlupfer.Model;

    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        // parents
        private CsdlAssociationModel _Owner;

        private string _TypeName;
        private CsdlEntityTypeModel _TypeModel;

        public CsdlAssociationEndModel() {
        }

        public string RoleName;

        public string Multiplicity;
        
        public CsdlAssociationModel Owner {
            get {
                return this._Owner;
            }
            set {
                this._Owner = value;
            }
        }

        public string TypeName {
            get {

                var entityTypeModel = this._TypeModel;
                if (entityTypeModel == null) {
                    return this._TypeName;
                } else {
                    return entityTypeModel.FullName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.Ordinal)) { return; }
                this._TypeName = value;
                this._TypeModel = null;
            }
        }

        public CsdlEntityTypeModel TypeModel {
            get {
                if (this._TypeModel == null && this._TypeName != null) {
                    var associationModel = this.Owner;
                    var schema = this._Owner?.SchemaModel;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null && associationModel != null) {
                        this.ResolveNames(ModelErrors.GetIgnorance());
                    }
                }
                return this._TypeModel;
            }
            set {
                this._TypeModel = value;
                this._TypeName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            if (this._TypeModel == null && this._TypeName != null) {
                EdmxModel edmxModel = this._Owner?.SchemaModel?.EdmxModel;
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
                            errors.AddErrorXmlParsing($"{this._TypeName} not found");
                        } else {
                            errors.AddErrorXmlParsing($"{this._TypeName} found #{lstFound.Count} times.");
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorXmlParsing($"{this._TypeName} namespace not found");
                    } else {
                        errors.AddErrorXmlParsing($"{this._TypeName} namespace found #{lstNS.Count} times.");
                    }
                }
            }
        }
    }
}