namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the scalar type of sql
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}-{SystemDataType}")]
    public sealed class ModelSematicScalarType 
        : ModelSematicType {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSematicScalarType"/> class.
        /// </summary>
        public ModelSematicScalarType() { }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>the name or null</returns>
        public override string GetName() {
            return this.Name.GetQFullName("[");
        }

        /// <summary>
        /// get the system condensed sql string;
        /// </summary>
        /// <returns>the sql string</returns>
        public string GetCondensed() {
            return ModelSystemDataTypeUtility.GetCondensed(this.Name, this.SystemDataType, this.MaxLength, this.Scale, this.Precision);            
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSematicScalarType"/> class.
        /// </summary>
        /// <param name="src">the source</param>
        public ModelSematicScalarType(ModelSematicScalarType src) {
            if ((object)src != null) {
                this.SystemDataType = src.SystemDataType;
                this.Name = src.Name;
                this.MaxLength = src.MaxLength;
                this.Scale = src.Scale;
                this.Precision = src.Precision;
                this.CollationName = src.CollationName;
                this.IsNullable = src.IsNullable;
            }
        }

        /// <summary>
        /// Gets or sets the datatype
        /// </summary>
        public ModelSystemDataType SystemDataType { get; set; }

        /// <summary>
        /// Gets or sets the MaxLength.
        /// </summary>
        public short? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the Precision.
        /// </summary>
        public byte? Precision { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        public byte? Scale { get; set; }

        /// <summary>
        /// Gets or sets the CollationName.
        /// </summary>
        public string CollationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is nullable.
        /// </summary>
        public bool? IsNullable { get; set; }

        public Type GetClrType() {
            return ModelSystemDataTypeUtility.ConvertToClrType(this.SystemDataType) ;
        }
    }
}
