using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InsertBulkColumnDefinition : TSqlFragment {
        private ColumnDefinitionBase _column;

        private NullNotNull _nullNotNull;

        public ColumnDefinitionBase Column {
            get {
                return this._column;
            }
            set {
                base.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public NullNotNull NullNotNull {
            get {
                return this._nullNotNull;
            }
            set {
                this._nullNotNull = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
