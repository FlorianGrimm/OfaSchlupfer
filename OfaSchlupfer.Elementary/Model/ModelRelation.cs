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
        : ModelNamedOwnedElement<ModelSchema> {
        [JsonIgnore]
        private string _MasterName;

        [JsonIgnore]
        private ModelEntity _MasterEntity;

        [JsonIgnore]
        private string _ForeignName;

        [JsonIgnore]
        private ModelEntity _ForeignEntity;

        public ModelRelation() { }

        [JsonIgnore]
        public override ModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Relations);
        }

        [JsonProperty(Order = 2)]
        public string MasterName {
            get => this.GetPairNameProperty(ref this._MasterName, ref this._MasterEntity, (item)=>item.Name); 
            set => this.SetPairNameProperty(ref this._MasterName, ref this._MasterEntity, value, (that, n)=> that.ResolveNamesMasterEntity(ModelErrors.GetIgnorance()));
        }

        [JsonIgnore]
        public ModelEntity MasterEntity {
            get => this.GetPairRefProperty(ref this._MasterName, ref this._MasterEntity, (that, n) => that.ResolveNamesMasterEntity(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._MasterName, ref this._MasterEntity, value, (item) => item.Name);
        }

        [JsonProperty(Order = 3)]
        public string MasterNavigationPropertyName { get; set; }

        [JsonIgnore]
        public ModelNavigationProperty MasterNavigationProperty { get; set; }

        [JsonProperty(Order = 4)]
        public string ForeignName {
            get => this.GetPairNameProperty(ref this._ForeignName, ref this._ForeignEntity, (item) => item.Name);
            set => this.SetPairNameProperty(ref this._ForeignName, ref this._ForeignEntity, value, (that, n) => that.ResolveNamesForeignEntity(ModelErrors.GetIgnorance()));
        }

        [JsonIgnore]
        public ModelEntity ForeignEntity {
            get => this.GetPairRefProperty(ref this._ForeignName, ref this._ForeignEntity, (that, n) => that.ResolveNamesForeignEntity(ModelErrors.GetIgnorance()));
            set => this.SetPairRefProperty(ref this._ForeignName, ref this._ForeignEntity, value, (item) => item.Name);
        }

        [JsonProperty(Order = 5)]
        public string ForeignNavigationPropertyName { get; set; }

        [JsonIgnore]
        public ModelNavigationProperty ForeignNavigationProperty { get; set; }

        private ModelEntity ResolveNamesForeignEntity(ModelErrors errors) => this.ResolveNameHelper(this._Owner, this.Name, ref this._ForeignName, ref this._ForeignEntity, (o, n) => o.FindEntity(n), errors);
        private ModelEntity ResolveNamesMasterEntity(ModelErrors errors) => this.ResolveNameHelper(this._Owner, this.Name, ref this._MasterName, ref this._MasterEntity, (o, n) => o.FindEntity(n), errors);

        public override void ResolveNamedReferences(ModelErrors errors) {
            //base.ResolveNamedReferences(errors);
            this.ResolveNamesMasterEntity(errors);
            this.ResolveNamesForeignEntity(errors);
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.MasterEntity?.Freeze();
                this.ForeignEntity?.Freeze();
            }
            return result;
        }
    }
}
