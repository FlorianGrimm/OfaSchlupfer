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
    public class MappingModelRepository
        : MappingObjectString<ModelRoot, ModelRepository> {
        //[JsonIgnore]
        //private MappingSchema _Mapping;

        //[JsonProperty]
        //public MappingSchema Mapping {
        //    get {
        //        return this._Mapping;
        //    }
        //    set {
        //        this.ThrowIfFrozen();
        //        this._Mapping = value;
        //        if ((object)value != null) {
        //            value.Owner = this;
        //        }
        //    }
        //}

        public MappingModelRepository() {        }

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
    }
}
