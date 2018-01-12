using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileGroupOrPartitionScheme : TSqlFragment {
        private IdentifierOrValueExpression _name;

        private List<Identifier> _partitionSchemeColumns = new List<Identifier>();

        public IdentifierOrValueExpression Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<Identifier> PartitionSchemeColumns {
            get {
                return this._partitionSchemeColumns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.PartitionSchemeColumns.Count; i < count; i++) {
                this.PartitionSchemeColumns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
