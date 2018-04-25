namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OfaSchlupfer.Model;

    public class SqlModelBuilderNamingService
            : ModelBuilderNamingService {
        public SqlModelBuilderNamingService(MappingModelRepository mappingModelRepository)
            : base(mappingModelRepository) {
            this.EntitiesHaveFakeComplexTypes = true;
        }

        public override (string targetName, string extenalName) SuggestComplexType(string name) {
#warning SOON think of
            return base.SuggestComplexType(name);
        }

        public override (string targetName, string extenalName, string typeName, string typeExternalName) SuggestEntityName(string targetName) {
            if (this.EntitiesHaveFakeComplexTypes) {
#warning TODO good solution for $"[dbo].[{targetName}]";
                string extenalName = $"[dbo].[{targetName}]";
                return (targetName, extenalName, targetName, extenalName);
            } else {
                return base.SuggestEntityName(targetName);
            }
        }
    }
}
