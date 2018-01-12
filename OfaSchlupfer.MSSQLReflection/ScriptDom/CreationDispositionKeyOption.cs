using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreationDispositionKeyOption : KeyOption {
        private bool _isCreateNew;

        public bool IsCreateNew {
            get {
                return this._isCreateNew;
            }
            set {
                this._isCreateNew = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
