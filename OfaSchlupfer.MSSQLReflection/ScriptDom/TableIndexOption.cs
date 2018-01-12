using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableIndexOption : TableOption {
        private TableIndexType _value;

        public TableIndexType Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
