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
        : MappingObject<ModelEntityName, ModelEntityName, ModelSchema> {
        [JsonIgnore]
        private MappingRepository _Owner;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingSchema, MappingEntity> _EntityMappings;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingSchema, MappingRelation> _RelationMappings;

        public MappingRepository Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        [JsonProperty]
        public FreezeableOwnedCollection<MappingSchema, MappingEntity> EntityMappings => this._EntityMappings;

        [JsonProperty]
        public FreezeableOwnedCollection<MappingSchema, MappingRelation> RelationMappings => this._RelationMappings;

        public MappingSchema() {
            this._EntityMappings = new FreezeableOwnedCollection<MappingSchema, MappingEntity>(this, (owner, item) => { item.Owner = owner; });
            this._RelationMappings = new FreezeableOwnedCollection<MappingSchema, MappingRelation>(this, (owner, item) => { item.Owner = owner; });
        }

        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(ModelEntityName thisName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

        public virtual void ResolveNames(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
#warning TODO ResolveNameSource
            //if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
            //}
        }

        public override void ResolveNameTarget(ModelErrors errors) {
#warning TODO ResolveNameTarget
            //if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
            //this._Owner.Owner.FindRepository
            //}
        }
    }
}
