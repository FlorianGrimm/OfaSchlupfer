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
        private readonly FreezeableOwnedCollection<MappingModelEntity, MappingModelConstraint> _ConstraintMappings;

        public MappingModelEntity() {
            this._ConstraintMappings = new FreezeableOwnedCollection<MappingModelEntity, MappingModelConstraint>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override MappingModelSchema Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.EntityMappings);
        }

        public FreezeableOwnedCollection<MappingModelEntity, MappingModelConstraint> ConstraintMappings => this._ConstraintMappings;

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var lstFound = this._Owner.Source.FindEntity(this._SourceName);
                if (lstFound.Count == 1) {
                    this._Source = lstFound[0];
                    this._SourceName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"{this._SourceName} not found", this.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"{this._SourceName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                }
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                var lstFound = this._Owner.Target.FindEntity(this._TargetName);
                if (lstFound.Count == 1) {
                    this._Target = lstFound[0];
                    this._TargetName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"{this._TargetName} not found", this.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"{this._TargetName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                }
            }
        }
    }
}
