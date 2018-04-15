using Newtonsoft.Json;
using OfaSchlupfer.Freezable;

namespace OfaSchlupfer.Model {
    public class ModelNamedOwnedElement<TOwner> : ModelNamedElement {
        [JsonIgnore]
        protected TOwner _Owner;

        public ModelNamedOwnedElement() { }

        [JsonIgnore]
        public virtual TOwner Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }
    }
}