namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelNavigationProperty
        : ModelNamedOwnedElement<ModelComplexType> {
        [JsonIgnore]
        private string _ItemTypeName;
        [JsonIgnore]
        private ModelComplexType _ItemType;
        [JsonIgnore]
        private bool _IsOptional;
        [JsonIgnore]
        private bool _IsCollection;

        public ModelNavigationProperty() {
        }

        [JsonIgnore]
        public override ModelComplexType Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.NavigationProperty);
        }

        [JsonProperty(Order = 3)]
        public string ItemTypeName {
            get => this.GetPairNameProperty(ref this._ItemTypeName, ref this._ItemType, (item)=>item.Name);
            set => this.SetPairNameProperty(ref this._ItemTypeName, ref this._ItemType, value, (that, n) => that.ResolveNamedItemType(ModelErrors.GetIgnorance()));
        }

        [JsonIgnore]
        public ModelComplexType ItemType {
            get => this.GetPairRefProperty(ref this._ItemTypeName, ref this._ItemType, (that, n) => that.ResolveNamedItemType(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._ItemTypeName, ref this._ItemType, value, (item) => item.Name);
        }

        public override void ResolveNamedReferences(ModelErrors errors) {
            //base.ResolveNamedReferences(errors);
            this.ResolveNamedItemType(errors);
        }

        public ModelComplexType ResolveNamedItemType(ModelErrors errors)
            => this.ResolveNameHelper(this.Owner, this.Name, ref this._ItemTypeName, ref this._ItemType, (o, n) => o.Owner.ComplexTypes.FindByKey(n), ModelErrors.GetIgnorance());

        [JsonProperty(Order = 4)]
        public bool IsOptional { get => this._IsOptional; set => this.SetValueProperty(ref this._IsOptional, value); }

        [JsonProperty(Order = 5)]
        public bool IsCollection { get => this._IsCollection; set => this.SetValueProperty(ref this._IsCollection, value); }
    }
}