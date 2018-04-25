namespace OfaSchlupfer.Model {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class ModelPrimaryKey
        : ModelNamedOwnedElement<ModelComplexType> {
        [JsonIgnore]
        private ModelProperty _Property;

        public ModelPrimaryKey() {
        }

        public override ModelComplexType Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Keys);
        }

        [JsonProperty(Order = 1, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public override string Name {
            get {
                if (this._Property is null) {
                    return this._Name;
                } else {
                    return this._Property.Name;
                }
            }
            set {
                this.SetStringProperty(ref this._Name, value);
            }
        }

        [JsonIgnore]
        public ModelProperty Property {
            get {
                if (this._Property is null) {
                    if (!(this._Owner is null)) {
                        var property = this._Owner.Properties.FindByKey(this._Name).SingleOrDefault();
                        if (!(property is null)) {
                            this._Property = property;
                        }
                    }
                }
                return this._Property;
            }

            set => this.SetRefProperty(ref this._Property, value);
        }
    }
}
