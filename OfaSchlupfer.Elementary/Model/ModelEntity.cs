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
        private readonly FreezableOwnedKeyedCollection<ModelEntity, string, ModelConstraint> _Constraints;

        [JsonProperty(Order = 5)]
        public FreezableOwnedKeyedCollection<ModelEntity, string, ModelConstraint> Constraints => this._Constraints;

        public ModelEntity() {
            this._Constraints = new FreezableOwnedKeyedCollection<ModelEntity, string, ModelConstraint>(
                this,
                (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override ModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Entities);
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModelEntityKind Kind {
            get => this._Kind;
            set => this.SetValueProperty(ref this._Kind, value);
        }

        [JsonProperty(Order = 3)]
        public string EntityTypeName {
            get => this.GetPairNameProperty(ref this._EntityTypeName, ref this._EntityType, (item) => item.Name);
            set => this.SetPairNameProperty(ref this._EntityTypeName, ref this._EntityType, value, (that, n) => that.ResolveNameEntityType(ModelErrors.GetIgnorance()));
        }

        [JsonIgnore]
        public ModelComplexType EntityType {
            get =>this.GetPairRefProperty(ref this._EntityTypeName, ref this._EntityType, (that, n) => that.ResolveNameEntityType(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._EntityTypeName, ref this._EntityType, value, (item) => item.Name); 
        }

        public override void ResolveNamedReferences(ModelErrors errors) {
            //base.ResolveNamedReferences(errors);
            this.ResolveNameEntityType(errors);
        }

        public ModelComplexType ResolveNameEntityType(ModelErrors errors)
            => this.ResolveNameHelper(this._Owner, this.Name, ref this._EntityTypeName, ref this._EntityType, (o, n) => o.FindComplexType(n), errors);

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
