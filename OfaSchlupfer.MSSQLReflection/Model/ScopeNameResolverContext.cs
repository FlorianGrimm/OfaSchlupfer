﻿#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// dev
    /// </summary>
    public class ScopeNameResolverContext
        : IScopeNameResolverContext {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeNameResolverContext"/> class.
        /// </summary>
        /// <param name="database">the database</param>
        public ScopeNameResolverContext(ModelSqlDatabase database) {
            this.ModelDatabase = database;
            this.ModelSqlServer = database.SqlServer;
        }

        /// <summary>
        /// Gets the current database
        /// </summary>
        public ModelSqlDatabase ModelDatabase { get; }

        /// <summary>
        /// Gets the current sever
        /// </summary>
        public ModelSqlServer ModelSqlServer { get; }

        // default schema?
        // handle use?
        public object Resolve(SqlName name) {
#warning more magic needed here...
            return this.ModelDatabase.ResolveObject(name, this);
        }
    }
}
