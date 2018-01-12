using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CursorDefaultDatabaseOption : DatabaseOption {
        private bool _isLocal;

        public bool IsLocal {
            get {
                return this._isLocal;
            }
            set {
                this._isLocal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
