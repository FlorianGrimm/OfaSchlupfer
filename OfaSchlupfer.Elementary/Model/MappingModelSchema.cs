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
        private readonly FreezableOwnedCollection<MappingModelSchema, MappingModelComplexType> _ComplexTypeMappings;
           
        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelSchema, MappingModelEntity> _EntityMappings;

        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelSchema, MappingModelRelation> _RelationMappings;

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelSchema, MappingModelComplexType> ComplexTypeMappings => this._ComplexTypeMappings;

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelSchema, MappingModelEntity> EntityMappings => this._EntityMappings;

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelSchema, MappingModelRelation> RelationMappings => this._RelationMappings;

        public MappingModelSchema() {
            this._ComplexTypeMappings = new FreezableOwnedCollection<MappingModelSchema, MappingModelComplexType>(this, (owner, item) => { item.Owner = owner; });
            this._EntityMappings = new FreezableOwnedCollection<MappingModelSchema, MappingModelEntity>(this, (owner, item) => { item.Owner = owner; });
            this._RelationMappings = new FreezableOwnedCollection<MappingModelSchema, MappingModelRelation>(this, (owner, item) => { item.Owner = owner; });
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

        public MappingModelEntity CreateEntityMapping(string name, ModelEntity source, ModelEntity target, bool enabled, bool generated, string comment) {
            var result = new MappingModelEntity();
            result.Name = name;
            result.Source = source;
            result.Target = target;
            result.Enabled = enabled;
            result.Generated = generated;
            result.Comment = comment;
            this.EntityMappings.Add(result);
            return result;
        }

        public MappingModelEntity CreateEntityMapping(string name, string sourceName, string targetName, bool enabled, bool generated, string comment) {
            var result = new MappingModelEntity();
            result.Name = name;
            result.SourceName = sourceName;
            result.TargetName = targetName;
            result.Enabled = enabled;
            result.Generated = generated;
            result.Comment = comment;
            this.EntityMappings.Add(result);
            return result;
        }

        public MappingModelComplexType CreateComplexTypeMapping(string name, ModelComplexType source, ModelComplexType target, bool enabled, bool generated, string comment) {
            var result = new MappingModelComplexType();
            result.Name = name;
            result.Source = source;
            result.Target = target;
            result.Enabled = enabled;
            result.Generated = generated;
            result.Comment = comment;
            this.ComplexTypeMappings.Add(result);
            return result;
        }
        public MappingModelComplexType CreateComplexTypeMapping(string name, string sourceName, string targetName, bool enabled, bool generated, string comment) {
            var result = new MappingModelComplexType();
            result.Name = name;
            result.SourceName = sourceName;
            result.TargetName = targetName;
            result.Enabled = enabled;
            result.Generated = generated;
            result.Comment = comment;
            this.ComplexTypeMappings.Add(result);
            return result;
        }
    }
}
