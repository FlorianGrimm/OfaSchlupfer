namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelDefinition
        : FreezeableObject {

        [JsonIgnore]
        private string _MetaData;

        [JsonIgnore]
        private string _Kind;

        public ModelDefinition() { }

        public string MetaData {
            get {
                return this._MetaData;
            }
            set {
                this.ThrowIfFrozen();
                this._MetaData = value;
            }
        }

        public string Kind {
            get {
                return this._Kind;
            }
            set {
                this.ThrowIfFrozen();
                this._Kind = value;
            }
        }
    }
}
