namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MappingModelBuilder {
#warning HHHHHHEEEEEEEEEERRRRRRRRRRRRREEEEEEEEEEE
        public MappingModelBuilder(MappingModelRepository mappingModelRepository=null) {
            this.MappingModelRepository = mappingModelRepository;
        }

        public MappingModelRepository MappingModelRepository { get; set; }

        public void Build(
            ModelErrors errors
            ) {
            if (this.MappingModelRepository is null) { throw new ArgumentNullException(nameof(this.MappingModelRepository)); }
            var source = this.MappingModelRepository.Source ?? throw new ArgumentNullException(nameof(this.MappingModelRepository.Source));
            var target = this.MappingModelRepository.Target ?? throw new ArgumentNullException(nameof(this.MappingModelRepository.Target));

            this.Build(source.ModelSchema, target.ModelSchema, errors);
            //errors.AddErrorOrThrow(new ModelErrorInfo("", ""));
        }

        public void Build(
            ModelSchema modelSchemaSource, 
            ModelSchema modelSchemaTarget, 
            ModelErrors errors) {
            foreach (var complexTypeSource in modelSchemaSource.ComplexTypes) {
                var complexTypeTarget = new ModelComplexType();
                complexTypeTarget.Name = complexTypeSource.Name;
                complexTypeTarget.ExternalName = complexTypeSource.ExternalName;
                //
                var lstComplexTypeTargetFound = modelSchemaTarget.ComplexTypes.FindByKey(complexTypeSource.Name);
                if (lstComplexTypeTargetFound.Count == 0) {
                    modelSchemaTarget.ComplexTypes.Add(complexTypeTarget);

                    var mappingModelComplexType = new MappingModelComplexType() {
                        Enabled = true,
                        Source = complexTypeSource,
                        Target = complexTypeTarget
                    };

#warning where to store mappingModelComplexType

                } else if (lstComplexTypeTargetFound.Count > 1) {
                    throw new NotImplementedException("(lstComplexTypeTargetFound.Count > 1)");
                } else {
                    complexTypeTarget = lstComplexTypeTargetFound[0];
                }
            }
            foreach (var entitySource in modelSchemaSource.Entities) {
                ModelEntity entityTarget = new ModelEntity();
                entityTarget.Kind = entitySource.Kind;
                entityTarget.Name = entitySource.Name;
                entityTarget.ExternalName = entitySource.ExternalName;

                // entityTarget.EntityType = sourceEntity.EntityType;
                entityTarget.EntityTypeName = entitySource.EntityTypeName;

                modelSchemaTarget.Entities.Add(entityTarget);
                var mappingModelEntity = new MappingModelEntity() {
                    Enabled=true,
                    Source=entitySource,
                    Target=entityTarget
                };
#warning where to store mappingModelEntity
            }
        }
    }
}
