﻿namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// a sql view
    /// </summary>
    public sealed class ModelSqlView
        : ModelSqlObjectWithColumns
        , IEquatable<ModelSqlView>
        , IScopeNameResolver {
        public static ModelSqlView Ensure(ModelSqlSchema modelSqlSchema, string name) {
            var sqlName = modelSqlSchema.Name.Child(name, ObjectLevel.Object);
            return modelSqlSchema.Views.GetValueOrDefault(sqlName)
                ?? new ModelSqlView(modelSqlSchema, name);
        }

        private SqlScope _Scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlView"/> class.
        /// </summary>
        public ModelSqlView() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlView"/> class.
        /// </summary>
        /// <param name="scopeSchema">the database scope</param>
        public ModelSqlView(SqlScope scopeSchema) {
            this._Scope = (scopeSchema?.CreateChildScope(this)) ?? (new SqlScope(null, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlView"/> class.
        /// </summary>
        /// <param name="schema">the owner</param>
        /// <param name="name">the name</param>
        public ModelSqlView(ModelSqlSchema schema, string name)
            : this(schema.GetScope()) {
            this.Name = schema.Name.Child(name, ObjectLevel.Object);
            this.Schema = schema;
        }

        [JsonIgnore]
        public override ModelSqlSchema Schema {
            get => this._Schema;
            set {
                if (this.SetOwnerWithChildren(ref this._Schema, value, (owner) => owner.Views)) {
                    this.Database = value?.Database;
                }
            }
        }

        [JsonIgnore]
        public override ModelSqlDatabase Database {
            get => this._Database;
            set => this.SetOwnerWithChildren(ref this._Database, value, (owner) => owner.Views);
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public override object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            var result = base.ResolveObject(name, context);
            if ((object)result != null) { return result; }

            return null;
        }

        /// <summary>
        /// Get the current scope
        /// </summary>
        /// <returns>this scope</returns>
        public override SqlScope GetScope() {
            return this._Scope ?? (this._Scope = new SqlScope(null, this));
        }

        public static bool operator ==(ModelSqlView a, ModelSqlView b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlView a, ModelSqlView b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <inheritdoc/>
        public override bool Equals(object obj) {
            if (obj is ModelSqlView other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ModelSqlView other) {
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}
