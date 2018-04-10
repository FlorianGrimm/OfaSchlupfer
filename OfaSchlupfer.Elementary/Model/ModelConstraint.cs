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
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private string _Type;


        [JsonIgnore]
        private ModelEntity _Owner;

        [JsonIgnore]

        private readonly FreezeableCollection<ModelProperty> _Properties;

        public IList<ModelProperty> Properties => this._Properties;

        public ModelConstraint() {
            this._Properties = new FreezeableCollection<ModelProperty>();
        }

        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public string Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }


        [JsonIgnore]
        public ModelEntity Owner {
            get {
                return this._Owner;
            }
            set {
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }


        public string GetName() => this._Name;

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Properties.Freeze();
            }
            return result;
        }
    }
}
