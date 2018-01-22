#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Scope for names
    /// </summary>
    public sealed class SqlCodeScope {
        /// <summary>
        /// the name for debugging
        /// </summary>
        public readonly string Name;
        public readonly SqlCodeScope Parent;
        public readonly SqlCodeScope Previous;
        public readonly ModelSqlDatabase ModelDatabase;
        public readonly bool IsDeclaration;
        public Dictionary<SqlName, ISqlCodeType> Content;

        private SqlCodeScope(string name, SqlCodeScope parent, bool isDeclaration, SqlCodeScope previous, ModelSqlDatabase modelDatabase) {
            if ((object)modelDatabase == null) { throw new ArgumentNullException(nameof(modelDatabase)); }
            this.Name = name;
            this.Parent = parent;
            this.Previous = previous;
            this.ModelDatabase = modelDatabase;
            this.IsDeclaration = isDeclaration;
        }

        public static SqlCodeScope CreateRoot(ModelSqlDatabase modelDatabase) {
            var result = new SqlCodeScope("DB", null, true, null, modelDatabase);
            return result;
        }

        public SqlCodeScope CreateChildScope(string name) {
            var result = new SqlCodeScope(name, this, false, null, this.ModelDatabase);
            return result;
        }

        public SqlCodeScope CreateChildDeclarationScope(string name) {
            var result = new SqlCodeScope(name, this, true, null, this.ModelDatabase);
            return result;
        }

        public SqlCodeScope CreateNextScope(string name) {
            var result = new SqlCodeScope(name, this.Parent, false, this, this.ModelDatabase);
            return result;
        }

        public bool HasContent => ((this.Content != null) && (this.Content.Count > 0));

        public void Add(string name, ISqlCodeType type) {
            if (this.Content == null) { this.Content = new Dictionary<SqlName, ISqlCodeType>(); }
            var sqlName = SqlName.Parse(name);
            this.Content.Add(sqlName, type);
        }

        public ISqlCodeType Resolve(string name) => this.Resolve(SqlName.Parse(name));

        public ISqlCodeType Resolve(SqlName sqlName) {
#warning here
            //if (this.Content != null) {
            //    ISqlCodeType result;
            //    if (this.Content.TryGetValue(sqlName, out result)) {
            //        return result;
            //    }
            //}
            //if (this.Previous != null) {
            //    return this.Parent.Resolve(sqlName);
            //}
            //if (this.IsDeclaration) {
            //    if (this.ModelDatabase != null) {
            //        var result = this.ModelDatabase.ResolveObject(sqlName);

            //        // HERE
            //    }
            //}
            //if (this.Parent != null) {
            //    return this.Parent.Resolve(sqlName);
            //}
            //if (this.ModelDatabase != null) {
            //    var modelType = this.ModelDatabase.ResolveObject(sqlName);

            //    if (modelType != null) {
            //        if (modelType is ModelSqlType modelSqlType) {
            //            return modelSqlType.SqlCodeType ?? (modelSqlType.SqlCodeType = new SqlCodeTypeSingle(modelSqlType));
            //        }
            //        if (modelType is ModelSqlObjectWithColumns modelSqlObjectWithColumns) {
            //            return modelSqlObjectWithColumns.SqlCodeType ?? (modelSqlObjectWithColumns.SqlCodeType = new SqlCodeTypeObjectWithColumns(modelSqlObjectWithColumns));
            //        }
            //    }
            //}
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
