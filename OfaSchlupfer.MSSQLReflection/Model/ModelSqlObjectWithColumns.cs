namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using OfaSchlupfer.Elementary.Immutable;

    public abstract class ModelSqlObjectWithColumns : BuildTargetBase {
        private SqlName _Name;
        protected ModelDictionary<SqlName, ModelSqlColumn> _Columns;
        internal OfaSchlupfer.MSSQLReflection.SqlCode.ISqlCodeType SqlCodeType;
        //public readonly Dictionary<int, ModelSqlColumn> ColumnById;
        //public readonly Dictionary<SqlName, ModelSqlColumn> ColumnByName;
        public ModelSqlObjectWithColumns() {
            //this.ColumnById = new Dictionary<int, ModelSqlColumn>();
            //this.ColumnByName = new Dictionary<SqlName, ModelSqlColumn>();
            this._Columns = new ModelDictionary<SqlName, ModelSqlColumn>();
        }

        public ModelSqlObjectWithColumns(ModelSqlObjectWithColumns src, ModelDictionary<SqlName, ModelSqlColumn> columns) {
            this.Name = src.Name;
            // this._Columns = ((src._Columns != null) && (src._Columns.IsFrozen)) ? src._Columns : new ModelDictionary<SqlName, ModelSqlColumn>(src._Columns);
            this._Columns = ModelDictionary<SqlName, ModelSqlColumn>.FactoryCopy(columns, src._Columns);
        }

        public SqlName Name { get { return this._Name; } set { this.ThrowIfFozen(); this._Name = value; } }

        public ModelDictionary<SqlName, ModelSqlColumn> Columns => this._Columns;

        public ModelSqlColumn GetColumnByName(SqlName name) {
            return this._Columns.GetByName(name);
        }

        public abstract class ModelSqlObjectWithColumnsBuilder<TModel>
            : BuilderBase<TModel>
            where TModel : ModelSqlObjectWithColumns {

            protected ModelSqlObjectWithColumnsBuilder(TModel target, bool clone, Action<TModel> setUnFrozen, Action<TModel> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

            public ModelDictionary<SqlName, ModelSqlColumn> Columns {
                get {
                    return this._Target._Columns;
                }

                set {
                    if (ReferenceEquals(this._Target._Columns, value)) { return; }
                    this.EnsureUnfrozen()._Columns = value;
                }
            }
        }
    }
}