using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetTransactionIsolationLevelStatement : TSqlStatement {
        private IsolationLevel _level;

        public IsolationLevel Level {
            get {
                return this._level;
            }
            set {
                this._level = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
