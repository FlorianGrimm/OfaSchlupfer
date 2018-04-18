namespace OfaSchlupfer.ModelSql {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.MSSQLReflection.Model;

    public class SQLSModelSchemaBuilder {
        public void Build(
            ModelSqlDatabase modelDatabase, 
            ModelSchema modelSchema,
            MetaModelBuilder metaModelBuilder,
            ModelErrors errors) {
            if (modelSchema == null) { modelSchema = new ModelSchema(); }
            if (metaModelBuilder == null) { metaModelBuilder = new MetaModelBuilder(); }

            // modelDatabase.Freeze();

            foreach (var table in modelDatabase.Tables.Values) {
                
                var entityTypeModelName = table.Name.GetQFullName(null, 2);
                var entityTypeModelFullName = entityTypeModelName;

                var modelComplexType = metaModelBuilder.CreateModelComplexType(
                      entityTypeModelName,
                      entityTypeModelFullName,
                      errors);

                //if (modelComplexType.Owner == null) {
                    modelSchema.ComplexTypes.Add(modelComplexType);
                //}

            }
        }
    }
}
