namespace OfaSchlupfer.ModelOData.Edm {
    public interface ICsdlTypeModel {
        string FullName { get; }
        CsdlEntityTypeModel GetEntityTypeModel();
    }
}
