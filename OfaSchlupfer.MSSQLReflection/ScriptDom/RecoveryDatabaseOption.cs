using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RecoveryDatabaseOption : DatabaseOption {
        private RecoveryDatabaseOptionKind _value;

        public RecoveryDatabaseOptionKind Value {
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
