using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlAssociationSetModel : CsdlAnnotationalModel {
        public string Association;
        public string Name;

        public CsdlAssociationSetModel() {
        }


        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }

        public void BuildNameResolver(CsdlEntityContainerModel entityContainer, CsdlNameResolver nameResolver) {
            nameResolver.AddAssociationSet(this.SchemaModel.Namespace, entityContainer.Name, this.Name, this);
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schema, CsdlEntityContainerModel entityContainer, List<string> errors) {
            // TODO: resolve
        }
    }
}