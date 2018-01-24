#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Scope for names
    /// </summary>
    public sealed class SqlCodeScope : IScopeNameResolver {
        /// <summary>
        /// the name for debugging
        /// </summary>
        public readonly string Name;
        public readonly SqlCodeScope Parent;
        public readonly SqlCodeScope Previous;
        public readonly bool IsDeclaration;
        public readonly IScopeNameResolverContext ScopeNameResolverContext;
        public SqlScope Content;

        private SqlCodeScope(
            string name,
            SqlCodeScope parent,
            bool isDeclaration,
            SqlCodeScope previous,
            IScopeNameResolverContext scopeNameResolverContext) {
            this.Name = name;
            this.Parent = parent;
            this.Previous = previous;
            this.IsDeclaration = isDeclaration;
            this.ScopeNameResolverContext = scopeNameResolverContext;
        }

        public static SqlCodeScope CreateRoot(IScopeNameResolverContext scopeNameResolverContext) {
            var result = new SqlCodeScope("DB", null, true, null, scopeNameResolverContext);
            result.Content = new SqlScope();
            return result;
        }

        public SqlCodeScope CreateChildScope(string name, IScopeNameResolverContext scopeNameResolverContext) {
            var result = new SqlCodeScope(name, this, false, null, scopeNameResolverContext ?? this.ScopeNameResolverContext);
            return result;
        }

        public SqlCodeScope CreateChildDeclarationScope(string name, IScopeNameResolverContext scopeNameResolverContext) {
            var result = new SqlCodeScope(name, this, true, null, scopeNameResolverContext ?? this.ScopeNameResolverContext);
            result.Content = new SqlScope();
            return result;
        }

        public SqlCodeScope CreateNextScope(string name, IScopeNameResolverContext scopeNameResolverContext) {
            var result = new SqlCodeScope(name, this.Parent, false, this, scopeNameResolverContext ?? this.ScopeNameResolverContext);
            return result;
        }

        public bool HasContent => ((this.Content != null) && (this.Content.ChildElements.Count > 0));

        public void Add(SqlName name, ISqlCodeType type) {
            if (this.Content == null) { this.Content = new SqlScope(); }

            this.Content.Add(name, type);
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            if (this.Content != null) {
                var result = this.Content.ResolveObject(name, context ?? this.ScopeNameResolverContext);
                if ((object)result != null) {
                    return result;
                }
            }
            if (this.Previous != null) {
                return this.Parent.ResolveObject(name, context);
            }
            if (this.IsDeclaration) {
                // if (this.ModelDatabase != null) {
                // var modelType = this.ModelDatabase.ResolveObject(name, context ?? this.ScopeNameResolverContext);
                var modelType = this.ScopeNameResolverContext.Resolve(name);
                if (modelType != null) {
                    if (modelType is ModelSqlType modelSqlType) {
                        return modelSqlType.SqlCodeType ?? (modelSqlType.SqlCodeType = new SqlCodeTypeSingle(modelSqlType));
                    }
                    if (modelType is ModelSqlObjectWithColumns modelSqlObjectWithColumns) {
                        return modelSqlObjectWithColumns.SqlCodeType ?? (modelSqlObjectWithColumns.SqlCodeType = new SqlCodeTypeObjectWithColumns(modelSqlObjectWithColumns));
                    }
                }

                // }
            }
            if (this.Parent != null) {
                return this.Parent.ResolveObject(name, context);
            }
            return null;
        }

        /// <summary>
        /// Get the scope marked as IsDeclaration
        /// </summary>
        /// <returns>the declaration scope or null.</returns>
        public SqlCodeScope GetDeclarationScope() {
            if (this.IsDeclaration) { return this; }
            if (this.Previous != null) { return this.Previous.GetDeclarationScope(); }
            if (this.Parent != null) { return this.Parent.GetDeclarationScope(); }
            return null;
        }

        /// <summary>
        /// name
        /// </summary>
        /// <returns>the name</returns>
        public override string ToString() => this.Name ?? "-";
    }
}
