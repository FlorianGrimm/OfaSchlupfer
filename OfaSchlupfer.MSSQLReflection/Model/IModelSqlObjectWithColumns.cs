namespace OfaSchlupfer.MSSQLReflection.Model {
    using System.Collections.Generic;

    /// <summary>
    /// columns
    /// </summary>
    public interface IModelSqlObjectWithColumns {
        /// <summary>
        /// Gets the columns
        /// </summary>
        List<ModelSqlColumn> Columns { get; }
    }
}
