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
        : FreezeableObject {

        public ModelEntityName SourceName;
        public ModelEntityName TargetName;
        [JsonIgnore]
        public ModelSchema Source;
        [JsonIgnore]
        public ModelSchema Target;
        public readonly List<MappingEntity> EntityMappings;
        public readonly List<MappingRelation> RelationMappings;

        public string Name;

        public MappingSchema() {
            this.EntityMappings = new List<MappingEntity>();
            this.RelationMappings = new List<MappingRelation>();
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
