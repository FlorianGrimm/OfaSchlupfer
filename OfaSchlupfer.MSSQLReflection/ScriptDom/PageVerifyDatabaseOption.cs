using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PageVerifyDatabaseOption : DatabaseOption {
        private PageVerifyDatabaseOptionKind _value;

        public PageVerifyDatabaseOptionKind Value {
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
