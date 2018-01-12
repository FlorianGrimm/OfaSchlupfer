using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UpdateStatisticsStatement : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        private List<Identifier> _subElements = new List<Identifier>();

        private List<StatisticsOption> _statisticsOptions = new List<StatisticsOption>();

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> SubElements {
            get {
                return this._subElements;
            }
        }

        public List<StatisticsOption> StatisticsOptions {
            get {
                return this._statisticsOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            for (int i=0, count = this.SubElements.Count; i < count; i++) {
                this.SubElements[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.StatisticsOptions.Count; j < count2; j++) {
                this.StatisticsOptions[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
