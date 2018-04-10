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
                return this._MasterName;
            }
            set {
                this.ThrowIfFrozen();
                this._MasterName = value;
            }
        }

        [JsonIgnore]
        public ModelEntity MasterEntity {
            get {
                return this._MasterEntity;
            }
            set {
                this.ThrowIfFrozen();
                this._MasterEntity = value;
                if (value == null) {
                    this.MasterName = null;
                } else {
                    this.MasterName = value.Name;
                }
            }
        }

        [JsonProperty(Order = 3)]
        public ModelEntityName ForeignName {
            get {
                return this._ForeignName;
            }
            set {
                this.ThrowIfFrozen();
                this._ForeignName = value;
            }
        }

        [JsonIgnore]
        public ModelEntity ForeignEntity {
            get {
                return this._ForeignEntity;
            }
            set {
                this.ThrowIfFrozen();
                this._ForeignEntity = value;
                if (value == null) {
                    this.ForeignName = null;
                } else {
                    this.ForeignName = value.Name;
                }
            }
        }
    }
}
