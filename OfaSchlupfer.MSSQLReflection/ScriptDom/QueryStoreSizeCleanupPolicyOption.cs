using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreSizeCleanupPolicyOption : QueryStoreOption {
        private QueryStoreSizeCleanupPolicyOptionKind _value;

        public QueryStoreSizeCleanupPolicyOptionKind Value {
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
