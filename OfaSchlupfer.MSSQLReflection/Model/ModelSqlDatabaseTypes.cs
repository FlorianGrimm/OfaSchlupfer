namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;

    public sealed class ModelSqlDatabaseTypes : BuildTargetBase {
        protected readonly Dictionary<SqlName, ModelSqlType> _ByName;
        private ModelSqlType[] _Cache;

        public ModelSqlDatabaseTypes() {
            this._ByName = new Dictionary<SqlName, ModelSqlType>();
        }
        public ModelSqlDatabaseTypes(ModelSqlDatabaseTypes src) {
            this._ByName = new Dictionary<SqlName, ModelSqlType>(src._ByName);
        }

        public ModelSqlDatabaseTypesBuilder GetBuilder(Action<ModelSqlDatabaseTypes> setTarget = null, bool clone = false)
            => new ModelSqlDatabaseTypesBuilder((ModelSqlDatabaseTypes)this.UnFreeze(clone), setTarget);

        public ModelSqlType[] GetAll() {
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
        public ModelSqlType GetByName(SqlName name) {
            ModelSqlType result;
            this._ByName.TryGetValue(name, out result);
            return result;
        }

        public override IBuildTarget UnFreeze(bool cloneAlways = false) {
            if (this.IsFrozen || cloneAlways) {
                var result = new ModelSqlDatabaseTypes(this);
                return result;
            } else {
                return this;
            }
        }

        public sealed class ModelSqlDatabaseTypesBuilder {
            private readonly Action<ModelSqlDatabaseTypes> _SetTarget;
            private ModelSqlDatabaseTypes _Target;

            internal ModelSqlDatabaseTypesBuilder(ModelSqlDatabaseTypes target, Action<ModelSqlDatabaseTypes> setTarget) {
                this._Target = target;
                this._SetTarget = setTarget;
            }

            private ModelSqlDatabaseTypes ensureUnfrozen() {
                if (this._Target.IsFrozen) {
                    var target = (ModelSqlDatabaseTypes)this._Target.UnFreeze(false);
                    this._Target = target;
                    if ((object)this._SetTarget != null) {
                        this._SetTarget(target);
                    }
                    return target;
                } else {
                    return this._Target;
                }
            }

            public ModelSqlType Add(ModelSqlType sqlType) {
                if ((object)sqlType == null) { throw new ArgumentNullException(nameof(sqlType)); }
                var TypeByName = ensureUnfrozen()._ByName;
                ModelSqlType result;
                TypeByName.TryGetValue(sqlType.Name, out result);
                TypeByName[sqlType.Name] = sqlType;
                return result;
            }

            public ModelSqlDatabaseTypes GetTarget() {
                this._Target.Freeze();
                return this._Target;
            }
        }
    }
}
