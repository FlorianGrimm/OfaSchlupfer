namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// An entity that stores it's data in an array.
    /// </summary>
    [JsonObject()]
    public class EntityFlexible
        : FreezeableObject
        , IEntity
        , IEntityFlexible {
        /// <summary>
        /// Convert the rows to ProjectChange
        /// </summary>
        /// <typeparam name="T">the target class.</typeparam>
        /// <param name="sqlResult">the read values</param>
        /// <param name="factory">a factory for the target instances</param>
        /// <returns>the list of read items.</returns>
        public static List<T> ConvertFromSqlResult<T>(string entityTypeName, SqlReadResult sqlResult, Func<MetaEntityFlexible /*metaData*/, object[] /*values*/, T> factory)
            where T : EntityFlexible {
            var result = new List<T>(sqlResult.Rows.Count);
            var meta = new MetaEntityFlexible(entityTypeName, sqlResult.FieldNames);
            var length = sqlResult.FieldNames.Length;
            foreach (var row in sqlResult.Rows) {
                result.Add(factory(meta, row));
            }
            return result;
        }

        private IMetaEntityFlexible _MetaData;
        private object[] _Values;

        /// <summary>
        /// For Deserialization
        /// </summary>
        public EntityFlexible() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFlexible"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public EntityFlexible(IMetaEntityFlexible metaData, object[] values) {
            this._MetaData = metaData;
            if ((object)values == null) {
                var cnt = metaData.GetPropertiesByIndex().Count;
                this._Values = new object[cnt];
            } else {
                this.Validate(values, false);
                this._Values = values;
            }
        }

#warning soon MetaDataEntityTypeName
        /*
        public string MetaDataEntityTypeName {
        get {
                return this._MetaData?.EntityTypeName;
            }
            set {
            }
        }
        */

        /// <summary>
        /// Gets the metadata.
        /// </summary>
#warning soon        [JsonProperty(ItemIsReference = true)]
        [JsonIgnore]
        public IMetaEntity MetaData {
            get {
                return this._MetaData;
            }
            set {
                this.ThrowIfFrozen();
                if (value is IMetaEntityFlexible metaEntityFlexible) {
                    if (this.SetRefPropertyOnce<IMetaEntityFlexible>(ref this._MetaData, metaEntityFlexible)) {
                        if (this._Values == null) {
                            var cnt = metaEntityFlexible.GetPropertiesByIndex().Count;
                            this._Values = new object[cnt];
                        }
                    }
                } else {
                    throw new InvalidCastException("IMetaEntityFlexible needed");
                }
            }
        }

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

        public string Validate(object[] values, bool validateOrThrow) => this._MetaData?.Validate(values, validateOrThrow);
    }
}
