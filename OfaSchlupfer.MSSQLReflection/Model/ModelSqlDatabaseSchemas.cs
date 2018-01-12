namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;

    public sealed class ModelSqlDatabaseSchemas : BuildTargetBase {
        protected readonly Dictionary<SqlName, ModelSqlSchema> _ByName;
        private ModelSqlSchema[] _Cache;

        public ModelSqlDatabaseSchemas() {
            this._ByName = new Dictionary<SqlName, ModelSqlSchema>();
        }
        public ModelSqlDatabaseSchemas(ModelSqlDatabaseSchemas src) {
            this._ByName = new Dictionary<SqlName, ModelSqlSchema>(src._ByName);
        }

        public Builder GetBuilder(Action<ModelSqlDatabaseSchemas> setTarget = null, bool clone = false)
            => new Builder((ModelSqlDatabaseSchemas)this.UnFreeze(clone), setTarget);

        public ModelSqlSchema[] GetAll() {
            if (this.IsFrozen) {
                return this._Cache ?? (this._Cache = this._ByName.Values.ToArray());
            } else {
                return this._ByName.Values.ToArray();
            }
        }

        /// <summary>
        /// Gets the schema by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public ModelSqlSchema GetByName(SqlName name) {
            ModelSqlSchema result;
            this._ByName.TryGetValue(name, out result);
            return result;
        }

        public override IBuildTarget UnFreeze(bool cloneAlways = false) {
            if (this.IsFrozen || cloneAlways) {
                var result = new ModelSqlDatabaseSchemas(this);
                return result;
            } else {
                return this;
            }
        }

        public sealed class Builder {
            private readonly Action<ModelSqlDatabaseSchemas> _SetTarget;
            private ModelSqlDatabaseSchemas _Target;

            internal Builder(ModelSqlDatabaseSchemas target, Action<ModelSqlDatabaseSchemas> setTarget) {
                this._Target = target;
                this._SetTarget = setTarget;
            }

            private ModelSqlDatabaseSchemas ensureUnfrozen() {
                if (this._Target.IsFrozen) {
                    var target = (ModelSqlDatabaseSchemas)this._Target.UnFreeze(false);
                    this._Target = target;
                    if ((object)this._SetTarget != null) {
                        this._SetTarget(target);
                    }
                    return target;
                } else {
                    return this._Target;
                }
            }

            public ModelSqlSchema Add(ModelSqlSchema sqlSchema) {
                if ((object)sqlSchema == null) { throw new ArgumentNullException(nameof(sqlSchema)); }
                var schemaByName = ensureUnfrozen()._ByName;
                ModelSqlSchema result;
                schemaByName.TryGetValue(sqlSchema.Name, out result);
                schemaByName[sqlSchema.Name] = sqlSchema;
                return result;
            }

            public ModelSqlDatabaseSchemas GetTarget() {
                this._Target.Freeze();
                return this._Target;
            }
        }
    }
}
