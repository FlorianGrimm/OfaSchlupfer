namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingModelComplexType
        : MappingObjectString<MappingModelSchema, ModelComplexType> {
        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty> _PropertyMappings;

        public MappingModelComplexType() {
            this._PropertyMappings = new FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty>(this, (owner, item) => { item.Owner = owner; });

        }

        [JsonIgnore]
        public override MappingModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.ComplexTypeMappings);
        }

        public FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty> PropertyMappings => this._PropertyMappings;

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.ComplexTypes.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.ComplexTypes.FindByKey(name), errors);

        public MappingModelProperty CreatePropertyMapping(
            string name,
            ModelProperty source,
            ModelProperty target) {
            var result = new MappingModelProperty {
                Name = name,
                Source = source,
                Target = target
            };
            this.PropertyMappings.Add(result);
            return result;
        }
    }
}
