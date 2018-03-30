using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        // parents
        private CsdlSchemaModel _SchemaModel;
        private CsdlAssociationModel _OwnerAssociationModel;

        public CsdlAssociationEndModel() {
        }

        public string Role;
        public string EntitySetName;
        public string TypeName;

        public string Multiplicity;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if (!ReferenceEquals(value, this._OwnerAssociationModel?.SchemaModel)) {
                    this._OwnerAssociationModel = null;
                }
            }
        }

        public CsdlAssociationModel OwnerAssociationModel {
            get {
                return this._OwnerAssociationModel;
            }
            set {
                this._OwnerAssociationModel = value;
                this._SchemaModel = value?.SchemaModel;
            }
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            // TODO: resolve
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel csdlSchemaModel, CsdlAssociationModel csdlAssociationModel, CsdlErrors errors) {
        }
    }
}