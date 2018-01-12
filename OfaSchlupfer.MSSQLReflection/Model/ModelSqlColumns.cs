namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary.Immutable;

    public sealed class ModelSqlColumns : BuildTargetBase {
        protected Dictionary<SqlName,ModelSqlColumn> _Columns;
        private ModelSqlColumn[] _Cache;

        public ModelSqlColumns() {
            this._Columns = new Dictionary<SqlName, ModelSqlColumn>();
        }

        public ModelSqlColumns(ModelSqlColumns src) {
            this._Columns = new Dictionary<SqlName, ModelSqlColumn>(src._Columns);
        }

        public ModelSqlColumn[] GetAll() {
            if (this.IsFrozen) {
                return this._Cache ?? (this._Cache = this._Columns.Values.ToArray());
            } else {
                return this._Columns.Values.ToArray();
            }
        }

        public override IBuildTarget UnFreeze(bool cloneAlways = false) {
            if (this.IsFrozen || cloneAlways) {
                var result = new ModelSqlColumns(this);
                return result;
            } else {
                return this;
            }
        }
    }
}
