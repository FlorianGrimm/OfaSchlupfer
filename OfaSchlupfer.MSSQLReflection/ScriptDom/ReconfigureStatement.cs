using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ReconfigureStatement : TSqlStatement {
        private bool _withOverride;

        public bool WithOverride {
            get {
                return this._withOverride;
            }

            set {
                this._withOverride = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
