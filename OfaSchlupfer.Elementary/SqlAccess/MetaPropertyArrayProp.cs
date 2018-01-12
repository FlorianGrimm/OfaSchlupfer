namespace OfaSchlupfer.Elementary.SqlAccess {
    /// <summary>
    /// MetaProperty for EntityArrayProp
    /// </summary>
    public class MetaPropertyArrayProp : MetaProperty {
        private int _Index;

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index { get { return this._Index; } set { this._Index = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyArrayProp"/> class.
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="idx">the index</param>
        public MetaPropertyArrayProp(string name, int idx) {
            this.Name = name;
            this._Index = idx;
        }

        /// <summary>
        /// get the accessor for this property in this entity.
        /// </summary>
        /// <param name="entity">the entity</param>
        /// <returns>the accessor.</returns>
        public override IAccessor GetAccessor(object entity) {
            return new AccessorArrayProp(this, entity);
        }
    }
}