using System;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
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
            }
        }

        public CsdlEntityTypeModel ÒwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        // TODO: Collection(Edm.DateTime)
        public string TypeName {
            get {
                if (this._ScalarType != null) {
                    return this._ScalarType.FullName;
                } else {
                    return this._TypeName;
                }
            }
            set {
                this._TypeName = value;
                this._ScalarType = null;
            }
        }

        public CsdlScalarTypeModel ScalarType {
            get {
                if (this._ScalarType == null) {
                    this.ResolveNames(CsdlErrors.GetIgnorance());
                }
                return this._ScalarType;
            }
            set {
                this._ScalarType = value;
                this._TypeName = null;
            }
        }

        public void ResolveNames(CsdlErrors errors) {
            EdmxModel edmxModel = this.SchemaModel?.EdmxModel;
            if ((edmxModel != null) && (this.ÒwnerEntityTypeModel != null)) {
                var lstNS = edmxModel.FindStart(this.TypeName);
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