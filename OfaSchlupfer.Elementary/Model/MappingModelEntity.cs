namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingModelEntity
        : MappingObjectString<MappingModelSchema, ModelEntity> {
        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelEntity, MappingModelConstraint> _ConstraintMappings;

        public MappingModelEntity() {
            this._ConstraintMappings = new FreezableOwnedCollection<MappingModelEntity, MappingModelConstraint>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override MappingModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.EntityMappings);
        }

        public FreezableOwnedCollection<MappingModelEntity, MappingModelConstraint> ConstraintMappings => this._ConstraintMappings;

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Entities.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.Entities.FindByKey(name), errors);
    }
}
