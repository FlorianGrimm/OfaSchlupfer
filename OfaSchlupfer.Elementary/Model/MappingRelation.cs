namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingRelation {
        public string SourceName;
        public string TargetName;
        [JsonIgnore]
        public ModelRelation Source;
        [JsonIgnore]
        public ModelRelation Target;

        public string Name;
        public bool Enabled;

        public MappingRelation() {

        }

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            if (this.Source == null) {
                if (!string.IsNullOrEmpty(this.SourceName)) {
                    if (sourceCurrent.RelationByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target != null) {
                if (!string.IsNullOrEmpty(this.TargetName)) {
                    if (targetCurrent.RelationByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
        }
    }
}
