namespace OfaSchlupfer.Elementary.SqlAccess {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An entity that stores it's data in an array.
    /// </summary>
    public class EntityArrayProp : IEntity {
        /// <summary>
        /// Convert the rows to ProjectChange
        /// </summary>
        /// <typeparam name="T">the target class.</typeparam>
        /// <param name="sqlResult">the read values</param>
        /// <param name="factory">a factory for the target instances</param>
        /// <returns>the list of read items.</returns>
        public static List<T> ConvertFromSqlResult<T>(SqlReadResult sqlResult, Func<MetaEntityArrayProp /*metaData*/, object[] /*values*/, T> factory)
            where T : EntityArrayProp {
            var result = new List<T>(sqlResult.Rows.Count);
            var meta = new MetaEntityArrayProp(sqlResult.FieldNames);
            var length = sqlResult.FieldNames.Length;
            foreach (var row in sqlResult.Rows) {
                result.Add(factory(meta, row));
            }
            return result;
        }

        /*
        private static EntityArrayProp Factory(MetaEntityArrayProp metaData, object[] values) {
            return new EntityArrayProp(metaData, values);
        }
        */
        private MetaEntityArrayProp _MetaData;

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        public IMetaEntity MetaData { get { return this._MetaData; } }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        public object[] Values { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityArrayProp"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public EntityArrayProp(MetaEntityArrayProp metaData, object[] values) {
            this._MetaData = metaData;
            this.Values = values;
        }

        /*
        /// <summary>
        /// Get an accessor to the property
        /// </summary>
        /// <typeparam name="TEntity">the type</typeparam>
        /// <param name="name">the name of the property</param>
        /// <returns>an bound accessor</returns>
        public IAccessor<T> GetAccessor<T>(string name) {
            //this._MetaData.GetPropertyT().GetAccessorOT
            throw new NotImplementedException();
        }
        public IAccessor<TEntity, TData> GetAccessor<TData>(string name) {
            var property = this._MetaData?.GetPropertyT<TData>(name);
            var result= property?.GetAccessorOT(this);
            return result;
        }
        */
    }
}
