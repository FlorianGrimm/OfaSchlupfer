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
    public class ModelIndexProperty
        : ModelNamedOwnedElement<ModelIndex> {
        
        [JsonIgnore]
        private ModelProperty _Property;

        public ModelIndexProperty() {
            this._Ascending = true;
        }

        public override ModelIndex Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Properties);
        }

        [JsonProperty(Order = 1, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public override string Name {
            get => this.GetPairNameProperty(ref this._Name, ref this._Property, GetName);
            set => this.SetPairNameProperty(ref this._Name, ref this._Property, value, (that, n) => that.ResolveNameProperty(ModelErrors.GetIgnorance()));
        }

        [JsonIgnore]
        public ModelProperty Property {
            get => this.GetPairRefProperty(ref this._Name, ref this._Property, (that, n) => that.ResolveNameProperty(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._Name, ref this._Property, value, GetName);
        }

        [JsonIgnore]
        private bool _Ascending;

        [JsonProperty]
        public bool Ascending { get => this._Ascending; set => this.SetValueProperty(ref this._Ascending, value); }
        
        private ModelProperty ResolveNameProperty(ModelErrors errors)
            => this.ResolveNameHelper(this._Owner?.Owner, this.Name, ref this._Name, ref this._Property, (o, n) => o.Properties.FindByKey(n), errors);

        public override void ResolveNamedReferences(ModelErrors errors) {
            //base.ResolveNamedReferences(errors);
            this.ResolveNameProperty(errors);
        }
    }
}
