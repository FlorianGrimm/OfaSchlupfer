namespace OfaSchlupfer.Model {
    public interface IModelBuilderNamingService {
        bool EntitiesHaveFakeComplexTypes { get; set; }

        (string targetName, string extenalName) SuggestComplexType(string name);

        (string targetName, string extenalName, string typeName, string typeExternalName) SuggestEntityName(string name);
    }
}