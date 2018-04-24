namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingModelRelation
        : MappingObjectString<MappingModelSchema, ModelRelation> {
        public MappingModelRelation() {
        }

        [JsonIgnore]
        public override MappingModelSchema Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.RelationMappings);
        }

        public void ResolveName(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Relations.FindByKey(name), errors);
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Target.Relations.FindByKey(name), errors);
        }
    }
}
