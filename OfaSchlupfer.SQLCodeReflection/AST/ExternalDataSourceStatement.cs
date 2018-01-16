namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExternalDataSourceStatement : TSqlStatement {
        private Identifier _name;

        private ExternalDataSourceType _dataSourceType;

        private Literal _location;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
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
                this.UpdateTokenInfo(value);
                this._location = value;
            }
        }

        public List<ExternalDataSourceOption> ExternalDataSourceOptions { get; } = new List<ExternalDataSourceOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Location?.Accept(visitor);
            this.ExternalDataSourceOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
