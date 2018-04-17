namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MetaModelBuilder {
        public MetaModelBuilder() {
        }
#warning add rules

        public ModelEntity CreateModelEntity(
            string entityName,
            ModelErrors errors) {
            var result = new ModelEntity();
            result.Name = entityName;
            result.ExternalName = entityName;
            return result;
        }

        public ModelComplexType CreateModelComplexType(
            string complexTypeName,
            ModelErrors errors) {
            var result = new ModelComplexType();
            result.Name = complexTypeName;
            result.ExternalName = complexTypeName;
            return result;
        }

        public ModelProperty CreateModelProperty(
            string complexTypeName,
            string propertyName,
            ModelErrors errors
            ) {
            var result = new ModelProperty();
            result.Name = propertyName;
            result.ExternalName = propertyName;
            return result;
        }

        public ModelScalarType CreateModelScalarType(
            string complexTypeName,
            string propertyName,
            string scalarTypeName,
            ModelScalarType suggestedType,
            short maxLentgth,
            bool fixedLength,
            bool nullable,
            byte precision,
            byte scale,
            ModelErrors errors
            ) {
            if (suggestedType != null) {
                return suggestedType;
            } else {
                var result = new ModelScalarType();
                result.Name = scalarTypeName;
                result.MaxLength = maxLentgth;
                result.FixedLength = fixedLength;
                result.Nullable = nullable;
                result.Precision = precision;
                result.Scale = scale;
#warning CreateModelScalarType
                return result;
            }
        }

        public ModelScalarType CreateModelScalarType(IModelScalarTypeFacade modelScalarTypeFacade, List<ModelScalarType> results) {
            if (results.Count > 0) {
                return results[0];
            } else {
                return null;
            }
        }
    }
}
