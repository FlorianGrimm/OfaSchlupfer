using System;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlPropertyModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;
        private string _TypeName;
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
                return this._TypeName;
            }
            set {
                this._TypeName = value;
            }
        }

        public void BuildNameResolver(CsdlEntityTypeModel entityType, CsdlNameResolver nameResolver) {
            nameResolver.AddProperty(this.SchemaModel.Namespace, entityType.Name, this.Name, this);
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlEntityTypeModel entityTypeModel, CsdlErrors errors) {
            // TODO: resolve this.TypeName
        }
    }
}