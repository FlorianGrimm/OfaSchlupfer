namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingModelComplexType
         : MappingObjectString<MappingModelSchema, ModelComplexType> {
        [JsonIgnore]
        private readonly FreezeableOwnedCollection<MappingModelComplexType, MappingModelProperty> _PropertyMappings;

        public MappingModelComplexType() {
            this._PropertyMappings = new FreezeableOwnedCollection<MappingModelComplexType, MappingModelProperty>(this, (owner, item) => { item.Owner = owner; });

        }

        [JsonIgnore]
        public override MappingModelSchema Owner {         
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.ComplexTypeMappings);
        }
                
        public FreezeableOwnedCollection<MappingModelComplexType, MappingModelProperty> PropertyMappings => this._PropertyMappings;
        
        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var lstFound = this.Owner.Source.ComplexTypes.FindByKey(this._SourceName);
                if (lstFound.Count == 1) {
                    this._Source = lstFound[0];
                    this._SourceName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Source {this._SourceName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Source {this._SourceName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                var lstFound = this.Owner.Target.ComplexTypes.FindByKey(this._TargetName);
                if (lstFound.Count == 1) {
                    this._Target = lstFound[0];
                    this._TargetName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Target {this._TargetName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Target {this._TargetName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }
    }
}
