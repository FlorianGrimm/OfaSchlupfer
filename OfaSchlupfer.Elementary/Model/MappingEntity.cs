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
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private ModelEntityName _SourceName;

        [JsonIgnore]
        private ModelEntity _Source;

        [JsonIgnore]
        private ModelEntityName _TargetName;

        [JsonIgnore]
        private ModelEntity _Target;

        [JsonIgnore]
        private string _Name;

        public MappingEntity() {
            this.PropertyMappings = new List<MappingProperty>();
            this.ConstraintMappings = new List<MappingConstraint>();
        }

        [JsonProperty]
        public ModelEntityName SourceName {
            get {
                return this._SourceName;
            }
            set {
                this.ThrowIfFrozen();
                this._SourceName = value;
            }
        }


        [JsonProperty]
        public ModelEntityName TargetName {
            get {
                return this._TargetName;
            }
            set {
                this.ThrowIfFrozen();
                this._TargetName = value;
            }
        }

        [JsonIgnore]
        public ModelEntity Source {
            get {
                return this._Source;
            }
            set {
                this.ThrowIfFrozen();
                this._Source = value;
            }
        }

        [JsonIgnore]
        public ModelEntity Target {
            get {
                return this._Target;
            }
            set {
                this.ThrowIfFrozen();
                this._Target = value;
            }
        }


        public readonly List<MappingProperty> PropertyMappings;
        public readonly List<MappingConstraint> ConstraintMappings;

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public string GetName() => this._Name;

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
