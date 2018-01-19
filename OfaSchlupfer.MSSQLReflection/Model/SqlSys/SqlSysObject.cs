namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysObject : EntityArrayProp {
        /// <summary>
        /// SELECT o.name, o.object_id, o.schema_id, o.parent_object_id, o.type, o.create_date, o.modify_date, m.definition, sn.base_object_name
        /// FROM sys.objects o
        /// LEFT JOIN sys.sql_modules m
        ///
        ///     ON o.object_id = m.object_id
        /// LEFT JOIN sys.synonyms sn
        ///
        ///     ON o.object_id = sn.object_id
        /// WHERE (o.object_id>0) AND(o.is_ms_shipped= 0)
        /// ;
        /// </summary>
        public const string SELECTStatement = @"
SELECT o.name, o.object_id, o.schema_id, o.parent_object_id, o.type, o.create_date, o.modify_date, m.definition, sn.base_object_name
FROM sys.objects o
LEFT JOIN sys.sql_modules m
    ON o.object_id = m.object_id
LEFT JOIN sys.synonyms sn
    ON o.object_id = sn.object_id
WHERE (o.object_id>0) AND (o.is_ms_shipped=0)
;
        ";

        /// <summary>
        /// The columns - can be null.
        /// </summary>
        public List<SqlSysColumn> Columns;

        /// <summary>
        /// The parameters - can be null.
        /// </summary>
        public List<SqlSysParameter> Parameters;

        /// <summary>
        /// The parameters - can be null.
        /// </summary>
        public List<SqlSysIndex> Indexes;

        /// <summary>
        /// The ForeignKeys - can be null.
        /// </summary>
        public List<SqlSysForeignKey> ForeignKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysObject"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysObject(MetaEntityArrayProp metaData, object[] values)
            : base(metaData, values) {
            this.Columns = new List<SqlSysColumn>();
            this.Parameters = new List<SqlSysParameter>();
        }

#pragma warning disable SA1101 // Prefix local calls with this
        /// <summary>
        /// Gets the Object name.
        /// </summary>
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        /// <summary>
        /// Gets the Object identification number. Is unique within a database.
        /// </summary>
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }

        /// <summary>
        /// Gets the ID of the schema that the object is contained in.
        /// </summary>
        public int schema_id { get { return this.GetPropertyAsInt(nameof(schema_id)); } }

        /// <summary>
        /// Gets the ID of the object to which this object belongs. 0 = Not a child object.
        /// </summary>
        public int parent_object_id { get { return this.GetPropertyAsInt(nameof(parent_object_id)); } }

        /// <summary>
        /// Gets the type
        /// AF = Aggregate function (CLR)
        /// C = CHECK constraint
        /// D = DEFAULT(constraint or stand-alone)
        /// F = FOREIGN KEY constraint
        /// FN = SQL scalar function
        /// FS = Assembly(CLR) scalar-function
        /// FT = Assembly(CLR) table-valued function
        /// IF = SQL inline table-valued function
        /// IT = Internal table
        /// P = SQL Stored Procedure
        /// PC = Assembly(CLR) stored-procedure
        /// PG = Plan guide
        /// PK = PRIMARY KEY constraint
        /// R = Rule(old-style, stand-alone)
        /// RF = Replication-filter-procedure
        /// S = System base table
        /// SN = Synonym
        /// SQ = Service queue
        /// TA = Assembly(CLR) DML trigger
        /// TF = SQL table-valued-function
        /// TR = SQL DML trigger
        /// TT = Table type
        /// U = Table(user-defined)
        /// UQ = UNIQUE constraint
        /// V = View
        /// X = Extended stored procedure
        /// </summary>
        public string type { get { return this.GetPropertyAsString(nameof(type)); } }

        /// <summary>
        /// Gets the date the object was created.
        /// </summary>
        public System.DateTime create_date { get { return this.GetPropertyAsDateTime(nameof(create_date)); } }

        /// <summary>
        /// Gets date the object was last modified by using an ALTER statement.If the object is a table or a view, modify_date also changes when a clustered index on the table or view is created or altered.
        /// </summary>
        public System.DateTime modify_date { get { return this.GetPropertyAsDateTime(nameof(modify_date)); } }

        /// <summary>
        /// Gets the sql create statement.
        /// </summary>
        public string definition { get { return this.GetPropertyAsString(nameof(definition)); } }

        /// <summary>
        /// Gets if synonym the referenced object
        /// </summary>
        public string base_object_name { get { return this.GetPropertyAsString(nameof(base_object_name)); } }
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <returns>the columns not null</returns>
        public List<SqlSysColumn> GetColumns() {
            if (this.Columns == null) {
                this.Columns = new List<SqlSysColumn>();
            }
            return this.Columns;
        }

        /// <summary>
        /// The parameters.
        /// </summary>
        /// <returns>the parameters not null</returns>
        public List<SqlSysParameter> GetParameters() {
            if (this.Parameters == null) {
                this.Parameters = new List<SqlSysParameter>();
            }
            return this.Parameters;
        }

        /// <summary>
        /// The indexes.
        /// </summary>
        /// <returns>the parameters not null</returns>
        public List<SqlSysIndex> GetIndexes() {
            if (this.Indexes == null) {
                this.Indexes = new List<SqlSysIndex>();
            }
            return this.Indexes;
        }

        /// <summary>
        /// The parameters.
        /// </summary>
        /// <returns>the parameters not null</returns>
        public List<SqlSysForeignKey> GetForeignKeys() {
            if (this.ForeignKeys == null) {
                this.ForeignKeys = new List<SqlSysForeignKey>();
            }
            return this.ForeignKeys;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>the name or the object_id.</returns>
        public override string ToString() {
            try {
                return this.name;
            } catch { }
            try {
                return this.object_id.ToString();
            } catch { }
            return base.ToString();
        }

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysObject Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysObject(metaData, values);
        }
    }
}