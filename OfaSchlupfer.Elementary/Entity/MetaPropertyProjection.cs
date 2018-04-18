namespace OfaSchlupfer.Entity {
    using System;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Property for projection
    /// </summary>
    public class MetaPropertyProjection
        : FreezeableObject
        , IMetaProperty {
        private readonly IMetaProperty _MetaProperty;
        private IMetaEntity _MetaEntity;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyProjection"/> class.
        /// </summary>
        /// <param name="name">front name</param>
        /// <param name="projectedName">back name</param>
        public MetaPropertyProjection(string name, string projectedName) {
#warning todo MetaPropertyProjection
            //IMetaProperty  metaProperty,
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

#warning thinkof
        public Type PropertyType { get { return this._MetaProperty.PropertyType; } set { this._MetaProperty.PropertyType = value; } }
        public IMetaEntity MetaEntity {
            get {
                return this._MetaEntity;
            }
            set {
                if (ReferenceEquals(this._MetaEntity, value)) { return; }

                if ((object)this._MetaEntity != null) {
                    this.ThrowIfFrozen();
                    throw new ArgumentException("Cannot be set again");
                }
                this._MetaEntity = value;
                //if (this._ChainedMetaProperty != null) {
                //    if (this._ChainedMetaProperty.MetaEntity == null) {
                //        this._ChainedMetaProperty.MetaEntity = value;
                //    }
                //}
            }
        }

        /// <summary>
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity.</param>
        /// <returns>the bound accessor</returns>
        public IAccessor GetAccessor(object entity) {
            return new AccessorProjection(this, (EntityProjection)entity);
        }

#warning TODO Validate MetaPropertyProjection
        public string Validate(object value, bool validateOrThrow) {
            return null;
        }
    }
}
