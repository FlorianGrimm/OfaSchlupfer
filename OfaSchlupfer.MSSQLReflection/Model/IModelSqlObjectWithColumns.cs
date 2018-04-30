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
        IFreezableOwnedKeyedCollection<SqlName, ModelSqlColumn> Columns { get; }

        IFreezableOwnedKeyedCollection<SqlName, ModelSqlIndex> Indexes { get; }
    }
}
