using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ShutdownStatement : TSqlStatement {
        private bool _withNoWait;

        public bool WithNoWait {
            get {
                return this._withNoWait;
            }
            set {
                this._withNoWait = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
