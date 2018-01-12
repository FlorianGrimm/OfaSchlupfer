using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreCapturePolicyOption : QueryStoreOption {
        private QueryStoreCapturePolicyOptionKind _value;

        public QueryStoreCapturePolicyOptionKind Value {
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
