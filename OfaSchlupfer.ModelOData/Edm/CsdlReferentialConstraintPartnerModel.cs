using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlReferentialConstraintPartnerModel : CsdlAnnotationalModel {
        public readonly List<CsdlPropertyRefModel> PropertyRef;
        public string Role;

        public CsdlReferentialConstraintPartnerModel() {
            this.PropertyRef = new List<CsdlPropertyRefModel>();
        }
    }
}