namespace OfaSchlupfer.Freezable {
    using Newtonsoft.Json;

    /// <summary>
    /// base implementation for <see cref="IFreezeable"/>
    /// </summary>
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
