namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A Simple definition for a SQL result.
    /// </summary>
    public class SqlReadResult {
        private readonly List<object[]> _Rows;
        private readonly List<string> _MeassureMessage;
        private readonly List<string> _MeassureError;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlReadResult"/> class.
        /// </summary>
        public SqlReadResult() {
            this._Rows = new List<object[]>();
            this._MeassureMessage = new List<string>();
            this._MeassureError = new List<string>();
        }

        /// <summary>
        /// Gets or sets the result index
        /// </summary>
        public int ResultIndex { get; set; }

        /// <summary>
        /// Gets or sets the field count
        /// </summary>
        public int FieldCount { get; set; }

        /// <summary>
        /// Gets or sets the fieldnames
        /// </summary>
        public string[] FieldNames { get; set; }

        /// <summary>
        /// Gets or sets the FieldTypes.
        /// </summary>
        public string[] FieldTypes { get; set; }

        /// <summary>
        /// Gets the data rows
        /// </summary>
        public List<object[]> Rows { get { return this._Rows; } }

        /// <summary>
        /// Gets the messages from the meassure.
        /// </summary>
        public List<string> MeassureMessage { get { return this._MeassureMessage; } }

        /// <summary>
        /// Gets the messages from the meassure.
        /// </summary>
        public List<string> MeassureError { get { return this._MeassureError; } }

        /// <summary>
        /// Add a  row
        /// </summary>
        /// <param name="values">the row</param>
        /// <returns>this.</returns>
        public SqlReadResult Add(object[] values) {
            if (this.FieldCount != values.Length) {
                if (this.FieldCount == 0) {
                    this.FieldCount = values.Length;
                } else {
                    throw new ArgumentException("FieldCount != values.Length");
                }
            }
            this.Rows.Add(values);
            return this;
        }
    }
}
