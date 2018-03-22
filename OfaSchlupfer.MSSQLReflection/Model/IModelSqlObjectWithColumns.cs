namespace OfaSchlupfer.MSSQLReflection.Model {
    using System.Collections.Generic;

    /// <summary>
    /// columns
    /// </summary>
    public interface IModelSqlObjectWithColumns
    : IModelSqlObjectWithName {
        /// <summary>
        /// think of
        /// </summary>
        /// <returns>scope</returns>
        SqlScope GetScope();

        /// <summary>
        /// Gets the columns
        /// </summary>
        List<ModelSqlColumn> Columns { get; }

        /// <summary>
        /// add the column
        /// </summary>
        /// <param name="column">the column</param>
        void AddColumn(ModelSqlColumn column);

        /// <summary>
        /// Get the column by it's name
        /// </summary>
        /// <param name="name">the name of the column</param>
        /// <returns>the column or null</returns>
        ModelSqlColumn GetColumnByName(SqlName name);
    }
}
