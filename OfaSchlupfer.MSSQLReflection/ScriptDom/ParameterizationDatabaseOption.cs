using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ParameterizationDatabaseOption : DatabaseOption {
        private bool _isSimple;

        public bool IsSimple {
            get {
                return this._isSimple;
            }
            set {
                this._isSimple = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
