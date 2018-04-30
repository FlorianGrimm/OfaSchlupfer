namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class CsdlEntityCollectionTypeModel
        : FreezableObject
        , ICsdlTypeModel {
        private static Regex regexIsCollection;

        /// <summary>
        /// Get the collection item typename.
        /// </summary>
        /// <param name="typename">the typename</param>
        /// <returns>null or Collection(result).</returns>
        public static string GetCollectionItemTypeName(string typename) {
            Regex regex = regexIsCollection ?? (regexIsCollection = new Regex(@"^Collection\(([^()]+)\)$", RegexOptions.Compiled));
            var match = regex.Match(typename);
            if (match.Success) {
                return match.Groups[1].Value;
            } else {
                return null;
            }
        }

        public static CsdlEntityCollectionTypeModel Create(string collection, CsdlEntityTypeModel ownerEntityTypeModel) {
            var entityTypeName = GetCollectionItemTypeName(collection);
            if (entityTypeName != null) {
                var result = new CsdlEntityCollectionTypeModel {
                    Owner = ownerEntityTypeModel,
                    EntityTypeName = entityTypeName
                };
                return result;
            }
            return null;
        }

        // parents
        private CsdlEntityTypeModel _Owner;

        private string _EntityTypeName;
        private CsdlEntityTypeModel _EntityTypeModel;


        public CsdlEntityCollectionTypeModel() { }

        [JsonIgnore]
        public CsdlEntityTypeModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

        [JsonIgnore]
        public string FullName => $"Collection({ this.EntityTypeName })";

        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => this.EntityTypeModel;

        [JsonProperty]
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
                this.ThrowIfFrozen();
                this._EntityTypeName = value;
                this._EntityTypeModel = null;
            }
        }

        [JsonIgnore]
        public CsdlEntityTypeModel EntityTypeModel {
            get {
                if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._EntityTypeModel;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityTypeModel = value;
                this._EntityTypeName = null;
            }
        }

        public CsdlEntityTypeModel ResolveNames(ModelErrors errors) {
            if (this._EntityTypeModel == null && this._EntityTypeName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if ((edmxModel != null)) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.EntityTypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindEntityType(localName);
                        if (lstFound.Count == 1) {
#if !DevAsserts
                            var oldEntityTypeName = this.EntityTypeName;
                            this._EntityTypeModel = lstFound[0];
                            this._EntityTypeName = null;
                            var newEntityTypeName = this.EntityTypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this._EntityTypeModel = lstFound[0];
                            this._EntityTypeName = null;
#endif
                            return lstFound[0];
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this._EntityTypeName} not found", this.FullName, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this._EntityTypeName} found #{lstFound.Count} times.", this.FullName, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this._EntityTypeName} namespace not found", this.FullName, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this._EntityTypeName} namespace found #{lstNS.Count} times.", this.FullName, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
            return this._EntityTypeModel;
        }
    }
}