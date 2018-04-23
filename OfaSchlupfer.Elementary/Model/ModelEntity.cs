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
        private ModelComplexType _EntityType;

        [JsonIgnore]
        private string _EntityTypeName;

        [JsonIgnore]
        private ModelEntityKind _Kind;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelEntity, string, ModelConstraint> _Constraints;

        [JsonProperty(Order = 5)]
        public FreezeableOwnedKeyedCollection<ModelEntity, string, ModelConstraint> Constraints => this._Constraints;

        public ModelEntity() {
            this._Constraints = new FreezeableOwnedKeyedCollection<ModelEntity, string, ModelConstraint>(
                this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override ModelSchema Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.Entities);
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
        public string EntityTypeName {
            get {
                return this._EntityTypeName;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityTypeName = value;
                this._EntityType = null;
            }
        }

        [JsonIgnore]
        public ModelComplexType EntityType {
            get {
                if (((object)this._Owner != null) && ((object)this._EntityType == null) && (this._EntityTypeName != null)) {
                    this.ResolveNameEntityType(ModelErrors.GetIgnorance());
                }
                return this._EntityType;
            }
            set {
                this.ThrowIfFrozen();
                this._EntityType = value;
                if (value != null) {
                    this._EntityTypeName = value.Name;
                }
            }
        }

        public void ResolveName(ModelErrors errors) {
            this.ResolveNameEntityType(errors);
        }

        public ModelComplexType ResolveNameEntityType(ModelErrors errors) {
            if ((this.Owner != null) && ((object)this._EntityType == null) && (this._EntityTypeName != null)) {
                var lstComplexType = this.Owner.FindComplexType(this._EntityTypeName);
                if (lstComplexType.Count == 1) {
                    this._EntityType = lstComplexType[0];
                    this._EntityTypeName = null;
                    return lstComplexType[0];
                } else if (lstComplexType.Count == 0) {
                    errors.AddErrorOrThrow($"EntityType {this._EntityTypeName} in {this.Owner?.Name} not found.", this.Owner?.Name, ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"EntityType {this._EntityTypeName} in {this.Owner?.Name} found #{lstComplexType.Count} times.", this.Owner?.Name, ResolveNameNotUniqueException.Factory);
                }
            }
            return this._EntityType;
        }

        public override Type GetClrType() => typeof(OfaSchlupfer.Entity.AccessorFlexible);

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Constraints.Freeze();
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
