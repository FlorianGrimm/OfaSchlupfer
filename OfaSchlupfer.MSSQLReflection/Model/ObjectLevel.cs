namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// The object level
    /// </summary>
    public enum ObjectLevel {
        /// <summary>
        /// no idead what this is.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Declare var in script or procedure
        /// </summary>
        Local = 0,

        /// <summary>
        /// column of table or view
        /// </summary>
        Column = 1,

        /// <summary>
        /// table, view, procedure, ...
        /// </summary>
        Object = 2,

        /// <summary>
        /// schema
        /// </summary>
        Schema = 3,

        /// <summary>
        /// database
        /// </summary>
        Database = 4,

        /// <summary>
        /// server
        /// </summary>
        Server = 5
    }
}