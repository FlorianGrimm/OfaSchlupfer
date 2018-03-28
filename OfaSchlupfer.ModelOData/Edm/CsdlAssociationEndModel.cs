namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlAssociationEndModel : CsdlAnnotationalModel {
        public CsdlAssociationEndModel() {
        }

        public string Role;
        public string EntitySet;
        public string Type;

        public string Multiplicity;
    }
}