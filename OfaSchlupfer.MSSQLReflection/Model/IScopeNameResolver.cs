namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// REsolves a name
    /// </summary>
    public interface IScopeNameResolver {
        /// <summary>
        /// Resolve the name.
        /// Only resolve at this level.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="level">the level to find the item at.</param>
        /// <returns>the found object or null</returns>
        object ResolveObject(SqlName name, ObjectLevel level);
    }
}
