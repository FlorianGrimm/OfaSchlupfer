﻿namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Maps 2 repositories
    /// </summary>
    [JsonObject]
    public sealed class MappingModelRepository
        : MappingObjectString<ModelRoot, ModelRepository> {
        [JsonIgnore]
        private readonly FreezableOwnedCollection<MappingModelRepository, MappingModelSchema> _ModelSchemaMappings;

        public MappingModelRepository() {
            this._ModelSchemaMappings = new FreezableOwnedCollection<MappingModelRepository, MappingModelSchema>(this, (owner, item) => { item.Owner = owner; });
        }
              
        [JsonIgnore]
        public override ModelRoot Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.RepositoryMappings);
        }

        [JsonProperty]
        public FreezableOwnedCollection<MappingModelRepository, MappingModelSchema> ModelSchemaMappings => this._ModelSchemaMappings;


        public void ResolveName(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Repositories.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Repositories.FindByKey(name), errors);

        public MappingModelSchema CreateMappingModelSchema(string name, ModelSchema modelSchemaSource, ModelSchema modelSchemaTarget, bool enabled, bool generated, string comment) {
            var result = new MappingModelSchema {
                Name = name ?? $"{modelSchemaSource.Name} - {modelSchemaTarget.Name}",
                Source = modelSchemaSource,
                Target = modelSchemaTarget,
                Enabled = enabled,
                Generated = generated,
                Comment = comment
            };
            this.ModelSchemaMappings.Add(result);
            return result;
        }
        
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ModelSchemaMappings.Freeze();
            }
            return result;
        }
    }
}
