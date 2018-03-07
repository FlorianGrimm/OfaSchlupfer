namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class MappingEntity {
        public string SourceName;
        public string TargetName;
        [NonSerialized]
        public ModelEntity Source;
        [NonSerialized]
        public ModelEntity Target;
        public readonly List<MappingProperty> PropertyMappings;
        public readonly List<MappingConstraint> ConstraintMappings;
        public string Name;

        public MappingEntity() {
            this.PropertyMappings = new List<MappingProperty>();
            this.ConstraintMappings = new List<MappingConstraint>();
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
                if (!string.IsNullOrEmpty(this.SourceName)) {
                    if (sourceCurrent.EntityByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target == null) {
                if (!string.IsNullOrEmpty(this.TargetName)) {
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
