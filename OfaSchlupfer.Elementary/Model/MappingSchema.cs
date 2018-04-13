namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingSchema
        : MappingObject<string, ModelEntityName, ModelSchema> {
        private readonly FreezeableOwnedCollection<MappingSchema, MappingEntity> _EntityMappings;
        private readonly FreezeableOwnedCollection<MappingSchema, MappingRelation> _RelationMappings;

        [JsonProperty]
        public IList<MappingEntity> EntityMappings => this._EntityMappings;

        [JsonProperty]
        public IList<MappingRelation> RelationMappings => this._RelationMappings;

        public MappingSchema() {
            this._EntityMappings = new FreezeableOwnedCollection<MappingSchema, MappingEntity>(this, (owner, item) => { item.Owner = owner; });
            this._RelationMappings = new FreezeableOwnedCollection<MappingSchema, MappingRelation>(this, (owner, item) => { item.Owner = owner; });
        }

        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(string thisName, ref string value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

        public virtual void ResolveNames(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
#warning TODO ResolveNameSource
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
#warning TODO ResolveNameTarget
            }
        }

        internal void UpdateNames(ModelRoot.Current current) {
            var sourceCurrent = new ModelSchema.Current(this.Source, false);
            var targetCurrent = new ModelSchema.Current(this.Target, false);
            foreach (var entityMapping in this.EntityMappings) { entityMapping.UpdateNames(current, sourceCurrent, targetCurrent); }
            foreach (var relationMapping in this.RelationMappings) { relationMapping.UpdateNames(current, sourceCurrent, targetCurrent); }
        }

        internal void ResolveNames(ModelRoot.Current current) {
            if (this.Source == null) {
                if (this.SourceName != null) {
                    if (current.SchemaByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target == null) {
                if (this.TargetName != null) {
                    if (current.SchemaByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
            var sourceCurrent = new ModelSchema.Current(this.Source, true);
            var targetCurrent = new ModelSchema.Current(this.Target, true);
            foreach (var entityMapping in this.EntityMappings) { entityMapping.ResolveNames(current, sourceCurrent, targetCurrent); }
            foreach (var relationMapping in this.RelationMappings) { relationMapping.ResolveNames(current, sourceCurrent, targetCurrent); }
        }
    }
}
