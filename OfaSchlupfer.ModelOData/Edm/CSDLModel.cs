using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlModel : EdmxDataService {
        public readonly List<CsdlEntityTypeModel> EntityType;
        public readonly List<CsdlEntityContainerModel> EntityContainer;
        public readonly List<CsdlAssociationModel> Association;

        public CsdlModel() {
            this.EntityType = new List<CsdlEntityTypeModel>();
            this.EntityContainer = new List<CsdlEntityContainerModel>();
            this.Association = new List<CsdlAssociationModel>();
        }

    }
}