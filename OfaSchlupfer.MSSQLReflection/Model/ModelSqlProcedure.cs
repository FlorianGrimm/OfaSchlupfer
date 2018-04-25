#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// ModelSqlProcedure
    /// </summary>
    public sealed class ModelSqlProcedure
        : ModelSqlSchemaChild
        , IEquatable<ModelSqlProcedure>
        , IScopeNameResolver {
        private SqlScope _Scope;
        private string _Definition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlProcedure"/> class.
        /// </summary>
        public ModelSqlProcedure() {
            this._Definition = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlProcedure"/> class.
        /// </summary>
        /// <param name="scopeSchema">the database scope</param>
        public ModelSqlProcedure(SqlScope scopeSchema) {
            this._Scope = (scopeSchema?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlProcedure"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlProcedure(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this._Schema = schema;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlProcedure"/> class.
        /// Copy contructor.
        /// </summary>
        /// <param name="src">instance to copy.</param>
        public ModelSqlProcedure(ModelSqlProcedure src) {
            this._Name = src._Name;
            this._Definition = src._Definition;
        }

        [JsonIgnore]
        public override ModelSqlSchema Owner {
            get => this._Schema;
            set => this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.Procedures);
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public string Definition { get { return this._Definition; } set { this._Definition = value ?? string.Empty; } }

#pragma warning restore SA1107 // Code must not contain multiple statements on one line

        /// <summary>
        /// Add this to the parent
        /// </summary>
        public override void AddToParent() {
            this._Schema.AddProcedure(this);
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

        /// <summary>
        /// a equals b
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equals.</returns>
        public static bool operator ==(ModelSqlProcedure a, ModelSqlProcedure b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// not equals.
        /// </summary>
        /// <param name="a">a instance.</param>
        /// <param name="b">another instance</param>
        /// <returns>true if not equals.</returns>
        public static bool operator !=(ModelSqlProcedure a, ModelSqlProcedure b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            return base.Equals(obj as ModelSqlProcedure);
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlProcedure other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            ((object)null).ToString();
            return (this.Name == other.Name)
                && (string.Equals(this.Definition, other.Definition, StringComparison.Ordinal))
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();
    }
}
