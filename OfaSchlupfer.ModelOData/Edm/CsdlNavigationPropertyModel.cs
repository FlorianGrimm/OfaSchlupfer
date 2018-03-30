namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlNavigationPropertyModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityTypeModel _OwnerEntityTypeModel;

        public string Name;
        // V3
        public string Relationship;
        public string FromRole;
        public string ToRole;
        public bool ContainsTarget;

        // V4
        public string TypeName;
        public string Partner;
        public bool Nullable;

        public CsdlNavigationPropertyModel() {
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

        public CsdlEntityTypeModel OwnerEntityTypeModel {
            get {
                return this._OwnerEntityTypeModel;
            }
            set {
                this._OwnerEntityTypeModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public void BuildNameResolver(CsdlEntityTypeModel entityType, CsdlNameResolver nameResolver) {
            nameResolver.AddNavigationProperty(this.SchemaModel.Namespace, entityType.Name, this.Name, this);
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schemaModel, CsdlEntityTypeModel entityTypeModel, CsdlErrors errors) {
            // TODO: resolve
        }
    }
}