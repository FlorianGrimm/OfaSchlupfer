namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Add an owner.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owenr</typeparam>
    public class ModelNamedOwnedElement<TOwner>
        : ModelNamedElement
        , IObjectWithOwner<TOwner>
        where TOwner : class {
        [JsonIgnore]
        protected TOwner _Owner;

        public ModelNamedOwnedElement() { }

        /// <summary>
        /// Gets or sets the owner.
        /// The owner that could be set 
        /// if it is not frozen
        /// -or- if it is frozen - the old value of Owner has to be null.
        /// </summary>
        [JsonIgnore]
        public virtual TOwner Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value);
        }
    }
}