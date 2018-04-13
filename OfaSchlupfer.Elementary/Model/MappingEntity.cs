namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingEntity
        : MappingObject<string, ModelEntityName, ModelEntity> {
        [JsonIgnore]
        private MappingSchema _Owner;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingEntity, MappingProperty> _PropertyMappings;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingEntity, MappingConstraint> _ConstraintMappings;

        public MappingEntity() {
            this._PropertyMappings = new FreezeableOwnedCollection<MappingEntity, MappingProperty>(this, (owner, item) => { item.Owner = owner; });
            this._ConstraintMappings = new FreezeableOwnedCollection<MappingEntity, MappingConstraint>(this, (owner, item) => { item.Owner = owner; });
        }

        public FreezeableOwnedCollection<MappingEntity, MappingProperty> PropertyMappings => this._PropertyMappings;

        public FreezeableOwnedCollection<MappingEntity, MappingConstraint> ConstraintMappings => this._ConstraintMappings;


        [JsonIgnore]
        public MappingSchema Owner {
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

        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(string thisName, ref string value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

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
