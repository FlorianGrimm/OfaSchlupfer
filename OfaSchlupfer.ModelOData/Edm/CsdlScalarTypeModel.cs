namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlScalarTypeModel {
        public string Namespace;
        public string Name;

        public CsdlScalarTypeModel(string @namespace, string name) {
            this.Namespace = @namespace;
            this.Name = name;
        }
    }
}