﻿namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// a element with an name
    /// </summary>
    [JsonObject]
    public class ModelSqlNamedElement {
        /// <summary>
        /// backfield for Name
        /// </summary>
        [JsonIgnore]
        protected SqlName _Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlNamedElement"/> class.
        /// </summary>
        public ModelSqlNamedElement() { }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Child); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the type
        /// </summary>
#warning kill this?
        [JsonIgnore]
        public ModelSqlElementType Type { get; set; }
    }
}
