using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class JsonForClauseOption : ForClause {
        private JsonForClauseOptions _optionKind;

        private Literal _value;

        public JsonForClauseOptions OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
