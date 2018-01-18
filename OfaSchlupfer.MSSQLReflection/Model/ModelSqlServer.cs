namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Server
    /// </summary>
    public class ModelSqlServer {
        private readonly Dictionary<SqlName, ModelSqlDatabase> _Database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlServer"/> class.
        /// </summary>
        public ModelSqlServer() {
            this._Database = new Dictionary<SqlName, ModelSqlDatabase>();
        }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        public Dictionary<SqlName, ModelSqlDatabase> Database => this._Database;

        /// <summary>
        /// Gets the type by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlDatabase GetTypeByName(SqlName name) => this._Database.GetValueOrDefault(name);

        /// <summary>
        /// Gets the named object called name.
        /// </summary>
        /// <param name="name">the name to serach for</param>
        /// <returns>the found object or null.</returns>
        public object GetObject(SqlName name) {
            object result;

            result = this._Database.GetValueOrDefault(name);
            if ((object)result != null) { return result; }

            // TODO check if name has 3 parts - than use the 3rd and go ahead with 2

            return null;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="sqlName">the name to search for</param>
        /// <returns>the named object or null.</returns>
        public object Resolve(SqlName sqlName) {
            return this.GetObject(sqlName);
        }
    }
}
