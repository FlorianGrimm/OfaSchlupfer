using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FunctionCallSetClause : SetClause {
        private FunctionCall _mutatorFunction;

        public FunctionCall MutatorFunction {
            get {
                return this._mutatorFunction;
            }

            set {
                this.UpdateTokenInfo(value);
                this._mutatorFunction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.MutatorFunction?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
