namespace OfaSchlupfer.Entitiy {
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
        , IEntityArrayValue {
        /// <summary>
        /// Convert the rows to ProjectChange
        /// </summary>
        /// <typeparam name="T">the target class.</typeparam>
        /// <param name="sqlResult">the read values</param>
        /// <param name="factory">a factory for the target instances</param>
        /// <returns>the list of read items.</returns>
        public static List<T> ConvertFromSqlResult<T>(SqlReadResult sqlResult, Func<MetaEntityArrayValues /*metaData*/, object[] /*values*/, T> factory)
            where T : EntityArrayValues {
            var result = new List<T>(sqlResult.Rows.Count);
            var meta = new MetaEntityArrayValues(sqlResult.FieldNames);
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
        internal object[] Values {
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
        /// Initializes a new instance of the <see cref="EntityArrayValues"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public EntityArrayValues(IMetaEntityArrayValues metaData, object[] values) {
            this._MetaData = metaData;
            this.Validate(values, false);
            this._Values = values;
        }


        public string Validate(object[] values, bool validateOrThrow) => this._MetaData?.Validate(values, validateOrThrow);
    }
}
