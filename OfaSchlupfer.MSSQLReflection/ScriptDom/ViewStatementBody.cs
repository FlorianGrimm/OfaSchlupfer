namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ViewStatementBody : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        private List<Identifier> _columns = new List<Identifier>();

        private List<ViewOption> _viewOptions = new List<ViewOption>();

        private SelectStatement _selectStatement;

        private bool _withCheckOption;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public List<ViewOption> ViewOptions {
            get {
                return this._viewOptions;
            }
        }

        public SelectStatement SelectStatement {
            get {
                return this._selectStatement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._selectStatement = value;
            }
        }

        public bool WithCheckOption {
            get {
                return this._withCheckOption;
            }

            set {
                this._withCheckOption = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.ViewOptions.Count; j < count2; j++) {
                this.ViewOptions[j].Accept(visitor);
            }
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
