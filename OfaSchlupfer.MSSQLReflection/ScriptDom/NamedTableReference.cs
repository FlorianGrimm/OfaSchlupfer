using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class NamedTableReference : TableReferenceWithAlias {
        private SchemaObjectName _schemaObject;

        private List<TableHint> _tableHints = new List<TableHint>();

        private TableSampleClause _tableSampleClause;

        private TemporalClause _temporalClause;

        public SchemaObjectName SchemaObject {
            get {
                return this._schemaObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObject = value;
            }
        }

        public List<TableHint> TableHints {
            get {
                return this._tableHints;
            }
        }

        public TableSampleClause TableSampleClause {
            get {
                return this._tableSampleClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableSampleClause = value;
            }
        }

        public TemporalClause TemporalClause {
            get {
                return this._temporalClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._temporalClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObject?.Accept(visitor);
            base.AcceptChildren(visitor);
            for (int i=0, count = this.TableHints.Count; i < count; i++) {
                this.TableHints[i].Accept(visitor);
            }
            this.TableSampleClause?.Accept(visitor);
            this.TemporalClause?.Accept(visitor);
        }
    }
}
