using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ContainmentDatabaseOption : DatabaseOption {
        private ContainmentOptionKind _value;

        public ContainmentOptionKind Value {
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
