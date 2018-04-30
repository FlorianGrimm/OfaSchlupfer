namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingModelIndex
        : MappingObjectString<MappingModelComplexType, ModelIndex> {
        //[JsonIgnore]
        //private readonly FreezableOwnedCollection<MappingModelIndex, MappingModelIndexColumn> _IndexColumnMappings;

        public MappingModelIndex() {
            //this._IndexColumnMappings = new FreezableOwnedCollection<MappingModelIndex, MappingModelIndexColumn>(this, (owner, item) => { item.Owner = owner; });
        }

        //[JsonProperty]
        //public FreezableOwnedCollection<MappingModelIndex, MappingModelIndexColumn> IndexColumnMappings => this._IndexColumnMappings;

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Indexes.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.Indexes.FindByKey(name), errors);

        //public MappingModelIndexColumn CreateIndexColumnMapping(
        //    string name,
        //    ModelIndexProperty source,
        //    ModelIndexProperty target) {
        //    var result = new MappingModelIndexColumn {
        //        Name = name,
        //        Source = source,
        //        Target = target
        //    };
        //    this.IndexColumnMappings.Add(result);
        //    return result;
        //}
    }
}