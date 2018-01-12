namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;

    public sealed class ModelSqlDatabaseTables : BuildTargetBase {
        protected readonly Dictionary<SqlName, ModelSqlTable> _ByName;
        private ModelSqlTable[] _Cache;

        public ModelSqlDatabaseTables() {
            this._ByName = new Dictionary<SqlName, ModelSqlTable>();
        }
        public ModelSqlDatabaseTables(ModelSqlDatabaseTables src) {
            this._ByName = new Dictionary<SqlName, ModelSqlTable>(src._ByName);
        }

        public ModelSqlDatabaseTablesBuilder GetBuilder(Action<ModelSqlDatabaseTables> setTarget = null, bool clone = false)
            => new ModelSqlDatabaseTablesBuilder((ModelSqlDatabaseTables)this.UnFreeze(clone), setTarget);

        public ModelSqlTable[] GetAll() {
            if (this.IsFrozen) {
                return this._Cache ?? (this._Cache = this._ByName.Values.ToArray());
            } else {
                return this._ByName.Values.ToArray();
            }
        }

        /// <summary>
        /// Gets the Type by its's name
        /// </summary>
        /// <param name="name">the Type name to search for</param>
        /// <returns>the found Type or null.</returns>
        public ModelSqlTable GetByName(SqlName name) {
            ModelSqlTable result;
            this._ByName.TryGetValue(name, out result);
            return result;
        }

        public override IBuildTarget UnFreeze(bool cloneAlways = false) {
            if (this.IsFrozen || cloneAlways) {
                var result = new ModelSqlDatabaseTables(this);
                return result;
            } else {
                return this;
            }
        }

        public sealed class ModelSqlDatabaseTablesBuilder {
            private readonly Action<ModelSqlDatabaseTables> _SetTarget;
            private ModelSqlDatabaseTables _Target;

            internal ModelSqlDatabaseTablesBuilder(ModelSqlDatabaseTables target, Action<ModelSqlDatabaseTables> setTarget) {
                this._Target = target;
                this._SetTarget = setTarget;
            }

            private ModelSqlDatabaseTables ensureUnfrozen() {
                if (this._Target.IsFrozen) {
                    var target = (ModelSqlDatabaseTables)this._Target.UnFreeze(false);
                    this._Target = target;
                    if ((object)this._SetTarget != null) {
                        this._SetTarget(target);
                    }
                    return target;
                } else {
                    return this._Target;
                }
            }

            public ModelSqlTable Add(ModelSqlTable sqlType) {
                if ((object)sqlType == null) { throw new ArgumentNullException(nameof(sqlType)); }
                var TypeByName = ensureUnfrozen()._ByName;
                ModelSqlTable result;
                TypeByName.TryGetValue(sqlType.Name, out result);
                TypeByName[sqlType.Name] = sqlType;
                return result;
            }

            public ModelSqlDatabaseTables GetTarget() {
                this._Target.Freeze();
                return this._Target;
            }
        }
    }
}
