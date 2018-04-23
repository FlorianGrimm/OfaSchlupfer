namespace OfaSchlupfer.Model {
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
        private readonly FreezeableOwnedCollection<MappingModelRepository, MappingModelSchema> _ModelSchemaMappings;

        public MappingModelRepository() {
            this._ModelSchemaMappings = new FreezeableOwnedCollection<MappingModelRepository, MappingModelSchema>(this, (owner, item) => { item.Owner = owner; });
        }
              
        [JsonIgnore]
        public override ModelRoot Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.RepositoryMappings);
        }

        [JsonProperty]
        public FreezeableOwnedCollection<MappingModelRepository, MappingModelSchema> ModelSchemaMappings => _ModelSchemaMappings;


        public void ResolveName(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this.Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var lstFound = this.Owner.Repositories.FindByKey(this.SourceName);
                if (lstFound.Count == 1) {
                    this._Source = lstFound[0];
                    this._SourceName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Repository {this.SourceName} in {this.Owner?.Name} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Repository {this.SourceName} in {this.Owner?.Name} found #{lstFound.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);
                }
            }
        }

        public MappingModelSchema CreateMappingModelSchema(string name, ModelSchema modelSchemaSource, ModelSchema modelSchemaTarget) {
            var result = new MappingModelSchema();
            result.Name = name;
            result.Source = modelSchemaSource;
            result.Target = modelSchemaTarget;
            this.ModelSchemaMappings.Add(result);
            return result;
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Target == null) && ((object)this._TargetName != null)) {
                if (((object)this.Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                    var lstFound = this.Owner.Repositories.FindByKey(this.TargetName);
                    if (lstFound.Count == 1) {
                        this._Target = lstFound[0];
                        this._TargetName = null;
                    } else if (lstFound.Count == 0) {
                        errors.AddErrorOrThrow($"Repository {this.TargetName} in {this.Owner?.Name} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Repository {this.TargetName} in {this.Owner?.Name} found #{lstFound.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
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
