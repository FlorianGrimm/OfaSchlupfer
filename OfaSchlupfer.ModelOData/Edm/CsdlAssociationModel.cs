using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlAssociationModel {
        public CsdlAssociationModel() {
            this.AssociationEnd = new List<CsdlAssociationEndModel>();
            this.ReferentialConstraint = new List<CsdlReferentialConstraintModel>();
        }

        public readonly List<CsdlAssociationEndModel> AssociationEnd;
        public readonly List<CsdlReferentialConstraintModel> ReferentialConstraint;
    }
}