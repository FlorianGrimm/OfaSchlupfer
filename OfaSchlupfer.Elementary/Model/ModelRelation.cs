namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class ModelRelation
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private ModelSchema _Owner;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private ModelEntityName _MasterName;

        [JsonIgnore]
        private ModelEntity _MasterEntity;

        [JsonIgnore]
        private ModelEntityName _ForeignName;

        [JsonIgnore]
        private ModelEntity _ForeignEntity;

        public ModelRelation() { }

        [JsonProperty(Order = 1)]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public string GetName() => this._Name;


        [JsonProperty(Order = 2)]
        public ModelEntityName MasterName {
            get {
                if ((object)this._MasterEntity != null) {
                    return this._MasterEntity.Name;
                } else {
                    return this._MasterName;
                }
            }
            set {
                this.ThrowIfFrozen();
                this._MasterName = value;
            }
        }

        [JsonIgnore]
        public ModelEntity MasterEntity {
            get {
                if (((object)this._MasterEntity == null)
                    && ((object)this._MasterName != null)) {
                    this.ResolveNamesMasterEntity(ModelErrors.GetIgnorance());
                }
                return this._MasterEntity;
            }
            set {
                this.ThrowIfFrozen();
                this._MasterEntity = value;
                this._MasterName = null;
            }
        }


        [JsonProperty(Order = 3)]
        public ModelEntityName ForeignName {
            get {
                if ((object)this._ForeignEntity != null) {
                    return this._ForeignEntity.Name;
                } else {
                    return this._ForeignName;
                }
            }
            set {
                this.ThrowIfFrozen();
                this._ForeignName = value;
            }
        }

        [JsonIgnore]
        public ModelEntity ForeignEntity {
            get {
                if (((object)this._ForeignEntity == null)
                   && ((object)this._ForeignName != null)) {
                    this.ResolveNamesForeignEntity(ModelErrors.GetIgnorance());
                }
                return this._ForeignEntity;
            }
            set {
                this.ThrowIfFrozen();
                this._ForeignEntity = value;
                this._ForeignName = null;
            }
        }

        [JsonIgnore]
        public ModelSchema Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }
        private void ResolveNames(ModelErrors errors) {
            this.ResolveNamesMasterEntity(errors);
            this.ResolveNamesForeignEntity(errors);
        }

        private void ResolveNamesMasterEntity(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._MasterEntity == null) && ((object)this._MasterName != null)) {
                this._MasterEntity
                var lst = this.Owner.FindEntity(this.MasterName);
                if (lst.Count == !) {
                    this._MasterEntity = lst[0];
                    this._MasterName = null;
                } else if (lst.Count == 0) {
                    errors.AddErrorOrThrow($"Master {this.MasterName} in {this.Owner?.Name.FullName} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Master {this.MasterName} in {this.Owner?.Name.FullName found #{lstNavProperty.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);

                }
            }
        }


        private void ResolveNamesForeignEntity(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._ForeignEntity == null) && ((object)this._ForeignName != null)) {
                this._MasterEntity
                               var lst = this.Owner.FindEntity(this.ForeignName);
                if (lst.Count == !) {
                    this._MasterEntity = lst[0];
                    this._MasterName = null;
                } else if (lst.Count == 0) {
                    errors.AddErrorOrThrow($"Foreign {this.ForeignName.Name} in {this.Owner?.Name.FullName} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Foreign {this.ForeignName.Name} in {this.Owner?.Name.FullName found #{lstNavProperty.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);

                }
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.MasterName?.Freeze();
                this.MasterEntity?.Freeze();
                this.ForeignName?.Freeze();
                this.ForeignEntity?.Freeze();
            }
            return result;
        }
    }
}
