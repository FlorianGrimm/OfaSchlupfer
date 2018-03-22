namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class ModelRelation {
        private ModelEntity _MasterEntity;
        private ModelEntity _ForeignEntity;

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public ModelEntityName MasterName { get; set; }

        [JsonIgnore]
        public ModelEntity MasterEntity {
            get {
                return this._MasterEntity;
            }
            set {
                this._MasterEntity = value;
                if (value == null) {
                    this.MasterName = null;
                } else {
                    this.MasterName = value.Name;
                }
            }
        }

        [JsonProperty(Order = 3)]
        public ModelEntityName ForeignName { get; set; }

        [JsonIgnore]
        public ModelEntity ForeignEntity {
            get {
                return this._ForeignEntity;
            }
            set {
                this._ForeignEntity = value;
                if (value == null) {
                    this.ForeignName = null;
                } else {
                    this.ForeignName = value.Name;
                }
            }
        }

        public ModelRelation() {

        }
    }
}
