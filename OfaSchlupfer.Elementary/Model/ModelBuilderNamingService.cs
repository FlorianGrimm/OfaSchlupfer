namespace OfaSchlupfer.Model {
    public class ModelBuilderNamingService
        : IModelBuilderNamingService {
        private MappingModelRepository _MappingModelRepository;

        public ModelBuilderNamingService(MappingModelRepository mappingModelRepository) {
            this._MappingModelRepository = mappingModelRepository;
        }

        public virtual bool EntitiesHaveFakeComplexTypes { get; set; }

        public virtual (string targetName, string extenalName) SuggestComplexType(string name) => (name, name);

        public virtual (string targetName, string extenalName, string typeName, string typeExternalName) SuggestEntityName(string name) => (name, name, (this.EntitiesHaveFakeComplexTypes) ? name : null, (this.EntitiesHaveFakeComplexTypes) ? name : null);
    }
}