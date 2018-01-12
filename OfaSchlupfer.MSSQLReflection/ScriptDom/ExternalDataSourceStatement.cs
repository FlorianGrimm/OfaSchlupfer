using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ExternalDataSourceStatement : TSqlStatement {
        private Identifier _name;

        private ExternalDataSourceType _dataSourceType;

        private Literal _location;

        private List<ExternalDataSourceOption> _externalDataSourceOptions = new List<ExternalDataSourceOption>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public ExternalDataSourceType DataSourceType {
            get {
                return this._dataSourceType;
            }
            set {
                this._dataSourceType = value;
            }
        }

        public Literal Location {
            get {
                return this._location;
            }
            set {
                base.UpdateTokenInfo(value);
                this._location = value;
            }
        }

        public List<ExternalDataSourceOption> ExternalDataSourceOptions {
            get {
                return this._externalDataSourceOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Location?.Accept(visitor);
            for (int i=0, count = this.ExternalDataSourceOptions.Count; i < count; i++) {
                this.ExternalDataSourceOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
