namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlScalarTypeModel : ICsdlTypeModel {
        public string Namespace;
        public string Name;

        public CsdlScalarTypeModel(string @namespace, string name) {
            this.Namespace = @namespace;
            this.Name = name;
        }

        public CsdlSchemaModel SchemaModel { get; set; }
        public string FullName => this.Namespace + "." + this.Name;
        CsdlEntityTypeModel ICsdlTypeModel.GetEntityTypeModel() => null;
    }
}