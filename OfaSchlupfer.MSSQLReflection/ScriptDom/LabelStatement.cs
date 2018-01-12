using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LabelStatement : TSqlStatement {
        private string _value;

        public string Value {
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
