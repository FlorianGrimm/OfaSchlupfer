namespace OfaSchlupfer.Entitiy {
    /// <summary>
    /// Property for projection
    /// </summary>
    public class MetaPropertyProjection
        : IMetaProperty {
#warning todo       FreezeableObject
        private readonly IMetaProperty _MetaProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyProjection"/> class.
        /// </summary>
        /// <param name="name">front name</param>
        /// <param name="projectedName">back name</param>
        public MetaPropertyProjection(string name, string projectedName) {
#warning todo
            //IMetaProperty metaProperty,
            //this._MetaProperty = metaProperty;
            this.Name = name;
            this.ProjectedName = projectedName;
        }


        /// <summary>
        /// Gets or sets the (frontend) name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets the projected (target) name
        /// </summary>
        public string ProjectedName { get; set; }

        /// <summary>
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity.</param>
        /// <returns>the bound accessor</returns>
        public IAccessor GetAccessor(object entity) {
            return new AccessorProjection(this, (EntityProjection)entity);
        }

#warning TODO
        public string Validate(object value, bool validateOrThrow) {
            return null;
        }
    }
}
