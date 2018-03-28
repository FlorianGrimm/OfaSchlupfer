using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlEntityContainerModel {
        public CsdlEntityContainerModel() {
            this.EntitySet = new List<CsdlEntitySetModel>();
            this.AssociationSet = new List<CsdlAssociationSetModel>();
        }

        public readonly List<CsdlEntitySetModel> EntitySet;
        public readonly List<CsdlAssociationSetModel> AssociationSet;
    }
}