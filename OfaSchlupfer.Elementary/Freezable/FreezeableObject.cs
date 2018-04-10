using Newtonsoft.Json;

namespace OfaSchlupfer.Freezable {

    [JsonObject]
    public class FreezeableObject : IFreezeable {
        [JsonIgnore]
        private int _IsFrozen;

        public FreezeableObject() { }

        public virtual bool Freeze() {
            return (System.Threading.Interlocked.CompareExchange(ref this._IsFrozen, 1, 0) == 0);
        }
        public bool IsFrozen() => (this._IsFrozen == 1);
    }
}
