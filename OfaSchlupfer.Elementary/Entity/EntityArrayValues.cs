namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// An entity that stores it's data in an array.
    /// </summary>
    public class EntityArrayValues
        : FreezeableObject
        , IEntity
        , IEntityArrayValues {
        /// <summary>
        /// Convert the rows to ProjectChange
        /// </summary>
        /// <typeparam name="T">the target class.</typeparam>
        /// <param name="sqlResult">the read values</param>
        /// <param name="factory">a factory for the target instances</param>
        /// <returns>the list of read items.</returns>
        public static List<T> ConvertFromSqlResult<T>(string entityTypeName, SqlReadResult sqlResult, Func<MetaEntityArrayValues /*metaData*/, object[] /*values*/, T> factory)
            where T : EntityArrayValues {
            var result = new List<T>(sqlResult.Rows.Count);
            var meta = new MetaEntityArrayValues(entityTypeName, sqlResult.FieldNames);
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
        private IMetaEntityArrayValues _MetaData;
        private object[] _Values;

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        public IMetaEntity MetaData { get { return this._MetaData; } }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        public object[] Values {
            get {
                return this._Values;
            }
            set {
                this.ThrowIfFrozen();
                this.Validate(value, false);
                this._Values = value;
            }
        }

        /// <summary>
        /// INTERNAL
        /// Get the object value
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>the value</returns>
        public object GetObjectValue(int index) { return this._Values[index]; }

        /// <summary>
        /// INTERNAL
        /// Set the value at the index
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="value">the new value</param>
        public void SetObjectValue(int index, object value) {
            this.ThrowIfFrozen();
            var metaProperty = this._MetaData.GetPropertyByIndex(index);
            this._MetaData.Validate(metaProperty, value, false);
            this._Values[index] = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityArrayValues"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public EntityArrayValues(IMetaEntityArrayValues metaData, object[] values) {
            this._MetaData = metaData;
            if ((object)values == null) {
                var cnt = metaData.GetPropertiesByIndex().Count;
                this._Values = new object[cnt];
            } else {
                this.Validate(values, false);
                this._Values = values;
            }
        }


        public string Validate(object[] values, bool validateOrThrow) => this._MetaData?.Validate(values, validateOrThrow);
    }
}
