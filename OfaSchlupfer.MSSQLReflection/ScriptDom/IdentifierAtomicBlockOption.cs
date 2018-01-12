using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentifierAtomicBlockOption : AtomicBlockOption {
        private Identifier _value;

        public Identifier Value {
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
