namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    [JsonObject]
    public class ModelConstraint
        : ModelNamedElement
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private string _Type;

        [JsonIgnore]
        private ModelEntity _Owner;

        [JsonIgnore]

        private readonly FreezeableCollection<ModelProperty> _Properties;

        public ModelConstraint() {
            this._Properties = new FreezeableCollection<ModelProperty>();
        }

        [JsonProperty]
        public string Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }

        [JsonProperty]
        public FreezeableCollection<ModelProperty> Properties => this._Properties;


        [JsonIgnore]
        public ModelEntity Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref _Owner, value);
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Properties.Freeze();
            }
            return result;
        }
    }
}
