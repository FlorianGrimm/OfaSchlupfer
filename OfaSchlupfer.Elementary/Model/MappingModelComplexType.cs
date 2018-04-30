namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MappingModelComplexType
        : MappingObjectString<MappingModelSchema, ModelComplexType> {
        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty> _PropertyMappings;

        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelComplexType, MappingModelIndex> _IndexMappings;

        public MappingModelComplexType() {
            this._PropertyMappings = new FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty>(this, (owner, item) => { item.Owner = owner; });
            this._IndexMappings = new FreezableOwnedCollection<MappingModelComplexType, MappingModelIndex>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override MappingModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.ComplexTypeMappings);
        }

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelComplexType, MappingModelProperty> PropertyMappings => this._PropertyMappings;

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelComplexType, MappingModelIndex> IndexMappings => this._IndexMappings;

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

        public MappingModelIndex CreateIndexMapping(
            string name,
            ModelIndex source,
            ModelIndex target) {
            var result = new MappingModelIndex {
                Name = name,
                Source = source,
                Target = target
            };
            this.IndexMappings.Add(result);
            return result;
        }
    }
}
