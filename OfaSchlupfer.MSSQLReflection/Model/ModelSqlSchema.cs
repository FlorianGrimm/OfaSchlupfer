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
        private readonly Dictionary<SqlName, ModelSqlType> _Types;
        private readonly Dictionary<SqlName, ModelSqlTable> _Tables;
        private readonly Dictionary<SqlName, ModelSqlView> _Views;
        private readonly Dictionary<SqlName, ModelSqlProcedure> _Procedures;
        private SqlName _Name;
        private SqlScope _Scope;
        private ModelSqlDatabase _Database;

        public ModelSqlSchema() {
            this._Types = new Dictionary<SqlName, ModelSqlType>(SqlNameEqualityComparer.Level1);
            this._Tables = new Dictionary<SqlName, ModelSqlTable>(SqlNameEqualityComparer.Level1);
            this._Views = new Dictionary<SqlName, ModelSqlView>(SqlNameEqualityComparer.Level1);
            this._Procedures = new Dictionary<SqlName, ModelSqlProcedure>(SqlNameEqualityComparer.Level1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="scopeDatbase">the database scope.</param>
        public ModelSqlSchema(SqlScope scopeDatbase)
            : this() {
            this._Scope = (scopeDatbase?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlSchema"/> class.
        /// </summary>
        /// <param name="database">the owner</param>
        /// <param name="name">the name of the schema</param>
        public ModelSqlSchema(ModelSqlDatabase database, string name)
            : this(database.GetScope()) {
            this.Name = database.Name.Child(name, ObjectLevel.Schema);
            this._Database = database;
        }

        public ModelSqlSchema(ModelSqlSchema src) {
            this.Name = src.Name;
        }

        /// <summary>
        /// Add this to the parent
        /// </summary>
        /// <returns>this.</returns>
        public ModelSqlSchema AddToParent() {
            this._Database.AddSchema(this);
            return this;
        }

        public void AddType(ModelSqlType modelSqlType) {
            this._Types[modelSqlType.Name] = modelSqlType;
            this._Database.AddType(modelSqlType);
        }

        public void AddTable(ModelSqlTable modelSqlTable) {
            this._Tables[modelSqlTable.Name] = modelSqlTable;
            this._Database.AddTable(modelSqlTable);
        }

        public void AddView(ModelSqlView modelSqlView) {
            this._Views[modelSqlView.Name] = modelSqlView;
            this._Database.AddView(modelSqlView);
        }

        public void AddProcedure(ModelSqlProcedure modelSqlProcedure) {
            this._Procedures[modelSqlProcedure.Name] = modelSqlProcedure;
            this._Database.AddProcedure(modelSqlProcedure);
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Schema); } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
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
