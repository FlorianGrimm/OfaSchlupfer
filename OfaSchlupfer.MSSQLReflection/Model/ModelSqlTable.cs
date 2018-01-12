namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;
    using OfaSchlupfer.Elementary.Immutable;

    public sealed class ModelSqlTable : ModelSqlObjectWithColumns, IEquatable<ModelSqlTable> {
        public ModelSqlTable() {
        }

        public ModelSqlTable(ModelSqlTable src, ModelDictionary<SqlName, ModelSqlColumn> columns) : base(src, columns) {
        }


        public static bool operator ==(ModelSqlTable a, ModelSqlTable b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(ModelSqlTable a, ModelSqlTable b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        public override bool Equals(object obj) {
            return this.Equals(obj as ModelSqlColumn);
        }

        public bool Equals(ModelSqlTable other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                ;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        public override string ToString() => this.Name.ToString();

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setTarget">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlTable> setTarget, Action<ModelSqlTable> setFrozen)
            => new Builder(this, clone, setTarget, setFrozen);

        protected override void FreezeChildren() {
            base.FreezeChildren();
            foreach (var column in this.Columns.GetValues()) { column.Freeze(); }
        }

        /// <summary>
        /// Create a unfrozen instance
        /// </summary>
        /// <returns>a new instacne</returns>
        protected override IBuildTarget UnFreezeCreateInstance() {
            return new ModelSqlTable(this, null);
        }

        public sealed class Builder : ModelSqlObjectWithColumnsBuilder<ModelSqlTable> {

            internal Builder(ModelSqlTable target, bool clone, Action<ModelSqlTable> setUnFrozen, Action<ModelSqlTable> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

            //public ModelSqlColumn AddColumn(ModelSqlColumn sqlColumn) {
            //    if ((object)sqlColumn == null) { throw new ArgumentNullException(nameof(sqlColumn)); }
            //    //var TypeByName = ensureUnfrozen()._ByName;
            //    //ModelSqlTable result;
            //    //TypeByName.TryGetValue(sqlColumn.Name, out result);
            //    //TypeByName[sqlColumn.Name] = sqlColumn;
            //    //return result;
            //    return null;
            //}
        }
    }
}
