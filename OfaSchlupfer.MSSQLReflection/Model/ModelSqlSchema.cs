#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.SqlAccess;

    public sealed class ModelSqlSchema
        : IEquatable<ModelSqlSchema>
        , IScopeNameResolver {
        private SqlName _Name;
        private SqlScope _Scope;

        public ModelSqlSchema() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="scopeDatbase">the database scope.</param>
        public ModelSqlSchema(SqlScope scopeDatbase) {
            this._Scope = (scopeDatbase?.CreateChildScope()) ?? (SqlScope.Root.CreateChildScope(this));
        }

        public ModelSqlSchema(ModelSqlSchema src) {
            this.Name = src.Name;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = SqlScope.Root.CreateChildScope(this));
        }

        public object Resolve(SqlName name) {
            throw new NotImplementedException();
        }

        public static bool operator ==(ModelSqlSchema a, ModelSqlSchema b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlSchema a, ModelSqlSchema b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        public override bool Equals(object obj) {
            return base.Equals(obj as ModelSqlSchema);
        }

        public bool Equals(ModelSqlSchema other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        public override string ToString() => this.Name.ToString();
    }
}
