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
        Column,

        /// <summary>
        /// table, view, procedure, ...
        /// </summary>
        Object,

        /// <summary>
        /// schema
        /// </summary>
        Schema,

        /// <summary>
        /// database
        /// </summary>
        Database,

        /// <summary>
        /// server
        /// </summary>
        Server
    }
}