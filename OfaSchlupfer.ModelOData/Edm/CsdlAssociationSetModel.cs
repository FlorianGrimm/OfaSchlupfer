using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationSetModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlEntityContainerModel _OwnerEntityContainerModel;

        public string Association;
        public string Name;

        public CsdlAssociationSetModel() {
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
                if (!ReferenceEquals(value, this._OwnerEntityContainerModel?.SchemaModel)) {
                    this._OwnerEntityContainerModel = null;
                }
            }
        }

        public CsdlEntityContainerModel OwnerEntityContainerModel {
            get {
                return this._OwnerEntityContainerModel;
            }
            set {
                this._OwnerEntityContainerModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public void BuildNameResolver(CsdlEntityContainerModel entityContainer, CsdlNameResolver nameResolver) {
            nameResolver.AddAssociationSet(this.SchemaModel.Namespace, entityContainer.Name, this.Name, this);
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schema, CsdlEntityContainerModel entityContainer, CsdlErrors errors) {
            // TODO: resolve
        }
    }
}