namespace OfaSchlupfer.MSSQLReflection.Model {
    using System.Collections.Generic;

    using OfaSchlupfer.Freezable;

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
        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlColumn> Columns { get; }

        IFreezeableOwnedKeyedCollection<SqlName, ModelSqlIndex> Indexes { get; }
    }
}
