using System;
using Newtonsoft.Json;
using OfaSchlupfer.Freezable;
using OfaSchlupfer.Model;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlPropertyModel : CsdlAnnotationalModel {
        // parents
        private CsdlEntityTypeModel _Owner;
        private string _TypeName;
        private CsdlScalarTypeModel _ScalarType;
        public string Name;

        public bool Nullable;
        public int MaxLength;
        public bool FixedLength;
        public int Precision;
        public int Scale;
        public bool Unicode;
        public string Collation;
        public string SRID;
        public string DefaultValue;
        public string ConcurrencyMode;

        public CsdlPropertyModel() {
            this.Nullable = true;
            this.Unicode = true;
        }

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

        // TODO: Collection(Edm.DateTime)
        [JsonProperty]
        public string TypeName {
            get {
                if (this._ScalarType != null) {
                    return this._ScalarType.FullName;
                } else {
                    return this._TypeName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.Ordinal)) { return; }
                this._TypeName = value;
                this._ScalarType = null;
            }
        }

        [JsonProperty]
        public CsdlScalarTypeModel ScalarType {
            get {
                if (this._ScalarType == null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._ScalarType;
            }
            set {
                this._ScalarType = value;
                this._TypeName = null;
            }
        }

        public void ResolveNames(ModelErrors errors) {
            if (this._ScalarType == null && this._TypeName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if (edmxModel != null) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.TypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindScalarType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.TypeName;
                            this.ScalarType = lstFound[0];
                            var newEntityTypeName = this.TypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this.ScalarType = lstFound[0];
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
}