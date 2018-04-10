namespace OfaSchlupfer.Model {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    public class ModelEntityNameConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var modelEntityName = (ModelEntityName)value;
            writer.WriteValue(modelEntityName.GetJsonValue());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            ModelEntityName modelEntityName = new ModelEntityName();
            modelEntityName.SetJsonValue((string)reader.Value);

            return modelEntityName;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(ModelEntityName);
        }
    }

    [JsonConverter(typeof(ModelEntityNameConverter))]
    [JsonObject]
    public sealed class ModelEntityName
        : FreezeableObject
        , IMappingNamedObject<string>
        , IEquatable<ModelEntityName> {
        [JsonIgnore]
        private string _NamespaceUri;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private int _HashCode;

        public ModelEntityName(string namespaceUri = null, string fullname = null, string name = null) {
            this._NamespaceUri = namespaceUri;
            this._Name = name;
        }

        [JsonIgnore]
        public string NamespaceUri {
            get {
                return this._NamespaceUri;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (ModelUtility.Instance.StringComparer.Equals(this._NamespaceUri, value)) { return; }
                if (this._NamespaceUri != null) { throw new ArgumentException("is already set"); }
                this.ThrowIfFrozen();
                this._NamespaceUri = value;
            }
        }

        [JsonIgnore]
        public string Name {
            get {
                return this._Name;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (ModelUtility.Instance.StringComparer.Equals(this._Name, value)) { return; }
                if (this._Name != null) { throw new ArgumentException("is already set"); }
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public string GetName() => this._Name;

        public override bool Equals(object obj)
            => this.Equals(obj as ModelEntityName);

        public bool Equals(ModelEntityName other) {
            if (ReferenceEquals(other, null)) { return false; }
            var stringComparer = ModelUtility.Instance.StringComparer;
            return stringComparer.Equals(this._Name, other._Name)
                && stringComparer.Equals(this._NamespaceUri, other._NamespaceUri)
                ;
        }

        public override int GetHashCode() {
            var stringComparer = ModelUtility.Instance.StringComparer;
            return (this._HashCode == 0)
                ? (
                    this._HashCode
                        = ((this._NamespaceUri == null) ? 0 : stringComparer.GetHashCode(this._NamespaceUri))
                        //^ ((this._FullName == null) ? 0 : stringComparer.GetHashCode(this._FullName))
                        ^ ((this._Name == null) ? 0 : stringComparer.GetHashCode(this._Name))
                ) : this._HashCode
                ;
        }

        public override string ToString() {
            return "{" + (this.NamespaceUri ?? string.Empty) + "}" + (this.Name ?? string.Empty);
        }

        public string GetJsonValue() {
            return "{" + (this.NamespaceUri ?? string.Empty) + "}" + (this.Name ?? string.Empty);
        }

        private static readonly System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^{([^}]*)}([^{}]*)$");
        public void SetJsonValue(string value) {
            if (!string.IsNullOrEmpty(value)) {
                var match = r.Match(value);
                if (match.Success) {
                    this._NamespaceUri = match.Groups[1].Value;
                    this._Name = match.Groups[2].Value;
                }
            }
        }
    }

    public sealed class ModelEntityNameEqualityComparer
        //: IComparer<ModelEntityName>, IEqualityComparer<ModelEntityName>, IComparer, IEqualityComparer {
        : IEqualityComparer<ModelEntityName>, IEqualityComparer {
        public bool Equals(ModelEntityName x, ModelEntityName y) {
            var nx = ReferenceEquals(x, null);
            var ny = ReferenceEquals(y, null);
            if (nx && ny) { return true; }
            if (nx != ny) { return true; }
            var stringComparer = ModelUtility.Instance.StringComparer;
            return stringComparer.Equals(x.Name, y.Name)
                //&& stringComparer.Equals(x.FullName, y.FullName)
                && stringComparer.Equals(x.NamespaceUri, y.NamespaceUri)
                ;
        }

        public new bool Equals(object x, object y)
            => this.Equals(x as ModelEntityName, y as ModelEntityName);


        public int GetHashCode(ModelEntityName obj) {
            if ((object)obj == null) { return 0; }
            return obj.GetHashCode();
        }

        public int GetHashCode(object obj) => this.GetHashCode((ModelEntityName)obj);
    }
}
