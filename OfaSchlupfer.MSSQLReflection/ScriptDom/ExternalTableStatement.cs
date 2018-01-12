using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ExternalTableStatement : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        private List<ExternalTableColumnDefinition> _columnDefinitions = new List<ExternalTableColumnDefinition>();

        private Identifier _dataSource;

        private List<ExternalTableOption> _externalTableOptions = new List<ExternalTableOption>();

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<ExternalTableColumnDefinition> ColumnDefinitions {
            get {
                return this._columnDefinitions;
            }
        }

        public Identifier DataSource {
            get {
                return this._dataSource;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataSource = value;
            }
        }

        public List<ExternalTableOption> ExternalTableOptions {
            get {
                return this._externalTableOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            for (int i=0, count = this.ColumnDefinitions.Count; i < count; i++) {
                this.ColumnDefinitions[i].Accept(visitor);
            }
            this.DataSource?.Accept(visitor);
            int j = 0;
            for (int count2 = this.ExternalTableOptions.Count; j < count2; j++) {
                this.ExternalTableOptions[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
