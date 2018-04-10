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
        : MappingObject<string, ModelEntityName, ModelEntity>
        , IMappingNamedObject<string> {
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

        public IList<MappingProperty> PropertyMappings => this._PropertyMappings;

        public IList<MappingConstraint> ConstraintMappings => this._ConstraintMappings;


        [JsonIgnore]
        public MappingSchema Owner {
            get {
                return this._Owner;
            }
            set {
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(string thisName, ref string value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

        public override void ResolveNameSource() {
            if (((object)this._Source == null) && ((object)this._SourceName != null)) {
#warning TODO ResolveNameSource
            }
        }

        public override void ResolveNameTarget() {
            if (((object)this._Target == null) && ((object)this._TargetName != null)) {
#warning TODO ResolveNameTarget
            }
        }

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            if (this.Source != null) {
                var name = this.Source.Name;
                this.SourceName = name;
                sourceCurrent.EntityByName[name] = this.Source;
            }
            if (this.Target != null) {
                var name = this.Target.Name;
                this.TargetName = name;
                targetCurrent.EntityByName[name] = this.Target;
            }
            foreach (var propertyMapping in this.PropertyMappings) { propertyMapping.UpdateNames(current, sourceCurrent, targetCurrent); }
            foreach (var constraintMapping in this.ConstraintMappings) { constraintMapping.UpdateNames(current, sourceCurrent, targetCurrent); }
        }


        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            if (this.Source == null) {
                if (this.SourceName != null) {
                    if (sourceCurrent.EntityByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target == null) {
                if (this.TargetName != null) {
                    if (targetCurrent.EntityByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
            foreach (var propertyMapping in this.PropertyMappings) { propertyMapping.ResolveNames(current, sourceCurrent, targetCurrent); }
            foreach (var constraintMapping in this.ConstraintMappings) { constraintMapping.ResolveNames(current, sourceCurrent, targetCurrent); }
        }
    }
}
