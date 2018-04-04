namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CsdlEntityCollectionTypeModel : ICsdlTypeModel {
        private static Regex regexIsCollection;
        public static string IsCollection(string typename) {
            Regex regex = regexIsCollection ?? (regexIsCollection = new Regex(@"^Collection\(([^()]+)\)$", RegexOptions.Compiled));
            var match = regex.Match(typename);
            if (match.Success) {
                return match.Groups[1].Value;
            } else {
                return null;
            }
        }
        public static CsdlEntityCollectionTypeModel Create(string collection, CsdlEntityTypeModel ownerEntityTypeModel) {
            var entityTypeName = IsCollection(collection);
            if (entityTypeName != null) {
                var result = new CsdlEntityCollectionTypeModel();
                result.OwnerEntityTypeModel = ownerEntityTypeModel;
                result.EntityTypeName = entityTypeName;
                return result;
            }
            return null;
        }

        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;

        private string _EntityTypeName;
        private CsdlEntityTypeModel _EntityTypeModel;


        public CsdlEntityCollectionTypeModel() { }


        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public string FullName => $"Collection({ this.EntityTypeName })";
        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => this.EntityTypeModel;

        public string EntityTypeName {
            get {
                var entityTypeModel = this._EntityTypeModel;
                if (entityTypeModel == null) {
                    return this._EntityTypeName;
                } else {
                    return entityTypeModel.FullName;
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
                    this.ResolveNames(CsdlErrors.GetIgnorance());
                }
                return this._EntityTypeModel;
            }
            set {
                this._EntityTypeModel = value;
                this._EntityTypeName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                EdmxModel edmxModel = this._SchemaModel?.EdmxModel;
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
    }
}