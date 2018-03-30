using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        public CsdlAssociationEndModel() {
        }

        public string Role;
        public string EntitySetName;
        public string TypeName;

        public string Multiplicity;

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            // TODO: resolve
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel csdlSchemaModel, CsdlAssociationModel csdlAssociationModel, List<string> errors) {
        }
    }
}