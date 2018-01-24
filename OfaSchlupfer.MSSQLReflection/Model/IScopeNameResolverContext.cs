#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// dev
    /// </summary>
    public interface IScopeNameResolverContext {
        ModelSqlDatabase ModelDatabase { get; }

        ModelSqlServer ModelSqlServer { get; }

        object Resolve(SqlName name);
    }
}
