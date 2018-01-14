#pragma warning disable SA1600
namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;
    using OfaSchlupfer.Elementary.SqlAccess;

    public sealed class ModelSqlSchema : BuildTargetBase, IEquatable<ModelSqlSchema> {
        public static void MetaInfo(ModelSqlDatabase sqlDatabase) {
            ModelSqlTable sqlTable = new ModelSqlTable();
            sqlTable.Name = SqlName.Parse("sys.schemas");
        }

        private SqlName _Name;

        public ModelSqlSchema() {
        }

        public ModelSqlSchema(ModelSqlSchema src) {
            this.Name = src.Name;
        }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public SqlName Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line

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

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public Builder GetBuilder(bool clone, Action<ModelSqlSchema> setUnFrozen, Action<ModelSqlSchema> setFrozen)
            => new Builder(this, clone, setUnFrozen, setFrozen);

        /// <summary>
        /// Builder
        /// </summary>
        public sealed class Builder : BuilderBase<ModelSqlSchema> {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="target">the caller</param>
            /// <param name="clone">always clone</param>
            /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
            /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
            internal Builder(ModelSqlSchema target, bool clone, Action<ModelSqlSchema> setUnFrozen, Action<ModelSqlSchema> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

#pragma warning disable SA1107 // Code must not contain multiple statements on one line
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public SqlName Name { get { return this._Target._Name; } set { if (this._Target._Name == value) { return; } this.EnsureUnfrozen()._Name = value; } }
#pragma warning restore SA1107 // Code must not contain multiple statements on one line
        }
    }
}
