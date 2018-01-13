namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysObject : EntityArrayProp{
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

        public readonly List<SqlSysColumn> Columns;
        public readonly List<SqlSysParameter> Parameters;

        public SqlSysObject(MetaEntityArrayProp metaData, object[] values) : base(metaData, values) {
            this.Columns = new List<SqlSysColumn>();
            this.Parameters = new List<SqlSysParameter>();
        }

        /// <summary>
        /// Object name.
        /// </summary>
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        /// <summary>
        /// Object identification number. Is unique within a database.
        /// </summary>
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }


        /// <summary>
        /// ID of the schema that the object is contained in.
        /// </summary>
        public int schema_id { get { return this.GetPropertyAsInt(nameof(schema_id)); } }

        /// <summary>
        /// ID of the object to which this object belongs. 0 = Not a child object.
        /// </summary>
        public int parent_object_id { get { return this.GetPropertyAsInt(nameof(parent_object_id)); } }
        
        /// <summary>
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
        /// Date the object was created.
        /// </summary>
        public System.DateTime create_date { get { return this.GetPropertyAsDateTime(nameof(create_date)); } }

        /// <summary>
        /// Date the object was last modified by using an ALTER statement.If the object is a table or a view, modify_date also changes when a clustered index on the table or view is created or altered.
        /// </summary>
        public System.DateTime modify_date { get { return this.GetPropertyAsDateTime(nameof(modify_date)); } }

        /// <summary>
        /// the sql create statement.
        /// </summary>
        public string definition { get { return this.GetPropertyAsString(nameof(definition)); } }

        /// <summary>
        /// if synonym the referenced object
        /// </summary>
        public string base_object_name { get { return this.GetPropertyAsString(nameof(base_object_name)); } }

        public override string ToString() {
            try {
                return this.name;
            } catch { }
            try {
                return this.object_id.ToString();
            } catch { }
            return base.ToString();
        }
        public static SqlSysObject Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysObject(metaData, values);
        }
    }
}