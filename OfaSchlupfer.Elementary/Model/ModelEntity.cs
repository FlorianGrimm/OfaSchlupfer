namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using OfaSchlupfer.Freezable;

    [JsonObject()]
    public class ModelEntity
        : ModelType {
        [JsonIgnore]
        private ModelSchema _Owner;

        [JsonIgnore]
        private ModelComplexType _EntityType;

        [JsonIgnore]
        private ModelEntityName _EntityTypeNáme;

        [JsonIgnore]
        private ModelEntityKind _Kind;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelEntity, ModelConstraint> _Constraints;

        [JsonProperty(Order = 5)]
        public FreezeableOwnedCollection<ModelEntity, ModelConstraint> Constraints => this._Constraints;

        public ModelEntity() {
            this._Constraints = new FreezeableOwnedCollection<ModelEntity, ModelConstraint>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelEntityKind Kind {
            get {
                return this._Kind;
            }
            set {
                this.ThrowIfFrozen();
                this._Kind = value;
            }
        }

        [JsonProperty(Order = 3)]
        public ModelEntityName EntityTypeNáme {
            get {
                return this._EntityTypeNáme;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityTypeNáme = value;
                this._EntityType = null;
            }
        }

        [JsonIgnore]
        public ModelComplexType EntityType {
            get {
                if (((object)this._Owner != null) && ((object)this._EntityType == null) && (this._EntityTypeNáme != null)) {
                    this.ResolveNameEntityType(ModelErrors.GetIgnorance());
                }
                return this._EntityType;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityType = value;
                if (value != null) {
                    this._EntityTypeNáme = value.Name;
                }
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

        public void ResolveName(ModelErrors errors) {
            this.ResolveNameEntityType(errors);
        }

        public ModelComplexType ResolveNameEntityType(ModelErrors errors) {
            if ((this.Owner != null) && ((object)this._EntityType == null) && (this._EntityTypeNáme != null)) {
                var lstComplexType = this.Owner.FindComplexType(this._EntityTypeNáme);
                if (lstComplexType.Count == 1) {
                    this._EntityType = lstComplexType[0];
                    this._EntityTypeNáme = null;
                    return lstComplexType[0];
                } else if (lstComplexType.Count == 0) {
                    errors.AddErrorOrThrow($"EntityType {this._EntityTypeNáme} in {this.Owner?.Name} not found.", this.Owner?.Name?.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"EntityType {this._EntityTypeNáme} in {this.Owner?.Name} found #{lstComplexType.Count} times.", this.Owner?.Name?.Name, ResolveNameNotUniqueException.Factory);
                }
            }
            return this._EntityType;
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Constraints.Freeze();
                this.EntityTypeNáme?.Freeze();
                this.EntityType?.Freeze();
            }
            return result;
        }
    }

    public enum ModelEntityKind {
        NotSet,
        Container,
        EntitySet
    }
}
