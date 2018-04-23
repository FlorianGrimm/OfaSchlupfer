namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingModelSchema
        : MappingObjectString<MappingModelRepository, ModelSchema> {
        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingModelSchema, MappingModelComplexType> _ComplexTypeMappings;
           
        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity> _EntityMappings;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation> _RelationMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelSchema, MappingModelComplexType> ComplexTypeMappings => this._ComplexTypeMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity> EntityMappings => this._EntityMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation> RelationMappings => this._RelationMappings;
        
        public MappingModelSchema() {
            this._ComplexTypeMappings = new FreezeableOwnedCollection<MappingModelSchema, MappingModelComplexType>(this, (owner, item) => { item.Owner = owner; });
            this._EntityMappings = new FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity>(this, (owner, item) => { item.Owner = owner; });
            this._RelationMappings = new FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation>(this, (owner, item) => { item.Owner = owner; });
        }

        /*
        [JsonIgnore]
        public override MappingModelRepository Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.r);
        }
        */

        public virtual void ResolveNames(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var modelSchema = this.Owner.Source?.ModelSchema;
                if (modelSchema != null) {
                    this._Source = modelSchema;
                    this._SourceName = null;
                }
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                var modelSchema = this.Owner.Target?.ModelSchema;
                if (modelSchema != null) {
                    this._Target = modelSchema;
                    this._TargetName = null;
                }
            }
        }

        public MappingModelEntity CreateEntityMapping(string name, ModelEntity source, ModelEntity target) {
            var result = new MappingModelEntity();
            result.Name = name;
            result.Source = source;
            result.Target = target;
            this.EntityMappings.Add(result);
            return result;
        }

        public MappingModelComplexType CreateComplexTypeMapping(string name, ModelComplexType source, ModelComplexType target) {
            var result = new MappingModelComplexType();
            result.Name = name;
            result.Source = source;
            result.Target = target;
            this.ComplexTypeMappings.Add(result);
            return result;
        }
    }
}
