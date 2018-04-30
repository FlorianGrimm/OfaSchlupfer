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
            this._Ascending = true;
        }

        public override ModelComplexType Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Keys);
        }

        [JsonProperty(Order = 1, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public override string Name {
            get => this.GetPairNameProperty(ref this._Name, ref this._Property, (item) => item.Name);
            set => this.SetPairNameProperty(ref this._Name, ref this._Property, value, (that, n) => that.ResolveNameProperty(ModelErrors.GetIgnorance()));
            //get    {
            //    if (this._Property is null) {
            //        return this._Name;
            //    } else {
            //        return this._Property.Name;
            //    }
            //}
            //set {
            //    this.SetStringProperty(ref this._Name, value);
            //}
        }

        [JsonIgnore]
        public ModelProperty Property {
            get => this.GetPairRefProperty(ref this._Name, ref this._Property, (that, n) => that.ResolveNameProperty(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._Name, ref this._Property, value, (item) => item.Name);
            //get {
            //    if (this._Property is null) {
            //        if (!(this._Owner is null)) {
            //            var property = this._Owner.Properties.FindByKey(this._Name).SingleOrDefault();
            //            if (!(property is null)) {
            //                this._Property = property;
            //            }
            //        }
            //    }
            //    return this._Property;
            //}

            //set => this.SetRefProperty(ref this._Property, value);
        }

        [JsonIgnore]
        private bool _Ascending;

        [JsonProperty]
        public bool Ascending { get => this._Ascending; set => this.SetValueProperty(ref this._Ascending, value); }
        
        private ModelProperty ResolveNameProperty(ModelErrors errors)
            => this.ResolveNameHelper(this._Owner, this.Name, ref this._Name, ref this._Property, (o, n) => o.Properties.FindByKey(n), errors);

        public override void ResolveNamedReferences(ModelErrors errors) {
            //base.ResolveNamedReferences(errors);
            this.ResolveNameProperty(errors);
        }
    }
}
