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

        public void ResolveName(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var ownerSource = this.Owner.Source;
                if (ownerSource != null) {
                    var lst = ownerSource.Relations.FindByKey(this._SourceName);
                    if (lst.Count == 1) {
                        this._Source = lst[0];
                        this._SourceName = null;
                    } else if (lst.Count == 0) {
                        errors.AddErrorOrThrow($"Source {this._SourceName} in {this.Owner?.Name} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Source {this._SourceName} in {this.Owner?.Name} found #{lst.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                var ownerTarget = this.Owner.Target;
                if (ownerTarget != null) {
                    var lst = ownerTarget.Relations.FindByKey(this._SourceName);
                    if (lst.Count == 1) {
                        this._Source = lst[0];
                        this._SourceName = null;
                    } else if (lst.Count == 0) {
                        errors.AddErrorOrThrow($"Target {this._TargetName} in {this.Owner?.Name} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"Target {this._TargetName} in {this.Owner?.Name} found #{lst.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
    }
}
