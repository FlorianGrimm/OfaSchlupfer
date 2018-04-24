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
            set => this.SetOwner(ref _Owner, value, (owner) => owner.NavigationProperty);
        }

        [JsonProperty(Order = 3)]
        public string ItemTypeName { get => this._ItemTypeName; set => this.SetStringProperty(ref _ItemTypeName, value); }

        [JsonIgnore]
        public ModelComplexType ItemType {
            get {
                if (this._ItemType is null) {
                    this.ResolveNameHelper(this.Owner, this.Name, ref this._ItemTypeName, ref this._ItemType, (o, n) => o.Owner.ComplexTypes.FindByKey(n), ModelErrors.GetIgnorance());
                }
                return this._ItemType;
            }
            set {
                if (this.SetRefProperty(ref this._ItemType, value)) {
                    this._ItemTypeName = null;
                }
            }
        }

        [JsonProperty(Order = 4)]
        public bool IsOptional { get => this._IsOptional; set => this.SetValueProperty(ref this._IsOptional, value); }

        [JsonProperty(Order = 5)]
        public bool IsCollection { get => this._IsCollection; set => this.SetValueProperty(ref this._IsCollection, value); }
    }
}