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
        private readonly FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity> _EntityMappings;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation> _RelationMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity> EntityMappings => this._EntityMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation> RelationMappings => this._RelationMappings;

        public MappingModelSchema() {
            this._EntityMappings = new FreezeableOwnedCollection<MappingModelSchema, MappingModelEntity>(this, (owner, item) => { item.Owner = owner; });
            this._RelationMappings = new FreezeableOwnedCollection<MappingModelSchema, MappingModelRelation>(this, (owner, item) => { item.Owner = owner; });
        }

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
    }
}
