namespace OfaSchlupfer.Model {
    using System;
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelScalarType
        : ModelType
        , IModelScalarTypeFacade {
        [JsonIgnore]
        private bool _Collection;

        [JsonIgnore]
        private Type _Type;

        [JsonIgnore]
        private bool _Nullable;

        [JsonIgnore]
        private short _MaxLength;

        [JsonIgnore]
        private bool _FixedLength;

        [JsonIgnore]
        private byte _Precision;

        [JsonIgnore]
        private byte _Scale;

        [JsonIgnore]
        private bool _Unicode;

        public ModelScalarType() {
            this._Nullable = true;
            this._Unicode = true;
        }

        [JsonProperty(Order = 2)]
        [JsonConverter(typeof(OfaSchlupfer.Entity.TypeJsonConverter))]
        public Type Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }

#warning thinkof IModelScalarTypeFacade ItemType
        [JsonIgnore]
        public IModelScalarTypeFacade ItemType {
            get { return null; }
            set { }
        }

        [JsonProperty(Order = 3, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Collection {
            get {
                return this._Collection;
            }
            set {
                this.ThrowIfFrozen();
                this._Collection = value;
            }
        }

        [JsonProperty(Order = 4)]
        public bool Nullable {
            get {
                return this._Nullable;
            }
            set {
                this.ThrowIfFrozen();
                this._Nullable = value;
            }
        }
        public bool ShouldSerializeNullable() => !this.Nullable;

        [JsonProperty(Order = 5, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public short MaxLength {
            get {
                return this._MaxLength;
            }
            set {
                this.ThrowIfFrozen();
                this._MaxLength = value;
            }
        }

        [JsonProperty(Order = 6, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool FixedLength {
            get {
                return this._FixedLength;
            }
            set {
                this.ThrowIfFrozen();
                this._FixedLength = value;
            }
        }

        [JsonProperty(Order = 7, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte Precision {
            get {
                return this._Precision;
            }
            set {
                this.ThrowIfFrozen();
                this._Precision = value;
            }
        }

        [JsonProperty(Order = 8, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte Scale {
            get {
                return this._Scale;
            }
            set {
                this.ThrowIfFrozen();
                this._Scale = value;
            }
        }

        [JsonProperty(Order = 9, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Unicode {
            get {
                return this._Unicode;
            }
            set {
                this.ThrowIfFrozen();
                this._Unicode = value;
            }
        }
        public bool ShouldSerializeUnicode() => !this.Unicode;

        public override Type GetClrType() => this._Type;
    }
}
